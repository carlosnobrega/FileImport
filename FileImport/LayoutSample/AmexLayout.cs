using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileImport.Base;
using FileImport.Common;
using FileImport.Interface;

namespace FileImport.LayoutSample
{
    public class AmexLayout : LayoutBase, ILayout
    {
        #region ILayout Members

        public LayoutType LayoutType
        {
            get { return LayoutType.Amex; }
        }

        public void Import(string fileName)
        {
            int lineHeader = 0;
            int linePagamento = 0;
            int lineSOC = 0;

            Amex amexLayout = new Amex();

            ImportFile = new ImportFile(amexLayout);
            if (ImportFile.PrepareFile(fileName))
            {
                Lines.Clear();

                while (ImportFile.ReadLine() && !ImportFile.ReadFailure)
                {

                    Lines.Append(ImportFile.Line + Environment.NewLine);

                    //The Amex line Identifier is encountered in column 6
                    //Delimited layout should always mark the column identifier
                    ImportFile.SetIdentificadorCorrente(ImportFile.CurrentLine["Col_6"].ToString());

                    switch ((Amex.RecordType)int.Parse(ImportFile.CurrentIdentifier))
                    {
                        case Amex.RecordType.Header:

                            lineHeader = ImportFile.CurrentLineNumber;
                            amexLayout.HeaderRows.Add(new Amex.HeaderRow(ImportFile.CurrentLine));
                            amexLayout.HeaderRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            break;

                        case Amex.RecordType.Pagamento:

                            linePagamento = ImportFile.CurrentLineNumber;
                            amexLayout.PagamentoRows.Add(new Amex.PagamentoRow(ImportFile.CurrentLine));
                            amexLayout.PagamentoRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            amexLayout.PagamentoRows.Last().ParentLineNumber = lineHeader;
                            break;

                        case Amex.RecordType.SOC:

                            lineSOC = ImportFile.CurrentLineNumber;
                            amexLayout.SOCRows.Add(new Amex.SOCRow(ImportFile.CurrentLine));
                            amexLayout.SOCRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            amexLayout.SOCRows.Last().ParentLineNumber = linePagamento;
                            break;

                        case Amex.RecordType.ROC:
                            amexLayout.ROCRows.Add(new Amex.ROCRow(ImportFile.CurrentLine));
                            amexLayout.ROCRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            amexLayout.ROCRows.Last().ParentLineNumber = lineSOC;
                            break;

                        case Amex.RecordType.Ajustes:
                            amexLayout.AjustesRows.Add(new Amex.AjustesRow(ImportFile.CurrentLine));
                            amexLayout.AjustesRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            amexLayout.AjustesRows.Last().ParentLineNumber = linePagamento;
                            break;

                        case Amex.RecordType.Trailer:
                            amexLayout.TrailerRows.Add(new Amex.TrailerRow(ImportFile.CurrentLine));
                            amexLayout.TrailerRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            amexLayout.TrailerRows.Last().ParentLineNumber = lineHeader;
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
            Amex layout = (Amex)this.ImportFile.ImportAttributes;

            int iResult = 0;

            foreach (Amex.HeaderRow header in layout.HeaderRows)
            {
                if(!int.TryParse(header.EE_REGISTRO_CABECALHO, out iResult))
                {
                    //Add an Error
                    //AddLineError("001", "EE_REGISTRO_CABECALHO deve ser numérico", header.LineNumber);
                }

                foreach (Amex.PagamentoRow pagto in layout.PagamentoRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                    foreach (Amex.SOCRow soc in layout.SOCRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                    {
                        foreach (Amex.ROCRow roc in layout.ROCRows.Where(p => p.ParentLineNumber == soc.LineNumber))
                        {

                        }
                        foreach (Amex.AjustesRow ajuste in layout.AjustesRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                        {

                        }
                    }
                }
                foreach (Amex.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {

                }
            }      
        }

        public void Validate()
        {
            //TODO: Validate the content of the file
            Amex layout = (Amex)this.ImportFile.ImportAttributes;

            foreach (Amex.HeaderRow header in layout.HeaderRows)
            {

                if (header.EE_REGISTRO_CABECALHO == "")
                {
                    //Add an Error
                    //AddLineError("001", "Registro Inválido", header.LineNumber);
                }

                foreach(Amex.PagamentoRow pagto in layout.PagamentoRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                    foreach(Amex.SOCRow soc in layout.SOCRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                    {
                        foreach(Amex.ROCRow roc in layout.ROCRows.Where(p => p.ParentLineNumber == soc.LineNumber))
                        {

                        }
                        foreach(Amex.AjustesRow ajuste in layout.AjustesRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                        {

                        }
                    }
                }
                foreach(Amex.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {

                }
            }        

        }

        public void Save()
        {
            //TODO: Save the data
            Amex layout = (Amex)this.ImportFile.ImportAttributes;

            foreach (Amex.HeaderRow header in layout.HeaderRows)
            {
                foreach (Amex.PagamentoRow pagto in layout.PagamentoRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                    foreach (Amex.SOCRow soc in layout.SOCRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                    {
                        foreach (Amex.ROCRow roc in layout.ROCRows.Where(p => p.ParentLineNumber == soc.LineNumber))
                        {

                        }
                        foreach (Amex.AjustesRow ajuste in layout.AjustesRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                        {

                        }
                    }
                }
                foreach (Amex.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                }
            }

        }

        #endregion
    }

}
