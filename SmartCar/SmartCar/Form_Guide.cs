using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartCar {
    public partial class Form_Guide : Form {
        public Form_Guide() {
            InitializeComponent();
        }

        private bool isStart = false;
        private void btnStart_CheckedChanged(object sender, EventArgs e) {
            
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (!isStart) {
                this.btnStart.Image = SmartCar.Properties.Resources.pause_player_72px_15410_easyicon_net;
                this.btnStart.Text = "暂停";
            }
            else {
                this.btnStart.Image = SmartCar.Properties.Resources.play_player_72px_15907_easyicon_net;
                this.btnStart.Text = "启动";
            }
            isStart = !isStart;
        }
    }
}
