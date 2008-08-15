using System;
using System.Windows.Forms;
using SystemMonitor;

namespace Osherove.PerfPlus.Controls
{
	/// <summary>
	/// Summary description for SysMonitorControlEx.
	/// </summary>
	public class SysMonitorControlEx:AxSystemMonitor.AxSystemMonitor, IActionable
	{
		protected override void Dispose(bool disposing)
		{
//			base.Dispose(disposing);
		}
		
		protected override void WndProc(ref Message m)
		{
			if((m.Msg == 0xa1 || m.Msg == 0x201) )
			{
				FocusActions();
				return;
			}
			base.WndProc (ref m);
		}


		private int lastSelectedIndex=0;
		private FocusActionsManager focusmanager;

		public SysMonitorControlEx()
		{
			this.OnCounterSelected+=new AxSystemMonitor.DISystemMonitorEvents_OnCounterSelectedEventHandler(SysMonitorControlEx_OnCounterSelected);
			this.GotFocus+=new EventHandler(SysMonitorControlEx_GotFocus);
			this.LostFocus+=new EventHandler(SysMonitorControlEx_LostFocus);
			
		}

		private void SysMonitorControlEx_OnCounterSelected(object sender, AxSystemMonitor.DISystemMonitorEvents_OnCounterSelectedEvent e)
		{
			lastSelectedIndex =e.iIndex;
			FocusActions();
		}

		private void FocusActions()
		{
			focusmanager.ActivateActionsFor(FocusActionsManager.KEY_ACTIVEMONITOR);
		}

		public CounterItem SelectedCounter
		{
			get
			{
				if(lastSelectedIndex==0)
				{
					return null;
				}
				return Counters[lastSelectedIndex];
			}	
		}
		const int DEFAULT_SCALE = 2147483647;

		public void ScaleUp()
		{
			if(SelectedCounter==null)
			{
				return;
			}
			if(SelectedCounter.ScaleFactor==DEFAULT_SCALE)
			{
				SelectedCounter.ScaleFactor=1;
			}

			try
			{
				SelectedCounter.ScaleFactor++;
				Refresh();
			}
			catch (Exception e)
			{
//#if DEBUG
//				MessageBox.Show(FindForm(), e.ToString());
//#endif
			}
		}


		public void ScaleDown()
		{
			if(SelectedCounter==null)
			{
				return;
			}
			if(SelectedCounter.ScaleFactor==DEFAULT_SCALE)
			{
				SelectedCounter.ScaleFactor=1;
			}

			try
			{
				SelectedCounter.ScaleFactor--;
				Refresh();
			}
			catch (Exception e)
			{
				
			}
		}
		#region IActionable Members

		public FocusActionsManager FocusManager
		{
			get
			{
				// TODO:  Add SysMonitorControlEx.FocusManager getter implementation
				return focusmanager;
			}
			set
			{
				focusmanager=value;
			}
		}

		#endregion

		private void SysMonitorControlEx_Click(object sender, EventArgs e)
		{
//			focusmanager.ActivateActionsFor(KEY_ACTIVEMONITOR);
		}

		private void SysMonitorControlEx_GotFocus(object sender, EventArgs e)
		{
			focusmanager.ActivateActionsFor(FocusActionsManager.KEY_ACTIVEMONITOR);

		}

		private void SysMonitorControlEx_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			focusmanager.ActivateActionsFor(FocusActionsManager.KEY_ACTIVEMONITOR);
		}

		
		private void SysMonitorControlEx_LostFocus(object sender, EventArgs e)
		{

		}
	}
}
