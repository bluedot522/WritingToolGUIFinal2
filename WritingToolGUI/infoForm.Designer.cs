namespace WritingToolGUI
{
    partial class infoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblInfoName = new Label();
            btnInfoClose = new Button();
            txtInfoDescription = new TextBox();
            SuspendLayout();
            // 
            // lblInfoName
            // 
            lblInfoName.AutoSize = true;
            lblInfoName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoName.Location = new Point(38, 49);
            lblInfoName.Name = "lblInfoName";
            lblInfoName.Size = new Size(50, 18);
            lblInfoName.TabIndex = 0;
            lblInfoName.Text = "label1";
            lblInfoName.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnInfoClose
            // 
            btnInfoClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnInfoClose.Location = new Point(301, 390);
            btnInfoClose.Name = "btnInfoClose";
            btnInfoClose.Size = new Size(75, 23);
            btnInfoClose.TabIndex = 2;
            btnInfoClose.Text = "Close";
            btnInfoClose.UseVisualStyleBackColor = true;
            btnInfoClose.Click += btnInfoClose_Click;
            // 
            // txtInfoDescription
            // 
            txtInfoDescription.Location = new Point(15, 91);
            txtInfoDescription.Multiline = true;
            txtInfoDescription.Name = "txtInfoDescription";
            txtInfoDescription.ReadOnly = true;
            txtInfoDescription.ScrollBars = ScrollBars.Vertical;
            txtInfoDescription.Size = new Size(361, 257);
            txtInfoDescription.TabIndex = 2;
            // 
            // infoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 450);
            Controls.Add(txtInfoDescription);
            Controls.Add(btnInfoClose);
            Controls.Add(lblInfoName);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(419, 489);
            Name = "infoForm";
            Text = "Information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfoName;
        private Button btnInfoClose;
        private TextBox txtInfoDescription;
    }
}