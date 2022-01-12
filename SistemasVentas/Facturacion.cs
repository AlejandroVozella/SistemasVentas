using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemasVentas.Procesos;
using MiLibreria;

namespace SistemasVentas
{
    public partial class Facturacion : Procesos
    {
        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            string cmd = "Select * from Usuarios where id_usuario=" + VentanaLogin.Codigo;

            DataSet ds;

            ds = Utilidades.Ejecutar(cmd);

            lblAtiende.Text = ds.Tables[0].Rows[0]["Nom_usu"].ToString().Trim();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoCli.Text.Trim()) == false)
            {

                try
                {
                    string cmd = string.Format("Select  Nom_cli from Cliente where id_clientes='{0}' ", txtCodigoCli.Text.Trim());

                    DataSet ds = Utilidades.Ejecutar(cmd);

                    txtCliente.Text = ds.Tables[0].Rows[0]["Nom_cli"].ToString().Trim();

                    txtCodigoPro.Focus();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha Ocurrido un error:" + error.Message);
                }
                
            }
        }
    }
}
