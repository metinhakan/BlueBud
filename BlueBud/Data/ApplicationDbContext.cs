using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueBud.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationDbContext.BlueBudUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    
    public class BlueBudUser: IdentityUser
    {
        public string FullName { get; set; }
        public string CarType { get; set; }
    }
    
}