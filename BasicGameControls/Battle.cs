﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicGameControls
{
    public partial class Battle : Form
    {
        #region Basic Strings
        string menuLoc = "FIGHT";
        string menuState = "Intro";
        string redArrow = "Up";
        string battleJason = "Trainer JASON would like to battle!";
		string moveHero = null;
		string moveFoe = null;
        #endregion

        #region Pokemon Variables
        string heroMon = "N/A";
        int heroHP = 100;
        int movePwrHero = 0;

        string foeMon = "N/A";
        int foeHP = 100;
        int movePwrFoe = 0;
        #endregion

        #region Moving Locations/Animation Variables
        int descLocX = 12;
        int descLocY = 122;
        int moveSlot = 1;
		int moveSlotFoe = 1;
        int throwFrame = 1;
        int throwX = 16;
        int throwXnpc = 146;

		Random randGen = new Random();
        #endregion

        bool buttonA = false;
        bool animation = false;


        public Battle()
        {
            InitializeComponent();
        }

        private void Battle_Seq()
        {

        }

        private void Battle_KeyDown(object sender, KeyEventArgs e)
        {
            if (!animation)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        {
                            if (menuState == "Main")
                            {
                                if (menuLoc == "PKMN")
                                {
                                    menuLoc = "FIGHT";
                                }
                                if (menuLoc == "RUN")
                                {
                                    menuLoc = "BAG";
                                }
                            }
                            if (menuState == "MoveSelect")
                            {
                                if (moveSlot == 2)
                                {
                                    moveSlot = 1;
                                }
                                if (moveSlot == 4)
                                {
                                    moveSlot = 3;
                                }
                            }
                        }
                        break;
                    case Keys.A:
                        {
                            if (menuState == "Main")
                            {
                                if (menuLoc == "BAG")
                                {
                                    menuLoc = "FIGHT";
                                }
                                if (menuLoc == "RUN")
                                {
                                    menuLoc = "PKMN";
                                }
                            }
                            if (menuState == "MoveSelect")
                            {
                                if (moveSlot == 3)
                                {
                                    moveSlot = 1;
                                }
                                if (moveSlot == 4)
                                {
                                    moveSlot = 2;
                                }
                            }
                        }
                        break;
                    case Keys.S:
                        {
                            if (menuState == "Main")
                            {
                                if (menuLoc == "FIGHT")
                                {
                                    menuLoc = "PKMN";
                                }
                                if (menuLoc == "BAG")
                                {
                                    menuLoc = "RUN";
                                }
                            }
                            if (menuState == "MoveSelect")
                            {
                                if (moveSlot == 1)
                                {
                                    moveSlot = 2;
                                }
                                if (moveSlot == 3)
                                {
                                    moveSlot = 4;
                                }
                            }
                        }
                        break;
                    case Keys.D:
                        {
                            if (menuState == "Main")
                            {
                                if (menuLoc == "FIGHT")
                                {
                                    menuLoc = "BAG";
                                }
                                if (menuLoc == "PKMN")
                                {
                                    menuLoc = "RUN";
                                }
                            }
                            if (menuState == "MoveSelect")
                            {
                                if (moveSlot == 1)
                                {
                                    moveSlot = 3;
                                }
                                if (moveSlot == 2)
                                {
                                    moveSlot = 4;
                                }
                            }
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
            switch (menuState)
            {
                case "Intro":
                    {
                        //Arrow movement
                        if (redArrow == "Down")
                        {
                            redArrow = "Up";
                        }

                        else
                        {
                            redArrow = "Down";
                        }

                        if (buttonA == true)
                        {
                            menuState = "PokemonOut";
							buttonA = false;
                        }
                    }
                    break;
                case "PokemonOut":
                    {
                        for (int a = 0; a < 80; a++)
                        {
                            throwXnpc++;
                            Refresh();
                        }

                        foeMon = "EEVEE";

                        for (int a = 0; a < 80; a++)
                        {
                            if (a > 20)
                            {
                                throwFrame = 2;
                            }
                            if (a > 40)
                            {
                                throwFrame = 3;
                            }
                            if (a > 60)
                            {
                                throwFrame = 4;
                            }
                            throwX--;
                            Refresh();
                        }
                        heroMon = "RALTS";

                        menuState = "Main";
                        buttonA = false;
                    }
                    break;
                case "Main":
                    {
                        if (buttonA == true && menuLoc == "FIGHT")
                        {
                            menuState = "MoveSelect";
							buttonA = false;
                        }
                    }
                    break;
                case "MoveSelect":
					{
						switch (moveSlot)
						{
							case 1:
								{
//									if (buttonA == true)
									{
										moveHero = "CONFUSION";
										movePwrHero = 50;
									}
								}
								break;
							case 2:
								{
//									if (buttonA == true)
									{
										moveHero = "RETURN";
										movePwrHero = 40;
									}
								}
								break;

						}
						switch (moveSlotFoe)
						{
							case 1:
								movePwrFoe = 40; //Quick Attack
								break;
							case 2:
								movePwrFoe = 30; //Double Kick
								break;

						}
						if (buttonA == true && moveSlot == 1 || buttonA == true && moveSlot == 2)
						{
							menuState = "Battle";
							buttonA = false;
						}
					}
                    break;
				case "Battle":
					{
						foeHP = foeHP - movePwrHero;
						heroHP = heroHP - movePwrFoe;
					}
					break;
            }
            label1.Text = ""+ foeHP + "\n" + 
						 heroHP + "\n" +
						 menuState + "\n" +
						 moveSlot;
            Refresh();
        }

        private void Battle_Paint(object sender, PaintEventArgs e)
        {
            #region Graphics stuff
            Pen menuSele = new Pen(Color.Red);
            SolidBrush colorDesc = new SolidBrush(Color.White);
            SolidBrush indiColor = new SolidBrush(Color.FromArgb(255, 66, 66, 66));
            SolidBrush shadowDesc = new SolidBrush(Color.FromArgb(255, 107, 89, 115));
            Font menuDesc = new Font("Pokémon Emerald Pro", 12, FontStyle.Regular);
            Font uiFont = new Font("ADMUI3Sm", 7, FontStyle.Regular);
            #endregion

            switch (throwFrame)
            {
                case 1:
                    {
                        e.Graphics.DrawImage(Properties.Resources.back1, throwX, 48, 64, 64);
                    }
                    break;
                case 2:
                    {
                        e.Graphics.DrawImage(Properties.Resources.back2, throwX, 48, 64, 64);
                    }
                    break;
                case 3:
                    {
                        e.Graphics.DrawImage(Properties.Resources.back3, throwX, 48, 64, 64);
                    }
                    break;
                case 4:
                    {
                        e.Graphics.DrawImage(Properties.Resources.back4, throwX, 48, 64, 64);
                    }
                    break;
            }

            switch (menuState)
            {
                case "Intro":
                    {
                        gameTimer.Interval = (160);
                        e.Graphics.DrawImage(Properties.Resources.trainer_bird, throwXnpc, 4, 64, 64);
                        e.Graphics.DrawImage(Properties.Resources.battle_intro, 0, 112, 240, 48);
                        e.Graphics.DrawString(battleJason, menuDesc, shadowDesc, descLocX + 1, descLocY + 1);
                        e.Graphics.DrawString(battleJason, menuDesc, colorDesc, descLocX, descLocY);

                        switch (redArrow)
                        {
                            case "Up":
                                e.Graphics.DrawImage(Properties.Resources.arrow_red, (descLocX + battleJason.Length), descLocY, 12, 12);
                                break;
                            case "Down":
                                e.Graphics.DrawImage(Properties.Resources.arrow_red, (descLocX + battleJason.Length), descLocY + 2, 12, 12);
                                break;
                        }
                    }
                    break;

                case "PokemonOut":
                    {
                        e.Graphics.DrawImage(Properties.Resources.trainer_bird, throwXnpc, 4, 64, 64);
                        e.Graphics.DrawImage(Properties.Resources.battle_intro, 0, 112, 240, 48);
                    }
                    break;

                case "Main":
                    {

                        gameTimer.Interval = (10);
                        e.Graphics.DrawImage(Properties.Resources.battle_main_menu, 0, 112, 240, 48);

                        switch (menuLoc)
                        {
                            case "FIGHT":
                                {
                                    e.Graphics.DrawImage(Properties.Resources.arrow_grey, 126, 123, 12, 12);
                                }
                                break;
                            case "BAG":
                                {
                                    e.Graphics.DrawImage(Properties.Resources.arrow_grey, 182, 123, 12, 12);
                                }
                                break;
                            case "PKMN":
                                {
                                    e.Graphics.DrawImage(Properties.Resources.arrow_grey, 126, 139, 12, 12);
                                }
                                break;
                            case "RUN":
                                {
                                    e.Graphics.DrawImage(Properties.Resources.arrow_grey, 182, 139, 12, 12);
                                }
                                break;
                        }
                    }
                    break;

                case "MoveSelect":
                    {
                        e.Graphics.DrawImage(Properties.Resources.move_select_ralts, 0, 112, 240, 48);

                        switch (moveSlot)
                        {
                            case 1:
                                e.Graphics.DrawImage(Properties.Resources.arrow_grey, 5, 123, 12, 12);
                                break;
                            case 2:
                                e.Graphics.DrawImage(Properties.Resources.arrow_grey, 5, 139, 12, 12);
                                break;
                            case 3:
                                e.Graphics.DrawImage(Properties.Resources.arrow_grey, 77, 123, 12, 12);
                                break;
                            case 4:
                                e.Graphics.DrawImage(Properties.Resources.arrow_grey, 77, 139, 12, 12);
                                break;
                        }
                    }
                    break;
				case "Battle":
					{
						descLocX = 12;
						descLocY = 122;
						e.Graphics.DrawImage(Properties.Resources.battle_intro, 0, 112, 240, 48);
						e.Graphics.DrawString(heroMon + " used " + moveHero + "!", menuDesc, shadowDesc, descLocX + 1, descLocY + 1);
						e.Graphics.DrawString(heroMon + " used " + moveHero + "!", menuDesc, colorDesc, descLocX, descLocY);

						e.Graphics.DrawString(foeMon + " used " + moveFoe + "!", menuDesc, shadowDesc, descLocX + 1, descLocY + 1);
						e.Graphics.DrawString(foeMon + " used " + moveFoe + "!", menuDesc, colorDesc, descLocX, descLocY);
					}
					break;
            }


            if (menuState == "Main" || menuState == "MoveSelect" || menuState == "Battle")
            {
                e.Graphics.DrawImage(Properties.Resources.hero_ui, 128, 73, 106, 40);
                e.Graphics.DrawImage(Properties.Resources.foe_ui, 12, 15, 100, 32);
            }
            if (foeMon == "EEVEE")
            {
                e.Graphics.DrawImage(Properties.Resources.eevee_f, 142, 16, 64, 64);
            }
            if (heroMon == "RALTS")
            {
                e.Graphics.DrawImage(Properties.Resources.ralts_b, 24, 48, 64, 64);
            }
		}
    }
}