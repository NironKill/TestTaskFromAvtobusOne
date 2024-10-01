using System.ComponentModel.DataAnnotations;

namespace ShorteningLink.Domain
{
    public class Link
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Url]
        public string LongURL { get; set; }

        [Required]
        public string ShortURL { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public int VisitCount { get; set; } = default(int);
    }
}
