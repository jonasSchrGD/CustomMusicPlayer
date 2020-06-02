using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;

namespace musicPlayer
{
    public partial class Form1 : Form
    {
        musicManager m_MusicManager = new musicManager();
        sound m_Sound = new sound();

        public Form1()
        {
            InitializeComponent();
            InitTimer();

            comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
            comboBox1.SelectedItem = comboBox1.Items[3];

            optionsBoard1.Hide();
            optionsBoard1.InitButtons(m_MusicManager.Folders);

            player.SetPrevButtonAction(PrevButton);
            player.SetPlayPauseButtonAction(PlayPauseButton);
            player.SetNextButtonAction(NextButton);

            List<string> songs = m_MusicManager.GetSongs();
            player.ReloadList(ref songs);
            player.UpdateSongIdx = ReloadSong;
            optionsButton.Click += OptionsButton_Click;
            homeButton.Click += HomeButton_Click;
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((string)comboBox1.SelectedItem == "random")
            {
                Settings.settings.RandomizeType = RandomizeType.Random;
            }
            if ((string)comboBox1.SelectedItem == "fisher-yates shuffle")
            {
                Settings.settings.RandomizeType = RandomizeType.FisherYatesShuffle;
            }
            if ((string)comboBox1.SelectedItem == "shuffle")
            {
                Settings.settings.RandomizeType = RandomizeType.Shuffle;
            }
            if ((string)comboBox1.SelectedItem == "none")
            {
                Settings.settings.RandomizeType = RandomizeType.None;
            }
        }

        private void InitTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(UpdateMusic);
            timer.Interval = 16;
            timer.Enabled = true;
            timer.Start();
        }

        private void UpdateMusic(object sender, ElapsedEventArgs e)
        {
            float value = player.GetVolume();
            m_Sound.SetVolume(value);
            m_Sound.Update();
        }

        private void HomeButton_Click(object sender, System.EventArgs e)
        {
            optionsBoard1.OnHide();
            optionsBoard1.Hide();
            player.Show();

            if (optionsBoard1.Changed)
            {
                m_MusicManager.Reload();
                List<string> songs = m_MusicManager.GetSongs();
                player.ReloadList(ref songs);

                if (m_Sound.IsPlayingSound())
                    m_Sound.playSound();
            }

            homeButton.BackColor = Color.Gray;
            optionsButton.BackColor = Color.DimGray;
        }
        private void OptionsButton_Click(object sender, System.EventArgs e)
        {
            player.Hide();
            optionsBoard1.OnShow();
            optionsBoard1.Show();

            homeButton.BackColor = Color.DimGray;
            optionsButton.BackColor = Color.Gray;
        }

        int PrevButton()
        {
            m_Sound.loadSound(m_MusicManager.getPrevSong());
            player.SetSelectedSong(m_MusicManager.Idx);
            return 0;
        }
        int PlayPauseButton()
        {
            m_Sound.loadSound(m_MusicManager.GetSong(m_MusicManager.Idx));
            player.SetSelectedSong(m_MusicManager.Idx);

            if (m_Sound.IsSoundLoaded())
                m_Sound.playSound();
            return 0;
        }
        int NextButton()
        {
            m_Sound.loadSound(m_MusicManager.getNextSong());
            player.SetSelectedSong(m_MusicManager.Idx);
            return 0;
        }

        int ReloadSong(int newIdx)
        {
            m_MusicManager.Idx = newIdx;
            m_Sound.loadSound(m_MusicManager.GetSong(newIdx));
            return 0;
        }
    }
}