---
title: Gyűrűdiagramok testreszabása prezentációkban Java használatával
linktitle: Gyűrűdiagram
type: docs
weight: 30
url: /hu/java/doughnut-chart/
keywords:
- gyűrűdiagram
- középső rés
- lyukméret
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat gyűrűdiagramokat az Aspose.Slides for Java-ban, amelyek támogatják a PowerPoint formátumokat a dinamikus prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk egy gyűrűdiagrammal az Aspose.Slides-ban a diagram diához való hozzáadásával, a középső lyuk méretének beállításával és a bemutató mentésével. A `setDoughnutHoleSize` metódusra összpontosít, és bemutatja a diagramtípus testreszabásához szükséges alapvető lépéseket a kódban.

Egy rövid GYIK is szerepel, amely a kapcsolódó gyűrűdiagram-szituációkat tárgyalja, például több sorozat használatát több gyűrű létrehozásához, a széttört gyűrűdiagramok kezelését, valamint a diagram rasterkép vagy SVG formátumba történő exportálását.

## **Középső lyuk meghatározása egy gyűrűdiagramon**
{{% alert color="primary" %}} 

Az Aspose.Slides for Java most már támogatja a gyűrűdiagram lyuk méretének meghatározását. Ebben a témában egy példán keresztül megmutatjuk, hogyan lehet beállítani a lyuk méretét egy gyűrűdiagramon.

{{% /alert %}} 

A gyűrűdiagram lyuk méretének meghatározásához kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) objektumot.  
2. Adjon hozzá gyűrűdiagramot a diára.  
3. Adja meg a lyuk méretét egy gyűrűdiagramon.  
4. Írja a bemutatót a lemezre.  

Az alább bemutatott példában beállítottuk a lyuk méretét egy gyűrűdiagramon.

```java
// Hozzon létre egy Presentation osztály példányt
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Írja a prezentációt a lemezre
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Létrehozhatok több szintű gyűrűdiagramot több gyűrűvel?**

Igen. Több sorozatot adhat egyetlen gyűrűdiagramhoz – minden sorozat külön gyűrűvé válik. A gyűrűk sorrendje a sorozatok gyűjteményben lévő sorrendjétől függ.

**Támogatott-e a "exploded" gyűrű (különálló szeletek)?**

Igen. Létezik egy Exploded Doughnut [chart type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) és egy robbantás tulajdonság az adatpontokon; egyes szeleteket szét lehet választani.

**Hogyan kaphatok képet egy gyűrűdiagramról (PNG/SVG) egy jelentéshez?**

A diagram egy alakzat; renderelhető egy [raster image](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getImage-int-float-float-) vagy exportálható egy [SVG image](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) formátumba.