using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrioTest.Radio;

namespace BrioTest
{
    public partial class Form1 : Form
    {
        private Calculator _calculator = new Calculator();
        private AdapterData _adapterData;
        public Form1()
        {
            InitializeComponent();

            OpenButton.Click += OpenButton_Click;
            SaveButton.Click += SaveButton_Click;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            //saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void OpenButton_Click(object sender, EventArgs e)
        {
            //if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            //    return;
            //// получаем выбранный файл
            //string filename = openFileDialog.FileName;
            string filename = "C:\\Users\\Azat\\Documents\\GitHub\\BrioTest\\input.txt";
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);

            //textBox1.Text = fileText;
            //Вызов логики
            //MessageBox.Show("Файл открыт");

            var data = _adapterData.Parse(fileText);
            
            _calculator.Callulate(data.receivers, data.signalTimes);
            
            //this.receiver1.Location()


        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog.FileName;
            // сохраняем текст в файл
            //System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");

        }
    }
}
