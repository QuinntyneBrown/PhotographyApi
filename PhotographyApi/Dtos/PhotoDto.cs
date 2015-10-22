using System;
using PhotographyApi.Models;

namespace PhotographyApi.Dtos
{
    public class PhotoDto
    {
        public PhotoDto(Photo photo)
        {
            this.Src = string.Format(@"/api/photo/serve?guid={0}", photo.Guid);

            this.Base64String = Convert.ToBase64String(photo.Bytes);
        }

        public string Src { get; set; }

        public string Base64String { get; set; }
    }
}