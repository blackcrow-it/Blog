using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Menu
    {
        public Menu()
        {
            this.Status = true;
            this.Parent = 0;
            this.StatusIcon = false;
        }
        [Key]
        public int MenuId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool StatusIcon { get; set; }
        public bool Status { get; set; }
        public int Parent { get; set; }
    }
}
