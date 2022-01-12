using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemasVentas.Mantenimiento;
using MiLibreria;

namespace SistemasVentas
{
    public partial class MantenimientoProducto : Mantenimiento
    {
        public MantenimientoProducto()
        {
            InitializeComponent();
            //IsMdiContainer = true;
        }

        public override Boolean Guardar()
        {
           if (Utilidades.ValidarFormulario(this, errorProvider1) == false)
            {
                try
                {
                    string cmd = string.Format("EXEC ActualizaArticulos '{0}','{1}','{2}'", txtIdProducto.Text.Trim(), txtNomProducto.Text.Trim(), txtPrecio.Text.Trim());
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("Se ha Guardado Correctamente");
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha Ocurrido un error:" + error.Message);
                    return false;
                }
            }
           else
            {
                return false;
            }
        }

        public override void Eliminar()
        {
            try
            {
                string cmd = string.Format("EXEC EliminarArticulos '{0}'", txtIdProducto.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se ha Elminado");
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error:" + error.Message); 
            }
        }

        private void MantenimientoProducto_Load(object sender, EventArgs e)
        {
            
        }

        private void txtIdProducto_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
