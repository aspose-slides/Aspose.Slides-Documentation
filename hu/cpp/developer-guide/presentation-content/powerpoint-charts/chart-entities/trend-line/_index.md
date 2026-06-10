---
title: Trendvonalak hozzáadása a prezentációs diagramokhoz С++-ban
linktitle: Trendvonal
type: docs
url: /hu/cpp/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- С++
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint diagramokban az Aspose.Slides for С++ segítségével — egy gyakorlati útmutató, hogy lebilincselje közönségét."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet trendvonalakat hozzáadni a bemutatódiagramokhoz az Aspose.Slides használatával. Megmutatja, hogyan hozhatunk létre diagramot, hogyan adhatunk trendvonalakat a diagram sorozataihoz, és hogyan dolgozhatunk különböző trendvonal típusokkal, többek között exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány.

Leírja továbbá, hogyan adhatunk egyéni vonalat a diagramhoz egy vonal alakzat beillesztésével, és egy rövid GYIK-ot tartalmaz a trendvonal előre és hátra történő kiterjesztési értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e a PDF vagy SVG formátumba exportáláskor, illetve a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**
Az Aspose.Slides for C++ egyszerű API-t biztosít a különböző diagramtrendvonalak kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg egy dia referenciaját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típus valamelyikével (ebben a példában a ChartType.ClusteredColumn típus van használva).
1. Az exponenciális trendvonal hozzáadása az 1. diagram sorozathoz.
1. A lineáris trendvonal hozzáadása az 1. diagram sorozathoz.
1. A logaritmikus trendvonal hozzáadása a 2. diagram sorozathoz.
1. A mozgó átlag trendvonal hozzáadása a 2. diagram sorozathoz.
1. A polinomiális trendvonal hozzáadása a 3. diagram sorozathoz.
1. A hatvány trendvonal hozzáadása a 3. diagram sorozathoz.
1. Írja a módosított bemutatót egy PPTX fájlba.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Egyéni vonal hozzáadása**
Az Aspose.Slides for C++ egyszerű API-t biztosít egyéni vonalak diagramba történő hozzáadásához. Egy egyszerű, egyenes vonal hozzáadásához a bemutató kiválasztott diájához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze meg egy dia referenciaját az Index használatával
- Hozzon létre egy új diagramot a Shapes objektum által biztosított AddChart metódussal
- Adjon hozzá egy vonal típusú AutoShape-et a Shapes objektum által biztosított AddAutoShape metódussal
- Állítsa be a forma vonalainak színét.
- Írja a módosított bemutatót PPTX fájlként

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **GYIK**

**Mit jelent a trendvonal esetében a 'forward' és a 'backward'?**

Ez a trendvonal előre/hátra kiterjesztett hossza: szórás (XY) diagramok esetén – tengelyegységekben; nem szórás diagramok esetén – a kategóriák számában. Csak nem negatív értékek megengedettek.

**Megmarad a trendvonal a bemutató PDF vagy SVG formátumba exportálásakor, illetve a dia képként történő renderelésekor?**

Igen. Az Aspose.Slides a bemutatókat [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram részei, megmaradnak ezek során. Egy módszer is elérhető a diagram [képének exportálásához](/slides/hu/cpp/create-shape-thumbnails/).