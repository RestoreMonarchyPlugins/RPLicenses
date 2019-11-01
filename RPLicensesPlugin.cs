using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace RestoreMonarchy.RPLicenses
{
    public class RPLicensesPlugin : RocketPlugin<RPLicensesConfiguration>
    {
        public Color MessageColor { get; set; }
        protected override void Load()
        {
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, Color.green);
            
            if (Configuration.Instance.VehicleLicenseEnabled)
            {
                UnturnedPlayerEvents.OnPlayerUpdateStance += OnPlayerUpdateStance;
            }            
            if (Configuration.Instance.GunLicenseEnabled)
            {
                U.Events.OnPlayerConnected += OnPlayerConnected;
                U.Events.OnPlayerDisconnected += OnPlayerDisconnected;
            }           

            Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded!", ConsoleColor.Yellow);
        }

        private void OnPlayerConnected(UnturnedPlayer player)
        {
            player.Player.equipment.onEquipRequested += OnEquipRequested;
        }

        private void OnPlayerDisconnected(UnturnedPlayer player)
        {
            player.Player.equipment.onEquipRequested -= OnEquipRequested;
        }

        private void OnEquipRequested(PlayerEquipment equipment, ItemJar jar, ItemAsset asset, ref bool shouldAllow)
        {
            if (asset.type == EItemType.GUN && equipment.player.inventory.has(Configuration.Instance.GunLicenseID) == null)
            {
                shouldAllow = false;
                UnturnedChat.Say(equipment.player.channel.owner.playerID.steamID, Translate("RequireGunLicense"), MessageColor);
            }
        }

        private void OnPlayerUpdateStance(UnturnedPlayer player, byte stance)
        {
            if (stance == (byte)EPlayerStance.DRIVING && player.Inventory.has(Configuration.Instance.VehicleLicenseID) == null)
            {
                if (player.CurrentVehicle.tryRemovePlayer(out byte seat, player.CSteamID, out Vector3 vector, out byte angle))
                {
                    VehicleManager.sendExitVehicle(player.CurrentVehicle, seat, vector, angle, false);
                    UnturnedChat.Say(player, Translate("RequireDriveLicense"), MessageColor);
                }
            }
        }

        protected override void Unload()
        {
            if (Configuration.Instance.VehicleLicenseEnabled)
            {
                UnturnedPlayerEvents.OnPlayerUpdateStance -= OnPlayerUpdateStance;
            }            
            if (Configuration.Instance.GunLicenseEnabled)
            {
                U.Events.OnPlayerConnected -= OnPlayerConnected;
                U.Events.OnPlayerDisconnected -= OnPlayerDisconnected;
            }

            Logger.Log($"{Name} has been unloaded!", ConsoleColor.Yellow);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "RequireDriveLicense", "You must have a license with you to drive vehicle!" },
            { "RequireGunLicense", "You must have a license with you to equip gun!" }
        };
    }
}
