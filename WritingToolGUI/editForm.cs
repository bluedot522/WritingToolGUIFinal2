using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WritingToolGUI
{
    public partial class editForm : Form
    {
        public editForm()
        {
            InitializeComponent();
            btnEditSubmit.Enabled = false;

        }

        public editForm(string type)
        {
            InitializeComponent();
            Text = "Add " + type;
            itemType = type;
            btnEditSubmit.Enabled = false;
            chkArchive.Visible = false;
            btnDelete.Visible = false;

        }

        public editForm(Item item, int itemIndex)
        {
            InitializeComponent();
            txtEditName.Text = item.Name;
            txtEditDescription.Text = item.Description;
            txtEditTags.Text = string.Join(", ", item.Tags);
            currentItem = item;
            btnEditSubmit.Enabled = false;

        }

        public static string editName;
        public static string editDescription;

        public static List<string> editTags = new List<string>();

        public static string itemType;
        public static Item currentItem;
        private void btnEditSubmit_Click(object sender, EventArgs e)
        {
            SubmitInfo();

            Close();
        }

        private void editForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void SubmitInfo()
        {

            if (chkArchive.Visible == true && chkArchive.Checked == true)
            {
                currentItem.Status = "Archived";
            }
            else
            {

                editName = txtEditName.Text;
                editDescription = txtEditDescription.Text;
                editTags = new List<string>(txtEditTags.Text.Split(','));
                
            }

            Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            currentItem.Status = "Deleted";
            Close();
        }

        private void txtEditName_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEditName.Text))
            {
                btnEditSubmit.Enabled = true;
            }
        }

        private void txtEditName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEditName.Text))
            {
                btnEditSubmit.Enabled = true;
            }
        }

        private void txtEditName_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEditName.Text))
            {
                btnEditSubmit.Enabled = true;
            }
        }
    }
}
