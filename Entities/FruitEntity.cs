using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApi.Entities
{
    public class FruitEntity
    {
        public long Id { get; set; }
        [Required]
        [StringLength(20)]
        public string No { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
    }
}