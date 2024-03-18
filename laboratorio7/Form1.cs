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

namespace laboratorio7
{
    public partial class Form1 : Form
    {
        List<Propiedad> propiedads = new List<Propiedad>();
        List<Propietario> propietarios = new List<Propietario>();
        List<Dato> datos = new List<Dato>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Cargarpropiedades()
        {
            string fileName = "Propiedades.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propiedad propiedad = new Propiedad();
                propiedad.Casa = reader.ReadLine();
                propiedad.Dpi = Convert.ToInt64(reader.ReadLine());
                propiedad.Cuota = Convert.ToInt32(reader.ReadLine());

                propiedads.Add(propiedad);
            }
            reader.Close();
        }
        private void Cargarpropietarios()
        {
            string fileName = "Propietarios.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propietario propietario = new Propietario();
                propietario.Dpi = Convert.ToInt64(reader.ReadLine());
                propietario.Nombre = reader.ReadLine();
                propietario.Apellido = reader.ReadLine();

                propietarios.Add(propietario);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cargarpropiedades();
            Cargarpropietarios();
            if (datos.Count == 0)
            {
                datos.Clear();
                foreach (Propietario propietario in propietarios)
                {
                    Propiedad propiedad = propiedads.FirstOrDefault(c => c.Dpi == propietario.Dpi);
                    if (propiedad != null)
                    {
                        Dato dato = new Dato();
                        dato.Nombre = propietario.Nombre;
                        dato.Apellido = propietario.Apellido;
                        dato.Casa = propiedad.Casa;
                        dato.Cuota = propiedad.Cuota;
                        datos.Add(dato);

                    }



                }
                //int mayor = alquilers.Max(a => a.Recorridos);
                //DatosAlquiler datosAlquiler1 = datosAlquilers.OrderByDescending(a => a.Total).First();
                //label1.Text = mayor.ToString();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
            }
        }
    }

}
