using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
	public class LeadShot : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Some lead shot");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.ranged = true;
			item.width = 18;                     //projectile size
			item.height = 18;
			item.maxStack = 9999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 9.5f;
			item.value = 30;
			item.rare = ItemRarityID.Orange;
			item.shoot = ProjectileType<Projectiles.CompanionProj.LeadShotProj>();   //The projectile shoot when your weapon using this ammo
			//item.shootSpeed = 16f;                  //The speed of the projectile
            item.ammo = item.type;            //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 50);
			recipe.AddRecipe();
        }
	}
}
