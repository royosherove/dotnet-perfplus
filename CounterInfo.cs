using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using SysMonitor;
using Osherove.PerfPlus;

namespace SysMonitor
{
	/// <summary>
	/// Summary description for CounterInfo.
	/// </summary>
	[Serializable]
	public class CounterInfo:SelfSerializer,ICounterData
	{
		private string orgPath=string.Empty;
		private string description=String.Empty;
		private int colornum;

		public string ShortName
		{
			get
			{
				if(orgPath==null)
				{
					return string.Empty;
				}
				if(orgPath!=null && !orgPath.StartsWith(@"\\"))
				{
					return OriginalPath.TrimStart('\\');
				}
				else
				{
					string shorterName = OriginalPath.Substring(2);
					string removedMachineName = shorterName.Substring(shorterName.IndexOf("\\"));
					return removedMachineName.TrimStart('\\');
				
				}
			}
		}
		

		private string ReplaceTargetInstance(string input)
		{
			if(targetInstance==string.Empty)
			{
				return input;
			}
			string pattern = @"\((?<Instance>.+)\)";
			string replace = Regex.Replace(input,pattern,"("+ targetInstance +")");
			
			return replace;
		}
		public string FinalPath
		{
			get
			{
				return machine + '\\' + ShortName;
			}
		}

		public string Machine
		{
			get { return machine; }
			set { machine = value; }
		}

		private string machine=string.Empty;
		public int LineStyle
		{
			get { return lineStyle; }
			set { lineStyle = value; }
		}

		private int lineStyle;


		public int Colornum
		{
			get { return colornum; }
			set { colornum = value; }
		}

		public int Width
		{
			get { return width; }
			set { width = value; }
		}

		public int Scale
		{
			get { return scale; }
			set { scale = value; }
		}

		private string targetInstance=string.Empty;

		public string TargetInstance
		{
			get { return targetInstance; }
			set { targetInstance = value; }
		}

		public CounterInfo()
		{
		}

		private int width;
		private int scale;

		public string dUPE
		{
			get
			{
				return dupe;
			}
			set { dupe = value; }
		}

		public string OriginalPath
		{
			get
			{
//				return orgPath;
				return ReplaceTargetInstance(orgPath);
			}
			set
			{
				orgPath = value;
			}
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		[XmlIgnore]
		public object Tag
		{
			get { return tag; }
			set { tag = value; }
		}

		private object tag;
		private string dupe;
	}
}
