using System.Collections.Generic;
using System.Threading.Tasks;
using PhotographyApi.Dtos;

namespace PhotoManagerApi.Services.Contracts
{
    public interface IPhotoService
    {
        Task<List<PhotoDto>> Upload(System.Net.Http.HttpRequestMessage request);
    }
}