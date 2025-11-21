namespace TareaTW.Models.Dtos
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
    }
}
