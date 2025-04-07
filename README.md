# RPLicenses

A simple vehicle & gun license plugin for Unturned Roleplay servers. Requires players to have specific items in their inventory to drive vehicles or use guns.

## Features

- Vehicle license system - players need a license to drive vehicles
- Gun license system - players need a license to equip weapons
- Permission-based override for admins/staff
- Customizable messages

## Workshop Resource (optional)

[2350128257](https://steamcommunity.com/sharedfiles/filedetails/?id=2350128257) - Game4Freak's RP Licenses

## Configuration Options

| Option | Description |
|--------|-------------|
| MessageColor | The color of plugin messages shown to players |
| VehicleLicenseEnabled | Enable/disable the vehicle license requirement |
| GunLicenseEnabled | Enable/disable the gun license requirement |
| VehicleLicensePermission | Permission that bypasses the vehicle license requirement |
| GunLicensePermission | Permission that bypasses the gun license requirement |
| VehicleLicenseID | Item ID of the vehicle license (default: 1052 - $10 note) |
| GunLicenseID | Item ID of the gun license (default: 1054 - $50 note) |

## Default Configuration

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

## Translations

You can customize the messages players see when they don't have the required licenses:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Translations xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Translation Id="RequireDriveLicense" Value="You must have a driving license to drive vehicle!" />
  <Translation Id="RequireGunLicense" Value="You must have a gun license to carry gun!" />
</Translations>
```

## How It Works

- Players need to have the license item in their inventory to drive vehicles or use guns
- Staff with the configured permissions can bypass these requirements
- If a player tries to drive without a license, they will receive a message and be denied
- If a player tries to equip a gun without a license, they will receive a message and be denied