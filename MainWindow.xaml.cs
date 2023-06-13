using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SystemWPF_DZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Process> curretP = new List<Process>();
        void InfoSeeker(Process Pr)
        {
            Process pr = curretP.FirstOrDefault(c=>c.Id==Pr.Id);
            try
            {
                InfoLB.Items.Clear();
                InfoLB.Items.Add("АйДи - " + pr.Id);
                InfoLB.Items.Add("Имя процесса - " + pr.ProcessName);
                InfoLB.Items.Add("Приоритет - " + pr.PriorityClass);
                InfoLB.Items.Add("Занимает память в Mb - " + pr.WorkingSet64/1000/1000);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

         
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StopProcessBTN_Click(object sender, RoutedEventArgs e)
        {
            if (CurretProcessLB.SelectedItem != null)
            {
                string sel = CurretProcessLB.SelectedItem.ToString();
                Process p = curretP.FirstOrDefault(c => c.ProcessName == sel);
                CurretProcessLB.Items.Remove(p.ProcessName);
                if (p.HasExited != true)
                    p.Kill();
                InfoLB.Items.Clear();
            }
        }

        private void TaskMNG_Click(object sender, RoutedEventArgs e)
        {
            Process pr = Process.Start("C:\\WINDOWS\\system32\\taskmgr.exe");
            
            
            curretP.Add(pr);
            InfoSeeker(pr);
            CurretProcessLB.Items.Add(pr.ProcessName);
        }

        private void Gimp_Click(object sender, RoutedEventArgs e)
        {
            
            Process pr = Process.Start("C:\\Program Files\\GIMP 2\\bin\\gimp-2.10.exe");

            
            curretP.Add(pr);
            InfoSeeker(pr);
            CurretProcessLB.Items.Add(pr.ProcessName);
        }
        private void Note_Click(object sender, RoutedEventArgs e)
        {

            Process pr = Process.Start("notepad.exe");


            curretP.Add(pr);
            InfoSeeker(pr);
            CurretProcessLB.Items.Add(pr.ProcessName);
        }
    }
}
