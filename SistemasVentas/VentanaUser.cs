using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;
using static SistemasVentas.FormularioBase;

namespace SistemasVentas
{
    public partial class VentanaUser : FormularioBase
    {
        public VentanaUser()
        {
            InitializeComponent();
        }

        private void VentanaUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void VentanaUser_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM  Usuarios WHERE id_usuario=" + VentanaLogin.Codigo;


            DataSet DS = Utilidades.Ejecutar(cmd);


            lblNomUs.Text = DS.Tables[0].Rows[0]["Nom_usu"].ToString();

            lblUs.Text = DS.Tables[0].Rows[0]["account"].ToString();

            lblCodigo.Text = DS.Tables[0].Rows[0]["id_usuario"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal Conp = new ContenedorPrincipal();
            this.Hide();
            Conp.Show();
        }
    }
}
