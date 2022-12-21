using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace  Zatonskaya_IDZ
{
    public partial class Form1 : Form
    {
        string figure_type = "Ellipse";
        int count_of_elps = 0;
        int count_of_prllgrm = 0;
        int count_of_rctngle = 0;
        int count_of_dmnd = 0;
        int count_of_arrw = 0;
        int count_of_txt = 0;
        int count_of_str = 0;


        int prev_x = 0;
        int prev_y = 0;
        bool mouse_down = false;
        bool focus = false;
        bool moving = false;
        int catch_point_index = -1;
        int catch_figure_index = -1;
        string type_of_focused_figure = "Ellipse";
        string[] str = new string[40];
       
        Point[][] elps;
        Point[][] prllgrm;
        Point[][] rctngle;
        Point[][] dmnd;
        Point[][] arrw;
        Point[][] txt;
        

        public Form1()
        {
            InitializeComponent();
            elps = new Point[100][];
            for (int i = 0; i < 100; i++)
                elps[i] = new Point[2];
            prllgrm = new Point[100][];
            for (int i = 0; i < 100; i++)
                prllgrm[i] = new Point[2];
            rctngle = new Point[100][];
            for (int i = 0; i < 100; i++)
                rctngle[i] = new Point[2];
            dmnd = new Point[100][];
            for (int i = 0; i < 100; i++)
                dmnd[i] = new Point[2];
            arrw = new Point[100][];
            for (int i = 0; i < 100; i++)
                arrw[i] = new Point[2];
            txt = new Point[100][];
            for (int i = 0; i < 100; i++)
                txt[i] = new Point[1];
        }
        private void panel3_MouseUp(object sender, MouseEventArgs e) // Создание объекта
        {
            mouse_down = false;
            if (!moving)
            {
                switch (figure_type)
                {
                    case "Ellipse":
                        elps[count_of_elps][1].X = e.X;
                        elps[count_of_elps][1].Y = e.Y;
                        count_of_elps++;
                        break;
                    case "Parallelogram":
                        prllgrm[count_of_prllgrm][1].X = e.X;
                        prllgrm[count_of_prllgrm][1].Y = e.Y;
                        count_of_prllgrm++;
                        break;
                    case "Rectangle":
                        rctngle[count_of_rctngle][1].X = e.X;
                        rctngle[count_of_rctngle][1].Y = e.Y;
                        count_of_rctngle++;
                        break;
                    case "Diamond":
                        dmnd[count_of_dmnd][1].X = e.X;
                        dmnd[count_of_dmnd][1].Y = e.Y;
                        count_of_dmnd++;
                        break;
                    case "Arrow":
                        arrw[count_of_arrw][1].X = e.X;
                        arrw[count_of_arrw][1].Y = e.Y;
                        count_of_arrw++;
                        break;
                    case "Text":
                        txt[count_of_txt][0].X = e.X;
                        txt[count_of_txt][0].Y = e.Y;
                        count_of_str++;
                        count_of_txt++;
                        break;
                }
            }
            panel3.Invalidate();
        }
        private void panel3_MouseDown(object sender, MouseEventArgs e)  // Берем координаты первой точки фигуры
        {
            mouse_down = true;
            switch (figure_type)
            {
                case "Ellipse":
                    elps[count_of_elps][0].X = e.X;
                    elps[count_of_elps][0].Y = e.Y;
                    break;
                case "Parallelogram":
                    prllgrm[count_of_prllgrm][0].X = e.X;
                    prllgrm[count_of_prllgrm][0].Y = e.Y;
                    break;
                case "Rectangle":
                    rctngle[count_of_rctngle][0].X = e.X;
                    rctngle[count_of_rctngle][0].Y = e.Y;
                    break;
                case "Diamond":
                    dmnd[count_of_dmnd][0].X = e.X;
                    dmnd[count_of_dmnd][0].Y = e.Y;
                    break;
                case "Arrow":
                    arrw[count_of_arrw][0].X = e.X;
                    arrw[count_of_arrw][0].Y = e.Y;
                    break;
            }          
        }
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {   
            if (mouse_down && focus)            // Изменение положения захваченной фигуры.
            {
                switch(type_of_focused_figure)
                {
                    
                    case "Ellipse":
                        prev_x = elps[catch_figure_index][catch_point_index].X;
                        prev_y = elps[catch_figure_index][catch_point_index].Y;
                        elps[catch_figure_index][catch_point_index].X = e.X;
                        elps[catch_figure_index][catch_point_index].Y = e.Y;
                        elps[catch_figure_index][0].X += e.X - prev_x;
                        elps[catch_figure_index][0].Y += e.Y - prev_y;
                        break;
                    case "Parallelogram":
                        prev_x = prllgrm[catch_figure_index][catch_point_index].X;
                        prev_y = prllgrm[catch_figure_index][catch_point_index].Y;
                        prllgrm[catch_figure_index][catch_point_index].X = e.X;
                        prllgrm[catch_figure_index][catch_point_index].Y = e.Y;
                        prllgrm[catch_figure_index][0].X += e.X - prev_x;
                        prllgrm[catch_figure_index][0].Y += e.Y - prev_y;
                        break;
                    case "Rectangle":
                        prev_x = rctngle[catch_figure_index][catch_point_index].X;
                        prev_y = rctngle[catch_figure_index][catch_point_index].Y;
                        rctngle[catch_figure_index][catch_point_index].X = e.X;
                        rctngle[catch_figure_index][catch_point_index].Y = e.Y;
                        rctngle[catch_figure_index][0].X += e.X - prev_x;
                        rctngle[catch_figure_index][0].Y += e.Y - prev_y;
                        break;
                    case "Diamond":
                        prev_x = dmnd[catch_figure_index][catch_point_index].X;
                        prev_y = dmnd[catch_figure_index][catch_point_index].Y;
                        dmnd[catch_figure_index][catch_point_index].X = e.X;
                        dmnd[catch_figure_index][catch_point_index].Y = e.Y;
                        dmnd[catch_figure_index][0].X += e.X - prev_x;
                        dmnd[catch_figure_index][0].Y += e.Y - prev_y;
                        break;
                    case "Text":
                        txt[catch_figure_index][0].X = e.X;
                        txt[catch_figure_index][0].Y = e.Y;
                        break;
                }
                
            }
            else if (mouse_down)               // Берем координаты второй точки фигуры.
            {
                switch (figure_type)
                {
                    case "Ellipse":
                        elps[count_of_elps][1].X = e.X;
                        elps[count_of_elps][1].Y = e.Y;
                        break;
                    case "Parallelogram":
                        prllgrm[count_of_prllgrm][1].X = e.X;
                        prllgrm[count_of_prllgrm][1].Y = e.Y;
                        break;
                    case "Rectangle":
                        rctngle[count_of_rctngle][1].X = e.X;
                        rctngle[count_of_rctngle][1].Y = e.Y;
                        break;
                    case "Diamond":
                        dmnd[count_of_dmnd][1].X = e.X;
                        dmnd[count_of_dmnd][1].Y = e.Y;
                        break;
                    case "Arrow":
                        arrw[count_of_arrw][1].X = e.X;
                        arrw[count_of_arrw][1].Y = e.Y;
                        break;
                    
                }
            }
            else if(figure_type != "Arrow") // Поиск точки захвата фигуры
            {
                moving = false;
                focus = false;
                catch_point_index = -1;
                catch_figure_index = -1;
                for (int i = 0; i < count_of_elps; i++)
                {
                    
                    if (Math.Abs(elps[i][1].X - e.X) < 5 || Math.Abs(elps[i][1].Y - e.Y) < 5)
                    {
                        moving = true;
                        focus = true;
                        catch_point_index = 1;
                        catch_figure_index = i;
                        type_of_focused_figure = "Ellipse";

                    }
                }
                for (int i = 0; i < count_of_prllgrm; i++)
                {
                    
                    if (Math.Abs(prllgrm[i][1].X - e.X) < 5 || Math.Abs(prllgrm[i][1].Y - e.Y) < 5)
                    {
                        moving = true;
                        focus = true;
                        catch_point_index = 1;
                        catch_figure_index = i;
                        type_of_focused_figure = "Parallelogram";

                    }
                }
                for (int i = 0; i < count_of_rctngle; i++)
                {          
                    if (Math.Abs(rctngle[i][1].X - e.X) < 5 || Math.Abs(rctngle[i][1].Y - e.Y) < 5)
                    {
                        moving = true;
                        focus = true;
                        catch_point_index = 1;
                        catch_figure_index = i;
                        type_of_focused_figure = "Rectangle";

                    }
                }
                for (int i = 0; i < count_of_dmnd; i++)
                {
                   
                    if (Math.Abs(dmnd[i][1].X - e.X) < 5 || Math.Abs(dmnd[i][1].Y - e.Y) < 5)
                    {
                        moving = true;
                        focus = true;
                        catch_point_index = 1;
                        catch_figure_index = i;
                        type_of_focused_figure = "Diamond";

                    }
                }
                for (int i = 0; i < count_of_txt; i++)
                {

                    if (Math.Abs(txt[i][0].X - e.X) < 5 || Math.Abs(txt[i][0].Y - e.Y) < 5)
                    {
                        moving = true;
                        focus = true;
                        catch_point_index = 0;
                        catch_figure_index = i;
                        type_of_focused_figure = "Text";

                    }
                }
            }  
           
            panel3.Invalidate();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)    // отрисовка всех элементов
        {
            Graphics g = e.Graphics;
            if (focus)
            {
                switch (type_of_focused_figure)             // рисование точек для захвата фигуры
                {                 
                    case "Ellipse":
                        g.DrawEllipse(new Pen(Color.Red), elps[catch_figure_index][catch_point_index].X, elps[catch_figure_index][catch_point_index].Y, 10, 10);
                        break;
                    case "Parallelogram":
                        g.DrawEllipse(new Pen(Color.Red), prllgrm[catch_figure_index][catch_point_index].X, prllgrm[catch_figure_index][catch_point_index].Y, 10, 10);
                        break;
                    case "Rectangle":
                        g.DrawEllipse(new Pen(Color.Red), rctngle[catch_figure_index][catch_point_index].X, rctngle[catch_figure_index][catch_point_index].Y, 10, 10);
                        break;
                    case "Diamond":
                        g.DrawEllipse(new Pen(Color.Red), dmnd[catch_figure_index][catch_point_index].X, dmnd[catch_figure_index][catch_point_index].Y, 10, 10);
                        break;
                    case "Text":
                        g.DrawEllipse(new Pen(Color.Blue), txt[catch_figure_index][0].X, txt[catch_figure_index][0].Y, 10, 10);
                        break;

                }
            }              
                for (int i = 0; i < count_of_elps; i++)
                {
                    g.DrawEllipse(new Pen(Color.Black), elps[i][0].X, elps[i][0].Y, elps[i][1].X - elps[i][0].X, elps[i][1].Y - elps[i][0].Y);
                }
                for (int i = 0; i < count_of_rctngle; i++)
                {
                    g.DrawRectangle(new Pen(Color.Black), rctngle[i][0].X, rctngle[i][0].Y, rctngle[i][1].X - rctngle[i][0].X, rctngle[i][1].Y - rctngle[i][0].Y);
                }
                for (int i = 0; i < count_of_prllgrm; i++)
                {
                    Point parallelogram_point1 = new Point(prllgrm[i][0].X, prllgrm[i][0].Y);
                    Point parallelogram_point2 = new Point(prllgrm[i][1].X, prllgrm[i][0].Y);
                    Point parallelogram_point3 = new Point(prllgrm[i][1].X - Convert.ToInt32(Math.Sqrt(prllgrm[i][1].X)), prllgrm[i][1].Y);
                    Point parallelogram_point4 = new Point(prllgrm[i][0].X - Convert.ToInt32(Math.Sqrt(prllgrm[i][1].X)), prllgrm[i][1].Y);

                    Point[] parallelogram_points =
                     {
                        parallelogram_point1,
                        parallelogram_point2,
                        parallelogram_point3,
                        parallelogram_point4
                     };
                    g.DrawPolygon(new Pen(Color.Black), parallelogram_points);
                }
                for (int i = 0; i < count_of_dmnd; i++)
                {
                    Point diamond_point1 = new Point(dmnd[i][0].X, dmnd[i][0].Y - (dmnd[i][1].Y - dmnd[i][0].Y));
                    Point diamond_point2 = new Point(dmnd[i][0].X + (dmnd[i][1].X - dmnd[i][0].X), dmnd[i][0].Y);
                    Point diamond_point3 = new Point(dmnd[i][0].X, dmnd[i][0].Y + (dmnd[i][1].Y - dmnd[i][0].Y));
                    Point diamond_point4 = new Point(dmnd[i][0].X - (dmnd[i][1].X - dmnd[i][0].X), dmnd[i][0].Y);
                    Point[] diamond_points =
                     {
                        diamond_point1,
                        diamond_point2,
                        diamond_point3,
                        diamond_point4
                     };
                    g.DrawPolygon(new Pen(Color.Black), diamond_points);
                }
                Pen arrow_pen = new Pen(Brushes.Black, 4f);
                arrow_pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                for (int i = 0; i < count_of_arrw; i++)
                {
                    g.DrawLine(arrow_pen, arrw[i][0].X, arrw[i][0].Y, arrw[i][1].X, arrw[i][1].Y);
                }
            Font myfont = new Font("Arial", 8.0f);
            
            for (int i = 0; i < count_of_txt; i++)
            {
                g.DrawString(str[i], myfont, Brushes.Black, txt[i][0].X, txt[i][0].Y);
            }

            if (mouse_down == true)
                {
                    g.DrawEllipse(new Pen(Color.Black), elps[count_of_elps][0].X, elps[count_of_elps][0].Y, elps[count_of_elps][1].X - elps[count_of_elps][0].X, elps[count_of_elps][1].Y - elps[count_of_elps][0].Y);
                    g.DrawRectangle(new Pen(Color.Black), rctngle[count_of_rctngle][0].X, rctngle[count_of_rctngle][0].Y, rctngle[count_of_rctngle][1].X - rctngle[count_of_rctngle][0].X, rctngle[count_of_rctngle][1].Y - rctngle[count_of_rctngle][0].Y);
                    Point parallelogram_point1 = new Point(prllgrm[count_of_prllgrm][0].X, prllgrm[count_of_prllgrm][0].Y);
                    Point parallelogram_point2 = new Point(prllgrm[count_of_prllgrm][1].X, prllgrm[count_of_prllgrm][0].Y);
                    Point parallelogram_point3 = new Point(prllgrm[count_of_prllgrm][1].X - Convert.ToInt32(Math.Sqrt(prllgrm[count_of_prllgrm][1].X)), prllgrm[count_of_prllgrm][1].Y);
                    Point parallelogram_point4 = new Point(prllgrm[count_of_prllgrm][0].X - Convert.ToInt32(Math.Sqrt(prllgrm[count_of_prllgrm][1].X)), prllgrm[count_of_prllgrm][1].Y);

                    Point[] parallelogram_points =
                     {
                        parallelogram_point1,
                        parallelogram_point2,
                        parallelogram_point3,
                        parallelogram_point4
                     };
                    g.DrawPolygon(new Pen(Color.Black), parallelogram_points);
                    Point diamond_point1 = new Point(dmnd[count_of_dmnd][0].X, dmnd[count_of_dmnd][0].Y - (dmnd[count_of_dmnd][1].Y - dmnd[count_of_dmnd][0].Y));
                    Point diamond_point2 = new Point(dmnd[count_of_dmnd][0].X + (dmnd[count_of_dmnd][1].X - dmnd[count_of_dmnd][0].X), dmnd[count_of_dmnd][0].Y);
                    Point diamond_point3 = new Point(dmnd[count_of_dmnd][0].X, dmnd[count_of_dmnd][0].Y + (dmnd[count_of_dmnd][1].Y - dmnd[count_of_dmnd][0].Y));
                    Point diamond_point4 = new Point(dmnd[count_of_dmnd][0].X - (dmnd[count_of_dmnd][1].X - dmnd[count_of_dmnd][0].X), dmnd[count_of_dmnd][0].Y);
                    Point[] diamond_points =
                     {
                        diamond_point1,
                        diamond_point2,
                        diamond_point3,
                        diamond_point4
                        };
                    g.DrawPolygon(new Pen(Color.Black), diamond_points);
                    g.DrawLine(arrow_pen, arrw[count_of_arrw][0].X, arrw[count_of_arrw][0].Y, arrw[count_of_arrw][1].X, arrw[count_of_arrw][1].Y);
                    g.DrawString(str[count_of_str], myfont, Brushes.Black, txt[count_of_txt][0].X, txt[count_of_txt][0].Y);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            figure_type = "Ellipse";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            figure_type = "Parallelogram";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            figure_type = "Rectangle";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            figure_type = "Diamond";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            figure_type = "Arrow";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            figure_type = "Text";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           str[count_of_str] = textBox1.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
