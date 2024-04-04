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

namespace LabRepaso3
{

    public partial class Form1 : Form
    {
        Temperatura temperatura = new Temperatura();
        List<Departamento> departamentos = new List<Departamento>();
        List<Temperatura> temperaturas = new List<Temperatura>();
        List<Reporte> reportes = new List<Reporte>();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "Departamentos.txt";
            
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Departamento departamento = new Departamento();
                departamento.Id = Convert.ToInt16(reader.ReadLine());
                departamento.Nombre = reader.ReadLine();

                departamentos.Add(departamento);
            }
            
            reader.Close();

            comboBoxDepartamentos.DisplayMember = "Nombre";
            comboBoxDepartamentos.ValueMember = "Id";
            comboBoxDepartamentos.DataSource = departamentos;
            comboBoxDepartamentos.Refresh();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            temperatura.IdDepartamento = Convert.ToInt32(comboBoxDepartamentos.SelectedValue);
            temperatura.TemperaturaLeida = Convert.ToInt16(textBox1.Text);
            temperatura.FechaLectura = DateTime.Now;

            temperaturas.Add(temperatura);
            

            GuardarTemperatura();
            
        }

        private void GuardarTemperatura()
        {
            
            FileStream stream = new FileStream("Temperaturas.txt", FileMode.OpenOrCreate, FileAccess.Write);            
            StreamWriter writer = new StreamWriter(stream);

            foreach (var temperatura in temperaturas)
            {
                writer.WriteLine(temperatura.IdDepartamento);
                writer.WriteLine(temperatura.TemperaturaLeida);
                writer.WriteLine(temperatura.FechaLectura);
            }
                           
            writer.Close();
        }

        private void buttonReporte_Click(object sender, EventArgs e)
        {
            foreach (var departamento in departamentos)
            {
                foreach (var temperatura in temperaturas)
                {
                    if (departamento.Id == temperatura.IdDepartamento)
                    {
                        Reporte reporte = new Reporte();
                        reporte.NombreDepartamento = departamento.Nombre;
                        reporte.Temperatura = temperatura.TemperaturaLeida;
                        reporte.Fecha = temperatura.FechaLectura;

                        reportes.Add(reporte);
                        
                    }
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            reportes = reportes.OrderBy(p => p.Temperatura).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();


        }
    }
}
