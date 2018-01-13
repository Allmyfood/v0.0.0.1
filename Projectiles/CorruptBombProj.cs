﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles
{
    public class CorruptBombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Bomb Explosion");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;   //This defines the hitbox width
            projectile.height = 32;    //This defines the hitbox height
            projectile.aiStyle = 16;  //How the projectile works, 16 is the aistyle Used for: Grenades, Dynamite, Bombs, Sticky Bomb.
            projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 170; //The amount of time the projectile is alive before explode 300 = 5 second fuse
        }



        public override void Kill(int timeLeft)
        {

            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 120;     //this is the explosion radius, the highter is the value the bigger is the explosion

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //this make so the explosion radius is a circle
                    {
                        int type = (int)Main.tile[xPosition, yPosition].type;
                        int wall = (int)Main.tile[xPosition, yPosition].wall;

                        if (wall == 1 || wall == 28 || wall == 61)// || wall == 83) //Stone, Pearl, Cave, Crimstone
                        {
                            Main.tile[xPosition, yPosition].wall = 3;
                            WorldGen.SquareWallFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                            if ((wall > 63 && wall < 65) || wall == 70 ||/* wall == 81 || (wall > 188 && wall < 195) ||*/ (wall > 200 && wall < 203)) //(Grass, Jungle, Flower grass), Hallowed, Crimson grass, Corrupt 1-4 - Crimson 1-4, Hallow 1-4
                        {
                                Main.tile[xPosition, yPosition].wall = 69; //Corrupt Grass natural
                                WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                            if (wall == 187 ||/* wall == 221 ||*/ wall ==222) //sandstone, Crimsandstone, Pearlsandstone
                        {
                            Main.tile[xPosition, yPosition].wall = 220; //Ebonsandstone wall
                            WorldGen.SquareWallFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                            if (wall == 216 || /*wall == 218 || */wall == 219) //Hardened sand wall, Hardened Crimsand, Hardened Pearlsand
                        {
                            Main.tile[xPosition, yPosition].wall = 217; //Hardened Ebonsand wall
                            WorldGen.SquareWallFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                        

                    if (type == 1 || type == 117) //|| type == 203) //Stone, Pearlsone, and Crimstone
                    {
                        Main.tile[xPosition, yPosition].type = 25; //Ebonstone block
                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                    }
                        if (type == 2 || type == 109)// || type == 199) //Grass, Hallowed grass, and Crimson grass
                        {
                            Main.tile[xPosition, yPosition].type = 23; //Corrupt Grass block
                            WorldGen.SquareTileFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                            if (type == 53 || type == 116)// || type == 234) //Sand, Pearlsand, and Crimsand
                            {
                                Main.tile[xPosition, yPosition].type = 112; //EbonSand
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                            if (type == 396 ||/* type == 401 ||*/ type == 403) //Sandstone, Crimsandstone, and Pearlsandstone
                        {
                            Main.tile[xPosition, yPosition].type = 400; //EbonSandstone Block
                            WorldGen.SquareTileFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                            if (type == 397 ||/* type == 399 ||*/ type == 402) //Hardened Sand, Crimsand, and Pearlsand
                        {
                            Main.tile[xPosition, yPosition].type = 398; //Hardened EbonSand Block
                            WorldGen.SquareTileFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                            if (type == 161 || type == 164)// || type == 200) //Ice block, Pink, and Red ice blocks
                        {
                            Main.tile[xPosition, yPosition].type = 163; //Purple Ice block
                            WorldGen.SquareTileFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                            //WorldGen.KillTile(xPosition, yPosition, false, false, false);  //this make the explosion destroy tiles  
                            Dust.NewDust(position, 144, 144, DustID.Smoke, -3.0f, -3.0f, 120, new Color(), 1f);  //this is the dust that will spawn after the explosion
                        }
                    }
                }
            }
        }
    }