using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace kliens_alkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string url = "http://20.234.113.211:8081/en-us/";
            string key = "1-96b39a7e-b4d5-4e33-ab50-b2176bfb9844";

            Api proxy = new Api(url, key);

            // specify the order to look for
            var orderId = "ad66e293-9afa-4470-a233-b7c9b2bf61f0";

            // call the API to find the order
            ApiResponse<OrderDTO> response = proxy.OrdersFind(orderId);

        }
    }
}
