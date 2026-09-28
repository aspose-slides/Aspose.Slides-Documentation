---
title: Az Aspose.Slides for SharePoint telepítése
type: docs
weight: 10
url: /hu/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Telepítse az Aspose.Slides for SharePoint‑t egy SharePoint farmon: válassza ki a SharePoint verziójának megfelelő telepítőprogramot, futtassa a rendszerellenőrzést, és telepítse valamint aktiválja a megoldást."
---
## **Csomag tartalma**

Az Aspose.Slides for SharePoint a [letöltési oldal](https://releases.aspose.com/slides/sharepoint/)ról ZIP archívumként tölthető le. Az archívum egy SharePoint megoldáscsomagot (WSP) és egy telepítőprogramot tartalmaz minden támogatott SharePoint verzióhoz:

| SharePoint verzió | Telepítőprogram | Megoldáscsomag |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Minden telepítőprogram mellé egy konfigurációs fájl tartozik (például *Setup2019.exe.config*), amely megnevezi a telepítendő megoldáscsomagot. A *License* mappa egy hivatkozást tartalmaz a felhasználói licencszerződésre és a harmadik fél licencmegjegyzéseire.

Az Aspose.Slides for SharePoint egy SharePoint megoldásként van csomagolva, amelyet a SharePoint a szerverfarmon belül telepít. A funkciót ezután egy webhelygyűjteményenként lehet aktiválni vagy deaktiválni.

## **Telepítési folyamat**

A telepítés előtt a telepítőprogram rendszerellenőrzést hajt végre. Ellenőrzi, hogy:

- A SharePoint telepítve van a szerveren.
- A jelenlegi felhasználó rendelkezik a SharePoint megoldások telepítéséhez és telepítéséhez szükséges jogosultságokkal.
- A SharePoint Administration szolgáltatás elindult.
- A SharePoint Timer szolgáltatás elindult.
- A konfigurációs fájlban megadott megoldáscsomag jelen van.

Az Administration és Timer szolgáltatások szükségesek, mert egyes telepítési műveletek időzített feladatként futnak, amelyek a megoldást a farm összes szerverére terjesztik.

### **A telepítés futtatása**

Az Aspose.Slides for SharePoint telepítéséhez:

1. Csomagolja ki a ZIP archívumot egy helyi meghajtóra a SharePoint farm egy szerverén.
2. Futtassa a SharePoint verziójának megfelelő telepítőprogramot (lásd a fenti táblázatot), és kövesse a képernyőn megjelenő utasításokat. A telepítőprogram:
   1. Elvégzi a rendszerellenőrzést. A telepítés nem folytatódik, ha bármely ellenőrzés hibát jelez.

      **Rendszerellenőrzés futtatása**

      ![A telepítőprogram Rendszerellenőrzés képernyője](installing-aspose-slides-for-sharepoint_1.png)

   2. Megjeleníti a felhasználói licencszerződést. Elfogadása szükséges a folytatáshoz.

      **A licencszerződés**

      ![A telepítőprogram licencszerződés képernyője](installing-aspose-slides-for-sharepoint_2.png)

   3. Megjeleníti a telepítési célpontokat. Válassza ki a webalkalmazásokat és webhelygyűjteményeket, amelyekre a funkciót aktiválni kívánja.

      **A telepítési célpontok kiválasztása**

      ![A telepítőprogram Webhelygyűjtemény Telepítési Célpontok képernyője](installing-aspose-slides-for-sharepoint_3.png)

   4. Telepíti a megoldást a farmra.

      **A telepítés állapota**

      ![A telepítőprogram telepítési állapot képernyője](installing-aspose-slides-for-sharepoint_4.png)

   5. Aktiválja az Aspose.Slides for SharePoint funkciót a kiválasztott webhelygyűjteményekben.
   6. Listázza a webalkalmazásokat és webhelygyűjteményeket, ahol a megoldás telepítve és aktiválva lett.

      **Sikeres telepítés**

      ![A telepítőprogram telepítés befejezése képernyője](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
A képernyőképek a SharePoint 2007-en lettek készítve. A későbbi verziók telepítőprogramjai ugyanazokon a képernyőkön haladnak.
{{% /alert %}}

Ha ugyanaz a Aspose.Slides for SharePoint verzió már telepítve van, a telepítőprogram felkínálja annak javítását vagy eltávolítását. Ha másik verzió van telepítve, felkínálja a frissítést vagy eltávolítást.

A telepítés után egy **Convert via Aspose.Slides** elem jelenik meg a kiválasztott webhelygyűjtemények dokumentumtárainak fájllistájában (SharePoint 2007 esetén **Convert with Aspose.Slides**). Az első prezentáció átalakításához lásd a [Converting Microsoft PowerPoint Documents into Other Formats](/slides/hu/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/) cikket. A megoldás farmra telepítésével kapcsolatos részleteket a [Deployment and Activation](/slides/hu/sharepoint/deployment-and-activation/) oldalon találja.

## **GYIK**

**Melyik telepítőprogramot kell futtatnom?**

Az, amelyik neve megegyezik a SharePoint verziójával. Például a *Setup2016.exe* futtatása a SharePoint Server 2016 farmon. Minden telepítőprogram csak a saját megoldáscsomagját telepíti.

**Szükségem van külön letöltésre a licencelt verzióhoz?**

Nem. Ugyanaz a csomag értékelő módban működik, amíg a licencmegoldást nem telepíti; lásd a [Installing Aspose.Slides for SharePoint License](/slides/hu/sharepoint/installing-aspose-slides-for-sharepoint-license/) oldalt.

**Hogyan távolíthatom el a terméket?**

Futtassa újra ugyanazt a telepítőprogramot, és válassza a **Remove** lehetőséget; lásd a [Uninstalling Aspose.Slides for SharePoint](/slides/hu/sharepoint/uninstalling-aspose-slides-for-sharepoint/) oldalt.