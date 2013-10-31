using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace FileImport.Common
{

    public class ImportFile
    {

        #region Properties

        private int _currentLineNumber = 0;
        private bool _failureOnRead = false;
        private string _line = string.Empty;
        private DataTable _dt = null;
        private DataRow _currentLine = null;
        private string _currentIdentifier = string.Empty;
        private bool _error = false;
        private string _errorDescription = string.Empty;
        private StreamReader _sr = null;

        //Linha corrente
        public int CurrentLineNumber
        {
            get
            {
                return _currentLineNumber;
            }
        }

        /// <summary>
        /// Indica se houve falha na leitura
        /// </summary>
        public bool ReadFailure
        {
            get
            {
                return _failureOnRead;
            }
        }

        /// <summary>
        /// Retorna a linha da leitura atual
        /// </summary>
        public string Line
        {
            get
            {
                return _line;
            }
        }

        /// <summary>
        /// Arquivo a ser importado
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Atributos de importação
        /// </summary>
        public ImportAttributes ImportAttributes { get; set; }

        /// <summary>
        /// Linha corrente (DataRow)
        /// </summary>
        public DataRow CurrentLine
        {
            get
            {
                return _currentLine;
            }
        }

        /// <summary>
        /// Identificador corrente
        /// </summary>
        public string CurrentIdentifier
        {
            get
            {
                return _currentIdentifier;
            }
        }

        /// <summary>
        /// Indica se houve erro de importação
        /// </summary>
        public bool Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// Descrição do erro ocorrido
        /// </summary>
        public string ErrorDescription
        {
            get
            {
                return _errorDescription;
            }
        }
        #endregion

        public ImportFile(ImportAttributes ImportAttributes)
        {
            this.ImportAttributes = ImportAttributes;
        }


        /// <summary>
        /// Prepara o arquivo a ser importado
        /// </summary>
        /// <param name="FilePath">Caminho do Arquivo</param>
        /// <returns>True or False</returns>
        public bool PrepareFile(string FilePath)
        {
            this._error = false;
            this._errorDescription = string.Empty;
            
            if(String.IsNullOrEmpty(FilePath.Trim()))
            {
                _error = true;
                _errorDescription = "Informe corretamente o nome do arquivo a processar.";
                return false;
            }

            if(!System.IO.File.Exists(FilePath))
            {
                _error = true;
                _errorDescription = string.Format("O arquivo informado não foi localizado. Favor tentar novamente. [{0}]", FilePath);  
                return false;
            }
            
            this.FilePath = FilePath;
        
            if((int)this.ImportAttributes.EncodingType < 1 || (int)this.ImportAttributes.EncodingType > 7)
            {
                this.ImportAttributes.EncodingType = ImportEncodingType.Default;
            }

            if(this.ImportAttributes.ImportType == ImportType.Positioned)
            {
                List<string> list = new List<string>();
                bool blank = false;

                foreach(ImportLine line in this.ImportAttributes.Lines)
                {
                    if(line.Identifier == null)
                    {
                        line.Identifier = "";
                    }
                
                    if(list.Contains(line.Identifier))
                    {
                        _error = true;
                        _errorDescription = "Não é permitido linhas com o mesmo identificador!";
                        return false;
                    }
                
                    list.Add(line.Identifier);

                    if(line.Identifier.Trim() == "")
                    {
                        blank = true;
                        break;
                    }                
                }

                if(blank && this.ImportAttributes.Lines.Count > 1)
                {
                    _error = true;
                    _errorDescription = "Quando uma linha não contém identificador apenas um tipo de linha é permitido para a importação!";
                    return false;
                }
            
            }

            switch(this.ImportAttributes.EncodingType)
            {
                case ImportEncodingType.ASCII:
                    this._sr = new StreamReader(FilePath, Encoding.ASCII); break;
                case ImportEncodingType.BigEndianUnicode:
                    this._sr = new StreamReader(FilePath, Encoding.BigEndianUnicode); break;
                case ImportEncodingType.Default:
                    this._sr = new StreamReader(FilePath, Encoding.Default); break;
                case ImportEncodingType.Unicode:
                    this._sr = new StreamReader(FilePath, Encoding.Unicode); break;
                case ImportEncodingType.UTF32:
                    this._sr = new StreamReader(FilePath, Encoding.UTF32); break;
                case ImportEncodingType.UTF7:
                    this._sr = new StreamReader(FilePath, Encoding.UTF7); break;
                case ImportEncodingType.UTF8:
                    this._sr = new StreamReader(FilePath, Encoding.UTF8); break;
            }
            
            this._currentLineNumber = 0;
            return true;
        }


        /// <summary>
        /// Leitura de cada linha
        /// </summary>
        /// <returns></returns>
        public bool ReadLine()
        {
            try
            {
                _error = false;
                _errorDescription = "";

                if (this._sr.EndOfStream)
                {
                    this._sr.Close();
                    return false;
                }

                this._line = this._sr.ReadLine();

                while (string.IsNullOrEmpty(this._line))
                {
                    if (this._sr.EndOfStream)
                    {
                        this._sr.Close();
                        return false;
                    }
                    this._line = this._sr.ReadLine();
                }

                if (!this.adjustLine())
                    return false;

                this._currentLineNumber += 1;
            }
            catch (Exception ex)
            {
                if(this._sr != null)
                {
                    this._sr.Close();
                }
                _error = true;
                _errorDescription = ex.Message + " [Linha " + (this._currentLineNumber + 1).ToString() + "]";
                return false;       
            }

            return true;
        }


        private bool adjustLine()
        {
            string[] split;

            this._currentIdentifier = "";
            this._currentLine = null;
            this._dt = new DataTable();

            if(this.ImportAttributes.ImportType == ImportType.Positioned)
            {
                foreach(ImportLine line in this.ImportAttributes.Lines)
                {
                    this._currentIdentifier = line.Identifier;
                    
                    if(line.UseRegularExpression)
                    {
                        foreach(ImportField field in line.Fields)
                        {
                            if(field.RegularExpression == null)
                            {       
                                field.RegularExpression = "";
                                field.RegularExpressionErrorMessage = "";
                            }
                        }
                    }
                                        
                    if(line.LineLength > 0)
                    {       
                        if(this._line.Length != line.LineLength)
                        {
                            _error = true;
                            _errorDescription = string.Format("Tamanho da linha [{0}] corrente é diferente da configuração do layout", this._currentLineNumber);
                            return false;                            
                        }
                    }

                    if(line.Identifier == "")
                    {
                        foreach(ImportField field in line.Fields)
                        {
                            this._dt.Columns.Add(new DataColumn(field.Field, typeof(string)));
                        }
                        this._currentLine = this._dt.NewRow();
                        foreach(ImportField field in line.Fields)
                        {
                            this._currentLine[field.Field] = this._line.Substring(field.FieldStartPosition - 1, field.FieldLength);
                            if(line.UseRegularExpression)
                            {
                                if(field.RegularExpression.Trim() != "")
                                {
                                    if(Regex.IsMatch(this._currentLine[field.Field].ToString(), field.RegularExpression) == false)
                                    {
                                        _error = true;
                                        _errorDescription = field.RegularExpressionErrorMessage + " [" + this._currentLine[field.Field] + "]";
                                        return false;
                                    }
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        if(this.Line.Substring(line.IdentifierStartPosition - 1, line.IdentifierLength) == line.Identifier)
                        {
                            foreach(ImportField field in line.Fields)
                            {
                                this._dt.Columns.Add(new DataColumn(field.Field, typeof(string)));
                            }
                            this._currentLine = this._dt.NewRow();
                            foreach(ImportField field in line.Fields)
                            {
                                this._currentLine[field.Field] = this.Line.Substring(field.FieldStartPosition - 1, field.FieldLength);
                                if(line.UseRegularExpression)
                                {
                                    if(field.RegularExpression.Trim() != "")
                                    {
                                        if(Regex.IsMatch(this._currentLine[field.Field].ToString(), field.RegularExpression) == false)
                                        {
                                            _error = true; 
                                            _errorDescription = field.RegularExpressionErrorMessage + " [" + this.CurrentLine[field.Field] + "]";
                                            return false;                                            
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else if(this.ImportAttributes.ImportType == ImportType.Delimited)
            {
                split = this.Line.Split(this.ImportAttributes.Delimiter.ToCharArray());
                for(int i = 0; i < split.Length - 1;i++)
                {
                    this._dt.Columns.Add(new DataColumn("Col_" + (i + 1), typeof(string)));
                }
                this._currentLine = this._dt.NewRow();
                for(int i = 0; i < split.Length - 1;i++)
                {
                    this._currentLine["Col_" + (i + 1)] = split[i];
                }
            }
            return true;
        }


        /// <summary>
        /// Ajuste o identificador corrente da linha. 
        /// </summary>
        /// <param name="Identifier">Identificador da Linha</param>
        public void SetIdentificadorCorrente(string Identifier)
        {
            this._currentIdentifier = Identifier;
        }

        /// <summary>
        /// Cancela a operação
        /// </summary>
        public void Abort()
        {
            if (this._sr != null)
            {
                this._sr.Close();
            }
            this._failureOnRead = true;
        }

    }
}