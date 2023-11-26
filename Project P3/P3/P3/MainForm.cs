using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        private Font OldFont;
        Font myFont;
        PrivateFontCollection private_fonts = new PrivateFontCollection();
        public MainForm()
		{
			InitializeComponent();
            //BackgroundImage = BackgroundImage = Image.FromFile("D:\\КЭП\\Практика\\P3\\P3\\adf4132c2660e304837035f46c3b0839.gif");
            //ImageAnimator.Animate(BackgroundImage, OnFrameChanged);
            button1.Image = P3.Properties.Resources.SETI1;
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button2.Image = P3.Properties.Resources.SETI1;
            button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button3.Image = P3.Properties.Resources.SETI1;
            button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button4.Image = P3.Properties.Resources.SETI1;
            button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button5.Image = P3.Properties.Resources.SETI1;
            button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button6.Image = P3.Properties.Resources.SETI1;
            button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox1.Image = P3.Properties.Resources.close_inactive;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.Image = P3.Properties.Resources.maximize_inactive;
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox5.Image = P3.Properties.Resources.minimize_inactive;
            pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox5.BackColor = System.Drawing.Color.Transparent;
            LoadFont();
            label1.Font = new Font(private_fonts.Families[0], 18);
            label1.UseCompatibleTextRendering = true;
            button1.Font = new Font(private_fonts.Families[0], 10);
            button1.UseCompatibleTextRendering = true;
            button2.Font = new Font(private_fonts.Families[0], 10);
            button2.UseCompatibleTextRendering = true;
            button3.Font = new Font(private_fonts.Families[0], 10);
            button3.UseCompatibleTextRendering = true;
            button4.Font = new Font(private_fonts.Families[0], 10);
            button4.UseCompatibleTextRendering = true;
            button5.Font = new Font(private_fonts.Families[0], 10);
            button5.UseCompatibleTextRendering = true;
            button6.Font = new Font(private_fonts.Families[0], 10);
            button6.UseCompatibleTextRendering = true;
            pictureBox3.Image = P3.Properties.Resources.icon7_transformed;
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.Icon = Properties.Resources.icon7;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void MainForm_Paint(object sender, PaintEventArgs e) 
        {
            // Нарисуйте границы формы
            DrawBorder(e.Graphics, ClientRectangle);

            // Нарисуйте красные неоновые вставки
            DrawNeonInserts(e.Graphics, ClientRectangle);
        }
        private void DrawBorder(Graphics graphics, Rectangle rectangle) 
        {
            int borderWidth = 2;
            Pen borderPen = new Pen(Color.Black, borderWidth);
            graphics.DrawRectangle(borderPen, rectangle);
            rectangle.Inflate(-borderWidth / 2, -borderWidth / 2);
            borderPen.Color = Color.Red;
            graphics.DrawRectangle(borderPen, rectangle);
        }
        private void DrawNeonInserts(Graphics graphics, Rectangle rectangle) 
        {
            int insetsWidth = 30;
            int insetsHeight = 15;
            Pen insetsPen = new Pen(Color.Red, 2);

            // Верхняя часть вставок
            Rectangle topInsetValue = new Rectangle(rectangle.Left + 30, rectangle.Top + 10, insetsWidth, insetsHeight);
            graphics.DrawArc(insetsPen, topInsetValue, 180, 180);
            graphics.DrawLine(insetsPen, topInsetValue.Left + insetsWidth / 2, topInsetValue.Bottom, topInsetValue.Right - 10, topInsetValue.Bottom);
            graphics.DrawLine(insetsPen, topInsetValue.Left + 10, topInsetValue.Bottom, topInsetValue.Left + insetsWidth / 2, topInsetValue.Bottom + insetsHeight);

            // Нижняя часть вставок
            Rectangle bottomInsetValue = new Rectangle(rectangle.Left + 30, rectangle.Bottom - 25, insetsWidth, insetsHeight);
            graphics.DrawArc(insetsPen, bottomInsetValue, 0, 180);
            graphics.DrawLine(insetsPen, bottomInsetValue.Left + insetsWidth / 2, bottomInsetValue.Top, bottomInsetValue.Right - 10, bottomInsetValue.Top);
            graphics.DrawLine(insetsPen, bottomInsetValue.Left + 10, bottomInsetValue.Top, bottomInsetValue.Left + insetsWidth / 2, bottomInsetValue.Top - insetsHeight);
        }
        protected override void WndProc(ref Message message) 
        {
            if (message.Msg == 0x201) 
            {
                base.Capture = false;
                message = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            }
            base.WndProc(ref message);
        }
        private void LoadFont()
        {
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.SeldomScene_B6lG))
            {
                System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                private_fonts.AddMemoryFont(data, (int)fontStream.Length);
                fontStream.Close();
                Marshal.FreeCoTaskMem(data);
            }
        }
        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }
        void Button1Click(object sender, EventArgs e)
		{
            this.Hide();
            Form_Format f2 = new Form_Format();
            f2.ShowDialog();			
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = P3.Properties.Resources.close_active;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = P3.Properties.Resources.close_inactive;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = P3.Properties.Resources.maximize_active;
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = P3.Properties.Resources.maximize_inactive;
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
        }
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = P3.Properties.Resources.minimize_active;
            pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox5.BackColor = System.Drawing.Color.Transparent;
        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = P3.Properties.Resources.minimize_inactive;
            pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox5.BackColor = System.Drawing.Color.Transparent;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm_Full f1 = new MainForm_Full();
            f1.ShowDialog();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
