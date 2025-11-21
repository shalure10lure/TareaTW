using System.ComponentModel.DataAnnotations;

namespace TareaTW.Models.DTOSd
{
    public class CreateBookDto
    {
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
    }
}
