using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using SysMonitor;

namespace Osherove.PerfPlus.Controls
{
	/// <summary>
	/// Summary description for CounterManager.
	/// </summary>
	public class CounterManager : UserControl
	{
		private ImageList lstToolBar;
		private CounterTree tv;
		private BarManager barManager1;
		private BarDockControl barDockControlTop;
		private BarDockControl barDockControlBottom;
		private BarDockControl barDockControlLeft;
		private BarDockControl barDockControlRight;
		private Bar bar1;
		private BarSubItem barSubItem1;
		private BarButtonItem barButtonItem1;
		private BarButtonItem barButtonItem2;
		private BarButtonItem barButtonItem3;
		private BarButtonItem barButtonItem4;
		private BarButtonItem barButtonItem6;
		private ImageCollection imageCollection1;
		private IContainer components;

		public CounterManager()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code

		private SysMonitorHelper sysMonHelper=null;

		public SysMonitorHelper SysMonHelper
		{
			get { return sysMonHelper; }
			set 
			{ 
				sysMonHelper = value;
				tv.SysMonHelper= value;
			}
		}

		public CounterFolder MasterFolder
		{
			get { return tv.MasterFolder; }
			set { tv.MasterFolder = value; }
		}

		public CounterInfo TreeSelectedCounter
		{
			get { return tv.TreeSelectedCounter; }
		}

		public CounterFolder TreeSelectedFolder
		{
			get { return tv.TreeSelectedFolder; }
		}

		public TreeNode TreeSelectedFolderNode
		{
			get { return tv.TreeSelectedFolderNode; }
		}
		private void FindNodeInTree(ICounterData dataObject)
		{
			foreach (TreeNode node in tv.Nodes)
			{
				if(node.Tag==dataObject)
				{
					tv.SelectedNode= node;
					node.EnsureVisible();
					return;
				}
			}
		}

		public CounterTree.ActivateNewTabDelegate ActivateNewTabCallback
		{
			get { return tv.ActivateNewTabCallback; }
			set
			{ tv.ActivateNewTabCallback= value; }
		}

		public void ActivateDefaultNode()
		{
			if(tv.Nodes.Count>0)
			{
				tv.SelectedNode= tv.Nodes[0];
				ActivateFromTreeView();
			}
		}

		private void ActivateFromTreeView()
		{
			if(tv.SelectedNode==null)
			{
				return;
			}
			sysMonHelper.ActivateCountersFromObject(tv.SelectedNode.Tag);
		}

		public void SaveCounters(string filename)
		{
			CounterFolder root = MasterFolder;
			root.Save(filename);
		}

		
		public void DeleteSelectedNode()
		{
			tv.DeleteSelectedNode();
		}

		public void FillTree(CounterFolder root, TreeNode parentNode)
		{
			tv.AddFolderToTreeRecursive(root, parentNode);
		}

		public TreeNode AddFolderToTree(TreeNode parentNode, CounterFolder folder)
		{
			return tv.AddFolderToTree(parentNode, folder);
		}

		public void AddExistingCountersToTree()
		{
			tv.AddExistingCountersToTree(sysMonHelper.Monitor);
		}

		public void LoadDefaultCounters()
		{
			tv.LoadDefaultCounters();
		}

		public void InsertNewSubFolder()
		{
			tv.InsertNewSubFolder();
		}

		public void InsertNewRootFolder()
		{
			tv.InsertNewRootFolder();
		}

		public void LoadCounters(string file)
		{
			tv.LoadCounters(file);
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CounterManager));
			this.lstToolBar = new System.Windows.Forms.ImageList(this.components);
			this.tv = new Osherove.PerfPlus.Controls.CounterTree();
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
			this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
			this.SuspendLayout();
			// 
			// lstToolBar
			// 
			this.lstToolBar.ImageSize = new System.Drawing.Size(16, 16);
			this.lstToolBar.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// tv
			// 
			this.tv.ActivateNewTabCallback = null;
			this.tv.BackColor = System.Drawing.Color.Gainsboro;
			this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tv.FocusManager = null;
			this.tv.LabelEdit = true;
			this.tv.Location = new System.Drawing.Point(0, 22);
			this.tv.MasterFolder = null;
			this.tv.Name = "tv";
			this.tv.Size = new System.Drawing.Size(352, 298);
			this.tv.SysMonHelper = null;
			this.tv.TabIndex = 1;
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
																			 this.bar1});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Images = this.imageCollection1;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
																				  this.barSubItem1,
																				  this.barButtonItem1,
																				  this.barButtonItem2,
																				  this.barButtonItem3,
																				  this.barButtonItem4,
																				  this.barButtonItem6});
			this.barManager1.MaxItemId = 7;
			// 
			// bar1
			// 
			this.bar1.BarName = "barActions";
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.FloatLocation = new System.Drawing.Point(229, 161);
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																							  new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, DevExpress.XtraBars.BarItemPaintStyle.Standard),
																							  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
																							  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
																							  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
																							  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
			this.bar1.OptionsBar.AllowDelete = true;
			this.bar1.OptionsBar.AllowQuickCustomization = false;
			this.bar1.OptionsBar.DisableClose = true;
			this.bar1.OptionsBar.DisableCustomization = true;
			this.bar1.OptionsBar.DrawDragBorder = false;
			this.bar1.OptionsBar.UseWholeRow = true;
			this.bar1.Text = "Actions";
			// 
			// barButtonItem4
			// 
			this.barButtonItem4.Caption = "&Delete Folder";
			this.barButtonItem4.Id = 4;
			this.barButtonItem4.ImageIndex = 1;
			this.barButtonItem4.Name = "barButtonItem4";
			// 
			// barButtonItem2
			// 
			this.barButtonItem2.Caption = "Create &Sub Folder";
			this.barButtonItem2.Id = 2;
			this.barButtonItem2.ImageIndex = 2;
			this.barButtonItem2.Name = "barButtonItem2";
			// 
			// barButtonItem1
			// 
			this.barButtonItem1.Caption = "Create &Root Folder";
			this.barButtonItem1.Id = 1;
			this.barButtonItem1.ImageIndex = 0;
			this.barButtonItem1.Name = "barButtonItem1";
			// 
			// barButtonItem3
			// 
			this.barButtonItem3.Caption = "-";
			this.barButtonItem3.Id = 3;
			this.barButtonItem3.Name = "barButtonItem3";
			// 
			// barButtonItem6
			// 
			this.barButtonItem6.Caption = "&Read counters from active monitor";
			this.barButtonItem6.Id = 6;
			this.barButtonItem6.ImageIndex = 3;
			this.barButtonItem6.Name = "barButtonItem6";
			// 
			// imageCollection1
			// 
			this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
			// 
			// barSubItem1
			// 
			this.barSubItem1.Caption = "&Predefined Counters";
			this.barSubItem1.Id = 0;
			this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									 new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
																									 new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
																									 new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
																									 new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
																									 new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
			this.barSubItem1.Name = "barSubItem1";
			// 
			// CounterManager
			// 
			this.Controls.Add(this.tv);
			this.Controls.Add(this.barDockControlTop);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Name = "CounterManager";
			this.Size = new System.Drawing.Size(352, 320);
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
