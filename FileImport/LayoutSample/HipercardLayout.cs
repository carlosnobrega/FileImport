using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileImport.Base;
using FileImport.Common;
using FileImport.Interface;

namespace FileImport.LayoutSample
{

    public sealed class HipercardLayout : LayoutBase, ILayout
    {

        #region ILayout Members

        public LayoutType LayoutType
        {
            get { return LayoutType.Hipercard; }
        }

        #endregion

        public void Import(string fileName)
        {
            int lineHeader = 0;
            int lineCapaLote = 0;

            Hipercard hipercardLayout = new Hipercard();

            this.ImportFile = new ImportFile(hipercardLayout);
            if (ImportFile.PrepareFile(fileName))
            {

                while ((ImportFile.ReadLine() && !ImportFile.ReadFailure))
                {
                    switch ((Hipercard.TipoRegistro)int.Parse(ImportFile.CurrentIdentifier))
                    {
                        case Hipercard.TipoRegistro.Header:

                            lineHeader = ImportFile.CurrentLineNumber;
                            hipercardLayout.HeaderRows.Add(new Hipercard.HeaderRow(ImportFile.CurrentLine));
                            hipercardLayout.HeaderRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            break;

                        case Hipercard.TipoRegistro.CapaLote:

                            lineCapaLote = ImportFile.CurrentLineNumber;
                            hipercardLayout.CapaLoteRows.Add(new Hipercard.CapaLoteRow(ImportFile.CurrentLine));
                            hipercardLayout.CapaLoteRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            hipercardLayout.CapaLoteRows.Last().ParentLineNumber = lineHeader;

                            break;
                        case Hipercard.TipoRegistro.MovimentoVenda:

                            hipercardLayout.MovVendaRows.Add(new Hipercard.MovimentoVendaRow(ImportFile.CurrentLine));
                            hipercardLayout.MovVendaRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            hipercardLayout.MovVendaRows.Last().ParentLineNumber = lineCapaLote;

                            break;
                        case Hipercard.TipoRegistro.PrevisaoPagamento:

                            hipercardLayout.PrevPagtoRows.Add(new Hipercard.PrevisaoPagamentoRow(ImportFile.CurrentLine));
                            hipercardLayout.PrevPagtoRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            hipercardLayout.PrevPagtoRows.Last().ParentLineNumber = lineCapaLote;

                            break;
                        case Hipercard.TipoRegistro.Desagendamento:

                            hipercardLayout.DesagendaRows.Add(new Hipercard.DesagendamentoRow(ImportFile.CurrentLine));
                            hipercardLayout.DesagendaRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            hipercardLayout.DesagendaRows.Last().ParentLineNumber = lineCapaLote;

                            break;
                        case Hipercard.TipoRegistro.Ajustes:

                            hipercardLayout.AjustesRows.Add(new Hipercard.AjustesRow(ImportFile.CurrentLine));
                            hipercardLayout.AjustesRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            hipercardLayout.AjustesRows.Last().ParentLineNumber = lineCapaLote;

                            break;
                        case Hipercard.TipoRegistro.Tarifas:

                            hipercardLayout.TarifasRows.Add(new Hipercard.TarifasRow(ImportFile.CurrentLine));
                            hipercardLayout.TarifasRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            hipercardLayout.TarifasRows.Last().ParentLineNumber = lineCapaLote;

                            break;
                        case Hipercard.TipoRegistro.Trailer:

                            hipercardLayout.TrailerRows.Add(new Hipercard.TrailerRow(ImportFile.CurrentLine));
                            hipercardLayout.TrailerRows.Last().LineNumber = ImportFile.CurrentLineNumber;
                            hipercardLayout.TrailerRows.Last().ParentLineNumber = lineHeader;

                            break;
                    }

                    if (this.ImportOnlyFirstLine)
                    {
                        break;
                    }

                }
            }
        }

        public void ValidateStructure(ImportAttributes attr)
        {
            //TODO: Validate the strucure of the file
        }

        public void Validate(ImportAttributes attr)
        {
            Hipercard layout = (Hipercard)this.ImportFile.ImportAttributes;

            int[] lotes1 = {
			    205,
			    206,
			    213,
			    777,
			    888,
			    999
		    };

            int[] lotes2 = {
			    205,
			    206,
			    213,
			    999
		    };

            string[] status = {
			    "PRE",
			    "PAG",
			    "ANT",
			    "DES",
			    "AJU",
			    "TAR"
		    };

            string[] IdentificRevendaAntecips = {
			    " ",
			    "R",
			    "A"
		    };
            
            int[] IndicadorJuros = {
			    0,
			    1,
			    2
		    };

            string[] FormaPagamentos = {
			    " ",
			    "U",
			    "P"
		    };

            int iTotalTrans = 0;


            foreach (Hipercard.HeaderRow header in layout.HeaderRows)
            {
                iTotalTrans = 1;

                if (header.DtProcessamento > System.DateTime.Today)
                {
                    this.AddLineError("99", "DATA DE PROCESSAMENTO INVALIDA", header.LineNumber);
                    continue;
                }

                if (header.PerInicial > System.DateTime.Today || header.PerInicial < System.DateTime.Today.AddDays(-90))
                {
                    this.AddLineError("99", "PERIODO INICIAL INVALIDO", header.LineNumber);
                    continue;
                }

                if (header.PerFinal > System.DateTime.Today)
                {
                    this.AddLineError("99", "PERIODO FINAL INVALIDO", header.LineNumber);
                    continue;
                }

                if (header.EmpresaAcquirer.Trim().ToUpper() != "HIPERCARD")
                {
                    this.AddLineError("99", "EMPRESA ACQUIRER DEVE SER HIPERCARD", header.LineNumber);
                    continue;
                }

                if (header.Versao != "002.04")
                {
                    this.AddLineError("99", "VERSAO INVALIDA DO LAYOUT", header.LineNumber);
                    continue;
                }


                foreach (Hipercard.CapaLoteRow capalote in layout.CapaLoteRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                    iTotalTrans += 1;

                    if (!lotes1.Contains(capalote.TpLote))
                    {
                        this.AddLineError("99", "TIPO DE LOTE INVALIDO", capalote.LineNumber);
                        continue;
                    }

                    if (capalote.NroLote == 0)
                    {
                        this.AddLineError("99", "NUMERO DE LOTE INVALIDO", capalote.LineNumber);
                        continue;
                    }

                    if (!status.Contains(capalote.Status))
                    {
                        this.AddLineError("99", "STATUS INVALIDO", capalote.LineNumber);
                        continue;
                    }

                    if (!IdentificRevendaAntecips.Contains(capalote.IdentificRevendaAntecip))
                    {
                        this.AddLineError("99", "INDICADOR REVENDA/ANTECIPACAO INVALIDA", capalote.LineNumber);
                        continue;
                    }

                    if (!IndicadorJuros.Contains(capalote.IndicadorJuros))
                    {
                        this.AddLineError("99", "INDICADOR DE JUROS INVALIDO", capalote.LineNumber);
                        continue;
                    }

                    if (!FormaPagamentos.Contains(capalote.FormaPagamento))
                    {
                        this.AddLineError("99", "FORMA DE PAGAMENTO INVALIDA", capalote.LineNumber);
                        continue;
                    }


                    foreach (Hipercard.MovimentoVendaRow movtovenda in layout.MovVendaRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                    {
                        iTotalTrans += 1;

                        if (!lotes2.Contains(movtovenda.TpLote))
                        {
                            this.AddLineError("99", "TIPO DE LOTE INVALIDO", capalote.LineNumber);
                            continue;
                        }

                        if (movtovenda.NroLote == 0)
                        {
                            this.AddLineError("99", "NUMERO DE LOTE INVALIDO", capalote.LineNumber);
                            continue;
                        }


                        foreach (Hipercard.PrevisaoPagamentoRow prevPagto in layout.PrevPagtoRows.Where(p => p.ParentLineNumber == movtovenda.LineNumber))
                        {
                            iTotalTrans += 1;

                            if (!lotes2.Contains(prevPagto.TpLote))
                            {
                                this.AddLineError("99", "TIPO DE LOTE INVALIDO", prevPagto.LineNumber);
                                continue;
                            }

                            if (prevPagto.NroLote == 0)
                            {
                                this.AddLineError("99", "NUMERO DE LOTE INVALIDO", prevPagto.LineNumber);
                                continue;
                            }

                        }
                    }


                    foreach (Hipercard.DesagendamentoRow desagendamento in layout.DesagendaRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                    {
                        iTotalTrans += 1;

                        if (desagendamento.TpLote != 777)
                        {
                            this.AddLineError("99", "TIPO DE LOTE INVALIDO", desagendamento.LineNumber);
                            continue;
                        }

                        if (desagendamento.NroLote == 0)
                        {
                            this.AddLineError("99", "NUMERO DE LOTE INVALIDO", desagendamento.LineNumber);
                            continue;
                        }

                    }


                    foreach (Hipercard.AjustesRow ajuste in layout.AjustesRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                    {
                        iTotalTrans += 1;

                        if (ajuste.TpLote != 888)
                        {
                            this.AddLineError("99", "TIPO DE LOTE INVALIDO", ajuste.LineNumber);
                            continue;
                        }

                        if (ajuste.NroLote == 0)
                        {
                            this.AddLineError("99", "NUMERO DE LOTE INVALIDO", ajuste.LineNumber);
                            continue;
                        }

                    }


                    foreach (Hipercard.TarifasRow tarifa in layout.TarifasRows.Where(p => p.ParentLineNumber == capalote.LineNumber))
                    {
                        iTotalTrans += 1;

                        if (tarifa.TpLote != 999)
                        {
                            this.AddLineError("99", "TIPO DE LOTE INVALIDO", tarifa.LineNumber);
                            continue;
                        }

                        if (tarifa.NroLote == 0)
                        {
                            this.AddLineError("99", "NUMERO DE LOTE INVALIDO", tarifa.LineNumber);
                            continue;
                        }

                    }
                }


                foreach (Hipercard.TrailerRow trailer in layout.TrailerRows.Where(p => p.ParentLineNumber == header.LineNumber))
                {
                    if (trailer.TotTransacoes != iTotalTrans)
                    {
                        this.AddLineError("99", "TOTAL DE TRANSACOES INVALIDA", trailer.LineNumber);
                        continue;
                    }

                }
            }

        }

        public void Save()
        {
            //TODO: Save the data
        }
        
    }
}