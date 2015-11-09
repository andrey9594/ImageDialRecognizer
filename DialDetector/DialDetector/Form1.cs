using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.Features2D;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.UI;

namespace DialDetector
{
    public partial class Form1 : Form
    {
        String faceFileName = "cascade.xml"; //Каскад детектора

        public System.Drawing.Bitmap BitmapToBlackWhite2(System.Drawing.Bitmap src)
        {
            double treshold = 0.6;

            Bitmap dst = new Bitmap(src.Width, src.Height);

            for (int i = 0; i < src.Width; i++)
            {
                for (int j = 0; j < src.Height; j++)
                {
                    dst.SetPixel(i, j, src.GetPixel(i, j).GetBrightness() < treshold ? System.Drawing.Color.Black : System.Drawing.Color.White);
                }
            }

            return dst;
        }
        
        public Image<Gray, byte> LabelConnectedComponents(Image<Gray, byte> binary, int startLabel)
        {
            Contour<Point> contours = binary.FindContours(
                CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE,
                RETR_TYPE.CV_RETR_CCOMP);

            int count = startLabel;
            for (Contour<Point> cont = contours;
                        cont != null;
                        cont = cont.HNext)
            {
                CvInvoke.cvDrawContours(
                binary,
                cont,
                new MCvScalar(count),
                new MCvScalar(0),
                2,
                -1,
                LINE_TYPE.FOUR_CONNECTED,
                new Point(0, 0));
                ++count;
            }
            return binary;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //Процедура обработки изображения и поика циферблата
        private void button1_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> frame = (Image<Bgr, Byte>)VideoImage.Image; //Полученный кадр
            using (CascadeClassifier dial = new CascadeClassifier(faceFileName)) //Каскад
            using (Image<Gray, Byte> gray = frame.Convert<Gray, Byte>()) //Хаар работает с ЧБ изображением
            {
                //Детектируем
                Rectangle[] facesDetected2 = dial.DetectMultiScale(
                        gray, //Исходное изображение
                        1.1,  //Коэффициент увеличения изображения
                        6,   //Группировка предварительно обнаруженных событий. Чем их меньше, тем больше ложных тревог
                        new Size(5, 5), //Минимальный размер циферблата
                        Size.Empty); //Максимальный размер циферблата
                //Выводим всё найденное
                foreach (Rectangle f in facesDetected2)
                {
                    frame.Draw(f, new Bgr(Color.Blue), 2);
                    VideoImage.Image = frame;
                    //frame.ROI = f;
                    frame.Save("out.bmp");
                    Bitmap bmp = new Bitmap("out.bmp");
                    BitmapToBlackWhite2(bmp).Save("out_black.bmp");

                    LabelConnectedComponents(gray, 0).Save("label.bmp");

                 //   BinaryImage.Image = 
                    //gray.ThresholdAdaptive(new Gray(255), ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C, THRESH.CV_THRESH_OTSU, 5, new Gray(0.03)).Save("another.bmp");
                }
            }
        }
    }
}
