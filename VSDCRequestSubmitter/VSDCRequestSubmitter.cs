using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSDCRequestSubmitter.Models;
using VSDCRequestSubmitter.Proxies;

namespace VSDCRequestSubmitter
{
    public partial class VSDCRequestSubmitter : Form
    {
        InvoiceRequest invoiceRequest;
        public VSDCRequestSubmitter()
        {
            InitializeComponent();

            txtVSDCAddress.Text = Properties.Settings.Default.VSDCTargerAddress;

            txtCertificateName.Text = Properties.Settings.Default.CertificateName;

            invoiceRequest = JsonConvert.DeserializeObject<InvoiceRequest>("{ \"IT\": \"Normal\", \"TT\": \"Sale\", \"PaymentType\": \"Cash\", \"PAC\": \"REPLACE WITH PAC CODE RECEIVED WITH POS PFX FILE!!!!\", \"Items\": [{\"Name\": \"Network Cable\", \"Quantity\": 1,\"UnitPrice\":100.87, \"Labels\":[\"A\"], \"TotalAmount\": 100.87 }]}");

            txtRequest.Text = JsonConvert.SerializeObject(invoiceRequest, Formatting.Indented);
        }

        private void btnSubmittRequest_Click(object sender, EventArgs e)
        {
            VSDCApiProxy proxy = new VSDCApiProxy(txtVSDCAddress.Text, txtCertificateName.Text);

            Directory.CreateDirectory($"{Path.GetDirectoryName(Application.ExecutablePath)}\\Result");

            File.WriteAllText($"{Path.GetDirectoryName(Application.ExecutablePath)}\\Result\\Response.Json", proxy.ExecuteRequest(JsonConvert.DeserializeObject<InvoiceRequest>(txtRequest.Text)));

            MessageBox.Show($"Signing was successful, find signing result at: {$"{Path.GetDirectoryName(Application.ExecutablePath)}\\Result"}");
        }
    }
}
