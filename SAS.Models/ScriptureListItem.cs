using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAS.Models
{
    public class ScriptureListItem
    {
        [Display(Name="ID")]
        public int ScriptureId { get; set; }

        public string Book { get; set; }

        public int Chapter { get; set; }

        public string Verses { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUTC { get; set; }

    }
}
