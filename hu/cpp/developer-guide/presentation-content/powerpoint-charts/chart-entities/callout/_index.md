---
title: Felhívások kezelése prezentációs diagramokban C++ használatával
linktitle: Felhívás
type: docs
url: /hu/cpp/callout/
keywords:
- diagram felhívás
- felhívás használata
- adatcímke
- címkeformátum
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Hozzon létre és formázzon felhívásokat az Aspose.Slides for C++-ban tömör kódrészletekkel, amelyek kompatibilisek a PPT és PPTX formátumokkal a prezentációs munkafolyamatok automatizálásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk felhívásokkal (callouts) a diagram adatcímkéiben az Aspose.Slides segítségével. Megmutatja, hogyan használható a `set_ShowLabelAsDataCallout` metódus a címkék felhívásként való megjelenítéséhez, hogyan konfigurálhatók a felhívással kapcsolatos címke beállítások egy gyűrűdiagram esetén, valamint azt, hogy a felhívások és megjelenésük megmaradnak, amikor a prezentációkat PDF, HTML5, SVG és raszteres képformátumokra exportálják.

## **Feliratok használata**
Új **ShowLabelAsDataCallout** tulajdonság került hozzáadásra a **DataLabelFormat** osztályhoz és az **IDataLabelFormat** interfészhez, amely meghatározza, hogy a megadott diagram adatcímkéje felhívásként vagy adatcímkeként jelenik meg. Az alábbi példában a felhívásokat állítottuk be.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Felirat beállítása gyűrűdiagramhoz**
Az Aspose.Slides for C++ támogatja a sorozat adatcímkéjének felhívás alakjának beállítását egy Gyűrűdiagram esetén. Az alábbi példát tekintse meg.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **GYIK**

**Megmaradnak-e a feliratok, ha a prezentációt PDF-re, HTML5-re, SVG-re vagy képekre konvertálják?**

Igen. A felhívások a diagram renderelésének részei, ezért amikor a [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/hu/cpp/export-to-html5/), [SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/) vagy [raszteres képek](/slides/hu/cpp/convert-powerpoint-to-png/) formátumba exportál, a felhívások a dia formázásával együtt megmaradnak.

**Működnek-e egyedi betűtípusok a felhívásokban, és megőrizhető-e a megjelenésük exportáláskor?**

Igen. Az Aspose.Slides támogatja a [betűtípusok beágyazását](/slides/hu/cpp/embedded-font/) a prezentációba, illetve szabályozza a betűtípus-beágyazást az olyan exportoknál, mint a [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), biztosítva, hogy a felhívások ugyanúgy nézzenek ki különböző rendszereken.