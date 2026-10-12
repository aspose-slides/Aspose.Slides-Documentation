---
title: Diagram adatcímkék kezelése prezentációkban JavaScript használatával
linktitle: Adatcímke
type: docs
url: /hu/nodejs-java/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet diagram adatcímkéket hozzáadni és formázni PowerPoint prezentációkban JavaScript és az Aspose.Slides for Node.js segítségével Java-hoz, a még vonzóbb diák érdekében."
---
## **Bevezetés**

Az adatcímkék információkat jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázhatók az értékek, hogyan jeleníthetők meg a százalékok, hogyan olvasható a címke szövege, hogyan vezérelhetők a címkék a tengely maximális értéke felett, hogyan állítható be a kategóriatengely címke távolsága, és hogyan helyezhetők el a kördiagram címkéi.

## **Adatpontosság beállítása a diagram adatcímkéiben**

Használja a [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) metódust a sorozatértékek formázásához. Ez a példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, megjeleníti az adat táblát, és engedélyezi az értékcímkéket az első sorozathoz. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy a mögöttes értékeket megváltoztatná.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Százalék megjelenítése címkeként**

Egy halmozott oszlopdiagram esetén számítsa ki minden értéket a kategória összegének százalékaként, és rendelje a szöveget a [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) által visszaadott szövegkerethez. Ez a példa az alapértelmezett diagram adatokat használja, és két tizedesjegy pontosságú százalékokat jelenít meg 8 pontos betűmérettel. Az olyan kategóriákat, amelyek összegük nulla, kihagyja a nullával való osztás elkerülése érdekében. Frissítse az egyéni címkeszöveget, ha a diagram adatai megváltoznak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Százalékjel beállítása a diagram adatcímkékkel**

Ha az értékek tört formájában vannak tárolva, használja a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) metódust a százalékok megjelenítéséhez. Adjon át `false` értéket a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) metódusnak, hogy a címkeformátumot függetlenül alkalmazza a forráscelláktól.  

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értéppár összege 1. A címkeformátum `0.0%` 0.30-at 30.0%-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkét használ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az adatcímkék tényleges szövegének lekérdezése**

Használja a [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) metódust a adatcímke beállítások által előállított szöveg lekérésére. Ez hasznos címkék jelentésekhez történő kinyerésekor, a prezentáció tartalmának keresésekor vagy a létrehozott diagramok ellenőrzésekor. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) kombinálja a kategórianév, sorozatnév és érték minden elemet. Egy pont a értékét százalékos formátumban jeleníti meg, egy másik egyedi szöveget használ a [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) segítségével.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

A data pontban tárolt szám továbbra is `0.75`, még akkor is, ha a címkéje `75%`-ot mutat a kategória- és sorozatnevekkel együtt. Az egyedi szöveg felülírja a generált címkét. A [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) mindkét esetben visszaadja a kapott címke karakterláncot. Ellenőrizze külön a [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) metódust, ahogyan fent is látható, ha csak a látható címkéket szeretné kinyerni.

## **Adatcímkék vezérlése a tengely maximuma felett**

Ha manuálisan korlátozza egy tengely tartományát, egyes adatpontok meghaladhatják a maximumot. Használja a [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) metódust annak szabályozására, hogy a címkék megjelenjenek-e. Ez a beállítás a címke láthatóságát módosítja; nem változtatja meg a tengely tartományát vagy a mögöttes adatértékeket.  

A lenti példa egy 2D csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. `false` értéket ad a [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) metódusnak, és a függőleges tengelyen a [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) segítségével 100-ra állítja a maximumot. Az első dián a maximumot meghaladó címkék engedélyezve vannak; egy másolatban letiltja őket. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlban kerül mentésre.  

Engedélyezze az értékcímkéket a [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) metódussal. A diagram szintű beállítás önmagában nem engedélyezi az értékek megjelenítését, és nem írja felül egy adott címke letiltott értékmegjelenítését. Ez a példa az egész sorozatra engedélyezi az értékek megjelenítését, és a [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) metódussal a címkéket az egyes oszlopok külső végére helyezi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A következő képek a Microsoft PowerPoint által renderelt mentett diákat mutatják. `true` esetén a **120** címke a felső határnál látható; `false` esetén rejtett. A **60** címke látható marad, a tengely maximum **100** marad, és a második adatpont **120** marad mindkét esetben.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint diagram, amely a 120 értékcímkét mutatja 100 tengelymaximum mellett](data-labels-over-maximum-true.png) | ![PowerPoint diagram, amely elrejti a 120 értékcímkét 100 tengelymaximum mellett](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Az értéktengellyel nem rendelkező diagramok, mint a kör- és a fánkdiagramok, nincs tengelymaximumuk, amit így korlátozni lehetne.
{{% /alert %}}

## **Címke távolság beállítása a tengelytől**

Használja a [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) metódust a kategóriatengely címkéi és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengelycímke eltolását 500-ra állítja. Ez a beállítás a kategóriatengely címkéit érinti, nem pedig az egyes adatpontokhoz csatolt címkéket.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Címke helyének módosítása**

Egy kördiagramon állítsa be az adatcímkék pozícióját a térköz javítása és a vezető vonalak számára hely biztosítása érdekében.  

Ez a példa megjeleníti az első adatpont értékét, a címkét a szelet kívülre helyezi, és a [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) és [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) metódusokkal a vízszintes és függőleges eltolásokat állítja be. Ezek az eltolások viszonylag a diagram szélességéhez és magasságához vannak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Kördiagram, amelyen a data címke pozíciója módosítva van](pie-chart-adjusted-label.png)

## **Több soros adatcímkék hozzáadása egy oszlopdiagram fölé**

Ez a példa egy oszlopdiagramot hoz létre két sor adatcímkével a rajzterület felett. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a további címkéket biztosítják. Ezek oszlopait a kitöltés és a körvonal eltávolításával rejtjük. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) metódus mindhárom sorozatot ugyanazzal a kategória középponttal helyezi.  

A [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) beállítások helyet tartanak fenn a címkesorok számára. A [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) számításai után a [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) és [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) megőrzik a vízszintes igazítást és függőleges eltolásokat alkalmaznak a címkék két sorba rendezéséhez. A számok maradnak adatcímkék, amelyek a sorozatértékekhez kapcsolódnak; csak a sorfejlécek külön szöveges alakzatok.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // Rejtse el a B és C oszlopait, de tartsa meg az adatcímkéiket.
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // Igazítsa a három sorozatot ugyanazzal a kategória középponttal.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // Kevesebb rácsvonalat használjon ebben a kompakt példában.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Foglaljon helyet a diagram felett két sor adatcímkének.
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Tartsa meg az alapértelmezett vízszintes pozíciót. Az Y egy eltolás a
            // alapcímke pozíciótól, a diagrammagasság hányadában kifejezve.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // Csak a sorfejléc egy külön szöveges alakzat.
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Oszlopdiagram két sor adatcímkével a rajzterület felett](multiple-rows-of-labels.png)

## **FAQ**

**Hogyan lehet megakadályozni az adatcímkék átfedését a zsúfolt diagramokon?**  
Kombinálja az automatikus címkeelhelyezést, a vezető vonalakat és a kisebb betűméretet; szükség esetén rejtse el egyes mezőket (például a kategóriát), vagy csak a szélső értékek vagy kulcspontok esetén jelenítse meg a címkéket.

**Hogyan lehet letiltani a címkéket csak a nulla, negatív vagy üres értékeknél?**  
Szűrje meg az adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést a 0, negatív vagy hiányzó értékekre egy meghatározott szabály szerint.

**Hogyan biztosítható a következetes címkestílus PDF vagy képek exportálásakor?**  
Kifejezetten állítsa be a betűtípust és a méretet, és ellenőrizze, hogy a betűtípus elérhető-e a renderelési környezetben, hogy elkerülje a helyettesítést.