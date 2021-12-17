using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Runtime;

namespace SLW16
{
    public partial class Form1 : Form
    {
        private double _a;
        private double _b;
        private double _dx;
        private bool isBuilt = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private double Func(double x)
        {
            if (x == 0)
            {
                return 1;
            }
            return Math.Pow(x - 2, 2.5) + _a * _b;
        }

        private void DrawGraph()
        {
            GraphPane pane = zedGraph.GraphPane;
            Pen pen = new Pen(Color.Blue, 1);
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();
            PointPairList list = new PointPairList();

            double xmin = 1;
            double xmax = 4;

            for (double x = xmin; x <= xmax; x += _dx)
            {
                list.Add(x, Func(x));
            }

            LineItem myCurve = pane.AddCurve("Sinc", list, Color.Blue, SymbolType.None);          
            TextObj text1X = new TextObj("1", 2, 0);
            text1X.FontSpec.Size = 6f;
            text1X.FontSpec.Border.IsVisible = false;
            pane.GraphObjList.Add(text1X);
            TextObj text2X = new TextObj("4", 4, 0);
            text2X.FontSpec.Size = 6f;
            text2X.FontSpec.Border.IsVisible = false;
            pane.GraphObjList.Add(text2X);

            TextObj text1Y = new TextObj(Convert.ToString(Func(2)), 0, Func(2));
            text1Y.FontSpec.Size = 6f;
            text1Y.FontSpec.Border.IsVisible = false;
            pane.GraphObjList.Add(text1Y);
            TextObj text2Y = new TextObj(Convert.ToString(Func(4)), 0, Func(4));
            text2Y.FontSpec.Size = 6f;
            text2Y.FontSpec.Border.IsVisible = false;
            pane.GraphObjList.Add(text2Y);

            LineObj lineY = new LineObj(Color.Black, 0, -1000, 0, 1000);
            pane.GraphObjList.Add(lineY);

            LineObj line1X = new LineObj(Color.Red, 2, 0, 2, Func(2));
            pane.GraphObjList.Add(line1X);
            LineObj line2X = new LineObj(Color.Red, 4, 0, 4, Func(4));
            pane.GraphObjList.Add(line2X);

            LineObj line1Y = new LineObj(Color.Green, 0, Func(2), 2, Func(2));
            pane.GraphObjList.Add(line1Y);
            LineObj line2Y = new LineObj(Color.Green, 0, Func(4), 4, Func(4));
            pane.GraphObjList.Add(line2Y);

            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _a = Convert.ToDouble(textBox1.Text);
                _b = Convert.ToDouble(textBox2.Text);
                _dx = 0.001;
                DrawGraph();
                isBuilt = true;
            }
            catch
            {
                MessageBox.Show("Set the boxes with values: a | b");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isBuilt)
            {
                try
                {
                    _a = Convert.ToDouble(textBox1.Text);
                    _b = Convert.ToDouble(textBox2.Text);
                    DrawGraph();
                }
                catch
                {

                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (isBuilt)
            {
                try
                {
                    _a = Convert.ToDouble(textBox1.Text);
                    _b = Convert.ToDouble(textBox2.Text);
                    DrawGraph();
                }
                catch
                {

                }
            }
        }

        private void zedGraph_Load(object sender, EventArgs e)
        {

        }
    }
}
