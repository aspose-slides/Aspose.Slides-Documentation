---
title: Aspose.Slides for SharePoint licenc telepítése
type: docs
weight: 10
url: /hu/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Az Aspose.Slides for SharePoint licenc telepítése egy SharePoint farmra: adja hozzá a licencmegoldást a megoldástárhoz, telepítse, és ellenőrizze, hogy a konvertált fájlok már nem tartalmazzák a kiértékelési vízjelet."
---
{{% alert color="info" title="Note" %}}

Miután elégedett a kiértékelésével, megvásárolhat egy [licencet vásárolni](https://purchase.aspose.com/pricing/slides/hu/sharepoint/). A vásárlás előtt győződjön meg róla, hogy megértette és egyetért a licenc előfizetési feltételeivel. A licencet e‑mailben kapja meg, miután a rendelést kiegyenlítették.

A licenc egy ZIP archívum, amely egy szokásos SharePoint megoldáscsomagot tartalmaz. Az archívum tartalmazza:

- Aspose.Slides.SharePoint.License.wsp – a SharePoint megoldáscsomag fájlja. A licencet SharePoint megoldásként csomagolják, hogy a telepítés és visszavonás a kiszolgáló farmon egyszerű legyen.
- readme.txt – Licenc telepítési útmutató.

{{% /alert %}}

## **A licenc telepítése**

A licenc telepítése a kiszolgáló konzolról történik a **stsadm.exe** segítségével.

{{% alert color="info" title="Note" %}}

Az útvonalak a következő részben az átláthatóság kedvéért el lettek hagyva.

{{% /alert %}}

Hajtsa végre a következő lépéseket az Aspose.Slides for SharePoint licenc telepítéséhez:

1. Futtassa a stsadm-et a megoldás hozzáadásához a SharePoint megoldástárhoz:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Telepítse a megoldást az összes szerveren a farmon:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Hajtsa végre az adminisztratív időzítő feladatokat a telepítés azonnali befejezéséhez:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

Az `addsolution` művelet a megoldásfájl elérési útját várja a `-filename` paraméterben; a `deploysolution` művelet a már a megoldástárban lévő megoldás nevét a `-name` paraméterben.

{{% alert color="info" title="Note" %}}

Figyelmeztetést kap a telepítési lépés futtatásakor, ha a SharePoint Administration szolgáltatás nem fut. A **stsadm.exe** erre a szolgáltatásra és a SharePoint Timer szolgáltatásra támaszkodik a megoldásadatok farmon belüli replikálásához. Ha ezek a szolgáltatások nem futnak a szerver farmon, előfordulhat, hogy a licencet minden egyes szerveren kell telepíteni.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

A SharePoint 2010‑től kezdve a SharePoint Management Shell cmdlet‑ek `Add-SPSolution`, `Install-SPSolution` és `Start-SPAdminJob` a `addsolution`, `deploysolution` és `execadmsvcjobs` műveleteknek felelnek meg. Lásd a [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **A licenc tesztelése**

A licenc helyes telepítésének teszteléséhez konvertáljon bármely prezentációt egy új formátumba. Ha a konvertált fájlban nincs kiértékelési vízjel, a licenc aktív.