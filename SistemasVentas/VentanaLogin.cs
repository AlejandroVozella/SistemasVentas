using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MiLibreria;

namespace SistemasVentas
{
    public partial class VentanaLogin : Form
    {
        public VentanaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("Select * FROM Usuarios WHERE account='{0}'AND password='{1}'", txtNomAcc.Text.Trim(), txtPass.Text.Trim());

                DataSet ds = Utilidades.Ejecutar(CMD);

                string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim();
                string contra= ds.Tables[0].Rows[0]["password"].ToString().Trim();

                if (cuenta == txtNomAcc.Text.Trim() && contra==txtPass.Text.Trim() )
                {
                    if (cuenta== txtNomAcc.Text.Trim() && contra == txtPass.Text.Trim()==true)
                    {
                        VentanaAdmin VenAd = new VentanaAdmin();

                        this.Hide();

                        VenAd.Show();
                    }
                    else
                    {
                        VentanaUser VenUs = new VentanaUser();
                        this.Hide();
                        VenUs.Show();
                    }
                }

                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecta");
                }
            }
            catch (Exception error)
            {
               MessageBox.Show("Usuario o Contraseña Incorrecta");
            }
            
        }
    }
}
