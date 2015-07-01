using BatchDownloaderCore.ApiCalls;
using BatchDownloaderCore.ApiMethods;
using Flurl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchDownloaderGUI
{
    public partial class MainWindow : Form
    {

        private ApiCaller _downloader;


        public MainWindow()
        {
            InitializeComponent();
            _downloader = new ApiCaller(new Url("http://192.168.1.35:8000"), new Url("api"));
            _downloader.Login(new LoginMethod("nas", "nas"));
            this.Text = "BatchDownloader";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = Regex.Split(richTextBox1.Text, String.Format("{0}|{1}", Environment.NewLine, "\n"));

            var links = text.Where(l => l.Trim().Length > 0)
                .Select(l => new Url(l)).ToList();

            var destination = textBox1.Text.Trim().Length > 0 
                ? textBox1.Text : null;

            if (links.Any())
            {
                _downloader.AddPackage(new AddPackageMethod(links, destination));
                richTextBox1.Text = String.Empty;
                textBox1.Text = String.Empty;
            }

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
