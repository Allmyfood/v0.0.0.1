using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
	public class TaintedBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tainted Bow");
            Tooltip.SetDefault("A corrupted bow" 
                + "\n May sometimes not consume ammo");
        }

        public override void SetDefaults()
		{

			item.damage = 24;
			item.ranged = true;
			item.width = 22;
			item.height = 40;
			item.useTime = 18;
            item.useAnimation = 18;
            item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 10f;			
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2.25f;
			item.value = 50;
			item.rare = ItemRarityID.Pink;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, -1);
        }

        //40% chance not to consume ammo
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .40f;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SlimeBow", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
