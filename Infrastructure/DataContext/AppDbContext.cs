
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<tbl_User> tbl_Users { get; set; }
        public DbSet<tbl_Role> tbl_Roles { get; set; }
        public DbSet<tbl_UserRoleDetail> tblUserRoleDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<tbl_UserRoleDetail>()
          .HasOne(p => p.tblRole)
          .WithMany(b => b.tblUserRoleDetail).HasForeignKey(v => v.RoleId);

            modelBuilder.Entity<tbl_UserRoleDetail>()
         .HasOne(p => p.tblUser)
         .WithMany(b => b.tblUserRoleDetail).HasForeignKey(v => v.UserId);
        }
    }
}
