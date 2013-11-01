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
        public StringBuilder Lines { get; set; }
        #endregion

        #region Constructor
        public LayoutBase()
        {
            Lines = new StringBuilder();
        }
        #endregion

        #region Methods
        private List<LineError> _lineErrors = new List<LineError>();
        
        public bool HasError
        {
            get
            {   
                return (_lineErrors.Count > 0);
            }
        }

        public List<LineError> LineErrors
        {
            get
            {
                return _lineErrors;
            }
        }

        public void AddLineError(string code, string msg, int line)
        {
            _lineErrors.Add(new LineError(code, (line > 0 ? string.Format(msg + ". Linha: {0}", line) : msg + "."), line));
        }

        public string GetErrors()
        {
            StringBuilder sb = new StringBuilder();
            foreach(LineError e in _lineErrors)
            {
                sb.Append(e.ErrorCode + " - " + e.ErrorDescription + Environment.NewLine);
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

