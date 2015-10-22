using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotographyApi.Models
{
    public class Gallery
    {
        public Gallery()
        {
            this.Photos = new HashSet<Photo>();


            this.Guid = Guid.NewGuid();
        }

        public int Id { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public Guid Guid { get; set; }

        public ICollection<Photo> Photos { get; set; }
 
    }
}