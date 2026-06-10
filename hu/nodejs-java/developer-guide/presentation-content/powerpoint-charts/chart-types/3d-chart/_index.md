---
title: 3D diagramok testreszabása prezentációkban JavaScript használatával
linktitle: 3D diagram
type: docs
url: /hu/nodejs-java/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat 3D diagramokat az Aspose.Slides for Node.js via Java segítségével, PPT és PPTX fájlok támogatásával—javítsa prezentációit még ma."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni egy 3D diagramot az Aspose.Slides-ban a `Rotation3D` beállítások, például a `RotationX`, `RotationY`, `DepthPercents` és a `RightAngleAxes` konfigurálásával. Lépésről lépésre végigvezet egy prezentáció létrehozásán, egy alapértelmezett adatokkal ellátott 3D diagram hozzáadásán, a szükséges 3D nézetbeállítások alkalmazásán, és a módosított prezentáció PPTX fájlként való mentésén.

## **A 3D diagram RotationX, RotationY és DepthPercents tulajdonságainak beállítása**

Az Aspose.Slides for Node.js via Java egyszerű API-t biztosít ezeknek a tulajdonságoknak a beállításához. A következő cikk segít abban, hogyan állíthatók be különböző tulajdonságok, mint a **X,Y Rotation, DepthPercents** stb. A példa kód a fent említett tulajdonságok beállítását mutatja be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Hozzáférés az első diára.
1. Diagram hozzáadása alapértelmezett adatokkal.
1. Rotation3D tulajdonságok beállítása.
1. A módosított prezentáció mentése PPTX fájlba.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // Diagram hozzáadása alapértelmezett adatokkal
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // A diagram adatlap indexének beállítása
    var defaultWorksheetIndex = 0;
    // A diagram adatlap lekérése
    var fact = chart.getChartData().getChartDataWorkbook();
    // Sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Rotation3D tulajdonságok beállítása
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Második diagram sorozat kivétele
    var series = chart.getChartData().getSeries().get_Item(1);
    // Sorozat adatainak feltöltése
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Overlap érték beállítása
    series.getParentSeriesGroup().setOverlap(100);
    // Prezentáció mentése lemezre
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja az oszlopdiagramok 3D változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100% Stacked Column 3D diagramokat, valamint a kapcsolódó 3D típusokat, amelyek a [ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/) felsorolásában érhetők el. A pontos, naprakész listáért tekintse meg a [ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/) elemeit a telepített verzió API referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [chart API](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage) vagy a [render the entire slide](/slides/hu/nodejs-java/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumokba. Ez akkor hasznos, ha pixelpontos előnézetre van szüksége, vagy a diagramot dokumentumokba, irányítópultokba vagy weboldalakba szeretné beágyazni anélkül, hogy a PowerPointot igénybe venné.

**Milyen teljesítményű a nagy 3D diagramok felépítése és renderelése?**

A teljesítmény az adat mennyiségétől és a vizuális komplexitástól függ. A legjobb eredmény érdekében tartsa minimálisra a 3D hatásokat, kerülje a nehéz textúrákat a falakon és a plot területeken, korlátozza az egy sorozatonkénti adatpontok számát ahol lehetséges, és rendereljen a cél kijelző vagy nyomtatási igényeknek megfelelő méretre (felbontás és méretek).