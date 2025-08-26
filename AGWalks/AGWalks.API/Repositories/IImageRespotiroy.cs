using AGWalks.API.Models.Domain;

namespace AGWalks.API.Repositories
{
    public interface IImageRespotiroy
    {
        Task<Image> Upload(Image image);
    }
}
