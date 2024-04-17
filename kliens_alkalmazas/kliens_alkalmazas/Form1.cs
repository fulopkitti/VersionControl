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
            string url = "http://20.234.113.211:8081";
            string key = "1-96b39a7e-b4d5-4e33-ab50-b2176bfb9844";

            Api proxy = new Api(url, key);
            var s = proxy.CustomerAccountsCountOfAll().Content;
            string kiirom = s.ToString();
            textBox1.Text = kiirom;



            var response = proxy.CustomerAccountsFindAll();

            JObject jResponse = JObject.Parse(response.ObjectToJson());
            JArray jArray = (JArray)jResponse["Content"];

            string[] keysToRemove = { "Password", "Addressess", "TaxExempt", "Notes", "PricingGroupId", "FailedLoginCount", "LastUpdatedUtc", "ShippingAddress", "Bvin", "LastUpdatedUtc", "StoreId", "NickName", "FirstName", "MiddleInitial", "LastName", "Company", "Line1", "Line2", "Line3", "City", "RegionName", "RegionBvin", "PostalCode", "CountryName", "CountryBvin", "Phone", "Fax", "WebSiteUrl", "CountyName", "CountyBvin", "UserBvin", "AddressType", "BillingAddress", "Bvin", "LastUpdatedUtc", "StoreId", "NickName", "FirstName", "MiddleInitial", "LastName", "Company", "Line1", "Line2", "Line3", "City", "RegionName", "RegionBvin", "PostalCode", "CountryName", "CountryBvin", "Phone", "Fax", "WebSiteUrl", "CountyName", "CountyBvin", "UserBvin", "AddressType" };
            foreach (JObject felhasznalo in jArray)
            {
                foreach (var keys in keysToRemove.ToList())
                {
                    felhasznalo.Remove(key);
                }
            }

            DataTable userTabla = (DataTable)JsonConvert.DeserializeObject(jArray.ToString(), typeof(DataTable));
            dataGridView1.DataSource = userTabla;
        }
    }
}
