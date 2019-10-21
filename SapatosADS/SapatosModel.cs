namespace SapatosADS
{
    using SapatosADS.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SapatosModel : DbContext
    {
        // Your context has been configured to use a 'SapatosModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SapatosADS.SapatosModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SapatosModel' 
        // connection string in the application configuration file.
        public SapatosModel()
            : base("name=SapatosModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        
        public virtual DbSet<Sapato> Sapatos { get; set; }

        public virtual DbSet<Pessoa> Pessoas { get; set; }
        
        public virtual DbSet<Venda> Vendas { get; set; }

        public virtual DbSet<Modelo> Modelos { get; set; }
    }

}