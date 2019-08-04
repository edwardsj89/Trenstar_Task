namespace BookingSystem.Data.Database.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BookingSystem.Data.Database.Models;

    public class BookingSystem_DbContext : DbContext
    {
        // Your context has been configured to use a 'BookingSystem_DbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookingSystem.Data.Database.Models.BookingSystem_DbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookingSystem_DbContext' 
        // connection string in the application configuration file.
        public BookingSystem_DbContext()
            : base("name=BookingSystem_DbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Booking> Bookings { get; set; }
    }
}