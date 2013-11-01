using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using FileImport.Common;
using FileImport.Base;
using FileImport.LayoutOperation;
using FileImport.LayoutSample;

namespace Test
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void btnSample1_Click(object sender, EventArgs e)
        {
            LayoutImport li = importFile("SampleFiles\\Sample1.txt", LayoutType.Sample1);
            if (li != null)
            {
                txtResult2.Text = li.LayoutBase.Lines.ToString();

                StringBuilder sb = new StringBuilder();
                
                Sample1 layout = (Sample1)li.LayoutBase.ImportFile.ImportAttributes;
                foreach(Sample1.HeaderRow header in layout.HeaderRows)
                {
                    sb.Append(header.Field1 + " ");
                    sb.Append(header.Field2);
                    sb.Append(Environment.NewLine);

                    foreach (Sample1.DetailRow detail in layout.DetailRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(detail.Field1 + " ");
                        sb.Append(detail.Field2 + " ");
                        sb.Append(detail.Field3);
                        sb.Append(Environment.NewLine);
                    }

                    foreach (Sample1.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(trailer.Field1);
                        sb.Append(Environment.NewLine);
                    }
                }

                txtResult1.Text = sb.ToString();
                
            }
        }

        private void btnSample2_Click(object sender, EventArgs e)
        {
            LayoutImport li = importFile("SampleFiles\\Sample2.txt", LayoutType.Sample2);
            if (li != null)
            {
                txtResult2.Text = li.LayoutBase.Lines.ToString();

                StringBuilder sb = new StringBuilder();
                
                Sample2 layout = (Sample2)li.LayoutBase.ImportFile.ImportAttributes;
                foreach (Sample2.HeaderRow header in layout.HeaderRows)
                {
                    sb.Append(header.Field1 + " ");
                    sb.Append(header.Field2);
                    sb.Append(Environment.NewLine);

                    foreach (Sample2.DetailRow detail in layout.DetailRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(detail.Field1 + " ");
                        sb.Append(detail.Field2 + " ");
                        sb.Append(detail.Field3);
                        sb.Append(Environment.NewLine);
                    }

                    foreach (Sample2.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(trailer.Field1);
                        sb.Append(Environment.NewLine);
                    }
                }

                txtResult1.Text = sb.ToString();

            }
        }

        private void btnTestAmex_Click(object sender, EventArgs e)
        {
            LayoutImport li = importFile("SampleFiles\\Amex.txt", LayoutType.Amex);
            if (li != null)
            { 
                //Get the lines

                Amex layout = (Amex)li.LayoutBase.ImportFile.ImportAttributes;

                txtResult2.Text = li.LayoutBase.Lines.ToString();

                StringBuilder sb = new StringBuilder();
                string tab1 = "    ";
                string tab2 = "        ";
                string tab3 = "            ";

                foreach (Amex.HeaderRow header in layout.HeaderRows)
                {
                    sb.Append(header.LineNumber + Environment.NewLine);

                    foreach (Amex.PagamentoRow pagto in layout.PagamentoRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(tab1 + pagto.LineNumber + Environment.NewLine);

                        foreach (Amex.SOCRow soc in layout.SOCRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                        {
                            sb.Append(tab2 + soc.LineNumber + Environment.NewLine);

                            foreach (Amex.ROCRow roc in layout.ROCRows.Where(p => p.ParentLineNumber == soc.LineNumber))
                            {
                                sb.Append(tab3 + roc.LineNumber + Environment.NewLine);
                            }

                            foreach (Amex.AjustesRow ajuste in layout.AjustesRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                            {
                                sb.Append(tab3 + ajuste.LineNumber + Environment.NewLine);
                            }
                        }
                    }

                    foreach (Amex.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(tab1 + trailer.LineNumber + Environment.NewLine);
                    }
                }

                txtResult1.Text = sb.ToString();

            }
        }

        private void btnTestHipercard_Click(object sender, EventArgs e)
        {
            LayoutImport li = importFile("SampleFiles\\Hipercard.txt", LayoutType.Hipercard);
            if (li != null)
            {             
                //Get the lines

                Hipercard layout = (Hipercard)li.LayoutBase.ImportFile.ImportAttributes;

                txtResult2.Text = li.LayoutBase.Lines.ToString();

                StringBuilder sb = new StringBuilder();
                string tab1 = "    ";
                string tab2 = "        ";
                string tab3 = "            ";

                foreach (Hipercard.HeaderRow header in layout.HeaderRows)
                {

                    sb.Append(header.LineNumber + Environment.NewLine);

                    foreach (Hipercard.CapaLoteRow capalote in layout.CapaLoteRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {

                        sb.Append(tab1 + capalote.LineNumber + Environment.NewLine);

                        foreach (Hipercard.MovimentoVendaRow movtovenda in layout.MovVendaRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                        {
                            sb.Append(tab2 + movtovenda.LineNumber + Environment.NewLine);
                            
                            foreach (Hipercard.PrevisaoPagamentoRow prevPagto in layout.PrevPagtoRows.Where(p => p.ParentLineNumber == movtovenda.LineNumber))
                            {
                                sb.Append(tab3 + prevPagto.LineNumber + Environment.NewLine);
                            }
                        }
                        
                        foreach (Hipercard.DesagendamentoRow desagendamento in layout.DesagendaRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                        {
                            sb.Append(tab2 + desagendamento.LineNumber + Environment.NewLine);
                        }


                        foreach (Hipercard.AjustesRow ajuste in layout.AjustesRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                        {
                            sb.Append(tab2 + ajuste.LineNumber + Environment.NewLine);
                        }


                        foreach (Hipercard.TarifasRow tarifa in layout.TarifasRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                        {
                            sb.Append(tab2 + tarifa.LineNumber + Environment.NewLine);
                        }
                    }


                    foreach (Hipercard.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(tab1 + trailer.LineNumber + Environment.NewLine);
                    }
                }

                txtResult1.Text = sb.ToString();

            }
        }

        private LayoutImport importFile(string fileName, LayoutType layoutType)
        {
            string filePath = Path.Combine(Application.StartupPath, fileName);
            LayoutImport li = new LayoutImport(filePath, false, layoutType);
            if (li.BreakPoint != BreakPoint.Success)
            {
                MessageBox.Show(li.LayoutBase.GetErrors());
                return null;
            }
            else
            {
                return li;
            }
        }

    }
}
