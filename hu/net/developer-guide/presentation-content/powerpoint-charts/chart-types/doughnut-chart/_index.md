---
title: Doughnut diagramok testreszabása prezentációkban .NET-ben
linktitle: Doughnut diagram
type: docs
weight: 30
url: /hu/net/doughnut-chart/
keywords:
- doughnut diagram
- középső hézag
- lyuk mérete
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat doughnut diagramokat az Aspose.Slides .NET verziójában, támogatva a PowerPoint formátumokat dinamikus prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben bemutatjuk, hogyan dolgozhat a doughnut diagrammal az Aspose.Slides-ban úgy, hogy a diagramot egy diára helyezzük, beállítjuk a középső lyuk méretét, és mentjük a prezentációt. A `DoughnutHoleSize` beállítást hangsúlyozzuk, és bemutatjuk a diagram típusának testreszabásához szükséges alapvető lépéseket kódban.

Ez tartalmaz egy rövid GYIK-ot, amely a kapcsolódó doughnut-diagram szcenáriókat fedi le, például több sorozat használata több gyűrű létrehozásához, felrobbant doughnut diagramok kezelését, valamint a diagram exportálását raszteres képként vagy SVG-ként.

## **A középső rés meghatározása egy doughnut diagramon**
A doughnut diagram lyukméretének megadásához kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályt.
- Adjon hozzá egy doughnut diagramot a diára.
- Adja meg a lyuk méretét a doughnut diagramon.
- Írja a prezentációt a lemezre.

Az alábbi példában beállítottuk a lyuk méretét a doughnut diagramon.

```c#
// Hozzon létre egy példányt a Presentation osztályból
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Mentse a prezentációt a lemezre
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Létrehozhatok több szintű doughnut diagramot több gyűrűvel?**

Igen. Több sorozatot adhat egyetlen doughnut diagramhoz – minden sorozat egy külön gyűrű lesz. A gyűrűk sorrendje a sorozatok a gyűjteményben való elhelyezkedésétől függ.

**Támogatott egy "exploded" (szétvált) doughnut (különálló szeletekkel)?**

Igen. Létezik egy Exploded Doughnut [chart type](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) és egy felrobbantás tulajdonság az adatpontokon; egyes szeleteket szétválaszthat.

**Hogyan szerezhetek képet egy doughnut diagramról (PNG/SVG) egy jelentéshez?**

A diagram egy alakzat; renderelhető egy [raster image](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/) vagy exportálható egy [SVG image](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/writeassvg/) formátumba.