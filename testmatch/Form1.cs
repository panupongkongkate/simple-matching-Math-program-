using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.CvEnum;

namespace testmatch
{
    public partial class Form1 : Form
    {
        OpenFileDialog op1 = new OpenFileDialog();
        OpenFileDialog op2 = new OpenFileDialog();
        OpenFileDialog op3 = new OpenFileDialog();
        Image<Bgr, byte> source = null;
        Image<Bgr, byte> template = null;
        Image<Bgr, byte> templatetwo = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (op1.ShowDialog() == DialogResult.OK)
            {
                source = new Image<Bgr, byte>(op1.FileName);
                imageBox4.Image = source;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void imageBox4_Click(object sender, EventArgs e)
        {

        }

        private void imageBox5_Click(object sender, EventArgs e)
        {

        }

        private void imageBox6_Click(object sender, EventArgs e)
        {

        }



        private void button6_Click_1(object sender, EventArgs e)
        {
            int one = 0;
            int two = 0;
            int three = 0;
            bool plus = false;
            bool del = false;
            int sum = 0;

            if ((source != null))
            {
    
                List<Rectangle> keep = new List<Rectangle>();
                Image<Bgr, byte> imageToShow = source.Copy();//ต้องกอป เพื่อเอาไปวาด ตอนถ้าย ๆ

                //-----เลข1---------------------------------------------------------------------
                Image<Bgr, byte> temgplas = new Image<Bgr, byte>("C:\\Users\\57120042\\Desktop\\testmatch\\testmatch\\เลข1.jpg");
                Image<Gray, float> result = source.MatchTemplate(temgplas, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                double[] min, max;
                Point[] point1, point2;
                result.MinMax(out min, out max, out point1, out point2);
                float[,,] match00 = result.Data;
                for (int x = 0; x < match00.GetLength(1); x++)
                {
                    for (int y = 0; y < match00.GetLength(0); y++)
                    {
                        double matchsouce = match00[y, x, 0];
                        if (matchsouce > 0.9)
                        {
                            Rectangle bect = new Rectangle(new Point(x, y), temgplas.Size);
                            imageToShow.Draw(bect, new Bgr(Color.Red), 5);
                            
                            keep.Add(bect);
                            one = 1 ;

                            //MessageBox.Show("come1");
                        }

                    }
                }

                //  imageBox6.Image = imageToShow ; // กอปมาจากข้างบนแล้ววาดเอา
                //-------เลข2----------------------------------------------------------------
                Image<Bgr, byte> temgplas2 = new Image<Bgr, byte>("C:\\Users\\57120042\\Desktop\\testmatch\\testmatch\\เลข2.jpg");
                Image<Gray, float> result2 = source.MatchTemplate(temgplas2, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                double[] min1, max1;
                Point[] point11, point21;
                result.MinMax(out min1, out max1, out point11, out point21);
                float[,,] match001 = result2.Data;
                for (int x = 0; x < match001.GetLength(1); x++)
                {
                    for (int y = 0; y < match001.GetLength(0); y++)
                    {
                        double matchsouce = match001[y, x, 0];
                        if (matchsouce > 0.9)
                        {
                            Rectangle bect = new Rectangle(new Point(x, y), temgplas2.Size);
                            imageToShow.Draw(bect, new Bgr(Color.Red), 5);

                            keep.Add(bect);
                            two = 2;
                            //  MessageBox.Show("come");
                        }

                    }
                }

                //-------------เลข3------------------------------------------------------------------
                Image<Bgr, byte> temgplas3 = new Image<Bgr, byte>("C:\\Users\\57120042\\Desktop\\testmatch\\testmatch\\เลข3.jpg");
                Image<Gray, float> result3 = source.MatchTemplate(temgplas3, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                double[] min2, max2;
                Point[] point12, point22;
                result3.MinMax(out min2, out max2, out point12, out point22);
                float[,,] match002 = result3.Data;
                for (int x = 0; x < match002.GetLength(1); x++)
                {
                    for (int y = 0; y < match002.GetLength(0); y++)
                    {
                        double matchsouce = match002[y, x, 0];
                        if (matchsouce > 0.9)
                        {
                            Rectangle bect = new Rectangle(new Point(x, y), temgplas3.Size);
                            imageToShow.Draw(bect, new Bgr(Color.Red), 5);

                            keep.Add(bect);
                            three = 3; 
                           // MessageBox.Show("come");
                        }

                    }
                }
                //------------บวก-----------------------------------------------------
                Image<Bgr, byte> temgplas4 = new Image<Bgr, byte>("C:\\Users\\57120042\\Desktop\\testmatch\\testmatch\\บวก.jpg");
                Image<Gray, float> result4 = source.MatchTemplate(temgplas4, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                double[] min3, max3;
                Point[] point13, point23;
                result3.MinMax(out min3, out max3, out point13, out point23);
                float[,,] match003 = result4.Data;
                for (int x = 0; x < match003.GetLength(1); x++)
                {
                    for (int y = 0; y < match003.GetLength(0); y++)
                    {
                        double matchsouce = match003[y, x, 0];
                        if (matchsouce > 0.9)
                        {
                            Rectangle bect = new Rectangle(new Point(x, y), temgplas4.Size);
                            imageToShow.Draw(bect, new Bgr(Color.Red), 5);

                            keep.Add(bect);
                            plus = true;
                            //MessageBox.Show("come");
                        }

                    }
                }
                //-------ลบ---------------------------------
                Image<Bgr, byte> temgplas5 = new Image<Bgr, byte>("C:\\Users\\57120042\\Desktop\\testmatch\\testmatch\\ลบ.jpg");
                Image<Gray, float> result5 = source.MatchTemplate(temgplas5, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                double[] min4, max4;
                Point[] point14, point24;
                result3.MinMax(out min4, out max4, out point14, out point24);
                float[,,] match004 = result5.Data;
                for (int x = 0; x < match004.GetLength(1); x++)
                {
                    for (int y = 0; y < match004.GetLength(0); y++)
                    {
                        double matchsouce = match004[y, x, 0];
                        if (matchsouce > 0.9)
                        {
                            Rectangle bect = new Rectangle(new Point(x, y), temgplas5.Size);
                            imageToShow.Draw(bect, new Bgr(Color.Red), 5);

                            keep.Add(bect);
                            del = true ;
                            //MessageBox.Show("come");
                        }

                    }
                }

                //---------การคำนวณ ---------------

 

                imageBox6.Image = imageToShow; // กอปมาจากข้างบนแล้ววาดเอา

                if (plus == true)
                {
                    sum = one + two + three;
                    textBox1.Text = sum.ToString();

                }
                else if (del == true)
                {
                    if(three == 0)
                    {
                        sum =  two - one;
                        textBox1.Text = sum.ToString();

                    }
                    else
                    {
                        sum = three - two - one;
                        textBox1.Text = sum.ToString();

                    }
 


                }
                else
                {
                    MessageBox.Show("ไม่มีการคำนวน");
                    textBox1.Text = "";
                }

            }

 
        }



        private void imageBox7_Click(object sender, EventArgs e)
        {

        }
    }

}









