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
    public partial class FSetNorth : Form
    {
        public Dictionary<int,int> stopAngles = new Dictionary<int,int> { {-1, -1 }, {1,-1}};
        public int northAngle = -1;
        public FSetNorth()
        {
            InitializeComponent();
        }

        private void bRotate0_MouseDown(object sender, MouseEventArgs e)
        {
            ((fMain)this.Owner).engine(1);
        }

        private void bRotate_MouseUp(object sender, MouseEventArgs e)
        {
            ((fMain)this.Owner).engine(0);            
        }

        private void bRotate1_MouseDown(object sender, MouseEventArgs e)
        {
            ((fMain)this.Owner).engine(-1);
        }

        private void bStop0_Click(object sender, EventArgs e)
        {
            stopAngles[1] = ((fMain)this.Owner).getCurrentAngle();
        }

        private void bNorth_Click(object sender, EventArgs e)
        {
            northAngle = ((fMain)this.Owner).getCurrentAngle();
        }

        private void bStop1_Click(object sender, EventArgs e)
        {
            stopAngles[-1] = ((fMain)this.Owner).getCurrentAngle();
        }
       
        private void bDeleteStops_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сбросить настройки концевиков?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
//                ((fMain)this.Owner).clearStops();
        }
    }
}
