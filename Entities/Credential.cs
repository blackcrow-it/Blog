using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Credential
    {
        public Credential(string accountId)
        {
            this.AccountId = accountId;
            this.AccessToken = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
            this.ModifiedAt = DateTime.Now;
            this.ExpiredAt = DateTime.Now.AddDays(7);
            this.Status = true;
        }
        [Key]
        public string AccessToken { get; set; }
        public string AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool Status { get; set; }
        public DateTime ExpiredAt { get; set; }
        public Account Account { get; set; }
        public bool IsValid()
        {
            return (this.Status == true && this.ExpiredAt >= DateTime.Now);
        }
    }
}
