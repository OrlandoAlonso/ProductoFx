using ProductoFx.pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoFx.model
{
    public class ProductoModel
    {
        private Producto[] productos;

        public ProductoModel() { }

        public void AddElement(Producto producto)
        {
            if (productos == null)
            {
                productos = new Producto[1];
                productos[0] = producto;
                return;
            }

            Producto[] temporal = new Producto[productos.Length + 1];
            Array.Copy(productos, temporal, productos.Length);
            temporal[temporal.Length - 1] = producto;

            productos = temporal;
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                return;
            }

            if (productos == null)
            {
                return;
            }

            if (index >= productos.Length)
            {
                throw new IndexOutOfRangeException($"El indice: '{index}' esta fuera de rango!");
            }

            if (index == 0 && productos.Length == 1)
            {
                productos = null;
                return;
            }

            Producto[] temp = new Producto[productos.Length - 1];
            if (index == 0)
            {
                Array.Copy(productos, index + 1, temp, 0, temp.Length);
                productos = temp;
                return;
            }

            if (index == productos.Length - 1)
            {
                Array.Copy(productos, 0, temp, 0, temp.Length);
                productos = temp;
                return;
            }

            Array.Copy(productos, 0, temp, 0, index);
            Array.Copy(productos, index + 1, temp, index, (temp.Length - index));
            productos = temp;
        }

        public Producto[] GetAll()
        {
            return productos;
        }

        public Producto SearchById(int index)
        {
            Producto temp = new Producto();
            foreach(Producto p in productos)
            {
                if(p.id == index)
                {
                    temp = p;
                    break;
                }
            }

            return temp;
        }
    }
}
