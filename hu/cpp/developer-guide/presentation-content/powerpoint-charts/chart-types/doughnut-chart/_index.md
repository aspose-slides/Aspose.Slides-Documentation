---
title: Gyűrűdiagramok testreszabása prezentációkban C++ használatával
linktitle: Gyűrűdiagram
type: docs
weight: 30
url: /hu/cpp/doughnut-chart/
keywords:
- gyűrűdiagram
- középső rés
- lyuk mérete
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat gyűrűdiagramokat az Aspose.Slides for C++-ban, támogatva a PowerPoint formátumokat dinamikus prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk gyűrűdiagrammal az Aspose.Slides-ban a diagram diára helyezésével, a középső lyuk méretének beállításával és a prezentáció mentésével. A `set_DoughnutHoleSize` metódusra összpontosít, és bemutatja a kódon belül ennek a diagramtípusnak az egyéni testreszabásához szükséges alapvető lépéseket.

## **Gyűrűdiagram középső lyukának megadása**
A gyűrűdiagram lyukjának méretének megadásához kövesse az alábbi lépéseket:

- Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályt.
- Adjon hozzá gyűrűdiagramot a diára.
- Adja meg a gyűrűdiagram lyukjának méretét.
- Írja a prezentációt a lemezre.

Az alább bemutatott példában beállítottuk a gyűrűdiagram lyukjának méretét.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **GYIK**

**Létrehozhatok több szintű gyűrűdiagramot több gyűrűvel?**

Igen. Több sorozatot adhat egyetlen gyűrűdiagramhoz – minden sorozat külön gyűrűvé válik. A gyűrűk sorrendje a sorozatok gyűjteményben való sorrendjétől függ.

**Támogatott a „szétrobbanó” gyűrűdiagram (különálló szeletek)?**

Igen. Létezik egy Exploded Doughnut [chart type](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) típus, és egy robbanás tulajdonság az adatpontokon; egyes szeleteket szétvághat.

**Hogyan szerezhetek képet egy gyűrűdiagramról (PNG/SVG) jelentéshez?**

A diagram egy alakzat; renderelhető egy [raster image](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) vagy exportálható egy [SVG image](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/writeassvg/) képként.