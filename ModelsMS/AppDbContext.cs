using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.ModelsMS
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
		{
		}

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Admins> Admins { get; set; }
		public virtual DbSet<Doctors> Doctors { get; set; }
		public virtual DbSet<Nurses> Nurses { get; set; }
		public virtual DbSet<Patients> Patients { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source =SF-CPU-523;Initial Catalog=hospital_db;User Id=sa;Password =Abhi@15042002;TrustServerCertificate=true");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

			modelBuilder.Entity<Admins>(entity =>
			{
				entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Email).IsUnicode(false);

				entity.Property(e => e.Name).IsUnicode(false);

				entity.Property(e => e.Password).IsUnicode(false);

				entity.Property(e => e.Phone).IsUnicode(false);
			});

			modelBuilder.Entity<Doctors>(entity =>
			{
				entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Email).IsUnicode(false);

				entity.Property(e => e.Name).IsUnicode(false);

				entity.Property(e => e.Password).IsUnicode(false);

				entity.Property(e => e.Phone).IsUnicode(false);

				entity.Property(e => e.Specialist).IsUnicode(false);
			});

			modelBuilder.Entity<Nurses>(entity =>
			{
				entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Email).IsUnicode(false);

				entity.Property(e => e.Name).IsUnicode(false);

				entity.Property(e => e.Password).IsUnicode(false);

				entity.Property(e => e.Phone).IsUnicode(false);
			});

			modelBuilder.Entity<Patients>(entity =>
			{
				entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

				entity.Property(e => e.HealthCondition).IsUnicode(false);

				entity.Property(e => e.Name).IsUnicode(false);

				entity.Property(e => e.Phone).IsUnicode(false);

				entity.HasOne(d => d.Doctor)
					.WithMany(p => p.Patients)
					.HasForeignKey(d => d.DoctorId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__patients__doctor__52593CB8");

				entity.HasOne(d => d.Nurse)
					.WithMany(p => p.Patients)
					.HasForeignKey(d => d.NurseId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__patients__nurse___534D60F1");
			});
		}
	}
}
