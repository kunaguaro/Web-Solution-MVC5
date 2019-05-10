
using System.ComponentModel.DataAnnotations;

namespace WebAppGen.Model.Entities
{
    public class Country : Entity<int>
    {

        [Required]
        [Display(Name = "Country Name")]
        public string Name { get; set; }

    }
}
