---
title: Formatera diagram i presentationer i JavaScript
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/nodejs-java/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensegenskaper
- rundade kanter
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för Node.js via Java och förbättra din PowerPoint-presentation med anpassade axlar, teckensnitt, talformat och rundade diagramkanter."
---
## **Översikt**

Den här artikeln förklarar hur du formaterar diagram i PowerPoint-presentationer med Aspose.Slides. Den visar hur du anpassar viktiga diagramdelar som axlar, rutnätslinjer, titlar, förklaringar, plotområdet och väggfyllningar för att förbättra diagrammens utseende och läsbarhet.

Den demonstrerar också hur du ställer in teckensegenskaper för diagramtext, tillämpar förinställda numeriska format på diagramdata och aktiverar rundade hörn för diagramområdet. Tillsammans visar dessa exempel hur du kontrollerar både den visuella stilen och datapresentationen för diagram i en presentation.

För separata fyllningar och konturer på stigande och fallande intervaller, se [exempel på aktiediagram](/slides/sv/nodejs-java/create-chart/#create-stock-charts).

## **Formatera diagramobjekt**

Använd [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) för att formatera diagramtitlar, axlar, rutnätslinjer, förklaringar och plotområdet. Detta exempel skapar ett linjediagram med markörer och standarddata, och tillämpar sedan separata text- och linjestilar på dess värde- och kategoriaxlar. Teckenstorlekar och linjebredder anges i punkter; kategorietiketter roteras 45 grader.

Värdeaxeln använder [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) oberoende av källcellerna. Dess skala sträcker sig från -2 till 15, med huvudintervall på 2 och delintervall på 0,5. Exemplet kombinerar också procentformat med [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) satt till tusental, så anpassa dessa inställningar efter betydelse och storlek på dina data. Förklaringen hålls utanför plotområdet eftersom [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) anropas med `false`. Bakväggs- och golvfyllningar konfigureras via [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) och [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor), men dessa ytor är endast synliga i 3D-diagram.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    let chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    chartTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15);
    chart.getAxes().getVerticalAxis().setMinValue(-2);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);

    let valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkGreen));
    valueAxisText.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    let valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    let categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    categoryAxisText.setLatinFont(new aspose.slides.FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    let categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    let legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    legendText.setFontHeight(16);
    legendText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    legendText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    legendText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkRed));

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.LightCyan));

    presentation.save("FormattedChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in teckensegenskaper för ett diagram**

Ställ in standardteckenstorleken för diagramtext via [Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat). Exemplet skapar ett hopgruppat stapeldiagram med ett 20‑punkts teckensnitt och aktiverar värdetiketter för den första serien via [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue). Textelement med egna uttryckliga teckensnittinställningar kan åsidosätta diagrammets standard.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Återanvänd formatering av textram för en diagramförklaring**

För att matcha en förklaring till en bildrubrik, ställ in rubrikens teckensnitt via [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) på det första stycket. Anropa [copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyFrom) på formatet som returneras av förklaringens [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#getTextFormat). Det kopierar textramens inställningar, det första styckets formatering och det styckets standardteckensnittsegenskaper. Formatering som appliceras direkt på enskilda portioner eller på senare stycken förblir lokalt för källan.

Exemplet använder en fet, 26‑punkts Calibri‑rubrik i marinblått som mall. Efter att förklaringen har stylats anropar det [copyTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyTo) för att tillämpa samma formatering på en separat bildtext.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const heading = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 20, 640, 40, false);
    const sourceTextFrame = heading.addTextFrame("Quarterly sales");
    const font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new aspose.slides.FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    font.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    font.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 32, 64, 96));

    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(java.newByte(aspose.slides.StyleType.Style3));
    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (let quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(java.newByte(aspose.slides.LegendPositionType.Bottom));
    const legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    const caption = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 460, 640, 40, false);
    const captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I den sparade presentationen matchar förklaringen och bildtexten rubriken i storlek, vikt och färg. Förklaringen visar fortfarande serienamnen, och bildtexten behåller sin egen text. Om en del i bildtexten redan har en explicit teckenstorlek, får den storleken företräde framför det kopierade styckets standard.

| Before copying | After copying |
| --- | --- |
| ![Kvartalsförsäljningsdiagram med vanliga svarta förklaringsetiketter och en svart bildtext](legend-formatting-before.png) | ![Samma diagram med större, fet, marinblå förklaringsetiketter och en matchande bildtext](legend-formatting.png) |

## **Ställ in numeriskt format**

Använd [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) för att tillämpa ett inbyggt talformat på diagrammets arbetsboksceller. Detta exempel skapar ett hopgruppat stapeldiagram med standard, cellstödd data och tillämpar formatindex 10 (`0.00%`) på varje serievärdescell. Detta ändrar hur värdena visas i arbetsboken utan att ändra de underliggande siffrorna; exempelvis visas 0,25 som 25,00 %. Axel- och datatetikettformat kan konfigureras separat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    let series = chart.getChartData().getSeries();

    for (let i = 0; i < series.size(); i++) {
        let chartSeries = series.get_Item(i);
        for (let j = 0; j < chartSeries.getDataPoints().size(); j++) {
            let dataPoint = chartSeries.getDataPoints().get_Item(j);
            dataPoint.getValue().getAsCell().setPresetNumberFormat(java.newByte(10)); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Följande tabell listar inbyggda talformatindex med representativa Excel-format för den engelska (USA) lokalen. De exakta formatsträngarna och deras visning kan variera mellan program och lokaler, särskilt för valuta och datum. Vissa Excel-format skiljer sig också från standardvärdena i OOXML‑standarden, enligt [Microsofts anteckningar om implementering av talformat](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Ställ in rundade kanter för diagramområde**

Anropa [Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) med `true` för att göra hörnen på diagramområdet rundade. Exemplet skapar ett hopgruppat stapeldiagram och använder [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) för att ge dess kontur en solid grå färg och en enkellinjefärg innan presentationen sparas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chart.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Redigera befintliga diagramanteckningar**

Ett diagram kan innehålla anpassade former, t.ex. en textanteckning som förklarar status för en rapport. Åtkomst till dessa former sker via [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes). Samlingen som returneras av [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) innehåller diagrammets egna former.

En vanlig textruta placerad ovanpå ett diagram tillhör bilden, även om den ser ut som en del av diagrammet. Att iterera genom [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) hittar diagrammet och vanliga bildformer, men räknar inte upp de enskilda formerna inuti diagrammet. Diagramtitlar och datalabels är separata diagramelement, inte anpassade anteckningar i denna samling.

Ladda ner [chart-annotations.pptx](chart-annotations.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller ett diagram med en ogrupperad anteckning med texten "Preliminary results", en diagramägd linje och en vanlig bildtextruta med texten "Slide overlay". Exemplet hittar det första diagrammet på den bilden och ändrar anteckningen till "Final results" när rapporten är redo att publiceras. Det kontrollerar om samlingen är tom och redigerar endast en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) med en icke‑null textram som returneras av [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) och den förväntade texten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("chart-annotations.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = null;
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
            chart = shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        console.log("No chart or chart-owned shapes found.");
    } else {
        let updated = false;
        for (let i = 0; i < chart.getUserShapes().getShapes().size(); i++) {
            let shape = chart.getUserShapes().getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let annotation = shape;
                if (annotation.getTextFrame() != null && annotation.getTextFrame().getText() === "Preliminary results") {
                    annotation.getTextFrame().setText("Final results");
                    updated = true;
                    break;
                }
            }
        }

        if (updated) {
            presentation.save("chart-annotations-updated.pptx", aspose.slides.SaveFormat.Pptx);
        } else {
            console.log("No matching text annotation found.");
        }
    }
} finally {
    presentation.dispose();
}
```

Linjen och bildtextrutan förblir oförändrade. Följande bilder visar indata och det sparade, återöppnade resultatet:

| Before editing | After editing |
| --- | --- |
| ![Diagramanteckning med texten Preliminära resultat](chart-annotations-before.png) | ![Diagramanteckning med texten Slutresultat](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Exemplet inspekterar endast diagrammets egna former på toppnivå. Om en anteckning finns inuti en [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), inspektera även den gruppens [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes)-samling. Upprepa detta rekursivt för nästlade grupper och tillämpa samma textkontroller på deras underordnade former. En grupp i sig är en behållare; behandla den inte som en textruta.
{{% /alert %}}

## **FAQ**

**Kan jag ange halvgenomskinliga fyllningar för staplar/områden samtidigt som kantlinjen förblir ogenomskinlig?**

Ja. Fyllnadens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten i rutnätet och data i täta visualiseringar.

**Hur kan jag hantera datalabels när de överlappar?**

Minska teckenstorleken, inaktivera icke‑nödvändiga etikettkomponenter (t.ex. kategorier), justera etikettens position, visa etiketter endast för utvalda punkter om det behövs, eller byt formatet till "värde + förklaring".

**Kan jag tillämpa gradient- eller mönsterfyllningar på serier?**

Ja. Serier stöder solida, gradient‑ och mönsterfyllningar. I praktiken bör gradienter användas sparsamt och undvika kombinationer som minskar kontrasten mot rutnätet och texten.