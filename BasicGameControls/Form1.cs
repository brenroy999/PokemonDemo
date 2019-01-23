using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicGameControls
{
    public partial class Demo : Form
    {
        bool moving = false;
        bool buttonA = false;

        string direction = "down";
        string leftRight = "left";
        string npcDirect = "down";

        bool idle = true;

        int x = 0;

        Rectangle player = new Rectangle(17, 33, 16, 16);
        Rectangle wall_left = new Rectangle(0, 0, 16, 160);
        Rectangle wall_right = new Rectangle(224, 0, 16, 160);
        Rectangle wall_top_l = new Rectangle(0, 0, 112, 32);
        Rectangle wall_top_r = new Rectangle(129, 0, 112, 32);
        Rectangle wall_bottom = new Rectangle(0, 160, 240, 16);
        Rectangle npc_body = new Rectangle(113, 81, 16, 16);
        Rectangle npc_act_updwn = new Rectangle(113, 80, 16, 18);
        Rectangle npc_act_leftright = new Rectangle(112, 81, 18, 16);

        public Demo()
        {
            InitializeComponent();
            gameTimer.Enabled = true;
        }

        private void Collider()
        {
            if (player.IntersectsWith(wall_left) |
                player.IntersectsWith(wall_right) |
                player.IntersectsWith(wall_top_l) |
                player.IntersectsWith(wall_top_r) |
                player.IntersectsWith(wall_bottom) |
                player.IntersectsWith(npc_body))
            {
                switch (direction)
                {
                    case "up":
                        {
                            player.Y = player.Y + 1;
                        }
                        break;
                    case "down":
                        {
                            player.Y = player.Y - 1;
                        }
                        break;
                    case "left":
                        {
                            player.X = player.X + 1;
                        }
                        break;
                    case "right":
                        {
                            player.X = player.X - 1;
                        }
                        break;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!moving)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        {
                            direction = "up";
                            moving = true;
                        }
                        break;
                    case Keys.A:
                        {
                            direction = "left";
                            moving = true;
                        }
                        break;
                    case Keys.S:
                        {
                            direction = "down";
                            moving = true;
                        }
                        break;
                    case Keys.D:
                        {
                            direction = "right";
                            moving = true;
                        }
                        break;
                    case Keys.Enter:
                        {
                            buttonA = true;
                        }
                        break;
                }
            }
            else
            {
                buttonA = false;
            }

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (moving)
            {
                switch (direction)
                {
                    case "down":
                        if (x < 16)
                        {
                            player.Y = player.Y + 1;
                            x++;
                            Collider();
                        }
                        else
                        {
                            moving = false;
                            x = 0;
                        }
                        break;
                    case "up":
                        if (x < 16)
                        {
                            player.Y = player.Y - 1;
                            x++;
                            Collider();
                        }
                        else
                        {
                            moving = false;
                            x = 0;
                        }
                        break;
                    case "left":
                        if (x < 16)
                        {
                            player.X = player.X - 1;
                            x++;
                            Collider();
                        }
                        else
                        {
                            moving = false;
                            x = 0;
                        }
                        break;
                    case "right":
                        if (x < 16)
                        {
                            player.X = player.X + 1;
                            x++;
                            Collider();
                        }
                        else
                        {
                            moving = false;
                            x = 0;
                        }
                        break;
                }
                if (x < 8)
                {
                    idle = true;
                }
                else
                {
                    idle = false;
                    if (leftRight == "left")
                    {
                        leftRight = "right";
                    }
                    else
                    {
                        leftRight = "left";
                    }
                }
            }
            //           if (!moving)
            {
                if (player.IntersectsWith(npc_act_updwn) |
                player.IntersectsWith(npc_act_leftright))
                {
                    if (buttonA == true)
                    {
                        buttonA = false;
                        Battle b = new Battle();
                        b.Show();
                        if (direction == "right")
                        {
                            npcDirect = "left";
                        }
                        if (direction == "left")
                        {
                            npcDirect = "right";
                        }
                        if (direction == "down")
                        {
                            npcDirect = "up";
                        }
                        if (direction == "up")
                        {
                            npcDirect = "down";
                        }
                    }
                }
            }
            Refresh();
        }

        private void Demo_Paint(object sender, PaintEventArgs e)
        {
            switch (npcDirect)
            {
                case "down":
                    {
                        e.Graphics.DrawImage(Properties.Resources.npc_f, 113, 74, 14, 22);
                    }
                    break;
                case "up":
                    {
                        e.Graphics.DrawImage(Properties.Resources.npc_b, 113, 74, 14, 22);
                    }
                    break;
                case "left":
                    {
                        e.Graphics.DrawImage(Properties.Resources.npc_l, 113, 74, 14, 22);
                    }
                    break;
                case "right":
                    {
                        e.Graphics.DrawImage(Properties.Resources.npc_r, 113, 74, 14, 22);
                    }
                    break;
            }

            switch (direction)
            {
                case "down":
                    if (idle)
                    {
                        e.Graphics.DrawImage(Properties.Resources.idle_front, player.X, player.Y - 7, 14, 22);
                    }
                    else
                    {
                        if (leftRight == "left")
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_front_left, player.X, player.Y - 7, 14, 22);
                        }
                        if (leftRight == "right")
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_front_right, player.X, player.Y - 7, 14, 22);
                        }
                    }
                    break;
                case "up":
                    if (idle)
                    {
                        e.Graphics.DrawImage(Properties.Resources.idle_rear, player.X, player.Y - 7, 14, 22);
                    }
                    else
                    {
                        if (leftRight == "left")
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_rear_left, player.X, player.Y - 7, 14, 22);
                        }
                        if (leftRight == "right")
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_rear_right, player.X, player.Y - 7, 14, 22);
                        }
                    }
                    break;
                case "left":
                    if (idle)
                    {
                        e.Graphics.DrawImage(Properties.Resources.idle_side_left, player.X, player.Y - 7, 14, 22);
                    }
                    else
                    {
                        if (leftRight == "left")
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_side_left, player.X, player.Y - 7, 14, 22);
                        }
                        if (leftRight == "right")
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_side_right, player.X, player.Y - 7, 14, 22);
                        }
                    }
                    break;
                case "right":
                    if (idle)
                    {
                        e.Graphics.DrawImage(Properties.Resources.idle_side_right, player.X, player.Y - 7, 14, 22);
                    }
                    else
                    {
                        if (leftRight == "left")
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_sideR_left, player.X, player.Y - 7, 14, 22);
                        }
                        if (leftRight == "right")
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_sideR_right, player.X, player.Y - 7, 14, 22);
                        }
                    }
                    break;
            }
        }

        private void Demo_Load(object sender, EventArgs e)
        {

        }
    }
}