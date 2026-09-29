---
title: Diagram adatcímkék kezelése prezentációkban JavaScript segítségével
linktitle: Adatcímke
type: docs
url: /hu/nodejs-java/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpontosság
- százalék
- címketávolság
- címkehelyzet
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint prezentációkban JavaScript és Aspose.Slides for Node.js segítségével, a Java használatával, hogy vonzóbb diák legyenek."
---
## **Bevezetés**

Az adatcímkék információt jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázhatók az értékek, hogyan jeleníthetők meg a százalékok, hogyan olvasható ki a címkeszöveg, hogyan vezérelhetők a címkék a tengely maximumán túl, hogyan állítható be a kategóriatengely címkéinek távolsága, és hogyan pozícionálhatók a kördiagram címkéi.

## **Adatcímkék pontosságának beállítása a diagram adatcímkéiben**

Használja a [setNumberFormatOfValues](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) metódust a sorozatértékek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozatra. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

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

## **Százalékok megjelenítése címkékként**

Halmozott oszlopdiagram esetén minden értéket a kategória összegének százalékaként számoljon ki, és rendelje hozzá a szöveggel [getTextFrameForOverriding](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) által visszaadott szövegkerethez. Ez a példa az alapértelmezett diagramadatokat használja, és a százalékokat két tizedesjeggyel, 8 pontos betűmérettel jeleníti meg. A nulla összeggel rendelkező kategóriákat kihagyja a nullával való osztás elkerülése érdekében. Ha a diagram adatai változnak, számolja újra az egyéni címkeszöveget.

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

## **Százalékjel beállítása a diagram adatcímkéknél**

Ha az értékek törtként vannak tárolva, használja a [setNumberFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) metódust a százalékok megjelenítéséhez. Adjon át `false` értéket a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) metódusnak, hogy a címkeformátumot a forráscelláktól függetlenül alkalmazza.

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értékpár összege 1. A címkeformátum `0.0%` a 0.30-at 30.0%-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

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

Használja a [getActualLabelText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) metódust a címke beállításai által előállított szöveg lekéréséhez. Ez hasznos jelentésekhez címkék kinyerésekor, a prezentáció tartalmának keresésekor vagy a generált diagramok ellenőrzésekor. Az alábbi példában az alapértelmezett [adatcímke formátum](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabelformat/) kombinálja minden kategórianév, sorozatnév és érték megjelenítését. Az egyik pont értékét százalékos formátumban jeleníti meg, a másik pedig egyedi szöveget használ a [getTextFrameForOverriding](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) által visszaadott szövegkeretből.

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

Az adatponton tárolt szám továbbra is `0.75`, még akkor is, ha a címkéje `75%`-ként jelenik meg a kategória- és sorozatnevekkel együtt. Az egyedi szöveg felülírja a generált címkeszöveget. A [getActualLabelText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) mindkét esetben visszaadja az eredményül kapott címke karakterláncot. A [isVisible](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabel/isvisible/) metódust külön ellenőrizze, ahogyan fent mutattuk, ha csak a látható címkéket szeretné kinyerni.

## **Adatcímkék vezérlése a tengely maximumán túl**

Ha kézzel korlátozza egy tengely tartományát, egyes adatpontok meghaladhatják a maximumot. Használja a [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) metódust annak meghatározásához, hogy a címkék megjelenjenek-e. Ez a beállítás csak a címkék láthatóságát módosítja; nem változtatja meg a tengely tartományát vagy a mögöttes adatértékeket.

Az alábbi példa egy 2D csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. `false` értéket ad át a [setAutomaticMaxValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) metódusnak, és a függőleges tengelyen a [setMaxValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/axis/setmaxvalue/) metódussal 100-ra állítja a maximumot. Az első dián a címkék megjelennek a maximumon túl; egy másolatban letiltja őket. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlba van mentve.

Az értékcímkéket a [setShowValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) metódussal engedélyezheti. A diagram szintű beállítás önmagában nem aktiválja az értékek megjelenítését, és nem ír felül egy adott címke letiltott értékmegjelenítését. Ez a példa az egész sorozatra engedélyezi az értékek megjelenítését, és a [setPosition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabelformat/setposition/) metódust használja, hogy a címkéket az egyes oszlopok külső végére helyezze.

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

Az alábbi képek a Microsoft PowerPoint által megjelenített mentett diákat mutatják. `true` esetén a **120** címke látható a felső határon; `false` esetén rejtett. A **60** címke továbbra is látható, a tengely maximum **100** marad, és a második adatpont mindkét esetben **120** marad.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Az olyan diagramok, amelyek nem rendelkeznek értéktengellyel, például a kör és a pogácsa diagramok, nem rendelkeznek ezzel a módon korlátozható tengelymaximumszal.
{{% /alert %}}

## **Címke távolságának beállítása a tengelytől**

Használja a [setLabelOffset](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/axis/setlabeloffset/) metódust a kategóriatengely címkéi és a tengely közti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategóriatengely címkéire vonatkozik, nem az egyes adatpontokhoz csatolt címkékre.

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

## **Címke helyzetének módosítása**

Kördiagram esetén állítsa be az adatcímkék helyzetét a térköz javítása és a vezető vonalak számára hely biztosítása érdekében.

Ez a példa megjeleníti az első adatpont értékét, a címkét a szelet kívülre helyezi, és a [setX](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabel/setx/) és [setY](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabel/sety/) metódusokkal állítja be a vízszintes és függőleges eltolást. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva vannak.

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

![Kördiagram a módosított adatcímke helyzettel](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan akadályozhatom meg az adatcímkék átfedését zsúfolt diagramokon?**  
Kombinálja az automatikus címkeelhelyezést, a vezető vonalakat és a csökkentett betűméretet; szükség esetén rejtse el néhány mezőt (például a kategóriát), vagy csak a szélső értékekhez illetve kulcspontokhoz jelenítsen meg címkéket.

**Hogyan tilthatom le a címkéket csak a nulla, negatív vagy üres értékek esetén?**  
Szűrje le az adatpontokat a címkék engedélyezése előtt, és a meghatározott szabály szerint tiltsa le a 0, negatív vagy hiányzó értékek megjelenítését.

**Hogyan biztosíthatom a konzisztens címkestílust PDF/képek exportálásakor?**  
Állítsa be kifeexplicit a betűtípust és a méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelési környezetben, hogy elkerülje az alapértelmezett helyettesítést.