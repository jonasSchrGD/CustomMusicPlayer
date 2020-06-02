using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;

namespace musicPlayer
{
	class musicManager
	{
		private List<string> m_Songs = new List<string>();
		private List<string> m_SongNames = new List<string>();
		private List<string> m_Folders = new List<string>();
		public List<string> Folders
		{
			get
			{
				return m_Folders;
			}
		}
		FileLoader m_MusicList;
		static MySqlConnection connection;
		Randomizer r = new Randomizer();
		int m_CurrentSong = -1;

		public musicManager()
		{
			m_MusicList = new FileLoader();
			r.SongPlaying(0);

			OpenSQL();
		}

		public void Reload()
		{
			m_Songs.Clear();
			m_SongNames.Clear();

			LoadAndSyncWithSQL();
		}

		public List<string> GetSongs()
		{
			return m_SongNames;
		}

		public string GetSong(int indx)
		{
			if (indx < 0)
				return null;

			if (indx > m_Songs.Count)
				return null;

			return m_Songs.ElementAt(indx);
		}

		public int Idx
		{
			get
			{
				return m_CurrentSong;
			}
			set
			{
				m_CurrentSong = value;
			}
		}

		public string getPrevSong()
		{
			if(m_Songs.Count > 0)
			{
				m_CurrentSong = (int)r.GetPrev();
				return m_Songs.ElementAt(m_CurrentSong);
			}
			return "";
		}

		public string getNextSong()
		{
			if (m_Songs.Count > 0)
			{
				m_CurrentSong = (int)r.GetNext();
				return m_Songs.ElementAt(m_CurrentSong);
			}
			return "";
		}

		private void OpenSQL()
		{
			connection = new MySqlConnection("server=localhost;userid=root;password=root;database=musicplayer");
			try
			{
				connection.Open();
			}
			catch (Exception)//database is not created
			{
				CreateDatabase();
			}
			LoadAndSyncWithSQL();
		}
		private void CreateDatabase()
		{
			connection = new MySqlConnection("server=localhost;userid=root;password=root");
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText = "create database musicplayer";
			command.ExecuteScalar();

			connection.ChangeDatabase("musicplayer");

			command.CommandText = "create table songs(id INTEGER UNSIGNED AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100), found char(1) default 'n')";
			command.ExecuteScalar();

			command.CommandText = "create table folders(id INTEGER UNSIGNED AUTO_INCREMENT PRIMARY KEY, path VARCHAR(200))";
			command.ExecuteScalar();

			command.CommandText = "create table folderLists(songId INTEGER UNSIGNED, folderId INTEGER UNSIGNED, " +
				"constraint fk_songs_id FOREIGN KEY (songId) REFERENCES songs(id) ON DELETE CASCADE ON UPDATE CASCADE, " +
				"constraint fk_folders_id FOREIGN KEY (folderId) REFERENCES folders(id) ON DELETE CASCADE ON UPDATE CASCADE)";
			command.ExecuteScalar();
		}

		private void LoadAndSyncWithSQL()
		{
			LoadFolders();

			if (m_Songs != null)
				m_CurrentSong = 0;

			ResetIncrement();

			for (int i = 0; i < m_Songs.Count; i++)
			{
				m_SongNames.Add(Path.GetFileName(m_Songs.ElementAt(i)));
			}
			r.SongCount = (uint)m_Songs.Count;
		}

		void LoadFolders()
		{
			var command = connection.CreateCommand();
			command.CommandText = "select count(id) from folders";
			var rowCount = command.ExecuteScalar();

			command.CommandText = "select * from folders";
			MySqlDataReader path = command.ExecuteReader();
			List<int> folderIds = new List<int>();
			while (path.Read())
			{
				m_MusicList.ReadFolder(path.GetString(1), "*.mp3");
				m_Folders.Add(path.GetString(1));
				m_Songs.AddRange(m_MusicList.Files);
				folderIds.Add(path.GetInt32(0));
			}
			path.Close();
			foreach (var id in folderIds)
			{
				LoadSongs(id);
			}

			command.CommandText = "delete from songs where found='n'";
			command.ExecuteScalar();

			command.CommandText = "update songs set found='n'";
			command.ExecuteScalar();
		}
		void LoadSongs(int pathId)
		{
			var command = connection.CreateCommand();
			for (int i = 0; i < m_MusicList.Files.Count; i++)
			{
				string songName = Path.GetFileName(m_MusicList.Files.ElementAt(i));

				songName = songName.Replace("'", "\\'");

				command.CommandText = "select * from songs where name = '" + songName + "'";
				var obj = command.ExecuteScalar();

				if (obj == null)
				{
					command.CommandText = "insert into songs(name, found) values ('" + songName + "', 'y')";
					command.ExecuteScalar();

					command.CommandText = "insert into folderLists(songId, folderId) values ('" + command.LastInsertedId + "','" + pathId + "')";
					command.ExecuteScalar();
				}
				else
				{
					command.CommandText = "update songs set found = 'y' where id = " + obj;
					command.ExecuteScalar();
				}
			}
		}
		public static void SaveFolder(string musicPath)
		{
			if (connection == null)
				return;

			musicPath = musicPath.Replace("\\", "//");

			var command = connection.CreateCommand();
			command.CommandText = "select * from folders where path = '" + musicPath + "'";
			object path = command.ExecuteScalar();

			if(path == null)
			{
				command.CommandText = "insert into folders(path) values ('" + musicPath + "')";
				command.ExecuteScalar();
			}
		}
		public static void RemoveFolder(string musicPath)
		{
			if (connection == null)
				return;

			musicPath = musicPath.Replace("\\", "//");
			
			var command = connection.CreateCommand();
			command.CommandText = "delete from folders where path = '" + musicPath + "'";
			command.ExecuteScalar();
		}

		void ResetIncrement()
		{
			var command = connection.CreateCommand();
			command.CommandText = "SELECT MAX( id ) FROM songs";
			var max = command.ExecuteScalar();
			var type = max.GetType();

			if (type != typeof(DBNull))
				command.CommandText = "ALTER TABLE songs AUTO_INCREMENT = " + ((uint)max + 1);
			else
				command.CommandText = "ALTER TABLE songs AUTO_INCREMENT = " + 1;
			command.ExecuteScalar();
		}
	}
}
