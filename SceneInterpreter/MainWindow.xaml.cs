using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;

namespace SceneInterpreter
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      this.Background = new SolidColorBrush(Colors.Black);
      FileReader fileReader = new FileReader();
      fileReader.SetUp();
      try
      {
        fileReader.ReadFile("complex_scene.txt");
        this.Content = DrawOnScreen(fileReader.Drawables);
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.ToString());
      }
      
      this.WindowState = WindowState.Maximized;

    }

    public Canvas DrawOnScreen(List<Shape>drawables)
    {
      Canvas canvas = new Canvas();
      foreach (Shape shape in drawables)
      {
        canvas.Children.Add(shape.Draw());
      }
      return canvas;
    }   

   
  }
}
