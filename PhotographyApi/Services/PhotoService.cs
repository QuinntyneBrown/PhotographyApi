using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Data.Contracts;
using Common.Stream;
using PhotographyApi.Data;
using PhotographyApi.Dtos;
using PhotographyApi.Services.Contracts;
using PhotographyApi.Models;

namespace PhotographyApi.Services
{
    public class PhotoService : IPhotoService
    {
        protected readonly PhotoManagerUow uow;

        protected readonly IRepository<Photo> repository;

        public PhotoService(PhotoManagerUow uow)
        {
            this.uow = uow;
            this.repository = uow.Photos;
        }

        public async Task<List<PhotoDto>> Upload(System.Net.Http.HttpRequestMessage Request)
        {
            var photos = new List<PhotoDto>();

            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());

            NameValueCollection formData = provider.FormData;
            IList<HttpContent> files = provider.Files;

            foreach (var file in files)
            {
                var filename = new FileInfo(file.Headers.ContentDisposition.FileName.Trim(new char[] { '"' })
                    .Replace("&", "and")).Name;

                Stream stream = await file.ReadAsStreamAsync();

                var bytes = StreamHelper.ReadToEnd(stream);


                var photo = new Photo();

                if (repository.GetAll().Count(x => x.Filename == filename) < 1)
                {
                    repository.Add(photo);
                }
                else
                {
                    photo = repository.GetAll().Single(x => x.Filename == filename);
                }

                photo.Filename = filename;
                photo.Bytes = bytes;
                photo.ContentType = Convert.ToString(file.Headers.ContentType);

                photos.Add(new PhotoDto(photo));
            }

            this.uow.SaveChanges();

            return photos;

        }

        public bool PhotoExists(string filename)
        {
            return this.uow.Photos.GetAll().Count(x => x.Filename == filename) > 0;
        }
    }
}