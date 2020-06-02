using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMOD;

namespace musicPlayer
{
    class sound
{
        public sound()
        {
            Factory.System_Create(out m_System);
            m_System.init(1, INITFLAGS.NORMAL, IntPtr.Zero);
            m_IsPaused = true;
        }

        public void Update()
        {
            m_System.update();
        }
        
        public bool IsSoundLoaded() { return m_Channel != null; }
        public bool loadSound(string file)
        {
            float volume = 50;
            if (m_Sound != null)
            {
                if(m_Sound.isValid())
                {
                    m_Channel.getVolume(out volume);
                    m_Sound.release();
                }
            }

            FMOD.RESULT result;
            result = m_System.createSound(file, MODE._2D, out m_Sound);

            if (result == FMOD.RESULT.ERR_FILE_NOTFOUND)
                return false;

            m_System.playSound(m_Sound, null, m_IsPaused, out m_Channel);

            m_Channel.setMode(MODE.LOOP_NORMAL);
            m_Channel.setLoopCount(-1);
            m_Channel.setVolume(volume);
            return true;
        }

        public void playSound()
        {
            m_IsPaused = !m_IsPaused;
            m_Channel.setPaused(m_IsPaused);
        }
        public bool IsPlayingSound()
        {
            return !m_IsPaused;
        }

        public void SetVolume(float volume)
        {
            if (m_Channel == null)
                return;

            if (volume > 1)
                volume = 1;

            m_Channel.setVolume(volume);
        }

        private FMOD.System m_System;
        private FMOD.Sound m_Sound;
        private FMOD.Channel m_Channel;
        private bool m_IsPaused;
    }
}
