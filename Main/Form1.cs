using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonFx.Json;

namespace Main
{
    public partial class MainForm : Form
    {
        dynamic data;
        public MainForm()
        {
            InitializeComponent();
            try
            {
                tbData.Text = System.IO.File.ReadAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\razortester.txt");
                tbTemplate.Text = System.IO.File.ReadAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\razortester2.txt");
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\razortester.txt", tbData.Text);
                System.IO.File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\razortester2.txt", tbTemplate.Text);
                data = new JsonReader().Read(tbData.Text);


                RazorEngine.Templating.TemplateService svc = new RazorEngine.Templating.TemplateService();
                tbCompiled.Text = svc.Parse(tbTemplate.Text, data, null, null);

                webBrowser1.DocumentText = tbCompiled.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbOutput.Text = ex.ToString();
            }
        }
    }
}
