using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PasswordInfo> PasswordInfos { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<TermTaxonomy> TermTaxonomies { get; set; }
        public DbSet<TermRelationship> TermRelationships { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Quan hệ một Account một PasswordInfo
            modelBuilder.Entity<Account>()
                .HasOne(a => a.PasswordInfo)
                .WithOne(pi => pi.Account)
                .HasForeignKey<PasswordInfo>(pi => pi.AccountId);
            //Quan hệ một Account nhiều Credential
            modelBuilder.Entity<Credential>()
                .HasOne(c => c.Account)
                .WithMany(a => a.Credentials);
            //Quan hệ nhiều Post nhiều TermTaxonomy
            modelBuilder.Entity<TermRelationship>()
                .HasKey(tr => new { tr.PostId, tr.TermTaxonomyId });
            modelBuilder.Entity<TermRelationship>()
                .HasOne(tr => tr.Post)
                .WithMany(p => p.TermRelationships)
                .HasForeignKey(tr => tr.PostId);
            modelBuilder.Entity<TermRelationship>()
                .HasOne(tr => tr.TermTaxonomy)
                .WithMany(tt => tt.TermRelationships)
                .HasForeignKey(tr => tr.TermTaxonomyId);
            //Quan hệ một Term một TermTaxonomy
            modelBuilder.Entity<Term>()
                .HasOne(t => t.TermTaxonomy)
                .WithOne(tt => tt.Term);

            //var account = new Account
            //{
            //    AccountId = Guid.NewGuid().ToString(),
            //    Email = "quanghungleo@gmail.com",
            //    UserName = "admin",
            //    CreatedAt = DateTime.Now,
            //    ModifiedAt = DateTime.Now
            //};
            //var password = new PasswordInfo
            //{
            //    Salt = Guid.NewGuid().ToString(),
            //    PasswordId = Guid.NewGuid().ToString(),
            //    AccountId = account.AccountId,
            //    Password = 
            //};
            //modelBuilder.Entity<Account>()
            //    .HasData(account);
            //modelBuilder.Entity<PasswordInfo>()
            //    .HasData(new PasswordInfo
            //    {
            //        PasswordId = Guid.NewGuid().ToString(),
            //        AccountId = 
            //    });
        }
    }
}
