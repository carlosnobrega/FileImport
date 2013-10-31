using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FileImport.Base
{
    public abstract class LayoutRow
    {

        public DataRow Row = null;
        public string Record = string.Empty;

        public int ParentLineNumber {get; set;}
        public int LineNumber{get; set;}

        public LayoutRow(DataRow Row)
        {
            this.Row = Row;
        }

        protected int GetInteger(string field)
        {
            try{
                if(Row[field].ToString().Trim() == "")
                {
                    return 0;
                }
                else
                {
                    return (int)Row[field];
                }
            }catch
            {
                throw new Exception(this.GetErrorMessageInteger(field));
            }
        }

        protected long GetLong(string field)
        {
            try{
                if(Row[field].ToString().Trim() == "")
                {
                    return 0;
                }
                else
                {
                    return (long)Row[field];
                }
            }catch
            {
                throw new Exception(this.GetErrorMessageInteger(field));
            }
        }

        protected decimal GetDecimal(string field)
        {
            try{
                if(Row[field].ToString().Trim() == "")
                {
                    return 0;
                }
                else
                {
                    return GetDecimalFromString(Row[field].ToString());
                }
            }catch
            {
                throw new Exception(this.GetErrorMessageInteger(field));
            }
        }

        protected DateTime GetDate(string field,  DateFormat format)
        {
            try{
                if(Row[field].ToString().Trim() == "" ||
                   Row[field].ToString().Trim() == "000000" ||
                   Row[field].ToString().Trim() == "010101" ||
                   Row[field].ToString().Trim() == "991231" ||
                   Row[field].ToString().Trim() == "00000000" ||
                   Row[field].ToString().Trim() == "00010101" ||
                   Row[field].ToString().Trim() == "99991231")
                {
                    return DateTime.MinValue;                
                }
                return GetDateFromString(Row[field].ToString(), format);
            }catch
            {
                throw new Exception(this.GetErrorMessageInteger(field));
            }
        }
        
        private string GetErrorMessageDate(string field)
        {
            return "Campo [" + field + "] no registro [" + Record + "] na linha " + LineNumber + " possui um valor inválido para representar uma data.";
        }

        private string GetErrorMessageDecimal(string field)
        {
            return "Campo [" + field + "] no registro [" + Record + "] na linha " + LineNumber + " possui um valor inválido para representar um valor decimal.";
        }

        private string GetErrorMessageInteger(string field)
        {
            return "Campo [" + field + "] no registro [" + Record + "] na linha " + LineNumber + " possui um valor inválido para representar um valor inteiro.";
        }

        private string GetErrorMessageLong(string field)
        {
            return "Campo [" + field + "] no registro [" + Record + "] na linha " + LineNumber + " possui um valor inválido para representar um valor inteiro longo.";
        }

        private DateTime GetDateFromString(string value, DateFormat format) 
        {
            int year = 0;
            DateTime dt = DateTime.MinValue;

            switch(format)
            {
                case DateFormat.YYYYMMDD:
                    dt = new DateTime(int.Parse(value.Substring(0, 4)), int.Parse(value.Substring(4, 2)), int.Parse(value.Substring(6, 2))); 
                    break;

                case DateFormat.CCYYMMDD:
                    dt = new DateTime(int.Parse(value.Substring(0, 4)), int.Parse(value.Substring(4, 2)), int.Parse(value.Substring(6, 2))); 
                    break;

                case DateFormat.DDMMYYYY:
                    dt = new DateTime(int.Parse(value.Substring(4, 4)), int.Parse(value.Substring(2, 2)), int.Parse(value.Substring(0, 2)));
                    break;

                case DateFormat.YYMMDD:
                    year = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(0, 2) + value.Substring(0, 2));
                    dt = new DateTime(year, int.Parse(value.Substring(2, 2)), int.Parse(value.Substring(4, 2)));
                    break;

                case DateFormat.DDMMYY:
                    year = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(0, 2) + value.Substring(4, 2));
                    dt = new DateTime(year, int.Parse(value.Substring(2, 2)), int.Parse(value.Substring(0, 2)));
                    break;

            }
           
            if(dt == DateTime.MinValue)
            {
                throw new NotImplementedException("Formato de data não suportado");
            }

            return dt;
        }

        private decimal GetDecimalFromString(string value)
        {
            if(value.Trim().Length == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(value) / 100;
            }
        }

        public enum DateFormat
        {
            YYYYMMDD = 1,
            DDMMYYYY = 2,
            DDMMYY = 5,
            YYMMDD = 3,
            CCYYMMDD = 4
        }

    }
   
}
