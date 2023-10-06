using InnoTechProject.Configuration;
using InnoTechProject.Models;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Buffers.Text;

namespace InnoTechProject.Helpers
{
    public static class Helper
    {
        public static async Task SaveImageInDirectory(ImageConfig item, string directory)
        {
            byte[] data = Convert.FromBase64String(item.base64);
            Stream content = new MemoryStream(data);
            using (var image = await Image.LoadAsync(content))
            {
                await image.SaveAsJpegAsync(directory + "\\" + item.Filename);
            }
        }

        public static async Task<ImageConfig> LoadFileFromDirectory(string item, string directory)
        {
            Image img = await Image.LoadAsync(directory + "\\" + item);
            string base64 = img.ToBase64String(JpegFormat.Instance);
            img.Dispose();

            return new ImageConfig
            {
                Filename = item,
                base64 = base64
            };
        }
    }
}
