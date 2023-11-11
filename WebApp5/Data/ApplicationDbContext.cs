using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApp5.Enums;
using WebApp5.Models;

namespace WebApp5.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserCliam");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            //Seeding Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "42c776fa-c03b-48db-a925-543b50d53d9e", Name = Enums.Roles.SuperAdmin.ToString(), NormalizedName = Enums.Roles.SuperAdmin.ToString().ToUpperInvariant() },
                new IdentityRole() { Id = "15619537-adcc-410f-b9e9-e1290b60c0d0", Name = Enums.Roles.Admin.ToString(), NormalizedName = Enums.Roles.Admin.ToString().ToUpperInvariant() },
                new IdentityRole() { Id = "57bfa597-8d8d-4bfe-b66b-82032522cec1", Name = Enums.Roles.Moderator.ToString(), NormalizedName = Enums.Roles.Moderator.ToString().ToUpperInvariant() },
                new IdentityRole() { Id = "744f629d-8e20-4454-af85-7b18b607fd89", Name = Enums.Roles.Basic.ToString(), NormalizedName = Enums.Roles.Basic.ToString().ToUpperInvariant() }
            );
            //seeding user
            const string emailStr = "abc@xyz.com";
            builder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "22cac3e4-ebd1-4ee2-9254-eb9ce3da696c",
                     FirstName = "DefaultAdmin",
                     LastName = "Admin",
                     UserName = emailStr,
                     Email = emailStr,
                     EmailConfirmed = true,
                     NormalizedEmail = emailStr.ToUpperInvariant(),
                     NormalizedUserName = emailStr.ToUpperInvariant(),
                     ProfilePicture = new byte[] { 0 },
                     PhoneNumber = "0912123456"
                 }
                );
            //------Seeding user roles
            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>() { RoleId= "42c776fa-c03b-48db-a925-543b50d53d9e" ,UserId= "22cac3e4-ebd1-4ee2-9254-eb9ce3da696c" },
                new IdentityUserRole<string>() { RoleId= "15619537-adcc-410f-b9e9-e1290b60c0d0", UserId= "22cac3e4-ebd1-4ee2-9254-eb9ce3da696c" },
                new IdentityUserRole<string>() { RoleId= "57bfa597-8d8d-4bfe-b66b-82032522cec1", UserId= "22cac3e4-ebd1-4ee2-9254-eb9ce3da696c" },
                new IdentityUserRole<string>() { RoleId= "744f629d-8e20-4454-af85-7b18b607fd89", UserId= "22cac3e4-ebd1-4ee2-9254-eb9ce3da696c" }
                );
        }
    }
}