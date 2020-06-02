using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace musicPlayer
{
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();
        }

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            playPauseAction?.Invoke();
        }
        private void PrevButton_Click(object sender, EventArgs e)
        {
            prevAction?.Invoke();
        }
        private void skipButton_Click(object sender, EventArgs e)
        {
            nextAction?.Invoke();
        }

        public float GetVolume()
        {
            return customTrackBar1.Value;
        }

        public void SetPrevButtonAction(Func<int> func)
        {
            prevAction = func;
        }
        public void SetNextButtonAction(Func<int> func)
        {
            nextAction = func;
        }
        public void SetPlayPauseButtonAction(Func<int> func)
        {
            playPauseAction = func;
        }

        public void ReloadList(ref List<string> songs)
        {
            listBox1.Items.Clear();

            for (int i = 0; i < songs.Count; ++i)
            {
                listBox1.Items.Add(songs[i]);
            }
        }
        public void SetSelectedSong(int idx)
        {
            if (idx > -1 && idx < listBox1.Items.Count)
                listBox1.SelectedIndex = idx;
        }

        private Func<int> prevAction;
        private Func<int> playPauseAction;
        private Func<int> nextAction;

        private void ListBox1_Click(object sender, System.EventArgs e)
        {
            newSongSelected?.Invoke(listBox1.SelectedIndex);
        }

        private Func<int, int> newSongSelected;
        public Func<int, int> UpdateSongIdx
        {
            set
            {
                newSongSelected = value;
            }
        }
    }
}
