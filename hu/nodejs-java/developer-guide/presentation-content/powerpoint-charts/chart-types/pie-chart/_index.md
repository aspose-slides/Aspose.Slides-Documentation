---
title: Kördiagramok testreszabása prezentációkban JavaScript használatával
linktitle: Kördiagram
type: docs
url: /hu/nodejs-java/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram beállításai
- diagram beállítások
- ábrázolási beállítások
- szelet színe
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat kördiagramokat JavaScriptben az Aspose.Slides for Node.js segítségével, exportálható PowerPoint formátumban, és növelheti adatmesélését néhány másodperc alatt."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet kördiagramokkal dolgozni az Aspose.Slides-ben. Ismerteti a másodlagos ábra beállításait a Pie of Pie és Bar of Pie diagramokhoz, valamint a standard kördiagram automatikus szeletszínezésének engedélyezését.

A példák gyakorlati diagramtestreszabási lépésekre összpontosítanak, például diagram hozzáadása egy diára, sorozatok és címkék beállítása, az alapértelmezett diagramadatok helyettesítése egyedi kategóriákkal és értékekkel, valamint a módosított prezentáció mentése.

## **Másodlagos ábrázolási lehetőségek a Pie of Pie és Bar of Pie diagramokhoz**
Az Aspose.Slides for Node.js via Java most már támogatja a másodlagos ábra beállításait a Pie of Pie vagy Bar of Pie diagramhoz. Ebben a témában megmutatjuk, hogyan adhatók meg ezek a beállítások az Aspose.Slides használatával. A tulajdonságok megadásához tegye a következőket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztálypéldányt.
1. Adjon diagramot a diára.
1. Adja meg a diagram másodlagos ábrázolási beállításait.
1. Írja a prezentációt lemezre.

Az alább bemutatott példában különböző Pie of Pie diagramtulajdonságokat állítottunk be.

```javascript
// Hozzon létre egy Presentation osztály példányt
var pres = new aspose.slides.Presentation();
try {
    // Adjon diagramot a diára
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Állítson be különböző tulajdonságokat
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Mentse a prezentációt lemezre
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Automatikus kördiagram szelet színek beállítása**
Az Aspose.Slides for Node.js via Java egyszerű API-t kínál az automatikus kördiagram szelet színek beállításához. A minta kód alkalmazza a fent említett beállításokat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Nyissa meg az első diát.
1. Adjon diagramot az alapértelmezett adatokkal.
1. Állítsa be a diagram címét.
1. Állítsa be az első sorozatot az Értékek megjelenítésére.
1. Állítsa be a diagram adatlap indexét.
1. Szerezze be a diagram adatlapját.
1. Törölje az alapértelmezés szerint generált sorozatokat és kategóriákat.
1. Adjon hozzá új kategóriákat.
1. Adjon hozzá új sorozatot.

Írja a módosított prezentációt PPTX fájlba.

```javascript
// Hozzon létre egy Presentation osztály példányt
var pres = new aspose.slides.Presentation();
try {
    // Adjon diagramot az alapértelmezett adatokkal
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // A diagram címének beállítása
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Állítsa be az első sorozatot az Értékek megjelenítésére
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // A diagram adatlap indexének beállítása
    var defaultWorksheetIndex = 0;
    // A diagram adatlapjának lekérése
    var fact = chart.getChartData().getChartDataWorkbook();
    // Törölje az alapértelmezés szerint generált sorozatokat és kategóriákat
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Új kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Új sorozat hozzáadása
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Most a sorozat adatainak feltöltése
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Támogatottak a 'Pie of Pie' és a 'Bar of Pie' változatok?**

Igen, a könyvtár [támogatja](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/) a kördiagramok másodlagos ábráját, beleértve a 'Pie of Pie' és 'Bar of Pie' típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, a diagramot [exportálhatja képként](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage) (például PNG) anélkül, hogy az egész prezentációt mentené.