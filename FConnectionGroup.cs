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
    public partial class FConnectionGroup : Form
    {
        public ConnectionGroup connectionGroup;
        private List<ConnectionSettings> _connections;
        private List<int> idxList = new List<int>();
        public FConnectionGroup(ConnectionGroup cg, List<ConnectionSettings> connections)
        {
            InitializeComponent();
            connectionGroup = cg != null ? (ConnectionGroup)cg.Clone() : new ConnectionGroup();
            _connections = connections;
            if (cg != null)
            {
                tbName.Text = cg.name;
                fillList();
                if (lbSet.Items.Count > 0)
                    lbSet.SelectedIndex = 0;
            }
        }

        private void fillList()
        {
            lbSet.Items.Clear();
            idxList.Clear();
            for (int c = 0; c < _connections.Count; c++)
                if (connectionGroup.contains(c))
                {
                    lbSet.Items.Add(_connections[c].name + " - " + connectionGroup.mhzStr(c));
                    idxList.Add(c);
                }

        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (editConnectionGroupEntry(lbSet.SelectedIndex))
            {
                int sel = lbSet.SelectedIndex;
                fillList();
                lbSet.SelectedIndex = sel;
            }

        }

        private bool editConnectionGroupEntry(int sel)
        {
            int connectionId = sel == -1 ? -1 : idxList[sel];
            using (FConnectionGroupItem fCGI = new FConnectionGroupItem(_connections, connectionId, connectionGroup))
                if (fCGI.ShowDialog() == DialogResult.OK)
                {
                    if (sel != -1)
                        connectionGroup.removeConnection(connectionId);
                    connectionId = _connections.IndexOf((ConnectionSettings)fCGI.cbConnection.SelectedItem);
                    fCGI.tbMhz.Text.Split(';').ToList().ForEach(
                        x => connectionGroup.items.Add(new ConnectionGroupEntry { connectionId = connectionId, esMhz = Convert.ToInt32(x) } ) );
                    if ( sel == -1 )
                    {
                        lbSet.Items.Add(_connections[connectionId].name + " - " + connectionGroup.mhzStr(connectionId));
                        idxList.Add(connectionId);
                    }
                    return true;
                }
                else
                    return false;                
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить элемент группы " + lbSet.Items[lbSet.SelectedIndex] + "?",
                "Удаление элемента группы соединений", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int sel = lbSet.SelectedIndex;
                int connectionId = idxList[sel];
                connectionGroup.removeConnection( connectionId );
                lbSet.Items.RemoveAt(sel);
                idxList.RemoveAt(sel);
                if (lbSet.Items.Count > 0)
                {
                    if (sel < lbSet.Items.Count)
                        lbSet.SelectedIndex = sel;
                    else
                        lbSet.SelectedIndex = lbSet.Items.Count - 1;
                }

            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            connectionGroup.name = tbName.Text;
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            editConnectionGroupEntry(-1);
        }
    }
}
