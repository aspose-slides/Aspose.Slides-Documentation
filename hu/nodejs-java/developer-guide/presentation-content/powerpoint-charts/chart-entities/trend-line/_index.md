---
title: Trendvonalak hozzáadása prezentációs diagramokhoz JavaScriptben
linktitle: Trendvonal
type: docs
url: /hu/nodejs-java/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgóátlag trendvonal
- polinomiális trendvonal
- hatványos trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint diagramokban JavaScript és Aspose.Slides for Node.js segítségével Java‑on keresztül — egy gyakorlati útmutató, amely segít lekötni a közönségét."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet trendvonalakat hozzáadni a prezentációdiagramokhoz az Aspose.Slides használatával. Megmutatja, hogyan hozhatunk létre diagramot, hogyan adhatunk hozzá trendvonalakat a diagram sorozataihoz, és hogyan dolgozhatunk több trendvonal típussal, beleértve az exponenciális, lineáris, logaritmikus, mozgóátlag, polinomiális és hatványos típusokat.

Leírja továbbá, hogyan adhatunk egy egyéni vonalat a diagramhoz vonal alakzat beillesztésével, és tartalmaz egy rövid GYIK-ot a trendvonalak előre és hátra történő kiterjesztésének értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e a PDF vagy SVG formátumba való exportálás, illetve a diagramok képként történő renderelése során.

## **Trendvonal hozzáadása**

Használja a [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) metódust trendvonal hozzáadásához egy diagram sorozatához, a típust a [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/) segítségével választhatja ki. A példa egy klaszterezett oszlopdiagramot hoz létre alapértelmezett adatokkal, és két trendvonalat ad hozzá mind a három sorozatához.

Az exponenciális trendvonal elrejti az egyenletét és az R-négyzet értékét a [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) és a [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue) segítségével, míg a lineáris trendvonal piros. A logaritmikus trendvonal a [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) metódust használja egy egyéni címkéhez. A mozgóátlag a [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) három adatpontot és egy egyéni [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) beállítást használ.

A polinomiális trendvonal [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) értéke három, és egy kategóriával előre nyúlik a [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward) segítségével. A hatványos trendvonal egy kategóriával hátra nyúlik a [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward) segítségével.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trendvonal metszéspont beállítása**

Használja a [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) metódust a trendvonal Y értékének X = 0-nál rögzítésére. Ez a beállítás támogatott lineáris, exponenciális és polinomiális trendvonalaknál.

Például egy termelési költségmodellnek 100 egység ismert fix költségnél kellene indulnia, még akkor is, ha a nem nulla termelési mennyiségeknél mért adatok más kiindulási értéket sugallnak. Lineáris trendvonal esetén a metszéspont rögzítése korlátozza a `y = ax + b` egyenletet `b = 100`‑ra; a meredekség a megadott feltétel mellett illeszkedik az adatokhoz. Ez nem egyszerűen eltol egy már illesztett vonalat. A tengelykeresztzési beállítások szabályozzák, hogy a diagram tengelyei hol találkoznak, nem pedig a trendvonal együtthatóit.

A következő példa egy szórási (XY) diagramot hoz létre, amely 1‑től 4‑ig terjedő termelési mennyiségeket és 170, 200, 230 és 260 költséget tartalmaz. A diagramot az alapértelmezett automatikus metszésponttal menti, beállítja a metszéspontot 100-ra, és egy második PPTX‑et ment. A két fájl csak a metszéspont beállításában különbözik. A trendvonal megjeleníti az egyenletét, és visszanyúlik X = 0‑ig.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Automatikus számítás esetén ezek az adatok `y = 30x + 140` egyenletet adnak. A metszéspont 100‑ra állítása helyette körülbelül `y = 43.33x + 100` egyenletet ad: a nulla ponton illesztett érték egyezik az ismert kiindulási értékkel, míg a vonal már nem halad át minden adatponton.

| Automatikus metszéspont | Fix metszéspont 100 |
| --- | --- |
| ![Lineáris trendvonal automatikusan számított 140-es metszésponttal](intercept-automatic.png) | ![Lineáris trendvonal fix 100-as metszésponttal](intercept-fixed.png) |

Mindkét kép ugyanazokat az adatokat és tengelyskálákat használja. A trendvonalak visszanyúlnak X = 0‑ig, hogy megmutassák metszéspontjaikat.

Alapértelmezés szerint a [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) `NaN` értéket ad vissza, ami nem meghatározott metszéspontot jelent, nem pedig nullát. Ezután a metszéspontot az adatokból számítja ki automatikusan.

## **Egyéni vonal hozzáadása**

Az egyéni vonal egy alakzat, amely a diagram felett van rajzolva, nem pedig a sorozatadatokból számított trendvonal. Ez a példa a [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) metódust használja egy vízszintes vonal hozzáadásához a diára a diagram felett. A vonal pozíciója a dia koordinátáiban, pontokban van megadva, így a diagram bal szélén kezdődik, és a diagram feléig helyezkedik el. Szélessége megegyezik a diagram szélességével. A [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) szilárd piros színt ad a vonalnak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mit jelent a 'forward' és a 'backward' egy trendvonal esetén?**

Ezek a trendvonal előre/vissza kiterjesztett hosszát jelentik: szórási (XY) diagramok esetén tengelyegységekben; nem-szórási diagramok esetén kategóriák számában. Csak nem negatív értékek engedélyezettek.

**Megmarad-e a trendvonal, amikor a prezentációt PDF‑be vagy SVG‑be exportálják, illetve amikor egy diát képként renderelik?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) vagy [SVG](/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak a diagram részeként megmaradnak ezeknél a műveleteknél. Egy módszer is elérhető a diagram [képének exportálására](/slides/hu/nodejs-java/create-shape-thumbnails/).