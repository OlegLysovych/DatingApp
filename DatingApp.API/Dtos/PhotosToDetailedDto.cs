using System;

namespace DatingApp.API.Dtos
{
    public class PhotosToDetailedDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descriptpion { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; } 
    }
}