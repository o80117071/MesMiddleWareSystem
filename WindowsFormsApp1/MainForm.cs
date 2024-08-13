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


namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private List<FileMonitor> monitors = new List<FileMonitor>();
        public MainForm()
        {
            InitializeComponent();
            Configuration.LoadConfiguration();
            ShowSettingsForm();
            StartMonitoring();
        }
        private void ShowSettingsForm()
        {
            if(Configuration.CustomerName == "CustomerA")
            {
                // 创建 SettingsForm 实例
                var settingsForm = new CusForm();

                // 设置为非顶级窗体，使其可以嵌入到 Panel 中
                settingsForm.TopLevel = false;

                // 移除边框
                settingsForm.FormBorderStyle = FormBorderStyle.None;

                // 设置填充整个 Panel
                settingsForm.Dock = DockStyle.Fill;

                // 将 SettingsForm 添加到 Panel 容器中
                this.panelContainer.Controls.Add(settingsForm);

                // 显示 SettingsForm
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
