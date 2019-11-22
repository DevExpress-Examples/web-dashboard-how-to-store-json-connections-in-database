using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DXWebApplication21 {
    public class MyJsonConnection {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }

    class JsonConnectionContext : DbContext {
        public DbSet<MyJsonConnection> Connections { get; set; }
        public JsonConnectionContext() : base("ConnectionsStorage") { }
    }
}