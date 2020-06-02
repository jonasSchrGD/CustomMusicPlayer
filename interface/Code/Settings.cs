using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace musicPlayer
{
    class Settings
    {
        private static Settings m_Settings;
        public static Settings settings
        {
            get
            {
                if (m_Settings == null)
                    m_Settings = new Settings();

                return m_Settings;
            }
        }

        public RandomizeType RandomizeType = RandomizeType.None;
        public bool NextRandom = false;
        public bool ReloadSongs = false;

        public Color PanelColor = Color.Gray;
        public Color SidePanelColor = Color.DimGray;
        public Color BottomBarColor = Color.DimGray;
    }
}
