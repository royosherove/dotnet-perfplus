using System;
using System.Windows.Forms;
using SysMonitor;
using Osherove.PerfPlus.Controls;

namespace Osherove.PerfPlus
{
	public class SysMonitorHelper
	{
		private CounterTree tv=null;

		public CounterTree Tv
		{
			get { return tv; }
			set { tv = value; }
		}

		private SysMonitorControlEx monitor=null;
		public SysMonitorControlEx Monitor
		{
			get
			{
				RefreshActiveMonitor();
				return monitor;
			}
		}

		
		public delegate void RequestSysMonitorObjectDelegate(out SysMonitorControlEx RequiredMonitor);
		public event RequestSysMonitorObjectDelegate RequestSysMonitorObject;

		private void RefreshActiveMonitor()
		{
			if(RequestSysMonitorObject==null)
			{
				throw new Exception("You must register for the RequestMonitorObject event for Counter Tree to work properly");
			}
			
			RequestSysMonitorObject(out monitor);
			if(monitor==null)
			{
				throw new InvalidOperationException("you must pass an active SysMonitor object");
			}
		}
		

		public void AddFolderCountersToMonitor(CounterFolder folder)
		{
			Monitor.FindForm().Text = folder.Name;
			foreach (CounterInfo info in folder.Counterinfos)
			{
				AddCounterToMonitor(info);
			}
			foreach (CounterFolder subFolder in folder.SubFolders)
			{
				AddFolderCountersToMonitor(subFolder);
			}
		}

		private void AddCounterToMonitor(CounterInfo info)
		{
			CounterInfoHelper.AddCounterItem(info, Monitor);
		}


//		private bool isInCall=false;
		public void ClearCounters()
		{
			if(Monitor==null)
			{
				return;
			}
			int count = Monitor.Counters.Count;
			for (int i = 0; i < count; i++)
			{
				Monitor.Counters.Remove(1);
			}
            
		}

		public void ActivateCountersFromObject(object tag)
		{
			ClearCounters();
			if(tag ==null)
			{
				return;
			}
			if(tag is CounterFolder)
			{
				CounterFolder folder = tag as CounterFolder;
				AddFolderCountersToMonitor(folder);
			}
			
			if(tag is CounterInfo)
			{
			
				CounterInfo info = tag as CounterInfo;
				AddCounterToMonitor(info);
			}
		}
		
		public SysMonitorHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
