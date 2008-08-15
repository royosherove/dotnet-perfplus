using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Osherove.PerfPlus;
using Osherove.PerfPlus.Controls;

namespace SysMonitor
{
	public class MonitorForm : Form,IActionable
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		private ContextMenu tabMenu;
		private MenuItem menuItem9;
		private MenuItem menuItem10;
		private MenuItem menuItem11;
		private MenuItem menuItem12;
		private MenuItem menuItem13;
		private CounterManager counterManager;
		private SysMonitorView monView;
		private MenuItem menuItem14;

		//		private AxSystemMonitor.AxSystemMonitor activeMonitor=null;
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}



		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MonitorForm));
			this.panel2 = new System.Windows.Forms.Panel();
			this.counterManager = new Osherove.PerfPlus.Controls.CounterManager();
			this.lblScale = new System.Windows.Forms.Label();
			this.cmdScaleMinus = new System.Windows.Forms.Button();
			this.cmdScalePlus = new System.Windows.Forms.Button();
			this.cmbTargetASPApp = new System.Windows.Forms.ComboBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.tabMenu = new System.Windows.Forms.ContextMenu();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.monView = new Osherove.PerfPlus.Controls.SysMonitorView();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.Controls.Add(this.counterManager);
			this.panel2.Controls.Add(this.lblScale);
			this.panel2.Controls.Add(this.cmdScaleMinus);
			this.panel2.Controls.Add(this.cmdScalePlus);
			this.panel2.Controls.Add(this.cmbTargetASPApp);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(224, 486);
			this.panel2.TabIndex = 9;
			// 
			// counterManager
			// 
			this.counterManager.ActivateNewTabCallback = null;
			this.counterManager.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.counterManager.Location = new System.Drawing.Point(0, 158);
			this.counterManager.MasterFolder = null;
			this.counterManager.Name = "counterManager";
			this.counterManager.Size = new System.Drawing.Size(224, 328);
			this.counterManager.SysMonHelper = null;
			this.counterManager.TabIndex = 12;
			// 
			// lblScale
			// 
			this.lblScale.AutoSize = true;
			this.lblScale.Location = new System.Drawing.Point(16, 16);
			this.lblScale.Name = "lblScale";
			this.lblScale.Size = new System.Drawing.Size(113, 19);
			this.lblScale.TabIndex = 7;
			this.lblScale.Text = "Target ASP app:";
			// 
			// cmdScaleMinus
			// 
			this.cmdScaleMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdScaleMinus.Location = new System.Drawing.Point(72, 88);
			this.cmdScaleMinus.Name = "cmdScaleMinus";
			this.cmdScaleMinus.Size = new System.Drawing.Size(32, 23);
			this.cmdScaleMinus.TabIndex = 10;
			this.cmdScaleMinus.Text = "-";
			// 
			// cmdScalePlus
			// 
			this.cmdScalePlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdScalePlus.Location = new System.Drawing.Point(32, 88);
			this.cmdScalePlus.Name = "cmdScalePlus";
			this.cmdScalePlus.Size = new System.Drawing.Size(32, 23);
			this.cmdScalePlus.TabIndex = 9;
			this.cmdScalePlus.Text = "+";
			// 
			// cmbTargetASPApp
			// 
			this.cmbTargetASPApp.Location = new System.Drawing.Point(16, 40);
			this.cmbTargetASPApp.Name = "cmbTargetASPApp";
			this.cmbTargetASPApp.Size = new System.Drawing.Size(121, 24);
			this.cmbTargetASPApp.TabIndex = 8;
			this.cmbTargetASPApp.Text = "__Total__";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(224, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 486);
			this.splitter1.TabIndex = 12;
			this.splitter1.TabStop = false;
			// 
			// tabMenu
			// 
			this.tabMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem9,
																					this.menuItem14,
																					this.menuItem10,
																					this.menuItem11,
																					this.menuItem13,
																					this.menuItem12});
			// 
			// menuItem9
			// 
			this.menuItem9.DefaultItem = true;
			this.menuItem9.Index = 0;
			this.menuItem9.Text = "&Close Tab";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 1;
			this.menuItem14.Text = "-";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 2;
			this.menuItem10.Text = "Close &Other Tabs";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "Close &All Tabs";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 4;
			this.menuItem13.Text = "-";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 5;
			this.menuItem12.Text = "&Rename...";
			// 
			// monView
			// 
			this.monView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.monView.Location = new System.Drawing.Point(232, 0);
			this.monView.Name = "monView";
			this.monView.Size = new System.Drawing.Size(456, 486);
			this.monView.TabIndex = 13;
			// 
			// MonitorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(688, 486);
			this.Controls.Add(this.monView);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MonitorForm";
			this.Text = "PerfMon+ By Roy osherove";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MonitorForm_Closing);
			this.Load += new System.EventHandler(this.MonitorForm_Load);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Panel panel2;
		private Label lblScale;
		private Button cmdScaleMinus;
		private Button cmdScalePlus;
		private ComboBox cmbTargetASPApp;
//		private CounterTree tv;
		private Splitter splitter1;
		public MonitorForm()
		{
			InitializeComponent();
			sysMonHelper.RequestSysMonitorObject+=new SysMonitorHelper.RequestSysMonitorObjectDelegate(sysMonHelper_RequestSysMonitorObject);
			counterManager.ActivateNewTabCallback=new CounterTree.ActivateNewTabDelegate(monView.AddNewMonitorTab);
		}
        
		private void MonitorForm_Load(object sender, EventArgs e)
		{
			counterManager.SysMonHelper=sysMonHelper;
			monView.SysMonHelper=sysMonHelper;

			monView.AddNewMonitorTab("Default");
			monView.LoadTabs(Path.Combine(Application.StartupPath,"tabs.xml"));
			counterManager.LoadCounters(Path.Combine(Application.StartupPath,"counters.xml"));
			counterManager.ActivateDefaultNode();
		}

	
	
		private SysMonitorHelper sysMonHelper = new SysMonitorHelper();
		private FocusActionsManager focusManager;

		private void MonitorForm_Closing(object sender, CancelEventArgs e)
		{
			counterManager.SaveCounters(Path.Combine(Application.StartupPath,"counters.xml"));
			monView.SaveTabs(Path.Combine(Application.StartupPath,"tabs.xml"));
		}


		private void sysMonHelper_RequestSysMonitorObject(out SysMonitorControlEx RequiredMonitor)
		{
			RequiredMonitor = monView.ActiveMonitorControl;
		}
		#region IActionable Members

		public FocusActionsManager FocusManager
		{
			get
			{
				
				return focusManager;
			}
			set
			{
				focusManager=value;
			}
		}
		
		#endregion
	}
    
}