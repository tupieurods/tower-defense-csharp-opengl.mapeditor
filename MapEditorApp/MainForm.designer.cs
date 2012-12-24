namespace WindowsFormsApplication1
{
  partial class MainForm
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.MapFileOpenDialog = new System.Windows.Forms.OpenFileDialog();
      this.MapPictBox = new System.Windows.Forms.PictureBox();
      this.MapElementsPicBox = new System.Windows.Forms.PictureBox();
      this.NewMapButton = new System.Windows.Forms.Button();
      this.MapLoadButton = new System.Windows.Forms.Button();
      this.MapSaveButton = new System.Windows.Forms.Button();
      this.MapWidthLabel = new System.Windows.Forms.Label();
      this.MapHeightLabel = new System.Windows.Forms.Label();
      this.MapPictBoxPanel = new System.Windows.Forms.Panel();
      this.StartSelectButton = new System.Windows.Forms.Button();
      this.FinishSelectButton = new System.Windows.Forms.Button();
      this.MapFileSaveDialog = new System.Windows.Forms.SaveFileDialog();
      this.CurrentElemLabel = new System.Windows.Forms.Label();
      this.CurrElemPictBox = new System.Windows.Forms.PictureBox();
      this.TurnRightButton = new System.Windows.Forms.Button();
      this.TurnLeftButton = new System.Windows.Forms.Button();
      this.ShowGridCheckBox = new System.Windows.Forms.CheckBox();
      this.WayUpdateButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.MapPictBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MapElementsPicBox)).BeginInit();
      this.MapPictBoxPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CurrElemPictBox)).BeginInit();
      this.SuspendLayout();
      // 
      // MapFileOpenDialog
      // 
      this.MapFileOpenDialog.FileName = "*.efm";
      this.MapFileOpenDialog.Filter = "MapFile(*.efm)|*.efm";
      // 
      // MapPictBox
      // 
      this.MapPictBox.Image = ((System.Drawing.Image)(resources.GetObject("MapPictBox.Image")));
      this.MapPictBox.Location = new System.Drawing.Point(1, 3);
      this.MapPictBox.Margin = new System.Windows.Forms.Padding(6);
      this.MapPictBox.Name = "MapPictBox";
      this.MapPictBox.Size = new System.Drawing.Size(500, 500);
      this.MapPictBox.TabIndex = 0;
      this.MapPictBox.TabStop = false;
      this.MapPictBox.Tag = "0";
      this.MapPictBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapPictBox_MouseDown);
      this.MapPictBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPictBox_MouseMove);
      this.MapPictBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapPictBox_MouseUp);
      // 
      // MapElementsPicBox
      // 
      this.MapElementsPicBox.Image = ((System.Drawing.Image)(resources.GetObject("MapElementsPicBox.Image")));
      this.MapElementsPicBox.Location = new System.Drawing.Point(549, 174);
      this.MapElementsPicBox.Margin = new System.Windows.Forms.Padding(6);
      this.MapElementsPicBox.Name = "MapElementsPicBox";
      this.MapElementsPicBox.Size = new System.Drawing.Size(180, 120);
      this.MapElementsPicBox.TabIndex = 1;
      this.MapElementsPicBox.TabStop = false;
      this.MapElementsPicBox.Tag = "-1";
      this.MapElementsPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapElementsPicBox_MouseUp);
      // 
      // NewMapButton
      // 
      this.NewMapButton.Location = new System.Drawing.Point(549, 22);
      this.NewMapButton.Margin = new System.Windows.Forms.Padding(6);
      this.NewMapButton.Name = "NewMapButton";
      this.NewMapButton.Size = new System.Drawing.Size(73, 42);
      this.NewMapButton.TabIndex = 2;
      this.NewMapButton.Text = "New";
      this.NewMapButton.UseVisualStyleBackColor = true;
      this.NewMapButton.Click += new System.EventHandler(this.NewMapButton_Click);
      // 
      // MapLoadButton
      // 
      this.MapLoadButton.Location = new System.Drawing.Point(634, 22);
      this.MapLoadButton.Margin = new System.Windows.Forms.Padding(6);
      this.MapLoadButton.Name = "MapLoadButton";
      this.MapLoadButton.Size = new System.Drawing.Size(69, 42);
      this.MapLoadButton.TabIndex = 3;
      this.MapLoadButton.Text = "Load";
      this.MapLoadButton.UseVisualStyleBackColor = true;
      this.MapLoadButton.Click += new System.EventHandler(this.MapLoadButton_Click);
      // 
      // MapSaveButton
      // 
      this.MapSaveButton.Location = new System.Drawing.Point(715, 22);
      this.MapSaveButton.Margin = new System.Windows.Forms.Padding(6);
      this.MapSaveButton.Name = "MapSaveButton";
      this.MapSaveButton.Size = new System.Drawing.Size(69, 42);
      this.MapSaveButton.TabIndex = 4;
      this.MapSaveButton.Text = "Save";
      this.MapSaveButton.UseVisualStyleBackColor = true;
      this.MapSaveButton.Click += new System.EventHandler(this.MapSaveButton_Click);
      // 
      // MapWidthLabel
      // 
      this.MapWidthLabel.AutoSize = true;
      this.MapWidthLabel.Location = new System.Drawing.Point(545, 120);
      this.MapWidthLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.MapWidthLabel.Name = "MapWidthLabel";
      this.MapWidthLabel.Size = new System.Drawing.Size(180, 24);
      this.MapWidthLabel.TabIndex = 5;
      this.MapWidthLabel.Text = "Width in elements: 0";
      // 
      // MapHeightLabel
      // 
      this.MapHeightLabel.AutoSize = true;
      this.MapHeightLabel.Location = new System.Drawing.Point(545, 144);
      this.MapHeightLabel.Name = "MapHeightLabel";
      this.MapHeightLabel.Size = new System.Drawing.Size(187, 24);
      this.MapHeightLabel.TabIndex = 6;
      this.MapHeightLabel.Text = "Height in elements: 0";
      // 
      // MapPictBoxPanel
      // 
      this.MapPictBoxPanel.AutoScroll = true;
      this.MapPictBoxPanel.Controls.Add(this.MapPictBox);
      this.MapPictBoxPanel.Location = new System.Drawing.Point(8, 12);
      this.MapPictBoxPanel.Name = "MapPictBoxPanel";
      this.MapPictBoxPanel.Size = new System.Drawing.Size(508, 513);
      this.MapPictBoxPanel.TabIndex = 7;
      // 
      // StartSelectButton
      // 
      this.StartSelectButton.Location = new System.Drawing.Point(549, 399);
      this.StartSelectButton.Name = "StartSelectButton";
      this.StartSelectButton.Size = new System.Drawing.Size(220, 32);
      this.StartSelectButton.TabIndex = 8;
      this.StartSelectButton.Tag = "0";
      this.StartSelectButton.Text = "Select start way pos";
      this.StartSelectButton.UseVisualStyleBackColor = true;
      this.StartSelectButton.Click += new System.EventHandler(this.StartSelectButton_Click);
      // 
      // FinishSelectButton
      // 
      this.FinishSelectButton.Location = new System.Drawing.Point(549, 437);
      this.FinishSelectButton.Name = "FinishSelectButton";
      this.FinishSelectButton.Size = new System.Drawing.Size(220, 34);
      this.FinishSelectButton.TabIndex = 9;
      this.FinishSelectButton.Tag = "0";
      this.FinishSelectButton.Text = "Select finish way pos";
      this.FinishSelectButton.UseVisualStyleBackColor = true;
      this.FinishSelectButton.Click += new System.EventHandler(this.FinishSelectButton_Click);
      // 
      // MapFileSaveDialog
      // 
      this.MapFileSaveDialog.FileName = "*.efm";
      this.MapFileSaveDialog.Filter = "MapFile(*.efm)|*.efm";
      // 
      // CurrentElemLabel
      // 
      this.CurrentElemLabel.AutoSize = true;
      this.CurrentElemLabel.Location = new System.Drawing.Point(545, 300);
      this.CurrentElemLabel.Name = "CurrentElemLabel";
      this.CurrentElemLabel.Size = new System.Drawing.Size(150, 24);
      this.CurrentElemLabel.TabIndex = 10;
      this.CurrentElemLabel.Text = "Current element:";
      // 
      // CurrElemPictBox
      // 
      this.CurrElemPictBox.Location = new System.Drawing.Point(723, 309);
      this.CurrElemPictBox.Name = "CurrElemPictBox";
      this.CurrElemPictBox.Size = new System.Drawing.Size(15, 15);
      this.CurrElemPictBox.TabIndex = 11;
      this.CurrElemPictBox.TabStop = false;
      this.CurrElemPictBox.Tag = "-1";
      // 
      // TurnRightButton
      // 
      this.TurnRightButton.Location = new System.Drawing.Point(657, 337);
      this.TurnRightButton.Name = "TurnRightButton";
      this.TurnRightButton.Size = new System.Drawing.Size(103, 56);
      this.TurnRightButton.TabIndex = 12;
      this.TurnRightButton.Text = "Turn elem right";
      this.TurnRightButton.UseVisualStyleBackColor = true;
      this.TurnRightButton.Click += new System.EventHandler(this.TurnRightButton_Click);
      // 
      // TurnLeftButton
      // 
      this.TurnLeftButton.Location = new System.Drawing.Point(549, 337);
      this.TurnLeftButton.Name = "TurnLeftButton";
      this.TurnLeftButton.Size = new System.Drawing.Size(97, 56);
      this.TurnLeftButton.TabIndex = 13;
      this.TurnLeftButton.Text = "Turn elem left";
      this.TurnLeftButton.UseVisualStyleBackColor = true;
      this.TurnLeftButton.Click += new System.EventHandler(this.TurnLeftButton_Click);
      // 
      // ShowGridCheckBox
      // 
      this.ShowGridCheckBox.AutoSize = true;
      this.ShowGridCheckBox.Checked = true;
      this.ShowGridCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ShowGridCheckBox.Location = new System.Drawing.Point(549, 73);
      this.ShowGridCheckBox.Name = "ShowGridCheckBox";
      this.ShowGridCheckBox.Size = new System.Drawing.Size(117, 28);
      this.ShowGridCheckBox.TabIndex = 14;
      this.ShowGridCheckBox.Text = "Show Grid";
      this.ShowGridCheckBox.UseVisualStyleBackColor = true;
      this.ShowGridCheckBox.CheckedChanged += new System.EventHandler(this.ShowGridCheckBox_CheckedChanged);
      // 
      // WayUpdateButton
      // 
      this.WayUpdateButton.Location = new System.Drawing.Point(549, 477);
      this.WayUpdateButton.Name = "WayUpdateButton";
      this.WayUpdateButton.Size = new System.Drawing.Size(220, 31);
      this.WayUpdateButton.TabIndex = 15;
      this.WayUpdateButton.Text = "Update way";
      this.WayUpdateButton.UseVisualStyleBackColor = true;
      this.WayUpdateButton.Click += new System.EventHandler(this.WayUpdateButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(805, 542);
      this.Controls.Add(this.WayUpdateButton);
      this.Controls.Add(this.ShowGridCheckBox);
      this.Controls.Add(this.TurnLeftButton);
      this.Controls.Add(this.TurnRightButton);
      this.Controls.Add(this.CurrElemPictBox);
      this.Controls.Add(this.CurrentElemLabel);
      this.Controls.Add(this.FinishSelectButton);
      this.Controls.Add(this.StartSelectButton);
      this.Controls.Add(this.MapPictBoxPanel);
      this.Controls.Add(this.MapHeightLabel);
      this.Controls.Add(this.MapWidthLabel);
      this.Controls.Add(this.MapSaveButton);
      this.Controls.Add(this.MapLoadButton);
      this.Controls.Add(this.NewMapButton);
      this.Controls.Add(this.MapElementsPicBox);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Margin = new System.Windows.Forms.Padding(6);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Tag = "0";
      this.Text = "Редактор карт";
      ((System.ComponentModel.ISupportInitialize)(this.MapPictBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MapElementsPicBox)).EndInit();
      this.MapPictBoxPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.CurrElemPictBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog MapFileOpenDialog;
    private System.Windows.Forms.PictureBox MapPictBox;
    private System.Windows.Forms.PictureBox MapElementsPicBox;
    private System.Windows.Forms.Button NewMapButton;
    private System.Windows.Forms.Button MapLoadButton;
    private System.Windows.Forms.Button MapSaveButton;
    private System.Windows.Forms.Label MapWidthLabel;
    private System.Windows.Forms.Label MapHeightLabel;
    private System.Windows.Forms.Panel MapPictBoxPanel;
    private System.Windows.Forms.Button StartSelectButton;
    private System.Windows.Forms.Button FinishSelectButton;
    private System.Windows.Forms.SaveFileDialog MapFileSaveDialog;
    private System.Windows.Forms.Label CurrentElemLabel;
    private System.Windows.Forms.PictureBox CurrElemPictBox;
    private System.Windows.Forms.Button TurnRightButton;
    private System.Windows.Forms.Button TurnLeftButton;
    private System.Windows.Forms.CheckBox ShowGridCheckBox;
    private System.Windows.Forms.Button WayUpdateButton;

  }
}

