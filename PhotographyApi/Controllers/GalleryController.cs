using System.Web.Http;
using Common.Controllers;
using PhotographyApi.Data;
using PhotographyApi.Data.Contracts;
using PhotographyApi.Models;

namespace PhotoManagerApi.Api
{
    [RoutePrefix("api/gallery")]
    public class GalleryController : EFController<Gallery>
    {
        public GalleryController(IPhotographyUow uow)
        {
            this.uow = uow;
            this.repository = uow.Galleries;
        }

        [HttpGet]
        [Route("test")]
        public IHttpActionResult Test()
        {
            return Ok("test");
        }

        protected new readonly IPhotographyUow uow;
    }
}