---
title: Reporting Services SharePoint konfiguráció
type: docs
weight: 50
url: /hu/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

Most, hogy a SharePoint telepítve és konfigurálva van az RS kiszolgálón, és az RS beállítása megtörtént a Reporting Services Configuration Managerrel, áttérhetünk a Central Admin konfigurációjára. Az RS 2008 R2 jelentősen leegyszerűsítette ezt a folyamatot. Korábban három lépéses folyamatra volt szükség a működéshez. Most már csak egy lépésre van szükség. 

A Central Administrator webhelyre kell menni, majd a General Application Settings menüpontra. Az alján megtaláljuk a Reporting Services részt. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Ábra 17**: SharePoint konfiguráció 

{{% alert color="primary" %}} 

Kattintson a **Reporting Services Integration** elemre. 

{{% /alert %}} 
## **Webszolgáltatás URL**
Adja meg azt az URL‑t a Report Serverhez, amelyet a Reporting Services Configuration Managerben talált. 
## **Hitelesítési mód**
Válasszon egy hitelesítési módot is. A következő MSDN hivatkozás részletesen bemutatja ezeket. 
[Security Overview for Reporting Services in SharePoint Integrated Mode](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

Röviden, ha a webhelye **Claims Authentication**‑t használ, akkor mindig a Trusted Authentication‑t fogja használni, függetlenül attól, hogy itt mit választ. Ha Windows hitelesítést szeretne átadni, válassza a Windows Authentication‑t. Trusted Authentication esetén a SPUser tokent adjuk át, nem a Windows hitelesítő adatokat. 

Trusted Authentication-t akkor is érdemes használni, ha a Classic Mode webhelyeket NTLM-re konfigurálta, és az RS is NTLM-re van beállítva. A Windows Authentication és az adatforrás átadása esetén Kerberosra van szükség. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Ábra 18**: Reporting Services Integration hitelesítési adatainak beállítása 
## **Funkció aktiválása**
Ez lehetővé teszi a Reporting Services aktiválását az összes webhelygyűjteményben, vagy kiválaszthatja, melyeken kívánja aktiválni. Ez gyakorlatilag azt jelenti, hogy mely webhelyek használhatják a Reporting Services‑t. 
Az aktiválás után a következő ábrát kell látnia. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Ábra 19**: A Reporting Services sikeres integrációja a SharePoint környezettel 

Visszatérve a Report Server URL‑re, amelyet az Ábra 14 mutat, egy hasonló ábrát kell látnunk. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Ábra 20**: A Reporting Services sikeres ellenőrzése a SharePoint környezetben 

{{% alert color="primary" %}} 

Ha a SharePoint webhelye SSL‑re van konfigurálva, nem jelenik meg ebben a listában. Ez egy ismert probléma, és nem jelenti azt, hogy hiba történt. A jelentéseinek továbbra is működniük kell. 

{{% /alert %}} 

Most már készen állunk a Reporting Services használatára a SharePoint 2010‑ben. Az előző verzióhoz hasonlóan a „Site Collection Feature” részben egy funkciót (amely a Reporting Services Integration konfigurálásakor aktiválódik) kapunk. A telepítés három tartalomtípust is hozzáadott a webhelyhez. Az Ábra 21‑ben látható, hogy két tartalomtípust hozzáadtunk egy dokumentumtárhoz, hogy egy egyéni jelentést hozzunk létre, ahogy az Ábra 21‑ben látható. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Ábra 21**: Report Builder 

A **Reporter Builder** egy ActiveX, amelyet a kiszolgálóra le kell tölteni, ahogy az Ábra 22‑ben látható. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Ábra 22**: A Report Builder letöltése és telepítése 

A letöltés befejezése után futtassa a **Report Builder**‑t. Most már készen állunk az első jelentésünk megtervezésére, ahogy az Ábra 23‑ban látható. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Ábra 23**: Report Builder – Új jelentés generálási varázsló 

A jelentés elkészítése után elmenthetjük a dokumentumtárba, amelyet a SharePoint 2010‑hez hoztunk létre. 

A másik tartalomtípust közös kapcsolatként (adatforrásként) kell használni, és a SharePoint dokumentumtárban kell tárolni. Létrehozhat egy dokumentumtárat, hozzáadhatja ezt a tartalomtípust, és ezután a kapcsolatok elérhetők lesznek a jelentések adatforrásának módosításához. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Ábra 24**: Jelentés sikeres exportálása a Report Serverre