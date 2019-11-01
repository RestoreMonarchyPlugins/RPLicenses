using Rocket.API;

namespace RestoreMonarchy.RPLicenses
{
    public class RPLicensesConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public bool VehicleLicenseEnabled { get; set; }
        public bool GunLicenseEnabled { get; set; }
        public string VehicleLicensePermission { get; set; }
        public string GunLicensePermission { get; set; }
        public ushort VehicleLicenseID { get; set; }
        public ushort GunLicenseID { get; set; }

        private readonly string DEFAULT_COLOR = "yellow";
        private readonly bool DEFAULT_VEHICLE_LICENSE_ENABLED = true;
        private readonly bool DEFAULT_GUN_LICENSE_ENABLED = true;
        private readonly string DEFAULT_VEHICLE_LICENSE_PERMISSION = "license.vehicle";
        private readonly string DEFAULT_GUN_LICENSE_PERMISSION = "license.gun";
        private readonly ushort DOLLARS_NOTE_10 = 1052;
        private readonly ushort DOLLARS_NOTE_50 = 1054;

        public void LoadDefaults()
        {
            MessageColor = DEFAULT_COLOR;
            VehicleLicenseEnabled = DEFAULT_VEHICLE_LICENSE_ENABLED;
            GunLicenseEnabled = DEFAULT_GUN_LICENSE_ENABLED;
            VehicleLicensePermission = DEFAULT_VEHICLE_LICENSE_PERMISSION;
            GunLicensePermission = DEFAULT_GUN_LICENSE_PERMISSION;
            VehicleLicenseID = DOLLARS_NOTE_10;
            GunLicenseID = DOLLARS_NOTE_50;
        }
    }
}