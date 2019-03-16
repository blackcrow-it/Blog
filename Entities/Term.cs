using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Term
    {
        public Term()
        {
            this.TermId = Guid.NewGuid().ToString();
            this.Color = "#000000";
        }
        [Key]
        public string TermId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Color { get; set; }
        public TermTaxonomy TermTaxonomy { get; set; }
    }
}
