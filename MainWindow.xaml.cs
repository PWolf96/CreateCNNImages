using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
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
using SWF = System.Windows.Forms;

namespace CreateCNNImages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string ExlImportFilePath = "";
        List<string> exlSheetList = new List<string>();
        List<List<Event>> eventList = new List<List<Event>>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            exlSheetList.Clear();
            ExlImportFilePath = selectExl();

            try
            {
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(ExlImportFilePath, false))
                {
                    WorkbookPart wbPart = spreadsheetDocument.WorkbookPart;
                    Sheets theSheets = wbPart.Workbook.Sheets;
                    foreach (Sheet sheet in theSheets)
                    {
                        string exlSheet = sheet.Name;
                        exlSheetList.Add(exlSheet);
                    }

                    if (exlSheetList.Count() == 0 || exlSheetList == null)
                    {
                        MessageBox.Show("Something is wront with your files sheets", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        eventList = Event.ReadExcelFile(ExlImportFilePath, exlSheetList.First());
                        int counter = 0;
                        foreach (List<Event> eventEntry in eventList)
                        {                   
                            CNNImage.CreateBitmap(eventEntry, counter);
                            counter += 1;
                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Selected file is opened. Please ensure that the file is closed before selecting.", "Operation cancelled", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        public static string selectExl()
        {
            string fPath = "";

            //Open a window dialog
            SWF.OpenFileDialog filePicker = new SWF.OpenFileDialog();
            filePicker.Multiselect = false;
            //Title and filter of the windows dialog
            filePicker.Title = "Pick players information file";
            filePicker.Filter = "ExcelFiles|*.xls;*xlsx;*.xlsm;*.csv";

            //If the user clicks OK on the dialog, collect the file path
            if (filePicker.ShowDialog() == SWF.DialogResult.OK)
            {
                fPath = filePicker.FileName;
            }

            return fPath;
        }
    }
}
