[![Version](https://img.shields.io/github/release/RestoreMonarchyPlugins/RPLicenses.svg)](https://github.com/RestoreMonarchyPlugins/RPLicenses/releases) [![Discord](https://discordapp.com/api/guilds/520355060312440853/widget.png)](https://restoremonarchy.com/discord)
# RPLicenses
Simple Vehicle & Gun license plugin for Unturned RP servers.  
Based on DiagonalRPLicenses, but created from scratch.

### Features
* Allows you to require your players to have license for actions, in current version it is driving and carrying guns.
* You may want to limit license requirements only to specific action in `VehicleLicenseEnabled` or `GunLicenseEnabled` parameter.
* Rocket permissions can bypass requirement to have a license in your inventory. So for example if you give `license.gun` to 
a given group in `Permissions.config.xml` then for this group license is not required.  
* You can change items required for licenses and permission names.
* You can set custom color of the messages sent within translations.


### Default Configuration
```xml
<?xml version="1.0" encoding="utf-8"?>
<RPLicensesConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <MessageColor>yellow</MessageColor>
  <VehicleLicenseEnabled>true</VehicleLicenseEnabled>
  <GunLicenseEnabled>true</GunLicenseEnabled>
  <VehicleLicensePermission>license.vehicle</VehicleLicensePermission>
  <GunLicensePermission>license.gun</GunLicensePermission>
  <VehicleLicenseID>1052</VehicleLicenseID>
  <GunLicenseID>1054</GunLicenseID>
</RPLicensesConfiguration>
```

### Default Translations
```xml
<?xml version="1.0" encoding="utf-8"?>
<Translations xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Translation Id="RequireDriveLicense" Value="You must have a driving license to drive vehicle!" />
  <Translation Id="RequireGunLicense" Value="You must have a gun license to carry gun!" />
</Translations>
```
