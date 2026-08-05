---
title: "Felhívások kezelése a prezentációs diagramokban C++-val"
linktitle: "Felhívás"
type: docs
url: /hu/cpp/callout/
keywords:
- diagram felhívás
- felhívás használata
- adatcímke
- címke formátuma
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Hozzon létre és formázzon felhívásokat az Aspose.Slides for C++-ban tömör kódrészletekkel, PPT és PPTX kompatibilitással, hogy automatizálja a prezentációs munkafolyamatokat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a felhívásokkal a diagram adatcímkéinél az Aspose.Slides-ben. Megmutatja, hogyan használja a `set_ShowLabelAsDataCallout` metódust a címkék felhívásként való megjelenítéséhez, hogyan állíthatja be a felhívással kapcsolatos címke beállításokat egy fánk diagramhoz, és megjegyzi, hogy a felhívások és megjelenésük megmarad, amikor a prezentációkat PDF, HTML5, SVG és raszteres képfformátumokba exportálják.

## **Felhívások használata**
Új **ShowLabelAsDataCallout** tulajdonság került hozzáadásra a **DataLabelFormat** osztályhoz és az **IDataLabelFormat** interfészhez, amely meghatározza, hogy a megadott diagram adatcímkéje felhívásként vagy adatcímkeként jelenik meg. Az alább bemutatott példában beállítottuk a felhívásokat.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Felhívás beállítása egy fánk diagramhoz**
Az Aspose.Slides for C++ támogatja a sorozat adatcímkéjének felhívás alakjának beállítását egy fánk diagramhoz. Az alábbi minta példa látható.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **GYIK**

**Megmaradnak a felhívások a prezentáció PDF, HTML5, SVG vagy képek formátumba történő konvertálásakor?**

Igen. A felhívások a diagram renderelésének részei, ezért exportáláskor a [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/hu/cpp/export-to-html5/), [SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/) vagy [raszteres képek](/slides/hu/cpp/convert-powerpoint-to-png/) formátumba a diák formázásával együtt megmaradnak.

**Aéni betűtípusok működnek a felhívásokban, és megőrizhető-e a megjelenésük exportáláskor?**

Igen. Az Aspose.Slides támogatja a [betűtípusok beágyazását](/slides/hu/cpp/embedded-font/) a prezentációba, és szabályozza a betűtípus beágyazását az exportáláskor, például a [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/) esetén, biztosítva, hogy a felhívások minden rendszerben egységesen jelenjenek meg.