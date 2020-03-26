namespace VTKTest
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.longLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polyLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.solidsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexahedronToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parametricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.torusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conicSpiralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossCapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipsoidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enneperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figure8KleinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kleinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mobiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomHillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.romanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superEllipsoidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superToroidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.pointToolStripMenuItem,
            this.polygonToolStripMenuItem,
            this.solidsToolStripMenuItem,
            this.parametricToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(758, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openImageToolStripMenuItem.Text = "Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem1,
            this.longLineToolStripMenuItem,
            this.polyLineToolStripMenuItem});
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.lineToolStripMenuItem.Text = "Line";
            // 
            // lineToolStripMenuItem1
            // 
            this.lineToolStripMenuItem1.Name = "lineToolStripMenuItem1";
            this.lineToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.lineToolStripMenuItem1.Text = "Line";
            this.lineToolStripMenuItem1.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // longLineToolStripMenuItem
            // 
            this.longLineToolStripMenuItem.Name = "longLineToolStripMenuItem";
            this.longLineToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.longLineToolStripMenuItem.Text = "Colored Lines";
            this.longLineToolStripMenuItem.Click += new System.EventHandler(this.ColoredLinesToolStripMenuItem_Click);
            // 
            // polyLineToolStripMenuItem
            // 
            this.polyLineToolStripMenuItem.Name = "polyLineToolStripMenuItem";
            this.polyLineToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.polyLineToolStripMenuItem.Text = "Poly Line";
            this.polyLineToolStripMenuItem.Click += new System.EventHandler(this.PolyLineToolStripMenuItem_Click);
            // 
            // pointToolStripMenuItem
            // 
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.pointToolStripMenuItem.Text = "Point";
            this.pointToolStripMenuItem.Click += new System.EventHandler(this.pointToolStripMenuItem_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polygonToolStripMenuItem1});
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.polygonToolStripMenuItem.Text = "Polygon";
            // 
            // polygonToolStripMenuItem1
            // 
            this.polygonToolStripMenuItem1.Name = "polygonToolStripMenuItem1";
            this.polygonToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.polygonToolStripMenuItem1.Text = "Regular Polygon";
            this.polygonToolStripMenuItem1.Click += new System.EventHandler(this.RegularPolygonToolStripMenuItem1_Click_1);
            // 
            // solidsToolStripMenuItem
            // 
            this.solidsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexahedronToolStripMenuItem1});
            this.solidsToolStripMenuItem.Name = "solidsToolStripMenuItem";
            this.solidsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.solidsToolStripMenuItem.Text = "Solids";
            // 
            // hexahedronToolStripMenuItem1
            // 
            this.hexahedronToolStripMenuItem1.Name = "hexahedronToolStripMenuItem1";
            this.hexahedronToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.hexahedronToolStripMenuItem1.Text = "Hexahedron";
            this.hexahedronToolStripMenuItem1.Click += new System.EventHandler(this.hexahedronToolStripMenuItem1_Click);
            // 
            // parametricToolStripMenuItem
            // 
            this.parametricToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.torusToolStripMenuItem,
            this.boyToolStripMenuItem,
            this.conicSpiralToolStripMenuItem,
            this.crossCapToolStripMenuItem,
            this.diniToolStripMenuItem,
            this.ellipsoidToolStripMenuItem,
            this.enneperToolStripMenuItem,
            this.figure8KleinToolStripMenuItem,
            this.kleinToolStripMenuItem,
            this.mobiusToolStripMenuItem,
            this.randomHillsToolStripMenuItem,
            this.romanToolStripMenuItem,
            this.splineToolStripMenuItem,
            this.superEllipsoidToolStripMenuItem,
            this.superToroidToolStripMenuItem});
            this.parametricToolStripMenuItem.Name = "parametricToolStripMenuItem";
            this.parametricToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.parametricToolStripMenuItem.Text = "Parametric";
            // 
            // torusToolStripMenuItem
            // 
            this.torusToolStripMenuItem.Name = "torusToolStripMenuItem";
            this.torusToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.torusToolStripMenuItem.Text = "Torus";
            this.torusToolStripMenuItem.Click += new System.EventHandler(this.torusToolStripMenuItem_Click);
            // 
            // boyToolStripMenuItem
            // 
            this.boyToolStripMenuItem.Name = "boyToolStripMenuItem";
            this.boyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.boyToolStripMenuItem.Text = "Boy";
            this.boyToolStripMenuItem.Click += new System.EventHandler(this.boyToolStripMenuItem_Click);
            // 
            // conicSpiralToolStripMenuItem
            // 
            this.conicSpiralToolStripMenuItem.Name = "conicSpiralToolStripMenuItem";
            this.conicSpiralToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.conicSpiralToolStripMenuItem.Text = "ConicSpiral";
            this.conicSpiralToolStripMenuItem.Click += new System.EventHandler(this.conicSpiralToolStripMenuItem_Click);
            // 
            // crossCapToolStripMenuItem
            // 
            this.crossCapToolStripMenuItem.Name = "crossCapToolStripMenuItem";
            this.crossCapToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.crossCapToolStripMenuItem.Text = "CrossCap";
            this.crossCapToolStripMenuItem.Click += new System.EventHandler(this.crossCapToolStripMenuItem_Click);
            // 
            // diniToolStripMenuItem
            // 
            this.diniToolStripMenuItem.Name = "diniToolStripMenuItem";
            this.diniToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.diniToolStripMenuItem.Text = "Dini";
            this.diniToolStripMenuItem.Click += new System.EventHandler(this.diniToolStripMenuItem_Click);
            // 
            // ellipsoidToolStripMenuItem
            // 
            this.ellipsoidToolStripMenuItem.Name = "ellipsoidToolStripMenuItem";
            this.ellipsoidToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ellipsoidToolStripMenuItem.Text = "Ellipsoid";
            this.ellipsoidToolStripMenuItem.Click += new System.EventHandler(this.ellipsoidToolStripMenuItem_Click);
            // 
            // enneperToolStripMenuItem
            // 
            this.enneperToolStripMenuItem.Name = "enneperToolStripMenuItem";
            this.enneperToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.enneperToolStripMenuItem.Text = "Enneper";
            this.enneperToolStripMenuItem.Click += new System.EventHandler(this.enneperToolStripMenuItem_Click);
            // 
            // figure8KleinToolStripMenuItem
            // 
            this.figure8KleinToolStripMenuItem.Name = "figure8KleinToolStripMenuItem";
            this.figure8KleinToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.figure8KleinToolStripMenuItem.Text = "Figure8Klein";
            this.figure8KleinToolStripMenuItem.Click += new System.EventHandler(this.figure8KleinToolStripMenuItem_Click);
            // 
            // kleinToolStripMenuItem
            // 
            this.kleinToolStripMenuItem.Name = "kleinToolStripMenuItem";
            this.kleinToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.kleinToolStripMenuItem.Text = "Klein";
            this.kleinToolStripMenuItem.Click += new System.EventHandler(this.kleinToolStripMenuItem_Click);
            // 
            // mobiusToolStripMenuItem
            // 
            this.mobiusToolStripMenuItem.Name = "mobiusToolStripMenuItem";
            this.mobiusToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.mobiusToolStripMenuItem.Text = "Mobius";
            this.mobiusToolStripMenuItem.Click += new System.EventHandler(this.mobiusToolStripMenuItem_Click);
            // 
            // randomHillsToolStripMenuItem
            // 
            this.randomHillsToolStripMenuItem.Name = "randomHillsToolStripMenuItem";
            this.randomHillsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.randomHillsToolStripMenuItem.Text = "RandomHills";
            this.randomHillsToolStripMenuItem.Click += new System.EventHandler(this.randomHillsToolStripMenuItem_Click);
            // 
            // romanToolStripMenuItem
            // 
            this.romanToolStripMenuItem.Name = "romanToolStripMenuItem";
            this.romanToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.romanToolStripMenuItem.Text = "Roman";
            this.romanToolStripMenuItem.Click += new System.EventHandler(this.romanToolStripMenuItem_Click);
            // 
            // splineToolStripMenuItem
            // 
            this.splineToolStripMenuItem.Name = "splineToolStripMenuItem";
            this.splineToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.splineToolStripMenuItem.Text = "Spline";
            this.splineToolStripMenuItem.Click += new System.EventHandler(this.splineToolStripMenuItem_Click);
            // 
            // superEllipsoidToolStripMenuItem
            // 
            this.superEllipsoidToolStripMenuItem.Name = "superEllipsoidToolStripMenuItem";
            this.superEllipsoidToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.superEllipsoidToolStripMenuItem.Text = "SuperEllipsoid";
            this.superEllipsoidToolStripMenuItem.Click += new System.EventHandler(this.superEllipsoidToolStripMenuItem_Click);
            // 
            // superToroidToolStripMenuItem
            // 
            this.superToroidToolStripMenuItem.Name = "superToroidToolStripMenuItem";
            this.superToroidToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.superToroidToolStripMenuItem.Text = "SuperToroid";
            this.superToroidToolStripMenuItem.Click += new System.EventHandler(this.superToroidToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 473);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "VTK Test Learning Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem longLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polyLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem solidsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexahedronToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametricToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem torusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conicSpiralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crossCapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipsoidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enneperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figure8KleinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kleinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mobiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomHillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem romanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superEllipsoidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superToroidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

