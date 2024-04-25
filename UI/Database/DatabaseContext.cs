using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Model;
using UI.Others;

namespace UI.Database;
internal class DatabaseContext: DbContext
{
    public DbSet<DatabaseUser> Users { get; set; }
    public DbSet<DatabaseLog> Logs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string databaseFile = "dbsettings2.db";
        string databasePath = Path.Combine(solutionFolder, databaseFile);
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<DatabaseLog>().Property(e => e.Id).ValueGeneratedOnAdd();

        var user = new DatabaseUser()
        {
            Id = 1,
            Name = "Test Test",
            Password = "1234",
            Role = UserRolesEnum.ADMIN,
            Expires = DateTime.Now.AddYears(10),
        };

        modelBuilder.Entity<DatabaseUser>().HasData(user);
    }
}
