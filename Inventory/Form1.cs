using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Inventory
{
    public partial class Form1 : Form
    {
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;
        BindingSource showProductList;
        public Form1()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = { "Beverages", "Bread/Bakery", "Canned/Jarred Goods",
                "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" 
            };

            foreach (string x in ListOfProductCategory)
            {
                cbCategory.Items.Add(x);
            }

            cbCategory.SelectedIndex = 0;

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,

                _ExpDate, _SellPrice, _Quantity, _Description)); gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; gridViewProductList.DataSource = showProductList;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    throw new StringFormatException("Invalid Product Name!");
                }

                
            }
            catch (StringFormatException sfe)
            {
                MessageBox.Show(sfe.Message);
            }
            return name;
        }
        public int Quantity(string qty)
        {
            try
            {
                if (!Regex.IsMatch(qty, @"^[0-9]"))
                {
                    throw new NumberFormatException("Invalid Product Quantity!");
                }

               
            }
            catch (NumberFormatException nfe)
            {
                MessageBox.Show(nfe.Message);
            }
            return Convert.ToInt32(qty);

        }
        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    throw new CurrencyFormatException("Invalid currency!");
                }

            }
            catch (CurrencyFormatException cfe)
            {
                MessageBox.Show(cfe.Message);
            }
                return Convert.ToDouble(price);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
