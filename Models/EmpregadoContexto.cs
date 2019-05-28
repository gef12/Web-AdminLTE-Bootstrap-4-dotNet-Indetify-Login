using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Models
{
    public class EmpregadoContexto : DbContext
    {
        //conexao com BD feita para os empregados
        public EmpregadoContexto(DbContextOptions<EmpregadoContexto> options) : base(options)
        {

        }

        //utilizando o contexto do Bd para gerar a tabela de usuario
        public DbSet<Empregado> Empregado { get; set; }

    }
}
