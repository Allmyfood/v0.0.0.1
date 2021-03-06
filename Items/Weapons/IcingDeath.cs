using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Weapons
{
    public class IcingDeath : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("An Enchanted Ice Scimitar");
        }
        public override void SetDefaults()
        {
            item.damage = 85;
            item.melee = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 5;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("MagicalThings:Cobalt Bar", 10);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddIngredient(ItemID.IceBlock, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(14) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 67); // mod.DustType("Sparkle"));
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Chilled, 160); //60 is the buff time
        }

    }
}