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
    public partial class optionsBoard : UserControl
    {
        List<FolderListing> _folders = new List<FolderListing>();
        bool _changed = false;
        public bool Changed
        {
            get { return _changed; }
        }

        public optionsBoard()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }
        public void InitButtons(List<string> folders)
        {
            foreach (var folder in folders)
            {
                FolderListing listing = new FolderListing(this, folder);
                _folders.Add(listing);
                listing.Location = new Point(10, 10 + (10 + listing.Height) * (_folders.Count - 1));
                Controls.Add(listing);
            }
        }

        public void OnShow()
        {
            _changed = false;
        }
        public void OnHide()
        {

        }

        public void PathChanged()
        {
            _changed = true;
        }

        public void Remove(FolderListing child)
        {
            _changed = true;
            _folders.Remove(child);
            Controls.Remove(child);

            for (int i = 0; i < _folders.Count; i++)
            {
                _folders[i].Location = new Point(10, 10 + (10 + _folders[i].Height) * i);
            }
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            FolderListing listing = new FolderListing(this, "");
            _folders.Add(listing);
            listing.Location = new Point(10, 10 + (10 + listing.Height) * (_folders.Count - 1));
            Controls.Add(listing);
        }

    }
}
