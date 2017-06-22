using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApi.Models
{
    public class Fruit
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string No { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
    }
}