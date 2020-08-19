using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Photogram.Models;

namespace Photogram.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<PostsModel> PostsModel { get; set; }
        public DbSet<UserProfileModel> UserProfileModel { get; set; }
    }
}
