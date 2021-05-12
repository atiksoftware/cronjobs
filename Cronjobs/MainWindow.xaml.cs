using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Cronjobs {
 
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent(); 
             
            btnCreate.Click += Create;
            btnRunSelecteds.Click += RunSelecteds;
 
            cronlist.MouseDoubleClick += CronListDoubleClicked;
            DB.OnChanged += CronListRefresh;
            cronlist.ItemsSource = DB.crons;
        }
        public void Window_Closing(object sender, CancelEventArgs e) {
            e.Cancel = true;
            Visibility = Visibility.Hidden;
            WindowState = WindowState.Minimized;
        }
        public void CronListRefresh() {
            cronlist.Items.Refresh();
        }


        public void Create(object sender, RoutedEventArgs e) {  
            OpenCronEditDialog( ); 
        }
         
        public void CronListDoubleClicked(object sender, MouseButtonEventArgs e) {
            Cron SelectedItem = (Cron)cronlist.SelectedItem; 
            if(SelectedItem != null)  
                OpenCronEditDialog(SelectedItem);  
        }


        public void OpenCronEditDialog(Cron cron = null) {
            Editor editor = new Editor { cron = cron };  
            editor.Show(); 
        }


        public void RunSelecteds(object sender, RoutedEventArgs e) {
            DB.RunCrons(cronlist.SelectedItems.Cast<Cron>().ToList()); 
        }
    }
}
