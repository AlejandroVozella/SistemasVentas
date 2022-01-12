using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiLibreria

{
    public class Utilidades
    {
        public static DataSet Ejecutar (string cmd)
        {
            
            SqlConnection Con = new SqlConnection("Data Source =.; Initial Catalog = Administracion; Integrated Security = True");

            Con.Open();

            DataSet DS = new DataSet();

            SqlDataAdapter DP = new SqlDataAdapter(cmd,Con);

            DP.Fill(DS);

            Con.Close();

            return DS;


        }

        public static  Boolean ValidarFormulario(Control Objeto , ErrorProvider errorProvider)
        {
            Boolean HayErrores = false;

            foreach (Control Item in Objeto.Controls)
            {
                if (Item is ErrortxtBox)
                {
                    ErrortxtBox Obj = (ErrortxtBox)Item;

                    if (Obj.Validar == true)
                    {
                        if (string.IsNullOrEmpty(Obj.Text.Trim()))
                        {
                            errorProvider.SetError(Obj, "No puede Estar Vacio");
                            HayErrores = true;
                        }
                    }
                    if (Obj.SoloNumeros == true)
                    {
                        int cont=0, LetrasEncontradas = 0;

                        foreach(char letra in Obj.Text.Trim())
                        {
                            if (char.IsLetter(Obj.Text.Trim(), cont))
                            {
                                LetrasEncontradas++;
                            }
                            cont++;
                        }
                        if (LetrasEncontradas != 0)
                        {
                            HayErrores = true;
                            errorProvider.SetError(Obj, "Solo Numeros");
                        }
                    }
                }
            }
            return HayErrores;
        }

    }
}
