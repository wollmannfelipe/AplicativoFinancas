using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDadosFinancas
{
    public class DBContext : DbContext
    {
        public DBContext() : base()
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Conta> Contas { get; set; }
        public virtual DbSet<TipoMovimento> TipoMovimento { get; set; }
        public virtual DbSet<Movimento> Movimentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}