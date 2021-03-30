using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAS.Models
{
    public class ScriptureCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Book { get; set; }

        [Required]
        public int Chapter { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        public string Verses { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Content { get; set; }
    }
}
