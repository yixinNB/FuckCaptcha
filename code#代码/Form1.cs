using OtgNamespace_Otg_excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace FuckCaptcha
{
    public partial class Form1 : Form
    {
        const int version = 1;
        public Form1()
        {
            InitializeComponent();
            string data0 = GetHtmlCode(@"https://nc.cli.im/qrcoderoute/qrcodeRoute?qrcode_route=qr61.cn/oFQTMX/qsDCS8M&password=");
            替换转义字符(ref data0);
            string data = data0;
            int s = data.IndexOf(@"<p>\\#/////系统公告/////S</p>");
            int e = data.IndexOf(@"<p>\\#/////系统公告/////E</p>");
            data = data.Substring(s + 25, e - s - 25);
            while (true)
            {
                s = data.IndexOf(@"<p>");
                if (s == -1) break;
                e = data.IndexOf(@"</p>", s);
                richTextBox1.Text += data.Substring(s + 3, e - s - 3) + "\r\n";
                data = data.Substring(e + 3);
            }
            string[] a = new string[6];
            int nowid = 0;
            data = data0;
            s = data.IndexOf(@"<p>\\#/////系统状态/////S</p>");
            e = data.IndexOf(@"<p>\\#/////系统状态/////E</p>");
            data = data.Substring(s + 25, e - s - 25);
            while (true)
            {
                s = data.IndexOf(@"<p>");
                if (s == -1) break;
                e = data.IndexOf(@"</p>", s);
                a[nowid++] += data.Substring(s + 3, e - (s + 3));
                data = data.Substring(e + 3);
            }
            if (version < int.Parse(a[0])) { MessageBox.Show("当前版本已不再受支持，请更新后使用，详情系统公告"); button_start.Enabled = false; versionLow.Visible = true; }
            if (a[1] != "T") { button_start.Enabled = false; label_1_2.ForeColor = Color.Red; label_1_2.Text = "关闭"; webBrowser2.Url = new Uri(@"http://yixin666.mikecrm.com/9DSjy2y"); }//总服务器
        }
        private string GetHtmlCode(string url)
        {
            string htmlCode;
            HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/4.0";
            webRequest.Timeout = 30000;
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            HttpWebResponse webResponse = (System.Net.HttpWebResponse)webRequest.GetResponse();
            if (webResponse.ContentEncoding.ToLower() == "gzip")
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (var zipStream =
                        new System.IO.Compression.GZipStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
                    {
                        using (StreamReader sr = new System.IO.StreamReader(zipStream, Encoding.UTF8))
                        {
                            htmlCode = sr.ReadToEnd();
                        }
                    }
                }
            }
            else
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(streamReceive, Encoding.UTF8))
                    {
                        htmlCode = sr.ReadToEnd();
                    }
                }
            }
            return htmlCode;
        }
        public void 替换转义字符(ref string data)
        {
            data = data.Replace(@"\'", @"'");
            data = data.Replace(@"abc", @"!!!!!!!!!");
            data = data.Replace("\\\"", "\"");
            data = data.Replace(@"\\", @"\");
            data = data.Replace(@"\/", @"/");
            data = data.Replace(@"&lt;", @"<");
            data = data.Replace(@"&gt;", @">");
            data = data.Replace(@"&nbsp;", @" ");
        }
        private void button_start_Click(object sender, EventArgs e)
        {
            button_start.Visible = false;
            System.Drawing.Rectangle rec = Screen.GetWorkingArea(this);
            int _SH = rec.Height;
            int _SW = rec.Width;

            Fuck _obj_fuck = new Fuck(_SH, _SW);

            int tmp = _obj_fuck._fuck_a();
            if (tmp == -1) { MessageBox.Show("未匹配到验证码大框"); return; }

            tmp = _obj_fuck._fuck_b();
            if (tmp != 0) { MessageBox.Show("未匹配到滑块"); return; }

            _obj_fuck.getTargetData(out int sx, out int ex, out int sy);
            new MoveMouse(sx, ex, sy);
        }
        private void xieyi_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"LICENSE.TXT");
        }
    }
    public class Fuck
    {
        Bitmap _bmp_s;
        Bitmap _bmp_t = new Bitmap(@"target.png");
        int a_sx, a_sy, a_ex, a_ey;
        int b_sx, b_sy, b_ex, b_ey;
        int _r = -100;
        public int targetX;
        int _SH, _SW;
        public Fuck(int _SH, int _SW)
        {
            this._SH = _SH;
            this._SW = _SW;
        }
        public int _fuck_a()
        {
            this.Screenshots(@"screenshots.png");
            _bmp_s = new Bitmap(@"screenshots.png");

            a_sy = (int)Math.Floor((double)this._SH / 100 * 30);
            a_sx = (int)Math.Floor((double)this._SW / 100 * 20);
            a_ey = (int)Math.Floor((double)this._SH / 100 * 85);
            a_ex = (int)Math.Floor((double)this._SW / 100 * 85);
            this.DrawOnScreen(a_sx, a_sy, a_ex, a_ey);


            Color _t_pixelColor = _bmp_t.GetPixel(0, 0);
            byte _t_r = _t_pixelColor.R;
            int target_Width = _bmp_t.Width;
            int target_Height = _bmp_t.Height;

            for (int i = a_sx; i <= a_ex; i++)
            {
                for (int j = a_sy; j <= a_ey; j++)
                {
                    int x = i, y = j;
                    Color pixelColor = _bmp_s.GetPixel(x, y);
                    byte _s_r = pixelColor.R;
                    if (_s_r != _t_r) continue;
                    _r = CheckA(x, y, target_Width, target_Height);
                    if (_r == 0) 
                    {
                        a_sx = i; a_sy = j; a_ex = i + target_Width - 1; a_ey = j + target_Height - 1;
                        this.DrawOnScreen(a_sx, a_sy, a_ex, a_ey);

                        b_sx = i + 55;
                        b_sy = j;
                        b_ex = i + target_Width - 1;
                        b_ey = (int)Math.Floor(j + (target_Height / 3 * 1.7));
                        return 0;
                    }
                }
            }
            return -1;
        }

        bool[,] hsb_b = new bool[4000, 4000];
        public int _fuck_b()
        {
            int _bestAverageB = 100;
            int _h_, _s_, _b_;
            int tmp_b_sx = 0, tmp_b_sy = 0, tmp_b_ex = 0, tmp_b_ey = 0;

            for (int i = b_sy; i <= b_ey; i++)
            {
                for (int j = b_sx; j <= b_ex; j++)
                {
                    Color pixelColor_b = _bmp_s.GetPixel(j, i);
                    RGBtoHSB(pixelColor_b.R, pixelColor_b.G, pixelColor_b.B, out _h_, out _s_, out _b_);
                    if (_b_ <= 50) { hsb_b[j, i] = true; }
                    else { hsb_b[j, i] = false; }
                }
                Console.WriteLine();
            }

            for (int j = b_sy; j <= b_ey; j++)
            {
                int cnt = 0;
                for (int k = b_sx - 50; k <= b_sx + 20; k++)
                {
                    Color _pixelColor = _bmp_s.GetPixel(k, j);
                    RGBtoHSB(_pixelColor.R, _pixelColor.G, _pixelColor.B, out _h_, out _s_, out _b_);
                    if (43 < _h_ && _h_ < 73 && _s_ > 21 && _b_ > 63) cnt++;
                }
                if (cnt < 26) continue;

                for (int i = b_sx; i <= b_ex; i++)
                {
                    if (!hsb_b[i, j]) continue;
                    int _ht = 0, _hb_37 = 0, _hb_38 = 0, _hb_39 = 0, _hb_40 = 0, _sl = 0, _sr_38 = 0, _sr_39 = 0, _sr_40 = 0, _sr_41 = 0, _sr_42 = 0, _sr_43 = 0, _sr_44 = 0;//横着的上下，竖着的左右(top,b?????,left,right)

                    for (int k = 0; k < 40; k++)
                        if (hsb_b[i + k, j]) _ht++;
                    if (_ht < 23) continue;

                    for (int k = 0; k < 36; k++)
                        if (hsb_b[i, j + k]) _sl++;
                    if (_sl < 23) continue;


                    for (int k = 37; k <= 40; k++)
                    {
                        for (int l = 0; l <= 40; l++)
                        {
                            if (hsb_b[i + l, j + k - 1])
                            {
                                switch (k)
                                {
                                    case 37: _hb_37++; break;
                                    case 38: _hb_38++; break;
                                    case 39: _hb_39++; break;
                                    case 40: _hb_40++; break;
                                }
                            }
                        }
                    }
                    for (int k = 38; k <= 44; k++)
                    {
                        for (int l = 0; l <= 36; l++)
                        {
                            if (hsb_b[i + k - 1, j + l])
                            {
                                switch (k)
                                {
                                    case 38: _sr_38++; break;
                                    case 39: _sr_39++; break;
                                    case 40: _sr_40++; break;
                                    case 41: _sr_41++; break;
                                    case 42: _sr_42++; break;
                                    case 43: _sr_43++; break;
                                    case 44: _sr_44++; break;
                                }
                            }
                        }
                    }
                    int _test_startX = i;
                    int _test_startY = j;
                    int _test_endY;
                    int _test_endX;
                    if (_hb_40 > 27) _test_endY = j + 40 - 1;
                    else if (_hb_39 > 27) _test_endY = j + 39 - 1;
                    else if (_hb_38 > 27) _test_endY = j + 38 - 1;
                    else if (_hb_37 > 27) _test_endY = j + 37 - 1;
                    else continue;
                    if (_sr_44 > 23) _test_endX = i + 42 - 1;
                    else if (_sr_43 > 23) _test_endX = i + 41 - 1;
                    else if (_sr_42 > 23) _test_endX = i + 41 - 1;
                    else if (_sr_41 > 23) _test_endX = i + 41 - 1;
                    else if (_sr_40 > 23) _test_endX = i + 40 - 1;
                    else if (_sr_39 > 23) _test_endX = i + 39 - 1;
                    else if (_sr_38 > 23) _test_endX = i + 38 - 1;
                    else continue;

                    int _AverageB = AverageB(_test_startX, _test_startY, _test_endX, _test_endY);
                    if (_AverageB < _bestAverageB)
                    {
                        tmp_b_sx = _test_startX;
                        tmp_b_sy = _test_startY;
                        tmp_b_ex = _test_endX;
                        tmp_b_ey = _test_endY;
                        _bestAverageB = _AverageB;
                    }
                }
            }
            if (_bestAverageB != 100)
            {
                this.DrawOnScreen(tmp_b_sx, tmp_b_sy, tmp_b_ex, tmp_b_ey);
                this.targetX = (int)(tmp_b_sx + tmp_b_ex) / 2; 
                return 0;
            }
            return -1;
        }
        public void getTargetData(out int sx, out int ex, out int sy)
        {
            sx = a_sx + 37;
            ex = targetX;
            sy = a_sy + 202;
        }
        private int AverageB(int _startX, int _startY, int _endX, int _endY)
        {
            Bitmap _bmp_s = new Bitmap(@"screenshots.png");
            int _h, _s, _b;
            int[] _AllB = new int[(_endX - _startX + 1) * (_endY - _startY + 1)];
            for (int i = _startX; i <= _endX; i++)
            {
                for (int j = _startY; j <= _endY; j++)
                {
                    Color _pixelColor = _bmp_s.GetPixel(i, j);
                    RGBtoHSB(_pixelColor.R, _pixelColor.G, _pixelColor.B, out _h, out _s, out _b);
                    _AllB[(i - _startX) * (_endY - _startY + 1) + (j - _startY)] = _b;
                }
            }
            return (int)_AllB.Average();
        }
        public int CheckA(int x, int y, int _Width, int _Height)
        {
            for (int i = 0; i <= _Width - 1; i++)
            {
                for (int j = 0; j <= _Height - 1; j++)
                {
                    Color _t_pixelColor = _bmp_t.GetPixel(i, j);
                    if (_t_pixelColor.A <= 80) continue;
                    byte _t_r = _t_pixelColor.R;

                    Color pixelColor = _bmp_s.GetPixel(x + i, y + j);
                    byte _s_r = pixelColor.R;
                    if (_t_r != _s_r) return -1;
                }
            }
            return 0;
        }
        private void Screenshots(string _filePath)
        {
            Bitmap image = new Bitmap(this._SW - 1, this._SH - 1);
            Graphics imgGraphics = Graphics.FromImage(image);
            imgGraphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(this._SW - 1, this._SH - 1));
            image.Save(_filePath);
        }
        private void Screenshots(int _startW, int _startH, int _endW, int _endH, string _filePath)//包含开始和结束两个像素
        {
            Bitmap image = new Bitmap(_endW - _startW + 1, _endH - _startH + 1);
            Graphics imgGraphics = Graphics.FromImage(image);
            imgGraphics.CopyFromScreen(new Point(_startW, _startH), new Point(0, 0), new Size(_endW - _startW + 1, _endH - _startH + 1));
            image.Save(_filePath);
        }
        private static void RGBtoHSB(int red, int green, int blue, out int _h, out int _s, out int _b)
        {
            double r = ((double)red / 255.0);
            double g = ((double)green / 255.0);
            double b = ((double)blue / 255.0);

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            double hue, sat, bri;

            hue = 0.0;
            if (max == r && g >= b)
            {
                if (max - min == 0) hue = 0.0;
                else hue = 60 * (g - b) / (max - min);
            }
            else if (max == r && g < b) hue = 60 * (g - b) / (max - min) + 360;
            else if (max == g) hue = 60 * (b - r) / (max - min) + 120;
            else if (max == b) hue = 60 * (r - g) / (max - min) + 240;
            sat = (max == 0) ? 0.0 : (1.0 - ((double)min / (double)max));
            bri = max;

            _h = (int)hue;
            _s = (int)(sat * 100);
            _b = (int)(bri * 100);
        }
        private void DrawOnScreen(int _startX, int _startY, int _endX, int _endY, int _time = 1000)
        {
            Rectangle _img = new Rectangle(_startX, _startY, _endX - _startX, _endY - _startY);
            ControlPaint.DrawReversibleFrame(_img, Color.Red, FrameStyle.Thick);
            ControlPaint.DrawReversibleFrame(_img, Color.Red, FrameStyle.Thick);
        }
    }
    class MoveMouse
    {
        Random obj_rand = new Random();
        int _rand;
        Otg_excel obj_excel_A;
        Otg_excel obj_excel_B;
        public MoveMouse(int _startX, int _endX, int _startY)
        {
            int lastFileID = 2;
            int[] a_x = new int[200], a_y = new int[200];
            int A_id = obj_rand.Next(1, lastFileID);
            int B_id = obj_rand.Next(1, lastFileID);
            obj_excel_A = new Otg_excel(@"resource\data\A\" + this.CreateID(A_id, 5) + ".xls");
            obj_excel_B = new Otg_excel(@"resource\data\B\" + this.CreateID(B_id, 5) + ".xls");
            int datanum_A = int.Parse(obj_excel_A.Select(0, 0));
            int datanum_B = int.Parse(obj_excel_B.Select(0, 0));
            int A_lastData_x = int.Parse(obj_excel_A.Select(0, datanum_A + 1 - 1));
            int A_lastData_y = int.Parse(obj_excel_A.Select(1, datanum_A + 1 - 1));
            int B_lastData_x = int.Parse(obj_excel_B.Select(0, datanum_B + 1 - 1));
            int B_lastData_y = int.Parse(obj_excel_B.Select(1, datanum_B + 1 - 1));
            int j = 0;
            for (int i = 1; i < datanum_A + 1; i++, j++)
            {
                a_x[j] = int.Parse(obj_excel_A.Select(0, i));
                a_y[j] = int.Parse(obj_excel_A.Select(1, i));
            }
            for (int i = 1; i <= datanum_B; i++, j++)
            {
                a_x[j] = int.Parse(obj_excel_B.Select(0, i)) + A_lastData_x;
                a_y[j] = int.Parse(obj_excel_B.Select(1, i)) + A_lastData_y;
            }

            int targetLen = _endX - _startX;
            int nowDataNum = datanum_A + datanum_B;
            int nowLen = A_lastData_x + B_lastData_x;
            while (nowLen > targetLen)
            {
                _rand = obj_rand.Next(1, nowDataNum - 1);
                nowLen -= a_x[_rand] - a_x[_rand - 1];
                delArrayData(ref a_x, _rand);
                delArrayData(ref a_y, _rand);
                nowDataNum--;
            }
            while (nowLen < targetLen - 4)
            {
                _rand = obj_rand.Next(1, 4);
                addArrayData(ref a_x, _rand, obj_rand.Next(1, nowDataNum - 1));
                nowLen += _rand;

            }
            if (nowLen < targetLen)
            {
                _rand = obj_rand.Next(1, nowDataNum - 1);
                addArrayData(ref a_x, targetLen - nowLen, obj_rand.Next(1, nowDataNum - 1));
                nowDataNum++;
            }
            SetCursorPos(_startX, _startY);
            mouse_event(0x0002);
            Thread.Sleep(5);
            for (int i = 0; i < nowDataNum - 1; i++)
            {
                SetCursorPos(_startX + a_x[i], _startY + a_y[i]);
                Thread.Sleep(8);
            }
            Thread.Sleep(10);
            mouse_event(0x0004);
        }
        private string CreateID(int id, int _length)
        {
            string _id = id.ToString();
            if (_id.Length > _length) _id = _id.Substring(0, _length);
            else
            {
                int j = _length - _id.Length;
                for (int i = 0; i < j; i++) _id = "0" + _id;
            }
            return _id;
        }
        private void delArrayData(ref int[] arr, int id)
        {
            int data = arr[id] - arr[id - 1];
            for (int i = id; i <= arr.Length - 2; i++)
            {
                arr[i] = arr[i + 1] - data;
            }
        }
        private void addArrayData(ref int[] arr, int add_data, int id)
        {
            for (int i = arr.Length - 1; i >= id; i--)
            {
                arr[i] += add_data;
            }
        }
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);
        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        private static extern int mouse_event(int dwFlags, int dx = 0, int dy = 0, int cButtons = 0, int dwExtraInfo = 0);
    }
}