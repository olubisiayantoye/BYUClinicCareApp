using Microsoft.EntityFrameworkCore;

namespace BYUClinicCareApp.Data;

public class ClinicDbContext(DbContextOptions<ClinicDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<StaffRole> StaffRoles { get; set; }
}

public class StaffRole
{
    public int Role_Id { get; set; }
    public required string Role_Name { get; set; }
}

public class User
{
    public Guid User_Id { get; set; }
    public required string Employee_Id { get; set; }
    public int Role_Id { get; set; }
    public required string First_Name { get; set; }
    public required string Last_Name { get; set; }
    public required string Email { get; set; }
    public string? Phone_Number { get; set; }
    public required string Password_Hash { get; set; }
    public bool Is_Active { get; set; } = true;
    public string? Specialization { get; set; }
    public DateTime Created_At { get; set; } = DateTime.UtcNow;
}
