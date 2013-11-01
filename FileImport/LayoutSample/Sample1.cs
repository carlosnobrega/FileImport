using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FileImport.Base;
using FileImport.Common;

namespace FileImport.LayoutSample
{
    public class Sample1 : ImportAttributes
    {
        #region "Methods"
        public Sample1() : base(ImportEncodingType.Default, ImportType.Positioned)
        {
            this.Lines.Add(addHeader(new ImportLine
            {
                Identifier = "0",
                LineName = "Registro Header do Arquivo",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 0 //LineLength greater than zero indicates that the validation will be fired
            }));

            this.Lines.Add(addDetail(new ImportLine
            {
                Identifier = "1",
                LineName = "Registro Detail do Arquivo",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 0 //LineLength greater than zero indicates that the validation will be fired
            }));

            this.Lines.Add(addTrailer(new ImportLine
            {
                Identifier = "2",
                LineName = "Registro Trailer do Arquivo",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 0 //LineLength greater than zero indicates that the validation will be fired
            }));  
        }

        private ImportLine addHeader(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "Field1",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "Field2",
                FieldStartPosition = 2,
                FieldLength = 50
            });
            return line;
        }

        private ImportLine addDetail(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "Field1",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "Field2",
                FieldStartPosition = 2,
                FieldLength = 10
            });
            line.Fields.Add(new ImportField
            {
                Field = "Field3",
                FieldStartPosition = 12,
                FieldLength = 50
            });
            return line;
        }

        private ImportLine addTrailer(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "Field1",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            return line;
        }

        #endregion

        #region "Enum"
        public enum RecordType
        {
            Header = 0,
            Detail = 1,
            Trailer = 2
        }
        #endregion

        #region "Rows"
        public List<Sample1.HeaderRow> HeaderRows = new List<Sample1.HeaderRow>();
        public List<Sample1.DetailRow> DetailRows = new List<Sample1.DetailRow>();
        public List<Sample1.TrailerRow> TrailerRows = new List<Sample1.TrailerRow>();
        
        public class HeaderRow : LayoutRow
        {
            public HeaderRow(DataRow Row): base(Row)
            {
                this.Record = "Header";
            }

            public string Field1 
            {
                get { return Row["Field1"].ToString(); }
            }

            public string Field2
            {
                get { return Row["Field2"].ToString(); }
            }

        }

        public class DetailRow : LayoutRow
        {
            public DetailRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Detail";
            }

            public string Field1
            {
                get { return Row["Field1"].ToString(); }
            }

            public string Field2
            {
                get { return Row["Field2"].ToString(); }
            }

            public string Field3
            {
                get { return Row["Field3"].ToString(); }
            }

        }

        public class TrailerRow : LayoutRow
        {

            public TrailerRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Trailer";
            }

            public string Field1
            {
                get { return Row["Field1"].ToString(); }
            }
            
        }
        #endregion

    }

}
