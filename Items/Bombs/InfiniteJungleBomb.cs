﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Bombs
{
    public class InfiniteJungleBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Mudify with Explosions!"
                + "\nWill change Dirt to Mud" + "\nExplodes in a 60 tile radius");
        }
        public override void SetDefaults()
        {
            item.damage = 0;
            item.width = 22;
            item.height = 30;
            item.maxStack = 1;
            item.consumable = false;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(silver: 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ProjectileType<Projectiles.Bombs.JungleBombProj>();
            item.shootSpeed = 5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "JungleBomb", 30);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}