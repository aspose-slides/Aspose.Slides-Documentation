---
title: Telepítési előfeltételek
type: docs
weight: 20
url: /hu/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 

A telepítés folytatása előtt a következő előfeltételeknek kell teljesülniük. 

{{% /alert %}} 
## **Reporting Services Add-In for SharePoint**
A **Reporting Services Add-In for SharePoint** az egyik kulcsfontosságú komponens a megfelelő integráció eléréséhez. A kiegészítőt a SharePoint farmon belül bármely **Web Front Ends (WFE)** szerveren, valamint a Central Admin szerveren kell telepíteni. Az SQL 2008 R2 és a SharePoint 2010 egyik új változása, hogy a 2008 R2 Add-In most már előfeltétel a SharePoint telepítéséhez. Ez azt jelenti, hogy a RS Add-In automatikusan települ, amikor a SharePoint telepítését indítja. Az alábbi ábrán látható és kiemelt. Ez valójában elkerüli a SP 2007 és RS 2008 add‑in telepítése során tapasztalt számos problémát. 

![todo:image_alt_text](installation-prerequisites_1.png)


**Figure 1**: Reporting Services Add-In for SharePoint 
## **SharePoint Authentication**
Mielőtt belevágna az RS integráció részleteibe, fontos egy dolog, hogy hogyan állítja be a **Site**‑ot a SharePoint farmban. Pontosabban, hogyan konfigurálja a site hitelesítését; legyen az **Classic** vagy **Claims**. Ez a választás a kezdetnél fontos. Nem hiszem, hogy ezt a beállítást a későbbiekben meg lehet változtatni. Ha meg lehet változtatni, az nem lenne egyszerű folyamat. 

{{% alert color="primary" %}} 

A Reporting Services 2008 R2 NEM támogatja a Claims‑ot 

{{% /alert %}} 

Még ha a SharePoint site‑ot Claims‑re állítja is, a Reporting Services maga nem támogatja a Claims‑ot. Ez befolyásolja a hitelesítés működését a Reporting Services esetében. Mi a különbség a Reporting Services szemszögéből? Az attól függ, hogy szeretné-e továbbítani a felhasználói hitelesítő adatokat az adatforrásnak. 

***Classic*** – Használhat Kerberos‑t és továbbíthatja a felhasználó hitelesítő adatait a háttér adatforrásnak (ehhez Kerberos szükséges). 

***Claims*** – Claims token használatos, nem Windows token. Ebben a helyzetben az RS mindig Trusted Authentication‑t használ, és csak a SPUser tokenhez fér hozzá. Hitelesítő adatokat az adatforrásban kell tárolnia. 

Egyelőre csak az RS beállítására szeretnénk koncentrálni. Jelenleg a SharePoint a SharePoint Boxon van telepítve, és egy **Classic Auth Site** van beállítva a **80‑as porton**. Emellett a RS szerveren most telepítettem a Reporting Services‑t, és ezzel kész is.