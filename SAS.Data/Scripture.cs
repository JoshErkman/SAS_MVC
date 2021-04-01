using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAS.Data
{
    public class Scripture
    {
        [Key]
        public int ScriptureId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Book { get; set; }

        [Required]
        public int Chapter { get; set; }

        [Required]
        public string Verses { get; set; }

        [Required]
        public string Content { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
