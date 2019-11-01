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
using Rocket.API;

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
            UnturnedPlayer player = UnturnedPlayer.FromPlayer(equipment.player);
            if (asset.type == EItemType.GUN && !this.CanPlayerEquipGun(player))
            {
                shouldAllow = false;
                UnturnedChat.Say(player, Translate("RequireGunLicense"), MessageColor);
            }
        }

        private void OnPlayerUpdateStance(UnturnedPlayer player, byte stance)
        {
            if (stance == (byte)EPlayerStance.DRIVING && !this.CanPlayerDrive(player))
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
            { "RequireDriveLicense", "You must have a driving license to drive vehicle!" },
            { "RequireGunLicense", "You must have a gun license to carry gun!" }
        };
    }
}
