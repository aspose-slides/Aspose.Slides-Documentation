---
title: Aspose.Slides for SharePoint licenc telepítése
type: docs
weight: 10
url: /hu/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

Miután elégedett a kiértékelésével, megvásárolhat egy licencet[​](https://purchase.aspose.com/buy). Mielőtt vásárolna, győződjön meg arról, hogy megérti és egyetért a licenc előfizetési feltételeivel. A licencet e‑mailben kapja meg, miután a megrendelést kiegyenlítette.

A licenc egy ZIP‑archívum, amely egy hagyományos SharePoint megoldáscsomagot tartalmaz. Az archívum a következőket tartalmaz:

- Aspose.Slides.SharePoint.License.wsp – a SharePoint megoldáscsomag fájlja. A licencet SharePoint megoldásként csomagolják, hogy a telepítés és visszavonás egy szerverfarmon belül egyszerű legyen.
- readme.txt – Licenc telepítési útmutató.

{{% /alert %}} 
## **A licenc telepítése**
A licenc telepítése a szerver konzoljáról, a **stsadm.exe** segítségével történik.

{{% alert color="primary" %}} 

Az útvonalak a következő részben a világosság kedvéért el vannak hagyva.

{{% /alert %}} 

A következő lépéseket kell elvégezni az Aspose.Slides for SharePoint licenc telepítéséhez:

1. Futtassa a stsadm parancsot a megoldás SharePoint megoldástárba való hozzáadásához: 

``` xml
 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp
```

2. Telepítse a megoldást a farm összes szerverére: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Futtassa az adminisztratív időzítő‑állásokat a telepítés azonnali befejezéséhez: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Figyelmeztetést kap a telepítési lépés futtatásakor, ha a Windows SharePoint Services Administration szolgáltatás nem fut. A **stsadm.exe** ennek a szolgáltatásnak és a Windows SharePoint Timer Service‑nek a működésére támaszkodik a megoldásadatok farmon belüli replikálásához. Ha ezek a szolgáltatások nem futnak a szerverfarmon, a licencet minden egyes szerveren külön kell telepíteni. 

{{% /alert %}} 
## **A licenc tesztelése**
A licenc megfelelő telepítésének teszteléséhez konvertáljon bármely dokumentumot egy új formátumba. Ha a dokumentumban nincs értékelő vízjel, a licenc sikeresen aktiválva lett.