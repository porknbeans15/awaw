using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class PersonModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lastname is Required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Middlename is Required")]
        public string Middlename { get; set; }

        [Required(ErrorMessage = "Firstname is Required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Birthdate is Required")]
        public string BirthdateStr { get; set; }

        public DateTime CreatedDatetime { get; set; }
    }
}
