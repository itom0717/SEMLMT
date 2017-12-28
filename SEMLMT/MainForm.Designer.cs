namespace SEMLMT
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CollectionMODListDataGridView = new SEMLMT.Class.CollectionMODListDataGridView();
            this.GetCollectionMODListButton = new System.Windows.Forms.Button();
            this.CollectionIDTextBox = new System.Windows.Forms.TextBox();
            this.CollectionIDLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionMODListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CollectionMODListDataGridView);
            this.groupBox1.Controls.Add(this.GetCollectionMODListButton);
            this.groupBox1.Controls.Add(this.CollectionIDTextBox);
            this.groupBox1.Controls.Add(this.CollectionIDLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "コレクションからMOD一覧を取得";
            // 
            // CollectionMODListDataGridView
            // 
            this.CollectionMODListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectionMODListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CollectionMODListDataGridView.Location = new System.Drawing.Point(8, 47);
            this.CollectionMODListDataGridView.Name = "CollectionMODListDataGridView";
            this.CollectionMODListDataGridView.ReadOnly = true;
            this.CollectionMODListDataGridView.RowTemplate.Height = 21;
            this.CollectionMODListDataGridView.Size = new System.Drawing.Size(503, 147);
            this.CollectionMODListDataGridView.TabIndex = 3;
            // 
            // GetCollectionMODListButton
            // 
            this.GetCollectionMODListButton.Location = new System.Drawing.Point(254, 18);
            this.GetCollectionMODListButton.Name = "GetCollectionMODListButton";
            this.GetCollectionMODListButton.Size = new System.Drawing.Size(59, 26);
            this.GetCollectionMODListButton.TabIndex = 2;
            this.GetCollectionMODListButton.Text = "取得";
            this.GetCollectionMODListButton.UseVisualStyleBackColor = true;
            this.GetCollectionMODListButton.Click += new System.EventHandler(this.GetCollectionMODListButton_Click);
            // 
            // CollectionIDTextBox
            // 
            this.CollectionIDTextBox.Location = new System.Drawing.Point(92, 22);
            this.CollectionIDTextBox.Name = "CollectionIDTextBox";
            this.CollectionIDTextBox.Size = new System.Drawing.Size(156, 19);
            this.CollectionIDTextBox.TabIndex = 1;
            // 
            // CollectionIDLabel
            // 
            this.CollectionIDLabel.AutoSize = true;
            this.CollectionIDLabel.Location = new System.Drawing.Point(20, 25);
            this.CollectionIDLabel.Name = "CollectionIDLabel";
            this.CollectionIDLabel.Size = new System.Drawing.Size(66, 12);
            this.CollectionIDLabel.TabIndex = 0;
            this.CollectionIDLabel.Text = "コレクションID";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(466, 229);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(72, 27);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "閉じる";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 268);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Engineers Mod List Management Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionMODListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label CollectionIDLabel;
        private System.Windows.Forms.TextBox CollectionIDTextBox;
        private System.Windows.Forms.Button GetCollectionMODListButton;
        private Class.CollectionMODListDataGridView CollectionMODListDataGridView;
    }
}

