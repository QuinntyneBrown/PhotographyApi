using System.Collections.Generic;
using System.Threading.Tasks;
using PhotographyApi.Dtos;

namespace PhotographyApi.Services.Contracts
{
    public interface IPhotoService
    {
        Task<List<PhotoDto>> Upload(System.Net.Http.HttpRequestMessage request);
    }
}