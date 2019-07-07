using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier7
{
    public class DarkThrow : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 50;
			item.width = 30;
			item.height = 26;
			item.shootSpeed = 32f;
			item.shoot = mod.ProjectileType("DarkThrowProj");
			item.knockBack = 3.75f;
			item.value = 80;
			item.rare = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Throw");
			Tooltip.SetDefault("A shadowy Yo-Yo"
                + "\nMay shoot shadowy crystals");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SkullThrow", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}