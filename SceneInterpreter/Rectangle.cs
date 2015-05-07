using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace SceneInterpreter
{
  internal class Rectangle : Shape
  {
   
    

    public override Canvas Draw()
    {
      Canvas canvas = new Canvas();
      System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle();
      rectangle.Width = this.Width;
      rectangle.Height = this.Height;
      Color ShapeColor = new Color();
      ShapeColor = Color.FromRgb(Convert.ToByte(this.Red), Convert.ToByte(this.Green), Convert.ToByte(this.Blue));
      rectangle.Fill = new SolidColorBrush(ShapeColor);
      Canvas.SetLeft(rectangle, this.PositionX);
      Canvas.SetTop(rectangle, this.PositionY);
      canvas.Children.Add(rectangle);
      return canvas;
    } 

  }
}

  