using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraBars.Docking;

namespace Osherove.PerfPlus.UIManagement
{
	public class HistoryUtil
	{
		private const string FILE_COUNTER_LIB = "Counters.xml";
		private const string FILE_LAYOUT = "Layout.xml";
		private const string FILE_TABS = "Tabs.xml";

		public static void SaveCounterLibrary(CounterFolder root)
		{
			Application.DoEvents();
			SaveFolderToStorage(root, FILE_COUNTER_LIB);
			Application.DoEvents();
			
		}

		public static void SaveCounterLibrary(CounterFolder root,string filename)
		{
			try
			{
				root.Save(filename);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		
		public static CounterFolder LoadCounterLibrary()
		{
			return LoadFolderFromStorage(FILE_COUNTER_LIB);
		}

		public static CounterFolder LoadCounterLibrary(string filename)
		{
			try
			{
				return CounterFolder.Load(filename, typeof (CounterFolder)) as CounterFolder;
			}
			catch (Exception e)
			{
				return null;
			}
		}
		
		
		public static void SaveTabs(CounterFolder root)
		{
			SaveFolderToStorage(root, FILE_TABS);
		}

		public static void SaveTabs(CounterFolder root,string filename)
		{
			try
			{
				root.Save(filename);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		
		public static CounterFolder LoadTabs()
		{
			return LoadFolderFromStorage(FILE_TABS);
		}

		public static CounterFolder LoadTabs(string filename)
		{
			try
			{
				return CounterFolder.Load(filename, typeof (CounterFolder)) as CounterFolder;
			}
			catch (Exception e)
			{
				return null;
			}
		}
		
		
		private static CounterFolder LoadFolderFromStorage(string filename)
		{
			try
			{
				using(IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForDomain())
				{
					
					using(IsolatedStorageFileStream stream = 
							  new IsolatedStorageFileStream(filename, FileMode.Open, FileAccess.Read,store))
					{
						CounterFolder loadedFolder=null;
						XmlSerializer serializer = new XmlSerializer(typeof(CounterFolder));
						loadedFolder = serializer.Deserialize(stream) as CounterFolder;
						return loadedFolder;
					}
				}
			}
			catch (Exception e)
			{
				return null;
			}
		}

		private static void SaveFolderToStorage(CounterFolder root, string filename)
		{
			try
			{
				using(IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForDomain())
				{
					using(IsolatedStorageFileStream stream = 
							  new IsolatedStorageFileStream(filename, FileMode.Create, FileAccess.Write,store))
					{
						XmlSerializer serializer = new XmlSerializer(root.GetType());
						Thread.SpinWait(10);
						serializer.Serialize(stream, root);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}


		public static void LoadLayout(DockManager mgr)
		{
			try
			{
				using(IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForDomain())
				{
					
					using(IsolatedStorageFileStream stream = 
							  new IsolatedStorageFileStream(FILE_LAYOUT, FileMode.Open, FileAccess.Read,store))
					{
						mgr.RestoreFromStream(stream);
					}
				}
			}
			catch (FileNotFoundException e)
			{
				return;
			}
			catch (Exception e)
			{
				MessageBox.Show("Could not load docking layout.\n" + e.Message);
			}
		}
		
		public static void SaveLayout(DockManager mgr)
		{
			try
			{
				using(IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForDomain())
				{
					using(IsolatedStorageFileStream stream = 
							  new IsolatedStorageFileStream(FILE_LAYOUT, FileMode.Create, FileAccess.Write,store))
					{
						mgr.SaveLayoutToStream(stream);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Could not save docking layout.\n" + e.Message);
			}
		}
	}
}
