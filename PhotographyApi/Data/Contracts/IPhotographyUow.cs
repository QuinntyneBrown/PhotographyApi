using Common.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographyApi.Models;

namespace PhotographyApi.Data.Contracts
{
    public interface IPhotographyUow
    {
        IRepository<Photo> Photos { get; }
        IRepository<Gallery> Galleries { get; }
        void SaveChanges();
    }
}
