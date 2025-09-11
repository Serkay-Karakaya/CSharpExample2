using CSharpEgitim301.BusinessLayer.Abstract;
using CSharpEgitim301.BusinessLayer.Concrete;
using CSharpEgitim301.DataAccessLayer.EntityFramework;
using CSharpEgitim301.EntityLayer.Concrete;
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
        private readonly ICategoryService _categoryService;
        public frmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            var productValues = _productService.TGetAll();
            dataGridView1.DataSource = productValues;
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            dataGridView1.DataSource = value;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            value.ProductName = txtProductName.Text;
            value.ProductStock = int.Parse(txtProductStock.Text);
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductDescription = txtDescription.Text;
            value.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            _productService.TUpdate(value);
            MessageBox.Show("Ürün Güncellendi");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName = txtProductName.Text;
            product.ProductStock = int.Parse(txtProductStock.Text);
            product.ProductPrice = decimal.Parse(txtProductPrice.Text);
            product.ProductDescription = txtDescription.Text;
            product.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            _productService.TInsert(product);
            MessageBox.Show("Ürün Eklendi");
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            cmbCategory.DataSource = values;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }
    }
}
