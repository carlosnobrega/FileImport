using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileImport.Common
{
    public class ImportField
    {
        /// <summary>
        /// Nome do Campo
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Posição Inicial
        /// </summary>
        public int FieldStartPosition { get; set; }

        /// <summary>
        /// Tamanho do Campo
        /// </summary>
        public int FieldLength { get; set; }

        /// <summary>
        /// Expressão regular para validar o campo durante a importação. 
        /// Deixar em branco para não validar
        /// </summary>
        public string RegularExpression { get; set; }
      
        /// <summary>
        /// Mensagem de erro para quando o campo não for compatível com a expressão regular.
        /// Utilizado apenas quando a expressão regular for informada
        /// </summary>
        public string RegularExpressionErrorMessage { get; set; }
    }
}
