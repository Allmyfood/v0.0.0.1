using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Warrior
{
	public class SlimeLeashProj : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 40;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.penetrate = -1; // Penetrates NPCs infinitely.
			projectile.melee = true; // Deals melee dmg.

			projectile.aiStyle = 15; // Set the aiStyle to that of a flail.
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Leash");

		}
        //Adds Dust to the Ball at the end
//		public override void AI()
//		{
//			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
//			Main.dust[dust].noGravity = true;
//		}
        //Adds buff to hit
//		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
//		{
//			if (Main.rand.NextBool(3))
//			{
//				target.AddBuff(44, 280, false);
//			}
//		}
        //Adds pvp buff
//		public override void OnHitPvp(Player target, int damage, bool crit)
//		{
//			if (Main.rand.NextBool(3))
//			{
//				target.AddBuff(44, 280, false);
//			}
//		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = ModContent.GetTexture("MagicalThings/Projectiles/CompanionProj/Warrior/SlimeLeash_Chain");

			Vector2 position = projectile.Center;
			Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
			Rectangle? sourceRectangle = new Rectangle?();
			Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
			float num1 = texture.Height;
			Vector2 vector2_4 = mountedCenter - position;
			float rotation = (float)Math.Atan2(vector2_4.Y, vector2_4.X) - 1.57f;
			bool flag = true;
			if (float.IsNaN(position.X) && float.IsNaN(position.Y))
				flag = false;
			if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
				flag = false;
			while (flag)
			{
				if (vector2_4.Length() < num1 + 1.0)
				{
					flag = false;
				}
				else
				{
					Vector2 vector2_1 = vector2_4;
					vector2_1.Normalize();
					position += vector2_1 * num1;
					vector2_4 = mountedCenter - position;
					Color color2 = Lighting.GetColor((int)position.X / 16, (int)(position.Y / 16.0));
					color2 = projectile.GetAlpha(color2);
					Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
				}
			}

			return true;
		}
	}
}
