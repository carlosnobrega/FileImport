using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileImport.Base;
using FileImport.Common;
using FileImport.Interface;

namespace FileImport.LayoutSample
{
    public class Sample1Layout : LayoutBase, ILayout
    {
        #region ILayout Members

        public LayoutType LayoutType
        {
            get { return LayoutType.Sample1; }
        }

        public void Import(string fileName)
        {
            int lineHeader = 0;

            Sample1 sample1Layout = new Sample1();

            ImportFile = new ImportFile(sample1Layout);
            if (ImportFile.PrepareFile(fileName))
            {

                Lines.Clear();

                while (ImportFile.ReadLine() && !ImportFile.ReadFailure)
                {

                    Lines.Append(ImportFile.Line + Environment.NewLine);

                    switch ((Sample1.RecordType)int.Parse(ImportFile.CurrentIdentifier))
                    {
                        case Sample1.RecordType.Header:

                            lineHeader = ImportFile.CurrentLineNumber;
                            sample1Layout.HeaderRows.Add(new Sample1.HeaderRow(ImportFile.CurrentLine));
                            sample1Layout.HeaderRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            break;

                        case Sample1.RecordType.Detail:

                            sample1Layout.DetailRows.Add(new Sample1.DetailRow(ImportFile.CurrentLine));
                            sample1Layout.DetailRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            sample1Layout.DetailRows.Last().ParentLineNumber = lineHeader;
                            break;

                        case Sample1.RecordType.Trailer:
                            sample1Layout.TrailerRows.Add(new Sample1.TrailerRow(ImportFile.CurrentLine));
                            sample1Layout.TrailerRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            sample1Layout.TrailerRows.Last().ParentLineNumber = lineHeader;
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
            Sample1 layout = (Sample1)this.ImportFile.ImportAttributes;

            int iResult = 0;

            foreach (Sample1.HeaderRow header in layout.HeaderRows)
            {
                if(!int.TryParse(header.Field1, out iResult))
                {
                    //Add an Error
                    //AddLineError("001", "Field1 deve ser numérico", header.LineNumber);
                }

                foreach (Sample1.DetailRow detail in layout.DetailRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                    
                }

                foreach (Sample1.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                }
            }      
        }

        public void Validate()
        {
            //TODO: Validate the content of the file
            Sample1 layout = (Sample1)this.ImportFile.ImportAttributes;

            foreach (Sample1.HeaderRow header in layout.HeaderRows)
            {
                if (header.Field2 != "")
                {
                    //Add an Error
                    //AddLineError("001", "Field2 possui conteúdo inválido", header.LineNumber);
                }

                foreach (Sample1.DetailRow detail in layout.DetailRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {

                }

                foreach (Sample1.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                }
            }           

        }

        public void Save()
        {
            //TODO: Save the data
            Sample1 layout = (Sample1)this.ImportFile.ImportAttributes;

            foreach (Sample1.HeaderRow header in layout.HeaderRows)
            {
                foreach (Sample1.DetailRow detail in layout.DetailRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {

                }

                foreach (Sample1.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                }
            }    

        }

        #endregion
    }

}
