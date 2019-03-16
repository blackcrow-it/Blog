using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class PasswordInfo
    {
        public PasswordInfo()
        {
            this.PasswordId = Guid.NewGuid().ToString();
        }
        [Key]
        public string PasswordId { get; set; }
        public string AccountId { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public Account Account { get; set; }
    }
}
