using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Money_Management
{
    class Transformation
    {
        public static void TransformSize(Form frm, int newWidth, int newHeight)
        {
            TransformSize(frm, new Size(newWidth, newHeight));
        }

        public static void TransformSize(Form frm, Size newSize)
        {
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(RunTransformation);
            Thread transformThread = new Thread(threadStart);

            transformThread.Start(new object[] { frm, newSize });
        }

        private delegate void RunTransformationDelegate(object paramaters);
        private static void RunTransformation(object parameters)
        {
            Form frm = (Form)((object[])parameters)[0];
            if (frm.InvokeRequired)
            {
                RunTransformationDelegate del = new RunTransformationDelegate(RunTransformation);
                frm.Invoke(del, parameters);
            }
            else
            {
                //Animation variables
                double FPS = 100.0;
                long interval = (long)(Stopwatch.Frequency / FPS);
                long ticks1 = 0;
                long ticks2 = 0;

                //Dimension transform variables
                Size size = (Size)((object[])parameters)[1];

                int xDiff = Math.Abs(frm.Width - size.Width);
                int yDiff = Math.Abs(frm.Height - size.Height);

                int step = 10;

                int xDirection = frm.Width < size.Width ? 1 : -1;
                int yDirection = frm.Height < size.Height ? 1 : -1;

                int xStep = step * xDirection;
                int yStep = step * yDirection;

                bool widthOff = IsWidthOff(frm.Width, size.Width, xStep);
                bool heightOff = IsHeightOff(frm.Height, size.Height, yStep);


                while (widthOff || heightOff)
                {
                    //Get current timestamp
                    ticks2 = Stopwatch.GetTimestamp();

                    if (ticks2 >= ticks1 + interval) //only run logic if enough time has passed "between frames"
                    {
                        //Adjust the Form dimensions
                        if (widthOff)
                            frm.Width += xStep;

                        if (heightOff)
                            frm.Height += yStep;

                        widthOff = IsWidthOff(frm.Width, size.Width, xStep);
                        heightOff = IsHeightOff(frm.Height, size.Height, yStep);

                        //Allows the Form to refresh
                        Application.DoEvents();

                        //Save current timestamp
                        ticks1 = Stopwatch.GetTimestamp();
                    }

                    Thread.Sleep(1);
                }

            }
        }

        private static bool IsWidthOff(int currentWidth, int targetWidth, int step)
        {
            //Do avoid uneven jumps, do not change the width if it is
            //within the step amount
            if (Math.Abs(currentWidth - targetWidth) <= Math.Abs(step)) return false;

            return (step > 0 && currentWidth < targetWidth) || //increasing direction - keep going if still too small
                   (step < 0 && currentWidth > targetWidth); //decreasing direction - keep going if still too large
        }

        private static bool IsHeightOff(int currentHeight, int targetHeight, int step)
        {
            //Do avoid uneven jumps, do not change the height if it is
            //within the step amount
            if (Math.Abs(currentHeight - targetHeight) <= Math.Abs(step)) return false;

            return (step > 0 && currentHeight < targetHeight) || //increasing direction - keep going if still too small
                   (step < 0 && currentHeight > targetHeight); //decreasing direction - keep going if still too large
        }
    }
}
