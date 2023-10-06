using InnoTechProject.Configuration;
using InnoTechProject.Helpers;
using InnoTechProject.Models;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;

namespace InnoTechProject.Services
{
    public class ImageService : IImageService
    {
        private readonly CustomSettings _customSettings;

        public ImageService(IOptions<CustomSettings> customSettings) {
            _customSettings = customSettings.Value;
        }   

        public async Task<List<ImageConfig>> Process(string[] filenames)
        {
            Image img = null;
            string base64 = null;
            List<ImageConfig> configs = new List<ImageConfig>();
            List<Task<ImageConfig>> tasks = new List<Task<ImageConfig>>();

            foreach (var filename in filenames)
            {
                tasks.Add(Helper.LoadFileFromDirectory(filename, _customSettings.Directory));
            }

            foreach (var task in await Task.WhenAll(tasks))
            {
                configs.Add(task);
            }

            return configs;
        }

        public async Task<string> Save(ImageConfig[] images)
        {
            List<Task> tasks = new List<Task>();

            try
            { 
                foreach (var item in images)
                {
                    tasks.Add(Helper.SaveImageInDirectory(item, _customSettings.Directory));
                }

                await Task.WhenAll(tasks);

                return "Saved";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
    }
}
