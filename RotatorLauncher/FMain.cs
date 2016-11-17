using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RotatorLauncher
{
    public partial class FMain : Form
    {
        FormState formState;

        public FMain()
        {
            InitializeComponent();
        }

        private void loadConfig()
        {
            XmlSerializer ser = new XmlSerializer(typeof(FormState));
            using (FileStream fs = File.OpenRead(Application.StartupPath + "\\config.xml"))
            {
                try
                {
                    formState = (FormState)ser.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading config: " + ex.ToString());
                }
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
