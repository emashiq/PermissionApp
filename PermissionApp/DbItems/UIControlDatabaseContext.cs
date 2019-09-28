using Microsoft.EntityFrameworkCore;

namespace PermissionApp.DbItems
{
    public partial class UIControlDatabaseContext : DbContext
    {
        public UIControlDatabaseContext()
        {
        }

        public UIControlDatabaseContext(DbContextOptions<UIControlDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleUi> ModuleUi { get; set; }
        public virtual DbSet<ModuleUicontrols> ModuleUicontrols { get; set; }
        public virtual DbSet<PermissionType> PermissionType { get; set; }
        public virtual DbSet<UserModuleUi> UserModuleUi { get; set; }
        public virtual DbSet<UserModuleUicontrolsPermissions> UserModuleUicontrolsPermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=UIControlDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ModuleUi>(entity =>
            {
                entity.ToTable("ModuleUI");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Uiname)
                    .IsRequired()
                    .HasColumnName("UIName")
                    .HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ModuleUicontrols>(entity =>
            {
                entity.ToTable("ModuleUIControls");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ControlName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModuleUiid).HasColumnName("ModuleUIId");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PermissionTypeName).HasMaxLength(255);
            });

            modelBuilder.Entity<UserModuleUi>(entity =>
            {
                entity.ToTable("UserModuleUI");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModuleUiid).HasColumnName("ModuleUIId");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UserModuleUicontrolsPermissions>(entity =>
            {
                entity.ToTable("UserModuleUIControlsPermissions");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModuleUiid).HasColumnName("ModuleUIId");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}
