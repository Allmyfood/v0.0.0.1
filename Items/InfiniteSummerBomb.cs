﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items            //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class InfiniteSummerBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Greenify with Explosions!"
                + "\nWill change Snow to Dirt and Ice to Stone" + "\nExplodes in a 60 tile radius");
        }
        public override void SetDefaults()
        {
            item.damage = 0;
            item.width = 22;
            item.height = 30;
            item.maxStack = 1;
            item.consumable = false;
            item.useStyle = 1;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(silver: 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ProjectileType<Projectiles.SummerBombProj>();
            item.shootSpeed = 5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SummerBomb", 30);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}