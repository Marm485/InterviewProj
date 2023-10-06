namespace InnoTechProject.Models
{
    public class SaveRequest
    {
        public int RequestId { get; set; }
        public ImageConfig[] images { get; set; } = null;
    }
}
