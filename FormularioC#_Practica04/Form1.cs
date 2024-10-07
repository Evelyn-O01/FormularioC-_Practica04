using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            tbNombre.TextChanged += validarNombre;
            tbApellidos.TextChanged += validarApellidos;
            tbEdad.TextChanged += validarEdad;
            tbEstatura.TextChanged += validarEstatura;
            tbTelefono.TextChanged += validarTelefono;

        }

        private bool EsEnteroValido (string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }

        private bool EsDecimalValido(string valor)
        {
            decimal resultado;
            return decimal.TryParse(valor, out resultado);
        }

        private bool EsTextoValido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
        }

        private bool EsEnteroValidoDe10Digitos(string valor)
        {
            long result;
            return long.TryParse(valor, out result) && valor.Length == 10;
        }

        private void validarNombre(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EsTextoValido(textBox.Text))
            {
                MessageBox.Show("Por favor ingresa un nombre valido (solo letras y espacios).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }

        }
        private void validarApellidos(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EsTextoValido(textBox.Text))
            {
                MessageBox.Show("Por favor ingresa apellidos validos (solo letras y espacios).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }

        }
        private void validarEdad(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EsEnteroValido(textBox.Text))
            {
                MessageBox.Show("Por favor ingresa una edad valida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }

        }
        private void validarEstatura(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EsDecimalValido(textBox.Text))
            {
                MessageBox.Show("Por favor ingresa una estatura valida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }

        }
        private void validarTelefono(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;
            //if (input.Length == 10)
            if (textBox.Text.Length == 10 && EsEnteroValidoDe10Digitos (textBox.Text))
            {
                textBox.BackColor = Color.Green;
                //if (!EsEnteroValidoDe10Digitos(input))
               // {
                 //   MessageBox.Show("Por favor ingrese un numero de telefono valido de 10 digitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //textBox.Clear();
               // }
              // else if (!EsEnteroValidoDe10Digitos(input))
                //{
               //     MessageBox.Show("Por favor ingrese un numero de telefono valido de 10 digitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // }
                
            }
            else
            {
                textBox.BackColor= Color.Red;
            }

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
