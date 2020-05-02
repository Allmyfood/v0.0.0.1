﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles
{
    public class AirLavaBombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Remover Bomb Explosion");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 32;
            projectile.aiStyle = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }
        
        public override void Kill(int timeLeft)
        {
            #region Updated WorldGen Convert
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            int radius = 60;
            //float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            //float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 58; i++)
            {
                float speedX = Main.rand.NextFloat(-12, 12);
                float speedY = Main.rand.NextFloat(-10, 10);
                //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX[i], speedY[i], ProjectileID.PureSpray, 0, 0, Main.myPlayer);
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 269, speedX, speedY, 100, new Color(), 1.5f);
            }

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //circle
                    {
                        #region Border Saftey Checks
                        if (xPosition < 0 && yPosition <0)//top left
                        {
                            xPosition = 0;
                            yPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        if ((xPosition >= Main.maxTilesX - 43) && yPosition < 0)//top right
                        {
                            xPosition = Main.maxTilesX - 43;
                            yPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        if (xPosition < 0 && yPosition >= Main.maxTilesY - 43)//bottom left
                        {
                            xPosition = 0;
                            yPosition = Main.maxTilesY - 43;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        if ((xPosition >= Main.maxTilesX - 43) && yPosition >= Main.maxTilesY - 43)//bottom right
                        {
                            xPosition = Main.maxTilesX - 43;
                            yPosition = Main.maxTilesY - 43;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        if (xPosition < 0)//left wall 0x
                        {
                            xPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                            //WorldGen.Convert(xPosition, yPosition, 0, 1); // convert to purity
                        }
                        if (xPosition >= Main.maxTilesX - 43)//right wall MaxX
                        {
                            xPosition = Main.maxTilesX - 43;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        if (yPosition < 0)//Top 0y
                        {
                            yPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        if (yPosition >= Main.maxTilesY - 43)//bottom MaxY
                        {
                            yPosition = Main.maxTilesY - 43;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        #endregion

                        else
                        {
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}