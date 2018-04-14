using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger
{
    public class ScrapCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scrap Cannon");
            Tooltip.SetDefault("A simple hand cannon, uses lead shot");
        }

        public override void SetDefaults()
        {

            item.damage = 18;
            item.ranged = true;
            item.width = 56;
            item.height = 20;
            item.useTime = 45;
            //item.shoot = 10;
            item.shoot = mod.ProjectileType("LeadShotProj");
            item.shootSpeed = 16f;
            item.useAnimation = 45;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 9;
            item.value = 30;
            //item.useAmmo = AmmoID.Arrow;
            item.useAmmo = mod.ItemType("LeadShot");
            item.rare = 3;
            item.UseSound = SoundID.Item14;//14 is explosion sound
            item.autoReuse = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PebbleGun", 1);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PebbleGun", 1);
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}