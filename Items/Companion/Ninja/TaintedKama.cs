using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja
{
	public class TaintedKama : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 24;
			item.melee = false;
            item.thrown = true;
			item.width = 28;
			item.height = 28;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.75f;
			item.value = 50;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.crit += 6;
            item.shoot = ProjectileID.SporeTrap; // ModContent.ProjectileType("InfestedProj");
            item.shootSpeed = 2f;

        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tainted Kama");
			Tooltip.SetDefault("A poisoned kama, strikes like a claw");
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PoisonGlove", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int target = 0;

            if (Main.rand.Next(5) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, target, 0f);
            }
            return false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 100);
        }
    }
}
