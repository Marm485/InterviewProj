using System.ComponentModel.DataAnnotations;

namespace InnoTechProject.Models
{
    public class ProcessRequest
    {
        [Required]
        public List<string> FileNames { get; set; } = null;
    }
}
