namespace WindowsFormsApplication1
{
  partial class NewMapSettingsForm
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
      this.CreateNewMap = new System.Windows.Forms.Button();
      this.MapHeightLabel = new System.Windows.Forms.Label();
      this.MapWidthLabel = new System.Windows.Forms.Label();
      this.CancButton = new System.Windows.Forms.Button();
      this.HeightMTextBox = new System.Windows.Forms.MaskedTextBox();
      this.WidthMTextBox = new System.Windows.Forms.MaskedTextBox();
      this.SuspendLayout();
      // 
      // CreateNewMap
      // 
      this.CreateNewMap.Location = new System.Drawing.Point(260, 6);
      this.CreateNewMap.Margin = new System.Windows.Forms.Padding(6);
      this.CreateNewMap.Name = "CreateNewMap";
      this.CreateNewMap.Size = new System.Drawing.Size(150, 42);
      this.CreateNewMap.TabIndex = 0;
      this.CreateNewMap.Text = "CreateNewMap";
      this.CreateNewMap.UseVisualStyleBackColor = true;
      this.CreateNewMap.Click += new System.EventHandler(this.CreateNewMap_Click);
      // 
      // MapHeightLabel
      // 
      this.MapHeightLabel.AutoSize = true;
      this.MapHeightLabel.Location = new System.Drawing.Point(12, 9);
      this.MapHeightLabel.Name = "MapHeightLabel";
      this.MapHeightLabel.Size = new System.Drawing.Size(102, 24);
      this.MapHeightLabel.TabIndex = 2;
      this.MapHeightLabel.Text = "MapHeight";
      // 
      // MapWidthLabel
      // 
      this.MapWidthLabel.AutoSize = true;
      this.MapWidthLabel.Location = new System.Drawing.Point(12, 46);
      this.MapWidthLabel.Name = "MapWidthLabel";
      this.MapWidthLabel.Size = new System.Drawing.Size(95, 24);
      this.MapWidthLabel.TabIndex = 3;
      this.MapWidthLabel.Text = "MapWidth";
      // 
      // CancButton
      // 
      this.CancButton.Location = new System.Drawing.Point(294, 57);
      this.CancButton.Name = "CancButton";
      this.CancButton.Size = new System.Drawing.Size(88, 34);
      this.CancButton.TabIndex = 7;
      this.CancButton.Text = "Cancel";
      this.CancButton.UseVisualStyleBackColor = true;
      this.CancButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // HeightMTextBox
      // 
      this.HeightMTextBox.Location = new System.Drawing.Point(120, 6);
      this.HeightMTextBox.Mask = "000";
      this.HeightMTextBox.Name = "HeightMTextBox";
      this.HeightMTextBox.Size = new System.Drawing.Size(100, 29);
      this.HeightMTextBox.TabIndex = 8;
      this.HeightMTextBox.Text = "28";
      // 
      // WidthMTextBox
      // 
      this.WidthMTextBox.Location = new System.Drawing.Point(120, 46);
      this.WidthMTextBox.Mask = "000";
      this.WidthMTextBox.Name = "WidthMTextBox";
      this.WidthMTextBox.Size = new System.Drawing.Size(100, 29);
      this.WidthMTextBox.TabIndex = 9;
      this.WidthMTextBox.Text = "27";
      // 
      // NewMapSettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(453, 102);
      this.Controls.Add(this.WidthMTextBox);
      this.Controls.Add(this.HeightMTextBox);
      this.Controls.Add(this.CancButton);
      this.Controls.Add(this.MapWidthLabel);
      this.Controls.Add(this.MapHeightLabel);
      this.Controls.Add(this.CreateNewMap);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ForeColor = System.Drawing.Color.Black;
      this.Margin = new System.Windows.Forms.Padding(6);
      this.Name = "NewMapSettingsForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "NewMapParametrs";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button CreateNewMap;
    private System.Windows.Forms.Label MapHeightLabel;
    private System.Windows.Forms.Label MapWidthLabel;
    private System.Windows.Forms.Button CancButton;
    private System.Windows.Forms.MaskedTextBox HeightMTextBox;
    private System.Windows.Forms.MaskedTextBox WidthMTextBox;
  }
}