using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GameLibrary.Model
{
    public class GameLibraryContext : DbContext
    {
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySQL("server=localhost:3306;userid=root;password=password;database=gameLib;", builder =>
        //     {
        //         builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        //     });
        //     base.OnConfiguring(optionsBuilder);
        // }
        public GameLibraryContext(DbContextOptions<GameLibraryContext> context) : base(context)
        { }
        public DbSet<Game> games { get; set; }
        public DbSet<genre> genre {get;set;}
        public DbSet<Publisher> publisher {get;set;}
        
    }
}