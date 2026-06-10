---
title: Testreszabás 3D diagramok prezentációkban Java használatával
linktitle: 3D diagram
type: docs
url: /hu/java/3d-chart/
keywords:
- 3D diagram
- forgatás
- mélység
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat 3D diagramokat az Aspose.Slides for Java-ban, PPT és PPTX fájlok támogatásával – növelje prezentációi hatékonyságát még ma."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni egy 3D diagramot az Aspose.Slides-ban a `Rotation3D` beállítások, például `RotationX`, `RotationY`, `DepthPercents` és `RightAngleAxes` konfigurálásával. Lépésről lépésre bemutatja egy prezentáció létrehozását, egy 3D diagram hozzáadását alapértelmezett adatokkal, a szükséges 3D nézetbeállítások alkalmazását, és a módosított prezentáció PPTX fájlként történő mentését.

## **3D Diagram RotationX, RotationY és DepthPercents Tulajdonságainak Beállítása**
Az Aspose.Slides for Java egyszerű API-t biztosít ezen tulajdonságok beállításához. A következő cikk segít abban, hogyan állítható be különböző tulajdonságok, például **X**, **Y** forgatás, **DepthPercents** stb. A mintakód alkalmazza a fent említett tulajdonságok beállítását.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés az első diára.
3. Diagram hozzáadása alapértelmezett adatokkal.
4. `Rotation3D` tulajdonságok beállítása.
5. A módosított prezentáció írása PPTX fájlba.

```java
Presentation pres = new Presentation();
try {
    // Első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Diagram hozzáadása alapértelmezett adatokkal
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // A diagram adatlapon lévő index beállítása
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
    
    // Rotation3D tulajdonságok beállítása
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // A második diagram sorozat kivétele
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Most feltöltjük a sorozat adatokat
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Overlap érték beállítása
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Prezentáció mentése a lemezre
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a 3D változatokat a oszlopdiagramok esetében, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100% Stacked Column 3D diagramokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) osztályon keresztül érhetők el. A pontos, naprakész listáért tekintse meg a [ChartType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) tagjait az Ön által telepített verzió API referenciájában.

**Kaphatok raszter képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képformátumba a [chart API](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getImage-int-float-float-) vagy a [render the entire slide](/slides/hu/java/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumban. Ez hasznos, ha pixel pontos előnézetre van szükség, vagy be szeretné ágyazni a diagramot dokumentumokba, műszerfalakba vagy weboldalakba anélkül, hogy a PowerPointra lenne szükség.

**Milyen teljesítményű a nagy 3D diagramok felépítése és renderelése?**

A teljesítmény az adatmennyiségtől és a vizuális komplexitástól függ. A legjobb eredmény érdekében tartsa minimálisra a 3D hatásokat, kerülje a nehéz textúrákat a falakon és a diagramterületeken, korlátozza az adatpontok számát sorozatonként, ha lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és méretek) a célkijelző vagy nyomtatási igényekhez igazítva.