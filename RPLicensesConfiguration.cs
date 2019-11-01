using Rocket.API;

namespace RestoreMonarchy.RPLicenses
{
    public class RPLicensesConfiguration : IRocketPluginConfiguration
    {
        public ushort VehicleLicenseID { get; set; }
        public ushort GunLicenseID { get; set; }

        public void LoadDefaults()
        {

        }
    }
}