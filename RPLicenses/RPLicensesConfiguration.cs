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

        public void LoadDefaults()
        {
            MessageColor = "yellow";
            VehicleLicenseEnabled = true;
            GunLicenseEnabled = true;
            VehicleLicensePermission = "license.vehicle";
            GunLicensePermission = "license.gun";
            VehicleLicenseID = 1052; // dollar note $10
            GunLicenseID = 1054; // dollar note $50
        }
    }
}