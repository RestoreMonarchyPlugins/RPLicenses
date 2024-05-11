# RPLicenses
Simple vehicle & gun license plugin for Roleplay servers.

## Workshop (optional)
[2350128257](https://steamcommunity.com/sharedfiles/filedetails/?id=2350128257) - Game4Freak's RP Licenses

## Configuration
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
```xml
<?xml version="1.0" encoding="utf-8"?>
<Translations xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Translation Id="RequireDriveLicense" Value="You must have a driving license to drive vehicle!" />
  <Translation Id="RequireGunLicense" Value="You must have a gun license to carry gun!" />
</Translations>
```
