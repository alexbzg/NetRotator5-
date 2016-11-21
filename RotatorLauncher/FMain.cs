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
        const int bandsCount = 6;

        public class DeviceEntry
        {
            public int programType;
            public string name;
            public int index;
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

        public class AppConf
        {
            public string[] rotatorPaths = new string[] { "", "" };
            public DeviceEntry[][] devices;

            public void initDevices() {
                devices = new DeviceEntry[bandsCount][];
                for ( int co = 0; co < bandsCount; co++ )
                    devices[co] = new DeviceEntry[2];
            }
        }

        FormState[] rotatorStates = new FormState[] { null, null };
        AppConf appConf = new AppConf();
        int ofdIndex = -1;
        BindingList<DeviceRow> blDevices = new BindingList<DeviceRow>();
        BindingSource bsDevices;
        int menuBand = -1;
        int menuDevType = -1;

        public FMain()
        {
            InitializeComponent();
            readConfig();
            if (appConf.devices == null || appConf.devices.Length < bandsCount)
                appConf.initDevices();

            for (int co = 0; co < 2; co++)
            {
                setRotatorPath(co, appConf.rotatorPaths[co]);
                if ( rotatorStates[co] != null )
                {
                    int programType = co;
                    ToolStripMenuItem mi = new ToolStripMenuItem();
                    mi.Text = ddbSettings.DropDownItems[co].Text;
                    for (int subCo = 0; subCo < rotatorStates[co].connections.Count; subCo++ )
                    {
                        ConnectionSettings cs = rotatorStates[co].connections[subCo];
                        ToolStripMenuItem miSub = new ToolStripMenuItem();
                        int index = subCo;
                        miSub.Text = cs.name;
                        miSub.Click += delegate (object sender, EventArgs e)
                        {
                            setDevEntry(menuBand, menuDevType, new DeviceEntry { programType = programType, name = cs.name, index = index } );
                            writeConfig();
                        };
                        mi.DropDownItems.Add(miSub);
                    }
                    cmDevices.Items.Add(mi);

                }
            }

            bsDevices = new BindingSource(blDevices, null);
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.DataSource = bsDevices;

            for ( int co = 0; co < bandsCount; co++ )
            {
                string[] devNames = new string[] { null, null };
                for ( int subCo = 0; subCo < 2; subCo++ )
                {
                    if (appConf.devices[co][subCo] != null) {
                        DeviceEntry de = appConf.devices[co][subCo];
                        if (rotatorStates[de.programType] != null)
                        {
                            int newIdx = rotatorStates[de.programType].connections.FindIndex(
                                cs => cs.name == de.name
                            );
                            de.index = newIdx;
                            if (newIdx != -1)
                                devNames[subCo] = de.name;
                        }
                    }
                }
                blDevices.Add(new DeviceRow { band = bands[co], run = devNames[0], run2 = devNames[1] });
            }
        }

        private void setDevEntry( int band, int devType, DeviceEntry de )
        {
            appConf.devices[band][devType] = de;
            DeviceRow dr = blDevices[band];
            if (devType == 0)
                dr.run = de.name;
            else
                dr.run2 = de.name;
            blDevices.ResetItem(band);
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
            if ( e.ColumnIndex > 0 && e.RowIndex > -1 )
            {
                DeviceEntry de = appConf.devices[e.RowIndex][e.ColumnIndex - 1];
                if (de != null && de.index != -1)
                    Process.Start( appConf.rotatorPaths[de.programType] + "//" + exeNames[de.programType], de.index.ToString() );
            }
        }

        private void dgvDevices_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.ColumnIndex < 1 || e.RowIndex < 0)
                e.ContextMenuStrip = null;
            else
            {
                menuBand = e.RowIndex;
                menuDevType = e.ColumnIndex - 1;
                e.ContextMenuStrip = cmDevices;
            }
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

    
}
