using Terraria.ID;
using Terraria.ModLoader;
 
namespace MagicalThings.Items.Soda
{
    public class MelonBlast : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Melon Blast Soda"); //In game item name
            Tooltip.SetDefault("Combines Ammo Reservation, Wrath, Regeneration, and Thorns potions"); //Tooltip info
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WormholePotion);
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SodaCan");  //SoundID.Item3;                //this is the sound that plays when you use the item
            item.useStyle = 2;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 16; //20
            item.height = 24; //28
            item.value = 100;                
            item.rare = 1;
            item.buffType = mod.BuffType("MelonBlastBuff");    //this is where you put your Buff name
            item.buffTime = 200000;    //this is the buff duration        20000 = 6 min
            return;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperCoin, 10);
            recipe.AddTile(null, "SodaMachineBox");
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverCoin, 1);
            recipe.AddTile(null, "SodaMachineBox");
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}