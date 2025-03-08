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

namespace SOM
{
    public partial class Form1 : Form
    {
        private Button[] clusterButtons; 
        public Map map; 

        public Form1()
        {
            InitializeComponent();
             
        }

        private void ClusterButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            // Taking cluster coordinates from button
            string[] coordinates = button.Text.Split(',');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);

            // Taking text representations of all instances belonging to the relevant cluster coordinates
            string clusterExamples = GetClusterExamples(x, y);

            MessageBox.Show(clusterExamples, "Instances in "+x+","+y, MessageBoxButtons.OK);
        }

        private string GetClusterExamples(int x, int y)
        {
            StringBuilder builder = new StringBuilder();

            string filePath = textBox1.Text;

            if (File.Exists(filePath))
            {
                
                string[] lines = File.ReadAllLines(filePath);

                string featuresLine = lines[0];

                builder.AppendLine(featuresLine);

                // Creating a Dictionary to store instances
                Dictionary<int, string> instances = new Dictionary<int, string>();

                // Adding lines other than the features line
                for (int i = 1; i < lines.Length; i++)
                {
                    instances.Add(i - 1, lines[i]); 
                }

                // Finding the ones belonging to the relevant cluster by going through all the instances
                for (int i = 0; i < map.patterns.Count; i++)
                {
                    // If the instance belongs to the relevant cluster
                    if (map.outputs[x, y] == map.Winner(map.patterns[i]))
                    {
                        //Console.WriteLine(i);
                        string exampleText = instances[i];
                        builder.AppendLine(exampleText);
                    }
                }
            }
            else
            {
                MessageBox.Show("File Not Found!");
            }
            return builder.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                openFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    string fileName = Path.GetFileName(openFileDialog1.FileName);
                    textBox1.Text = fileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dimension = 0;
            if (int.TryParse(textBox2.Text, out dimension))
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && File.Exists(textBox1.Text))
                {
                    StreamReader sr = new StreamReader(textBox1.Text);
                    int lng = sr.ReadLine().Split(',').Length;

                    map = new Map(lng-1, dimension,textBox1.Text);
                    InitializeClusterButtons();
                }
                else
                {
                    MessageBox.Show("Please select a valid file.");
                }
            }
            else
            {
                MessageBox.Show("Dimension is invalid.");
            }
        }
        private void InitializeClusterButtons()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowStyles.Clear();

            int rows = map.length;
            int cols = map.length;

            for (int i = 0; i < rows; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));

                for (int j = 0; j < cols; j++)
                {
                    tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));

                    int index = i * cols + j;
                    Button button = new Button();
                    button.Text = $"{i},{j}";
                    button.Tag = index;
                    button.Click += ClusterButton_Click;
                    button.BackColor = Color.Orange; 

                    tableLayoutPanel.Controls.Add(button, j, i);
                }
            }

            tableLayoutPanel.Size = new Size(600, 400);
            tableLayoutPanel.Location = new Point(10, 80);
            tableLayoutPanel.Dock = DockStyle.None; 
            Controls.Add(tableLayoutPanel);
        }
    }
}
