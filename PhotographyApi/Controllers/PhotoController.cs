using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Common.Controllers;
using PhotographyApi.Data;
using PhotographyApi.Models;
using PhotographyApi.Services;

namespace PhotographyApi.Api
{
    [RoutePrefix("api/photo")]
    public class PhotoController : EFController<Photo>
    {
        public PhotoController(PhotoManagerUow uow, PhotoService photoService)
        {
            this.uow = uow;
            this.repository = uow.Photos;
            this.photoService = photoService;
        }

        [Route("serve")]
        [HttpGet]
        public HttpResponseMessage Serve([FromUri]Guid guid)
        {
            Photo photo = repository.GetAll().FirstOrDefault(x => x.Guid == guid);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            if (photo == null)
                return result;

            result.Content = new ByteArrayContent(photo.Bytes);

            result.Content.Headers.ContentType = new MediaTypeHeaderValue(photo.ContentType);

            return result;
        }

        [HttpPost]
        [Route("upload")]
        public IHttpActionResult Upload()
        {
            return Ok(this.photoService.Upload(Request).Result);
        }

        public override IHttpActionResult Add(Photo entity)
        {
            return base.Add(entity);
        }

        protected readonly PhotoService photoService;
    }
}