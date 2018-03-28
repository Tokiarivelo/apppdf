using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.IO;
using SautinSoft;

namespace appPdf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string pathToPdf = @"C:\Users\toky\Documents\Visual Studio 2015\Projects\appPdf\20180207_PAR.pdf";
            string pathToHtml = System.IO.Path.ChangeExtension(pathToPdf, ".htm");

            // Convert PDF file to HTML file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            // You may download the latest version of SDK here: 
            // www.sautinsoft.com/products/pdf-focus/download.php 


            // Let's force the component to store images inside HTML document
            // using base-64 encoding
            f.HtmlOptions.IncludeImageInHtml = true;
            f.HtmlOptions.Title = "Simple text";

            // This property is necessary only for registered version


            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToHtml(pathToHtml);

                //Show HTML document in browser
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(pathToHtml);
                }
            }
        }
    }
}
