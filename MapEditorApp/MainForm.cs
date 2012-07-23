using System;
using System.Drawing;
using System.Windows.Forms;
using GameCoClassLibrary.Enums;
using GameCoClassLibrary.Structures;
using GameCoClassLibrary.Classes;

namespace WindowsFormsApplication1
{
  public partial class MainForm : Form
  {
    /// <summary>
    /// Map
    /// </summary>
    private Map _map;
    /// <summary>
    /// Game class emulator
    /// </summary>
    private Bitmap _image;
    /// <summary>
    /// Start position for map filling by selected map element
    /// </summary>
    private Point _lineStart = new Point(-1, -1);

    #region Methods, not events

    /// <summary>
    /// Draws the map obn MapPictBox
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    private void DrawMap(int x = -1, int y = -1)
    {
      _image = new Bitmap(_map.Width * Settings.ElemSize, _map.Height * Settings.ElemSize);
      Graphics canva = Graphics.FromImage(_image);
      _map.ShowOnGraphics(canva, true);
      MapPictBox.Width = _map.Width * Settings.ElemSize;
      MapPictBox.Height = _map.Height * Settings.ElemSize;
      if (ShowGridCheckBox.Checked)
        DrawGrid(canva);
      if (x != -1)//Fixing graphical lag, when drawing line
      {
        canva.DrawLine(new Pen(new SolidBrush(Color.Yellow), (float)0.0000001), new Point(_lineStart.X * Settings.ElemSize + Settings.ElemSize / 2,
          _lineStart.Y * Settings.ElemSize + Settings.ElemSize / 2), new Point(x, y));
        Graphics tmp = MapPictBox.CreateGraphics();
        tmp.DrawImage(_image, new Point(0, 0));
      }
      else
        MapPictBox.Image = _image;
    }

    /// <summary>
    /// Draws the grid.
    /// </summary>
    /// <param name="canva">The canva.</param>
    private void DrawGrid(Graphics canva)
    {
      for (int i = 1; i < Math.Max(MapPictBox.Width, MapPictBox.Height); i++)
      {
        canva.DrawLine(new Pen(Brushes.Black, 1), new Point(i * Settings.ElemSize, 0), new Point(i * Settings.ElemSize, MapPictBox.Height));
        canva.DrawLine(new Pen(Brushes.Black, 1), new Point(0, i * Settings.ElemSize), new Point(MapPictBox.Width, i * Settings.ElemSize));
      }
    }

    /// <summary>
    /// Maps the save check. If map don't saved and user trying to load/create new map
    /// </summary>
    /// <returns></returns>
    private bool MapSaveCheck()
    {
      if (Convert.ToInt32(MapPictBox.Tag) != 0)
        if (MessageBox.Show("Map not saved.", "Map not saved! Save Map?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          MapSaveButton_Click(this, new EventArgs());
          if (Convert.ToInt32(MapPictBox.Tag) != 0)
            return false;//Saving error
        }
      return true;
    }

    /// <summary>
    /// Called when map was created/loaded.
    /// </summary>
    private void OnMapCreating()
    {
      MapWidthLabel.Text = "Width in elements: " + _map.Width;
      MapHeightLabel.Text = "Height in elements: " + _map.Height;
    }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    public MainForm()
    {
      InitializeComponent();
      _map = null;
      int countLines = (Map.Bitmaps.Length) / (MapElementsPicBox.Width / 20);//Number of lines with map elements
      _image = new Bitmap(120, ((Map.Bitmaps.Length) / (MapElementsPicBox.Width / 20) + 1) * 20);
      Graphics canva = Graphics.FromImage(_image);
      for (int i = 0; i <= countLines; i++)
      {
        int k = (Map.Bitmaps.Length - i * countLines) >= (MapElementsPicBox.Width / 20) - 1 ?
          (MapElementsPicBox.Width / 20) - 1 : Map.Bitmaps.Length - i * countLines;
        for (int j = 0; j < k; j++)
          canva.DrawImage(Map.Bitmaps[i * countLines + j], j * 20, i * countLines, Settings.ElemSize, Settings.ElemSize);
      }
      MapElementsPicBox.Image = _image;
    }

    /// <summary>
    /// Create new map.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void NewMapButton_Click(object sender, EventArgs e)
    {
      if (!MapSaveCheck())//if Save error
        return;
      //From for creating new map
      NewMapSettingsForm settingsForm = new NewMapSettingsForm();
      if (settingsForm.ShowDialog() != DialogResult.OK) return;

      Point mapProp = settingsForm.GetMapParams();//Получаем размеры и имя карты
      if (mapProp.X == -1)
      {
        MessageBox.Show("Incorrect map parametrs");
        return;
      }
      _map = new Map(mapProp.X, mapProp.Y);
      OnMapCreating();
      MapPictBox.Width = mapProp.X * Settings.ElemSize;//Установили размеры
      MapPictBox.Height = mapProp.Y * Settings.ElemSize;
      DrawMap();

      MapPictBox.Tag = 1;
    }

    #region Save/Load
    /// <summary>
    /// Map loading
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void MapLoadButton_Click(object sender, EventArgs e)
    {
      if (!MapSaveCheck())
        return;
      if (MapFileOpenDialog.ShowDialog() != DialogResult.OK) return;
      try
      {
        _map = new Map(MapFileOpenDialog.FileName);
        OnMapCreating();
      }
      catch (Exception exc)
      {
        MessageBox.Show("Map loading error:\n" + exc.StackTrace);
        return;
      }
      MapPictBox.Tag = 0;//Flag. If 0 then we can create, load new map without question
      DrawMap();
      MessageBox.Show("Map loaded Successful");
    }

    /// <summary>
    /// Map saving
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void MapSaveButton_Click(object sender, EventArgs e)
    {
      if ((_map == null) || (MapFileSaveDialog.ShowDialog() != DialogResult.OK)) return;

      if (!_map.SaveToFile(MapFileSaveDialog.FileName))
        MessageBox.Show("Map saving error");
      else
      {
        MapPictBox.Tag = 0;//Flag. If 0 then we can create, load new map without question
        MessageBox.Show("Map saved successful");
      }
    }

    #endregion

    /// <summary>
    /// Selecting type of element, which user want to add to the map
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void MapElementsPicBox_MouseUp(object sender, MouseEventArgs e)
    {
      int num = (e.Y / 20) * ((Map.Bitmaps.Length) / (MapElementsPicBox.Width / 20)) + e.X / 20;
      if (num >= Map.Bitmaps.Length) return;

      Bitmap tmpBitmap = new Bitmap(Settings.ElemSize, Settings.ElemSize);
      Graphics canva = Graphics.FromImage(tmpBitmap);
      canva.DrawImage(Map.Bitmaps[num], 0, 0, Settings.ElemSize, Settings.ElemSize);
      CurrElemPictBox.Image = tmpBitmap;
      MapElementsPicBox.Tag = num;
      CurrElemPictBox.Tag = 0;
    }

    /// <summary>
    /// Add new elements to map
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void MapPictBox_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      if (_map != null)
      {
        #region Start/Finish select
        if (Convert.ToInt32(StartSelectButton.Tag) == 1)
        {
          if (!_map.SetStart(new Point(e.X / Settings.ElemSize, e.Y / Settings.ElemSize)))
          {
            MessageBox.Show("Can't set start there");
            return;
          }
          StartSelectButton.Tag = 0;
          DrawMap();
          MapPictBox.Tag = 1;
          return;
        }
        if (Convert.ToInt32(FinishSelectButton.Tag) == 1)
        {
          if (!_map.SetFinish(new Point(e.X / Settings.ElemSize, e.Y / Settings.ElemSize)))
          {
            MessageBox.Show("Can't set finish there");
            return;
          }
          FinishSelectButton.Tag = 0;
          DrawMap();
          MapPictBox.Tag = 1;
          return;
        }
        #endregion
        if (Convert.ToInt32(MapElementsPicBox.Tag) == -1)
          return;
        #region Map element standing

        MapElem Tmp;
        Tmp.PictNumber = Convert.ToInt32(MapElementsPicBox.Tag);
        Tmp.AngleOfRotate = Convert.ToInt32(CurrElemPictBox.Tag);
        Tmp.Status = MapElemStatus.CanMove;
        Point lineEnd = new Point(e.X / Settings.ElemSize, e.Y / Settings.ElemSize);
        if (_lineStart.X > lineEnd.X)
        {
          int tmp = lineEnd.X;
          lineEnd.X = _lineStart.X;
          _lineStart.X = tmp;
        }
        if (_lineStart.Y > lineEnd.Y)
        {
          int tmp = lineEnd.Y;
          lineEnd.Y = _lineStart.Y;
          _lineStart.Y = tmp;
        }
        for (int i = 0; i <= (lineEnd.X - _lineStart.X); i++)
          for (int j = 0; j <= (lineEnd.Y - _lineStart.Y); j++)
          {
            if (_map.AddElemToMap(new Point(_lineStart.X + i, _lineStart.Y + j), Tmp) == false)
              MessageBox.Show("Element standing error");
            //return;
          }
        #endregion
        DrawMap();
        _lineStart = new Point(-1, -1);
        MapPictBox.Tag = 1;//Save needed
      }
    }

    #region PictureRotate
    /// <summary>
    /// Map element rotating. Right
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TurnRightButton_Click(object sender, EventArgs e)
    {
      int tmp = Convert.ToInt32(CurrElemPictBox.Tag);
      if (tmp == -1) return;
      if (tmp == 3)
        tmp = 0;
      else
        tmp++;
      Bitmap tmpBit = new Bitmap(Settings.ElemSize, Settings.ElemSize);
      Graphics canva = Graphics.FromImage(tmpBit);
      canva.DrawImage(Map.Bitmaps[Convert.ToInt32(MapElementsPicBox.Tag)], 0, 0, Settings.ElemSize, Settings.ElemSize);
      for (int i = 0; i < tmp; i++)
        tmpBit.RotateFlip(RotateFlipType.Rotate90FlipNone);
      CurrElemPictBox.Image = tmpBit;
      CurrElemPictBox.Tag = tmp;
    }

    /// <summary>
    /// Map element rotating. Left
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TurnLeftButton_Click(object sender, EventArgs e)
    {
      int tmp = Convert.ToInt32(CurrElemPictBox.Tag);
      if (tmp == -1) return;
      if (tmp == 0)
        tmp = 3;
      else
        tmp--;
      Bitmap tmpBit = new Bitmap(Settings.ElemSize, Settings.ElemSize);//(Map.Bitmaps[Convert.ToInt32(MapElementsPicBox.Tag)]);
      Graphics canva = Graphics.FromImage(tmpBit);
      canva.DrawImage(Map.Bitmaps[Convert.ToInt32(MapElementsPicBox.Tag)], 0, 0, Settings.ElemSize, Settings.ElemSize);
      for (int i = 0; i < tmp; i++)
        tmpBit.RotateFlip(RotateFlipType.Rotate270FlipXY);
      CurrElemPictBox.Image = tmpBit;
      CurrElemPictBox.Tag = tmp;
    }
    #endregion

    /// <summary>
    /// Grid check box changed
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void ShowGridCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (_map != null)
        DrawMap();
    }

    /// <summary>
    /// Start drawing position selector
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void MapPictBox_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      if ((Convert.ToInt32(MapElementsPicBox.Tag) == -1) || (Convert.ToInt32(StartSelectButton.Tag) == 1)
        || (Convert.ToInt32(FinishSelectButton.Tag) == 1))
        return;
      _lineStart = new Point(e.X / Settings.ElemSize, e.Y / Settings.ElemSize);
    }

    /// <summary>
    /// Mouse moving on map area. Draws line, if map element to drawing was selected
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void MapPictBox_MouseMove(object sender, MouseEventArgs e)
    {
      if (_map == null)
        return;
      if (Convert.ToInt32(MapElementsPicBox.Tag) == -1)
        return;
      if (_lineStart.X != -1)
        DrawMap(e.X, e.Y);
    }

    /// <summary>
    /// Start select button clicked, now next user click on map will select starting way position
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void StartSelectButton_Click(object sender, EventArgs e)
    {
      if (_map == null)
        return;
      StartSelectButton.Tag = Convert.ToInt32(StartSelectButton.Tag) == 1 ? 0 : 1;
      FinishSelectButton.Tag = 0;
    }

    /// <summary>
    /// Finish select button clicked, now next user click on map will select finish way position
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void FinishSelectButton_Click(object sender, EventArgs e)
    {
      if (_map == null)
        return;
      FinishSelectButton.Tag = Convert.ToInt32(FinishSelectButton.Tag) == 1 ? 0 : 1;
      StartSelectButton.Tag = 0;
    }

    /// <summary>
    /// Map way updating(For testing)
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void WayUpdateButton_Click(object sender, EventArgs e)
    {
      if (_map == null) return;
      _map.RebuildWay();
      DrawMap();
    }

  }
}
