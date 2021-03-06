using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class BlazingGloryBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Valkyrie");
			Description.SetDefault("A Valkyrie will fight for you" + "\n'Your safety is assured.'");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.ValkyrieProj>()] > 0)
            {
				modPlayer.ValkyrieMinion = true;
			}
            if (!modPlayer.ValkyrieMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}