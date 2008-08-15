using System;
using System.Collections;
using DevExpress.XtraBars.Ribbon;

namespace Osherove.PerfPlus
{
	/// <summary>
	/// Summary description for FocusActionsManager.
	/// </summary>
	public class FocusActionsManager
	{
		public static readonly string KEY_LIBRARY_COUNTER="ribPageLibCounter";
		public static readonly string KEY_LIBRARY_FOLDER="ribPageLibFolder";
//		public static readonly string KEY_ACTIVECOUNTER = "ActiveCounter";
		public static readonly string KEY_ACTIVEMONITOR = "ribPageActiveMonitor";
		public static readonly string KEY_GENERAL = "ribPageGeneral";

		public FocusActionsManager(Hashtable ActionMap)
		{
			actionMap=ActionMap;
		}

		private Hashtable actionMap=null;
		public void ActivateActionsFor(string key)
		{
			ActionActivator action = actionMap[key] as ActionActivator;
			if(action==null)
			{
				throw new InvalidOperationException("Could not find action for key " + key);
			}
			action.Activate();
		}
	
	
		public static Hashtable InitializeMap(RibbonControl ribbon)
		{
			Hashtable hash = new Hashtable();
			foreach (RibbonPage page in ribbon.Pages)
			{
				hash.Add(page.Name,new ActionActivator(page));
			}
			return hash;
		}
		}
	
	public class ActionActivator
	{
		public ActionActivator(RibbonPage page)
		{
			this.page = page;
		}

		private RibbonPage page=null;
		public void Activate()
		{
			if(page==null)
			{
				throw new Exception("you must initialize a page object in the ribbon");
			}
			page.Ribbon.SelectedPage = page;
		}
		
	}
}
