---
title: Csavart diagramok testreszabása előadásokban С++ használatával
linktitle: Csavart diagram
type: docs
weight: 30
url: /hu/cpp/doughnut-chart/
keywords:
- csavart diagram
- középső rés
- lyukméret
- PowerPoint
- prezentáció
- С++
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat csavart diagramokat az Aspose.Slides С++ változatában, támogatva a PowerPoint formátumokat dinamikus előadásokhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk csavart diagrammal az Aspose.Slides‑ben a diagram diára helyezésével, a középső lyuk méretének beállításával, és a bemutató mentésével. A `set_DoughnutHoleSize` metódusra összpontosít, és bemutatja a diagram típus testreszabásához szükséges alapvető lépéseket a kódban.

## **A csavart diagram középső lyukának meghatározása**
A csavart diagram lyukméretének megadásához kövesse az alábbi lépéseket:

- Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt.
- Adjon csavart diagramot a diára.
- Állítsa be a csavart diagram lyukjának méretét.
- Írja ki a bemutatót a lemezre.

Az alább bemutatott példában beállítottuk a csavart diagram lyukjának méretét.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **GYIK**

**Létrehozhatok többszintű csavart több gyűrűvel?**

Igen. Több sorozatot adhat egyetlen csavart diagramhoz – minden sorozat egy külön gyűrűvé válik. A gyűrűk sorrendje a sorozatok kollekcióban felvett sorrendjét követi.

**Támogatott-e a „robbanó” csavart (különálló szeletek)?**

Igen. Létezik egy *Exploded Doughnut* [diagramtípus](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/), valamint egy robbanási tulajdonság az adatpontokon; egyes szeleteket így szét lehet választani.

**Hogyan szerezhetek képet a csavart diagramról (PNG/SVG) egy jelentéshez?**

A diagram egy alakzat; renderelhető egy [raster kép](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) formájában, vagy exportálható egy [SVG kép](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/writeassvg/) formátumba.