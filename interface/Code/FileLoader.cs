using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace musicPlayer
{
    class FileLoader
{
        private List<string> m_Files = new List<string>();
        public List<string> Files
        {
            get {
                return m_Files;
            }
        }

        public void ReadFolder(string path, string filetype)
        {
            if ((filetype.ElementAt(1) != '.' && filetype.ElementAt(0) != '*') || path == "")
                return;

            m_Files.Clear();
            string[] files = Directory.GetFiles(path,filetype);
            for (int i = 0; i < files.Length; i++)
            {
                m_Files.Add(files.ElementAt(i));
            }
        }
}
}
