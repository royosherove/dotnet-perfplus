using System;
using System.Threading;
using System.Windows.Forms;
using SysMonitor.Utils;
using Osherove.PerfPlus;

namespace SysMonitor
{
	public  class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
//        	TestSaveCategory();
//            Application.EnableVisualStyles();
        	Thread thread = new Thread(new ThreadStart(RunApp));
			thread.ApartmentState=ApartmentState.STA;
			thread.Start();
        }

		private static void TestSaveCategory()
		{
			CounterFolder cat = new CounterFolder();
			cat.Name="root";
			cat.Description="desc";
	
			CounterInfo info = new CounterInfo();
			info.Description="desc";
			info.OriginalPath="counterName";
			cat.Counterinfos.Add(info);
	
			cat.Save(@"c:\temp\cat.xml");
		}

		[STAThread]
		private static void RunApp()
		{
//			try
//			{
				Application.Run(new MainForm());
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show(ex.ToString());
//				throw;
//			}
				
		}
    }
}