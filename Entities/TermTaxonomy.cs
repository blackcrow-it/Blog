using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class TermTaxonomy
    {
        public TermTaxonomy()
        {
            this.TermTaxonomyId = Guid.NewGuid().ToString();
            this.Parent = "0";
        }
        [Key]
        public string TermTaxonomyId { get; set; }
        public string TermId { get; set; }
        public string Taxonomy { get; set; }
        public string Description { get; set; }
        public string Parent { get; set; }
        public int Count { get; set; }
        public ICollection<TermRelationship> TermRelationships { get; set; }
        public Term Term { get; set; }
    }
}
