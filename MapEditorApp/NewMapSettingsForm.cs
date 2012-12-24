using System;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
  public partial class NewMapSettingsForm : Form
  {
    public NewMapSettingsForm()
    {
      InitializeComponent();
    }
    public Point GetMapParams()
    {
      Point tmp;
      try
      {
        tmp = new Point(Convert.ToInt32(WidthMTextBox.Text), Convert.ToInt32(HeightMTextBox.Text));
      }
      catch
      {
        tmp = new Point(-1, -1);
      }
      return tmp;
    }
    private void CreateNewMap_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }
  }
}
