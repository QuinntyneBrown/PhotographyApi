using Common.Data;
using Common.Data.Contracts;
using PhotographyApi.Data.Contracts;
using PhotographyApi.Models;

namespace PhotographyApi.Data
{
    public class PhotoManagerUow : BaseUow, IPhotographyUow
    {
        public PhotoManagerUow(PhotographyContext photographyContext)
            : base(photographyContext)
        {

        }

        public IRepository<Photo> Photos { get { return GetStandardRepo<Photo>(); } }

        public IRepository<Gallery> Galleries { get { return GetStandardRepo<Gallery>(); } }
    }
}