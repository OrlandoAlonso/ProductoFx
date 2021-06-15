using ProductoFx.pojo;
using ProductoFx.UsingControl;
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
    public partial class FrmViewProducto : Form
    {
        private MainFrm mainFrm;
        private List<string> valueControlProductos;
        private List<ControlProducto> controlProductos;
        private string value;
        private string[] imagePaths;

        public FrmViewProducto(MainFrm mainFrm1)
        {
            InitializeComponent();
            mainFrm = mainFrm1;
            valueControlProductos = new List<string>();
            controlProductos = new List<ControlProducto>();
            loadProductos();
        }

        private void loadProductos()
        {
            Producto[] productos = mainFrm.productoModel.GetAll();
            imagePaths = new string[productos.Length];
            int i = 0;
            foreach(Producto p in productos)
            {
                value = "Nombre: " + p.nombre + Environment.NewLine + "No. Existencia: " + p.noExistencia + Environment.NewLine + 
                    "Marca: " + p.marca + Environment.NewLine + "Modelo: " +  p.modelo + Environment.NewLine +  
                    "Precio: " + p.precio + Environment.NewLine + "Descripcion: " + p.descripcion;
                imagePaths[i] = p.imagePath;
                valueControlProductos.Add(value);
                i++;
            }
            i = 0;
            foreach(string v in valueControlProductos)
            {
                ControlProducto control = new ControlProducto()
                {
                    ImageFile = imagePaths[i],
                    Description = v
                };
                controlProductos.Add(control);
                i++;
            }
            foreach(ControlProducto item in controlProductos)
            {
                flowLayoutPanel1.Controls.Add(item);
            }
        }
    }
}
