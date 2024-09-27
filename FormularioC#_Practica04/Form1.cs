using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FormularioC__Practica04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text;
            string apellidos = tbApellidos.Text;
            string edad = tbEdad.Text;
            string estatura = tbEstatura.Text;
            string telefono = tbTelefono.Text;
            string genero = "";
            if (rbMasculino.Checked)
            {
                genero = "Masculino";
            }
            else if (rbFemenino.Checked)
            {
                genero = "Femenino";
            }

            string datos = $"Nombre: {nombre}\r\nApellidos: {apellidos}\r\nEdad: {edad} años\r\nEstatura: {estatura}\r\nTelefono: {telefono}\r\nGenero: {genero}";

            string rutaArchivos = "C:\\Users\\DELL\\Documents\\P.EJGR\\TXT.txt";
            bool archivoExiste = File.Exists(rutaArchivos);
            using (StreamWriter writer = new StreamWriter (rutaArchivos, true))
            {
                if (archivoExiste)
                {
                    writer.WriteLine();
                }
                writer.WriteLine(datos);
            }
            MessageBox.Show("Datos guardados correctamente: \n\n" + datos, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            tbNombre.Clear();
            tbApellidos.Clear();
            tbEdad.Clear();
            tbEstatura.Clear();
            tbTelefono.Clear();
            rbMasculino.Checked = false;
            rbFemenino.Checked = false;
        }
    }
}
