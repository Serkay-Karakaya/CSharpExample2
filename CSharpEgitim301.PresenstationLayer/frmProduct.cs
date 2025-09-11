using CSharpEgitim301.BusinessLayer.Abstract;
using CSharpEgitim301.BusinessLayer.Concrete;
using CSharpEgitim301.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitim301.PresenstationLayer
{
    public partial class frmProduct : Form
    {
        private readonly IProductService _productService;
        public frmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            var productValues = _productService.TGetAll();
            dataGridView1.DataSource = productValues;
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {

        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var value = _productService.TGetProductByCategory();
            dataGridView1.DataSource = value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            MessageBox.Show("Ürün Silindi");
        }
    }
}
