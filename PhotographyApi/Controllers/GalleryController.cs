using System.Web.Http;
using Common.Controllers;
using PhotographyApi.Data;
using PhotographyApi.Models;

namespace PhotoManagerApi.Api
{
    [RoutePrefix("api/gallery")]
    public class GalleryController : EFController<Gallery>
    {
        public GalleryController(PhotoManagerUow uow)
        {
            this.uow = uow;
            this.repository = uow.Galleries;
        }
    }
}