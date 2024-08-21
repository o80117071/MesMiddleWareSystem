using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using log4net;


namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private static MainForm _instance;
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));
        private List<FileMonitor> monitors = new List<FileMonitor>();
        public MainForm()
        {
            InitializeComponent();
            _instance = this;

            LoadConfig();
            ShowSettingsForm();
            StartMonitoring();

            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            var logControlAppender = new LogControlAppender(logListBox);  
            ((log4net.Repository.Hierarchy.Logger)log.Logger).AddAppender(logControlAppender);

            //log.Info("Form initialized");
        }

        private void LoadConfig()
        {
            Configuration.LoadConfiguration();
            txt_Customer.Text = Configuration.CustomerName;

        }

        private void ShowSettingsForm()
        {
            if(Configuration.CustomerName == "CustomerA")
            {
                var settingsForm = new CusForm();

                settingsForm.TopLevel = false;

                settingsForm.FormBorderStyle = FormBorderStyle.None;

                settingsForm.Dock = DockStyle.Fill;

                this.panelContainer.Controls.Add(settingsForm);

                settingsForm.Show();
            }      
        }
        public void AddLog(string message)
        {
            logListBox.Items.Add($"{DateTime.Now}: {message}");
            logListBox.SelectedIndex = logListBox.Items.Count - 1;
        }

        private void StartMonitoring()
        {
            var directories = new string[]
            {
                @"MESPolling\SFC\",
                @"MESPolling\SECS\",
                @"MESPolling\CFX\"
            };

            foreach (var directory in directories)
            {
                // 檢查資料夾是否存在，如果不存在則創建
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var monitor = new FileMonitor(directory, Configuration.CustomerName);
                monitors.Add(monitor);
                monitor.StartMonitoring();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var monitor in monitors)
            {
                monitor.StopMonitoring();
            }
        }

        public static MainForm Instance
        {
            get { return _instance; }
        }

        public void AddLogMessage(string message)
        {
            log.Info(message);
        }
    }

    public static class Configuration
    {
        public static string CustomerName { get; private set; }

        public static void LoadConfiguration()
        {
            CustomerName = File.ReadAllText("customer.config").Trim();
        }
    }
}
