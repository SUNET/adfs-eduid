# Instructions for installing and uninstalling the EduID second factor Adapter

### EventLog
Should be created during install, otherwise run:
```PowerShell
New-EventLog -LogName "Application" -Source "EduID"
```
### Config
-OriginIdp, entityId for adfs (http://adfs.xxx.se/adfs/services/trust):
-TargetIdp, entityID for EduID (https://login.idp.eduid.se/idp.xml).
-AuthContextClassRef (https://refeds.org/profile/mfa).
-IdentityClaimName, choose attribute for identification (norEduPersonNIN).
-ProxySp, uri to the sp-proxy used (https://somedomain.se/ProxyWeb/Default/Index).
-CryptoKey, shared secret between Idp and sp-proxy.
-Choose lookup method for civicnumber "UserLookupMethod": "SQL" or "UserLookupMethod": "LDAP"
For sql, multiple connections are available if say staff and guests reside in different databases.

### Copy files to ADFS
Copy files to ADFS server (c:\admin\install\<ADFSEduIDMFA>) 
- ADFSTK.ExternalMFA.AdapterMerged.dll		\bin\<configuration>\ADFSTK.ExternalMFA.AdapterMerged.dll
- ExternalMFASettings.json		
- Newtonsoft.json.dll		
- Install-ADFSEduIDMFA.ps1	\scripts\
- Uninstall-ADFSEduIDMFA.ps1	\scripts\

### Install
- Install with following command:
```PowerShell
Install-ADFSEduIDMFA.ps1 -InstallDirectory "path to folder" -ConfigFile "path to settingsfile <ExternalMFASettings.json>"
```
### Uninstall
- Uninstall with following command:
```PowerShell
Uninstall-ADFSEduIDMFA -InstallDirectory "path to folder"
```


