using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAS.Models
{
    public class ScriptureDetail
    {
        public int ScriptureId { get; set; }

        public string Book { get; set; }

        public int Chapter { get; set; }

        public string Verses { get; set; }

        public string Content { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
