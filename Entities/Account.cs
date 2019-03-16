using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Account
    {
        public Account()
        {
            this.AccountId = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
            this.ModifiedAt = DateTime.Now;
        }
        [Key]
        public string AccountId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public PasswordInfo PasswordInfo { get; set; }
        public ICollection<Credential> Credentials { get; set; }
    }
}
