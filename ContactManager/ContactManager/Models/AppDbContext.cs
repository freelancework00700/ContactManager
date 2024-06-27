using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
    // The AppDbContext class is responsible for configuring and managing the database context for the application.
    public class AppDbContext : DbContext
    {
        // DbSet property for accessing and managing Contact entities in the database.
        public DbSet<Contact> Contacts { get; set; }

        // Constructor that accepts DbContextOptions to configure the context.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Method for configuring the model and seeding initial data.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding the database with an initial Contact entity.
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1,
                Name = "Rajesh Kumar",
                Email = "rajesh.kumar@example.com",
                Phone = "1234567890",
                Address = "456 Gandhi Nagar, Bangalore, Karnataka, India"
            });
        }
    }
}
