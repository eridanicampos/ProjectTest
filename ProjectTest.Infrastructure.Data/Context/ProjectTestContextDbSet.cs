using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectTest.Domain.Entities;
using ProjectTest.Infrastructure.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Infrastructure.Data.Context
{
    public partial class ProjectTestContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<AcessoUsuario> Acessos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }
        
    }
}
