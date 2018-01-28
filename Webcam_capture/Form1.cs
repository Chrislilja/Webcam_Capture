using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webcam_capture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public FilterInfoCollection CamsCollection;
        public VideoCaptureDevice Cam = null;
        public Bitmap currimg;
        CompressionClass CC = new CompressionClass();
        private void button1_Click(object sender, EventArgs e)
        {


            CamsCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

           // MessageBox.Show(Convert.ToString(videoDevices.Count));
           
            Cam = new VideoCaptureDevice(CamsCollection[0].MonikerString);


            Cam = new VideoCaptureDevice(videoDevices[0].MonikerString);
            Cam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);
            Cam.Start();

        }

        private void Cam_NewFrame(object sender,
        NewFrameEventArgs eventArgs)
        {
            
            // get new frame
            currimg = eventArgs.Frame;
            // process the frame
            Image leimage = (Image)eventArgs.Frame.Clone();
            
            pictureBox1.Image = CC.tester(leimage); ;
           // currimg.Dispose();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cam.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
