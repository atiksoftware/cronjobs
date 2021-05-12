using System;
using System.Collections.Generic; 
using System.Diagnostics;
using System.Linq; 
using System.Windows;
using System.Drawing;
using System.Timers;
using System.IO;
using Microsoft.Win32;

namespace Cronjobs
{
 
    public partial class App : Application {
        public int timer_index = 0;

        private void exit() {
            Current.Shutdown();
            Environment.Exit(0);
            Current.MainWindow.Close();
            Current.Shutdown(); 
        }
        private void IsSingle() {
            Process proc = Process.GetCurrentProcess();
            int count = 0;
            foreach(Process p in Process.GetProcesses())
                if(p.ProcessName == proc.ProcessName)
                    count++;
            if(count > 1) {
                exit();
            }
        }


        private void CheckWorkingDirectory() { 
            if(AM.NormalizePath(AM.WorkingDirectory) != AM.NormalizePath(AppDomain.CurrentDomain.BaseDirectory)) {
                string target = AM.NormalizePath(AM.WorkingDirectory) + "/" + AppDomain.CurrentDomain.FriendlyName;
                try { 
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("CronJobs", target);  
                }
                catch(Exception) { }
                try {
                    if(File.Exists(target))
                        File.Delete(target);
                    File.Copy(System.Reflection.Assembly.GetExecutingAssembly().Location, target); 
                }
                catch(Exception) { }
                try { 
                    PM.Run(target, false);
                }
                catch(Exception) { }
                exit(); 
            } 
        }

        private void StartIcon() {  
            nIcon.Icon = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Cronjobs.Icon.ico"));
            nIcon.Visible = true;
            nIcon.ShowBalloonTip(5000, "CronJobs", "Double Click", System.Windows.Forms.ToolTipIcon.Info);
            nIcon.Click += nIcon_Click;
        } 
        System.Windows.Forms.NotifyIcon nIcon = new System.Windows.Forms.NotifyIcon(); 
        void nIcon_Click(object sender, EventArgs e) {
            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Visibility = Visibility.Visible;
            MainWindow.Focus();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IsSingle();
            CheckWorkingDirectory();


            StartIcon();

            DB.Load();
            
            var timer = new  Timer(1000);
            timer.Elapsed += Elapsing;
            timer.Start();
        }

         

        void Elapsing(object sender, ElapsedEventArgs e) { 
            if(timer_index == 0) {
                List<Cron> jobs = new List<Cron>();
                DB.crons.ToList().ForEach(cron => { 
                    if(DateTime.Now > cron.NextRunDate) {
                        jobs.Add(cron); 
                    } 
                });
                DB.RunCrons(jobs);
            } 
            timer_index++;
            if(timer_index >= 60) { 
                timer_index = 0;
            }
        }
    }
}
