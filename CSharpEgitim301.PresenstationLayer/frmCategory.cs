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
    public partial class frmCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public frmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = rdbActive.Checked;
            _categoryService.TInsert(category);
            MessageBox.Show("Kategori eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var deletedValues= _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Kategori silindi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var categoryValues = _categoryService.TGetById(id);
            dataGridView1.DataSource = categoryValues;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedId = int.Parse(txtCategoryId.Text);
            var updatedValues = _categoryService.TGetById(updatedId);
            updatedValues.CategoryName = txtCategoryName.Text;
            updatedValues.CategoryStatus = true;
            _categoryService.TUpdate(updatedValues);
            MessageBox.Show("Kategori güncellendi");
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
          
        }
    }
}
