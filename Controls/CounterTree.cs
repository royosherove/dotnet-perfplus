using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using SystemMonitor;
using Microsoft.VisualBasic;
using SysMonitor;

namespace Osherove.PerfPlus.Controls
{
	public class CounterTree:TreeView,IActionable
	{
		public CounterTree()
		{
			InitializeComponent();
			LabelEdit=true;
			mnuAddCurrentCounters.Click+=new EventHandler(mnuAddCurrentCounters_Click);
			mnuChangeMachineName.Click+=new EventHandler(mnuChangeMachineName_Click);
			mnuDelete.Click+=new EventHandler(mnuDelete_Click);
			mnuNewRootFolder.Click+=new EventHandler(mnuNewRootFolder_Click);
			mnuNewSubFolder.Click+=new EventHandler(mnuNewSubFolder_Click);
			mnuSaveVisualProperties.Click+=new EventHandler(mnuSaveVisualProperties_Click);
			mnuShowInActiveTab.Click+=new EventHandler(mnuShowInActiveTab_Click);
			mnuShowInNewTab.Click+=new EventHandler(mnuShowInNewTab_Click);
			mnuChangeInstanceName.Click+=new EventHandler(mnuChangeInstanceName_Click);
			this.MouseDown+=new MouseEventHandler(tv_MouseDown);
			this.AfterLabelEdit+=new NodeLabelEditEventHandler(tv_AfterLabelEdit);
			this.KeyDown+=new KeyEventHandler(tv_KeyDown);
			this.MouseEnter+=new EventHandler(CounterTree_MouseEnter);
			this.ContextMenu=treeMenu;
			
		}

		///<summary>
		///
		///<para>
		///Raises the <see cref="E:System.Windows.Forms.Control.Click" />
		///event.
		///</para>
		///
		///</summary>
		///
		///<param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnClick(EventArgs e)
		{

			base.OnClick(e);
		}

		private void FocusActions()
		{
			focusManager.ActivateActionsFor(FocusActionsManager.KEY_LIBRARY_FOLDER);
		}

		///<summary>
		///
		///<para>
		///Raises the <see cref="E:System.Windows.Forms.TreeView.AfterSelect" /> event.
		///</para>
		///
		///</summary>
		///
		///<param name="e">A <see cref="T:System.Windows.Forms.TreeViewEventArgs" /> that contains the event data.</param>
		protected override void OnAfterSelect(TreeViewEventArgs e)
		{
			if(SelectedItem!=null)
			{
				focusManager.ActivateActionsFor(FocusActionsManager.KEY_LIBRARY_COUNTER);
			}
			else
			{
				focusManager.ActivateActionsFor(FocusActionsManager.KEY_LIBRARY_FOLDER);
			}
			base.OnAfterSelect(e);
		}


		private System.Windows.Forms.ContextMenu treeMenu;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem mnuSaveVisualProperties;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem mnuShowInActiveTab;
		private System.Windows.Forms.MenuItem mnuChangeInstanceName;
		private System.Windows.Forms.MenuItem mnuShowInNewTab;
		private System.Windows.Forms.MenuItem mnuAddCurrentCounters;
		private System.Windows.Forms.MenuItem mnuChangeMachineName;
		private System.Windows.Forms.MenuItem mnuNewRootFolder;
		private System.Windows.Forms.MenuItem mnuNewSubFolder;
		private System.Windows.Forms.ImageList imglstTree;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem mnuDelete;
	
		public CounterFolder MasterFolder
		{
			get
			{
//			if(masterFolder==null)
//			 {
//				 masterFolder = new CounterFolder();
//			 }
				return null;
			}
//			set { masterFolder = value; }
			set { throw new NotImplementedException(); }
		}

//		private CounterFolder masterFolder=new CounterFolder();

		public void DeleteSelectedNode()
		{
			if(SelectedNode==null)
			{
				return;
			}
			if(TreeSelectedCounter!=null)
			{
				TreeSelectedFolder.Counterinfos.Remove(TreeSelectedCounter);
			}
			if(TreeSelectedFolder!=null)
			{
				if(TreeSelectedFolderNode.Parent!=null)
				{
					CounterFolder parentFolder=TreeSelectedFolderNode.Parent.Tag as CounterFolder;
					parentFolder.SubFolders.Remove(TreeSelectedFolder);
				}
				else
				{
//					masterFolder.SubFolders.Remove(TreeSelectedFolder);
				}
			}
			TreeSelectedFolderNode.Remove();
		}

		public void AddFolderToTreeRecursive(CounterFolder root,TreeNode parentNode)
		{
			TreeNode rootNode = null;

			if(parentNode==null)
			{
				parentNode= Nodes.Add(root.Name);
				parentNode.Tag= root;
				parentNode.ImageIndex = 0;
				rootNode=parentNode;
			}
			else
			{
				rootNode = AddFolderToTree(parentNode, root);
			}
			parentNode.Expand();

			foreach (CounterInfo counterinfo in root.Counterinfos)
			{
				AddCounterToTree(rootNode,counterinfo);
			}
			foreach (CounterFolder folder in root.SubFolders)
			{
				AddFolderToTreeRecursive(folder,rootNode);
			}
		}

		
		public TreeNode AddFolderToTree(TreeNode parentNode, CounterFolder folder)
		{
			TreeNode rootNode;
			if(parentNode==null)
			{
				rootNode=Nodes.Add(folder.Name);
			}
			else
			{
				rootNode=parentNode.Nodes.Add(folder.Name);
			}
			rootNode.Tag= folder;
			return rootNode;
		}

		private TreeNode AddCounterToTree(TreeNode parent, CounterInfo counterinfo)
		{
			TreeNode node = parent.Nodes.Add(counterinfo.FinalPath);
			node.Tag=counterinfo;
			node.ImageIndex = 2;
			node.SelectedImageIndex = 2;
			return node;
		}


		public CounterInfo TreeSelectedCounter
		{
			get
			{
				TreeNode selected = SelectedNode;
				if(selected!=null && selected.Tag !=null 
					&& selected.Tag is CounterInfo )
				{
					return selected.Tag as CounterInfo;
				}
				return null;
			}
		}

		public CounterFolder TreeSelectedFolder
		{
			get
			{
				TreeNode selected = SelectedNode;
				if(selected!=null && selected.Tag !=null 
					&& selected.Tag is CounterFolder )
				{
					return selected.Tag as CounterFolder;
				}
				else
				{
					if(TreeSelectedCounter!=null)
					{
						return selected.Parent.Tag as CounterFolder;
					}	
				}
				return Nodes[0].Tag as CounterFolder;
			}
		}
		
		public TreeNode TreeSelectedFolderNode
		{
			get
			{
				TreeNode selected = SelectedNode;
				if(selected!=null && selected.Tag !=null 
					&& selected.Tag is CounterFolder )
				{
					return selected;
				}
				else
				{
					if(TreeSelectedCounter!=null)
					{
						return selected.Parent;
					}	
				}
				return Nodes[0];
			}
		}

		private void tv_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if(isLoading)
				return;
			UpdateObjectFromNewLabel(e.Node.Tag,e.Label);
		}

		private void UpdateObjectFromNewLabel(object labeledObject,string newLabel)
		{
			if(newLabel==null || newLabel.Trim()==string.Empty)
				return;
			
			if(labeledObject is CounterFolder)
			{
				((CounterFolder)labeledObject).Name=newLabel;
			}
			
			if(labeledObject is CounterInfo)
			{
				((CounterInfo)labeledObject).OriginalPath=newLabel;
				
			}
		}
		
		private bool isLoading=false;
		public void AddExistingCountersToTree(AxSystemMonitor.AxSystemMonitor ActiveMonitor)
		{
			isLoading = true;
			CounterFolder folder = TreeSelectedFolder;
			int count = ActiveMonitor.Counters.Count;
			for (int i=1;i<=count;i++)
			{
				CounterItem currentUICounter = ActiveMonitor.Counters[i];
				AddNewSysCounterFromUI(currentUICounter, folder);
			}
			isLoading = false;
		}

		private void tv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Delete)
			{
				DeleteSelectedNode();
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CounterTree));
			this.treeMenu = new System.Windows.Forms.ContextMenu();
			this.mnuShowInActiveTab = new System.Windows.Forms.MenuItem();
			this.mnuChangeInstanceName = new System.Windows.Forms.MenuItem();
			this.mnuShowInNewTab = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.mnuAddCurrentCounters = new System.Windows.Forms.MenuItem();
			this.mnuSaveVisualProperties = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuNewSubFolder = new System.Windows.Forms.MenuItem();
			this.mnuNewRootFolder = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.mnuChangeMachineName = new System.Windows.Forms.MenuItem();
			this.mnuDelete = new System.Windows.Forms.MenuItem();
			this.imglstTree = new System.Windows.Forms.ImageList(this.components);
			// 
			// treeMenu
			// 
			this.treeMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuShowInActiveTab,
																					 this.mnuShowInNewTab,
																					 this.menuItem7,
																					 this.mnuAddCurrentCounters,
																					 this.mnuSaveVisualProperties,
																					 this.menuItem2,
																					 this.mnuNewSubFolder,
																					 this.mnuNewRootFolder,
																					 this.menuItem6,
																					 this.mnuChangeMachineName,
																					 this.mnuChangeInstanceName,
																					 this.mnuDelete});
			this.treeMenu.Popup += new System.EventHandler(this.treeMenu_Popup);
			// 
			// mnuShowInActiveTab
			// 
			this.mnuShowInActiveTab.DefaultItem = true;
			this.mnuShowInActiveTab.Index = 0;
			this.mnuShowInActiveTab.Text = "Show in &Active Tab";
			// 
			// mnuShowInNewTab
			// 
			this.mnuShowInNewTab.Index = 1;
			this.mnuShowInNewTab.Text = "Show in &New Tab";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "-";
			// 
			// mnuAddCurrentCounters
			// 
			this.mnuAddCurrentCounters.Index = 3;
			this.mnuAddCurrentCounters.Text = "Add Current Counters to this folder";
			// 
			// mnuSaveVisualProperties
			// 
			this.mnuSaveVisualProperties.Index = 4;
			this.mnuSaveVisualProperties.Text = "Save Counter(s) Visual Properties";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "-";
			// 
			// mnuNewSubFolder
			// 
			this.mnuNewSubFolder.Index = 6;
			this.mnuNewSubFolder.Text = "New &Sub Folder";
			// 
			// mnuNewRootFolder
			// 
			this.mnuNewRootFolder.Index = 7;
			this.mnuNewRootFolder.Text = "New &Root Folder";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 8;
			this.menuItem6.Text = "-";
			// 
			// mnuChangeMachineName
			// 
			this.mnuChangeMachineName.Index = 9;
			this.mnuChangeMachineName.Text = "Change Machine Name...";
			
			// 
			// mnuChangeInstanceName
			// 
			this.mnuChangeInstanceName.Index = 9;
			this.mnuChangeInstanceName.Text = @"Change target &instance...";
			// 
			// mnuDelete
			// 
			this.mnuDelete.Index = 10;
			this.mnuDelete.Text = "Delete";
			// 
			// imglstTree
			// 
			this.imglstTree.ImageSize = new System.Drawing.Size(16, 16);
			this.imglstTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstTree.ImageStream")));
			this.imglstTree.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// CounterTree
			// 
			this.ImageIndex = 0;
			this.ImageList = this.imglstTree;
			this.SelectedImageIndex = 0;

		}

		private void AddNewSysCounterFromUI(CounterItem currentUICounter, CounterFolder folder)
		{
			
			CounterInfo newCOunterInfo = CounterInfoHelper.FromPerfmonCounter(currentUICounter);
			if(folder.ContainsCounter(newCOunterInfo))
			{
				return;
			}
			folder.Counterinfos.Add(newCOunterInfo);
			AddCounterToTree(TreeSelectedFolderNode, newCOunterInfo);
		}

		private void tv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			FocusActions();
			
			if(e.Button!=MouseButtons.Right )
			{
				return;
			}

			TreeNode possibleNode = GetNodeAt(e.X,e.Y);
			if(possibleNode==null)
			{
				return;
			}
			SelectedNode= possibleNode;
		}
		
		CounterItem SelectedItem=null;
		
		private SysMonitorHelper sysMonHelper;

		public SysMonitorHelper SysMonHelper
		{
			get { return sysMonHelper; }
			set { sysMonHelper = value; }
		}

		private void mnuSaveVisualProperties_Click(object sender, System.EventArgs e)
		{
			SaveVisualProperties(sysMonHelper.Monitor,SelectedItem);
		}

		private void SaveVisualProperties(AxSystemMonitor.AxSystemMonitor ActiveMonitor,CounterItem SelectedCounter)
		{
			if(TreeSelectedCounter==null)
			{
				int sysCountersCount=ActiveMonitor.Counters.Count;
				CounterFolder folder = TreeSelectedFolder;
				for(int i=1;i<=sysCountersCount;i++)
				{
					CounterInfo info= (CounterInfo) folder.Counterinfos[i-1];
					CounterItem item= ActiveMonitor.Counters[i];
					SaveCounterVisualProperties(info,item);
				}
			}
			else
			{
				SaveCounterVisualProperties(TreeSelectedCounter,SelectedCounter);
			}
			MessageBox.Show("Saved!");
		}

		
		public void LoadDefaultCounters()
		{

			CounterFolder defaultFolder = new CounterFolder();
			defaultFolder.Description="Default";
			defaultFolder.Name="Default";
//			if(masterFolder==null)
//			{
//				masterFolder=new CounterFolder();
//			}
//			masterFolder.SubFolders.Add(defaultFolder);
//			
			AddFolderToTreeRecursive(defaultFolder,null);

		}

		public void InsertNewSubFolder()
		{
    		
			CounterFolder newfolder = new CounterFolder();
			newfolder.Name= "New Folder";
			TreeSelectedFolder.SubFolders.Add(newfolder);
			TreeNode newTreenode = AddFolderToTree(TreeSelectedFolderNode, newfolder);
			newTreenode.Parent.Expand();
			SelectedNode=newTreenode;
			newTreenode.BeginEdit();
		}

		public void InsertNewRootFolder()
		{
			CounterFolder newfolder = new CounterFolder();
			newfolder.Name= "New Folder";
//			MasterFolder.SubFolders.Add(newfolder);
			TreeNode newTreenode = AddFolderToTree(null, newfolder);
			SelectedNode=newTreenode;
			
			Focus();
			SelectedNode = newTreenode;
			newTreenode.BeginEdit();
		}
		public void LoadCounters(string file)
		{
			throw new NotImplementedException("don't use this");
//			string countersFile= file;
//			if(!File.Exists(countersFile))
//			{
//				LoadDefaultCounters();
//				return;
//			}
//			masterFolder = (CounterFolder)CounterFolder.Load(countersFile,typeof(CounterFolder));
//			if(masterFolder.SubFolders.Count==0)
//			{
//				LoadDefaultCounters();
//				return;
//			}
//			foreach (CounterFolder subFolder in masterFolder.SubFolders)
//			{
//				AddFolderToTreeRecursive(subFolder,null);
//			}
		}

		private void SaveCounterVisualProperties(CounterInfo counterInfo, CounterItem item)
		{
			if(counterInfo.OriginalPath!=item.Path)
			{
				return;
			}
			CounterInfoHelper.SaveCounterItemInfo(item,counterInfo);
		}


		public void ChangeMachineNameforCounters()
		{
			if(SelectedNode==null)
				return;
			string oldMachineName = GetCurrentMachineNameFromActiveTreeCounters();
			string newName = Interaction.InputBox("Enter machine name for current counter(s)","Set Machine Name",oldMachineName,Location.X,Location.Y);
			if(newName==string.Empty || newName	==oldMachineName	)
				return;
			if(TreeSelectedCounter!=null)
			{
				SetNewMachineNameForCounter(TreeSelectedCounter,newName);
				SelectedNode.Text = TreeSelectedCounter.FinalPath;
			}
			else
			{
				CounterFolder folder = TreeSelectedFolder;
				SetMachineNameForAllCountersInFolder(folder, newName);
				if(folder.SubFolders.Count>0)
				{
					string question = "Would you like to set the machine name for all sub folders as well?";
				
					DialogResult userReply = MessageBox.Show(question, "Apply to sub folders?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if(userReply==DialogResult.Yes)
					{
						foreach (CounterFolder subFolder in folder.SubFolders)
						{
							SetMachineNameForAllCountersInFolder(subFolder, newName);
						}
					}
				}
				foreach (TreeNode n in TreeSelectedFolderNode.Nodes)
				{
					if(n.Tag!= null && n.Tag is CounterInfo)
					{
						n.Text = (n.Tag as CounterInfo).FinalPath;
					}
				}
			}
		}

		public void ChangeInstanceNameforCounters()
		{
			if(SelectedNode==null)
				return;
			string oldInstanceNamre = "OLD";// GetCurrentMachineNameFromActiveTreeCounters();
			string newName = Interaction.InputBox("Enter target application name for current counter(s)","Set Machine Name",oldInstanceNamre,Location.X,Location.Y);
			if(newName==string.Empty || newName	==oldInstanceNamre	)
				return;
			if(TreeSelectedCounter!=null)
			{
				SetNewInstanceNameForCounter(TreeSelectedCounter,newName);
				SelectedNode.Text = TreeSelectedCounter.FinalPath;
			}
			else
			{
				CounterFolder folder = TreeSelectedFolder;
				SetInstanceeNameForAllCountersInFolder(folder, newName);
				if(folder.SubFolders.Count>0)
				{
					string question = "Would you like to set the instance name for all sub folders as well?";
				
					DialogResult userReply = MessageBox.Show(question, "Apply to sub folders?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if(userReply==DialogResult.Yes)
					{
						foreach (CounterFolder subFolder in folder.SubFolders)
						{
							SetInstanceeNameForAllCountersInFolder(subFolder, newName);
						}
					}
				}
				foreach (TreeNode n in TreeSelectedFolderNode.Nodes)
				{
					if(n.Tag!= null && n.Tag is CounterInfo)
					{
						n.Text = (n.Tag as CounterInfo).FinalPath;
					}
				}
			}
		}

		private void SetMachineNameForAllCountersInFolder(CounterFolder folder, string newName)
		{
			foreach (CounterInfo info in folder.Counterinfos)
			{
				SetNewMachineNameForCounter(info,newName);
			}
		}
		
		private void SetInstanceeNameForAllCountersInFolder(CounterFolder folder, string newName)
		{
			foreach (CounterInfo info in folder.Counterinfos)
			{
				SetNewInstanceNameForCounter(info,newName);
			}
		}

		private void SetNewMachineNameForCounter(CounterInfo info,string newMachineName)
		{
			//    		info.OriginalPath = newMachineName + "\\" + info.ShortName;
			info.Machine = newMachineName;
		}
		
		private void SetNewInstanceNameForCounter(CounterInfo info,string instance)
		{
			//    		info.OriginalPath = newMachineName + "\\" + info.ShortName;
			info.TargetInstance = instance;
		}

		private string GetCurrentMachineNameFromActiveTreeCounters()
		{
			if(TreeSelectedCounter!=null)
			{
				return TreeSelectedCounter.Machine;
			}
			return string.Empty;
		}

		private void treeMenu_Popup(object sender, System.EventArgs e)
		{
		
		}

		private void mnuAddCurrentCounters_Click(object sender, EventArgs e)
		{
			AddExistingCountersToTree(sysMonHelper.Monitor);
		}

		private void mnuChangeMachineName_Click(object sender, EventArgs e)
		{
			ChangeMachineNameforCounters();
		}

		private void mnuDelete_Click(object sender, EventArgs e)
		{
			DeleteSelectedNode();
		}

		private void mnuNewRootFolder_Click(object sender, EventArgs e)
		{
			InsertNewRootFolder();
		}

		private void mnuNewSubFolder_Click(object sender, EventArgs e)
		{
			InsertNewSubFolder();
		}

		private void mnuShowInActiveTab_Click(object sender, EventArgs e)
		{
			ActivateInCurrentTab();
		}

		public void ActivateInCurrentTab()
		{
			if(SelectedNode==null)
				return;

			try
			{
				doAddToTab(SelectedNode.Tag);
			}
			catch (InvalidOperationException e)
			{
				ActivateInNewTab();
			}
		}

		public delegate void ActivateNewTabDelegate(string title);

		public ActivateNewTabDelegate ActivateNewTabCallback
		{
			get { return activateNewTabCallback; }
			set
			{ activateNewTabCallback=value; }
		}

		private ActivateNewTabDelegate activateNewTabCallback=null;
		private FocusActionsManager focusManager;

		private void mnuShowInNewTab_Click(object sender, EventArgs e)
		{
			ActivateInNewTab();
		}

		public void ActivateInNewTab()
		{
			if(ActivateNewTabCallback==null)
			{
				throw new Exception("You must initialize ActivateNewTabCallback in order to activate somethign in a new tab");
			}
			if(SelectedNode==null)
				return;
			ActivateNewTabCallback(SelectedNode.Text);
			doAddToTab(SelectedNode.Tag);
		}

		private void doAddToTab(object tag)
		{
			sysMonHelper.ActivateCountersFromObject(tag);
			if(tag is CounterFolder)
			{
				CounterFolder tagFolder = tag as CounterFolder;
				foreach (CounterFolder subfolder in tagFolder.SubFolders)
				{
					activateNewTabCallback(subfolder.Name);
					doAddToTab(subfolder);
				}
			}
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

		private void CounterTree_MouseEnter(object sender, EventArgs e)
		{
			FocusActions();
		}

		public CounterFolder GetAllWithSingleRoot()
		{
			CounterFolder master = new CounterFolder();
			master.Name = "root";
			foreach (TreeNode node in Nodes)
			{
				if(node.Tag !=null && node.Tag is CounterFolder)
				{
					master.SubFolders.Add(node.Tag);
//					AddSubNodes(node, node.Tag as CounterFolder);
				}
			}	
			
			return master;
		}

		private void AddSubNodes(TreeNode rootNode, CounterFolder parent)
		{
			foreach (TreeNode node in rootNode.Nodes)
			{
				if(node.Tag !=null && node.Tag is CounterFolder)
				{
					parent.SubFolders.Add(node.Tag);
					AddSubNodes(node, node.Tag as CounterFolder);
				}
				
				if(node.Tag !=null && node.Tag is CounterInfo)
				{
//					parent.Counterinfos.Add(node.Tag);
				}			
			}	
		}

		private void mnuChangeInstanceName_Click(object sender, EventArgs e)
		{
			ChangeInstanceNameforCounters();
		}
	}
}
