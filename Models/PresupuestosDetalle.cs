using System;
using Productos;

namespace PresupuestosDetalle
{
    public class PresupuestoDetalle
    {
        private Producto producto;
        private int cantidad;

        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        PresupuestoDetalle()
        {

        }

        PresupuestoDetalle(Producto prod, int cant)
        {
            this.producto = prod;
            this.cantidad = cant;
        }
    }
}