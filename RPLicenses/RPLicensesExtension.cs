using Rocket.API;
using Rocket.Unturned.Player;

namespace RestoreMonarchy.RPLicenses
{
    public static class RPLicensesExtension
    {
        public static bool CanPlayerEquipGun(this RPLicensesPlugin plugin, UnturnedPlayer player)
        {
            return player.Inventory.has(plugin.Configuration.Instance.GunLicenseID) != null || player.HasPermission(plugin.Configuration.Instance.GunLicensePermission);
        }

        public static bool CanPlayerDrive(this RPLicensesPlugin plugin, UnturnedPlayer player)
        {
            return player.Inventory.has(plugin.Configuration.Instance.VehicleLicenseID) != null || player.HasPermission(plugin.Configuration.Instance.VehicleLicensePermission);
        }
    }
}
