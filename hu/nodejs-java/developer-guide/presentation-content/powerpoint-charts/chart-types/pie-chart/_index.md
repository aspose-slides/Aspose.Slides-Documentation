---
title: Kördiagramok testreszabása prezentációkban JavaScript használatával
linktitle: Kördiagram
type: docs
url: /hu/nodejs-java/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram opciók
- diagram beállítások
- ábrázolási beállítások
- szelet szín
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kördiagramok létrehozása és testreszabása JavaScript-ben az Aspose.Slides for Node.js via Java segítségével. Másodlagos ábrákat konfigurál, adatcímkéket jelenít meg, és automatikus szelet színeket alkalmaz a PowerPointban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell dolgozni kördiagramokkal az Aspose.Slides-ban. Megmutatja, hogyan kell beállítani a másodlagos ábrázolási beállításokat a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan lehet engedélyezni az automatikus szeletszínezést egy szabványos kördiagramhoz.

A példák a diagram testreszabási feladatokra összpontosítanak, például diagram hozzáadására egy diára, sorozatok és címkék beállításainak módosítására, az alapértelmezett diagramadatok cseréjére egyéni kategóriákkal és értékekkel, valamint a frissített bemutató mentésére.

## **Másodlagos ábrázolási beállítások a Pie of Pie és Bar of Pie diagramokhoz**

Az Aspose.Slides for Node.js via Java támogatja a másodlagos ábrázolási beállításokat a Pie of Pie és Bar of Pie diagramokhoz. Ezek a beállítások szabályozzák a másodlagos ábra méretét, valamint azt, hogy az adatpontok hogyan oszlanak meg a két ábra között.

A következő példa létrehoz egy Pie of Pie diagramot egy új bemutatóban, és az adatpont értékeket címkeként jeleníti meg. A [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) metódus a másodlagos ábra méretét a fő ábra 149%-ára állítja. A [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) százalékos alapú felosztást választ, és a [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) a küszöböt 53%-ra állítja.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Értékek megjelenítése és a másodlagos ábra konfigurálása.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Válassza ki a kategóriákat a másodlagos ábrához**

Használjon egyéni felosztást, amikor adott kategóriákat szeretne a másodlagos ábrában csoportosítani a százalékos értékeiktől függetlenül. Például egy értékesítési jelentésben az Online és az Events együtt jelenhet meg, hogy az olvasók össze tudják hasonlítani ezt a két csatornát, még akkor is, ha azok a teljes értékesítés 35%-át és 10%-át teszik ki.

Hívja meg a [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) a [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) értékkel, és válassza ki a pontokat a [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) segítségével. A gyűjtemény [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) metódusa nulla alapú indexet fogad a sorozatban; használja az [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) metódust egy adatpont objektum hozzáadásához. Ebben a példában az 1-es index az Online-ot választja, a 3-as index pedig az Events-et. A Partners is ideiglenesen hozzá van adva, majd a [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem) segítségével kizárásra kerül.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Cserélje le az alapértelmezett adatokat csatornánkénti értékesítéssel.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Válassza ki az Online-ot a nulla alapú indexével, és az Events-et az adatpont objektumával.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Zárja ki a Partners-t a kiválasztásból, anélkül, hogy törölné a forrásadatait.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az Online (35) és az Events (10) külön szeletekként jelennek meg a másodlagos ábrában. Az elsődleges ábrában egyetlen kombinált szeletként jelennek meg 45 értékkel, a Retail (40) és a Partners (15) mellett. A Partners eltávolítása az egyéni kiválasztásból az elsődleges ábrában marad; nem távolítja el a kategóriát vagy annak értékét a diagram forrásadataiból.

Az alábbi kép mutatja a mentett bemutatót a PowerPointban:
![Pie of Pie diagram Online és Events-szel a másodlagos ábrában és kombinált értékük 45 az elsődleges ábrában](pie_of_pie_custom.png)

## **Automatikus kördiagram szelet színek beállítása**

Az Aspose.Slides for Node.js via Java automatikusan képes különböző színeket rendelni a kördiagram szeleteihez. A következő példa középre igazított címmel hoz létre egy kördiagramot, és az alapértelmezett adatokat három negyedévi kategóriával és értékükkel helyettesíti. A [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) metódus a 20, 50 és 30 értékeket címkeként jeleníti meg, míg a [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) egyedi színt engedélyez minden szelethez.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Adjunk hozzá egy középre igazított diagramcímet.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Cseréljük le az alapértelmezett adatokat az első munkalap használatával.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Mutassuk meg az értékeket, és rendeljünk a szeletekhez különböző színeket.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Támogatottak a Pie of Pie és Bar of Pie változatok?**

Igen, a könyvtár [támogat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) egy másodlagos ábrát biztosít a kördiagramokhoz, beleértve a Pie of Pie és Bar of Pie típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, [exportálja a diagramot képként](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (például PNG) anélkül, hogy az egész bemutatót exportálná.