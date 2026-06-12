---
title: Beheer callouts in presentatiediagrammen met JavaScript
linktitle: Callout
type: docs
url: /nl/nodejs-java/callout/
keywords:
- grafiek callout
- callout gebruiken
- gegevenslabel
- labelindeling
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en style callouts in Aspose.Slides voor Node.js via Java met beknopte codevoorbeelden, compatibel met PPT en PPTX om presentatieworkflows te automatiseren."
---
## **Overzicht**

Dit artikel legt uit hoe u met callouts voor gegevenslabels van grafieken in Aspose.Slides kunt werken. Het laat zien hoe u de `setShowLabelAsDataCallout`-methode gebruikt om labels als callouts weer te geven, hoe u callout‑gerelateerde labelinstellingen voor een donutgrafiek configureert, en merkt op dat callouts en hun weergave behouden blijven wanneer presentaties worden geëxporteerd naar PDF, HTML5, SVG en rasterafbeeldingsformaten.

## **Callouts gebruiken**

Nieuwe methoden [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) en [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) zijn toegevoegd aan de klasse [DataLabelFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabelformat) en [DataLabelFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabelformat). Deze methoden bepalen of het gegevenslabel van de opgegeven grafiek wordt weergegeven als data‑callout of als gegevenslabel.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Callout instellen voor donutgrafiek**

Aspose.Slides for Node.js via Java biedt ondersteuning voor het instellen van de callout‑vorm van serie‑gegevenslabels voor een donutgrafiek. Hieronder staat een voorbeeld.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Worden callouts behouden bij het converteren van een presentatie naar PDF, HTML5, SVG of afbeeldingen?**

Ja. Callouts maken deel uit van de grafiekweergave, dus wanneer u exporteert naar [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/nl/nodejs-java/export-to-html5/), [SVG](/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/) of [rasterafbeeldingen](/slides/nl/nodejs-java/convert-powerpoint-to-png/), blijven ze behouden samen met de opmaak van de dia.

**Werken aangepaste lettertypen in callouts, en kan hun weergave behouden blijven bij export?**

Ja. Aspose.Slides ondersteunt het [inbedden van lettertypen](/slides/nl/nodejs-java/embedded-font/) in de presentatie en regelt het inbedden van lettertypen tijdens exporten zoals [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), waardoor de callouts er op verschillende systemen identiek uitzien.