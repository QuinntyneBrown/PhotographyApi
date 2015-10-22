using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotographyApi.Models
{
    public class Photo
    {
        public Photo()
        {
            this.Galleries = new HashSet<Gallery>();

            this.Guid = Guid.NewGuid();
        }

        public int Id { get; set; }

        [ForeignKey("PhotographerReference")]
        public int? PhotographerReferenceId { get; set; }

        public string Filename { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public string Base64String { get { return Convert.ToBase64String(Bytes); } }

        public Byte[] Bytes { get; set; }

        public string ContentType { get; set; }

        public Guid Guid { get; set; }

        public string Url { get; set; }

        public PhotographerReference PhotographerReference { get; set; }

        public ICollection<Gallery> Galleries { get; set; }
    }
}