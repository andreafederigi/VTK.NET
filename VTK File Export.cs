using System.Windows.Forms;
using Kitware.VTK;

namespace VTKTest
{
    public partial class Form1 : Form
    {
        private void WritePNG(string filePath)
        {
            vtkRenderWindow renW = myRenderWindowControl.RenderWindow;
            vtkRenderer ren = renW.GetRenderers().GetFirstRenderer();
            double [] backCol;
            backCol = ren.GetBackground();

            ren.SetBackground(255.0, 255.0, 255.0);

            vtkRenderLargeImage largeScreenExpoHelper = vtkRenderLargeImage.New();
            largeScreenExpoHelper.SetInput(ren);
            largeScreenExpoHelper.SetMagnification(10);

            vtkPNGWriter writer = vtkPNGWriter.New();
            writer.SetFileName(filePath);
            writer.SetInputConnection(largeScreenExpoHelper.GetOutputPort());
            writer.Write();

            ren.SetBackground(backCol[0], backCol[1], backCol[2]);



        }
    }
}
