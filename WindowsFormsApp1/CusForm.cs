﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CusForm : Form
    {
        public CusForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CusFormSettings.SetSettingValue("txt_1", txt_1.Text);
            MainForm.Instance.AddLogMessage("button1_Click");
        }
    }
}
