using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileImport.Common
{
    public class ImportLine
    {

        /// <summary>
        /// Descrição da linha (Exemplo: Header, Body, Trailer)
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// Identificador da linha (Exemplo: 1=Header, 2=Body, 9=Trailer)
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Posição Inicial do Identificador
        /// </summary>
        public int IdentifierStartPosition { get; set; }

        /// <summary>
        /// Tamanho do Campo Identificador
        /// </summary>
        public int IdentifierLength { get; set; }

        /// <summary>
        /// Campos existentes na linha
        /// </summary>
        public List<ImportField> Fields { get; set; }

        /// <summary>
        /// Marcar para usar expressões regulares
        /// </summary>
        public bool UseRegularExpression { get; set; }
        
        /// <summary>
        /// Tamanho da linha para validação de layout. 
        /// Quando o tamanho da linha for zero não haverá validação.
        /// Quando for maior que zero a linha deverá ter o número informado. Ex. CNAB240 = 240, CNAB400 = 400, etc.
        /// </summary>
        public int LineLength { get; set; }

        public ImportLine()
        {
            this.Fields = new List<ImportField>();        
        }
    }
}
