
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
            this.动画ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置缓入缓出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animePane = new System.Windows.Forms.SplitContainer();
            this.animeStart = new System.Windows.Forms.Button();
            this.animeStartEndSet = new System.Windows.Forms.SplitContainer();
            this.animeSaveStart = new System.Windows.Forms.Button();
            this.animeSaveEnd = new System.Windows.Forms.Button();
            this.scaleLable = new System.Windows.Forms.Label();
            this.scale = new System.Windows.Forms.TrackBar();
            this.rotZLable = new System.Windows.Forms.Label();
            this.rotYLable = new System.Windows.Forms.Label();
            this.rotXLable = new System.Windows.Forms.Label();
            this.ZposLable = new System.Windows.Forms.Label();
            this.YposLable = new System.Windows.Forms.Label();
            this.XposLable = new System.Windows.Forms.Label();
            this.rotX = new System.Windows.Forms.TrackBar();
            this.rotY = new System.Windows.Forms.TrackBar();
            this.rotZ = new System.Windows.Forms.TrackBar();
            this.Zpos = new System.Windows.Forms.TrackBar();
            this.Ypos = new System.Windows.Forms.TrackBar();
            this.Xpos = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.启用动画ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainContSplit)).BeginInit();
            this.MainContSplit.Panel1.SuspendLayout();
            this.MainContSplit.Panel2.SuspendLayout();
            this.MainContSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileSplit)).BeginInit();
            this.FileSplit.Panel1.SuspendLayout();
            this.FileSplit.Panel2.SuspendLayout();
            this.FileSplit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animePane)).BeginInit();
            this.animePane.Panel1.SuspendLayout();
            this.animePane.Panel2.SuspendLayout();
            this.animePane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animeStartEndSet)).BeginInit();
            this.animeStartEndSet.Panel1.SuspendLayout();
            this.animeStartEndSet.Panel2.SuspendLayout();
            this.animeStartEndSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zpos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ypos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xpos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            resources.ApplyResources(this.glControl1, "glControl1");
            this.glControl1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
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
            this.FileSplit.Panel2.Controls.Add(this.animePane);
            this.FileSplit.Panel2.Controls.Add(this.scaleLable);
            this.FileSplit.Panel2.Controls.Add(this.scale);
            this.FileSplit.Panel2.Controls.Add(this.rotZLable);
            this.FileSplit.Panel2.Controls.Add(this.rotYLable);
            this.FileSplit.Panel2.Controls.Add(this.rotXLable);
            this.FileSplit.Panel2.Controls.Add(this.ZposLable);
            this.FileSplit.Panel2.Controls.Add(this.YposLable);
            this.FileSplit.Panel2.Controls.Add(this.XposLable);
            this.FileSplit.Panel2.Controls.Add(this.rotX);
            this.FileSplit.Panel2.Controls.Add(this.rotY);
            this.FileSplit.Panel2.Controls.Add(this.rotZ);
            this.FileSplit.Panel2.Controls.Add(this.Zpos);
            this.FileSplit.Panel2.Controls.Add(this.Ypos);
            this.FileSplit.Panel2.Controls.Add(this.Xpos);
            this.FileSplit.Panel2.Controls.Add(this.trackBar1);
            this.FileSplit.Panel2.Controls.Add(this.treeView1);
            this.FileSplit.Panel2.Controls.Add(this.editModel);
            this.FileSplit.Panel2.Controls.Add(this.loadModel);
            this.FileSplit.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.动画ToolStripMenuItem,
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
            // 动画ToolStripMenuItem
            // 
            this.动画ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启用动画ToolStripMenuItem,
            this.设置缓入缓出ToolStripMenuItem});
            this.动画ToolStripMenuItem.Name = "动画ToolStripMenuItem";
            resources.ApplyResources(this.动画ToolStripMenuItem, "动画ToolStripMenuItem");
            // 
            // 设置缓入缓出ToolStripMenuItem
            // 
            this.设置缓入缓出ToolStripMenuItem.Name = "设置缓入缓出ToolStripMenuItem";
            resources.ApplyResources(this.设置缓入缓出ToolStripMenuItem, "设置缓入缓出ToolStripMenuItem");
            this.设置缓入缓出ToolStripMenuItem.Click += new System.EventHandler(this.设置缓入缓出ToolStripMenuItem_Click);
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
            // animePane
            // 
            resources.ApplyResources(this.animePane, "animePane");
            this.animePane.Name = "animePane";
            // 
            // animePane.Panel1
            // 
            this.animePane.Panel1.Controls.Add(this.animeStart);
            // 
            // animePane.Panel2
            // 
            this.animePane.Panel2.Controls.Add(this.animeStartEndSet);
            // 
            // animeStart
            // 
            resources.ApplyResources(this.animeStart, "animeStart");
            this.animeStart.BackColor = System.Drawing.Color.Snow;
            this.animeStart.Name = "animeStart";
            this.animeStart.UseVisualStyleBackColor = false;
            this.animeStart.Click += new System.EventHandler(this.animeStart_Click);
            // 
            // animeStartEndSet
            // 
            resources.ApplyResources(this.animeStartEndSet, "animeStartEndSet");
            this.animeStartEndSet.Name = "animeStartEndSet";
            // 
            // animeStartEndSet.Panel1
            // 
            this.animeStartEndSet.Panel1.Controls.Add(this.animeSaveStart);
            // 
            // animeStartEndSet.Panel2
            // 
            this.animeStartEndSet.Panel2.Controls.Add(this.animeSaveEnd);
            // 
            // animeSaveStart
            // 
            resources.ApplyResources(this.animeSaveStart, "animeSaveStart");
            this.animeSaveStart.BackColor = System.Drawing.Color.Snow;
            this.animeSaveStart.Name = "animeSaveStart";
            this.animeSaveStart.UseVisualStyleBackColor = false;
            this.animeSaveStart.Click += new System.EventHandler(this.animeSaveStart_Click);
            // 
            // animeSaveEnd
            // 
            resources.ApplyResources(this.animeSaveEnd, "animeSaveEnd");
            this.animeSaveEnd.BackColor = System.Drawing.Color.Snow;
            this.animeSaveEnd.Name = "animeSaveEnd";
            this.animeSaveEnd.UseVisualStyleBackColor = false;
            this.animeSaveEnd.Click += new System.EventHandler(this.animeSaveEnd_Click);
            // 
            // scaleLable
            // 
            resources.ApplyResources(this.scaleLable, "scaleLable");
            this.scaleLable.Name = "scaleLable";
            // 
            // scale
            // 
            resources.ApplyResources(this.scale, "scale");
            this.scale.Maximum = 3;
            this.scale.Minimum = -10;
            this.scale.Name = "scale";
            // 
            // rotZLable
            // 
            resources.ApplyResources(this.rotZLable, "rotZLable");
            this.rotZLable.Name = "rotZLable";
            // 
            // rotYLable
            // 
            resources.ApplyResources(this.rotYLable, "rotYLable");
            this.rotYLable.Name = "rotYLable";
            // 
            // rotXLable
            // 
            resources.ApplyResources(this.rotXLable, "rotXLable");
            this.rotXLable.Name = "rotXLable";
            // 
            // ZposLable
            // 
            resources.ApplyResources(this.ZposLable, "ZposLable");
            this.ZposLable.Name = "ZposLable";
            this.ZposLable.Click += new System.EventHandler(this.label3_Click);
            // 
            // YposLable
            // 
            resources.ApplyResources(this.YposLable, "YposLable");
            this.YposLable.Name = "YposLable";
            // 
            // XposLable
            // 
            resources.ApplyResources(this.XposLable, "XposLable");
            this.XposLable.Name = "XposLable";
            this.XposLable.Click += new System.EventHandler(this.label1_Click);
            // 
            // rotX
            // 
            resources.ApplyResources(this.rotX, "rotX");
            this.rotX.Maximum = 180;
            this.rotX.Minimum = -180;
            this.rotX.Name = "rotX";
            // 
            // rotY
            // 
            resources.ApplyResources(this.rotY, "rotY");
            this.rotY.Maximum = 180;
            this.rotY.Minimum = -180;
            this.rotY.Name = "rotY";
            // 
            // rotZ
            // 
            resources.ApplyResources(this.rotZ, "rotZ");
            this.rotZ.Maximum = 180;
            this.rotZ.Minimum = -180;
            this.rotZ.Name = "rotZ";
            // 
            // Zpos
            // 
            resources.ApplyResources(this.Zpos, "Zpos");
            this.Zpos.Maximum = 100;
            this.Zpos.Minimum = -100;
            this.Zpos.Name = "Zpos";
            // 
            // Ypos
            // 
            resources.ApplyResources(this.Ypos, "Ypos");
            this.Ypos.Maximum = 100;
            this.Ypos.Minimum = -100;
            this.Ypos.Name = "Ypos";
            // 
            // Xpos
            // 
            resources.ApplyResources(this.Xpos, "Xpos");
            this.Xpos.Maximum = 100;
            this.Xpos.Minimum = -100;
            this.Xpos.Name = "Xpos";
            this.Xpos.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.Name = "trackBar1";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
            // 
            // 启用动画ToolStripMenuItem
            // 
            this.启用动画ToolStripMenuItem.Name = "启用动画ToolStripMenuItem";
            resources.ApplyResources(this.启用动画ToolStripMenuItem, "启用动画ToolStripMenuItem");
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
            this.animePane.Panel1.ResumeLayout(false);
            this.animePane.Panel1.PerformLayout();
            this.animePane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.animePane)).EndInit();
            this.animePane.ResumeLayout(false);
            this.animeStartEndSet.Panel1.ResumeLayout(false);
            this.animeStartEndSet.Panel1.PerformLayout();
            this.animeStartEndSet.Panel2.ResumeLayout(false);
            this.animeStartEndSet.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animeStartEndSet)).EndInit();
            this.animeStartEndSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zpos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ypos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xpos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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
        private System.Windows.Forms.TrackBar rotX;
        private System.Windows.Forms.TrackBar rotY;
        private System.Windows.Forms.TrackBar rotZ;
        private System.Windows.Forms.TrackBar Zpos;
        private System.Windows.Forms.TrackBar Ypos;
        private System.Windows.Forms.TrackBar Xpos;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label rotZLable;
        private System.Windows.Forms.Label rotYLable;
        private System.Windows.Forms.Label rotXLable;
        private System.Windows.Forms.Label ZposLable;
        private System.Windows.Forms.Label YposLable;
        private System.Windows.Forms.Label XposLable;
        private System.Windows.Forms.Label scaleLable;
        private System.Windows.Forms.TrackBar scale;
        private System.Windows.Forms.SplitContainer animePane;
        private System.Windows.Forms.SplitContainer animeStartEndSet;
        private System.Windows.Forms.Button animeStart;
        private System.Windows.Forms.Button animeSaveStart;
        private System.Windows.Forms.Button animeSaveEnd;
        private System.Windows.Forms.ToolStripMenuItem 动画ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置缓入缓出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启用动画ToolStripMenuItem;
    }
}

