---
title: Trendvonalak hozzáadása a prezentáció diagramjaihoz C++-ban
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
- C++
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint diagramokhoz az Aspose.Slides for C++ segítségével — egy gyakorlati útmutató a közönség bevonásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet trendvonalakat hozzáadni a prezentáció diagramjaihoz az Aspose.Slides használatával. Megmutatja, hogyan kell diagramot létrehozni, trendvonalakat hozzáadni a diagram sorozataihoz, és több trendvonal típussal dolgozni, többek között exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatványvonal.

Leírja továbbá, hogyan lehet egy egyéni vonalat hozzáadni a diagramhoz egy vonal alakzat beszúrásával, és tartalmaz egy rövid GYIK-et a trendvonal előre és hátra kiterjesztett értékeiről, illetve arról, hogy a trendvonalak megmaradnak-e a PDF vagy SVG exportálásakor, valamint a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**
Az Aspose.Slides for C++ egyszerű API‑t biztosít a különböző diagram Trendvonalak kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását a indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típusúval (ebben a példában a ChartType.ClusteredColumn használatos).
1. Exponenciális trendvonal hozzáadása az 1. sorozathoz.
1. Lineáris trendvonal hozzáadása az 1. sorozathoz.
1. Logaritmikus trendvonal hozzáadása a 2. sorozathoz.
1. Mozgó átlag trendvonal hozzáadása a 2. sorozathoz.
1. Polinomiális trendvonal hozzáadása a 3. sorozathoz.
1. Hatványtrendvonal hozzáadása a 3. sorozathoz.
1. Írja a módosított prezentációt egy PPTX fájlba.

Az alábbi kódot használják diagram Trendvonalakkal való létrehozásához.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Egyéni vonal hozzáadása**
Az Aspose.Slides for C++ egyszerű API‑t biztosít egyéni vonalak diagramhoz történő hozzáadásához. Egy egyszerű egyenes vonal hozzáadásához a prezentáció egy kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy Presentation példányt
- Szerezze meg egy dia hivatkozását az Index használatával
- Hozzon létre egy új diagramot a Shapes objektum által biztosított AddChart metódussal
- Adjon hozzá egy Line típusú AutoShape‑t a Shapes objektum által biztosított AddAutoShape metódussal
- Állítsa be a vonal alakzat színét.
- Írja a módosított prezentációt PPTX fájlként

Az alábbi kódot használják diagram Egyéni Vonalakkal való létrehozásához.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **GYIK**

**Mit jelentenek a 'forward' és a 'backward' a trendvonal esetén?**

A trendvonal előre/hátra kiterjesztett hosszát jelentik: szórás (XY) diagramok esetén a tengelyegységekben; nem szórás diagramok esetén a kategóriák számában. Csak nem negatív értékek megengedettek.

**Megmaradnak-e a trendvonalak a prezentáció PDF‑re vagy SVG‑re exportálásakor, illetve a dia képként történő renderelésekor?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram részei, megmaradnak ezeknél a műveleteknél. Egy metódus továbbá elérhető a diagram [kép exportálásához](/slides/hu/cpp/create-shape-thumbnails/).