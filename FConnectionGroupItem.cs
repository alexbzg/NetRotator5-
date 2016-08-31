using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncRotator
{
    public partial class FConnectionGroupItem : Form
    {
        public FConnectionGroupItem( List<ConnectionSettings> connections, int connectionId, ConnectionGroup connectionGroup )
        {
            InitializeComponent();
            for (int c = 0; c < connections.Count; c++)
                if (!connectionGroup.contains(c) || c == connectionId)
                    cbConnection.Items.Add(connections[c]);
            tbMhz.Text = connectionGroup.mhzStr(connectionId);
            if (connectionId != -1)
                cbConnection.SelectedItem = connections[connectionId];
        }
    }
}
