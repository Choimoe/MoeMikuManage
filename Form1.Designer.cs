
namespace MoeMikuManage
{
    partial class ModelViewer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelViewer));
            this.glControl1 = new OpenTK.GLControl();
            this.loadModel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.editModel = new System.Windows.Forms.Button();
            this.DirInfo = new System.Windows.Forms.TextBox();
            this.MainContSplit = new System.Windows.Forms.SplitContainer();
            this.FileSplit = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.MainContSplit)).BeginInit();
            this.MainContSplit.Panel1.SuspendLayout();
            this.MainContSplit.Panel2.SuspendLayout();
            this.MainContSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileSplit)).BeginInit();
            this.FileSplit.Panel1.SuspendLayout();
            this.FileSplit.Panel2.SuspendLayout();
            this.FileSplit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            resources.ApplyResources(this.glControl1, "glControl1");
            this.glControl1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.glControl1.Name = "glControl1";
            this.glControl1.VSync = false;
            this.glControl1.AutoSizeChanged += new System.EventHandler(this.glControl1_AutoSizeChanged);
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_AutoSizeChanged);
            // 
            // loadModel
            // 
            resources.ApplyResources(this.loadModel, "loadModel");
            this.loadModel.BackColor = System.Drawing.Color.White;
            this.loadModel.Name = "loadModel";
            this.loadModel.UseVisualStyleBackColor = false;
            this.loadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // editModel
            // 
            resources.ApplyResources(this.editModel, "editModel");
            this.editModel.BackColor = System.Drawing.Color.White;
            this.editModel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.editModel.Name = "editModel";
            this.editModel.UseVisualStyleBackColor = false;
            this.editModel.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // DirInfo
            // 
            this.DirInfo.BackColor = System.Drawing.SystemColors.Control;
            this.DirInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DirInfo.CausesValidation = false;
            resources.ApplyResources(this.DirInfo, "DirInfo");
            this.DirInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DirInfo.Name = "DirInfo";
            this.DirInfo.ReadOnly = true;
            // 
            // MainContSplit
            // 
            resources.ApplyResources(this.MainContSplit, "MainContSplit");
            this.MainContSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainContSplit.Name = "MainContSplit";
            // 
            // MainContSplit.Panel1
            // 
            this.MainContSplit.Panel1.Controls.Add(this.FileSplit);
            this.MainContSplit.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // MainContSplit.Panel2
            // 
            this.MainContSplit.Panel2.Controls.Add(this.glControl1);
            // 
            // FileSplit
            // 
            resources.ApplyResources(this.FileSplit, "FileSplit");
            this.FileSplit.Name = "FileSplit";
            // 
            // FileSplit.Panel1
            // 
            this.FileSplit.Panel1.Controls.Add(this.DirInfo);
            this.FileSplit.Panel1.Controls.Add(this.menuStrip1);
            // 
            // FileSplit.Panel2
            // 
            this.FileSplit.Panel2.Controls.Add(this.treeView1);
            this.FileSplit.Panel2.Controls.Add(this.editModel);
            this.FileSplit.Panel2.Controls.Add(this.loadModel);
            this.FileSplit.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载模型ToolStripMenuItem,
            this.清除模型ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            resources.ApplyResources(this.文件ToolStripMenuItem, "文件ToolStripMenuItem");
            // 
            // 加载模型ToolStripMenuItem
            // 
            this.加载模型ToolStripMenuItem.Name = "加载模型ToolStripMenuItem";
            resources.ApplyResources(this.加载模型ToolStripMenuItem, "加载模型ToolStripMenuItem");
            // 
            // 清除模型ToolStripMenuItem
            // 
            this.清除模型ToolStripMenuItem.Name = "清除模型ToolStripMenuItem";
            resources.ApplyResources(this.清除模型ToolStripMenuItem, "清除模型ToolStripMenuItem");
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.检查更新ToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            resources.ApplyResources(this.关于ToolStripMenuItem, "关于ToolStripMenuItem");
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 检查更新ToolStripMenuItem
            // 
            this.检查更新ToolStripMenuItem.Name = "检查更新ToolStripMenuItem";
            resources.ApplyResources(this.检查更新ToolStripMenuItem, "检查更新ToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
            // 
            // ModelViewer
            // 
            this.AcceptButton = this.loadModel;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.editModel;
            this.Controls.Add(this.MainContSplit);
            this.Controls.Add(this.flowLayoutPanel1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ModelViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MainContSplit.Panel1.ResumeLayout(false);
            this.MainContSplit.Panel2.ResumeLayout(false);
            this.MainContSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContSplit)).EndInit();
            this.MainContSplit.ResumeLayout(false);
            this.FileSplit.Panel1.ResumeLayout(false);
            this.FileSplit.Panel1.PerformLayout();
            this.FileSplit.Panel2.ResumeLayout(false);
            this.FileSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileSplit)).EndInit();
            this.FileSplit.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Button loadModel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button editModel;
        private System.Windows.Forms.TextBox DirInfo;
        private System.Windows.Forms.SplitContainer MainContSplit;
        private System.Windows.Forms.SplitContainer FileSplit;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

