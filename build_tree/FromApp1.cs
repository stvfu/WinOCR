using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Media;
using Tesseract;

// for screen shot
using System.Drawing.Imaging;


namespace FromApp1
{
     public enum ShowCommands
    {
        Hide = 0,
        ShowNormal = 1,
        ShowMinimized = 2,
        ShowMaximized = 3,
        Maximize = 3,
        ShowNormalNoActivate = 4,
        Show = 5,
        Minimize = 6,
        ShowMinNoActivate = 7,
        ShowNoActivate = 8,
        Restore = 9,
        ShowDefault = 10,
        ForceMinimized = 11
    }
    public class WindowsAPI
    {
        [DllImport("shell32.dll")]
        public static extern IntPtr ShellExecute(
            IntPtr hwnd,
            string lpOperation,
            string lpFile,
            string lpParameters,
            string lpDirectory,
            ShowCommands nShowCmd);
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        load_data _load = new load_data();
        TesseractEngine ocr;
        public void LoadText(string test)
        {
            textBox_A.Text = "trace1\n";

            ocr = new TesseractEngine(@"./tessdata", "eng");

            textBox_A.Text += "trace2\n";
            using (var img = Pix.LoadFromFile(textBox_B.Text))
            {
                using (var page = ocr.Process(img))
                {
                    var text = page.GetText();
                    textBox_A.Text = text;
                    MessageBox.Show("OK", "辨識完成");
                }
            }
        }

        static void _open_png_by_painter()
        {
            try
            {
                // 定義圖片檔案的路徑
                string filePath = "test.png";

                // 使用Process類別來啟動小畫家並開啟圖片
                Process painterProcess = new Process();
                painterProcess.StartInfo.FileName = "mspaint.exe";
                painterProcess.StartInfo.Arguments = filePath;
                painterProcess.Start();

                Console.WriteLine("圖片已經用小畫家開啟。");
            }
            catch (Exception ex)
            {
                Console.WriteLine("無法開啟圖片: " + ex.Message);
            }
        }

        static void _get_full_screen()
        {
            try
            {
                // 定義圖片檔案的路徑
                string filePath = "test.png";

                // 截取全螢幕
                Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics graphics = Graphics.FromImage(screenshot);
                graphics.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
                screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                Console.WriteLine("全螢幕截圖已保存為 " + filePath);

                // 使用Process類別來啟動小畫家並開啟圖片
                Process painterProcess = new Process();
                painterProcess.StartInfo.FileName = "mspaint.exe";
                painterProcess.StartInfo.Arguments = filePath;
                painterProcess.Start();

                Console.WriteLine("圖片已經用小畫家開啟。");
            }
            catch (Exception ex)
            {
                Console.WriteLine("無法截取全螢幕或開啟圖片: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            //int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;

            int x = 0;//Screen.PrimaryScreen.WorkingArea.Width - Screen.PrimaryScreen.WorkingArea.Width;
            int y = 0;//Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Location  = new Point(x, y);
            //string [] label_array = _load.ReadStringArrayFromFile("label.txt");
            //for(int i = 0;i<label_array.Length;i++)
            //{
                //comboBox_title.Items.Add(label_array[i]);
            //}
        }
        private void button_A_Click(Object sender, EventArgs e)
        {
            LoadText("test");
            //MessageBox.Show("OK.", "!!");
        }

        private void button_B_Click(Object sender, EventArgs e)
        {
            _open_png_by_painter();
        }

        private void button_C_Click(Object sender, EventArgs e)
        {
            _get_full_screen();
        }

    }
}
