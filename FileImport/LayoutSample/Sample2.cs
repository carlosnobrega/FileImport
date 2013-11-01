using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FileImport.Base;
using FileImport.Common;

namespace FileImport.LayoutSample
{
    public class Sample2 : ImportAttributes
    {
        #region "Methods"
        public Sample2() : base(ImportEncodingType.Default, ImportType.Delimited, ";")
        {
            //Sample2 layout is delimited so it's not necessary define the layout
            //All the columns are stored internally using "System.Data.DataColumn"
            //and the columns are named as "Col_1", "Col_2", ... "Col_N"
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
        public List<Sample2.HeaderRow> HeaderRows = new List<Sample2.HeaderRow>();
        public List<Sample2.DetailRow> DetailRows = new List<Sample2.DetailRow>();
        public List<Sample2.TrailerRow> TrailerRows = new List<Sample2.TrailerRow>();
        
        public class HeaderRow : LayoutRow
        {
            public HeaderRow(DataRow Row): base(Row)
            {
                this.Record = "Header";
            }

            public string Field1 
            {
                get { return Row["Col_1"].ToString(); } 
            }

            public string Field2
            {
                get { return Row["Col_2"].ToString(); } 
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
                get { return Row["Col_1"].ToString(); }
            }

            public string Field2
            {
                get { return Row["Col_2"].ToString(); }
            }

            public string Field3
            {
                get { return Row["Col_3"].ToString(); }
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
                get { return Row["Col_1"].ToString(); }
            }
            
        }
        #endregion

    }

}
