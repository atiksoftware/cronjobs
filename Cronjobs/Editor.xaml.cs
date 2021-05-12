using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Cronjobs {

    public partial class Editor : Window {
        public Cron cron;
        public bool is_new = false;

        public Action onChange;


        public Editor() {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            btnChoose.Click += ChoosePath;
            btnSave.Click += Save;
            btnDelete.Click += Delete;
            Title = cron == null ? "New Cron" : "Edit Cron";
            btnSave.Content = cron == null ? "Add" : "Save";
            if(cron == null) {
                cron = new Cron();
                is_new = true;
                btnDelete.Visibility = Visibility.Hidden;
            }
            txtPath.Text = cron.FilePath;
            txtDelayMin.Text = cron.DelayMin.ToString();
            txtDelayMax.Text = cron.DelayMax.ToString();
        }
 


        public void ChoosePath(object sender, RoutedEventArgs e) {
            OpenFileDialog dialog = new  OpenFileDialog();
            Nullable<bool> result = dialog.ShowDialog();
            if(result == true)
                txtPath.Text = dialog.FileName;
        }


        public void Save(object sender, RoutedEventArgs e) {
            cron.FilePath = txtPath.Text;
            cron.DelayMin = int.Parse(txtDelayMin.Text);
            cron.DelayMax = int.Parse(txtDelayMax.Text);
            if(is_new)
                DB.crons.Add(cron);
            DB.Save();
            if(onChange != null)
                onChange();
            this.Close();
        }
        public void Delete(object sender, RoutedEventArgs e) {
            DB.crons.Remove(cron); 
            DB.Save();
            if(onChange != null)
                onChange();
            this.Close();
        }
         
    }
}
