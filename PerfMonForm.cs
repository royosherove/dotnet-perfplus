using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Osherove.PerfPlus.Controls;

namespace Osherove.PerfPlus
{
	/// <summary>
	/// Summary description for PerfMonForm.
	/// </summary>
	public class PerfMonForm : XtraForm,IActionable
	{

		private System.ComponentModel.IContainer components;
		private FocusActionsManager focusManager;
		
		private System.Windows.Forms.Panel panel1;
		private SysMonitorControlEx mon1;
		private Panel panel;		

		public PerfMonForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			mon1.Highlight = true;
			mon1.BorderStyle = 0;
			
			mon1.Enter+=new EventHandler(mon_Enter);
			this.Activated+=new EventHandler(PerfMonForm_Activated);
			MouseEnter+=new EventHandler(PerfMonForm_MouseEnter);
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

		#region Windows Form Designer generated code

		///<summary>
		///
		///<para>
		///Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
		///</para>
		///
		///</summary>
		///
		///<param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
//			mon1.GotFocus+=new EventHandler(mon1_GotFocus);
		}

		public SysMonitorControlEx MonitorControl
		{
			get
			{
				return (SysMonitorControlEx) mon1;
			}
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PerfMonForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.mon1 = new PerfPlus.Controls.SysMonitorControlEx();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mon1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.mon1);
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(542, 428);
			this.panel1.TabIndex = 0;
			// 
			// mon1
			// 
			this.mon1.ContainingControl = this;
			this.mon1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mon1.Enabled = true;
			this.mon1.FocusManager = null;
			this.mon1.Location = new System.Drawing.Point(0, 0);
			this.mon1.Name = "mon1";
			this.mon1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mon1.OcxState")));
			this.mon1.Size = new System.Drawing.Size(542, 428);
			this.mon1.TabIndex = 0;
			// 
			// PerfMonForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(568, 454);
			this.Controls.Add(this.panel1);
			this.Name = "PerfMonForm";
			this.Text = "Monitor";
			
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mon1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void axSystemMonitor1_OnCounterSelected(object sender, AxSystemMonitor.DISystemMonitorEvents_OnCounterSelectedEvent e)
		{
		
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
				mon1.FocusManager=value;
				focusManager = value;
			}
		}
		
		#endregion

		private void mon1_GotFocus(object sender, EventArgs e)
		{
						focusManager.ActivateActionsFor(FocusActionsManager.KEY_ACTIVEMONITOR);
		}

		private void mon1_Click(object sender, EventArgs e)
		{
			focusManager.ActivateActionsFor(FocusActionsManager.KEY_ACTIVEMONITOR);

		}

		private void PerfMonForm_Activated(object sender, EventArgs e)
		{
			focusManager.ActivateActionsFor(FocusActionsManager.KEY_ACTIVEMONITOR);

		}

		private void mon1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			FocusActions();
		}

		private void FocusActions()
		{
			if(focusManager!=null)
			focusManager.ActivateActionsFor(FocusActionsManager.KEY_ACTIVEMONITOR);
		}

		private void mon_GotFocus(object sender, EventArgs e)
		{
		FocusActions();
		}

		private void mon_Enter(object sender, EventArgs e)
		{
			FocusActions();
		}

		private void PerfMonForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			FocusActions();
		
		}

		private void PerfMonForm_MouseEnter(object sender, EventArgs e)
		{
			FocusActions();
		}
	}
}
