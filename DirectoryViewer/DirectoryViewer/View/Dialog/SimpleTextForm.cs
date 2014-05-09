using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirectoryViewer.View.Dialog
{
    public partial class SimpleTextForm : Form
    {
        public SimpleTextForm(string caption, string defaultText = "")
        {
            InitializeComponent();

            Text = caption;
            tbxInput.Text = defaultText;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string GetText()
        {
            return tbxInput.Text;
        }

        private void tbxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
