---
title: Testreszabott gyűrűdiagramok prezentációkban Java segítségével
linktitle: Gyűrűdiagram
type: docs
weight: 30
url: /hu/java/doughnut-chart/
keywords:
  - gyűrűdiagram
  - középső hézag
  - lyuk méret
  - PowerPoint
  - prezentáció
  - Java
  - Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat gyűrűdiagramokat az Aspose.Slides for Java-ban, a PowerPoint formátumokat támogatva dinamikus prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk a gyűrűdiagrammal az Aspose.Slides-ben úgy, hogy a diagramot egy diára helyezzük, beállítjuk a középső lyuk méretét, és elmentjük a bemutatót. A `setDoughnutHoleSize` metódusra összpontosít, és demonstrálja a diagramtípus testreszabásához szükséges alapvető lépéseket a kódban.

Hozzá tartozik egy rövid GyIK is, amely a kapcsolódó gyűrűdiagram‑szituációkat tárgyalja, például több sorozat használatát több gyűrű létrehozásához, a felrobbantott gyűrűdiagramok kezelését, és a diagram exportálását raszteres képként vagy SVG‑ként.

## **A középső hézag megadása a gyűrűdiagramon**
{{% alert color="info" %}} 

Az Aspose.Slides for Java most már támogatja a gyűrűdiagram lyukméretének megadását. Ebben a témában példán keresztül megmutatjuk, hogyan lehet megadni a lyuk méretét a gyűrűdiagramon.

{{% /alert %}} 

A gyűrűdiagram lyukméretének megadásához kövesse az alább felsorolt lépéseket:

1. Példányosítson egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) objektumot.
1. Adjon hozzá egy gyűrűdiagramot a diára.
1. Adja meg a lyuk méretét a gyűrűdiagramon.
1. Írja ki a prezentációt a lemezre.

Az alább bemutatott példában beállítottuk a lyuk méretét a gyűrűdiagramon.

```java
import com.aspose.slides.*;

// Hozzon létre egy Presentation osztály példányt
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Mentse a prezentációt a lemezre
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### Létrehozhatok több szintű gyűrűdiagramot több gyűrűvel?

Igen. Adjunk hozzá több sorozatot egyetlen gyűrűdiagramhoz – minden sorozat egy külön gyűrűvé válik. A gyűrűk sorrendjét a sorozatok a gyűjteményben való elhelyezkedése határozza meg.

### Támogatott-e a “felrobbantott” gyűrű (szétválasztott szeletek)?

Igen. Van egy Exploded Doughnut [chart type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) típus, és egy explosion tulajdonság az adatpontokon; így egyedi szeleteket lehet szétválasztani.

### Hogyan kaphatok képet egy gyűrűdiagramról (PNG/SVG) egy jelentéshez?

A diagram egy alakzat; renderelhető egy [raster image](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getImage-int-float-float-) formátumba, vagy exportálható egy [SVG image](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).