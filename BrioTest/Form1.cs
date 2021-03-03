using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BrioTest.Radio;
using BrioTest.UserControls;

namespace BrioTest
{
    public partial class Form1 : Form
    {
        private AdapterData _adapterData;
        private readonly Calculator _calculator = new Calculator();

        public Form1()
        {
            InitializeComponent();
            
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var zero = new ZeroCoordinateUC();
            
            panel1.Controls.Add(zero);

            zero.Location = new Point(transformCoord(0), transformCoord(0));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void OpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            var filename = openFileDialog.FileName;
            // читаем файл в строку
            var fileText = File.ReadAllText(filename);

            MessageBox.Show("Файл открыт");
            _adapterData = new AdapterData();
            var data = _adapterData.Parse(fileText);

            _calculator.Calculate(data.receivers, data.signalTimes);

            Draw();
        }

        private void SaveAsInputButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            var filename = saveFileDialog.FileName;
            // сохраняем текст в файл
            var data = _calculator.GetData();
            _adapterData.SaveData(data.receivers, data.signalTimes, filename);
            MessageBox.Show("Файл сохранен");
        }

        private void SaveAsOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            var filename = saveFileDialog.FileName;
            // сохраняем текст в файл
            var data = _calculator.GetData();
            _adapterData.SaveData(_calculator.GetTransmitterPoints(), filename);
            MessageBox.Show("Файл сохранен");
        }

        public void Draw()
        {
            panel1.Controls.Clear();

            var receiverPoints = _calculator.GetReceiverPoints();
            foreach (var receiverPoint in receiverPoints)
            {
                var receiverUc = new ReceiverUC();
                panel1.Controls.Add(receiverUc);

                receiverUc.Location = new Point(
                    transformCoord(receiverPoint.X),
                    transformCoord(receiverPoint.Y));
            }

            var transmitterPoints = _calculator.GetTransmitterPoints();
            foreach (var transmitterPoint in transmitterPoints)
            {
                var transmitterUc = new TransmitterUC();
                panel1.Controls.Add(transmitterUc);

                transmitterUc.Location = new Point(
                    transformCoord(transmitterPoint.X),
                    transformCoord(transmitterPoint.Y));
            }
            
            var zero = new ZeroCoordinateUC();

            panel1.Controls.Add(zero);

            zero.Location = new Point(transformCoord(0), transformCoord(0));
        }

        public int transformCoord(double coord)
        {
            return (int) (Math.Round(coord, 1) * 10) + 200;
        }

        private void AddNewTransmitterPoint_Click(object sender, EventArgs e)
        {
            double x = -100000, y = -100000;

            var correctData = double.TryParse(NewX.Text, out x) && double.TryParse(NewY.Text, out y);

            if (correctData)
            {
                _calculator.AddTransmitterPoint(new Radio.Structs.Point(x, y));
                Draw();
            }
            else
            {
                MessageBox.Show("Надо ввести число в формате 1.12(double)");
            }
        }
    }
}