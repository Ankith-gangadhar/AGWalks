using System.ComponentModel.DataAnnotations.Schema;

namespace AGWalks.API.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string Filename { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension{ get; set; }
        public long FileSizeInBytes { get; set; }
        public string Filepath { get; set; }
    }
}
