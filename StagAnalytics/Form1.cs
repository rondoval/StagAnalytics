using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StagAnalytics
{
    public partial class Main : Form
    {
        OSCStatistics stats; // main stats object

        public Main()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            oscMainFileDialog.ShowDialog();
        }

        private void appendButton_Click(object sender, EventArgs e)
        {
            oscAdditionalFileDialog.ShowDialog();
        }

        private void oscMainFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            using (BinaryReader reader = new BigEndianReader(oscMainFileDialog.OpenFile(), Encoding.ASCII))
            {
                OSCFile osc = new OSCFile(reader);
                stats = new OSCStatistics(osc);
            }
            minLpgTemp.Enabled = true;
            minRedTemp.Enabled = true;

            refresh();
        }

        private void oscAdditionalFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            using (BinaryReader reader = new BigEndianReader(oscAdditionalFileDialog.OpenFile(), Encoding.ASCII))
            {
                OSCFile osc = new OSCFile(reader);
                if (stats != null)
                {
                    stats.addFrames(osc);
                } else
                {
                    stats = new OSCStatistics(osc);
                }
            }
            refresh();
        }

        private void refresh()
        {
            double[,] pbCorrections = stats.getAvgCorrections(OSCStatistics.Mode.PB);
            double[,] lpgCorrections = stats.getAvgCorrections(OSCStatistics.Mode.LPG);
            int[,] multiplier = stats.getMultipliers();
            double[,] diff = OSCStatistics.calcCorrectionDiff(pbCorrections, lpgCorrections);
            int[,] newMultiplier = stats.calcNewMultiplier(diff);

            fillDataView(pbMapView, pbCorrections, new Converter<double, string>(x => (Double.IsNaN(x)) ? "" : Math.Round(x, 2) + "%"));
            fillDataView(lpgMapView, lpgCorrections, new Converter<double, string>(x => (Double.IsNaN(x)) ? "" : Math.Round(x, 2) + "%"));
            fillDataView(multiplierMapView, multiplier, new Converter<int, string>(x => x.ToString()));
            fillDataView(diffMapView, diff, new Converter<double, string>(x => (Double.IsNaN(x)) ? "" : Math.Round(x, 2) + "%"));
            fillDataView(adjustedMultiplierMap, newMultiplier, new Converter<int, string>(x => x.ToString()));
            fillDataView(sampleQuantity, stats.prepSampleQtyText(), new Converter<string, string>(x => x));

            fillDataView(pbQuota, stats.getPBQuota(), new Converter<double, string>(x => (Double.IsNaN(x)) ? "" : Math.Round(x, 2) + "%"));
        }

        private void fillDataView<T>(DataGridView dest, T[,] correction, Converter<T, string> conv)
        {
            dest.Rows.Clear();
            dest.Columns.Clear();

            double[] columnHeader = stats.getMsTable();
            int[] rowHeader = stats.getRpmTable();
            addDataViewHeaderMS(dest, columnHeader);

            for (int i = rowHeader.Length - 1; i >= 0; i--)
            {
                string[] row = new string[columnHeader.Length + 1];
                row[0] = rowHeader[i].ToString();
                for (int j = 0; j < columnHeader.Length; j++)
                {
                    row[j + 1] = conv(correction[j, i]);
                }
                dest.Rows.Add(row);
                //dest.Rows[0].Cells[1].Style.BackColor = Color.Green;
            }
        }

        private static void addDataViewHeaderMS(DataGridView dest, double[] columnHeader)
        {
            dest.Columns.Add("rpm", "RPM/Inj time");
            foreach (double d in columnHeader)
            {
                dest.Columns.Add("ms", d.ToString() + " ms");
            }
        }

        private void minRedTemp_EnabledChanged(object sender, EventArgs e)
        {
            stats.minReducerTemperature = (int) minRedTemp.Value;
        }

        private void minLpgTemp_EnabledChanged(object sender, EventArgs e)
        {
            stats.minLpgTemperature = (int) minLpgTemp.Value;
        }

        private void minRedTemp_ValueChanged(object sender, EventArgs e)
        {
            stats.minReducerTemperature = (int)minRedTemp.Value;
            refresh();
        }

        private void minLpgTemp_ValueChanged(object sender, EventArgs e)
        {
            stats.minLpgTemperature = (int)minLpgTemp.Value;
            refresh();
        }
    }
}
