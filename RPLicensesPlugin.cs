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
                VehicleManager.onEnterVehicleRequested += OnEnterVehicleRequested;
                VehicleManager.onSwapSeatRequested += OnSwapSeatRequested;
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

        private void OnEnterVehicleRequested(Player player, InteractableVehicle vehicle, ref bool shouldAllow)
        {
            if (vehicle.tryAddPlayer(out byte seat, player) && seat == 0)
            {
                var untPlayer = UnturnedPlayer.FromPlayer(player);
                shouldAllow = this.CanPlayerDrive(untPlayer);
                if (!shouldAllow)
                    UnturnedChat.Say(untPlayer, Translate("RequireDriveLicense"), MessageColor);
            }
        }

        private void OnSwapSeatRequested(Player player, InteractableVehicle vehicle, ref bool shouldAllow, byte fromSeatIndex, ref byte toSeatIndex)
        {
            if (toSeatIndex == 0)
            {
                var untPlayer = UnturnedPlayer.FromPlayer(player);
                shouldAllow = this.CanPlayerDrive(untPlayer);
                if (!shouldAllow)
                    UnturnedChat.Say(untPlayer, Translate("RequireDriveLicense"), MessageColor);
            }            
        }

        protected override void Unload()
        {
            VehicleManager.onEnterVehicleRequested -= OnEnterVehicleRequested;
            VehicleManager.onSwapSeatRequested -= OnSwapSeatRequested;
            U.Events.OnPlayerConnected -= OnPlayerConnected;
            U.Events.OnPlayerDisconnected -= OnPlayerDisconnected;

            Logger.Log($"{Name} has been unloaded!", ConsoleColor.Yellow);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "RequireDriveLicense", "You must have a driving license to drive vehicle!" },
            { "RequireGunLicense", "You must have a gun license to carry gun!" }
        };
    }
}
