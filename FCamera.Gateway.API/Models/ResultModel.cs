using System.Collections.Generic;

namespace FCamera.Common.Models
{
    public class ResultModel<TEntity> where TEntity : class
    {
        public TEntity Resultado { get; set; }

        public bool Sucesso
        {
            get { return Inconsistencias == null || Inconsistencias.Count == 0; }
        }

        public List<string> Inconsistencias { get; } = new List<string>();
    }
}
