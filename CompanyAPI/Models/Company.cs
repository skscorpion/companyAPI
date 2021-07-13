using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Models
{
    [Table("Company", Schema = "dbo")]
    public class Company
    {
        [Key]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string CEO { get; set; }

        [Required]
        [MinLength(9)]
        public string TurnOver { get; set; }

        [Required]
        [MaxLength(100)]
        public string Website { get; set; }
        [Required]
        [MaxLength(50)]
        public string StockExchange { get; set; }

        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
