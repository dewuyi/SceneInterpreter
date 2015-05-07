using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace SceneInterpreter
{
  public class Shape
  {
    public int PositionX, PositionY;
    public int Red, Green, Blue;
    protected int Width,Height;
    public string Name;
    
   
    public virtual Canvas Draw()
    {
      Canvas canvas = new Canvas();
      return canvas;
    }

    public virtual void GetParameters(string[] parameters)
    {
      foreach (string parameter in parameters)
      {
        if (parameter.Contains("position"))
        {
          string[] position = parameter.Split(' ');
          this.PositionX = Convert.ToInt32(position[2]);
          this.PositionY = Convert.ToInt32(position[3]);
        }

        if (parameter.Contains("size"))
        {
          string[] size = parameter.Split(' ');
          this.Width = Convert.ToInt32(size[2]);
          this.Height = Convert.ToInt32(size[3]);
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
