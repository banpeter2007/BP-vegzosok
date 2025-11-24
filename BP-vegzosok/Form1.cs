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

namespace BP_vegzosok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // TXT betöltése gomb eseménykezelő
            string filePath = "vegzosok.txt";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Nem található a TXT fájl!");
                return;
            }
            var sorok = File.ReadAllLines(filePath, Encoding.Default);
            var fejlec = sorok[0].Split(';');
            DataTable tabla = new DataTable();
            foreach (var oszlop in fejlec)
                tabla.Columns.Add(oszlop);
            foreach (var sor in sorok.Skip(1))
                tabla.Rows.Add(sor.Split(';'));
            dataGridView1.DataSource = tabla;
        }
    }
}
