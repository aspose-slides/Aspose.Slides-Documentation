---
title: SharePoint beállítása az RS szerveren
type: docs
weight: 40
url: /hu/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

Tehát azt kell tennünk, amit a SharePoint WFE‑nél csináltunk. Az első lépés a szükséges előfeltételek telepítése, majd ezt követően a SharePoint beállításának indítása. 

A telepítéshez a Server Farm‑ot választjuk, és teljes telepítést, hogy illeszkedjen a SharePoint dobozomhoz, mivel nem akarunk önálló (standalone) telepítést a SharePoint‑hez. 

{{% /alert %}} 
### **SharePoint konfiguráció**
A SharePoint konfigurációs varázslóban egy meglévő farmhoz szeretnénk csatlakozni. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Figure 13**: SharePoint konfigurációs varázsló 

Ezután a farmunk által használt **SharePoint_Config** adatbázishoz irányítjuk. Ha nem tudod, hol van ez, a Central Admin > **System Settings -> Manager Servers in this farm** menüpontban megtalálhatod. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Figure 14**: SharePoint konfigurációs varázsló 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Figure 15**: SharePoint konfigurációs varázsló 

Miután a varázsló befejeződött, ez egyelőre minden, amit a Report Server gépen meg kell tennünk. Ha visszalépünk a ReportServer URL‑re, egy újabb hibát fogunk látni, ami azért van, mert még nem konfiguráltuk a Central Administratoron keresztül. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Figure 16**: Report Server hiba