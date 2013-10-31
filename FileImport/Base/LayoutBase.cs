using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileImport.Common;

namespace FileImport.Base
{
    public abstract class LayoutBase
    {
        #region Layout
        public ImportFile ImportFile { get; set; }
        public ImportAttributes Attributes { get; set; }
        public bool ImportOnlyFirstLine { get; set; }
        #endregion

        #region Erro
        private List<LineError> _lineErrors = new List<LineError>();
        private List<string> _error = new List<string>();

        public bool HasError
        {
            get
            {   
                return (_error.Count > 0) || (_lineErrors.Count > 0);
            }
        }

        public List<LineError> LineErrors
        {
            get
            {
                return _lineErrors;
            }
        }

        public void AddError(string msg , int line)
        {
            _error.Add(string.Format(msg + ". Linha: {0}", line));
        }

        public void AddLineError(string code, string msg, int line)
        {
            _lineErrors.Add(new LineError(code, string.Format(msg + ". Linha: {0}", line), line));
        }

        public string GetErrors()
        {
            StringBuilder sb = new StringBuilder();
            if(_error.Count > 0)
            {
                foreach(string s in _error)
                {
                    sb.Append(s + Environment.NewLine);
                }
            }
            else
            {
                foreach(LineError e in _lineErrors)
                {
                    sb.Append(e.ErrorDescription + Environment.NewLine);
                }
            }
            return sb.ToString();
        }

        #endregion

    }

    public sealed class LineError
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public int LineNumber { get; set; }
    
        public LineError(string code, string description, int line)
        {
            this.ErrorCode = code;
            this.ErrorDescription = description;
            this.LineNumber = line;    
        }    
    }

}

