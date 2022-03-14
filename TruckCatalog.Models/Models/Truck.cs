using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckCatalog.Models.Models
{
    public class Truck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public int ManufactureYear { get; set; }
        [Required]
        public int ModelYear { get; set; }
    }
}
