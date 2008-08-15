using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SystemMonitor;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTabbedMdi;
using Microsoft.VisualBasic;
using Osherove.PerfPlus.Controls;
using Osherove.PerfPlus.UIManagement;
using SysMonitor;

namespace Osherove.PerfPlus
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : Form
	{
		private BarAndDockingController barDockMgr;
		private DockManager dockMgr;
		private ControlContainer dockPanel1_Container;
		private DockPanel pnlCountersTree;
		private BarSubItem barSubItem1;
		private BarButtonItem barButtonItem1;
		private XtraTabbedMdiManager tabsMgr;
		private BarSubItem barSubItem2;
		private BarButtonItem cmdNewTab;
		private DefaultLookAndFeel defaultLookAndFeel1;
		private ImageCollection lsttopToolbarImages;
		private Bar bar4;
		private RibbonPageGroup ribbonPageGroup1;
		private RibbonPageGroup ribbonPageGroup2;
		private RibbonStatusBar ribbonStatusBar1;
		private ImageCollection imgRibbon;
		private RibbonPageGroup ribbonPageGroup4;
		private BarButtonGroup barButtonGroup1;
		private BarCheckItem chkPanelCounters;
		private BarStaticItem barStaticItem1;
		private RibbonPageGroup ribbonPageGroup5;
		private RibbonPageGroup ribbonPageGroup6;
		private BarButtonItem cmdAddCounters;
		private RibbonPageGroup ribbonPageGroup7;
		private RibbonPageGroup ribbonPageGroup8;
		private RibbonPageGroup ribbonPageGroup9;
		private RibbonPageGroup ribbonPageGroup10;
		private RibbonPageGroup ribbonPageGroup11;
		private RibbonPageGroup ribbonPageGroup12;
		private RibbonPageGroup ribbonPageGroup13;
		private RibbonPageGroup ribbonPageGroup14;
		private BarButtonItem barButtonItem13;
		private RibbonPageGroup ribbonPageGroup3;
		private BarCheckItem chkShowToolbar;
		private BarStaticItem barStaticItem2;
		private RibbonControl ribbonMain;
		private IContainer components;
		private RibbonPage ribPageGeneral;
		private RibbonPage ribPageActiveMonitor;
		private RibbonPage ribPageLibFolder;
		private RibbonPage ribPageLibCounter;
		private BarButtonItem cmdScaleUp;
		private BarButtonItem cmdScaleDown;
		private BarCheckItem chkLegend;
		private BarCheckItem chkTextReport;
		private BarCheckItem chkShowVGrid;
		private BarCheckItem chkShowHGrid;
		private BarButtonItem cmdCreateRootNode;
		private BarButtonItem cmdCreateChildNode;
		private BarButtonItem cmdRemoveNode;
		private BarButtonItem cmdCreateFolderFromActiveMonitor;
		private BarButtonItem cmdAddNodeToNewTab;
		private RibbonPageGroup ribbonPageGroup15;
		private PopupMenu popupMenu1;
		private PopupMenu popupMenu2;
		private BarButtonItem cmdSetCounterMachineNames;
		private BarButtonItem cmdRenameFolder;
		private BarButtonItem cmdSaveCountersToCurrentFolder;
		private BarButtonItem cmdRenameTab;
		private BarButtonGroup barButtonGroup2;
		private RibbonPageGroup ribbonPageGroup16;
		private BarButtonItem cmdImport;
		private BarButtonItem cmdExport;
		private BarButtonGroup barButtonGroup3;
		private BarButtonGroup barButtonGroup4;
		private BarButtonGroup barButtonGroup5;
		private RibbonPage ribbonPage1;
		private RibbonPageGroup ribbonPageGroup17;
		private RibbonPageGroup ribbonPageGroup18;
		private RibbonPageGroup ribbonPageGroup19;
		private RibbonPageGroup ribbonPageGroup20;
		private BarButtonItem barButtonItem2;
		private BarButtonItem barButtonItem3;
		private BarButtonItem barButtonItem4;
		private BarButtonItem barButtonItem5;
		private BarButtonItem barButtonItem6;
		private BarButtonItem barButtonItem7;
		private BarStaticItem lblVersionCaption;
		private BarStaticItem lblVersion;
		private DevExpress.XtraBars.PopupMenu popupMenu3;
		private DevExpress.XtraBars.BarButtonItem cmdCloseTab;
		private DevExpress.XtraBars.BarButtonItem cmdSetInstanceName;
		private DevExpress.Utils.ToolTipController toolTipController1;

		private CounterTree tv;
		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			sysmonHelp.RequestSysMonitorObject+=new SysMonitorHelper.RequestSysMonitorObjectDelegate(sysmonHelp_RequestSysMonitorObject);
			
			tv= new CounterTree();
			tv.HideSelection = false;
			tv.SysMonHelper = sysmonHelp;
			tv.ActivateNewTabCallback+=new CounterTree.ActivateNewTabDelegate(ActivateNewTabCallback);
			tv.Dock=DockStyle.Fill;
			tv.LoadDefaultCounters();
			pnlCountersTree.Controls.Add(tv);
			
			
			focuser = new FocusActionsManager(FocusActionsManager.InitializeMap(ribbonMain));
			
			tv.FocusManager = focuser;
			doAddTab("Default");
			
		}

		private FocusActionsManager focuser = null;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.barDockMgr = new DevExpress.XtraBars.BarAndDockingController(this.components);
			this.dockMgr = new DevExpress.XtraBars.Docking.DockManager();
			this.pnlCountersTree = new DevExpress.XtraBars.Docking.DockPanel();
			this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
			this.cmdNewTab = new DevExpress.XtraBars.BarButtonItem();
			this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
			this.lsttopToolbarImages = new DevExpress.Utils.ImageCollection(this.components);
			this.tabsMgr = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
			this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
			this.imgRibbon = new DevExpress.Utils.ImageCollection(this.components);
			this.bar4 = new DevExpress.XtraBars.Bar();
			this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
			this.chkPanelCounters = new DevExpress.XtraBars.BarCheckItem();
			this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
			this.cmdScaleUp = new DevExpress.XtraBars.BarButtonItem();
			this.cmdScaleDown = new DevExpress.XtraBars.BarButtonItem();
			this.cmdAddCounters = new DevExpress.XtraBars.BarButtonItem();
			this.cmdCreateRootNode = new DevExpress.XtraBars.BarButtonItem();
			this.cmdCreateChildNode = new DevExpress.XtraBars.BarButtonItem();
			this.cmdRemoveNode = new DevExpress.XtraBars.BarButtonItem();
			this.cmdCreateFolderFromActiveMonitor = new DevExpress.XtraBars.BarButtonItem();
			this.cmdSaveCountersToCurrentFolder = new DevExpress.XtraBars.BarButtonItem();
			this.cmdSetCounterMachineNames = new DevExpress.XtraBars.BarButtonItem();
			this.cmdAddNodeToNewTab = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
			this.chkTextReport = new DevExpress.XtraBars.BarCheckItem();
			this.chkShowToolbar = new DevExpress.XtraBars.BarCheckItem();
			this.chkLegend = new DevExpress.XtraBars.BarCheckItem();
			this.chkShowVGrid = new DevExpress.XtraBars.BarCheckItem();
			this.chkShowHGrid = new DevExpress.XtraBars.BarCheckItem();
			this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
			this.cmdRenameFolder = new DevExpress.XtraBars.BarButtonItem();
			this.cmdRenameTab = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonGroup2 = new DevExpress.XtraBars.BarButtonGroup();
			this.cmdImport = new DevExpress.XtraBars.BarButtonItem();
			this.cmdExport = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonGroup3 = new DevExpress.XtraBars.BarButtonGroup();
			this.barButtonGroup4 = new DevExpress.XtraBars.BarButtonGroup();
			this.barButtonGroup5 = new DevExpress.XtraBars.BarButtonGroup();
			this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
			this.lblVersionCaption = new DevExpress.XtraBars.BarStaticItem();
			this.lblVersion = new DevExpress.XtraBars.BarStaticItem();
			this.cmdCloseTab = new DevExpress.XtraBars.BarButtonItem();
			this.cmdSetInstanceName = new DevExpress.XtraBars.BarButtonItem();
			this.ribPageGeneral = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribPageActiveMonitor = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup15 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribPageLibFolder = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribPageLibCounter = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup17 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup18 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup19 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup20 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
			this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
			this.popupMenu3 = new DevExpress.XtraBars.PopupMenu(this.components);
			this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
			((System.ComponentModel.ISupportInitialize)(this.barDockMgr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dockMgr)).BeginInit();
			this.pnlCountersTree.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lsttopToolbarImages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tabsMgr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRibbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).BeginInit();
			this.SuspendLayout();
			// 
			// barDockMgr
			// 
			this.barDockMgr.AppearancesRibbon.PageHeader.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.barDockMgr.AppearancesRibbon.PageHeader.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.barDockMgr.AppearancesRibbon.PageHeader.Options.UseBackColor = true;
			this.barDockMgr.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
			this.barDockMgr.PaintStyleName = "Skin";
			this.barDockMgr.PropertiesBar.AllowLinkLighting = false;
			// 
			// dockMgr
			// 
			this.dockMgr.Controller = this.barDockMgr;
			this.dockMgr.Form = this;
			this.dockMgr.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
																							 this.pnlCountersTree});
			this.dockMgr.TopZIndexControls.AddRange(new string[] {
																	 "DevExpress.XtraBars.BarDockControl",
																	 "System.Windows.Forms.StatusBar",
																	 "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
																	 "DevExpress.XtraBars.Ribbon.RibbonControl"});
			// 
			// pnlCountersTree
			// 
			this.pnlCountersTree.Controls.Add(this.dockPanel1_Container);
			this.pnlCountersTree.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
			this.pnlCountersTree.ID = new System.Guid("67d03641-787f-4ee4-abc7-e67c35e02bd4");
			this.pnlCountersTree.Location = new System.Drawing.Point(0, 144);
			this.pnlCountersTree.Name = "pnlCountersTree";
			this.pnlCountersTree.Size = new System.Drawing.Size(206, 326);
			this.pnlCountersTree.Text = "Counter Library";
			// 
			// dockPanel1_Container
			// 
			this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
			this.dockPanel1_Container.Name = "dockPanel1_Container";
			this.dockPanel1_Container.Size = new System.Drawing.Size(200, 298);
			this.dockPanel1_Container.TabIndex = 0;
			// 
			// cmdNewTab
			// 
			this.cmdNewTab.Caption = "&New tab";
			this.cmdNewTab.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdNewTab.Glyph")));
			this.cmdNewTab.Hint = "New Tab";
			this.cmdNewTab.Id = 3;
			this.cmdNewTab.ImageIndex = 0;
			this.cmdNewTab.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
			this.cmdNewTab.Name = "cmdNewTab";
			this.cmdNewTab.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdNewTab_ItemClick);
			// 
			// barSubItem1
			// 
			this.barSubItem1.Caption = "&File";
			this.barSubItem1.Id = 0;
			this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									 new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
			this.barSubItem1.Name = "barSubItem1";
			// 
			// barButtonItem1
			// 
			this.barButtonItem1.Caption = "E&xit";
			this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
			this.barButtonItem1.Hint = "Exit";
			this.barButtonItem1.Id = 1;
			this.barButtonItem1.ImageIndex = 1;
			this.barButtonItem1.Name = "barButtonItem1";
			// 
			// barSubItem2
			// 
			this.barSubItem2.Caption = "&Tabs";
			this.barSubItem2.Id = 2;
			this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									 new DevExpress.XtraBars.LinkPersistInfo(this.cmdNewTab)});
			this.barSubItem2.Name = "barSubItem2";
			// 
			// lsttopToolbarImages
			// 
			this.lsttopToolbarImages.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("lsttopToolbarImages.ImageStream")));
			// 
			// tabsMgr
			// 
			this.tabsMgr.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
			this.tabsMgr.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.tabsMgr.AppearancePage.HeaderActive.BorderColor = System.Drawing.Color.Red;
			this.tabsMgr.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.tabsMgr.AppearancePage.HeaderActive.Options.UseBackColor = true;
			this.tabsMgr.AppearancePage.HeaderActive.Options.UseBorderColor = true;
			this.tabsMgr.AppearancePage.HeaderActive.Options.UseFont = true;
			this.tabsMgr.Controller = this.barDockMgr;
			this.tabsMgr.HeaderButtons = ((DevExpress.XtraTab.TabButtons)(((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
				| DevExpress.XtraTab.TabButtons.Close)));
			this.tabsMgr.MdiParent = this;
			this.tabsMgr.SelectedPageChanged += new System.EventHandler(this.tabsMgr_SelectedPageChanged);
			this.tabsMgr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabsMgr_MouseDown);
			// 
			// defaultLookAndFeel1
			// 
			this.defaultLookAndFeel1.LookAndFeel.SkinName = "The Asphalt World";
			// 
			// imgRibbon
			// 
			this.imgRibbon.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgRibbon.ImageStream")));
			// 
			// bar4
			// 
			this.bar4.BarName = "barActions";
			this.bar4.DockCol = 0;
			this.bar4.DockRow = 0;
			this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar4.FloatLocation = new System.Drawing.Point(229, 161);
			this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																							  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
			this.bar4.OptionsBar.AllowDelete = true;
			this.bar4.OptionsBar.AllowQuickCustomization = false;
			this.bar4.OptionsBar.DisableClose = true;
			this.bar4.OptionsBar.DisableCustomization = true;
			this.bar4.OptionsBar.DrawDragBorder = false;
			this.bar4.OptionsBar.UseWholeRow = true;
			this.bar4.Text = "Actions";
			// 
			// ribbonMain
			// 
			this.ribbonMain.Images = this.imgRibbon;
			this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
																				 this.barSubItem1,
																				 this.barButtonItem1,
																				 this.barSubItem2,
																				 this.cmdNewTab,
																				 this.barButtonGroup1,
																				 this.chkPanelCounters,
																				 this.barStaticItem1,
																				 this.cmdScaleUp,
																				 this.cmdScaleDown,
																				 this.cmdAddCounters,
																				 this.cmdCreateRootNode,
																				 this.cmdCreateChildNode,
																				 this.cmdRemoveNode,
																				 this.cmdCreateFolderFromActiveMonitor,
																				 this.cmdSaveCountersToCurrentFolder,
																				 this.cmdSetCounterMachineNames,
																				 this.cmdAddNodeToNewTab,
																				 this.barButtonItem13,
																				 this.chkTextReport,
																				 this.chkShowToolbar,
																				 this.chkLegend,
																				 this.chkShowVGrid,
																				 this.chkShowHGrid,
																				 this.barStaticItem2,
																				 this.cmdRenameFolder,
																				 this.cmdRenameTab,
																				 this.barButtonGroup2,
																				 this.cmdImport,
																				 this.cmdExport,
																				 this.barButtonGroup3,
																				 this.barButtonGroup4,
																				 this.barButtonGroup5,
																				 this.barButtonItem2,
																				 this.barButtonItem3,
																				 this.barButtonItem4,
																				 this.barButtonItem5,
																				 this.barButtonItem6,
																				 this.barButtonItem7,
																				 this.lblVersionCaption,
																				 this.lblVersion,
																				 this.cmdCloseTab,
																				 this.cmdSetInstanceName});
			this.ribbonMain.Location = new System.Drawing.Point(0, 0);
			this.ribbonMain.MaxItemId = 42;
			this.ribbonMain.Name = "ribbonMain";
			this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
																						   this.ribPageGeneral,
																						   this.ribPageActiveMonitor,
																						   this.ribPageLibFolder,
																						   this.ribPageLibCounter,
																						   this.ribbonPage1});
			this.ribbonMain.SelectedPage = this.ribPageActiveMonitor;
			this.ribbonMain.Size = new System.Drawing.Size(712, 144);
			this.ribbonMain.Toolbar.ItemLinks.Add(this.barButtonItem1);
			this.ribbonMain.Toolbar.ItemLinks.Add(this.cmdNewTab, true);
			this.ribbonMain.Toolbar.ItemLinks.Add(this.cmdRenameTab);
			this.ribbonMain.Toolbar.ItemLinks.Add(this.cmdAddCounters, true);
			this.ribbonMain.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Below;
			this.ribbonMain.SelectedPageChanged += new System.EventHandler(this.ribbonMain_SelectedPageChanged);
			// 
			// barButtonGroup1
			// 
			this.barButtonGroup1.Caption = "barButtonGroup1";
			this.barButtonGroup1.Id = 0;
			this.barButtonGroup1.Name = "barButtonGroup1";
			// 
			// chkPanelCounters
			// 
			this.chkPanelCounters.Caption = "Show Counter Library";
			this.chkPanelCounters.Checked = true;
			this.chkPanelCounters.Glyph = ((System.Drawing.Image)(resources.GetObject("chkPanelCounters.Glyph")));
			this.chkPanelCounters.Hint = "Show counter library panel";
			this.chkPanelCounters.Id = 1;
			this.chkPanelCounters.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L));
			this.chkPanelCounters.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkPanelCounters.LargeGlyph")));
			this.chkPanelCounters.Name = "chkPanelCounters";
			this.chkPanelCounters.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
			this.chkPanelCounters.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkPanelCounters_CheckedChanged);
			// 
			// barStaticItem1
			// 
			this.barStaticItem1.Caption = "Actions on the active perfomance monitor";
			this.barStaticItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticItem1.Glyph")));
			this.barStaticItem1.Id = 2;
			this.barStaticItem1.Name = "barStaticItem1";
			this.barStaticItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// cmdScaleUp
			// 
			this.cmdScaleUp.Caption = "Scale up";
			this.cmdScaleUp.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdScaleUp.Glyph")));
			this.cmdScaleUp.Hint = "Scale up current counter";
			this.cmdScaleUp.Id = 3;
			this.cmdScaleUp.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Add);
			this.cmdScaleUp.Name = "cmdScaleUp";
			this.cmdScaleUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdScaleUp_ItemClick);
			// 
			// cmdScaleDown
			// 
			this.cmdScaleDown.Caption = "Scale down                 ";
			this.cmdScaleDown.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdScaleDown.Glyph")));
			this.cmdScaleDown.Hint = "Scale down current counter";
			this.cmdScaleDown.Id = 4;
			this.cmdScaleDown.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Subtract);
			this.cmdScaleDown.Name = "cmdScaleDown";
			this.cmdScaleDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
			// 
			// cmdAddCounters
			// 
			this.cmdAddCounters.Caption = "Add counter(s)";
			this.cmdAddCounters.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdAddCounters.Glyph")));
			this.cmdAddCounters.Hint = "Add Counters...";
			this.cmdAddCounters.Id = 5;
			this.cmdAddCounters.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A));
			this.cmdAddCounters.Name = "cmdAddCounters";
			this.cmdAddCounters.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdAddCounters_ItemClick);
			// 
			// cmdCreateRootNode
			// 
			this.cmdCreateRootNode.Caption = "Create Root";
			this.cmdCreateRootNode.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdCreateRootNode.Glyph")));
			this.cmdCreateRootNode.Hint = "Create root folder in library";
			this.cmdCreateRootNode.Id = 6;
			this.cmdCreateRootNode.Name = "cmdCreateRootNode";
			this.cmdCreateRootNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdCreateRootNode_ItemClick);
			// 
			// cmdCreateChildNode
			// 
			this.cmdCreateChildNode.Caption = "Create Child";
			this.cmdCreateChildNode.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdCreateChildNode.Glyph")));
			this.cmdCreateChildNode.Hint = "Create sub folder in library";
			this.cmdCreateChildNode.Id = 7;
			this.cmdCreateChildNode.Name = "cmdCreateChildNode";
			this.cmdCreateChildNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdCreateChildNode_ItemClick);
			// 
			// cmdRemoveNode
			// 
			this.cmdRemoveNode.Caption = "&Remove";
			this.cmdRemoveNode.Hint = "Remove folder or counter from library";
			this.cmdRemoveNode.Id = 8;
			this.cmdRemoveNode.ImageIndex = 1;
			this.cmdRemoveNode.Name = "cmdRemoveNode";
			this.cmdRemoveNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdRemoveNode_ItemClick);
			// 
			// cmdCreateFolderFromActiveMonitor
			// 
			this.cmdCreateFolderFromActiveMonitor.Caption = "Import Tab Counters to new folder";
			this.cmdCreateFolderFromActiveMonitor.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdCreateFolderFromActiveMonitor.Glyph")));
			this.cmdCreateFolderFromActiveMonitor.Hint = "Import tab counters to a new library folder";
			this.cmdCreateFolderFromActiveMonitor.Id = 10;
			this.cmdCreateFolderFromActiveMonitor.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
				| System.Windows.Forms.Keys.N));
			this.cmdCreateFolderFromActiveMonitor.Name = "cmdCreateFolderFromActiveMonitor";
			this.cmdCreateFolderFromActiveMonitor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdCreateFolderFromActiveMonitor_ItemClick);
			// 
			// cmdSaveCountersToCurrentFolder
			// 
			this.cmdSaveCountersToCurrentFolder.Caption = "Import tab counters to selected folder";
			this.cmdSaveCountersToCurrentFolder.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdSaveCountersToCurrentFolder.Glyph")));
			this.cmdSaveCountersToCurrentFolder.Hint = "Import tab counters to the selected library folder";
			this.cmdSaveCountersToCurrentFolder.Id = 11;
			this.cmdSaveCountersToCurrentFolder.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
				| System.Windows.Forms.Keys.F));
			this.cmdSaveCountersToCurrentFolder.Name = "cmdSaveCountersToCurrentFolder";
			this.cmdSaveCountersToCurrentFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSaveCountersToCurrentFolder_ItemClick);
			// 
			// cmdSetCounterMachineNames
			// 
			this.cmdSetCounterMachineNames.Caption = "Set machine name";
			this.cmdSetCounterMachineNames.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdSetCounterMachineNames.Glyph")));
			this.cmdSetCounterMachineNames.Hint = "set the machine name for the library counter(s)";
			this.cmdSetCounterMachineNames.Id = 12;
			this.cmdSetCounterMachineNames.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M));
			this.cmdSetCounterMachineNames.Name = "cmdSetCounterMachineNames";
			this.cmdSetCounterMachineNames.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdChangeMachinNameForCOunters_ItemClick);
			// 
			// cmdAddNodeToNewTab
			// 
			this.cmdAddNodeToNewTab.Caption = "Add folder to new tab";
			this.cmdAddNodeToNewTab.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdAddNodeToNewTab.Glyph")));
			this.cmdAddNodeToNewTab.Hint = "add this library folder\'s counters to a new tab";
			this.cmdAddNodeToNewTab.Id = 13;
			this.cmdAddNodeToNewTab.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
				| System.Windows.Forms.Keys.Right));
			this.cmdAddNodeToNewTab.Name = "cmdAddNodeToNewTab";
			this.cmdAddNodeToNewTab.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdAddNodeToNewTab_ItemClick);
			// 
			// barButtonItem13
			// 
			this.barButtonItem13.Caption = "Add to selected tab";
			this.barButtonItem13.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem13.Glyph")));
			this.barButtonItem13.Hint = "add this library folder/counter to the current tab";
			this.barButtonItem13.Id = 16;
			this.barButtonItem13.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right));
			this.barButtonItem13.Name = "barButtonItem13";
			this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem13_ItemClick);
			// 
			// chkTextReport
			// 
			this.chkTextReport.Caption = "Text Report";
			this.chkTextReport.Glyph = ((System.Drawing.Image)(resources.GetObject("chkTextReport.Glyph")));
			this.chkTextReport.Hint = "Set the perfmon display to \"Text Report\"";
			this.chkTextReport.Id = 17;
			this.chkTextReport.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R));
			this.chkTextReport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkTextReport.LargeGlyph")));
			this.chkTextReport.Name = "chkTextReport";
			this.chkTextReport.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkTextReport_CheckedChanged);
			// 
			// chkShowToolbar
			// 
			this.chkShowToolbar.Caption = "Toolbar";
			this.chkShowToolbar.Checked = true;
			this.chkShowToolbar.Glyph = ((System.Drawing.Image)(resources.GetObject("chkShowToolbar.Glyph")));
			this.chkShowToolbar.Hint = "Show/Hide the perfmon toolbar";
			this.chkShowToolbar.Id = 18;
			this.chkShowToolbar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T));
			this.chkShowToolbar.Name = "chkShowToolbar";
			this.chkShowToolbar.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkShowToolbar_CheckedChanged);
			// 
			// chkLegend
			// 
			this.chkLegend.Caption = "Legend";
			this.chkLegend.Checked = true;
			this.chkLegend.Glyph = ((System.Drawing.Image)(resources.GetObject("chkLegend.Glyph")));
			this.chkLegend.Hint = "Show/Hide the perfmon legend";
			this.chkLegend.Id = 19;
			this.chkLegend.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L));
			this.chkLegend.Name = "chkLegend";
			this.chkLegend.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkLegend_CheckedChanged);
			// 
			// chkShowVGrid
			// 
			this.chkShowVGrid.Caption = "Vertical Grid Lines";
			this.chkShowVGrid.Glyph = ((System.Drawing.Image)(resources.GetObject("chkShowVGrid.Glyph")));
			this.chkShowVGrid.Hint = "Show/Hide perfmon vertical grid lines";
			this.chkShowVGrid.Id = 20;
			this.chkShowVGrid.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V));
			this.chkShowVGrid.Name = "chkShowVGrid";
			this.chkShowVGrid.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkShowVGrid_CheckedChanged);
			// 
			// chkShowHGrid
			// 
			this.chkShowHGrid.Caption = "Horizontal Grid Lines";
			this.chkShowHGrid.Glyph = ((System.Drawing.Image)(resources.GetObject("chkShowHGrid.Glyph")));
			this.chkShowHGrid.Hint = "Show/Hide perfmon Horizontal grid lines";
			this.chkShowHGrid.Id = 21;
			this.chkShowHGrid.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H));
			this.chkShowHGrid.Name = "chkShowHGrid";
			this.chkShowHGrid.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkShowHGrid_CheckedChanged);
			// 
			// barStaticItem2
			// 
			this.barStaticItem2.Caption = "Perf+                                                                            " +
				"";
			this.barStaticItem2.Id = 22;
			this.barStaticItem2.Name = "barStaticItem2";
			this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// cmdRenameFolder
			// 
			this.cmdRenameFolder.Caption = "&Rename";
			this.cmdRenameFolder.Id = 23;
			this.cmdRenameFolder.Name = "cmdRenameFolder";
			this.cmdRenameFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdRenameFolder_ItemClick);
			// 
			// cmdRenameTab
			// 
			this.cmdRenameTab.Caption = "&Rename Tab";
			this.cmdRenameTab.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdRenameTab.Glyph")));
			this.cmdRenameTab.Hint = "Rename Tab";
			this.cmdRenameTab.Id = 25;
			this.cmdRenameTab.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
			this.cmdRenameTab.Name = "cmdRenameTab";
			this.cmdRenameTab.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdRenameTab_ItemClick);
			// 
			// barButtonGroup2
			// 
			this.barButtonGroup2.Caption = "Share";
			this.barButtonGroup2.Id = 26;
			this.barButtonGroup2.Name = "barButtonGroup2";
			// 
			// cmdImport
			// 
			this.cmdImport.Caption = "&Import Library...";
			this.cmdImport.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdImport.Glyph")));
			this.cmdImport.Hint = "Import existing library counters from file";
			this.cmdImport.Id = 27;
			this.cmdImport.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
			this.cmdImport.Name = "cmdImport";
			this.cmdImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdImport_ItemClick);
			// 
			// cmdExport
			// 
			this.cmdExport.Caption = "Export Library...";
			this.cmdExport.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdExport.Glyph")));
			this.cmdExport.Hint = "Export coutner library to file";
			this.cmdExport.Id = 28;
			this.cmdExport.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
			this.cmdExport.Name = "cmdExport";
			this.cmdExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdExport_ItemClick);
			// 
			// barButtonGroup3
			// 
			this.barButtonGroup3.Caption = "barButtonGroup3";
			this.barButtonGroup3.Id = 29;
			this.barButtonGroup3.Name = "barButtonGroup3";
			// 
			// barButtonGroup4
			// 
			this.barButtonGroup4.Caption = "View ptions";
			this.barButtonGroup4.Id = 30;
			this.barButtonGroup4.ItemLinks.Add(this.chkLegend);
			this.barButtonGroup4.ItemLinks.Add(this.chkShowToolbar);
			this.barButtonGroup4.Name = "barButtonGroup4";
			// 
			// barButtonGroup5
			// 
			this.barButtonGroup5.Caption = "barButtonGroup5";
			this.barButtonGroup5.Id = 31;
			this.barButtonGroup5.ItemLinks.Add(this.chkShowHGrid);
			this.barButtonGroup5.ItemLinks.Add(this.chkShowVGrid);
			this.barButtonGroup5.Name = "barButtonGroup5";
			// 
			// barButtonItem2
			// 
			this.barButtonItem2.Caption = "Team Agile";
			this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
			this.barButtonItem2.Id = 32;
			this.barButtonItem2.Name = "barButtonItem2";
			this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
			// 
			// barButtonItem3
			// 
			this.barButtonItem3.Caption = "Other Tools from Roy";
			this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
			this.barButtonItem3.Id = 33;
			this.barButtonItem3.Name = "barButtonItem3";
			this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_1);
			// 
			// barButtonItem4
			// 
			this.barButtonItem4.Caption = "Roy\'s Blog";
			this.barButtonItem4.Id = 34;
			this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
			this.barButtonItem4.Name = "barButtonItem4";
			this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
			// 
			// barButtonItem5
			// 
			this.barButtonItem5.Caption = "Bug/ Feature request";
			this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
			this.barButtonItem5.Id = 35;
			this.barButtonItem5.Name = "barButtonItem5";
			this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
			// 
			// barButtonItem6
			// 
			this.barButtonItem6.Caption = "Email the author";
			this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
			this.barButtonItem6.Id = 36;
			this.barButtonItem6.Name = "barButtonItem6";
			this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
			// 
			// barButtonItem7
			// 
			this.barButtonItem7.Caption = "barButtonItem7";
			this.barButtonItem7.Id = 37;
			this.barButtonItem7.Name = "barButtonItem7";
			// 
			// lblVersionCaption
			// 
			this.lblVersionCaption.Caption = "Version:";
			this.lblVersionCaption.Id = 38;
			this.lblVersionCaption.Name = "lblVersionCaption";
			this.lblVersionCaption.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// lblVersion
			// 
			this.lblVersion.Caption = "       1.0      ";
			this.lblVersion.Id = 39;
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// cmdCloseTab
			// 
			this.cmdCloseTab.Caption = "&Close";
			this.cmdCloseTab.Id = 40;
			this.cmdCloseTab.Name = "cmdCloseTab";
			// 
			// cmdSetInstanceName
			// 
			this.cmdSetInstanceName.Caption = "Set Target Application Instance";
			this.cmdSetInstanceName.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdSetInstanceName.Glyph")));
			this.cmdSetInstanceName.Hint = "Set the counter(s) target application instance";
			this.cmdSetInstanceName.Id = 41;
			this.cmdSetInstanceName.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T));
			this.cmdSetInstanceName.Name = "cmdSetInstanceName";
			this.cmdSetInstanceName.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSetInstanceName_ItemClick);
			// 
			// ribPageGeneral
			// 
			this.ribPageGeneral.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
																									 this.ribbonPageGroup1,
																									 this.ribbonPageGroup2,
																									 this.ribbonPageGroup4,
																									 this.ribbonPageGroup16});
			this.ribPageGeneral.Name = "ribPageGeneral";
			this.ribPageGeneral.Text = "General";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "Program";
			// 
			// ribbonPageGroup2
			// 
			this.ribbonPageGroup2.ItemLinks.Add(this.cmdNewTab);
			this.ribbonPageGroup2.ItemLinks.Add(this.cmdRenameTab);
			this.ribbonPageGroup2.Name = "ribbonPageGroup2";
			this.ribbonPageGroup2.ShowCaptionButton = false;
			this.ribbonPageGroup2.Text = "Tabs";
			// 
			// ribbonPageGroup4
			// 
			this.ribbonPageGroup4.ItemLinks.Add(this.chkPanelCounters);
			this.ribbonPageGroup4.Name = "ribbonPageGroup4";
			this.ribbonPageGroup4.Text = "Panels";
			// 
			// ribbonPageGroup16
			// 
			this.ribbonPageGroup16.ItemLinks.Add(this.cmdImport);
			this.ribbonPageGroup16.ItemLinks.Add(this.cmdExport);
			this.ribbonPageGroup16.Name = "ribbonPageGroup16";
			this.ribbonPageGroup16.Text = "Share";
			// 
			// ribPageActiveMonitor
			// 
			this.ribPageActiveMonitor.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
																										   this.ribbonPageGroup5,
																										   this.ribbonPageGroup6,
																										   this.ribbonPageGroup3,
																										   this.ribbonPageGroup15});
			this.ribPageActiveMonitor.Name = "ribPageActiveMonitor";
			this.ribPageActiveMonitor.Text = "Active Monitor";
			// 
			// ribbonPageGroup5
			// 
			this.ribbonPageGroup5.ItemLinks.Add(this.cmdScaleUp);
			this.ribbonPageGroup5.ItemLinks.Add(this.cmdScaleDown);
			this.ribbonPageGroup5.Name = "ribbonPageGroup5";
			this.ribbonPageGroup5.Text = "Active Counter";
			// 
			// ribbonPageGroup6
			// 
			this.ribbonPageGroup6.ItemLinks.Add(this.cmdAddCounters, true);
			this.ribbonPageGroup6.ItemLinks.Add(this.cmdRenameTab);
			this.ribbonPageGroup6.ItemLinks.Add(this.cmdNewTab);
			this.ribbonPageGroup6.Name = "ribbonPageGroup6";
			this.ribbonPageGroup6.Text = "Monitor";
			// 
			// ribbonPageGroup3
			// 
			this.ribbonPageGroup3.ItemLinks.Add(this.barButtonGroup4);
			this.ribbonPageGroup3.ItemLinks.Add(this.barButtonGroup5);
			this.ribbonPageGroup3.ItemLinks.Add(this.chkTextReport);
			this.ribbonPageGroup3.Name = "ribbonPageGroup3";
			this.ribbonPageGroup3.Text = "Toggle Visible";
			// 
			// ribbonPageGroup15
			// 
			this.ribbonPageGroup15.ItemLinks.Add(this.cmdCreateFolderFromActiveMonitor);
			this.ribbonPageGroup15.ItemLinks.Add(this.cmdSaveCountersToCurrentFolder);
			this.ribbonPageGroup15.Name = "ribbonPageGroup15";
			this.ribbonPageGroup15.Text = "Library";
			// 
			// ribPageLibFolder
			// 
			this.ribPageLibFolder.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
																									   this.ribbonPageGroup7,
																									   this.ribbonPageGroup12,
																									   this.ribbonPageGroup10,
																									   this.ribbonPageGroup11});
			this.ribPageLibFolder.Name = "ribPageLibFolder";
			this.ribPageLibFolder.Text = "Library Folder";
			// 
			// ribbonPageGroup7
			// 
			this.ribbonPageGroup7.ItemLinks.Add(this.cmdCreateRootNode, true);
			this.ribbonPageGroup7.ItemLinks.Add(this.cmdCreateChildNode);
			this.ribbonPageGroup7.ItemLinks.Add(this.cmdRemoveNode, true);
			this.ribbonPageGroup7.ItemLinks.Add(this.cmdRenameFolder);
			this.ribbonPageGroup7.Name = "ribbonPageGroup7";
			this.ribbonPageGroup7.Text = "Folders";
			// 
			// ribbonPageGroup12
			// 
			this.ribbonPageGroup12.ItemLinks.Add(this.cmdAddNodeToNewTab);
			this.ribbonPageGroup12.ItemLinks.Add(this.barButtonItem13);
			this.ribbonPageGroup12.Name = "ribbonPageGroup12";
			this.ribbonPageGroup12.Text = "Monitor";
			// 
			// ribbonPageGroup10
			// 
			this.ribbonPageGroup10.ItemLinks.Add(this.cmdCreateFolderFromActiveMonitor);
			this.ribbonPageGroup10.ItemLinks.Add(this.cmdSaveCountersToCurrentFolder);
			this.ribbonPageGroup10.Name = "ribbonPageGroup10";
			this.ribbonPageGroup10.Text = "Import";
			// 
			// ribbonPageGroup11
			// 
			this.ribbonPageGroup11.ItemLinks.Add(this.cmdSetCounterMachineNames);
			this.ribbonPageGroup11.ItemLinks.Add(this.cmdSetInstanceName);
			this.ribbonPageGroup11.Name = "ribbonPageGroup11";
			this.ribbonPageGroup11.Text = "Current Folder\\Counter";
			// 
			// ribPageLibCounter
			// 
			this.ribPageLibCounter.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
																										this.ribbonPageGroup13,
																										this.ribbonPageGroup14});
			this.ribPageLibCounter.Name = "ribPageLibCounter";
			this.ribPageLibCounter.Text = "Library Counter";
			// 
			// ribbonPageGroup13
			// 
			this.ribbonPageGroup13.ItemLinks.Add(this.cmdSetCounterMachineNames);
			this.ribbonPageGroup13.Name = "ribbonPageGroup13";
			this.ribbonPageGroup13.Text = "Modify Counter";
			// 
			// ribbonPageGroup14
			// 
			this.ribbonPageGroup14.ItemLinks.Add(this.cmdAddNodeToNewTab);
			this.ribbonPageGroup14.ItemLinks.Add(this.barButtonItem13);
			this.ribbonPageGroup14.Name = "ribbonPageGroup14";
			this.ribbonPageGroup14.Text = "Monitor";
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
																								  this.ribbonPageGroup17,
																								  this.ribbonPageGroup18,
																								  this.ribbonPageGroup19,
																								  this.ribbonPageGroup20});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Help";
			// 
			// ribbonPageGroup17
			// 
			this.ribbonPageGroup17.ItemLinks.Add(this.lblVersionCaption);
			this.ribbonPageGroup17.ItemLinks.Add(this.lblVersion);
			this.ribbonPageGroup17.Name = "ribbonPageGroup17";
			this.ribbonPageGroup17.Text = "About";
			// 
			// ribbonPageGroup18
			// 
			this.ribbonPageGroup18.ItemLinks.Add(this.barButtonItem2);
			this.ribbonPageGroup18.ItemLinks.Add(this.barButtonItem3);
			this.ribbonPageGroup18.ItemLinks.Add(this.barButtonItem4, true);
			this.ribbonPageGroup18.Name = "ribbonPageGroup18";
			this.ribbonPageGroup18.Text = "Other Sites";
			// 
			// ribbonPageGroup19
			// 
			this.ribbonPageGroup19.ItemLinks.Add(this.barButtonItem5);
			this.ribbonPageGroup19.ItemLinks.Add(this.barButtonItem6);
			this.ribbonPageGroup19.Name = "ribbonPageGroup19";
			this.ribbonPageGroup19.Text = "Support";
			// 
			// ribbonPageGroup20
			// 
			this.ribbonPageGroup20.Name = "ribbonPageGroup20";
			this.ribbonPageGroup20.Text = "Videos";
			// 
			// ribbonStatusBar1
			// 
			this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem2);
			this.ribbonStatusBar1.ItemLinks.Add(this.cmdScaleUp);
			this.ribbonStatusBar1.ItemLinks.Add(this.cmdScaleDown);
			this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 470);
			this.ribbonStatusBar1.Name = "ribbonStatusBar1";
			this.ribbonStatusBar1.Ribbon = this.ribbonMain;
			this.ribbonStatusBar1.Size = new System.Drawing.Size(712, 24);
			// 
			// ribbonPageGroup8
			// 
			this.ribbonPageGroup8.ItemLinks.Add(this.barStaticItem1);
			this.ribbonPageGroup8.Name = "ribbonPageGroup8";
			this.ribbonPageGroup8.Text = "Description";
			// 
			// ribbonPageGroup9
			// 
			this.ribbonPageGroup9.ItemLinks.Add(this.barStaticItem1);
			this.ribbonPageGroup9.Name = "ribbonPageGroup9";
			this.ribbonPageGroup9.Text = "Description";
			// 
			// popupMenu1
			// 
			this.popupMenu1.Name = "popupMenu1";
			this.popupMenu1.Ribbon = this.ribbonMain;
			// 
			// popupMenu2
			// 
			this.popupMenu2.Name = "popupMenu2";
			this.popupMenu2.Ribbon = this.ribbonMain;
			// 
			// popupMenu3
			// 
			this.popupMenu3.ItemLinks.Add(this.cmdRenameTab);
			this.popupMenu3.ItemLinks.Add(this.cmdCloseTab);
			this.popupMenu3.Name = "popupMenu3";
			this.popupMenu3.Ribbon = this.ribbonMain;
			// 
			// toolTipController1
			// 
			this.toolTipController1.Rounded = true;
			this.toolTipController1.ShowBeak = true;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(712, 494);
			this.Controls.Add(this.pnlCountersTree);
			this.Controls.Add(this.ribbonMain);
			this.Controls.Add(this.ribbonStatusBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Name = "MainForm";
			this.Text = "Perf+  (Alpha - Expires February 2007)";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.barDockMgr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dockMgr)).EndInit();
			this.pnlCountersTree.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lsttopToolbarImages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tabsMgr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRibbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdNewTab_ItemClick(object sender, ItemClickEventArgs e)
		{
			doAddTab("New Monitor");
		}

		private  SysMonitorHelper sysmonHelp = new SysMonitorHelper();
		private void doAddTab(string title)
		{
			
			PerfMonForm tab = new PerfMonForm();
			tab.FocusManager=focuser;
			tab.MdiParent = this;
			tab.Text = title;
			tab.Show();
			
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			lblVersion.Caption = Assembly.GetEntryAssembly().GetName().Version.ToString();
			LoadLayouts();
			LoadCounterLibrary();
			LoadTabs();
		}

		private void LoadLayouts()
		{
			HistoryUtil.LoadLayout(dockMgr);
		}

		///<summary>
		///
		///<para>
		///Raises the <see cref="E:System.Windows.Forms.Form.Closing" /> event.
		///</para>
		///
		///</summary>
		///
		///<param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			SaveLibrary();
			SaveTabs();
			SaveLayouts();
		}

		private void SaveLayouts()
		{
			HistoryUtil.SaveLayout(dockMgr);
		}

		private void SaveTabs()
		{
			CounterFolder tabsRoot = GetTabsRootFromForms();
			HistoryUtil.SaveTabs(tabsRoot);
		}

		private CounterFolder GetTabsRootFromForms()
		{
			CounterFolder tabsRoot = new CounterFolder();
			tabsRoot.Name = "root";
			foreach (Form form in MdiChildren)
			{
				if(form is PerfMonForm)
				{
					CounterFolder folder = new CounterFolder();
					folder.Name = form.Text;
					
					PerfMonForm tab = form as PerfMonForm;
					bool shouldIgnoreThisForm = tab.Text.ToLower()=="default" && tab.MonitorControl.Counters.Count==0;
					if(shouldIgnoreThisForm)
					{
						continue;
					}
					foreach (CounterItem counterItem in tab.MonitorControl.Counters)
					{
						CounterInfo info = CounterInfoHelper.FromPerfmonCounter(counterItem);
						folder.Counterinfos.Add(info);
					}
					tabsRoot.SubFolders.Add(folder);
				}
			}
			return tabsRoot;
		}

		private void SaveLibrary()
		{
			CounterFolder root = tv.GetAllWithSingleRoot();
			HistoryUtil.SaveCounterLibrary(root);
		}

		private void LoadCounterLibrary()
		{
			CounterFolder libRoot = HistoryUtil.LoadCounterLibrary();
			if(libRoot!=null && libRoot.SubFolders.Count>0)
			{
				tv.Nodes.Clear();
				foreach (CounterFolder subFolder in libRoot.SubFolders)
				{
					tv.AddFolderToTreeRecursive(subFolder, null);
				}
				tv.ExpandAll();
			}
			else//LOAD FROM DEFAULT FILE
			{
				string defaultfilename = Path.Combine(Application.StartupPath,"default.xml");
				if(File.Exists(defaultfilename))
				{
					CounterFolder library = HistoryUtil.LoadCounterLibrary(defaultfilename);
					if(library==null)
					{
						MessageBox.Show("Error loading default counters");
						return;
					}
					tv.Nodes.Clear();
					foreach (CounterFolder subFolder in library.SubFolders)
					{
						tv.AddFolderToTreeRecursive(subFolder, null);
					}
				}
			}
		}
		
		private void LoadTabs()
		{
			CounterFolder libRoot = HistoryUtil.LoadTabs();
			if(libRoot!=null)
			{
				foreach (CounterFolder subFolder in libRoot.SubFolders)
				{
					doAddTab(subFolder.Name);
					sysmonHelp.AddFolderCountersToMonitor(subFolder);
				}
			}
		}

		private void ActivateNewTabCallback(string title)
		{
			doAddTab(title);
		}

		private void sysmonHelp_RequestSysMonitorObject(out SysMonitorControlEx RequiredMonitor)
		{
			if(ActiveMdiChild==null)
			{
				RequiredMonitor = null;
				return;
			}
			PerfMonForm form = (PerfMonForm) ActiveMdiChild;
			RequiredMonitor = form.MonitorControl;
		}

		private void chkPanelCounters_CheckedChanged(object sender, ItemClickEventArgs e)
		{
			if(chkPanelCounters.Checked)
			{
				pnlCountersTree.Show();
			}
			else
			{
				pnlCountersTree.Hide();
			}
		}

		private void cmdScaleUp_ItemClick(object sender, ItemClickEventArgs e)
		{
			doScaleUp();
		}

		private void doScaleUp()
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			ActiveMonitorForm.MonitorControl.ScaleUp();
		}
		
		private void doScaleDown()
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			ActiveMonitorForm.MonitorControl.ScaleDown();
		}

		private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
		{
			doScaleDown();	
		}

		private void cmdAddCounters_ItemClick(object sender, ItemClickEventArgs e)
		{
			doAddCounter();
		}

		private void doAddCounter()
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			ActiveMonitorForm.MonitorControl.BrowseCounters();
		}

		private void chkLegend_CheckedChanged(object sender, ItemClickEventArgs e)
		{
			doShowLegend(chkLegend.Checked);
		}

		private void doShowLegend(bool show)
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			ActiveMonitorForm.MonitorControl.ShowLegend=show;
		}
		
		private void doShowToolbar(bool show)
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			ActiveMonitorForm.MonitorControl.ShowToolbar=show;
		}
		
		
		private void doShowHGrid(bool show)
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			ActiveMonitorForm.MonitorControl.ShowHorizontalGrid=show;
		}
		
		private void doShowVGrid(bool show)
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			ActiveMonitorForm.MonitorControl.ShowVerticalGrid=show;
		}
		
		private void doShowTextReport(bool show)
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			if(show)
			{
				ActiveMonitorForm.MonitorControl.DisplayType=DisplayTypeConstants.sysmonReport;
			}
			else
			{
				ActiveMonitorForm.MonitorControl.DisplayType=DisplayTypeConstants.sysmonLineGraph;
			}
		}

		private void chkTextReport_CheckedChanged(object sender, ItemClickEventArgs e)
		{
			doShowTextReport(chkTextReport.Checked);
		}

		private void chkShowVGrid_CheckedChanged(object sender, ItemClickEventArgs e)
		{
			doShowVGrid(chkShowVGrid.Checked);
		}

		private void chkShowHGrid_CheckedChanged(object sender, ItemClickEventArgs e)
		{
			doShowHGrid(chkShowHGrid.Checked);
		
		}

		private void chkShowToolbar_CheckedChanged(object sender, ItemClickEventArgs e)
		{
			doShowToolbar(chkShowToolbar.Checked);
		}

		private void cmdCreateRootNode_ItemClick(object sender, ItemClickEventArgs e)
		{
			doCreateRoot();
			
		}

		private void doCreateRoot()
		{
			pnlCountersTree.Show();
			tv.InsertNewRootFolder();
		}
		
		private void doCreateSubFolder()
		{
			pnlCountersTree.Show();
			tv.InsertNewSubFolder();
		}

		private void cmdCreateChildNode_ItemClick(object sender, ItemClickEventArgs e)
		{
		doCreateSubFolder();
		}

		private void cmdRemoveNode_ItemClick(object sender, ItemClickEventArgs e)
		{
			doRemoveNode();
		}

		private void doRemoveNode()
		{
			tv.DeleteSelectedNode();
		}

		private void cmdAddNodeToNewTab_ItemClick(object sender, ItemClickEventArgs e)
		{
			doActivateInNewTab();
		}

		private void doActivateInNewTab()
		{
			pnlCountersTree.Show();
			tv.ActivateInNewTab();
		}
		private void doActivateInCurrentTab()
		{
			pnlCountersTree.Show();
			tv.ActivateInCurrentTab();
		}

		private void cmdCreateFolderFromActiveMonitor_ItemClick(object sender, ItemClickEventArgs e)
		{
			doSaveCountersToNewTreeFolder();
		}

		private void doSaveCountersToNewTreeFolder()
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			doCreateRoot();
			doAddExistingCountersToActiveFolder();
			tv.Focus();
			tv.SelectedNode.Text = ActiveMonitorForm.Text;
			tv.TreeSelectedFolder.Name=ActiveMonitorForm.Text;
			Application.DoEvents();
			
			tv.TreeSelectedFolder.Name=ActiveMonitorForm.Text;
			Application.DoEvents();
			tv.SelectedNode.BeginEdit();
		}

		private void doAddExistingCountersToActiveFolder()
		{
			if(ActiveMonitorForm==null)
			{
				return;
			}
			tv.AddExistingCountersToTree(ActiveMonitorForm.MonitorControl);
		}

		private void cmdChangeMachinNameForCOunters_ItemClick(object sender, ItemClickEventArgs e)
		{
			doChangeMachineNameForCounters();
		}

		private void doChangeMachineNameForCounters()
		{
			pnlCountersTree.Show();
			tv.ChangeMachineNameforCounters();
		}

		private void cmdRenameFolder_ItemClick(object sender, ItemClickEventArgs e)
		{
			doRenameFolder();
		}

		private void doRenameFolder()
		{
			if(tv.TreeSelectedFolderNode==null)
			{return;}
			tv.TreeSelectedFolderNode.BeginEdit();
		}

		private void cmdSaveCountersToCurrentFolder_ItemClick(object sender, ItemClickEventArgs e)
		{
			doAddExistingCountersToActiveFolder();
		}

		private void cmdRenameTab_ItemClick(object sender, ItemClickEventArgs e)
		{
			doRenameTab();
		}

		private void doRenameTab()
		{
//			int lastHight = ribbonMain.Height;
//			
//			ribbonMain.Refresh();
			Application.DoEvents();
			Application.DoEvents();
			
			if(ActiveMonitorForm==null)
				return;
			Point pt = PointToScreen( new Point( 0,ribbonMain.Bottom));
			string result = Interaction.InputBox("Rename Tab","Rename",ActiveMonitorForm.Text,pt.X,pt.Y);
			if(result==string.Empty || result==ActiveMonitorForm.Text)
			{
				return;
			}
			ActiveMonitorForm.Text = result;
			
//			ribbonMain.Height = lastHight;
			
		}

		private void cmdImport_ItemClick(object sender, ItemClickEventArgs e)
		{
			doImportLibrary();
		}

		private void doImportLibrary()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "*.xml|*.xml";
			DialogResult result = dlg.ShowDialog(this);
			if(result==DialogResult.OK)
			{
				try
				{
					CounterFolder newRoot = HistoryUtil.LoadCounterLibrary(dlg.FileName);
					tv.BeginUpdate();
					
					foreach (CounterFolder folder in newRoot.SubFolders)
					{
						tv.AddFolderToTreeRecursive(folder,null);
					}
					tv.EndUpdate();
					tv.Refresh();
				}
				catch(Exception e)
				{
					MessageBox.Show(e.Message);
				}
			}
		}

		private void cmdExport_ItemClick(object sender, ItemClickEventArgs e)
		{
			doExportLibrary();
		}

		private void doExportLibrary()
		{
			try
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Filter = "*.xml|*.xml";
				if(dlg.ShowDialog(this)==DialogResult.OK)
				{
					CounterFolder root = tv.GetAllWithSingleRoot();
					HistoryUtil.SaveCounterLibrary(root,dlg.FileName);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void tabsMgr_SelectedPageChanged(object sender, EventArgs e)
		{
			doRefreshCheckedToolbarItemsForActiveMonitor();
		}

		private void doRefreshCheckedToolbarItemsForActiveMonitor()
		{
			Application.DoEvents();
			if(ActiveMonitorForm==null)
			{
				return;
			}
			chkLegend.Checked = ActiveMonitorForm.MonitorControl.ShowLegend;
			chkShowToolbar.Checked = ActiveMonitorForm.MonitorControl.ShowToolbar;
			chkShowVGrid.Checked = ActiveMonitorForm.MonitorControl.ShowVerticalGrid;
			chkShowHGrid.Checked = ActiveMonitorForm.MonitorControl.ShowHorizontalGrid;
			chkTextReport.Checked = ActiveMonitorForm.MonitorControl.DisplayType == DisplayTypeConstants.sysmonReport;
		}

		private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
		{
			AboutHelper.NavTeamAgileHomepage();
		}

		private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
		{
			AboutHelper.NavTools();
		}

		private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
		{
			AboutHelper.NavBlog();
		}

		private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
		{
			AboutHelper.NavBugz();
		}

		private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
		{
			AboutHelper.EmailAuthor();
		}

		private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			tv.ActivateInCurrentTab();
		}

		private void tabsMgr_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(MdiChildren.Length>0 && e.Button==MouseButtons.Right)
			{
//				popupMenu3.ShowPopup(PointToScreen(new Point(e.X,e.Y)));
			}
		}

		private void cmdSetInstanceName_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			doSetTargetInstanceforCounters();
		}

		private void doSetTargetInstanceforCounters()
		{
			tv.ChangeInstanceNameforCounters();
		}

		private void ribbonMain_SelectedPageChanged(object sender, System.EventArgs e)
		{
			ValidateExpireDate();
		}

		private void ValidateExpireDate()
		{
			DateTime expireDate = new DateTime(2007,2,22);
			if(DateTime.Now > expireDate)
			{
				if(MessageBox.Show("Application expired. Go to the product site for a new version?","Expired",MessageBoxButtons.YesNo)==DialogResult.Yes)
				{
					AboutHelper.NavTools();
				}
			}
		}

		private PerfMonForm ActiveMonitorForm
		{
			get
			{
				return ActiveMdiChild as PerfMonForm;
			}
		}
	}
}
