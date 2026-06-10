---
title: K�rdiagramok testreszab�sa prezent�ci�kban Java haszn�lat�val
linktitle: K�rdiagram
type: docs
url: /hu/java/pie-chart/
keywords:
- k�rdiagram
- diagram kezel�se
- diagram testreszab�sa
- diagram be�ll�t�sk
- diagram konfigur�ci�k
- �br�zol�si be�ll�t�sk
- szelet sz�n�e
- PowerPoint
- prezent�ci� 
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat l�tre �s testreszabhat k�rdiagramokat Java-ban az Aspose.Slides seg�ts�g�vel, amelyek export�lhat�k PowerPointba, �s m�odospercek alatt fokozz�k adatmes�l�s�t."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan dolgozzunk kördiagramokkal az Aspose.Slides-ban. Bemutatja, hogyan konfiguráljuk a másodlagos diagrambeállításokat a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan engedélyezzük az automatikus szelet színezést egy szabványos kördiagram esetén.

A példák a gyakorlati diagramtestreszabási lépésekre összpontosítanak, mint például diagram hozzáadása egy diára, sorozat- és címkelési beállítások módosítása, az alapértelmezett diagramadatok helyettesítése egyedi kategóriákkal és értékekkel, valamint a frissített bemutató mentése.

## **Másodlagos diagrambeállítások a Pie of Pie és Bar of Pie diagramokhoz**
Az Aspose.Slides for Java most már támogatja a másodlagos diagrambeállításokat a Pie of Pie vagy Bar of Pie diagramokhoz. Ebben a témában megmutatjuk, hogyan adhatók meg ezek a beállítások az Aspose.Slides használatával. A tulajdonságok megadásához tegye a következőket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztálypéldányt.
1. Adjon hozzá diagramot a diára.
1. Adja meg a diagram másodlagos diagrambeállításait.
1. Írja a bemutatót lemezre.

Az alább bemutatott példában a Pie of Pie diagram különböző tulajdonságait állítottuk be.

```java
// Hozzon létre egy Presentation osztály példányát
Presentation pres = new Presentation();
try {
    // Adjunk hozzá diagramot a diára
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Állítsa be a különböző tulajdonságokat
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Írja a bemutatót a lemezre
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Automatikus kördiagram-szelet színek beállítása**
Az Aspose.Slides for Java egyszerű API-t biztosít az automatikus kördiagram-szelet színek beállításához. A minta kód alkalmazza a fent említett tulajdonságok beállítását.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztálypéldányt.
1. Hozzáférjen az első diához.
1. Adjon hozzá diagramot alapértelmezett adatokkal.
1. Állítsa be a diagram címsorát.
1. Állítsa be az első sorozatot az Értékek megjelenítésére.
1. Állítsa be a diagram adatlapjának indexét.
1. Szerezze meg a diagram adat munkalapját.
1. Törölje az alapértelmezett generált sorozatokat és kategóriákat.
1. Adjon hozzá új kategóriákat.
1. Adjon hozzá új sorozatot.

Írja a módosított bemutatót egy PPTX fájlba.

```java
// Hozzon létre egy Presentation osztály példányt
Presentation pres = new Presentation();
try {
    // Adjunk hozzá diagramot alapértelmezett adatokkal
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

    // A diagram adat munkalapjának lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Alapértelmezett generált sorozatok és kategóriák törlése
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Új kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Új sorozat hozzáadása
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Most a sorozat adatai feltöltése
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

**Támogatottak a „Pie of Pie” és a „Bar of Pie” változatok?**

Igen, a könyvtár [támogat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) egy másodlagos diagramot a kördiagramokhoz, beleértve a „Pie of Pie” és „Bar of Pie” típusokat.

**Exportálhatom csak a diagramot képként (például PNG‑ként)?**

Igen, [exportálhatja a diagramot képként](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getImage-int-float-float-) (például PNG) anélkül, hogy az egész bemutatót mentené.