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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestAmex_Click(object sender, EventArgs e)
        {            
            string filePath = Path.Combine(Application.StartupPath, "SampleFiles\\Amex.txt");
            LayoutImport li = new LayoutImport(filePath, false, LayoutType.Amex);
            if (li.BreakPoint != BreakPoint.Success)
            {
                MessageBox.Show(li.LayoutBase.GetErrors());
            }
            else
            { 
                //Get the lines

                Amex layout = (Amex)li.LayoutBase.ImportFile.ImportAttributes;

                StringBuilder sb = new StringBuilder();
                string tab1 = "    ";
                string tab2 = "        ";
                string tab3 = "            ";

                foreach (Amex.HeaderRow header in layout.HeaderRows)
                {
                    sb.Append(header.LineNumber + "\n");

                    foreach (Amex.PagamentoRow pagto in layout.PagamentoRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(tab1 + pagto.LineNumber + "\n");

                        foreach (Amex.SOCRow soc in layout.SOCRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                        {
                            sb.Append(tab2 + soc.LineNumber + "\n");

                            foreach (Amex.ROCRow roc in layout.ROCRows.Where(p => p.ParentLineNumber == soc.LineNumber))
                            {
                                sb.Append(tab3 + roc.LineNumber + "\n");
                            }

                            foreach (Amex.AjustesRow ajuste in layout.AjustesRows.Where(p => p.ParentLineNumber == pagto.LineNumber))
                            {
                                sb.Append(tab3 + ajuste.LineNumber + "\n");
                            }
                        }
                    }

                    foreach (Amex.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(tab1 + trailer.LineNumber + "\n");
                    }
                }

                MessageBox.Show(sb.ToString());

            }
        }

        private void btnTestHipercard_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, "SampleFiles\\Hipercard.txt");
            LayoutImport li = new LayoutImport(filePath, false, LayoutType.Hipercard);
            if (li.BreakPoint != BreakPoint.Success)
            {
                MessageBox.Show(li.LayoutBase.GetErrors());
            }
            else
            {
                //Get the lines

                Hipercard layout = (Hipercard)li.LayoutBase.ImportFile.ImportAttributes;

                StringBuilder sb = new StringBuilder();
                string tab1 = "    ";
                string tab2 = "        ";
                string tab3 = "            ";

                foreach (Hipercard.HeaderRow header in layout.HeaderRows)
                {

                    sb.Append(header.LineNumber + "\n");

                    foreach (Hipercard.CapaLoteRow capalote in layout.CapaLoteRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {

                        sb.Append(tab1 + capalote.LineNumber + "\n");

                        foreach (Hipercard.MovimentoVendaRow movtovenda in layout.MovVendaRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                        {
                            sb.Append(tab2 + movtovenda.LineNumber + "\n");
                            
                            foreach (Hipercard.PrevisaoPagamentoRow prevPagto in layout.PrevPagtoRows.Where(p => p.ParentLineNumber == movtovenda.LineNumber))
                            {
                                sb.Append(tab3 + prevPagto.LineNumber + "\n");
                            }
                        }
                        
                        foreach (Hipercard.DesagendamentoRow desagendamento in layout.DesagendaRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                        {
                            sb.Append(tab2 + desagendamento.LineNumber + "\n");
                        }


                        foreach (Hipercard.AjustesRow ajuste in layout.AjustesRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                        {
                            sb.Append(tab2 + ajuste.LineNumber + "\n");
                        }


                        foreach (Hipercard.TarifasRow tarifa in layout.TarifasRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                        {
                            sb.Append(tab2 + tarifa.LineNumber + "\n");
                        }
                    }


                    foreach (Hipercard.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                    {
                        sb.Append(tab1 + trailer.LineNumber + "\n");
                    }
                }

                MessageBox.Show(sb.ToString());

            }
        }
    }
}
