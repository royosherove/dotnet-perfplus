using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SystemMonitor;
using SysMonitor;
using Osherove.PerfPlus.Controls;

namespace Osherove.PerfPlus
{
	/// <summary>
	/// Summary description for CounterInfoHelper.
	/// </summary>
	public class CounterInfoHelper
	{
		public static CounterInfo FromPerfmonCounter(CounterItem item)
		{
			CounterInfo info = new CounterInfo();
			SaveCounterItemInfo(item, info);
			return info;
		}
		
		public static void SaveCounterItemInfo(CounterItem item,CounterInfo info)
		{
			//find bug of short name
//			info.Colornum=(int) item.Color;
//			info.LineStyle= item.LineStyle;
//			info.OriginalPath= item.Path;
//			info.Scale=item.ScaleFactor;
//			info.Width=item.Width;
//			info.Tag= item;
//		
			info.Colornum= int.Parse(item.Color.ToString());
			info.LineStyle= int.Parse(item.LineStyle.ToString());
			string newpath = string.Copy(item.Path);
			info.OriginalPath= newpath;
			
			info.Scale=int.Parse(item.ScaleFactor.ToString());
			info.Width=int.Parse(item.Width.ToString());
			info.Tag= item;
		}
		
		public static void AddCounterItem(CounterInfo info,SysMonitorControlEx monitor)
		{
			CounterItem item = 
				monitor.Counters.Add(info.FinalPath);

			item.Color= (uint) info.Colornum;
			item.LineStyle= info.LineStyle;
//			item.ScaleFactor= info.Scale;
			item.Width= info.Width;
			info.Tag= item;

		}
	}
}
