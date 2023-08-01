using EntityNETAzure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNETAzure
{

    [Table("Voitures")]
    internal class Voiture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Brand CarBrand { get; set; }

        [MinLength(5)]
        [Required]
        public string Model { get; set; }

        [Required]
        [MinLength(7)]
        public string Plate { get; set; }

       

        [Required]
        [Range(0, 1500)]
        public int Hp { get; set; }


        public List<Person> Drivers { get; set; }

    }
}
