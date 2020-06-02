using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicPlayer
{
    public partial class FolderListing : UserControl
    {
        optionsBoard _OptionsBoard;

        public FolderListing(optionsBoard parent, string path)
        {
            _OptionsBoard = parent;
            InitializeComponent();
            textBox1.Text = path;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Ookii.Dialogs.WinForms.VistaFolderBrowserDialog fileDialog = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog();

            fileDialog.SelectedPath = textBox1.Text;
            fileDialog.ShowDialog();

            musicManager.RemoveFolder(textBox1.Text);
            musicManager.SaveFolder(fileDialog.SelectedPath);

            if (fileDialog.SelectedPath != textBox1.Text)
                _OptionsBoard.PathChanged();

            textBox1.Text = fileDialog.SelectedPath;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            musicManager.RemoveFolder(textBox1.Text);
            _OptionsBoard.Remove(this);
        }
    }
}
