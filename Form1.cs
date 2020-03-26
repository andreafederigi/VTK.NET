using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitware.VTK;


namespace VTKTest
{
    public partial class Form1 : Form
    {
        private RenderWindowControl myRenderWindowControl;
        public Form1()  {
            InitializeComponent();

            myRenderWindowControl = new RenderWindowControl();
            myRenderWindowControl.SetBounds(0, 0, panel1.Width, panel1.Height);
            myRenderWindowControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(this.myRenderWindowControl);
            myRenderWindowControl.Load += RenderWindowControl_Load;
        }

        private void RenderWindowControl_Load(object sender, System.EventArgs e)   {
            try
            {
                myRenderWindowControl.Refresh();


            }
            catch (Exception ex)  {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK);
            }
        }
        private void panel1_Resize(object sender, EventArgs e) {
            myRenderWindowControl.SetBounds(0, 0, panel1.Width, panel1.Height); 
        }
        private void panel1_Paint(object sender, EventArgs e)
        {
            myRenderWindowControl.Refresh();
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e) {
            }
        private void lineToolStripMenuItem_Click(object sender, EventArgs e) {
            Line();  }
        private void ColoredLinesToolStripMenuItem_Click(object sender, EventArgs e) {
            ColoredLines(); }
        private void PolyLineToolStripMenuItem_Click(object sender, EventArgs e){
            PolyLine();    }
        private void pointToolStripMenuItem_Click(object sender, EventArgs e) {
            Point(); }

        private void RegularPolygonToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            RegularPolygon();
        }


        private void hexahedronToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hexahedron();
        }

        private void torusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Torus);
        }

        private void boyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Boy);
        }

        private void conicSpiralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.ConicSpiral);
        }

        private void crossCapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.CrossCap);
        }

        private void diniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Dini);
        }

        private void ellipsoidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Ellipsoid);
        }

        private void enneperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Enneper);
        }

        private void figure8KleinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Figure8Klein);
        }

        private void kleinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Klein);
        }

        private void mobiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Mobius);
        }

        private void randomHillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.RandomHills);
        }

        private void romanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Roman);
        }

        private void splineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.Spline);
        }

        private void superEllipsoidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.SuperEllipsoid);
        }

        private void superToroidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawParametricObjects(VTKParametric.SuperToroid );
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportVTK();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();

            SaveFileDialog1.CreatePrompt = true;
            SaveFileDialog1.OverwritePrompt = true;

            // Set the file name to myText.txt, set the type filter
            // to text files, and set the initial directory to the 
            // MyDocuments folder.
            SaveFileDialog1.FileName = "myImage";
            // DefaultExt is only used when "All files" is selected from 
            // the filter box and no extension is specified by the user.
            SaveFileDialog1.DefaultExt = "png";
            SaveFileDialog1.Filter =
                "png files (*.png)|*.png|All files (*.*)|*.*";
            SaveFileDialog1.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Call ShowDialog and check for a return value of DialogResult.OK,
            // which indicates that the file was saved. 
            DialogResult result = SaveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Open the file, copy the contents of memoryStream to fileStream,
                // and close fileStream. Set the memoryStream.Position value to 0 
                // to copy the entire stream. 
                string fileName = SaveFileDialog1.FileName;
                WritePNG(fileName);

                         
            }
      
            
        }
    }
}
