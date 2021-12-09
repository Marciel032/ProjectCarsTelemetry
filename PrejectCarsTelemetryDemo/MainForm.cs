using Newtonsoft.Json;
using ProjectCarsTelemetry;
using System;
using System.Windows.Forms;

namespace PrejectCarsTelemetryDemo
{
    public partial class MainForm : Form
    {
        private TelemetryReader telemetryReader;

        public MainForm()
        {
            InitializeComponent();
            telemetryReader = new TelemetryReader();
            telemetryReader.OnTelemetryRead += TelemetryReader_OnTelemetryRead;
        }

        private void TelemetryReader_OnTelemetryRead(Telemetry telemetry)
        {
            var texto = JsonConvert.SerializeObject(telemetry, Formatting.Indented);
            richTextBox1.BeginInvoke((MethodInvoker)delegate ()
            {
                richTextBox1.Text = texto;
                lblLastRefresh.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            });
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartStopTelemetry(true);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StartStopTelemetry(false);
        }

        private void StartStopTelemetry(bool start) {
            if(start)
                telemetryReader.Start();
            else
                telemetryReader.Stop();
            BtnStart.Enabled = !start;
            btnStop.Enabled = start;
        }
    }
}
