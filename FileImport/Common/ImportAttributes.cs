using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileImport.Common;

namespace FileImport.Common
{
    public class ImportAttributes
    {

        /// <summary>
        /// Tipo de Importação (Arquivo Delimitado ou Posicionado)
        /// </summary>
        public ImportType ImportType {get; set;}

        /// <summary>
        /// Quando arquivo delimitado informe o caractere delimitador
        /// </summary>
        public string Delimiter {get; set;}

        /// <summary>
        /// Encoding utilizado para importação
        /// </summary>
        public ImportEncodingType EncodingType { get; set; }

        /// <summary>
        /// Tipos de linha utilizadas no arquivo importado
        /// </summary>
        public List<ImportLine> Lines {get; set;}

        
        public ImportAttributes(ImportEncodingType EncodingType, 
                                ImportType ImportType) : this(EncodingType, ImportType, "")
        {
        }

        public ImportAttributes(ImportEncodingType EncodingType,
                                ImportType ImportType,
                                string Delimiter)
        {
            this.EncodingType = EncodingType;
            this.ImportType = ImportType;
            this.Delimiter = Delimiter;
            this.Lines = new List<ImportLine>();
        }
        
    }

}
