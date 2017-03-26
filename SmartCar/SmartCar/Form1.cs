using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartCar {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            initMForms();
        }

        /// <summary>
        /// 初始化三个窗口
        /// </summary>
        public static Form[] MForms;
        public void initMForms() {
            MForms = new Form[] {
                new Form_Guide(),
                new Form_Path(),
                new Form_Param()
            };
            for (int i = 0; i < MForms.Length; ++i) {
                MForms[i].Visible = true;
                MForms[i].TopLevel = false;
                MForms[i].Location = new Point(0, 0);
            }
        }

        private void btnGuide_Click(object sender, EventArgs e) {
            this.panelShow.Controls.Clear();
            this.panelShow.Controls.Add(MForms[0]);
        }
        private void btnPath_Click(object sender, EventArgs e) {
            this.panelShow.Controls.Clear();
            this.panelShow.Controls.Add(MForms[1]);
        }
        private void btnParam_Click(object sender, EventArgs e) {
            this.panelShow.Controls.Clear();
            this.panelShow.Controls.Add(MForms[2]);
        }

        /// <summary>
        /// 窗口大小改变时，设定子窗口大小变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelShow_Resize(object sender, EventArgs e) {
            for (int i = 0; i < MForms.Length; ++i) {
                MForms[i].Width = this.panelShow.Width;
                MForms[i].Height = this.panelShow.Height;
            }
        }

        

        



    }
}
