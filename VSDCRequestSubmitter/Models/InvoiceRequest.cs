using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSDCRequestSubmitter.Models
{
    public class InvoiceRequest
    {
        #region Header

        public DateTime? DateAndTimeOfIssue { get; set; }

        public string Cashier { get; set; }

        public string BD { get; set; }

        public string BuyerCostCenterId { get; set; }

        public InvoiceType? IT { get; set; }

        public TransactionType? TT { get; set; }

        public PaymentType? PaymentType { get; set; }

        public string InvoiceNumber { get; set; }

        public string ReferentDocumentNumber { get; set; }

        public string PAC { get; set; }


        #endregion

        #region Items

        public List<Item> Items { get; set; } = new List<Item>();

        #endregion
    }

    public enum InvoiceType
    {
        Normal,

        ProForma,

        Copy,

        Training
    }

    public enum TransactionType
    {
        Sale,

        Refund
    }

    public enum PaymentType
    {
        Other,

        Cash,

        Card,

        Check,

        WireTransfer,

        Voucher,

        MobileMoney
    }

    public class Item
    {
        public string GTIN { get; set; }

        public string Name { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Discount { get; set; }

        public List<char> Labels { get; set; }

        public decimal? UnitPrice { get; set; }
      
        public decimal? TotalAmount { get; set; }
     
    }
}