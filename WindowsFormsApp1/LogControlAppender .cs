using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Appender;
using log4net.Core;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class LogControlAppender : AppenderSkeleton
    {
        private ListBox _logListBox;  // 或 TextBox 控件


        public LogControlAppender(ListBox listBox)
        {
            _logListBox = listBox;
            this.Layout = new log4net.Layout.PatternLayout("%date [%thread] %-5level %message%newline");
        }

       
        protected override void Append(LoggingEvent loggingEvent)
        {
            string logMessage = RenderLoggingEvent(loggingEvent);

            if (_logListBox != null)
            {
                _logListBox.Invoke((MethodInvoker)delegate {
                    _logListBox.Items.Add(logMessage);
                    _logListBox.SelectedIndex = _logListBox.Items.Count - 1;  // 自动滚动到最后一条
                });
            }
        }
    }
}
