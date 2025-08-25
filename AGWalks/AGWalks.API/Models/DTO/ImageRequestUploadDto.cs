﻿using System.ComponentModel.DataAnnotations;

namespace AGWalks.API.Models.DTO
{
    public class ImageRequestUploadDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
