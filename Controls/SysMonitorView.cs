using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using SystemMonitor;
using Microsoft.VisualBasic;
using SysMonitor;

namespace Osherove.PerfPlus.Controls
{
	/// <summary>
	/// Summary description for SysMonitorView.
	/// </summary>
	public class SysMonitorView : UserControl
	{
		private ContextMenu tabMenu;
		private MenuItem menuItem14;
		private MenuItem menuItem13;
		private MenuItem mnuCloseActive;
		private MenuItem mnuCloseOther;
		private MenuItem mnuCloseAll;
		private MenuItem mnuRename;
		private System.Windows.Forms.TabPage tabPage1;
		private AxSystemMonitor.AxSystemMonitor axSystemMonitor1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TabControl tabs;
		private System.ComponentModel.IContainer components;

		public SysMonitorView()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.Load+=new EventHandler(SysMonitorView_Load);
		}

		public CounterFolder GetAllCountersAsFolderHierarchy()
		{
			CounterFolder root = new CounterFolder();

			foreach (TabPage tabPage in tabs.TabPages)
			{
				if(tabPage.Text==	 "Default")
					continue;

				CounterFolder subFolder = new CounterFolder();
				subFolder.Name=tabPage.Text;
				AxSystemMonitor.AxSystemMonitor tabMon = tabPage.Controls[0] as AxSystemMonitor.AxSystemMonitor;
				foreach (CounterItem item in tabMon.Counters)
				{
					CounterInfo itemInfo = CounterInfoHelper.FromPerfmonCounter(item);
					subFolder.Counterinfos.Add(itemInfo);
				}
				root.SubFolders.Add(subFolder);
			}
			return root;
		}

		public SysMonitorControlEx ActiveMonitorControl
		{
			get
			{
				if(tabs.SelectedTab==null || tabs.SelectedTab.Controls.Count==0)
				{
					return null;
				}
				return (SysMonitorControlEx) tabs.SelectedTab.Controls[0];
			}
		}

		

		private void SetActivateTabTitle(object tag)
		{
			if(tag == null || tabs.TabPages.Count==0)
			{
				return;
			}
			if(tag is CounterFolder)
			{
				CounterFolder folder = tag as CounterFolder;
				tabs.SelectedTab.Text = folder.Name;
			}
			
			if(tag is CounterInfo)
			{
				CounterInfo info = tag as CounterInfo;
				tabs.SelectedTab.Text = info.ShortName;
			}
		}

		public void LoadTabs(string countersFile)
		{
			if(!File.Exists(countersFile))
			{
				return;
			}
			CounterFolder tabFolder = (CounterFolder)CounterFolder.Load(countersFile,typeof(CounterFolder));
			if(tabFolder.SubFolders.Count==0)
			{
				return;
			}
			foreach (CounterFolder subFolder in tabFolder.SubFolders)
			{
				AddNewMonitorTab(subFolder.Name);
				sysMonHelper.AddFolderCountersToMonitor(subFolder);
			}
		}

		public void SaveTabs(string filename)
		{
			CounterFolder root = GetAllCountersAsFolderHierarchy();
			root.Save(filename);
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
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SysMonitorView));
			this.tabMenu = new System.Windows.Forms.ContextMenu();
			this.mnuCloseActive = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.mnuCloseOther = new System.Windows.Forms.MenuItem();
			this.mnuCloseAll = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.mnuRename = new System.Windows.Forms.MenuItem();
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.axSystemMonitor1 = new AxSystemMonitor.AxSystemMonitor();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabs.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axSystemMonitor1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabMenu
			// 
			this.tabMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuCloseActive,
																					this.menuItem14,
																					this.mnuCloseOther,
																					this.mnuCloseAll,
																					this.menuItem13,
																					this.mnuRename});
			// 
			// mnuCloseActive
			// 
			this.mnuCloseActive.DefaultItem = true;
			this.mnuCloseActive.Index = 0;
			this.mnuCloseActive.Text = "&Close Tab";
			this.mnuCloseActive.Click += new System.EventHandler(this.mnuCloseActiveClick);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 1;
			this.menuItem14.Text = "-";
			// 
			// mnuCloseOther
			// 
			this.mnuCloseOther.Index = 2;
			this.mnuCloseOther.Text = "Close &Other Tabs";
			this.mnuCloseOther.Click += new System.EventHandler(this.mnuCloseOtherClick);
			// 
			// mnuCloseAll
			// 
			this.mnuCloseAll.Index = 3;
			this.mnuCloseAll.Text = "Close &All Tabs";
			this.mnuCloseAll.Click += new System.EventHandler(this.mnuCloseAllClick);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 4;
			this.menuItem13.Text = "-";
			// 
			// mnuRename
			// 
			this.mnuRename.Index = 5;
			this.mnuRename.Text = "&Rename...";
			this.mnuRename.Click += new System.EventHandler(this.mnuRenameClick);
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.tabPage1);
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.Location = new System.Drawing.Point(0, 0);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(432, 384);
			this.tabs.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.axSystemMonitor1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(424, 358);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Sample";
			// 
			// axSystemMonitor1
			// 
			this.axSystemMonitor1.ContainingControl = this;
			this.axSystemMonitor1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axSystemMonitor1.Enabled = true;
			this.axSystemMonitor1.Location = new System.Drawing.Point(0, 0);
			this.axSystemMonitor1.Name = "axSystemMonitor1";
			this.axSystemMonitor1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSystemMonitor1.OcxState")));
			this.axSystemMonitor1.Size = new System.Drawing.Size(424, 358);
			this.axSystemMonitor1.TabIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// SysMonitorView
			// 
			this.Controls.Add(this.tabs);
			this.Name = "SysMonitorView";
			this.Size = new System.Drawing.Size(432, 384);
			this.Load += new System.EventHandler(this.SysMonitorView_Load_1);
			this.tabs.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axSystemMonitor1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void tabs_SelectedIndexChanged(object sender, EventArgs e)
		{
		
		}

		private void SysMonitorView_Load(object sender, EventArgs e)
		{
			if(DesignMode)
			{
				return;
			}
			tabs.TabPages.Clear();
		}


		private SysMonitorHelper sysMonHelper=null;

		public SysMonitorHelper SysMonHelper
		{
			get { return sysMonHelper; }
			set { sysMonHelper = value; }
		}

		public	void AddNewMonitorTab(string title)
		{
			TabPage tab = new TabPage(title);
			tab.Visible=true;
			SysMonitorControlEx mon = new SysMonitorControlEx();
			tab.Controls.Add(mon);
			mon.Dock=DockStyle.Fill;
			mon.ContextMenu= tabMenu;
			mon.Visible=true;
			mon.ContainingControl=this;
			
			tabs.TabPages.Add(tab);

			tabs.SelectedTab=tab;
			mon.Highlight=true;
			mon.ShowHorizontalGrid=true;
			mon.ShowVerticalGrid=true;
		}

		public void CloseActiveTab()
		{
			if(tabs.TabPages.Count<=1)
			{
				return;
			}
			tabs.TabPages.Remove(tabs.SelectedTab);

		}

		public void CloseOtherTabs()
		{
			if(tabs.TabPages.Count<=1)
			{
				return;
			}
			foreach (TabPage page in tabs.TabPages)
			{
				if(page!=tabs.SelectedTab)
				{
					tabs.TabPages.Remove(page);
				}
			}
		}
		
		public void CloseAllTabs()
		{
			tabs.TabPages.Clear();
			AddNewMonitorTab("Default");
		}
		
		
		public void RenameTab()
		{
			string newName = Interaction.InputBox("Name this tab","Tab Name",tabs.SelectedTab.Text,tabs.Location.X,tabs.Location.Y);
			if(newName==string.Empty)
				return;
			tabs.SelectedTab.Text=	newName;
		}

	
		
		private void mnuCloseActiveClick(object sender, EventArgs e)
		{
			CloseActiveTab();
		}

		private void mnuCloseOtherClick(object sender, EventArgs e)
		{
			CloseOtherTabs();
		}

		private void mnuCloseAllClick(object sender, EventArgs e)
		{
			CloseAllTabs();
		}

		private void mnuRenameClick(object sender, EventArgs e)
		{
			RenameTab();
		}

		private void SysMonitorView_Load_1(object sender, System.EventArgs e)
		{
		
		}


		}
}
