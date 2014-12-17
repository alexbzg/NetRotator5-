﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncRotator
{
    public partial class FConnectionsList : Form
    {
        FormState state;
        public FConnectionsList(FormState fs)
        {
            InitializeComponent();
            state = fs;
            fillList();
            lbConnections.SelectedIndex = 0;
        }

        private void fillList()
        {
            lbConnections.Items.Clear();
            foreach (ConnectionSettings cs in state.connections)
                lbConnections.Items.Add(cs.name);

        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (((fMain)this.Owner).editConnection(state.connections[lbConnections.SelectedIndex]))
            {
                int sel = lbConnections.SelectedIndex;
                fillList();
                lbConnections.SelectedIndex = sel;
            }

        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить соединение " + lbConnections.Items[lbConnections.SelectedIndex] + "?",
                "Удаление соединения", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                state.connections.RemoveAt(lbConnections.SelectedIndex);
                lbConnections.Items.RemoveAt(lbConnections.SelectedIndex);
                ((fMain)this.Owner).writeConfig();
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
