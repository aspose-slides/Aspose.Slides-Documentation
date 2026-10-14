---
title: Kördiagramok testreszabása prezentációkban Java használatával
linktitle: Kördiagram
type: docs
url: /hu/java/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram beállításai
- diagram beállítások
- ábrázolási beállítások
- szelet szín
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Készítsen és testreszabjon kördiagramokat Java-val az Aspose.Slides segítségével. Konfigurálja a másodlagos ábrákat, jelenítse meg az adatcímkéket, és alkalmazzon automatikus szelet színeket a PowerPointban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozzunk kördiagramokkal az Aspose.Slides-ban. Megmutatja, hogyan konfigurálhatók a másodlagos ábra beállításai a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan engedélyezhető az automatikus szelet színezés egy szabványos kördiagramon.

A példák a diagram testreszabási feladataira összpontosítanak, mint például diagram hozzáadása egy diára, sorozatok és címkék beállításainak módosítása, az alapértelmezett diagramadatok helyettesítése egyéni kategóriákkal és értékekkel, valamint a frissített prezentáció mentése.

## **Másodlagos ábra beállítások a Pie of Pie és Bar of Pie diagramokhoz**

Az Aspose.Slides for Java támogatja a másodlagos ábra beállításait a Pie of Pie és Bar of Pie diagramokhoz. Ezek a beállítások szabályozzák a másodlagos ábra méretét és azt, hogy az adatpontok hogyan oszlanak meg a két ábra között.

A következő példa egy Pie of Pie diagramot hoz létre egy új prezentációban, és az adatpont értékeket címkeként jeleníti meg. A [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) metódus a másodlagos ábra méretét a fő ábra 149%-ára állítja. A [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) százalékos alapú felosztást választ, és a [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) a küszöböt 53%-ra állítja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Értékek megjelenítése és a másodlagos ábra konfigurálása.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kategóriák kiválasztása a másodlagos ábrához**

Használjon egyéni felosztást, ha bizonyos kategóriákat szeretne a másodlagos ábrában csoportosítani a százalékos értékeiktől függetlenül. Például egy értékesítési jelentésben megjelenítheti az Online és az Events kategóriákat együtt, hogy az olvasók össze tudják hasonlítani ezt a két csatornát, még ha azok a teljes eladások 35%-át és 10%-át teszik ki is.

Hívja meg a [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) metódust a [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) értékkel, és válassza ki a pontokat a [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--) segítségével. A gyűjtemény [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) metódusa sorozatonként nullától kezdődő indexet fogad; használja a [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) metódust adatpont objektum hozzáadásához. Ebben a példában az 1-es index az Online-ot választja, a 3-as index az Events-et. A Partners is ideiglenesen hozzáadódik, majd a [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-) használatával kerül kizárásra.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Cserélje le az alapértelmezett adatokat a csatorna szerinti értékesítéssel.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Válassza ki az Online-ot a nullánál kezdődő indexével, és az Events-et az adatpont objektumával.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Zárja ki a Partners-et a kiválasztásból a forrásadatok törlése nélkül.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az Online (35) és az Events (10) külön szeletekként jelennek meg a másodlagos ábrán. Az elsődleges ábrán egy kombinált szelet képviseli őket, amelynek értéke 45, a Retail (40) és a Partners (15) mellett. A Partners eltávolítása az egyéni kiválasztásból csak az elsődleges ábrában marad; nem távolítja el a kategóriát vagy az értékét a diagram forrásadataiból.

Az alábbi kép mutatja a mentett prezentációt PowerPointban:
![Pie of Pie diagram Online és Events kategóriákkal a másodlagos ábrában és a 45-ös összértékkel az elsődleges ábrában](pie_of_pie_custom.png)

## **Automatikus kördiagram szelet színek beállítása**

Az Aspose.Slides for Java automatikusan különböző színeket rendelhet a kördiagram szeleteihez. A következő példa egy kördiagramot hoz létre középre igazított címmel, és az alapértelmezett adatokat három negyedéves kategóriával és azok értékeivel helyettesíti. A [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) metódus a 20, 50 és 30 értékeket jeleníti meg címkeként, míg a [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) lehetővé teszi, hogy minden szelet más színt kapjon.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Középre igazított diagramcím hozzáadása.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Cserélje le az alapértelmezett adatokat az első munkalap használatával.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Értékek megjelenítése és különböző színek hozzárendelése a szeletekhez.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Támogatottak a Pie of Pie és Bar of Pie változatok?**

Igen, a könyvtár [támogatja](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) egy másodlagos ábrát a kördiagramokhoz, beleértve a Pie of Pie és Bar of Pie típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, [exportálhatja a diagramot képként](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (például PNG) anélkül, hogy az egész prezentációt exportálná.