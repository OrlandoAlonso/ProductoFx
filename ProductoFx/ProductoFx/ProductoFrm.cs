using ProductoFx.model;
using ProductoFx.pojo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductoFx
{
    public partial class ProductoFrm : Form
    {
        private MainFrm mainFrm;
        private Producto producto;
        private bool validate1;
        private int index;
        public ProductoFrm(bool validate, MainFrm frameMain, int indice)
        {
            InitializeComponent();
            mainFrm = frameMain;
            validate1 = validate;
            index = indice;
            if (validate)
            {
                producto = mainFrm.productoModel.SearchById(indice);
                txtName.Text = producto.nombre;
                txtCant.Text = "" + producto.noExistencia;
                txtMarca.Text = producto.marca;
                txtModel.Text = producto.modelo;
                txtPrice.Text = "" + producto.precio;
                txtDescp.Text = producto.descripcion;
                txtImage.Text = producto.imagePath;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImage.Text = ofd.FileName;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que ya no desea agregar mas productos?", "Mensaje de informacion", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
            return;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtName.Text) || String.IsNullOrWhiteSpace(txtCant.Text)
                || String.IsNullOrWhiteSpace(txtMarca.Text) || String.IsNullOrWhiteSpace(txtModel.Text)
                || String.IsNullOrWhiteSpace(txtPrice.Text) || String.IsNullOrWhiteSpace(txtDescp.Text)
                || String.IsNullOrWhiteSpace(txtImage.Text))
            {
                MessageBox.Show("No puede haber campos vacios!");
                return;
            }

            string name = txtName.Text, marca = txtMarca.Text, modelo = txtModel.Text, descipcion = txtDescp.Text, image = txtImage.Text;
            int.TryParse(txtCant.Text, out int cantidad);
            Random random = new Random();
            int count = random.Next(0, 100);
            decimal.TryParse(txtPrice.Text, out decimal precio);

            if (validate1)
            {
                Producto producto = mainFrm.productoModel.SearchById(index);
                producto.nombre = name;
                producto.noExistencia = cantidad;
                producto.marca = marca;
                producto.modelo = modelo;
                producto.precio = precio;
                producto.descripcion = descipcion;
                producto.imagePath = image;
            }
            else
            {
                Producto producto = new Producto()
                {
                    id = count++,
                    nombre = name,
                    noExistencia = cantidad,
                    marca = marca,
                    modelo = modelo,
                    precio = precio,
                    descripcion = descipcion,
                    imagePath = image
                };

                mainFrm.productoModel.AddElement(producto);

                MessageBox.Show("Producto guardado satisfactoriamente!");
            }

            clearDataTxt();
        }

        private void clearDataTxt()
        {
            txtName.Text = "";
            txtCant.Text = "";
            txtMarca.Text = "";
            txtModel.Text = "";
            txtPrice.Text = "";
            txtDescp.Text = "";
            txtImage.Text = "";
        }
    }
}
