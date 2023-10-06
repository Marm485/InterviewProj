using InnoTechProject.Models;

namespace InnoTechProject.Services
{
    public interface IImageService
    {
        Task<string> Save(ImageConfig[] images);

        Task<List<ImageConfig>> Process(string[] filenames);
    }
}
