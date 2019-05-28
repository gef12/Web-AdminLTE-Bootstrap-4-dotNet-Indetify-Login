using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Models
{
    public class Empregado
    {
        //representação da tabela funcionario/empregado
        //anotacao para os atributo
        [Key]
        public int EmpregadoId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage ="Este Campo Devera ser Prenchido")]

        [DisplayName("Nome Completo")]
        public string NameCompleto { get; set; }
        [Column(TypeName = "varchar(20)")]

        [DisplayName("Emp. Codigo")]
        public string EmpCode { get; set; }
        [Column(TypeName = "varchar(100)")]

        public string Posicao { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Localização do Trabalho")]


        public string LocalizacaoTrabalho { get; set; }
    }
}
