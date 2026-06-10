---
title: Fánk diagramok testreszabása prezentációkban Androidon
linktitle: Fánk diagram
type: docs
weight: 30
url: /hu/androidjava/doughnut-chart/
keywords:
- fánk diagram
- középső hézag
- lyuk mérete
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat fánk diagramokat az Aspose.Slides for Android via Java segítségével, támogatva a PowerPoint formátumokat dinamikus prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni egy fánk diagrammal az Aspose.Slides-ben úgy, hogy a diagramot egy diára helyezzük, beállítjuk a központi lyuk méretét, és elmentjük a prezentációt. A `setDoughnutHoleSize` metódusra összpontosít, és bemutatja a diagramtípus testreszabásához szükséges alapvető lépéseket kódban.

Továbbá egy rövid GYIK-ot is tartalmaz, amely a kapcsolódó fánk diagram szituációkat tárgyalja, például több sorozat használatát több gyűrű létrehozásához, a felrobbant fánk diagramok kezelését, valamint a diagram raszteres kép vagy SVG formátumban való exportálását.

## **A középső hézag megadása a fánk diagramon**
{{% alert color="primary" %}} 
Az Aspose.Slides for Android via Java most már támogatja a fánk diagram lyukméretének megadását. Ebben a témában egy példával mutatjuk be, hogyan adható meg a lyuk mérete a fánk diagramon.
{{% /alert %}} 

A fánk diagram lyukméretének megadásához kérjük, kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) objektumot.
1. Adjon egy fánk diagramot a diára.
1. Adja meg a fánk diagram lyukjának méretét.
1. Írja a prezentációt a lemezre.

Az alább bemutatott példában beállítottuk a fánk diagram lyukjának méretét.

```java
// Hozzon létre egy példányt a Presentation osztályból
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

**Létrehozhatok több szintű fánkot több gyűrűvel?**

Igen. Adjon több sorozatot egyetlen fánk diagramhoz – minden sorozat külön gyűrűvé válik. A gyűrűk sorrendjét a sorozatok a gyűjteményben való sorrendje határozza meg.

**Támogatott a „felrobbant” fánk (szétválasztott szeletek)?**

Igen. Van egy Exploded Doughnut [chart type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) típusú diagram és egy robbantási tulajdonság az adatpontokon; egyes szeleteket szétválaszthat.

**Hogyan kaphatok képet egy fánk diagramról (PNG/SVG) egy jelentéshez?**

A diagram egy alakzat; renderelhető egy [raster image](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) képre, vagy exportálható egy [SVG image](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) képbe.