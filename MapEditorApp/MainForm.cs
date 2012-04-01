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
    private Map _map;
    private Bitmap _image;//Для эмуляции класса TGame
    private Point _lineStart = new Point(-1, -1);

    #region Собственные методы

    private void DrawMap(int x = -1, int y = -1)//Вывод изображения карты в MapPictBox
    {
      _image = new Bitmap(_map.Width * Settings.ElemSize, _map.Height * Settings.ElemSize);//Для "ускорения" вывода
      Graphics canva = Graphics.FromImage(_image);//создали канву
      _map.ShowOnGraphics(canva);
      MapPictBox.Width = _map.Width * Settings.ElemSize;//Установили размеры
      MapPictBox.Height = _map.Height * Settings.ElemSize;
      if (ShowGridCheckBox.Checked)
        DrawGrid(canva);
      if (x != -1)//Если карта перирисовывается при попытке добавления элемента, чтобы не было моргания линии
      {
        canva.DrawLine(new Pen(new SolidBrush(Color.Yellow), (float)0.0000001), new Point(_lineStart.X * Settings.ElemSize + Settings.ElemSize / 2,
          _lineStart.Y * Settings.ElemSize + Settings.ElemSize / 2), new Point(x, y));
        Graphics tmp = MapPictBox.CreateGraphics();
        tmp.DrawImage(_image, new Point(0, 0));
      }
      else
        MapPictBox.Image = _image;
    }

    private void DrawGrid(Graphics canva)//Вывод вспомогательной сетки
    {
      for (int i = 1; i < Math.Max(MapPictBox.Width, MapPictBox.Height); i++)//нанесли сетку, потом процедуру вынесу
      {
        canva.DrawLine(new Pen(Brushes.Black, 1), new Point(i * Settings.ElemSize, 0), new Point(i * Settings.ElemSize, MapPictBox.Height));
        canva.DrawLine(new Pen(Brushes.Black, 1), new Point(0, i * Settings.ElemSize), new Point(MapPictBox.Width, i * Settings.ElemSize));
      }
    }

    private bool MapSaveCheck()
    //Проверка на создание/загрузку карты, если она ещё не сохранена, а мы пытаемся создать/загрузить новую
    {
      if (Convert.ToInt32(MapPictBox.Tag) != 0)
        if (MessageBox.Show("Map not saved.", "Map not saved! Save Map?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          MapSaveButton_Click(this, new EventArgs());
          if (Convert.ToInt32(MapPictBox.Tag) != 0)
            return false;//Если вдруг произошла ошибка при сохранении
        }
      return true;//Если ответят что не хотят сохранять, то текущее состояние будет утеряно
    }

    #endregion

    public MainForm()
    {
      InitializeComponent();
      _map = null;
      int countLines = (Map.Bitmaps.Length) / (MapElementsPicBox.Width / 20);//Число строк элементов карты
      _image = new Bitmap(120, ((Map.Bitmaps.Length) / (MapElementsPicBox.Width / 20) + 1) * 20);//Для рисования
      Graphics canva = Graphics.FromImage(_image);//создали канву
      for (int i = 0; i <= countLines; i++)
      {
        int k = (Map.Bitmaps.Length - i * countLines) >= (MapElementsPicBox.Width / 20) - 1 ?
          (MapElementsPicBox.Width / 20) - 1 : Map.Bitmaps.Length - i * countLines;
        for (int j = 0; j < k; j++)
          canva.DrawImage(Map.Bitmaps[i * countLines + j], j * 20, i * countLines, Settings.ElemSize, Settings.ElemSize);
      }
      MapElementsPicBox.Image = _image;
    }

    private void NewMapButton_Click(object sender, EventArgs e)
    {
      if (!MapSaveCheck())//Если карту не сохранили, новую не создадим
        return;
      //Если нажали применить параметры к новой карте
      NewMapSettingsForm settingsForm = new NewMapSettingsForm();
      if (settingsForm.ShowDialog() != DialogResult.OK) return;

      Point mapProp = settingsForm.GetMapParams();//Получаем размеры и имя карты
      if (mapProp.X == -1)
      {
        MessageBox.Show("Incorrect map parametrs");
        return;
      }
      MapWidthLabel.Text = "Ширина в элементах: " + mapProp.X;
      MapHeightLabel.Text = "Высота в элементах: " + mapProp.Y;

      MapPictBox.Width = mapProp.X * Settings.ElemSize;//Установили размеры
      MapPictBox.Height = mapProp.Y * Settings.ElemSize;

      _map = new Map(mapProp.X, mapProp.Y);
      DrawMap();

      MapPictBox.Tag = 1;
    }

    #region Save/Load
    private void MapLoadButton_Click(object sender, EventArgs e)
    {
      if (!MapSaveCheck())
        return;
      if (MapFileOpenDialog.ShowDialog() != DialogResult.OK) return;
      try
      {
        _map = new Map(MapFileOpenDialog.FileName);
      }
      catch
      {
        MessageBox.Show("Map loading error");
        return;
      }
      MapPictBox.Tag = 0;//Флаг того что карта была сохранена и можно будет создавать
      //загружать новую без предупреждений
      DrawMap();
      MapWidthLabel.Text = "Ширина в элементах: " + _map.Width;
      MapHeightLabel.Text = "Высота в элементах: " + _map.Height;
      MessageBox.Show("Map loaded Successful");
    }

    private void MapSaveButton_Click(object sender, EventArgs e)
    {
      if ((_map == null) || (MapFileSaveDialog.ShowDialog() != DialogResult.OK)) return;

      if (!_map.SaveToFile(MapFileSaveDialog.FileName))
        MessageBox.Show("Map saving error");
      else
      {
        MapPictBox.Tag = 0;//Флаг того что карта была сохранена и можно будет создавать
        //загружать новую без предупреждений
        MessageBox.Show("Map saved successful");
      }
    }

    #endregion

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

    private void MapPictBox_MouseUp(object sender, MouseEventArgs e)
    {
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
        MapPictBox.Tag = 1;//Нужно сохранить
      }
    }

    #region PictureRotate
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

    private void ShowGridCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (_map != null)
        DrawMap();
    }

    private void MapPictBox_MouseDown(object sender, MouseEventArgs e)
    {
      if ((Convert.ToInt32(MapElementsPicBox.Tag) == -1) || (Convert.ToInt32(StartSelectButton.Tag) == 1)
        || (Convert.ToInt32(FinishSelectButton.Tag) == 1))
        return;
      _lineStart = new Point(e.X / Settings.ElemSize, e.Y / Settings.ElemSize);
    }

    private void MapPictBox_MouseMove(object sender, MouseEventArgs e)
    {
      if (_map == null)
        return;
      if (Convert.ToInt32(MapElementsPicBox.Tag) == -1)
        return;
      if (_lineStart.X != -1)
        DrawMap(e.X, e.Y);
    }

    private void StartSelectButton_Click(object sender, EventArgs e)
    {
      if (_map == null)
        return;
      StartSelectButton.Tag = Convert.ToInt32(StartSelectButton.Tag) == 1 ? 0 : 1;
      FinishSelectButton.Tag = 0;
    }

    private void FinishSelectButton_Click(object sender, EventArgs e)
    {
      if (_map == null)
        return;
      FinishSelectButton.Tag = Convert.ToInt32(FinishSelectButton.Tag) == 1 ? 0 : 1;
      StartSelectButton.Tag = 0;
    }

    private void WayUpdateButton_Click(object sender, EventArgs e)
    {
      if (_map == null) return;
      _map.RebuildWay();
      DrawMap();
    }

  }
}
