namespace goatMP3vF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.trackPositionBar = new System.Windows.Forms.TrackBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rightclickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shuffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleButton = new System.Windows.Forms.Button();
            this.positionBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.titleUpdate = new System.ComponentModel.BackgroundWorker();
            this.opacityUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackPositionBar)).BeginInit();
            this.rightclickMenu.SuspendLayout();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // trackPositionBar
            // 
            this.trackPositionBar.Location = new System.Drawing.Point(256, 12);
            this.trackPositionBar.Maximum = 100;
            this.trackPositionBar.Name = "trackPositionBar";
            this.trackPositionBar.Size = new System.Drawing.Size(98, 45);
            this.trackPositionBar.TabIndex = 13;
            this.trackPositionBar.Value = 100;
            this.trackPositionBar.Scroll += new System.EventHandler(this.volBar);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.ContextMenuStrip = this.rightclickMenu;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 80);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(371, 460);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.sort);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.listView1.DoubleClick += new System.EventHandler(this.playSong);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.del);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Artist";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 198;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 0;
            // 
            // rightclickMenu
            // 
            this.rightclickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4});
            this.rightclickMenu.Name = "contextMenuStrip1";
            this.rightclickMenu.Size = new System.Drawing.Size(136, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem1.Text = "Add files";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.fileAddClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem3.Text = "Add folders";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.folderAddClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem2.Text = "Delete files";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem4.Text = "Shuffle";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.shuffleToolStripMenuItem_Click);
            // 
            // button6
            // 
            this.button6.Image = global::goatMP3vF.Properties.Resources.folder;
            this.button6.Location = new System.Drawing.Point(360, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(23, 23);
            this.button6.TabIndex = 14;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.playlistManagerOpen);
            // 
            // button5
            // 
            this.button5.Image = global::goatMP3vF.Properties.Resources.control_end;
            this.button5.Location = new System.Drawing.Point(212, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 23);
            this.button5.TabIndex = 12;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.nextButton);
            // 
            // button4
            // 
            this.button4.Image = global::goatMP3vF.Properties.Resources.control_play;
            this.button4.Location = new System.Drawing.Point(163, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 23);
            this.button4.TabIndex = 11;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.playButton);
            // 
            // button3
            // 
            this.button3.Image = global::goatMP3vF.Properties.Resources.control_stop;
            this.button3.Location = new System.Drawing.Point(110, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 23);
            this.button3.TabIndex = 10;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.stopButton);
            // 
            // button2
            // 
            this.button2.Image = global::goatMP3vF.Properties.Resources.control_pause;
            this.button2.Location = new System.Drawing.Point(61, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 23);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.pauseButton);
            // 
            // button1
            // 
            this.button1.Image = global::goatMP3vF.Properties.Resources.control_rewind;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.backButton);
            // 
            // menuBar
            // 
            this.menuBar.Dock = System.Windows.Forms.DockStyle.None;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.playlistToolStripMenuItem,
            this.orderToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(12, 49);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(150, 24);
            this.menuBar.TabIndex = 21;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFoldersToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addFilesToolStripMenuItem.Text = "Add files";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.fileAddClick);
            // 
            // addFoldersToolStripMenuItem
            // 
            this.addFoldersToolStripMenuItem.Name = "addFoldersToolStripMenuItem";
            this.addFoldersToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addFoldersToolStripMenuItem.Text = "Add folders";
            this.addFoldersToolStripMenuItem.Click += new System.EventHandler(this.folderAddClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.shuffleToolStripMenuItem});
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.playlistToolStripMenuItem.Text = "Playlist";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.savePlaylistToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadPlaylistToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // shuffleToolStripMenuItem
            // 
            this.shuffleToolStripMenuItem.Name = "shuffleToolStripMenuItem";
            this.shuffleToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.shuffleToolStripMenuItem.Text = "Shuffle";
            this.shuffleToolStripMenuItem.Click += new System.EventHandler(this.shuffleToolStripMenuItem_Click);
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearToolStripMenuItem,
            this.randomToolStripMenuItem,
            this.loopToolStripMenuItem,
            this.popToolStripMenuItem,
            this.sortByFolderToolStripMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // linearToolStripMenuItem
            // 
            this.linearToolStripMenuItem.Name = "linearToolStripMenuItem";
            this.linearToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.linearToolStripMenuItem.Text = "* Linear";
            this.linearToolStripMenuItem.Click += new System.EventHandler(this.button11_Click);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.randomToolStripMenuItem.Text = "Random";
            this.randomToolStripMenuItem.Click += new System.EventHandler(this.button10_Click);
            // 
            // loopToolStripMenuItem
            // 
            this.loopToolStripMenuItem.Name = "loopToolStripMenuItem";
            this.loopToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.loopToolStripMenuItem.Text = "Loop";
            this.loopToolStripMenuItem.Click += new System.EventHandler(this.loopToolStripMenuItem_Click);
            // 
            // popToolStripMenuItem
            // 
            this.popToolStripMenuItem.Name = "popToolStripMenuItem";
            this.popToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.popToolStripMenuItem.Text = "Pop";
            this.popToolStripMenuItem.Click += new System.EventHandler(this.popToolStripMenuItem_Click);
            // 
            // sortByFolderToolStripMenuItem
            // 
            this.sortByFolderToolStripMenuItem.Name = "sortByFolderToolStripMenuItem";
            this.sortByFolderToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.sortByFolderToolStripMenuItem.Text = "Sort by folder";
            this.sortByFolderToolStripMenuItem.Click += new System.EventHandler(this.sortByFolderToolStripMenuItem_Click);
            // 
            // toggleButton
            // 
            this.toggleButton.Location = new System.Drawing.Point(292, 50);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(91, 23);
            this.toggleButton.TabIndex = 22;
            this.toggleButton.Text = "On top?";
            this.toggleButton.UseVisualStyleBackColor = true;
            this.toggleButton.Click += new System.EventHandler(this.toggleOnTop);
            // 
            // positionBar
            // 
            this.positionBar.Location = new System.Drawing.Point(12, 546);
            this.positionBar.Name = "positionBar";
            this.positionBar.Size = new System.Drawing.Size(303, 45);
            this.positionBar.TabIndex = 24;
            this.positionBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 555);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 25;
            // 
            // titleUpdate
            // 
            this.titleUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateWork);
            // 
            // opacityUpDown
            // 
            this.opacityUpDown.Location = new System.Drawing.Point(231, 53);
            this.opacityUpDown.Name = "opacityUpDown";
            this.opacityUpDown.Size = new System.Drawing.Size(43, 20);
            this.opacityUpDown.TabIndex = 26;
            this.opacityUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.opacityUpDown.ValueChanged += new System.EventHandler(this.opacityChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Opacity:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 586);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.opacityUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.positionBar);
            this.Controls.Add(this.toggleButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.trackPositionBar);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuBar;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "pygmp3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.storeCurrent);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.trackPositionBar)).EndInit();
            this.rightclickMenu.ResumeLayout(false);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackPositionBar;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Button toggleButton;
        private System.Windows.Forms.ToolStripMenuItem loopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shuffleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip rightclickMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.TrackBar positionBar;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker titleUpdate;
        private System.Windows.Forms.ToolStripMenuItem popToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown opacityUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem sortByFolderToolStripMenuItem;
    }
}

