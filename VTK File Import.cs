using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitware.VTK;

namespace VTKTest
{
    public partial class Form1 : Form
    {
        public vtkProp3D imgProp = null;
        public void ImportVTK()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the name of the file you want to open from the dialog 
                string fileName = openFileDialog1.FileName;
                vtkRenderer ren = (vtkRenderer)this.myRenderWindowControl.RenderWindow.GetRenderers().GetItemAsObject(0);

                //Get rid of any props already there
                if (imgProp != null)
                {
                    ren.RemoveActor(imgProp);
                    imgProp.Dispose();
                    imgProp = null;
                }

                //Look at known file types to see if they are readable
                if (fileName.Contains(".png")
                    || fileName.Contains(".jpg")
                    || fileName.Contains(".jpeg")
                    || fileName.Contains(".tif")
                    || fileName.Contains(".slc")
                    || fileName.Contains(".dicom")
                    || fileName.Contains(".minc")
                    || fileName.Contains(".bmp")
                    || fileName.Contains(".pmn"))
                {
                  vtkImageReader2 rdr = vtkImageReader2Factory.CreateImageReader2(fileName);
                    rdr.SetFileName(fileName);
                    rdr.Update();
                    imgProp = vtkImageActor.New();
                   
                    ((vtkImageActor) imgProp).SetInput(rdr.GetOutput());
                    rdr.Dispose();
                }

                //.vtk files need a DataSetReader instead of a ImageReader2
                //some .vtk files need a different kind of reader, but this
                //will read most and serve our purposes
                else if (fileName.Contains(".vtk") || fileName.Contains(".VTK"))
                {
                    vtkDataSetReader dataReader = vtkDataSetReader.New();
                    dataReader.SetFileName(fileName);
                    dataReader.Update();

                    vtkDataSetMapper dataMapper = vtkDataSetMapper.New();
                    dataMapper.SetInput(dataReader.GetOutput());

                    imgProp = vtkActor.New();
                    ((vtkActor) imgProp).SetMapper(dataMapper);
                    
                    dataMapper.Dispose();
                    dataMapper = null;
                    
                    dataReader.Dispose();
                    dataReader = null;
                }
                else
                {
                    return;
                }

                ren.RemoveAllViewProps();
                ren.AddActor(imgProp);
                ren.ResetCamera();
                ren.SetBackground(0.0, 0.46, 0.5);

                //Rerender the screen
                //NOTE: sometimes you have to drag the mouse
                //a little before the image shows up
                ren.Render();
                myRenderWindowControl.RenderWindow.Render();
                myRenderWindowControl.Refresh();
                

            }
        }
    }

}

