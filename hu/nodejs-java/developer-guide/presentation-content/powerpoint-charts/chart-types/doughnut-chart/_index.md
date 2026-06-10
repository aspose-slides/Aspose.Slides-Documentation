---
title: Gyűrűdiagramok testreszabása prezentációkban JavaScript használatával
linktitle: Gyűrűdiagram
type: docs
weight: 30
url: /hu/nodejs-java/doughnut-chart/
keywords:
- gyűrűdiagram
- középső rés
- lyukméret
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan lehet gyűrűdiagramokat létrehozni és testre szabni JavaScript és Aspose.Slides segítségével a Node.js-hez, PowerPoint formátumokat támogató dinamikus prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk egy gyűrűdiagrammal az Aspose.Slides-ban, a diagram diához való hozzáadásával, a középső lyuk méretének beállításával és a prezentáció mentésével. A `setDoughnutHoleSize` metódusra összpontosít, és bemutatja a kódban ennek a diagramtípusnak a testreszabásához szükséges alapvető lépéseket.

Emellett egy rövid GYIK is szerepel, amely a gyűrűdiagramokhoz kapcsolódó helyzeteket tárgyalja, például több sorozat használatát több gyűrű létrehozásához, a felrobbantott gyűrűdiagramokkal való munkát, valamint a diagram rasterkép vagy SVG formátumba való exportálását.

## **Középső rés méretének módosítása a gyűrűdiagramon**

A gyűrűdiagram lyukjának méretének megadásához kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) objektumot.  
1. Adjon hozzá gyűrűdiagramot a diára.  
1. Adja meg a lyuk méretét a gyűrűdiagramon.  
1. Mentse a prezentációt a lemezre.

Az alább bemutatott példában beállítottuk a gyűrűdiagram lyukjának méretét.

```javascript
// Hozzon létre egy Presentation osztály példányt
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Mentse a prezentációt a lemezre
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Létrehozhatok több szintű gyűrűdiagramot több gyűrűvel?**

Igen. Több sorozatot adjon hozzá egyetlen gyűrűdiagramhoz – minden sorozat egy külön gyűrűvé válik. A gyűrűk sorrendje a sorozatok gyűjteményben elfoglalt sorrendjétől függ.

**Támogatott a "felrobbantott" (szétválasztott szeletekkel) gyűrűdiagram?**

Igen. Van egy Exploded Doughnut [chart type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/) és egy robbantási tulajdonság az adatpontokon; egyes szeleteket szétválaszthat.

**Hogyan szerezhetek képet egy gyűrűdiagramról (PNG/SVG) egy jelentéshez?**

A diagram egy alakzat; renderelhető [raster image](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage) formátumba, vagy exportálható [SVG image](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/writeassvg/) formátumba.