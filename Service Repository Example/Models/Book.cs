using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Service_Repository_Example.Models
{
    public class Book
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        [StringLength(100)]
        public string Title { get; set; }

        [Column("author")]
        [StringLength(100)]
        public string Author { get; set; }

    }
}
