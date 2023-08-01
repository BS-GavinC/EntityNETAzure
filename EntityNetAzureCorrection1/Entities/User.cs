using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityNetAzureCorrection1.Entities
{
    internal class User
    {

        public User()
        {
            Created = DateTime.Now;
        }

        //        Creer une DB avec une table user
        //Id => PK, Identity
        //Email => Email, Unique, NN
        //Password => NN, Min 8Char
        //Pseudo => Nullable
        //DateCreationCompte => NN, Doit etre egal au moment de la creation de l'instance

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [EmailAddress]
        [Required]
        //TODO Add IS Unique to Fluent API
        public string? Email { get; set; }

        [Required]
        [MinLength(8)]
        //TODO Check en DB La contrainte MinLenght
        public string? Password { get; set; }

        public string? Pseudo { get; set; }

        [Required]
        public DateTime Created { get;}


        public override string ToString()
        {
            return $"{Id} {Email} {Password} {Pseudo} {Created}";
        }
    }
}
