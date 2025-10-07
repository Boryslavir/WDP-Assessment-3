using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WDP_Assessment_3.Models;

namespace WDP_Assessment_3.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<WDP_Assessment_3.Models.AIImage> AIImage { get; set; } = default!;
}
