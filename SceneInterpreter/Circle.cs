using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SceneInterpreter
{
  class Circle:Shape
  {
    private int _radius;
  

    public override Canvas Draw()
    {
      Canvas canvas = new Canvas();
      Ellipse ellipse = new Ellipse();
      ellipse.Width = this._radius*2;
      ellipse.Height = this._radius*2;
      double left = this.PositionX - this._radius;
      double top = this.PositionY - this._radius;
      Color ShapeColor = new Color();
      ShapeColor = Color.FromRgb(Convert.ToByte(this.Red), Convert.ToByte(this.Green), Convert.ToByte(this.Blue));
      ellipse.Fill = new SolidColorBrush(ShapeColor);
      Canvas.SetLeft(ellipse, left);
      Canvas.SetTop(ellipse, top);
      canvas.Children.Add(ellipse);
      return canvas;
    }


    public override void GetParameters(string[] parameters)
    {
      foreach (string parameter in parameters)
      {
        if (parameter.Contains("position"))
        {
          string[] position = parameter.Split(' ');
          this.PositionX = Convert.ToInt32(position[2]);
          this.PositionY = Convert.ToInt32(position[3]);
        }

        if (parameter.Contains("radius"))
        {
          string[] radius = parameter.Split(' ');
          this._radius = Convert.ToInt32(radius[2]);
        }

        if (parameter.Contains("color"))
        {
          string[] color = parameter.Split(' ');
          this.Red = Convert.ToInt32(color[2]);
          this.Green = Convert.ToInt32(color[3]);
          this.Blue = Convert.ToInt32(color[4]);
        }
      }

    }

  }
}
