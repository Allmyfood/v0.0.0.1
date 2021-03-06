using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier4
{
    public class SlimeLeash : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Slime Leash");
            Tooltip.SetDefault("Drag your own pet slime around");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.noMelee = true;
            item.channel = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 7;
            item.value = 40;
            item.rare = ItemRarityID.LightRed;
            item.scale = 1.1f;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Warrior.SlimeLeashProj>();
            item.shootSpeed = 13.9f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpikedFlail", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        //public override void MeleeEffects(Player player, Rectangle hitbox)
        //{
        //    if (Main.rand.Next(3) == 0)
        //    {
        //        int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
        //    }
        //}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Dazed, 35);
        }
    }
}