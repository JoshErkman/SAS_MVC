using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAS.Models
{
    public class ScriptureEdit
    {
        public int ScriptureId { get; set; }

        public string Book { get; set; }

        public int Chapter { get; set; }

        public string Verses { get; set; }

        public string Content { get; set; }
    }
}
