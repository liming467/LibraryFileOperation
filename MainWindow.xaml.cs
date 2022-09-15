using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Path = System.IO.Path;

namespace LibraryFileOperation
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


        //查询文件，选择文件夹
        private void btnQueryFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = selectFolderPath();
            textBoxQueryFile.Text = fileName;
        }

        //查询文件，确定键开始查询
        private void btnQueryFileOk_Click(object sender, RoutedEventArgs e)
        {

            string suffixName = "." + textBoxSuffixName.Text;
            string path = textBoxQueryFile.Text;

            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            bool isFirst = true;

            foreach(var file in files)
            {

                string fileName = Path.GetFileName(file.FullName);
                if (Path.GetExtension(fileName) == suffixName)
                {
                    if (isFirst)
                    {
                        textBoxContent.Clear();
                        isFirst = false;
                    }
                    textBoxContent.AppendText(fileName + "\n");
                }
                    Debug.WriteLine(fileName);
            }
           


        }

        //源文件夹，选择文件夹
        private void btnCopyFile_src_Click(object sender, RoutedEventArgs e)
        {
            string fileName = selectFolderPath();
            textBoxCopyFile_src.Text = fileName;
        }

        //目标文件夹，选择文件夹
        private void btnCopyFile_dst_Click(object sender, RoutedEventArgs e)
        {
            string fileName = selectFolderPath();
            textBoxCopyFile_dst.Text = fileName;
        }

        //复制文件，确定按钮
        private void btnCopyFile_ok_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string[] contentArray = content.Split("\n");
            if (contentArray.Length == 0) return;

            string path_src = textBoxCopyFile_src.Text;
            string path_dst = textBoxCopyFile_dst.Text;
            string fileName_src = "";
            string fileName_dst = "";
            int count = 0;
            bool isFirst = true;
            foreach (var name in contentArray)
            {
                //复制文件
                fileName_src = path_src + @"\" + name;
                fileName_dst = path_dst + @"\" + name;
                if (!File.Exists(fileName_src)) continue;

                if(isFirst)
                {
                    textBoxContent.Clear();
                    isFirst = false;
                }

                File.Copy(fileName_src, fileName_dst);
                count++;
            }

            MessageBox.Show("复制成功文件数：" + count.ToString(), "提示");

        }


        string selectFolderPath()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.InitialDirectory = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            CommonFileDialogResult result = dialog.ShowDialog();
            return result == CommonFileDialogResult.Ok ? dialog.FileName : "";
        }

    }
}
