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
    public partial class FConnectionGroupsList : Form
    {
        FormState state;
        public FConnectionGroupsList(FormState fs)
        {
            InitializeComponent();
            state = fs;
            fillList();
            if ( lbGroups.Items.Count > 0 )
                lbGroups.SelectedIndex = 0;
        }

        private void fillList()
        {
            lbGroups.Items.Clear();
            foreach (ConnectionGroup cg in state.connectionGroups)
                lbGroups.Items.Add(cg.name);

        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            int idx = lbGroups.SelectedIndex;
            if ( editConnectionGroup(state.connectionGroups[idx]) )
            {
                if (state.connectionGroups[idx].name != (string)lbGroups.Items[idx] )
                {
                    fillList();
                    lbGroups.SelectedIndex = idx;
                }
            }
        }

        private bool editConnectionGroup( ConnectionGroup cg)
        {
            using (FConnectionGroup fcg = new FConnectionGroup(cg, state.connections))
                if (fcg.ShowDialog() == DialogResult.OK)
                {
                    if (cg != null)
                        cg = fcg.connectionGroup;
                    else
                    {
                        state.connectionGroups.Add(fcg.connectionGroup);
                        lbGroups.Items.Add(fcg.connectionGroup.name);
                    }
                    ((fMain)Owner).writeConfig();
                    return true;
                }
                else
                    return false;
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить группу " + lbGroups.Items[lbGroups.SelectedIndex] + "?",
                "Удаление группы соединений", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int sel = lbGroups.SelectedIndex;
                state.connectionGroups.RemoveAt(lbGroups.SelectedIndex);
                lbGroups.Items.RemoveAt(lbGroups.SelectedIndex);
                ((fMain)this.Owner).writeConfig();
                if (lbGroups.Items.Count > 0)
                {
                    if (sel < lbGroups.Items.Count)
                        lbGroups.SelectedIndex = sel;
                    else
                        lbGroups.SelectedIndex = lbGroups.Items.Count - 1;
                }

            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            editConnectionGroup(null);
        }
    }
}
