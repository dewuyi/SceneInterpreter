using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SceneInterpreter
{
  internal class FileReader
  {
    Dictionary<string,Shape>ShapeDictionary = new Dictionary<string, Shape>();
    public List<Shape> Drawables = new List<Shape>();
    private bool definitionInProgress;
    private ComplexShape _complexShape;

    public void SetUp()
    {
      Circle circle = new Circle();
      circle.Name = "Circle";
      Rectangle rectangle = new Rectangle();
      rectangle.Name = "Rectangle";
      StoreShapeInShapeDictionary(circle);
      StoreShapeInShapeDictionary(rectangle);
    }


    public void ReadFile(string filename)
    {
      List<string> lines = new List<string>();
      
      string[] fileContent = File.ReadAllLines(@"C:\Users\Adewuyi Oyawoye\Scene\" + filename);

      foreach (string text in fileContent)
      {
        lines.Add(text.Trim());
      }      
        CreateShapes(lines);
    }


    private void CreateShapes(List<string> lines)
    {
      for (int index = 0; index < lines.Count; index++)
      {
        bool shapeIsCircle = lines[index].Contains("Circle");
        bool shapeIsRectangle = lines[index].Contains("Rectangle");
        bool keywordIsDefine = lines[index].Contains("define");
        bool keywordIsDraw = lines[index].Contains("draw");
        if (keywordIsDefine)
        {
          definitionInProgress = true;
        }

        if (!definitionInProgress)
        {
          if (shapeIsCircle)
          {
            string[] parameters = { lines[index + 1], lines[index + 2], lines[index + 3] };
            Drawables.Add(CreateCircle(parameters));
          }
          if (shapeIsRectangle)
          {
            string[] parameters = { lines[index + 1], lines[index + 2], lines[index + 3] };
            Drawables.Add(CreateRectangle(parameters));
          }

          if (keywordIsDraw && !shapeIsRectangle && !shapeIsCircle)
          {
            ComplexShape newShape = CreateComplexShape(lines[index], lines[index + 1]);
            ComplexShape clonedShape = CloneComplexShape(lines, index);
            newShape.ListOfShapes = clonedShape.ListOfShapes;
            Drawables.Add(newShape);
          }
        }
        if (definitionInProgress)
        {
          if (keywordIsDefine)
          {
            _complexShape = CreateComplexShape(lines[index], lines[index + 1]);
          }

          if (shapeIsCircle)
          {
            string[] parameters = { lines[index + 1], lines[index + 2], lines[index + 3] };
            _complexShape.ListOfShapes.Add(CreateCircle(parameters));
          }
          if (shapeIsRectangle)
          {
            string[] parameters = { lines[index + 1], lines[index + 2], lines[index + 3] };
            _complexShape.ListOfShapes.Add(CreateRectangle(parameters));
          }
          if (keywordIsDraw && !shapeIsRectangle && !shapeIsCircle)
          {
            ComplexShape newShape = CreateComplexShape(lines[index], lines[index + 1]);
            ComplexShape clonedShape = CloneComplexShape(lines, index);
            newShape.ListOfShapes = clonedShape.ListOfShapes;
            _complexShape.ListOfShapes.Add(newShape);
          }
          if (lines[index].Contains("done") && lines[index + 1].Contains("done"))
          {
            definitionInProgress = false;
            StoreShapeInShapeDictionary(_complexShape);
          }
         

        }
      }
    }

    private ComplexShape CloneComplexShape(List<string> lines, int index)
    {
      string[] name = lines[index].Split(' ');
      ComplexShape newShape = null;
      try
      {
        newShape = (ComplexShape)ShapeDictionary[name[1]];
        
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex + " "+ name[1] + " not found");
      }
      return newShape;
    }

    public ComplexShape CreateComplexShape(string name,string position)
    {
      ComplexShape complexShape = new ComplexShape();
      string[] names = name.Split(' ');
      complexShape.Name = names[1];
      if (position.Contains("position"))
      {
        string[] Position = position.Split(' ');
        complexShape.PositionX = Convert.ToInt32(Position[2]);
        complexShape.PositionY = Convert.ToInt32(Position[3]);
      }
      return complexShape;
    }


    public Circle CreateCircle(string[] parameters)
    {
      Circle circle = new Circle();
      circle.Name = "Circle";
      circle.GetParameters(parameters);
      return circle;
    }


    public Rectangle CreateRectangle(string[] parameters)
    {
      Rectangle rectangle = new Rectangle();
      rectangle.Name = "Rectangle";
      rectangle.GetParameters(parameters);
      return rectangle;
    }


    public void StoreShapeInShapeDictionary(Shape shape)
    {

      if (!ShapeDictionary.ContainsKey(shape.Name))
      {
        ShapeDictionary.Add(shape.Name,shape);
      }
    }
  

    
  }
}
