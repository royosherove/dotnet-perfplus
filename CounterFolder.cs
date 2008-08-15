using System;
using System.Collections;
using System.Windows.Forms;
using System.Xml.Serialization;
using SysMonitor;

namespace Osherove.PerfPlus
{
	/// <summary>
	/// Summary description for CounterFileCategory.
	/// </summary>
	[Serializable]
	public class CounterFolder:SelfSerializer,ICounterData
	{
		
		public CounterFolder()
		{
			//
			counterinfos=new ArrayList();
			subcategories = new ArrayList();
			//
		}

		public override string ToString()
		{
			return Name;
		}

		private string name;
		private string description;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}
		
		[XmlArrayItem("CounterInfo",typeof(CounterInfo))]
		public ArrayList Counterinfos
		{
			get { return counterinfos; }
			set { counterinfos = value; }
		}

		private ArrayList counterinfos=new  ArrayList();

		private ArrayList subcategories=new ArrayList();
		
		[XmlArrayItem("CounterFolder",typeof(CounterFolder))]
		public ArrayList SubFolders
		{
			get { return subcategories; }
			set { subcategories = value; }
		}

		public bool ContainsCounter(CounterInfo info)
		{
			foreach (CounterInfo local in counterinfos)
			{
				if(local.ShortName==info.ShortName && local.OriginalPath!=string.Empty)
				{
					return true;
				}
			}
			return false;
		}


	}
}
