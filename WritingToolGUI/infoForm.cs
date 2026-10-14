using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WritingToolGUI
{
    public partial class infoForm : Form
    {
        public infoForm(Item item, int index)
        {
            InitializeComponent();
            lblInfoName.Text = item.Name;
            txtInfoDescription.Text = item.Description;
            
        }

       
        private void btnInfoClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
