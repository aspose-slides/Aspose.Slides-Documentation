---
title: 3D diagramok testreszabása prezentációkban Androidon
linktitle: 3D diagram
type: docs
url: /hu/androidjava/3d-chart/
keywords:
- 3D diagram
- forgatás
- mélység
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat 3-D diagramokat az Aspose.Slides for Android via Java segítségével, PPT és PPTX fájlok támogatásával—javítsa prezentációit még ma."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni egy 3D diagramot az Aspose.Slides-ban a `Rotation3D` beállítások, például a `RotationX`, `RotationY`, `DepthPercents` és `RightAngleAxes` konfigurálásával. Lépésről lépésre ismerteti a prezentáció létrehozását, egy 3D diagram hozzáadását alapértelmezett adatokkal, a szükséges 3D nézetbeállítások alkalmazását, és a módosított prezentáció PPTX fájlként történő mentését.

## **A RotationX, RotationY és DepthPercents tulajdonságok beállítása egy 3D diagramon**
Az Aspose.Slides for Android via Java egyszerű API-t biztosít ezen tulajdonságok beállításához. A következő cikk segít a különböző tulajdonságok, például a **X,Y Rotation, DepthPercents** stb. beállításában. A példakód alkalmazza a fent említett tulajdonságok beállítását.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Nyissa meg az első diát.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal.
4. Állítsa be a Rotation3D tulajdonságokat.
5. Írja a módosított prezentációt PPTX fájlba.

```java
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Diagram hozzáadása alapértelmezett adatokkal
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // A diagram adatlap indexének beállítása
    int defaultWorksheetIndex = 0;
    
    // A diagram adatlapjának lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // A Rotation3D tulajdonságok beállítása
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // A második diagram sorozat lekérése
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Most a sorozat adatait töltjük fel
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Az Overlap érték beállítása
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Prezentáció mentése lemezre
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a oszlopdiagramok 3D változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100% Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) osztály ismeretében elérhet. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) tagjait az Ön által telepített verzió API referenciájában.

**Kaphatok rasterképet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [chart API](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) vagy a [render the entire slide](/slides/hu/androidjava/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumokban. Ez hasznos, ha pixel‑pontosságú előnézetre van szüksége, vagy a diagramot dokumentumokba, irányítópultokra vagy weboldalakra szeretné beágyazni anélkül, hogy a PowerPointra támaszkodna.

**Mennyire teljesítményorientált a nagy 3D diagramok építése és renderelése?**

A teljesítmény az adatmérettől és a vizuális komplexitástól függ. A legjobb eredmény érdekében tartsa minimális szinten a 3D hatásokat, kerülje a nehéz textúrákat a falakon és a diagramterületeken, korlátozza az egy sorozatra jutó adatpontok számát, ha lehetséges, és rendereljen olyan kimenetre, amely megfelelő felbontással és mérettel rendelkezik a célkijelző vagy nyomtatási igényekhez.