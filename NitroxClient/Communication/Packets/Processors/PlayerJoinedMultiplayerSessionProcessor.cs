using System.Collections.Generic;
using System.Linq;
using NitroxClient.Communication.Packets.Processors.Abstract;
using NitroxClient.GameLogic;
using NitroxModel.Packets;
using NitroxModel_Subnautica.DataStructures;

namespace NitroxClient.Communication.Packets.Processors
{
    public class PlayerJoinedMultiplayerSessionProcessor : ClientPacketProcessor<PlayerJoinedMultiplayerSession>
    {
        private readonly PlayerManager playerManager;

        public PlayerJoinedMultiplayerSessionProcessor(PlayerManager playerManager)
        {
            this.playerManager = playerManager;
        }

        public override void Process(PlayerJoinedMultiplayerSession packet)
        {
            List<TechType> techTypes = packet.EquippedTechTypes.Select(techType => techType.ToUnity()).ToList();
            List<Pickupable> items = new List<Pickupable>();

            playerManager.Create(packet.PlayerContext);

            Log.InGame(Language.main.Get("Nitrox_PlayerJoined").Replace("{PLAYER}", packet.PlayerContext.PlayerName));

        }
    }
}
