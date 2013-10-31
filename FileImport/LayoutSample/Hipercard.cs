using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using FileImport.Base;
using FileImport.Common;

namespace FileImport.LayoutSample
{
    public class Hipercard : ImportAttributes
    {

        #region "Methods"

        public Hipercard() : base(ImportEncodingType.Default, ImportType.Positioned)
        {
            this.Lines.Add(addHeader(new ImportLine
            {
                Identifier = "0",
                LineName = "Registro Header de Arquivo",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 300
            }));

            this.Lines.Add(addCapaLote(new ImportLine
            {
                Identifier = "1",
                LineName = "Registro detalhe 1 - Capa de Lote",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 300
            }));

            this.Lines.Add(addMovimentoVenda(new ImportLine
            {
                Identifier = "2",
                LineName = "Registro detalhe 2 -  Movimentos de Vendas",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 300
            }));

            this.Lines.Add(addPrevisaoPagamento(new ImportLine
            {
                Identifier = "3",
                LineName = "Registro detalhe 3 -  Previsões de Pagamento",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 300
            }));

            this.Lines.Add(addDesagendamento(new ImportLine
            {
                Identifier = "4",
                LineName = "Registro detalhe 4 -  Desagendamento de parcelas",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 300
            }));

            this.Lines.Add(addAjustes(new ImportLine
            {
                Identifier = "5",
                LineName = "Registro detalhe 5 - Ajustes",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 300
            }));

            this.Lines.Add(addTarifas(new ImportLine
            {
                Identifier = "7",
                LineName = "Registro detalhe 7 - Tarifas",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 300
            }));

            this.Lines.Add(addTrailer(new ImportLine
            {
                Identifier = "9",
                LineName = "Registro Trailer de Arquivo",
                IdentifierStartPosition = 1,
                IdentifierLength = 1,
                LineLength = 300
            }));

        }

        private ImportLine addHeader(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "TpRegistro",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "Matriz",
                FieldStartPosition = 2,
                FieldLength = 10
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtProcessamento",
                FieldStartPosition = 12,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "PerInicial",
                FieldStartPosition = 20,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "PerFinal",
                FieldStartPosition = 28,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "Sequencia",
                FieldStartPosition = 36,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "EmpresaAcquirer",
                FieldStartPosition = 43,
                FieldLength = 9
            });
            line.Fields.Add(new ImportField
            {
                Field = "Versao",
                FieldStartPosition = 52,
                FieldLength = 6
            });
            line.Fields.Add(new ImportField
            {
                Field = "Vago",
                FieldStartPosition = 58,
                FieldLength = 243
            });
            return line;
        }

        private ImportLine addCapaLote(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "TpRegistro",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "LojaSubmissora",
                FieldStartPosition = 2,
                FieldLength = 10
            });
            line.Fields.Add(new ImportField
            {
                Field = "TpLote",
                FieldStartPosition = 12,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLote",
                FieldStartPosition = 15,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "ParcPagaPlano",
                FieldStartPosition = 22,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "Status",
                FieldStartPosition = 27,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtRemessa",
                FieldStartPosition = 30,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtProcessamento",
                FieldStartPosition = 38,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtProgCredito",
                FieldStartPosition = 46,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred",
                FieldStartPosition = 54,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrBruto",
                FieldStartPosition = 62,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrBruto",
                FieldStartPosition = 63,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrRejeitado",
                FieldStartPosition = 76,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrRejeitado",
                FieldStartPosition = 77,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParcela1",
                FieldStartPosition = 90,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParcela1",
                FieldStartPosition = 91,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "PercTaxaAdmin",
                FieldStartPosition = 104,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalTaxaAdmin",
                FieldStartPosition = 109,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTaxaAdmin",
                FieldStartPosition = 110,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "PercTaxaFinan",
                FieldStartPosition = 123,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalTaxaFinan",
                FieldStartPosition = 128,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTaxaFinan",
                FieldStartPosition = 129,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrLiqParc",
                FieldStartPosition = 142,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrLiqParc",
                FieldStartPosition = 143,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrTitTaxaEmbarque",
                FieldStartPosition = 156,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTitTaxaEmbarque",
                FieldStartPosition = 157,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "Banco",
                FieldStartPosition = 170,
                FieldLength = 4
            });
            line.Fields.Add(new ImportField
            {
                Field = "Agencia",
                FieldStartPosition = 174,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "ContaCorrente",
                FieldStartPosition = 179,
                FieldLength = 14
            });
            line.Fields.Add(new ImportField
            {
                Field = "QtdeVendas",
                FieldStartPosition = 193,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "TipoCredDeb",
                FieldStartPosition = 198,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "QtdeVendasRejeitadas",
                FieldStartPosition = 199,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLoteOriginal",
                FieldStartPosition = 204,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "IdentificRevendaAntecip",
                FieldStartPosition = 211,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "IndicadorJuros",
                FieldStartPosition = 212,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "FormaPagamento",
                FieldStartPosition = 213,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrDifBruta1",
                FieldStartPosition = 214,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrDifBruta1",
                FieldStartPosition = 215,
                FieldLength = 4
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrDifBruta2",
                FieldStartPosition = 219,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrDifBruta2",
                FieldStartPosition = 220,
                FieldLength = 4
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrDifLiq3",
                FieldStartPosition = 224,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrDifLiq3",
                FieldStartPosition = 225,
                FieldLength = 4
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrDifLiq4",
                FieldStartPosition = 229,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrDifLiq4",
                FieldStartPosition = 230,
                FieldLength = 4
            });
            line.Fields.Add(new ImportField
            {
                Field = "PagtoFlexivel",
                FieldStartPosition = 234,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "Vago",
                FieldStartPosition = 235,
                FieldLength = 66
            });
            return line;
        }

        private ImportLine addMovimentoVenda(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "TpRegistro",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "LojaSubmissora",
                FieldStartPosition = 2,
                FieldLength = 10
            });
            line.Fields.Add(new ImportField
            {
                Field = "TpLote",
                FieldStartPosition = 12,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLote",
                FieldStartPosition = 15,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroCartaoHiper",
                FieldStartPosition = 22,
                FieldLength = 19
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtCompra",
                FieldStartPosition = 41,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrTotCompra",
                FieldStartPosition = 49,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTotCompra",
                FieldStartPosition = 50,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParcCompra",
                FieldStartPosition = 63,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParcCompra",
                FieldStartPosition = 64,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalTaxaEmbarque",
                FieldStartPosition = 77,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTaxaEmbarque",
                FieldStartPosition = 78,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "MotivoRejeicao",
                FieldStartPosition = 91,
                FieldLength = 30
            });
            line.Fields.Add(new ImportField
            {
                Field = "CodAutorizacao",
                FieldStartPosition = 121,
                FieldLength = 6
            });
            line.Fields.Add(new ImportField
            {
                Field = "NSU",
                FieldStartPosition = 127,
                FieldLength = 6
            });
            line.Fields.Add(new ImportField
            {
                Field = "MeioCaptura",
                FieldStartPosition = 133,
                FieldLength = 6
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroTerminal",
                FieldStartPosition = 139,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "Estabelecimento",
                FieldStartPosition = 147,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLoteOriginal",
                FieldStartPosition = 150,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrBrutoParc",
                FieldStartPosition = 157,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrBrutoParc",
                FieldStartPosition = 158,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrLiquidoParc",
                FieldStartPosition = 171,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrLiquidoParc",
                FieldStartPosition = 172,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "StatusVenda",
                FieldStartPosition = 185,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrLiquidoParcComResto",
                FieldStartPosition = 188,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrLiquidoParcComResto",
                FieldStartPosition = 189,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "QtdeParcelas",
                FieldStartPosition = 202,
                FieldLength = 2
            });
            line.Fields.Add(new ImportField
            {
                Field = "Vago",
                FieldStartPosition = 204,
                FieldLength = 97
            });
            return line;
        }

        private ImportLine addPrevisaoPagamento(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "TpRegistro",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "LojaSubmissora",
                FieldStartPosition = 2,
                FieldLength = 10
            });
            line.Fields.Add(new ImportField
            {
                Field = "TpLote",
                FieldStartPosition = 12,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLote",
                FieldStartPosition = 15,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtRemessa",
                FieldStartPosition = 22,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtProcessamento",
                FieldStartPosition = 30,
                FieldLength = 8
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtProgCredParc2",
                FieldStartPosition = 38,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "ParcPagaPlano2",
                FieldStartPosition = 46,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc2",
                FieldStartPosition = 51,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc2",
                FieldStartPosition = 52,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "PercTaxaAdmin2",
                FieldStartPosition = 65,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrTaxaAdmin2",
                FieldStartPosition = 70,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTaxaAdmin2",
                FieldStartPosition = 71,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "PercTaxaFinan2",
                FieldStartPosition = 84,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrTaxaFinan2",
                FieldStartPosition = 89,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTaxaFinan2",
                FieldStartPosition = 90,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrLiqParc2",
                FieldStartPosition = 103,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrLiqParc2",
                FieldStartPosition = 104,
                FieldLength = 13
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtProgCredParc3",
                FieldStartPosition = 117,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "ParcPagaPlano3",
                FieldStartPosition = 125,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc3",
                FieldStartPosition = 130,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc3",
                FieldStartPosition = 131,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "PercTaxaAdmin3",
                FieldStartPosition = 144,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrTaxaAdmin3",
                FieldStartPosition = 149,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTaxaAdmin3",
                FieldStartPosition = 150,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "PercTaxaFinan3",
                FieldStartPosition = 163,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrTaxaFinan3",
                FieldStartPosition = 168,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTaxaFinan3",
                FieldStartPosition = 169,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrLiqParc3",
                FieldStartPosition = 182,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrLiqParc3",
                FieldStartPosition = 183,
                FieldLength = 13
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtProgCredParc4",
                FieldStartPosition = 196,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "ParcPagaPlano4",
                FieldStartPosition = 204,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc4",
                FieldStartPosition = 209,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc4",
                FieldStartPosition = 210,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "PercTaxaAdmin4",
                FieldStartPosition = 223,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrTaxaAdmin4",
                FieldStartPosition = 228,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTaxaAdmin4",
                FieldStartPosition = 229,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "PercTaxaFinan4",
                FieldStartPosition = 242,
                FieldLength = 5
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrTaxaFinan4",
                FieldStartPosition = 247,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTaxaFinan4",
                FieldStartPosition = 248,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrLiqParc4",
                FieldStartPosition = 261,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrLiqParc4",
                FieldStartPosition = 262,
                FieldLength = 13
            });

            line.Fields.Add(new ImportField
            {
                Field = "SinalDif1Parc2",
                FieldStartPosition = 275,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrDif1Parc2",
                FieldStartPosition = 276,
                FieldLength = 4
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalDif1Parc3",
                FieldStartPosition = 280,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrDif1Parc3",
                FieldStartPosition = 281,
                FieldLength = 4
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalDif1Parc4",
                FieldStartPosition = 285,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrDif1Parc4",
                FieldStartPosition = 286,
                FieldLength = 4
            });

            line.Fields.Add(new ImportField
            {
                Field = "Vago",
                FieldStartPosition = 290,
                FieldLength = 11
            });
            return line;
        }

        private ImportLine addDesagendamento(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "TpRegistro",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "LojaSubmissora",
                FieldStartPosition = 2,
                FieldLength = 10
            });
            line.Fields.Add(new ImportField
            {
                Field = "TpLote",
                FieldStartPosition = 12,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLote",
                FieldStartPosition = 15,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroCartaoHiper",
                FieldStartPosition = 22,
                FieldLength = 19
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtRemessa",
                FieldStartPosition = 41,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "QtdeParcelas",
                FieldStartPosition = 49,
                FieldLength = 2
            });
            line.Fields.Add(new ImportField
            {
                Field = "NSU",
                FieldStartPosition = 51,
                FieldLength = 6
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLoteOrigem",
                FieldStartPosition = 57,
                FieldLength = 7
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred1",
                FieldStartPosition = 64,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc1",
                FieldStartPosition = 72,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc1",
                FieldStartPosition = 73,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroParc1",
                FieldStartPosition = 86,
                FieldLength = 2
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred2",
                FieldStartPosition = 88,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc2",
                FieldStartPosition = 96,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc2",
                FieldStartPosition = 97,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroParc2",
                FieldStartPosition = 110,
                FieldLength = 2
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred3",
                FieldStartPosition = 112,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc3",
                FieldStartPosition = 120,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc3",
                FieldStartPosition = 121,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroParc3",
                FieldStartPosition = 134,
                FieldLength = 2
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred4",
                FieldStartPosition = 136,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc4",
                FieldStartPosition = 144,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc4",
                FieldStartPosition = 145,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroParc4",
                FieldStartPosition = 158,
                FieldLength = 2
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred5",
                FieldStartPosition = 160,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc5",
                FieldStartPosition = 168,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc5",
                FieldStartPosition = 169,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroParc5",
                FieldStartPosition = 182,
                FieldLength = 2
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred6",
                FieldStartPosition = 184,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc6",
                FieldStartPosition = 192,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc6",
                FieldStartPosition = 193,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroParc6",
                FieldStartPosition = 206,
                FieldLength = 2
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred7",
                FieldStartPosition = 208,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc7",
                FieldStartPosition = 216,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc7",
                FieldStartPosition = 217,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroParc7",
                FieldStartPosition = 230,
                FieldLength = 2
            });

            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred8",
                FieldStartPosition = 232,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrParc8",
                FieldStartPosition = 240,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrParc8",
                FieldStartPosition = 241,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroParc8",
                FieldStartPosition = 254,
                FieldLength = 2
            });

            line.Fields.Add(new ImportField
            {
                Field = "Vago",
                FieldStartPosition = 256,
                FieldLength = 45
            });
            return line;
        }

        private ImportLine addAjustes(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "TpRegistro",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "LojaSubmissora",
                FieldStartPosition = 2,
                FieldLength = 10
            });
            line.Fields.Add(new ImportField
            {
                Field = "TpLote",
                FieldStartPosition = 12,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLote",
                FieldStartPosition = 15,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroCartaoHiper",
                FieldStartPosition = 22,
                FieldLength = 19
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtProgDebCred",
                FieldStartPosition = 41,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtDebCred",
                FieldStartPosition = 49,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtRemessa",
                FieldStartPosition = 57,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrBrutoAjuste",
                FieldStartPosition = 65,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrBrutoAjuste",
                FieldStartPosition = 66,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrLiqAjuste",
                FieldStartPosition = 79,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrLiqAjuste",
                FieldStartPosition = 80,
                FieldLength = 13
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroParcelas",
                FieldStartPosition = 93,
                FieldLength = 2
            });
            line.Fields.Add(new ImportField
            {
                Field = "QtdeParcelas",
                FieldStartPosition = 95,
                FieldLength = 2
            });
            line.Fields.Add(new ImportField
            {
                Field = "NSU",
                FieldStartPosition = 97,
                FieldLength = 6
            });
            line.Fields.Add(new ImportField
            {
                Field = "CodAjuste",
                FieldStartPosition = 103,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "Descricao",
                FieldStartPosition = 106,
                FieldLength = 60
            });
            line.Fields.Add(new ImportField
            {
                Field = "Comentario",
                FieldStartPosition = 166,
                FieldLength = 90
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLoteOrigem",
                FieldStartPosition = 256,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "Vago",
                FieldStartPosition = 263,
                FieldLength = 38
            });
            return line;
        }

        private ImportLine addTarifas(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "TpRegistro",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "LojaSubmissora",
                FieldStartPosition = 2,
                FieldLength = 10
            });
            line.Fields.Add(new ImportField
            {
                Field = "TpLote",
                FieldStartPosition = 12,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "NroLote",
                FieldStartPosition = 15,
                FieldLength = 7
            });
            line.Fields.Add(new ImportField
            {
                Field = "DtDebito",
                FieldStartPosition = 22,
                FieldLength = 8
            });
            line.Fields.Add(new ImportField
            {
                Field = "PerReferencia",
                FieldStartPosition = 30,
                FieldLength = 6
            });
            line.Fields.Add(new ImportField
            {
                Field = "SinalVlrTarifa",
                FieldStartPosition = 36,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "VlrTarifa",
                FieldStartPosition = 37,
                FieldLength = 10
            });
            line.Fields.Add(new ImportField
            {
                Field = "TpTarifa",
                FieldStartPosition = 47,
                FieldLength = 3
            });
            line.Fields.Add(new ImportField
            {
                Field = "Vago",
                FieldStartPosition = 50,
                FieldLength = 251
            });
            return line;
        }

        private ImportLine addTrailer(ImportLine line)
        {
            line.Fields.Add(new ImportField
            {
                Field = "TpRegistro",
                FieldStartPosition = 1,
                FieldLength = 1
            });
            line.Fields.Add(new ImportField
            {
                Field = "TotTransacoes",
                FieldStartPosition = 2,
                FieldLength = 11
            });
            line.Fields.Add(new ImportField
            {
                Field = "Vago",
                FieldStartPosition = 13,
                FieldLength = 288
            });
            return line;
        }

        #endregion

        #region "Enum"
        public enum TipoRegistro : int
        {
            Header = 0,
            CapaLote = 1,
            MovimentoVenda = 2,
            PrevisaoPagamento = 3,
            Desagendamento = 4,
            Ajustes = 5,
            Tarifas = 7,
            Trailer = 9
        }
        #endregion

        #region "Rows"

        public List<Hipercard.HeaderRow> HeaderRows = new List<Hipercard.HeaderRow>();
        public List<Hipercard.CapaLoteRow> CapaLoteRows = new List<Hipercard.CapaLoteRow>();
        public List<Hipercard.MovimentoVendaRow> MovVendaRows = new List<Hipercard.MovimentoVendaRow>();
        public List<Hipercard.PrevisaoPagamentoRow> PrevPagtoRows = new List<Hipercard.PrevisaoPagamentoRow>();
        public List<Hipercard.DesagendamentoRow> DesagendaRows = new List<Hipercard.DesagendamentoRow>();
        public List<Hipercard.AjustesRow> AjustesRows = new List<Hipercard.AjustesRow>();
        public List<Hipercard.TarifasRow> TarifasRows = new List<Hipercard.TarifasRow>();

        public List<Hipercard.TrailerRow> TrailerRows = new List<Hipercard.TrailerRow>();
        public class HeaderRow : LayoutRow
        {

            public HeaderRow(DataRow Row) : base(Row)
            {
                this.Record = "Header";
            }

            public int TpRegistro
            {
                get { return this.GetInteger("TpRegistro"); }
            }

            public string Matriz
            {
                get { return Row["Matriz"].ToString(); }
            }

            public System.DateTime DtProcessamento
            {
                get { return this.GetDate("DtProcessamento", DateFormat.YYYYMMDD); }
            }

            public System.DateTime PerInicial
            {
                get { return this.GetDate("PerInicial", DateFormat.YYYYMMDD); }
            }

            public System.DateTime PerFinal
            {
                get { return this.GetDate("PerFinal", DateFormat.YYYYMMDD); }
            }

            public int Sequencia
            {
                get { return this.GetInteger("Sequencia"); }
            }

            public string EmpresaAcquirer
            {
                get { return Row["EmpresaAcquirer"].ToString(); }
            }

            public string Versao
            {
                get { return Row["Versao"].ToString(); }
            }

            public string Vago
            {
                get { return Row["Vago"].ToString(); }
            }

        }

        public class CapaLoteRow : LayoutRow
        {

            public CapaLoteRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Capa Lote";
            }

            public int TpRegistro
            {
                get { return this.GetInteger("TpRegistro"); }
            }

            public string LojaSubmissora
            {
                get { return Row["LojaSubmissora"].ToString(); }
            }

            public int TpLote
            {
                get { return this.GetInteger("TpLote"); }
            }

            public int NroLote
            {
                get { return this.GetInteger("NroLote"); }
            }

            public string ParcPagaPlano
            {
                get { return Row["ParcPagaPlano"].ToString(); }
            }

            public string Status
            {
                get { return Row["Status"].ToString(); }
            }

            public System.DateTime DtRemessa
            {
                get { return this.GetDate("DtRemessa", DateFormat.YYYYMMDD); }
            }

            public Nullable<System.DateTime> DtProcessamento
            {
                get { return this.GetDate("DtProcessamento", DateFormat.YYYYMMDD); }
            }

            public System.DateTime DtProgCredito
            {
                get { return this.GetDate("DtProgCredito", DateFormat.YYYYMMDD); }
            }

            public System.DateTime DtDebCred
            {
                get { return this.GetDate("DtDebCred", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrBruto
            {
                get { return Row["SinalVlrBruto"].ToString(); }
            }

            public decimal VlrBruto
            {
                get { return this.GetDecimal("VlrBruto"); }
            }

            public string SinalVlrRejeitado
            {
                get { return Row["SinalVlrRejeitado"].ToString(); }
            }

            public decimal VlrRejeitado
            {
                get { return this.GetDecimal("VlrRejeitado"); }
            }

            public string SinalVlrParcela1
            {
                get { return Row["SinalVlrParcela1"].ToString(); }
            }

            public decimal VlrParcela1
            {
                get { return this.GetDecimal("VlrParcela1"); }
            }

            public decimal PercTaxaAdmin
            {
                get { return this.GetDecimal("PercTaxaAdmin"); }
            }

            public string SinalTaxaAdmin
            {
                get { return Row["SinalTaxaAdmin"].ToString(); }
            }

            public decimal VlrTaxaAdmin
            {
                get { return this.GetDecimal("VlrTaxaAdmin"); }
            }

            public decimal PercTaxaFinan
            {
                get { return this.GetDecimal("PercTaxaFinan"); }
            }

            public string SinalTaxaFinan
            {
                get { return Row["SinalTaxaFinan"].ToString(); }
            }

            public decimal VlrTaxaFinan
            {
                get { return this.GetDecimal("VlrTaxaFinan"); }
            }

            public string SinalVlrLiqParc
            {
                get { return Row["SinalVlrLiqParc"].ToString(); }
            }

            public decimal VlrLiqParc
            {
                get { return this.GetDecimal("VlrLiqParc"); }
            }

            public string SinalVlrTitTaxaEmbarque
            {
                get { return Row["SinalVlrTitTaxaEmbarque"].ToString(); }
            }

            public decimal VlrTitTaxaEmbarque
            {
                get { return this.GetDecimal("VlrTitTaxaEmbarque"); }
            }

            public string Banco
            {
                get { return Row["Banco"].ToString(); }
            }

            public string Agencia
            {
                get { return Row["Agencia"].ToString(); }
            }

            public string ContaCorrente
            {
                get { return Row["ContaCorrente"].ToString(); }
            }

            public int QtdeVendas
            {
                get { return this.GetInteger("QtdeVendas"); }
            }

            public string TipoCredDeb
            {
                get { return Row["TipoCredDeb"].ToString(); }
            }

            public int QtdeVendasRejeitadas
            {
                get { return this.GetInteger("QtdeVendasRejeitadas"); }
            }

            public int NroLoteOriginal
            {
                get { return this.GetInteger("NroLoteOriginal"); }
            }

            public string IdentificRevendaAntecip
            {
                get { return Row["IdentificRevendaAntecip"].ToString(); }
            }

            public int IndicadorJuros
            {
                get { return this.GetInteger("IndicadorJuros"); }
            }

            public string FormaPagamento
            {
                get { return Row["FormaPagamento"].ToString(); }
            }

            public string SinalVlrDifBruta1
            {
                get { return Row["SinalVlrDifBruta1"].ToString(); }
            }

            public decimal VlrDifBruta1
            {
                get { return this.GetDecimal("VlrDifBruta1"); }
            }

            public string SinalVlrDifBruta2
            {
                get { return Row["SinalVlrDifBruta2"].ToString(); }
            }

            public decimal VlrDifBruta2
            {
                get { return this.GetDecimal("VlrDifBruta2"); }
            }

            public string SinalVlrDifLiq3
            {
                get { return Row["SinalVlrDifLiq3"].ToString(); }
            }

            public decimal VlrDifLiq3
            {
                get { return this.GetDecimal("VlrDifLiq3"); }
            }

            public string SinalVlrDifLiq4
            {
                get { return Row["SinalVlrDifLiq4"].ToString(); }
            }

            public decimal VlrDifLiq4
            {
                get { return this.GetDecimal("VlrDifLiq4"); }
            }

            public string PagtoFlexivel
            {
                get { return Row["PagtoFlexivel"].ToString(); }
            }

            public string Vago
            {
                get { return Row["Vago"].ToString(); }
            }

        }

        public class MovimentoVendaRow : LayoutRow
        {

            public MovimentoVendaRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Movimento Venda";
            }

            public int TpRegistro
            {
                get { return this.GetInteger("TpRegistro"); }
            }

            public string LojaSubmissora
            {
                get { return Row["LojaSubmissora"].ToString(); }
            }

            public int TpLote
            {
                get { return this.GetInteger("TpLote"); }
            }

            public int NroLote
            {
                get { return this.GetInteger("NroLote"); }
            }

            public string NroCartaoHiper
            {
                get { return Row["NroCartaoHiper"].ToString(); }
            }

            public System.DateTime DtCompra
            {
                get { return this.GetDate("DtCompra", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrTotCompra
            {
                get { return Row["SinalVlrTotCompra"].ToString(); }
            }

            public decimal VlrTotCompra
            {
                get { return this.GetDecimal("VlrTotCompra"); }
            }

            public string SinalVlrParcCompra
            {
                get { return Row["SinalVlrParcCompra"].ToString(); }
            }

            public decimal VlrParcCompra
            {
                get { return this.GetDecimal("VlrParcCompra"); }
            }

            public string SinalTaxaEmbarque
            {
                get { return Row["SinalTaxaEmbarque"].ToString(); }
            }

            public decimal VlrTaxaEmbarque
            {
                get { return this.GetDecimal("VlrTaxaEmbarque"); }
            }

            public string MotivoRejeicao
            {
                get { return Row["MotivoRejeicao"].ToString(); }
            }

            public string CodAutorizacao
            {
                get { return Row["CodAutorizacao"].ToString(); }
            }

            public string NSU
            {
                get { return Row["NSU"].ToString(); }
            }

            public string MeioCaptura
            {
                get { return Row["MeioCaptura"].ToString(); }
            }

            public string NroTerminal
            {
                get { return Row["NroTerminal"].ToString(); }
            }

            public int Estabelecimento
            {
                get { return this.GetInteger("Estabelecimento"); }
            }

            public int NroLoteOriginal
            {
                get { return this.GetInteger("NroLoteOriginal"); }
            }

            public string SinalVlrBrutoParc
            {
                get { return Row["SinalVlrBrutoParc"].ToString(); }
            }

            public decimal VlrBrutoParc
            {
                get { return this.GetDecimal("VlrBrutoParc"); }
            }

            public string SinalVlrLiquidoParc
            {
                get { return Row["SinalVlrLiquidoParc"].ToString(); }
            }

            public decimal VlrLiquidoParc
            {
                get { return this.GetDecimal("VlrLiquidoParc"); }
            }

            public string StatusVenda
            {
                get { return Row["StatusVenda"].ToString(); }
            }

            public string SinalVlrLiquidoParcComResto
            {
                get { return Row["SinalVlrLiquidoParcComResto"].ToString(); }
            }

            public decimal VlrLiquidoParcComResto
            {
                get { return this.GetDecimal("VlrLiquidoParcComResto"); }
            }

            public int QtdeParcelas
            {
                get { return this.GetInteger("QtdeParcelas"); }
            }

            public string Vago
            {
                get { return Row["Vago"].ToString(); }
            }


        }

        public class PrevisaoPagamentoRow : LayoutRow
        {

            public PrevisaoPagamentoRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Previsão Pagamento";
            }

            public int TpRegistro
            {
                get { return this.GetInteger("TpRegistro"); }
            }

            public string LojaSubmissora
            {
                get { return Row["LojaSubmissora"].ToString(); }
            }

            public int TpLote
            {
                get { return this.GetInteger("TpLote"); }
            }

            public int NroLote
            {
                get { return this.GetInteger("NroLote"); }
            }

            public System.DateTime DtRemessa
            {
                get { return this.GetDate("DtRemessa", DateFormat.YYYYMMDD); }
            }

            public System.DateTime DtProcessamento
            {
                get { return this.GetDate("DtProcessamento", DateFormat.YYYYMMDD); }
            }

            public System.DateTime DtProgCredParc2
            {
                get { return this.GetDate("DtProgCredParc2", DateFormat.YYYYMMDD); }
            }

            public string ParcPagaPlano2
            {
                get { return Row["ParcPagaPlano2"].ToString(); }
            }

            public string SinalVlrParc2
            {
                get { return Row["SinalVlrParc2"].ToString(); }
            }

            public decimal VlrParc2
            {
                get { return this.GetDecimal("VlrParc2"); }
            }

            public decimal PercTaxaAdmin2
            {
                get { return this.GetDecimal("PercTaxaAdmin2"); }
            }

            public string SinalVlrTaxaAdmin2
            {
                get { return Row["SinalVlrTaxaAdmin2"].ToString(); }
            }

            public decimal VlrTaxaAdmin2
            {
                get { return this.GetDecimal("VlrTaxaAdmin2"); }
            }

            public decimal PercTaxaFinan2
            {
                get { return this.GetDecimal("PercTaxaFinan2"); }
            }

            public string SinalVlrTaxaFinan2
            {
                get { return Row["SinalVlrTaxaFinan2"].ToString(); }
            }

            public decimal VlrTaxaFinan2
            {
                get { return this.GetDecimal("VlrTaxaFinan2"); }
            }

            public string SinalVlrLiqParc2
            {
                get { return Row["SinalVlrLiqParc2"].ToString(); }
            }

            public decimal VlrLiqParc2
            {
                get { return this.GetDecimal("VlrLiqParc2"); }
            }

            public System.DateTime DtProgCredParc3
            {
                get { return this.GetDate("DtProgCredParc3", DateFormat.YYYYMMDD); }
            }

            public string ParcPagaPlano3
            {
                get { return Row["ParcPagaPlano3"].ToString(); }
            }

            public string SinalVlrParc3
            {
                get { return Row["SinalVlrParc3"].ToString(); }
            }

            public decimal VlrParc3
            {
                get { return this.GetDecimal("VlrParc3"); }
            }

            public decimal PercTaxaAdmin3
            {
                get { return this.GetDecimal("PercTaxaAdmin3"); }
            }

            public string SinalVlrTaxaAdmin3
            {
                get { return Row["SinalVlrTaxaAdmin3"].ToString(); }
            }

            public decimal VlrTaxaAdmin3
            {
                get { return this.GetDecimal("VlrTaxaAdmin3"); }
            }

            public decimal PercTaxaFinan3
            {
                get { return this.GetDecimal("PercTaxaFinan3"); }
            }

            public string SinalVlrTaxaFinan3
            {
                get { return Row["SinalVlrTaxaFinan3"].ToString(); }
            }

            public decimal VlrTaxaFinan3
            {
                get { return this.GetDecimal("VlrTaxaFinan3"); }
            }

            public string SinalVlrLiqParc3
            {
                get { return Row["SinalVlrLiqParc3"].ToString(); }
            }

            public decimal VlrLiqParc3
            {
                get { return this.GetDecimal("VlrLiqParc3"); }
            }

            public System.DateTime DtProgCredParc4
            {
                get { return this.GetDate("DtProgCredParc4", DateFormat.YYYYMMDD); }
            }

            public string ParcPagaPlano4
            {
                get { return Row["ParcPagaPlano4"].ToString(); }
            }

            public string SinalVlrParc4
            {
                get { return Row["SinalVlrParc4"].ToString(); }
            }

            public decimal VlrParc4
            {
                get { return this.GetDecimal("VlrParc4"); }
            }

            public decimal PercTaxaAdmin4
            {
                get { return this.GetDecimal("PercTaxaAdmin4"); }
            }

            public string SinalVlrTaxaAdmin4
            {
                get { return Row["SinalVlrTaxaAdmin4"].ToString(); }
            }

            public decimal VlrTaxaAdmin4
            {
                get { return this.GetDecimal("VlrTaxaAdmin4"); }
            }

            public decimal PercTaxaFinan4
            {
                get { return this.GetDecimal("PercTaxaFinan4"); }
            }

            public string SinalVlrTaxaFinan4
            {
                get { return Row["SinalVlrTaxaFinan4"].ToString(); }
            }

            public decimal VlrTaxaFinan4
            {
                get { return this.GetDecimal("VlrTaxaFinan4"); }
            }

            public string SinalVlrLiqParc4
            {
                get { return Row["SinalVlrLiqParc4"].ToString(); }
            }

            public decimal VlrLiqParc4
            {
                get { return this.GetDecimal("VlrLiqParc4"); }
            }

            public string SinalDif1Parc2
            {
                get { return Row["SinalDif1Parc2"].ToString(); }
            }

            public decimal VlrDif1Parc2
            {
                get { return this.GetDecimal("VlrDif1Parc2"); }
            }

            public string SinalDif1Parc3
            {
                get { return Row["SinalDif1Parc3"].ToString(); }
            }

            public decimal VlrDif1Parc3
            {
                get { return this.GetDecimal("VlrDif1Parc3"); }
            }

            public string SinalDif1Parc4
            {
                get { return Row["SinalDif1Parc4"].ToString(); }
            }

            public decimal VlrDif1Parc4
            {
                get { return this.GetDecimal("VlrDif1Parc4"); }
            }

            public string Vago
            {
                get { return Row["Vago"].ToString(); }
            }

        }

        public class DesagendamentoRow : LayoutRow
        {

            public DesagendamentoRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Desagendamento";
            }

            public int TpRegistro
            {
                get { return this.GetInteger("TpRegistro"); }
            }

            public string LojaSubmissora
            {
                get { return Row["LojaSubmissora"].ToString(); }
            }

            public int TpLote
            {
                get { return this.GetInteger("TpLote"); }
            }

            public int NroLote
            {
                get { return this.GetInteger("NroLote"); }
            }

            public string NroCartaoHiper
            {
                get { return Row["NroCartaoHiper"].ToString(); }
            }

            public System.DateTime DtRemessa
            {
                get { return this.GetDate("DtRemessa", DateFormat.YYYYMMDD); }
            }

            public int QtdeParcelas
            {
                get { return this.GetInteger("QtdeParcelas"); }
            }

            public string NSU
            {
                get { return Row["NSU"].ToString(); }
            }

            public int NroLoteOrigem
            {
                get { return this.GetInteger("NroLoteOrigem"); }
            }

            public System.DateTime DtDebCred1
            {
                get { return this.GetDate("DtDebCred1", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrParc1
            {
                get { return Row["SinalVlrParc1"].ToString(); }
            }

            public decimal VlrParc1
            {
                get { return this.GetDecimal("VlrParc1"); }
            }

            public int NroParc1
            {
                get { return this.GetInteger("NroParc1"); }
            }

            public System.DateTime DtDebCred2
            {
                get { return this.GetDate("DtDebCred2", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrParc2
            {
                get { return Row["SinalVlrParc2"].ToString(); }
            }

            public decimal VlrParc2
            {
                get { return this.GetDecimal("VlrParc2"); }
            }

            public int NroParc2
            {
                get { return this.GetInteger("NroParc2"); }
            }

            public System.DateTime DtDebCred3
            {
                get { return this.GetDate("DtDebCred3", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrParc3
            {
                get { return Row["SinalVlrParc3"].ToString(); }
            }

            public decimal VlrParc3
            {
                get { return this.GetDecimal("VlrParc3"); }
            }

            public int NroParc3
            {
                get { return this.GetInteger("NroParc3"); }
            }

            public System.DateTime DtDebCred4
            {
                get { return this.GetDate("DtDebCred4", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrParc4
            {
                get { return Row["SinalVlrParc4"].ToString(); }
            }

            public decimal VlrParc4
            {
                get { return this.GetDecimal("VlrParc4"); }
            }

            public int NroParc4
            {
                get { return this.GetInteger("NroParc4"); }
            }

            public System.DateTime DtDebCred5
            {
                get { return this.GetDate("DtDebCred5", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrParc5
            {
                get { return Row["SinalVlrParc5"].ToString(); }
            }

            public decimal VlrParc5
            {
                get { return this.GetDecimal("VlrParc5"); }
            }

            public int NroParc5
            {
                get { return this.GetInteger("NroParc5"); }
            }

            public System.DateTime DtDebCred6
            {
                get { return this.GetDate("DtDebCred6", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrParc6
            {
                get { return Row["SinalVlrParc6"].ToString(); }
            }

            public decimal VlrParc6
            {
                get { return this.GetDecimal("VlrParc6"); }
            }

            public int NroParc6
            {
                get { return this.GetInteger("NroParc6"); }
            }

            public System.DateTime DtDebCred7
            {
                get { return this.GetDate("DtDebCred7", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrParc7
            {
                get { return Row["SinalVlrParc7"].ToString(); }
            }

            public decimal VlrParc7
            {
                get { return this.GetDecimal("VlrParc7"); }
            }

            public int NroParc7
            {
                get { return this.GetInteger("NroParc7"); }
            }

            public System.DateTime DtDebCred8
            {
                get { return this.GetDate("DtDebCred8", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrParc8
            {
                get { return Row["SinalVlrParc8"].ToString(); }
            }

            public decimal VlrParc8
            {
                get { return this.GetDecimal("VlrParc8"); }
            }

            public int NroParc8
            {
                get { return this.GetInteger("NroParc8"); }
            }

            public string Vago
            {
                get { return Row["Vago"].ToString(); }
            }

        }

        public class AjustesRow : LayoutRow
        {

            public AjustesRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Ajustes";
            }

            public int TpRegistro
            {
                get { return this.GetInteger("TpRegistro"); }
            }

            public string LojaSubmissora
            {
                get { return Row["LojaSubmissora"].ToString(); }
            }

            public int TpLote
            {
                get { return this.GetInteger("TpLote"); }
            }

            public int NroLote
            {
                get { return this.GetInteger("NroLote"); }
            }

            public string NroCartaoHiper
            {
                get { return Row["NroCartaoHiper"].ToString(); }
            }

            public System.DateTime DtProgDebCred
            {
                get { return this.GetDate("DtProgDebCred", DateFormat.YYYYMMDD); }
            }

            public System.DateTime DtDebCred
            {
                get { return this.GetDate("DtDebCred", DateFormat.YYYYMMDD); }
            }

            public System.DateTime DtRemessa
            {
                get { return this.GetDate("DtRemessa", DateFormat.YYYYMMDD); }
            }

            public string SinalVlrBrutoAjuste
            {
                get { return Row["SinalVlrBrutoAjuste"].ToString(); }
            }

            public decimal VlrBrutoAjuste
            {
                get { return this.GetDecimal("VlrBrutoAjuste"); }
            }

            public string SinalVlrLiqAjuste
            {
                get { return Row["SinalVlrLiqAjuste"].ToString(); }
            }

            public decimal VlrLiqAjuste
            {
                get { return this.GetDecimal("VlrLiqAjuste"); }
            }

            public int NroParcelas
            {
                get { return this.GetInteger("NroParcelas"); }
            }

            public int QtdeParcelas
            {
                get { return this.GetInteger("QtdeParcelas"); }
            }

            public string NSU
            {
                get { return Row["NSU"].ToString(); }
            }

            public string CodAjuste
            {
                get { return Row["CodAjuste"].ToString(); }
            }

            public string Descricao
            {
                get { return Row["Descricao"].ToString(); }
            }

            public string Comentario
            {
                get { return Row["Comentario"].ToString(); }
            }

            public int NroLoteOrigem
            {
                get { return this.GetInteger("NroLoteOrigem"); }
            }

            public string Vago
            {
                get { return Row["Vago"].ToString(); }
            }

        }

        public class TarifasRow : LayoutRow
        {

            public TarifasRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Tarifas";
            }

            public int TpRegistro
            {
                get { return this.GetInteger("TpRegistro"); }
            }

            public string LojaSubmissora
            {
                get { return Row["LojaSubmissora"].ToString(); }
            }

            public int TpLote
            {
                get { return this.GetInteger("TpLote"); }
            }

            public int NroLote
            {
                get { return this.GetInteger("NroLote"); }
            }

            public System.DateTime DtDebito
            {
                get { return this.GetDate("DtDebito", DateFormat.YYYYMMDD); }
            }

            public string PerReferencia
            {
                get { return Row["PerReferencia"].ToString(); }
            }

            public string SinalVlrTarifa
            {
                get { return Row["SinalVlrTarifa"].ToString(); }
            }

            public decimal VlrTarifa
            {
                get { return this.GetDecimal("VlrTarifa"); }
            }

            public string TpTarifa
            {
                get { return Row["TpTarifa"].ToString(); }
            }

            public string Vago
            {
                get { return Row["Vago"].ToString(); }
            }

        }

        public class TrailerRow : LayoutRow
        {

            public TrailerRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Trailer";
            }

            public int TpRegistro
            {
                get { return this.GetInteger("TpRegistro"); }
            }

            public long TotTransacoes
            {
                get { return this.GetLong("TotTransacoes"); }
            }

            public string Vago
            {
                get { return Row["Vago"].ToString(); }
            }

        }

        #endregion

    }
}