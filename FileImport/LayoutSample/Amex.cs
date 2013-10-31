using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FileImport.Base;
using FileImport.Common;

namespace FileImport.LayoutSample
{
    public class Amex : ImportAttributes
    {
        #region "Methods"
        public Amex():base(ImportEncodingType.UTF8, ImportType.Delimited, ",")
        {         
            //AMEX layout is delimited so it's not necessary define the layout
            //All the columns are stored internally using "System.Data.DataColumn"
            //and the columns are named as "Col_1", "Col_2", ... "Col_N"
        }
        #endregion

        #region "Enum"
        public enum TipoRegistro
        {
            Header = 0,
            Pagamento = 1,
            SOC = 3,
            ROC = 4,
            Ajustes = 5,
            Pricing = 6,
            Trailer = 9
        }
        #endregion

        #region "Rows"
        public List<Amex.HeaderRow> HeaderRows = new List<Amex.HeaderRow>();
        public List<Amex.PagamentoRow> PagamentoRows = new List<Amex.PagamentoRow>();
        public List<Amex.SOCRow> SOCRows = new List<Amex.SOCRow>();
        public List<Amex.ROCRow> ROCRows = new List<Amex.ROCRow>();
        public List<Amex.AjustesRow> AjustesRows = new List<Amex.AjustesRow>();
        public List<Amex.TrailerRow> TrailerRows = new List<Amex.TrailerRow>();
        
        public class HeaderRow : LayoutRow
        {
            public HeaderRow(DataRow Row): base(Row)
            {
                this.Record = "Header";
            }

            public string EE_REGISTRO_CABECALHO 
            { 
                get { return ""; } 
            }

            public string EE_CA_CHAVE_IND
            { 
                get { return ""; } 
            }

            public string EE_CA_NUM_EC_PAGTO
            {
                get { return Row["Col_1"].ToString(); }
            }

            public string EE_CA_RESERVADO_1
            {
                get { return Row["Col_2"].ToString(); }
            }

            public int EE_CA_RESERVADO_2
            {
                get { return GetInteger("Col_3"); }
            }

            public string EE_CA_RESERVADO_3
            {
                get { return Row["Col_4"].ToString(); }
            }

            public int EE_CA_RESERVADO_4
            {
                get { return GetInteger("Col_5"); }
            }

            public int EE_CA_TIPO_REGISTRO
            {
                get { return GetInteger("Col_6"); }
            }

            public string EE_CA_RESERVADO_5
            {
                get { return Row["Col_7"].ToString(); }
            }

            public DateTime EE_CA_DATA_ARQUIVO
            {
                get { return GetDate("Col_8", DateFormat.CCYYMMDD); }
            }

            public string EE_CA_HORA_ARQUIVO
            {
                get { return Row["Col_9"].ToString(); }
            }

            public int EE_CA_NUM_ARQUIVO
            {
                get { return GetInteger("Col_10"); }
            }

            public string EE_CA_NOME_ARQUIVO
            {
                get { return Row["Col_11"].ToString(); }
            }           

        }

        public class PagamentoRow : LayoutRow
        {

            public PagamentoRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Pagamento";
            }

            public string EE_REGISTRO_PAGAMENTO
            {
                get { return ""; }
            }

            public string EE_PG_CHAVE_IND
            {
                get { return ""; }
            }

            public string EE_PG_NUM_EC_PAGTO
            {
                get { return Row["Col_1"].ToString(); }
            }

            public System.DateTime EE_PG_DATA_PAGTO
            {
                get { return GetDate("Col_2", DateFormat.CCYYMMDD); }
            }

            public int EE_PG_SEQ_PAGTO
            {
                get { return GetInteger("Col_3"); }
            }

            public string EE_PG_RESERVADO_1
            {
                get { return Row["Col_4"].ToString(); }
            }

            public int EE_PG_RESERVADO_2
            {
                get { return GetInteger("Col_5"); }
            }

            public int EE_PG_TIPO_REGISTRO
            {
                get { return GetInteger("Col_6"); }
            }

            public int EE_PG_RESERVADO_3
            {
                get { return GetInteger("Col_7"); }
            }

            public decimal EE_PG_VLR_PAGTO
            {
                get { return GetDecimal("Col_8"); }
            }

            public string EE_PG_COD_BANCO
            {
                get { return Row["Col_9"].ToString(); }
            }

            public string EE_PG_COD_AGENCIA
            {
                get { return Row["Col_10"].ToString(); }
            }

            public string EE_PG_NUM_CONTA
            {
                get { return Row["Col_11"].ToString(); }
            }

            public string EE_PG_NOME_EC
            {
                get { return Row["Col_12"].ToString(); }
            }

            public string EE_PG_COD_MOEDA
            {
                get { return Row["Col_13"].ToString(); }
            }

            public decimal EE_PG_DEBIT_ANTERIOR
            {
                get { return GetDecimal("Col_14"); }
            }

            public decimal EE_PG_VLR_BRUTO
            {
                get { return GetDecimal("Col_15"); }
            }

            public decimal EE_PG_VLR_DESCONTO
            {
                get { return GetDecimal("Col_16"); }
            }

            public decimal EE_PG_RESERVADO_4
            {
                get { return GetDecimal("Col_17"); }
            }

            public decimal EE_PG_ENCARGOS_ANTECIP
            {
                get { return GetDecimal("Col_18"); }
            }

            public decimal EE_PG_VLR_LIQUIDO
            {
                get { return GetDecimal("Col_19"); }
            }

            public string EE_PG_LANCAMENTO
            {
                get { return Row["Col_20"].ToString(); }
            }

        }

        public class SOCRow : LayoutRow
        {

            public SOCRow(DataRow Row)
                : base(Row)
            {
                this.Record = "SOC";
            }

            public string EE_RESUMO_OPERACAO
            {
                get { return ""; }
            }

            public string EE_RO_CHAVE_IND
            {
                get { return ""; }
            }

            public string EE_RO_NUM_EC_PAGTO
            {
                get { return Row["Col_1"].ToString(); }
            }

            public System.DateTime EE_RO_DATA_PAGTO
            {
                get { return GetDate("Col_2", DateFormat.CCYYMMDD); }
            }

            public int EE_RO_SEQ_PAGTO
            {
                get { return GetInteger("Col_3"); }
            }

            public string EE_RO_NUM_EC_SUBM
            {
                get { return Row["Col_4"].ToString(); }
            }

            public int EE_RO_NUM_SEQUENCIAL
            {
                get { return GetInteger("Col_5"); }
            }

            public int EE_RO_TIPO_REGISTRO
            {
                get { return GetInteger("Col_6"); }
            }

            public int EE_RO_RESERVADO_1
            {
                get { return GetInteger("Col_7"); }
            }

            public System.DateTime EE_RO_DATA_SUBM
            {
                get { return GetDate("Col_8", DateFormat.CCYYMMDD); }
            }

            public string EE_RO_NUM_REFERENCIA
            {
                get { return Row["Col_9"].ToString(); }
            }

            public decimal EE_RO_VLR_TOTAL
            {
                get { return GetDecimal("Col_10"); }
            }

            public decimal EE_RO_VLR_BRUTO
            {
                get { return GetDecimal("Col_11"); }
            }

            public decimal EE_RO_VLR_DESCONTO
            {
                get { return GetDecimal("Col_12"); }
            }

            public decimal EE_RO_RESERVADO_2
            {
                get { return GetDecimal("Col_13"); }
            }

            public decimal EE_RO_RESERVADO_3
            {
                get { return GetDecimal("Col_14"); }
            }

            public decimal EE_RO_VLR_LIQUIDO
            {
                get { return GetDecimal("Col_15"); }
            }

            public int EE_RO_QTD_CV
            {
                get { return GetInteger("Col_16"); }
            }

            public string EE_RO_COD_MOEDA
            {
                get { return Row["Col_17"].ToString(); }
            }

            public decimal EE_RO_RESERVADO_4
            {
                get { return GetDecimal("Col_18"); }
            }

            public int EE_RO_NUM_PARCELA
            {
                get { return GetInteger("Col_19"); }
            }

            public int EE_RO_NUM_ANTECIPACAO
            {
                get { return GetInteger("Col_20"); }
            }

            public System.DateTime EE_RO_DATA_ORIGINAL
            {
                get { return GetDate("Col_21", DateFormat.CCYYMMDD); }
            }

            public System.DateTime EE_RO_DATA_ANTECIPADO
            {
                get { return GetDate("Col_22", DateFormat.CCYYMMDD); }
            }

            public int EE_RO_DIAS_ANTECIPADOS
            {
                get { return GetInteger("Col_23"); }
            }

            public decimal EE_RO_ENC_ANTECIPACAO
            {
                get { return GetDecimal("Col_24"); }
            }

            public decimal EE_RO_VLR_ORIGINAL
            {
                get { return GetDecimal("Col_25"); }
            }

            public decimal EE_RO_VLR_DEBITO
            {
                get { return GetDecimal("Col_26"); }
            }

            public decimal EE_RO_VLR_CREDITO
            {
                get { return GetDecimal("Col_27"); }
            }

        }

        public class ROCRow : LayoutRow
        {

            public ROCRow(DataRow Row)
                : base(Row)
            {
                this.Record = "ROC";
            }

            public string EE_COMPROVANTE_DE_VENDA
            {
                get { return ""; }
            }

            public string EE_CV_CHAVE_IND
            {
                get { return ""; }
            }

            public string EE_CV_NUM_EC_PAGTO
            {
                get { return Row["Col_1"].ToString(); }
            }

            public System.DateTime EE_CV_DATA_PAGTO
            {
                get { return GetDate("Col_2", DateFormat.CCYYMMDD); }
            }

            public int EE_CV_SEQ_PAGTO
            {
                get { return GetInteger("Col_3"); }
            }

            public string EE_CV_NUM_EC_SUBM
            {
                get { return Row["Col_4"].ToString(); }
            }

            public int EE_CV_NUM_SEQUENCIAL
            {
                get { return GetInteger("Col_5"); }
            }

            public int EE_CV_TIPO_REGISTRO
            {
                get { return GetInteger("Col_6"); }
            }

            public int EE_CV_RESERVADO_1
            {
                get { return GetInteger("Col_7"); }
            }

            public System.DateTime EE_CV_DATA_VENDA
            {
                get { return GetDate("Col_8", DateFormat.CCYYMMDD); }
            }

            public string EE_CV_NSU
            {
                get { return Row["Col_9"].ToString(); }
            }

            public string EE_CV_COD_AUTORIZACAO
            {
                get { return Row["Col_10"].ToString(); }
            }

            public string EE_CV_NUM_CARTAO
            {
                get { return Row["Col_11"].ToString(); }
            }

            public decimal EE_CV_VLR_VENDA
            {
                get { return GetDecimal("Col_12"); }
            }

            public decimal EE_CV_VLR_PARCELA_PRI
            {
                get { return GetDecimal("Col_13"); }
            }

            public decimal EE_CV_VLR_PARCELA_N
            {
                get { return GetDecimal("Col_14"); }
            }

            public int EE_CV_QTD_PARCELAS
            {
                get { return GetInteger("Col_15"); }
            }

            public int EE_CV_NUM_PARCELA
            {
                get { return GetInteger("Col_16"); }
            }

            public int EE_CV_COD_REJEICAO
            {
                get { return GetInteger("Col_17"); }
            }

            public string EE_CV_DSC_REJEICAO
            {
                get { return Row["Col_18"].ToString(); }
            }

            public string EE_CV_NSU_REF_1
            {
                get { return Row["Col_19"].ToString(); }
            }

            public string EE_CV_NUM_BILHETE
            {
                get { return Row["Col_20"].ToString(); }
            }

            public string EE_CV_NSU_REF_2
            {
                get { return Row["Col_21"].ToString(); }
            }

        }

        public class AjustesRow : LayoutRow
        {

            public AjustesRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Ajustes";
            }

            public string EE_REGISTRO_AJUSTE
            {
                get { return ""; }
            }

            public string EE_AJ_CHAVE_IND
            {
                get { return ""; }
            }

            public string EE_AJ_NUM_EC_PAGTO
            {
                get { return Row["Col_1"].ToString(); }
            }

            public System.DateTime EE_AJ_DATA_PAGTO
            {
                get { return GetDate("Col_2", DateFormat.CCYYMMDD); }
            }

            public int EE_AJ_SEQ_PAGTO
            {
                get { return GetInteger("Col_3"); }
            }

            public string EE_AJ_NUM_EC_SUBM
            {
                get { return Row["Col_4"].ToString(); }
            }

            public int EE_AJ_NUM_SEQUENCIAL
            {
                get { return GetInteger("Col_5"); }
            }

            public int EE_AJ_TIPO_REGISTRO
            {
                get { return GetInteger("Col_6"); }
            }

            public int EE_AJ_RESERVADO_1
            {
                get { return GetInteger("Col_7"); }
            }

            public string EE_AJ_NUM_REFERENCIA
            {
                get { return Row["Col_8"].ToString(); }
            }

            public decimal EE_AJ_VLR_BRUTO
            {
                get { return GetDecimal("Col_9"); }
            }

            public decimal EE_AJ_VLR_DESCONTO
            {
                get { return GetDecimal("Col_10"); }
            }

            public decimal EE_AJ_RESERVADO_2
            {
                get { return GetDecimal("Col_11"); }
            }

            public decimal EE_AJ_VLR_SERVICO
            {
                get { return GetDecimal("Col_12"); }
            }

            public decimal EE_AJ_VLR_LIQUIDO
            {
                get { return GetDecimal("Col_13"); }
            }

            public string EE_AJ_NUM_CARTAO
            {
                get { return Row["Col_14"].ToString(); }
            }

            public string EE_AJ_CODIGO
            {
                get { return Row["Col_15"].ToString(); }
            }

            public string EE_AJ_DESCRICAO
            {
                get { return Row["Col_16"].ToString(); }
            }

            public string EE_AJ_COD_MOEDA
            {
                get { return Row["Col_17"].ToString(); }
            }

            public string EE_AJ_NUM_ANTECIPACAO
            {
                get { return GetInteger("Col_18").ToString(); }
            }

            public decimal EE_AJ_VLR_CREDITO
            {
                get { return GetDecimal("Col_19"); }
            }

            public decimal EE_AJ_VLR_DEBITO
            {
                get { return GetDecimal("Col_20"); }
            }

            public string EE_AJ_CBK_NUM_EC_SUBM
            {
                get { return Row["Col_21"].ToString(); }
            }

            public decimal EE_AJ_CBK_VLR_ORIGINAL
            {
                get { return GetDecimal("Col_22"); }
            }

            public System.DateTime EE_AJ_CBK_DATA_ORIGINAL
            {
                get { return GetDate("Col_23", DateFormat.CCYYMMDD); }
            }

            public string EE_AJ_CBK_NSU_ORIGINAL
            {
                get { return Row["Col_24"].ToString(); }
            }

            public string EE_AJ_CBK_NSU_REF_2
            {
                get { return Row["Col_25"].ToString(); }
            }

            public string EE_AJ_CBK_NSU_REF_1
            {
                get { return Row["Col_26"].ToString(); }
            }

            public string EE_AJ_CBK_BILHETE_ORIGINAL
            {
                get { return Row["Col_27"].ToString(); }
            }

            public int EE_AJ_QTD_PARCELAS
            {
                get { return GetInteger("Col_28"); }
            }
            
        }

        public class TrailerRow : LayoutRow
        {

            public TrailerRow(DataRow Row)
                : base(Row)
            {
                this.Record = "Trailer";
            }

            public string EE_REGISTRO_RODAPE
            {
                get { return ""; }
            }

            public string EE_RP_CHAVE_IND
            {
                get { return ""; }
            }

            public string EE_RP_NUM_EC_PAGTO
            {
                get { return Row["Col_1"].ToString(); }
            }

            public System.DateTime EE_RP_RESERVADO_1
            {
                get { return GetDate("Col_2", DateFormat.CCYYMMDD); }
            }

            public int EE_RP_RESERVADO_2
            {
                get { return GetInteger("Col_3"); }
            }

            public string EE_RP_RESERVADO_3
            {
                get { return Row["Col_4"].ToString(); }
            }

            public int EE_RP_RESERVADO_4
            {
                get { return GetInteger("Col_5"); }
            }

            public int EE_RP_TIPO_REGISTRO
            {
                get { return GetInteger("Col_6"); }
            }

            public int EE_RP_RESERVADO_5
            {
                get { return GetInteger("Col_7"); }
            }

            public System.DateTime EE_RP_DATA_ARQUIVO
            {
                get { return GetDate("Col_8", DateFormat.CCYYMMDD); }
            }

            public string EE_RP_HORA_ARQUIVO
            {
                get { return Row["Col_9"].ToString(); }
            }

            public string EE_RP_NUM_ARQUIVO
            {
                get { return Row["Col_10"].ToString(); }
            }

            public string EE_RP_NOME_ARQUIVO
            {
                get { return Row["Col_11"].ToString(); }
            }

            public string EE_RP_VERSAO_ARQUIVO
            {
                get { return Row["Col_12"].ToString(); }
            }

            public int EE_RP_QTD_REGISTROS
            {
                get { return GetInteger("Col_13"); }
            }

        }
        #endregion

    }

}
