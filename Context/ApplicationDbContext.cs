using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FileApprovalSystem.Models;

namespace FileApprovalSystem.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileRecord> FileRecords { get; set; }
        public DbSet<Approval> Approvals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Employee1", NormalizedName = "EMPLOYEE1" },
                new IdentityRole { Name = "Employee2", NormalizedName = "EMPLOYEE2" },
                new IdentityRole { Name = "Employee3", NormalizedName = "EMPLOYEE3" }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            // Seed Users
            var passwordHasher = new PasswordHasher<IdentityUser>();

            var employee1 = new IdentityUser
            {
                UserName = "employee1",
                NormalizedUserName = "EMPLOYEE1",
                Email = "employee1@example.com",
                NormalizedEmail = "EMPLOYEE1@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            employee1.PasswordHash = passwordHasher.HashPassword(employee1, "Password123!");

            var employee2 = new IdentityUser
            {
                UserName = "employee2",
                NormalizedUserName = "EMPLOYEE2",
                Email = "employee2@example.com",
                NormalizedEmail = "EMPLOYEE2@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            employee2.PasswordHash = passwordHasher.HashPassword(employee2, "Password123!");

            var employee3 = new IdentityUser
            {
                UserName = "employee3",
                NormalizedUserName = "EMPLOYEE3",
                Email = "employee3@example.com",
                NormalizedEmail = "EMPLOYEE3@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            employee3.PasswordHash = passwordHasher.HashPassword(employee3, "Password123!");

            modelBuilder.Entity<IdentityUser>().HasData(employee1, employee2, employee3);

            // Assign Roles to Users
            var userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string> { UserId = employee1.Id, RoleId = roles[0].Id }, // Employee1 role to employee1
                new IdentityUserRole<string> { UserId = employee2.Id, RoleId = roles[1].Id }, // Employee2 role to employee2
                new IdentityUserRole<string> { UserId = employee3.Id, RoleId = roles[2].Id }  // Employee3 role to employee3
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}

