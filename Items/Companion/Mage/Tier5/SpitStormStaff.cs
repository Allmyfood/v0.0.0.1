using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier5
{
	public class SpitStormStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Spit Storm Staff");
            Tooltip.SetDefault("Call down a barrage of Corrupter spit!");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.magic = true;
            item.melee = false;
			item.mana = 7;
			item.width = 48;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 50;
			item.rare = ItemRarityID.Pink;
			//item.UseSound = SoundID.Item13;
			item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.SpitProj>(); //this is a mod projectile
			item.shootSpeed = 12.75f;
		}
        //-----------------------------------------------StarWrath projectile style----------------------------------------------
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 5 + Main.rand.Next(2);  //This defines how many projectiles to shot
            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-40, 41) * 0.02f;  //this defines the projectile X position speed and randomnes
                float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.02f;  //this defines the projectile Y position speed and randomnes
                Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StormStaff", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}