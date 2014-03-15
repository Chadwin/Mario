using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using NetComm;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        // NetComm.Host Server;
        bool right;
        bool left;
        bool jump;
        int G = 30;
        int Force;
       
        public Form1()
        {
            InitializeComponent();

           // block.Top = screen.Height - block.Height; // sets the block starting position
            player.Top = screen.Height - player.Height; // Sets the player starts position
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player.Left + player.Width > block1.Left && player.Left + player.Width < block1.Left + block1.Width + player.Width && player.Top - block1.Bottom <= 10 && player.Top - block1.Top > -10)
            {
                block1.Image = Image.FromFile("Mush.bmp");
                Force = -1;
            }
            if (player.Left + player.Width > block1.Left && player.Left + player.Width < block1.Left + block1.Width + player.Width && player.Top + player.Height >= block1.Top && player.Top < block1.Top)
            {
                player.Height = (72);

                player.Image = Image.FromFile("Large.bmp");
            }
            // Side Collision
            if (player.Right > block.Left && player.Left < block.Right - player.Width  && player.Bottom < block.Bottom && player.Bottom > block.Top )
            {
                right = false;
            }
            if (player.Left < block.Right && player.Right > block.Left + player.Width && player.Bottom < block.Bottom && player.Bottom > block.Top)
            {
                left = false;
            }
            if (player.Right > block1.Left && player.Left < block1.Right - player.Width && player.Bottom < block1.Bottom && player.Bottom > block1.Top)
            {
                right = false;
            }
            if (player.Left < block1.Right && player.Right > block1.Left + player.Width && player.Bottom < block1.Bottom && player.Bottom > block1.Top)
            {
                left = false;
            }

            if (right == true)
            {
                player.Left += 3;
            }
            if (left == true)
            {
                player.Left -= 3;
            }

            if (jump == true)
            {
                // Falling (if the player has jumped before)
                player.Top -= Force;
                Force -= 1;
            }
            if (player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height; // Stop falling at bottom
                if (jump == true)
                {
                    player.Image = Image.FromFile("stand.png");
                }
                jump = false;
            }
            else
            {
                player.Top += 5;  //Falling
            }

            // Top Collision

            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = false;
                Force = 0;
                player.Top = block.Location.Y - player.Height;
            }
            if (player.Left + player.Width > block1.Left && player.Left + player.Width < block1.Left + block1.Width + player.Width && player.Top + player.Height >= block1.Top && player.Top < block1.Top)
            {
                Force = 0;
                player.Top = block1.Location.Y - player.Height;
            
            }
            //Simple fall
            if (!(player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width)&& player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = true;
            }
            // head collision
            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top - block.Bottom <= 10 && player.Top - block.Top > -10)
            {
                Force = -1;
            }
            if (player.Left + player.Width > block1.Left && player.Left + player.Width < block1.Left + block1.Width + player.Width && player.Top - block1.Bottom <= 10 && player.Top - block1.Top > -10)
            {
                block1.Image = Image.FromFile("Mush.bmp");
                Force = -1;
            }
            if (player.Left + player.Width > block1.Left && player.Left + player.Width < block1.Left + block1.Width + player.Width && player.Top + player.Height >= block1.Top && player.Top < block1.Top)
            {
                player.Height =(72);
              
                player.Image = Image.FromFile("Large.bmp");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right)
                
            {
             
                right = true;
                player.Image = Image.FromFile("walk_r.gif");
            }
            if (e.KeyCode == Keys.Left)
               
            {
                left = true;
                player.Image = Image.FromFile("walk_l.gif");
            }
                
            
                
            if (e.KeyCode == Keys.Escape) this.Close(); // Escape = Exit

            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    Force = G;
                    player.Image = Image.FromFile("jump.png");
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
                player.Image = Image.FromFile("stand.png");
            }
            if (e.KeyCode == Keys.Left) 
            {
                left = false; 
                player.Image = Image.FromFile("stand.png");
            }
            if (e.KeyCode == Keys.R) 
            {
                block1.Image = Image.FromFile("123.bmp");
                player.Height = (32);
                player.Width = (35);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          /*  Server = new NetComm.Host(2020); //Initialize the Server object, connection will use the 2020 port number
            Server.StartConnection(); //Starts listening for incoming clients

            //Adding event handling methods, to handle the server messages
            Server.onConnection += new NetComm.Host.onConnectionEventHandler(Server_onConnection);
            Server.lostConnection += new NetComm.Host.lostConnectionEventHandler(Server_lostConnection);
            Server.DataReceived += new NetComm.Host.DataReceivedEventHandler(Server_DataReceived); */
        }
    }
}
