---
title: Hantera diagramdataetiketter i presentationer med JavaScript
linktitle: Dataetikett
type: docs
url: /sv/nodejs-java/chart-data-label/
keywords:
- diagram
- dataetikett
- dataprecision
- procent
- etikettavstånd
- etikettposition
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdataetiketter i PowerPoint-presentationer med JavaScript och Aspose.Slides för Node.js via Java för mer engagerande bildspel."
---
## **Introduction**

Dataetiketter i ett diagram visar detaljer om diagrammets dataserier eller enskilda datapunkter. De gör det möjligt för läsare att snabbt identifiera dataserier och de gör också diagrammen lättare att förstå.

## **Set Precision of Data in Chart Data Labels**

Denna JavaScript‑kod visar hur du anger dataprecision i en diagramdataetikett:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Display Percentage as Labels**

Aspose.Slides för Node.js via Java låter dig ange procentsatsetiketter i visade diagram. Denna JavaScript‑kod demonstrerar hur det fungerar:

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // Sparar presentationen som innehåller diagrammet
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Percentage Sign with Chart Data Labels**

Denna JavaScript‑kod visar hur du anger procentsymbolen för en diagramdataetikett:

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Hämtar en bilds referens via dess index
    var slide = pres.getSlides().get_Item(0);
    // Skapar diagrammet PercentsStackedColumn på en bild
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // Ställer in NumberFormatLinkedToSource till false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // Hämtar diagrammets dataarbetsblad
    var workbook = chart.getChartData().getChartDataWorkbook();
    // Lägger till ny serie
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // Ställer in fyllningsfärgen för serien
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Ställer in egenskaperna för LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Lägger till ny serie
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // Ställer in fyllningstyp och färg
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // Skriver presentationen till disk
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Label Distances from Axis**

Denna JavaScript‑kod visar hur du anger etikettavståndet från en kategori­axel när du arbetar med ett diagram som ritas från axlar:

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Hämtar en bilds referens
    var sld = pres.getSlides().get_Item(0);
    // Skapar ett diagram på bilden
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // Ställer in etikettavståndet från en axel
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // Skriver presentationen till disk
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adjust Label Location**

När du skapar ett diagram som inte bygger på någon axel, såsom ett cirkeldiagram, kan diagrammets dataetiketter hamna för nära kanten. I så fall måste du justera placeringen av dataetiketten så att förbindelselänkarna visas tydligt.

Denna JavaScript‑kod visar hur du justerar etikettpositionen i ett cirkeldiagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Hur kan jag förhindra att dataetiketter överlappar i täta diagram?**

Kombinera automatisk etikettplacering, förbindelselänkar och minskad teckenstorlek; vid behov, dölj vissa fält (t.ex. kategorin) eller visa etiketter endast för extrema/nyckelpunkter.

**Hur kan jag inaktivera etiketter enbart för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan du aktiverar etiketter och stäng av visning för värden som är 0, negativa eller saknade enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettstil vid export till PDF/bilder?**

Ange tydligt teckensnitt (familj, storlek) och verifiera att teckensnittet är tillgängligt på renderingssidan för att undvika reservteckensnitt.