using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Diagnostics;

namespace RotatorLauncher
{
    public partial class FMain : Form
    {
        static readonly string[] exeNames = { "AntennaNetRotator.exe", "AntennaNetRotator5.exe" };
        static readonly string[] bands = { "10", "15", "20", "40", "80", "160" };

        private class DeviceEntry
        {
            int programType;
            string name;
            int index;


        };

        private class DeviceRow
        {
            string _Band;
            string _Run;
            string _Run2;

            public string band
            {
                get { return _Band; }
                set { _Band = value; }
            }

            public string run
            {
                get { return _Run; }
                set { _Run = value; }
            }

            public string run2
            {
                get { return _Run2; }
                set { _Run2 = value; }
            }


        };

        FormState[] rotatorStates = new FormState[] { null, null };
        AppConf appConf = new AppConf();
        int ofdIndex = -1;
        BindingList<DeviceRow> blDevices = new BindingList<DeviceRow>();
        BindingSource bsDevices;

        public FMain()
        {
            InitializeComponent();
            readConfig();

            for (int co = 0; co < 2; co++)
            {
                setRotatorPath(co, appConf.rotatorPaths[co]);
                if ( rotatorStates[co] != null )
                {
                    ToolStripMenuItem mi = new ToolStripMenuItem();
                    mi.Text = ddbSettings.DropDownItems[co].Text;
                    cmDevices.Items.Add(mi);
                }
            }

            bsDevices = new BindingSource(blDevices, null);
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.DataSource = bsDevices;

            foreach ( string band in bands)
            {
                blDevices.Add(new DeviceRow { band = band });
            }
        }

        private FormState loadRotatorConfig(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(FormState));
            using (FileStream fs = File.OpenRead(path + "\\config.xml"))
            {
                try
                {
                    return (FormState)ser.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading config: " + ex.ToString());
                }
            }
            return null;
        }

        private void miPathClick(object sender, EventArgs e)
        {
            ToolStripMenuItem miSender = (ToolStripMenuItem)sender;
            ofdIndex = ddbSettings.DropDownItems.IndexOf(miSender);
            ofdRotator.Filter = exeNames[ofdIndex] + "|" + exeNames[ofdIndex];
            ofdRotator.InitialDirectory = appConf.rotatorPaths[ofdIndex];
            ofdRotator.ShowDialog();
        }

        private void ofdRotator_FileOk(object sender, CancelEventArgs e)
        {
            setRotatorPath(ofdIndex, Path.GetDirectoryName(ofdRotator.FileName));
        }

        private void setRotatorPath( int index, string path )
        {
            string exePath = path + "\\" + exeNames[index];
            if (File.Exists(exePath))
            {
                ddbSettings.DropDownItems[index].ToolTipText = exePath;
                rotatorStates[index] = loadRotatorConfig(path);
                if ( appConf.rotatorPaths[index] != path )
                {
                    appConf.rotatorPaths[index] = path;
                    writeConfig();
                }
            }
        }

        private void readConfig()
        {
            XmlSerializer ser = new XmlSerializer(typeof(AppConf));
            try
            {
                using (FileStream fs = File.OpenRead(Application.StartupPath + "\\config.xml"))
                    appConf = (AppConf)ser.Deserialize(fs);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading config: " + ex.ToString());
            }

        }

        public void writeConfig()
        {
            using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\config.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(AppConf));
                ser.Serialize(sw, appConf);
            }
        }

        private void dgvDevices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("cell click");
        }
    }

    public class ConnectionSettings
    {

        public string name = "";
    }

    public class FormState
    {
        public List<ConnectionSettings> connections;
    }

    public class AppConf
    {
        public string[] rotatorPaths = new string[] { "", "" };
    }
}
