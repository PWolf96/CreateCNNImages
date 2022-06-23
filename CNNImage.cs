using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace CreateCNNImages
{
    class CNNImage
    {

        public static void CreateBitmap(List<Event> eventEntryList, int counter)
        {
            //Bitmap baseImage;
            Bitmap overlayImage = new Bitmap(1200,800);
            //Bitmap finalImage = new Bitmap(overlayImage.Width, overlayImage.Height, PixelFormat.Format32bppArgb);
            //Graphics graphics = Graphics.FromImage(finalImage);
            string teamInPoss = eventEntryList.First().poseessionTeamName;
            Pen Blue = new Pen(Color.Blue, 4);
            //Pen othersDash = new Pen(Color.Green, 4);
            Pen DarkGray = new Pen(System.Drawing.Color.DarkGray, 4);
            Pen Black = new Pen(System.Drawing.Color.Black, 4);
            Pen Red = new Pen(System.Drawing.Color.Red, 4);
            Pen Pink = new Pen(System.Drawing.Color.DeepPink, 4);

            //Pen othersThick = new Pen(System.Drawing.Color.Red, 4);
            double ratioX = 10;
            double ratioY = 10;

            if (teamInPoss == "Chelsea FCW")
            {

                //baseImage = (Bitmap)Image.FromFile(@"C:\Users\Petar\Downloads\WhiteFP.jpg");
                using (Graphics g = Graphics.FromImage(overlayImage))
                {
                    g.Clear(System.Drawing.Color.White);
                    int firstPass = 1;
                    foreach (Event entry in eventEntryList)
                    {
                        if (entry.teamName == teamInPoss)
                        {
                            if (entry.typeName == "Pass")
                            {
                                if (firstPass == 1)
                                {
                                    if (entry.passHeight == "High Passs")
                                    {
                                        Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
                                        Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.passEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.passEndLocY) * ratioY));
                                        g.DrawLine(DarkGray, startPoint, endPoint);

                                        DrawArrow(g, Pink, endPoint, startPoint, 10);
                                        firstPass += 1;
                                    }

                                    else
                                    {
                                        Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
                                        Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.passEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.passEndLocY) * ratioY));
                                        g.DrawLine(DarkGray, startPoint, endPoint);

                                        DrawArrow(g, Pink, endPoint, startPoint, 10);
                                        firstPass += 1;
                                    }
                                }

                                else
                                {
                                    if (entry.passHeight == "High Passs")
                                    {
                                        Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
                                        Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.passEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.passEndLocY) * ratioY));
                                        g.DrawLine(DarkGray, startPoint, endPoint);

                                        DrawArrow(g, Black, endPoint, startPoint, 10);
                                    }

                                    else
                                    {
                                        Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
                                        Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.passEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.passEndLocY) * ratioY));
                                        g.DrawLine(DarkGray, startPoint, endPoint);

                                        DrawArrow(g, DarkGray, endPoint, startPoint, 10);
                                    }
                                }


                            }

                            if (entry.typeName == "Shot")
                            {
                                Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
                                Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.shotEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.shotEndLocY) * ratioY));
                                g.DrawLine(DarkGray, startPoint, endPoint);

                                DrawArrow(g, DarkGray, endPoint, startPoint, 10);
                            }

                            if (entry.typeName == "Carry")
                            {
                                Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
                                Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.carryEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.carryEngLocY) * ratioY));
                                g.DrawLine(Blue, startPoint, endPoint);

                                DrawArrow(g, Blue, endPoint, startPoint, 10);
                            }

                            //if (entry.typeName == "Interception")
                            //{
                            //    int x = Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX);
                            //    int y = Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY);
                            //    g.DrawRectangle(chelsea, x, y, 30, 30);
                            //}

                            //if (entry.typeName == "Clearance")
                            //{
                            //    int x = Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX);
                            //    int y = Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY);
                            //    g.DrawRectangle(chelseaDash, x, y, 30, 30);
                            //}

                            //if (entry.typeName == "Block")
                            //{
                            //    int x = Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX);
                            //    int y = Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY);
                            //    g.DrawRectangle(chelseaThick, x, y, 30, 30);
                            //}

                            //if (entry.typeName == "Pressure")
                            //{
                            //    int x = Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX);
                            //    int y = Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY);
                            //    g.DrawRectangle(others, x, y, 30, 30);
                            //}

                        }

                        else
                        {
                            //if (entry.typeName == "Pass")
                            //{
                            //    Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
                            //    Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.passEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.passEndLocY) * ratioY));
                            //    g.DrawLine(others, startPoint, endPoint);
                            //    DrawArrow(g, others, endPoint, startPoint, 10);
                            //}

                            //if (entry.typeName == "Carry")
                            //{
                            //    Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
                            //    Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.carryEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.carryEngLocY) * ratioY));
                            //    g.DrawLine(othersDash, startPoint, endPoint);

                            //    DrawArrow(g, othersDash, endPoint, startPoint, 10);
                            //}

                            //if (entry.typeName == "Shot")
                            //{

                            //}

                            if (entry.typeName == "Interception")
                            {
                                int x = 1200 - Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX);
                                int y = 800 - Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY);
                                g.DrawRectangle(DarkGray, x, y, 30, 30);
                            }

                            if (entry.typeName == "Clearance")
                            {
                                int x = 1200 - Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX);
                                int y = 800 - Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY);
                                g.DrawRectangle(Blue, x, y, 30, 30);
                            }

                            if (entry.typeName == "Block")
                            {
                                int x = 1200 - Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX);
                                int y = 800 - Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY);
                                g.DrawRectangle(Black, x, y, 30, 30);
                            }

                            if (entry.typeName == "Pressure")
                            {
                                int x = 1200 - Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX);
                                int y = 800 - Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY);
                                g.DrawRectangle(Red, x, y, 30, 30);
                            }
                        }
                    }

                }
                //save the final composite image to disk
                overlayImage.Save(@"C:\Users\Petar\Downloads\CNNImages\test" + counter + ".jpg", ImageFormat.Jpeg);
            }

            #region other team
            //else
            //{
            //    //baseImage = (Bitmap)Image.FromFile(@"C:\Users\Petar\Downloads\WhiteFP.jpg");
            //    using (Graphics g = Graphics.FromImage(overlayImage))
            //    {
            //        g.Clear(System.Drawing.Color.White);

            //        foreach (Event entry in eventEntryList)
            //        {
            //            if (entry.teamName == teamInPoss)
            //            {
            //                if (entry.typeName == "Pass" || entry.typeName == "Shot")
            //                {
            //                    if (entry.passHeight == "High Pass")
            //                    {
            //                        Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
            //                        Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.passEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.passEndLocY) * ratioY));
            //                        g.DrawLine(others, startPoint, endPoint);
            //                        DrawArrow(g, others, endPoint, startPoint, 10);
            //                    }
            //                    else
            //                    {
            //                        Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
            //                        Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.passEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.passEndLocY) * ratioY));
            //                        g.DrawLine(others, startPoint, endPoint);
            //                        DrawArrow(g, others, endPoint, startPoint, 10);
            //                    }


            //                }

            //                if (entry.typeName == "Carry")
            //                {
            //                    Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
            //                    Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.carryEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.carryEngLocY) * ratioY));
            //                    g.DrawLine(othersDash, startPoint, endPoint);

            //                    DrawArrow(g, othersDash, endPoint, startPoint, 10);
            //                }

            //                if (entry.typeName == "Interception")
            //                {

            //                }

            //                if (entry.typeName == "Clearance")
            //                {

            //                }

            //                if (entry.typeName == "Block")
            //                {

            //                }
            //            }

            //            else
            //            {
            //                //if (entry.typeName == "Pass")
            //                //{
            //                //    Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
            //                //    Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.passEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.passEndLocY) * ratioY));
            //                //    g.DrawLine(chelsea, startPoint, endPoint);
            //                //    DrawArrow(g, chelsea, endPoint, startPoint, 10);

            //                //}

            //                //if (entry.typeName == "Carry")
            //                //{
            //                //    Point startPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.locationX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.locationY) * ratioY));
            //                //    Point endPoint = new Point(Convert.ToInt32(Convert.ToDouble(entry.carryEndLocX) * ratioX), Convert.ToInt32(Convert.ToDouble(entry.carryEngLocY) * ratioY));
            //                //    g.DrawLine(chelseaDash, startPoint, endPoint);

            //                //    DrawArrow(g, chelsea, endPoint, startPoint, 10);
            //                //}

            //                //if (entry.typeName == "Shot")
            //                //{

            //                //}

            //                if (entry.typeName == "Interception")
            //                {

            //                }

            //                if (entry.typeName == "Clearance")
            //                {

            //                }

            //                if (entry.typeName == "Block")
            //                {

            //                }
            //            }

            //        }

            //        overlayImage.Save(@"C:\Users\Petar\Downloads\CNNImages\test" + counter + ".jpg", ImageFormat.Jpeg);
            //    }

            //}

            #endregion


        }

        private static void DrawArrow(Graphics gr, Pen pen, PointF p1, PointF p2, float length)
        {
            gr.DrawLine(pen, p1, p2);
            float vx = p2.X - p1.X;
            float vy = p2.Y - p1.Y;
            float dist = (float)Math.Sqrt(vx * vx + vy * vy);
            vx /= dist;
            vy /= dist;

            DrawArrowHead(gr, pen, p1, -vx, -vy, length);
        }

        private static void DrawArrowHead(Graphics gr, Pen pen, PointF p, float nx, float ny, float length)
        {
            float ax = length * (-nx - ny);
            float ay = length * (nx - ny);
            PointF[] points =
            {
                new PointF(p.X + ax, p.Y + ay),
                p,
                new PointF(p.X - ay, p.Y + ax)
            };
            gr.DrawLines(pen, points);
        }



    }
}
