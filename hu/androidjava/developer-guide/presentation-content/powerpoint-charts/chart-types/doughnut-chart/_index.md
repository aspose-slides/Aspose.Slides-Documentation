---
title: "Fánkdiagramok testreszabása prezentációkban Androidon"
linktitle: "Fánkdiagram"
type: docs
weight: 30
url: /hu/androidjava/doughnut-chart/
keywords:
- "fánkdiagram"
- "középső lyuk"
- "lyuk mérete"
- "PowerPoint"
- "prezentáció"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Fedezze fel, hogyan hozhat létre és testreszabhat fánkdiagramokat az Aspose.Slides for Android via Java használatával, támogatva a PowerPoint formátumokat dinamikus prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni egy fánkdiagrammal az Aspose.Slides-ban úgy, hogy a diagramot egy diára helyezzük, beállítjuk középső lyuk méretét, és elmentjük a bemutatót. A `setDoughnutHoleSize` metódusra összpontosít, és bemutatja a diagram típus testreszabásához szükséges alapvető lépéseket a kódban.

Emellett egy rövid GYIK is szerepel, amely a kapcsolódó fánkdiagram-szituációkat fedi, például több sorozat használata több gyűrű létrehozásához, a szétrobbanó fánkdiagramok kezelése, valamint egy diagram raster kép vagy SVG formátumba exportálása.

## **A középső rés (lyuk) megadása a fánkdiagramon**
{{% alert color="info" %}} 
Az Aspose.Slides for Android via Java most már támogatja a fánkdiagram lyukméretének megadását. Ebben a témában példán keresztül megmutatjuk, hogyan adható meg a lyuk mérete a fánkdiagramon.
{{% /alert %}} 

Az alábbi lépéseket kövesse a lyuk méretének megadásához egy fánkdiagramon:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) objektumot.
1. Adjon hozzá fánkdiagramot a diára.
1. Adja meg a lyuk méretét a fánkdiagramon.
1. Írja a bemutatót a lemezre.

Az alább bemutatott példában beállítottuk a lyuk méretét a fánkdiagramon.

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

### Létrehozhatok több szintű fánkot több gyűrűvel?

Igen. Több sorozatot adjon egyetlen fánkdiagramhoz – minden sorozat külön gyűrűvé válik. A gyűrűk sorrendje a sorozatok gyűjteményben szereplő sorrendjétől függ.

### Támogatott a „szétrobbanó” fánk (különálló szeletek)?

Igen. Létezik egy Exploded Doughnut [chart type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) és egy robbanás‑tulajdonság az adatpontokon; egyes szeleteket külön lehet választani.

### Hogyan szerezhetek képet egy fánkdiagramról (PNG/SVG) egy jelentéshez?

A diagram egy alakzat; renderelhető egy [raster image](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) formátumba, vagy exportálható egy [SVG image](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).