using Cwk.Domain.Aggregates.PostAggregate;
using Cwk.Domain.Aggregates.UserProfileAggregate;
using CwkSocial.Dal.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CwkSocial.Dal
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new PostCommentConfig());
            modelbuilder.ApplyConfiguration(new PostInteractionConfig());
            modelbuilder.ApplyConfiguration(new UserProfileConfig());
            modelbuilder.ApplyConfiguration(new IdentityUserLoginConfig());
            modelbuilder.ApplyConfiguration(new IdentityUserRoleConfig());
            modelbuilder.ApplyConfiguration(new IdentityUserTokenConfig());
        }
    }
}
