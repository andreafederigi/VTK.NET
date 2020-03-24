using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

using Kitware.VTK;
using System.Runtime.InteropServices;

namespace VTKTest {

    partial class Form1 : Form
    {
        private enum VTKParametric
        {
            Torus,
            Boy,
            ConicSpiral,
            CrossCap,
            Dini,
            Ellipsoid,
            Enneper,
            Figure8Klein,
            Klein,
            Mobius,
            RandomHills,
            Roman,
            Spline,
            SuperEllipsoid,
            SuperToroid,
        }

        private void RenderAddActor(vtkActor Actor)
        {
            vtkRenderWindow renderWindow = myRenderWindowControl.RenderWindow;
            vtkRenderer renderer = renderWindow.GetRenderers().GetFirstRenderer();

            renderer.RemoveAllViewProps();
            renderer.ResetCamera();

            renderer.SetBackground(0.2, 0.3, 0.4);
            renderer.AddActor(Actor);
            renderer.ResetCamera();
            myRenderWindowControl.Refresh();
        }

        private void Line()
        {
            // Create a line.  
            vtkLineSource lineSource = vtkLineSource.New();
            // Create two points, P0 and P1
            double[] p0 = new double[] { 1.0, 0.0, 0.0 };
            double[] p1 = new double[] { 0.0, 1.0, 0.0 };

            lineSource.SetPoint1(p0[0], p0[1], p0[2]);
            lineSource.SetPoint2(p1[0], p1[1], p1[2]);

            // Visualize
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(lineSource.GetOutputPort());
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);
            actor.GetProperty().SetLineWidth(4);

            RenderAddActor(actor);
        }
        private void ColoredLines()
        {
            // Create three points. Join (Origin and P0) with a red line and
            // (Origin and P1) with a green line
            double[] origin = new double[] { 0.0, 0.0, 0.0 };
            double[] p0 = new double[] { 1.0, 0.0, 0.0 };
            double[] p1 = new double[] { 0.0, 1.0, 0.0 };

            // Create a vtkPoints object and store the points in it
            vtkPoints pts = vtkPoints.New();
            pts.InsertNextPoint(origin[0], origin[1], origin[2]);
            pts.InsertNextPoint(p0[0], p0[1], p0[2]);
            pts.InsertNextPoint(p1[0], p1[1], p1[2]);

            // Setup two colors - one for each line
            byte[] red = new byte[] { 255, 0, 0 };
            byte[] green = new byte[] { 0, 255, 0 };

            // Setup the colors array
            vtkUnsignedCharArray colors = vtkUnsignedCharArray.New();
            colors.SetNumberOfComponents(3);
            colors.SetName("Colors");

            // Add the colors we created to the colors array
            colors.InsertNextValue(red[0]);
            colors.InsertNextValue(red[1]);
            colors.InsertNextValue(red[2]);

            colors.InsertNextValue(green[0]);
            colors.InsertNextValue(green[1]);
            colors.InsertNextValue(green[2]);

            // Create the first line (between Origin and P0)
            vtkLine line0 = vtkLine.New();
            line0.GetPointIds().SetId(0, 0); //the second 0 is the index of the Origin in the vtkPoints
            line0.GetPointIds().SetId(1, 1); //the second 1 is the index of P0 in the vtkPoints

            // Create the second line (between Origin and P1)
            vtkLine line1 = vtkLine.New();
            line1.GetPointIds().SetId(0, 0); //the second 0 is the index of the Origin in the vtkPoints
            line1.GetPointIds().SetId(1, 2); //2 is the index of P1 in the vtkPoints

            // Create a cell array to store the lines in and add the lines to it
            vtkCellArray lines = vtkCellArray.New();
            lines.InsertNextCell(line0);
            lines.InsertNextCell(line1);

            // Create a polydata to store everything in
            vtkPolyData linesPolyData = vtkPolyData.New();

            // Add the points to the dataset
            linesPolyData.SetPoints(pts);

            // Add the lines to the dataset
            linesPolyData.SetLines(lines);

            // Color the lines - associate the first component (red) of the
            // colors array with the first component of the cell array (line 0)
            // and the second component (green) of the colors array with the
            // second component of the cell array (line 1)
            linesPolyData.GetCellData().SetScalars(colors);

            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(linesPolyData);
            // create an actor
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            RenderAddActor(actor);

        }
        private void PolyLine()
        {
            // Create five points
            double[,] p = new double[,] {
            { 0.0, 0.0, 0.0 },
            { 1.0, 0.0, 0.0 },
            { 0.0, 1.0, 0.0 },
            { 0.0, 1.0, 2.0 },
            { 0.0, 3.0, 3.0 }
         };

            // Create the points
            vtkPoints points = vtkPoints.New();
            for (int i = 0; i < 5; i++)
                points.InsertNextPoint(p[i, 0], p[i, 1], p[i, 2]);


            vtkPolyLine polyLine = vtkPolyLine.New();
            polyLine.GetPointIds().SetNumberOfIds(5);
            for (int i = 0; i < 5; i++)
                polyLine.GetPointIds().SetId(i, i);

            // Create a cell array to store the lines in and add the lines to it
            vtkCellArray cells = vtkCellArray.New();
            cells.InsertNextCell(polyLine);

            // Create a polydata to store everything in
            vtkPolyData polyData = vtkPolyData.New();

            // Add the points to the dataset
            polyData.SetPoints(points);

            // Add the lines to the dataset
            polyData.SetLines(cells);
            //Create an actor and mapper
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(polyData);
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            RenderAddActor(actor);

        }
        private void Point()
        {
            // Create the geometry of the points (the coordinate)
            vtkPoints points = vtkPoints.New();
            double[,] p = new double[,] {
            {1.0, 2.0, 3.0},
            {3.0, 1.0, 2.0},
            {2.0, 3.0, 1.0}
         };

            // Create topology of the points (a vertex per point)
            vtkCellArray vertices = vtkCellArray.New();
            int nPts = 3;

            int[] ids = new int[nPts];
            for (int i = 0; i < nPts; i++)
                ids[i] = points.InsertNextPoint(p[i, 0], p[i, 1], p[i, 2]);

            int size = Marshal.SizeOf(typeof(int)) * nPts;
            IntPtr pIds = Marshal.AllocHGlobal(size);
            Marshal.Copy(ids, 0, pIds, nPts);
            vertices.InsertNextCell(nPts, pIds);
            Marshal.FreeHGlobal(pIds);

            // Create a polydata object
            vtkPolyData pointPoly = vtkPolyData.New();

            // Set the points and vertices we created as the geometry and topology of the polydata
            pointPoly.SetPoints(points);
            pointPoly.SetVerts(vertices);

            // Visualize
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(pointPoly);

            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);
            actor.GetProperty().SetPointSize(20);

            RenderAddActor(actor);

        }
        private void RegularPolygon()
        {
            // Create a pentagon
            vtkRegularPolygonSource polygonSource = vtkRegularPolygonSource.New();

            //polygonSource.GeneratePolygonOff();
            polygonSource.SetNumberOfSides(5);
            polygonSource.SetRadius(5);
            polygonSource.SetCenter(0, 0, 0);
            //polygonSource.Update(); // not necessary

            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(polygonSource.GetOutputPort());
            vtkActor actor = vtkActor.New();
            actor.GetProperty().SetLineWidth(4);
            actor.SetMapper(mapper);
            RenderAddActor(actor);
        }
        private void Hexahedron()
        {
            // Setup the coordinates of eight points 
            // (faces must be in counter clockwise order as viewed from the outside)
            double[,] p = new double[,] {
            { 0.0, 0.0, 0.0 },
            { 1.0, 0.0, 0.0 },
            { 1.0, 1.0, 0.0 },
            { 0.0, 1.0, 0.0 },
            { 0.0, 0.0, 1.0 },
            { 1.0, 0.0, 1.0 },
            { 1.0, 1.0, 1.0 },
            { 0.0, 1.0, 1.0 }
         };

            // Create the points
            vtkPoints points = vtkPoints.New();
            for (int i = 0; i < 8; i++)
                points.InsertNextPoint(p[i, 0], p[i, 1], p[i, 2]);

            // Create a hexahedron from the points
            vtkHexahedron hex = vtkHexahedron.New();
            for (int i = 0; i < 8; i++)
                hex.GetPointIds().SetId(i, i);

            // Add the hexahedron to a cell array
            vtkCellArray hexs = vtkCellArray.New();
            hexs.InsertNextCell(hex);

            // Add the points and hexahedron to an unstructured grid
            vtkUnstructuredGrid uGrid = vtkUnstructuredGrid.New();
            uGrid.SetPoints(points);
            uGrid.InsertNextCell(hex.GetCellType(), hex.GetPointIds());

            // Visualize
            vtkDataSetMapper mapper = vtkDataSetMapper.New();
            mapper.SetInput(uGrid);
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);
            actor.GetProperty().SetLineWidth(4);

            RenderAddActor(actor);
        }
        private void DrawParametricObjects(VTKParametric type)
        {
            // Select one of the following (matching the selection above)
            vtkParametricFunctionSource parametricFunctionSource = vtkParametricFunctionSource.New();

            switch (type)             {
                case VTKParametric.Torus:
                    vtkParametricTorus Torus = vtkParametricTorus.New();
                    parametricFunctionSource.SetParametricFunction(Torus);
                    break;
                case VTKParametric.Boy:
                    vtkParametricBoy Boy = vtkParametricBoy.New();
                    parametricFunctionSource.SetParametricFunction(Boy);
                    break;
                case VTKParametric.ConicSpiral:
                    vtkParametricConicSpiral ConicSpiral = vtkParametricConicSpiral.New();
                    parametricFunctionSource.SetParametricFunction(ConicSpiral);
                    break;
                case VTKParametric.CrossCap:
                    vtkParametricCrossCap CrossCap = vtkParametricCrossCap.New();
                    parametricFunctionSource.SetParametricFunction(CrossCap);
                    break;
                case VTKParametric.Dini:
                    vtkParametricDini Dini = vtkParametricDini.New();
                    parametricFunctionSource.SetParametricFunction(Dini);
                    break;
                case VTKParametric.Ellipsoid:
                    vtkParametricEllipsoid Ellipsoid = vtkParametricEllipsoid.New();
                    Ellipsoid.SetXRadius(0.5);
                    Ellipsoid.SetYRadius(2.0);
                    
                    parametricFunctionSource.SetParametricFunction(Ellipsoid);
                    break;
                case VTKParametric.Enneper:
                    vtkParametricEnneper Enneper = vtkParametricEnneper.New();
                    parametricFunctionSource.SetParametricFunction(Enneper);
                    break;
                case VTKParametric.Figure8Klein:
                    vtkParametricFigure8Klein Figure8Klein = vtkParametricFigure8Klein.New();
                    parametricFunctionSource.SetParametricFunction(Figure8Klein);
                    break;
                case VTKParametric.Klein:
                    vtkParametricKlein Klein = vtkParametricKlein.New();
                    parametricFunctionSource.SetParametricFunction(Klein);
                    break;
                case VTKParametric.Mobius:
                    vtkParametricMobius Mobius = vtkParametricMobius.New();
                    parametricFunctionSource.SetParametricFunction(Mobius);
                    break;
                case VTKParametric.RandomHills:
                    vtkParametricRandomHills RandomHills = vtkParametricRandomHills.New();
                    parametricFunctionSource.SetParametricFunction(RandomHills);
                    break;
                case VTKParametric.Roman:
                    vtkParametricRoman Roman = vtkParametricRoman.New();
                    parametricFunctionSource.SetParametricFunction(Roman);
                    break;
                case VTKParametric.Spline:
                    vtkParametricSpline spline = vtkParametricSpline.New();
                    vtkPoints inputPoints = vtkPoints.New();
                    vtkMath.RandomSeed(8775070);
                    for (int p = 0; p < 10; p++)
                    {
                        double x = vtkMath.Random(0.0, 1.0);
                        double y = vtkMath.Random(0.0, 1.0);
                        double z = vtkMath.Random(0.0, 1.0);
                        inputPoints.InsertNextPoint(x, y, z);
                    }
                    spline.SetPoints(inputPoints);

                    parametricFunctionSource.SetParametricFunction(spline);
                    break;
                case VTKParametric.SuperEllipsoid:
                    vtkParametricSuperEllipsoid superEllipsoid = vtkParametricSuperEllipsoid.New();
                    superEllipsoid.SetN1(.50);
                    superEllipsoid.SetN2(.1);
                    parametricFunctionSource.SetParametricFunction(superEllipsoid);
                    break;
                case VTKParametric.SuperToroid:
                    vtkParametricSuperToroid SuperToroid = vtkParametricSuperToroid.New();
                    SuperToroid.SetN1(0.5);
                    SuperToroid.SetN2(0.1);

                    parametricFunctionSource.SetParametricFunction(SuperToroid);
                    break;
            }

            parametricFunctionSource.Update();

            // Setup mapper and actor
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(parametricFunctionSource.GetOutputPort());
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            // Visualize
            RenderAddActor(actor);

        }
        private void Plane()
        {
            // Create a plane
            vtkPlaneSource planeSource = vtkPlaneSource.New();
            planeSource.SetCenter(1.0, 0.0, 0.0);
            planeSource.SetNormal(1.0, 0.0, 1.0);
            planeSource.Update();

            // Visualize
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(planeSource.GetOutputPort());
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);
            actor.GetProperty().SetLineWidth(4);

            RenderAddActor(actor);

        }
        private void PlatonicSolid()
        {
            vtkPlatonicSolidSource platonicSolidSource = vtkPlatonicSolidSource.New();
            platonicSolidSource.SetSolidTypeToOctahedron();

            // Each face has a different cell scalar
            vtkLookupTable lut = vtkLookupTable.New();
            lut.SetNumberOfTableValues(8);
            lut.SetTableRange(0.0, 7.0);
            lut.Build();
            lut.SetTableValue(0, 0, 0, 0, 1);
            lut.SetTableValue(1, 0, 0, 1, 1);
            lut.SetTableValue(2, 0, 1, 0, 1);
            lut.SetTableValue(3, 0, 1, 1, 1);
            lut.SetTableValue(4, 1, 0, 0, 1);
            lut.SetTableValue(5, 1, 0, 1, 1);
            lut.SetTableValue(6, 1, 1, 0, 1);
            lut.SetTableValue(7, 1, 1, 1, 1);

            // Visualize
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(platonicSolidSource.GetOutputPort());
            mapper.SetLookupTable(lut);
            mapper.SetScalarRange(0, 7);

            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);


            RenderAddActor(actor);

        }
        private void Polygon()
        {
            // Setup four points
            vtkPoints points = vtkPoints.New();
            double c = Math.Cos(Math.PI / 6); // helper variable

            points.InsertNextPoint(0.0, -1.0, 0.0);
            points.InsertNextPoint(c, -0.5, 0.0);
            points.InsertNextPoint(c, 0.5, 0.0);
            points.InsertNextPoint(0.0, 1.0, 0.0);
            points.InsertNextPoint(-c, 0.5, 0.0);
            points.InsertNextPoint(-c, -0.5, 0.0);

            // Create the polygon
            vtkPolygon polygon = vtkPolygon.New();
            polygon.GetPointIds().SetNumberOfIds(6); //make a six-sided figure
            polygon.GetPointIds().SetId(0, 0);
            polygon.GetPointIds().SetId(1, 1);
            polygon.GetPointIds().SetId(2, 2);
            polygon.GetPointIds().SetId(3, 3);
            polygon.GetPointIds().SetId(4, 4);
            polygon.GetPointIds().SetId(5, 5);

            // Add the polygon to a list of polygons
            vtkCellArray polygons = vtkCellArray.New();
            polygons.InsertNextCell(polygon);

            // Create a PolyData
            vtkPolyData polygonPolyData = vtkPolyData.New();
            polygonPolyData.SetPoints(points);
            polygonPolyData.SetPolys(polygons);

            // Create a mapper and actor
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(polygonPolyData);
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            RenderAddActor(actor);

        }
        private void Quad()
        {
            double[,] p = new double[,] {
            { 0.0, 0.0, 0.0 },
            { 1.0, 0.0, 0.0 },
            { 1.0, 1.0, 0.0 },
            { 0.0, 1.0, 0.0 }
         };

            // Create the points
            vtkPoints points = vtkPoints.New();
            for (int i = 0; i < 4; i++)
                points.InsertNextPoint(p[i, 0], p[i, 1], p[i, 2]);


            vtkQuad quad = vtkQuad.New();
            quad.GetPointIds().SetNumberOfIds(4);
            for (int i = 0; i < 4; i++)
                quad.GetPointIds().SetId(i, i);

            // Create a cell array to store the quad in and add the quad to it
            vtkCellArray cells = vtkCellArray.New();
            cells.InsertNextCell(quad);

            // Create a polydata to store everything in
            vtkPolyData polyData = vtkPolyData.New();

            // Add the points to the dataset
            polyData.SetPoints(points);

            // Add the quad to the dataset
            polyData.SetPolys(cells);

            //Create an actor and mapper
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(polyData);
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            RenderAddActor(actor);

        }

        private void Tetrahedron()
        {
            vtkPoints points = vtkPoints.New();
            points.InsertNextPoint(0, 0, 0);
            points.InsertNextPoint(1, 0, 0);
            points.InsertNextPoint(1, 1, 0);
            points.InsertNextPoint(0, 1, 1);
            points.InsertNextPoint(5, 5, 5);
            points.InsertNextPoint(6, 5, 5);
            points.InsertNextPoint(6, 6, 5);
            points.InsertNextPoint(5, 6, 6);

            // Method 1
            vtkUnstructuredGrid unstructuredGrid1 = vtkUnstructuredGrid.New();
            unstructuredGrid1.SetPoints(points);

            int[] ptIds = new int[] { 0, 1, 2, 3 };
            IntPtr ptIdsPointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * 4);
            Marshal.Copy(ptIds, 0, ptIdsPointer, 4);
            unstructuredGrid1.InsertNextCell(10, 4, ptIdsPointer);
            Marshal.FreeHGlobal(ptIdsPointer);

            // Method 2
            vtkUnstructuredGrid unstructuredGrid2 = vtkUnstructuredGrid.New();
            unstructuredGrid2.SetPoints(points);

            vtkTetra tetra = vtkTetra.New();

            tetra.GetPointIds().SetId(0, 4);
            tetra.GetPointIds().SetId(1, 5);
            tetra.GetPointIds().SetId(2, 6);
            tetra.GetPointIds().SetId(3, 7);

            vtkCellArray cellArray = vtkCellArray.New();
            cellArray.InsertNextCell(tetra);
            unstructuredGrid2.SetCells(10, cellArray);

            // Create a mapper and actor
            vtkDataSetMapper mapper1 = vtkDataSetMapper.New();
            mapper1.SetInputConnection(unstructuredGrid1.GetProducerPort());

            vtkActor actor1 = vtkActor.New();
            actor1.SetMapper(mapper1);

            // Create a mapper and actor
            vtkDataSetMapper mapper2 = vtkDataSetMapper.New();
            mapper2.SetInputConnection(unstructuredGrid2.GetProducerPort());

            vtkActor actor2 = vtkActor.New();
            actor2.SetMapper(mapper2);

            vtkRenderWindow renderWindow = myRenderWindowControl.RenderWindow;
            vtkRenderer renderer = renderWindow.GetRenderers().GetFirstRenderer();
            renderer.SetBackground(0.2, 0.3, 0.4);
            // Add the actor to the scene
            renderer.AddActor(actor1);
            renderer.AddActor(actor2);
            renderer.SetBackground(.3, .6, .3); // Background color green
        }
        private void Triangle()
        {
            // Create a triangle
            vtkPoints points = vtkPoints.New();
            points.InsertNextPoint(1.0, 0.0, 0.0);
            points.InsertNextPoint(0.0, 0.0, 0.0);
            points.InsertNextPoint(0.0, 1.0, 0.0);

            vtkTriangle triangle = vtkTriangle.New();
            triangle.GetPointIds().SetId(0, 0);
            triangle.GetPointIds().SetId(1, 1);
            triangle.GetPointIds().SetId(2, 2);

            // Create a cell array to store the triangle in and add the triangle to it
            vtkCellArray cells = vtkCellArray.New();
            cells.InsertNextCell(triangle);

            // Create a polydata to store everything in
            vtkPolyData polyData = vtkPolyData.New();

            // Add the points to the dataset
            polyData.SetPoints(points);

            // Add the quad to the dataset
            polyData.SetPolys(cells);

            //Create an actor and mapper
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(polyData);
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);
            RenderAddActor(actor);

        }
        private void TriangleStrip()
        {
            vtkPoints points = vtkPoints.New();
            points.InsertNextPoint(0, 0, 0);
            points.InsertNextPoint(0, 1, 0);
            points.InsertNextPoint(1, 0, 0);
            points.InsertNextPoint(1.5, 1, 0);

            vtkTriangleStrip triangleStrip = vtkTriangleStrip.New();
            triangleStrip.GetPointIds().SetNumberOfIds(4);
            triangleStrip.GetPointIds().SetId(0, 0);
            triangleStrip.GetPointIds().SetId(1, 1);
            triangleStrip.GetPointIds().SetId(2, 2);
            triangleStrip.GetPointIds().SetId(3, 3);

            vtkCellArray cells = vtkCellArray.New();
            cells.InsertNextCell(triangleStrip);
            // Create a polydata to store everything in
            vtkPolyData polyData = vtkPolyData.New();

            // Add the points to the dataset
            polyData.SetPoints(points);
            // Add the strip to the dataset
            polyData.SetStrips(cells);

            //Create an actor and mapper
            vtkDataSetMapper mapper = vtkDataSetMapper.New();
            mapper.SetInput(polyData);
            vtkActor actor = vtkActor.New();
            actor.GetProperty().SetRepresentationToWireframe();

            actor.SetMapper(mapper);

            RenderAddActor(actor);

        }
        private void ParametricObjectsDemo()
        {
            // we create a matrix of 4x4 renderer in our renderwindow
            // each renderer can be interacted with independently from one another
            int rendererSize = 189; // width per renderer
            int gridDimensions = 4;
            this.Size = new System.Drawing.Size(756, 756);
            Random rnd = new Random(2);
            List<vtkParametricFunction> parametricObjects = new List<vtkParametricFunction>();
            parametricObjects.Add(vtkParametricBoy.New());
            parametricObjects.Add(vtkParametricConicSpiral.New());
            parametricObjects.Add(vtkParametricCrossCap.New());
            parametricObjects.Add(vtkParametricDini.New());
            vtkParametricEllipsoid ellipsoid = vtkParametricEllipsoid.New();
            ellipsoid.SetXRadius(0.5);
            ellipsoid.SetYRadius(2.0);
            parametricObjects.Add(ellipsoid);
            parametricObjects.Add(vtkParametricEnneper.New());
            parametricObjects.Add(vtkParametricFigure8Klein.New());
            parametricObjects.Add(vtkParametricKlein.New());
            parametricObjects.Add(vtkParametricMobius.New());
            vtkParametricRandomHills randomHills = vtkParametricRandomHills.New();
            randomHills.AllowRandomGenerationOff();
            parametricObjects.Add(randomHills);
            parametricObjects.Add(vtkParametricRoman.New());
            vtkParametricSuperEllipsoid superEllipsoid = vtkParametricSuperEllipsoid.New();
            superEllipsoid.SetN1(.50);
            superEllipsoid.SetN2(.1);
            parametricObjects.Add(superEllipsoid);
            vtkParametricSuperToroid superToroid = vtkParametricSuperToroid.New();
            superToroid.SetN1(0.2);
            superToroid.SetN2(3.0);
            parametricObjects.Add(superToroid);
            parametricObjects.Add(vtkParametricTorus.New());

            vtkParametricSpline spline = vtkParametricSpline.New();
            vtkPoints inputPoints = vtkPoints.New();
            vtkMath.RandomSeed(8775070);
            for (int p = 0; p < 10; p++)
            {
                double x = vtkMath.Random(0.0, 1.0);
                double y = vtkMath.Random(0.0, 1.0);
                double z = vtkMath.Random(0.0, 1.0);
                inputPoints.InsertNextPoint(x, y, z);
            }
            spline.SetPoints(inputPoints);

            parametricObjects.Add(spline);


            List<vtkParametricFunctionSource> parametricFunctionSources = new List<vtkParametricFunctionSource>();
            List<vtkRenderer> renderers = new List<vtkRenderer>();
            List<vtkPolyDataMapper> mappers = new List<vtkPolyDataMapper>();
            List<vtkActor> actors = new List<vtkActor>();
            List<vtkTextMapper> textMappers = new List<vtkTextMapper>();
            List<vtkActor2D> textActors = new List<vtkActor2D>();

            // Create one text property for all
            vtkTextProperty textProperty = vtkTextProperty.New();
            textProperty.SetFontSize(12);
            textProperty.SetJustificationToCentered();

            // Create a source, renderer, mapper, and actor
            // for each object 
            for (int i = 0; i < parametricObjects.Count; i++)
            {
                parametricFunctionSources.Add(vtkParametricFunctionSource.New());
                parametricFunctionSources[i].SetParametricFunction(parametricObjects[i]);
                parametricFunctionSources[i].Update();
                mappers.Add(vtkPolyDataMapper.New());
                mappers[i].SetInputConnection(parametricFunctionSources[i].GetOutputPort());

                actors.Add(vtkActor.New());
                actors[i].SetMapper(mappers[i]);

                textMappers.Add(vtkTextMapper.New());
                textMappers[i].SetInput(parametricObjects[i].GetClassName());
                textMappers[i].SetTextProperty(textProperty);

                textActors.Add(vtkActor2D.New());
                textActors[i].SetMapper(textMappers[i]);
                textActors[i].SetPosition(rendererSize / 2, 16);

                renderers.Add(vtkRenderer.New());
            }

            // Need a renderer even if there is no actor
            for (int i = parametricObjects.Count; i < gridDimensions * gridDimensions; i++)
            {
                renderers.Add(vtkRenderer.New());
            }

            vtkRenderWindow renderWindow = myRenderWindowControl.RenderWindow;
            renderWindow.SetSize(rendererSize * gridDimensions, rendererSize * gridDimensions);

            for (int row = 0; row < gridDimensions; row++)
            {
                for (int col = 0; col < gridDimensions; col++)
                {
                    int index = row * gridDimensions + col;

                    // (xmin, ymin, xmax, ymax)
                    double[] viewport = new double[] {
                  (col) * rendererSize / (double)(gridDimensions * rendererSize),
                  (gridDimensions - (row+1)) * rendererSize / (double)(gridDimensions * rendererSize),
                  (col+1)*rendererSize / (double)(gridDimensions * rendererSize),
                  (gridDimensions - row) * rendererSize / (double)(gridDimensions * rendererSize)};

                    //Debug.WriteLine(viewport[0] + " " + viewport[1] + " " + viewport[2] + " " + viewport[3]);
                    renderWindow.AddRenderer(renderers[index]);
                    IntPtr pViewport = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 4);
                    Marshal.Copy(viewport, 0, pViewport, 4);
                    renderers[index].SetViewport(pViewport);
                    Marshal.FreeHGlobal(pViewport);
                    if (index > parametricObjects.Count - 1)
                        continue;

                    renderers[index].AddActor(actors[index]);
                    renderers[index].AddActor(textActors[index]);
                    renderers[index].SetBackground(.2 + rnd.NextDouble() / 8, .3 + rnd.NextDouble() / 8, .4 + rnd.NextDouble() / 8);
                    renderers[index].ResetCamera();
                    renderers[index].GetActiveCamera().Azimuth(30);
                    renderers[index].GetActiveCamera().Elevation(-50);
                    renderers[index].GetActiveCamera().Pitch(-2);
                    renderers[index].ResetCameraClippingRange();
                }
            }
        }
        private void OrientedArrow()
        {
            //Create an arrow.
            vtkArrowSource arrowSource = vtkArrowSource.New();

            // Generate a random start and end point
            vtkMath.RandomSeed(8775070);
            double[] startPoint = new double[]{
            vtkMath.Random(-10,10),
            vtkMath.Random(-10,10),
            vtkMath.Random(-10,10)
         };

            double[] endPoint = new double[]{
            vtkMath.Random(-10,10),
            vtkMath.Random(-10,10),
            vtkMath.Random(-10,10)
         };

            // Compute a basis
            double[] normalizedX = new double[3];
            double[] normalizedY = new double[3];
            double[] normalizedZ = new double[3];

            // The X axis is a vector from start to end
            myMath.Subtract(endPoint, startPoint, ref normalizedX);
            double length = myMath.Norm(normalizedX);
            myMath.Normalize(ref normalizedX);

            // The Z axis is an arbitrary vector cross X
            double[] arbitrary = new double[]{
            vtkMath.Random(-10,10),
            vtkMath.Random(-10,10),
            vtkMath.Random(-10,10)
         };
            myMath.Cross(normalizedX, arbitrary, ref normalizedZ);
            myMath.Normalize(ref normalizedZ);
            // The Y axis is Z cross X
            myMath.Cross(normalizedZ, normalizedX, ref normalizedY);
            vtkMatrix4x4 matrix = vtkMatrix4x4.New();

            // Create the direction cosine matrix
            matrix.Identity();
            for (int i = 0; i < 3; i++)
            {
                matrix.SetElement(i, 0, normalizedX[i]);
                matrix.SetElement(i, 1, normalizedY[i]);
                matrix.SetElement(i, 2, normalizedZ[i]);
            }

            // Apply the transforms
            vtkTransform transform = vtkTransform.New();
            transform.Translate(startPoint[0], startPoint[1], startPoint[2]);
            transform.Concatenate(matrix);
            transform.Scale(length, length, length);


            //Create a mapper and actor for the arrow
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            vtkActor actor = vtkActor.New();
#if USER_MATRIX
         mapper.SetInputConnection(arrowSource.GetOutputPort());
         actor.SetUserMatrix(transform.GetMatrix());
#else
            // Transform the polydata
            vtkTransformPolyDataFilter transformPD = vtkTransformPolyDataFilter.New();
            transformPD.SetTransform(transform);
            transformPD.SetInputConnection(arrowSource.GetOutputPort());
            mapper.SetInputConnection(transformPD.GetOutputPort());
#endif
            actor.SetMapper(mapper);

            // Create spheres for start and end point
            vtkSphereSource sphereStartSource = vtkSphereSource.New();
            sphereStartSource.SetCenter(startPoint[0], startPoint[1], startPoint[2]);
            vtkPolyDataMapper sphereStartMapper = vtkPolyDataMapper.New();
            sphereStartMapper.SetInputConnection(sphereStartSource.GetOutputPort());
            vtkActor sphereStart = vtkActor.New();
            sphereStart.SetMapper(sphereStartMapper);
            sphereStart.GetProperty().SetColor(1.0, 1.0, .3);

            vtkSphereSource sphereEndSource = vtkSphereSource.New();
            sphereEndSource.SetCenter(endPoint[0], endPoint[1], endPoint[2]);
            vtkPolyDataMapper sphereEndMapper = vtkPolyDataMapper.New();
            sphereEndMapper.SetInputConnection(sphereEndSource.GetOutputPort());
            vtkActor sphereEnd = vtkActor.New();
            sphereEnd.SetMapper(sphereEndMapper);
            sphereEnd.GetProperty().SetColor(1.0, .3, .3);

            vtkRenderWindow renderWindow = myRenderWindowControl.RenderWindow;
            vtkRenderer renderer = renderWindow.GetRenderers().GetFirstRenderer();
            renderer.SetBackground(0.2, 0.3, 0.4);
            renderer.AddActor(actor);
            renderer.AddActor(sphereStart);
            renderer.AddActor(sphereEnd);
            renderer.ResetCamera();
        }
    }

    // I'm using my own math class
    // reason: due to the fact that ActiViz wraps native, unmanaged functions in class vtkMath
    // many of the arguments like double arrays (for vector definition) has to be passed by an IntPtr.
    //
    // But there do exist some managed open source math libraries of professional quality, that it
    // should be not a problem at all using another math library for vector algebra.
    //   
    // vtkmath could be used for vetor algebra, no doubt, but then functions which heavily relies on 
    // vector algebra like dot or cross product, etc. would be full of Marshaling code.

    public class myMath
    {
        public static void Subtract(double[] a, double[] b, ref double[] c)
        {
            c[0] = a[0] - b[0];
            c[1] = a[1] - b[1];
            c[2] = a[2] - b[2];
        }


        public static double Norm(double[] x)
        {
            return Math.Sqrt(x[0] * x[0] + x[1] * x[1] + x[2] * x[2]);
        }


        public static void Normalize(ref double[] x)
        {
            double length = Norm(x);
            x[0] /= length;
            x[1] /= length;
            x[2] /= length;
        }

        public static void Cross(double[] x, double[] y, ref double[] z)
        {
            z[0] = (x[1] * y[2]) - (x[2] * y[1]);
            z[1] = (x[2] * y[0]) - (x[0] * y[2]);
            z[2] = (x[0] * y[1]) - (x[1] * y[0]);
        }
    }
}
