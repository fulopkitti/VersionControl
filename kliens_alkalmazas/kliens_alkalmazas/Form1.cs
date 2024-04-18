using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Orders;
using Hotcakes.CommerceDTO.v1.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetNuke.Common.Utilities;
using DotNetNuke.UI.UserControls;
using Newtonsoft.Json.Linq;
using Hotcakes.Web;
using Newtonsoft.Json;



namespace kliens_alkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://20.234.113.211:8081";
            string kulcs = "1-96b39a7e-b4d5-4e33-ab50-b2176bfb9844";

            Api proxy = new Api(url, kulcs);
            var s = proxy.CustomerAccountsCountOfAll().Content;
            string kiirom = s.ToString();
            textBox1.Text = kiirom;



            var response = proxy.CustomerAccountsFindAll();

            JObject jResponse = JObject.Parse(response.ObjectToJson());
            JArray jArray = (JArray)jResponse["Content"];

            string[] keysToRemove = { "Password", "Addresses", "Notes", "TaxExempt", "PricingGroupId", "FailedLoginCount", "LastUpdatedUtc", "ShippingAddress", "BillingAddress" };
            foreach (JObject felhasznalo in jArray)
            {
                foreach (var key in keysToRemove.ToList())
                {
                    felhasznalo.Remove(key);
                }
            }

            DataTable userTabla = (DataTable)JsonConvert.DeserializeObject(jArray.ToString(), typeof(DataTable));
            dataGridView1.DataSource = userTabla;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            authentication azon = new authentication();
            azon.Show();
        }
    }
}
