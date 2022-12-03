using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gameassignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            over.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            coin3.Visible = false;
            coin4.Visible = false;
            label3.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            movelines(gamespeed);
            enemy(gamespeed);
            gameover();
            coins(gamespeed);
            coinscollection();
        }

        int collectedcoins = 0;
        Random r = new Random();
        int x;
        void enemy(int speed)
        {
            if (enemy1.Top >= 550)
            { 
                x = r.Next(0, 212);
                //y = r.Next(0, 450);
                enemy1.Location = new Point(x, 0);
            }
            else { enemy1.Top += speed; }

            if (enemy2.Top >= 550)
            {
                x = r.Next(112,312);
                //y = r.Next(0, 450);
                enemy2.Location = new Point(x, 0);
            }
            else { enemy2.Top += speed; }

            if (enemy3.Top >= 550)
            {
                x = r.Next(212,424);
                //y = r.Next(0, 450);
                enemy3.Location = new Point(x, 0);
            }
            else { enemy3.Top += speed; }
        }

        void coinscollection()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds))
            {
                collectedcoins+=10;
                label2.Text = "Points:" + collectedcoins.ToString();
                x = r.Next(0, 212);
                coin1.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                collectedcoins += 10;
                label2.Text = "Points:" + collectedcoins.ToString();
                x = r.Next(0, 212);
                coin2.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                collectedcoins += 10;
                label2.Text = "Points:" + collectedcoins.ToString();
                x = r.Next(0, 212);
                coin3.Location = new Point(x, 0);

            }

            if (car.Bounds.IntersectsWith(coin4.Bounds))
            {
                collectedcoins += 10;
                label2.Text = "Points:" + collectedcoins.ToString();
                x = r.Next(0, 212);
                coin4.Location = new Point(x, 0);
            }

            if(collectedcoins==500)
            {
                label3.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                timer1.Enabled = false;
            }
        }

        void coins(int speed)
        {
            if (coin1.Top >= 550)
            {
                x = r.Next(0, 212);
                //y = r.Next(0, 450);
                coin1.Location = new Point(x, 0);
            }
            else { coin1.Top += speed; }

            if (coin2.Top >= 550)
            {
                x = r.Next(100, 300);
                //y = r.Next(0, 450);
                coin2.Location = new Point(x, 0);
            }
            else { coin2.Top += speed; }

            if (coin3.Top >= 550)
            {
                x = r.Next(200, 400);
                //y = r.Next(0, 450);
                coin3.Location = new Point(x, 0);
            }
            else { coin3.Top += speed; }

            if (coin4.Top >= 550)
            {
                x = r.Next(300, 424);
                //y = r.Next(0, 450);
                coin4.Location = new Point(x, 0);
            }
            else { coin4.Top += speed; }
        }



        void gameover()
        {
            if(car.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                string Msg = "You Collected  " + collectedcoins/10 + "  Coins and your score is  "+collectedcoins;
                string title = "Collected Coins";
                MessageBox.Show(Msg,title);
            }
            if (car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                string Msg = "You Collected  " + collectedcoins/10 + "  Coins and your score is  " + collectedcoins;
                string title = "Collected Coins";
                MessageBox.Show(Msg, title);
            }
            if (car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                string Msg = "You Collected  " + collectedcoins/10 + "  Coins and your score is  " + collectedcoins;
                string title = "Collected Coins";
                MessageBox.Show(Msg, title);
                
            }
        }
        void movelines(int speed)
        {
            if(pictureBox1.Top>=550)
            { pictureBox1.Top = 0; }
            else { pictureBox1.Top += speed; }

            if (pictureBox2.Top >= 550)
            { pictureBox2.Top = 0; }
            else { pictureBox2.Top += speed; }

            if (pictureBox3.Top >= 550)
            { pictureBox3.Top = 0; }
            else { pictureBox3.Top += speed; }

            if (pictureBox4.Top >= 550)
            { pictureBox4.Top = 0; }
            else { pictureBox4.Top += speed; }

            if (pictureBox5.Top >= 550)
            { pictureBox5.Top = 0; }
            else { pictureBox5.Top += speed; }
        }

        int gamespeed = 0;
        private void Form1_Keydown(object sender, KeyEventArgs e)
        {
           // label1.Text = "";
            if (e.KeyCode == Keys.Left)
            {
                if(car.Left>-5)
                car.Left += -10;
            }
            if (e.KeyCode == Keys.Right)
            {
                if(car.Right<410)
                car.Left += 10;
            }

            if (e.KeyCode == Keys.Up)
            {
                label1.Text = "";
                coin3.Visible = true;
                coin4.Visible = true;
                if (gamespeed<21)
                {
                    gamespeed++;
                    label4.Text = "Speed:" + " " + gamespeed * 10 + "" + "KM/hr";
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if(gamespeed>0)
                {
                    gamespeed--;
                    label4.Text = "Speed:" + " " + gamespeed * 10 + "" + "KM/hr";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
