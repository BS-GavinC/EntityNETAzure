using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNETAzure
{
    internal class Person
    {
        public Person()
        {
            Name = null;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Pseudo { get; set; }


        public int? DriverLicense { get; set; }
     
    }

    
}
