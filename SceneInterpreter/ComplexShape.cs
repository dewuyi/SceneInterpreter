using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SceneInterpreter
{
  class ComplexShape:Shape
  {

    public List<Shape> ListOfShapes = new List<Shape>();
    public override Canvas Draw()
    {
      Canvas canvas = new Canvas();
     
        foreach (Shape shape in ListOfShapes)
        {
          shape.PositionX += this.PositionX;
          shape.PositionY += this.PositionY;
          canvas.Children.Add(shape.Draw());
          shape.PositionX -= this.PositionX;
          shape.PositionY -= this.PositionY;
        }

      return canvas;
    }
  }
}
