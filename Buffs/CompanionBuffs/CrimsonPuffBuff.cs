using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class CrimsonPuffBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Crimson Puff");
			Description.SetDefault("A Crimson Puff will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.CrimsonPuffProj>()] > 0)
			{
				modPlayer.CrimsonPuffMinion = true;
			}
			if (!modPlayer.CrimsonPuffMinion)
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