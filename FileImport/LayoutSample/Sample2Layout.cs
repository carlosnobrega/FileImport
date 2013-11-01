using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileImport.Base;
using FileImport.Common;
using FileImport.Interface;

namespace FileImport.LayoutSample
{
    public class Sample2Layout : LayoutBase, ILayout
    {
        #region ILayout Members

        public LayoutType LayoutType
        {
            get { return LayoutType.Sample2; }
        }

        public void Import(string fileName)
        {
            int lineHeader = 0;

            Sample2 sample2Layout = new Sample2();

            ImportFile = new ImportFile(sample2Layout);
            if (ImportFile.PrepareFile(fileName))
            {

                Lines.Clear();

                while (ImportFile.ReadLine() && !ImportFile.ReadFailure)
                {

                    Lines.Append(ImportFile.Line + Environment.NewLine);

                    //The Sample2 line Identifier is encountered in column 1
                    //Delimited layout should always mark the column identifier
                    ImportFile.SetIdentificadorCorrente(ImportFile.CurrentLine["Col_1"].ToString());

                    switch ((Sample2.RecordType)int.Parse(ImportFile.CurrentIdentifier))
                    {
                        case Sample2.RecordType.Header:

                            lineHeader = ImportFile.CurrentLineNumber;
                            sample2Layout.HeaderRows.Add(new Sample2.HeaderRow(ImportFile.CurrentLine));
                            sample2Layout.HeaderRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            break;

                        case Sample2.RecordType.Detail:

                            sample2Layout.DetailRows.Add(new Sample2.DetailRow(ImportFile.CurrentLine));
                            sample2Layout.DetailRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            sample2Layout.DetailRows.Last().ParentLineNumber = lineHeader;
                            break;

                        case Sample2.RecordType.Trailer:
                            sample2Layout.TrailerRows.Add(new Sample2.TrailerRow(ImportFile.CurrentLine));
                            sample2Layout.TrailerRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            sample2Layout.TrailerRows.Last().ParentLineNumber = lineHeader;
                            break;

                    }

                    if (this.ImportOnlyFirstLine)
                    {
                        break;
                    }

                }

                if (ImportFile.Error)
                {
                    AddLineError("INTERNAL", ImportFile.ErrorDescription, ImportFile.CurrentLineNumber);
                }

            }
            else
            {
                AddLineError("INTERNAL", ImportFile.ErrorDescription, ImportFile.CurrentLineNumber); 
            }
        }

        public void ValidateStructure()
        {
            //TODO: Validate the strucure of the file
            Sample2 layout = (Sample2)this.ImportFile.ImportAttributes;

            int iResult = 0;

            foreach (Sample2.HeaderRow header in layout.HeaderRows)
            {
                if(!int.TryParse(header.Field1, out iResult))
                {
                    //Add an Error
                    //AddLineError("001", "Field1 deve ser numérico", header.LineNumber);
                }

                foreach (Sample2.DetailRow detail in layout.DetailRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                    
                }

                foreach (Sample2.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                }
            }      
        }

        public void Validate()
        {
            //TODO: Validate the content of the file
            Sample2 layout = (Sample2)this.ImportFile.ImportAttributes;

            foreach (Sample2.HeaderRow header in layout.HeaderRows)
            {
                if (header.Field2 != "")
                {
                    //Add an Error
                    //AddLineError("001", "Field2 possui conteúdo inválido", header.LineNumber);
                }

                foreach (Sample2.DetailRow detail in layout.DetailRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {

                }

                foreach (Sample2.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                }
            }           

        }

        public void Save()
        {
            //TODO: Save the data
            Sample2 layout = (Sample2)this.ImportFile.ImportAttributes;

            foreach (Sample2.HeaderRow header in layout.HeaderRows)
            {
                foreach (Sample2.DetailRow detail in layout.DetailRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {

                }

                foreach (Sample2.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                }
            }    

        }

        #endregion
    }

}
