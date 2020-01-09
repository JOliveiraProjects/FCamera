using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCamera.Domain.Entities
{
    [Table("autentica")]
    public class AutenticaModel
    {
        [Key]
        [Column("usuarioid")]
        public int UsuarioId { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }

        [Column("datacadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("refreshtoken")]
        public string RefreshToken { get; set; }
    }
}
