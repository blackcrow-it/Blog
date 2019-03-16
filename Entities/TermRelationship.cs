using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class TermRelationship
    {
        public string PostId { get; set; }
        public string TermTaxonomyId { get; set; }

        public Post Post { get; set; }
        public TermTaxonomy TermTaxonomy { get; set; }
    }
}
