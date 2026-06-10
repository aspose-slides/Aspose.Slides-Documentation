---
title: Testreszabott kördiagramok prezentációkban Androidon
linktitle: Kördiagram
type: docs
url: /hu/androidjava/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram opciók
- diagram beállítások
- ábrázolási opciók
- szelet szín
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat kördiagramokat Java-val az Aspose.Slides for Android segítségével, exportálható PowerPoint formátumba, és másodpercek alatt növelheti adatmesélését."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk kördiagramokkal az Aspose.Slides-ban. Megmutatja, hogyan konfigurálható a másodlagos ábrázolási beállítás a 'Pie of Pie' és 'Bar of Pie' diagramokhoz, valamint hogyan engedélyezhető az automatikus szelet színezés egy szabványos kördiagramnál.

A példák a gyakorlati diagram testreszabási lépésekre összpontosítanak, mint például diagram hozzáadása egy diára, sorozatok és címkék beállításainak módosítása, az alapértelmezett diagramadatok helyettesítése egyéni kategóriákkal és értékekkel, valamint a frissített bemutató mentése.

## **Másodlagos ábrázolási lehetőségek a 'Pie of Pie' és 'Bar of Pie' diagramokhoz**
Az Aspose.Slides for Android via Java most már támogatja a másodlagos ábrázolási lehetőségeket a 'Pie of Pie' vagy 'Bar of Pie' diagramokhoz. Ebben a témában megmutatjuk, hogyan adhatók meg ezek a beállítások az Aspose.Slides használatával. A tulajdonságok megadásához tegye a következőt:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály objektumát.
1. Adjon hozzá egy diagramot a diára.
1. Adja meg a diagram másodlagos ábrázolási beállításait.
1. Írja ki a bemutatót a lemezre.

Az alább bemutatott példában különböző tulajdonságokat állítottunk be a 'Pie of Pie' diagramhoz.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    // Adjon hozzá egy diagramot a diára
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Állítson be különböző tulajdonságokat
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Írja ki a bemutatót a lemezre
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Automatikus kördiagram szelet színek beállítása**
Az Aspose.Slides for Android via Java egyszerű API-t biztosít az automatikus kördiagram diaszínek beállításához. A mintakód alkalmazza a fent említett beállításokat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Hozzáférés az első diához.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal.
1. Állítsa be a diagram címét.
1. Állítsa be az első sorozatot az Értékek megjelenítésére.
1. Állítsa be a diagram adatlap indexét.
1. A diagram adatlapjának lekérése.
1. Törölje az alapértelmezett generált sorozatokat és kategóriákat.
1. Új kategóriák hozzáadása.
1. Új sorozatok hozzáadása.

Írja ki a módosított bemutatót egy PPTX fájlba.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    // Adjon hozzá egy diagramot alapértelmezett adatokkal
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Diagram címének beállítása
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Állítsa be az első sorozatot az Értékek megjelenítésére
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // A diagram adatlap indexének beállítása
    int defaultWorksheetIndex = 0;

    // A diagram adatlapjának lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Az alapértelmezett generált sorozatok és kategóriák törlése
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Új kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Új sorozatok hozzáadása
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Most a sorozat adatok feltöltése
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Támogatottak a 'Pie of Pie' és 'Bar of Pie' változatok?**

Igen, a könyvtár [támogatja](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) a kördiagramok másodlagos ábrázolását, beleértve a 'Pie of Pie' és 'Bar of Pie' típusokat.

**Exportálhatom a diagramot csak képként (például PNG)?**

Igen, [exportálhatja a diagramot képként](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (például PNG), a teljes bemutató nélkül.