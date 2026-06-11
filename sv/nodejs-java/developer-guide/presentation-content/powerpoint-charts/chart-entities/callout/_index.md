---
title: Hantera callouts i presentationsdiagram med JavaScript
linktitle: Callout
type: docs
url: /sv/nodejs-java/callout/
keywords:
- diagram‑callout
- använd callout
- datapunktetikett
- etikettformat
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och formatera callouts i Aspose.Slides för Node.js via Java med koncisa kodexempel, kompatibla med PPT och PPTX för att automatisera presentationsarbetsflöden."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med callouts för diagrammets datapunktetiketter i Aspose.Slides. Den visar hur du använder metoden `setShowLabelAsDataCallout` för att visa etiketter som callouts, hur du konfigurerar callout‑relaterade etikettinställningar för ett doughnut-diagram, och noterar att callouts och deras utseende bevaras när presentationer exporteras till PDF, HTML5, SVG och rasterbildformat.

## **Använda callouts**

Nya metoderna [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) och [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) har lagts till i klassen [DataLabelFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabelformat). Dessa metoder bestämmer om diagrammets datapunktetikett ska visas som data‑callout eller som datapunktetikett.

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

## **Ange callout för doughnut-diagram**

Aspose.Slides för Node.js via Java erbjuder stöd för att ställa in serie‑datapunktetikettens callout‑form för ett doughnut-diagram. Nedanstående exempel ges.

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

## **Vanliga frågor**

**Bevaras callouts när en presentation konverteras till PDF, HTML5, SVG eller bilder?**

Ja. Callouts är en del av diagramrenderingen, så när du exporterar till [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/sv/nodejs-java/export-to-html5/), [SVG](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/) eller [rasterbilder](/slides/sv/nodejs-java/convert-powerpoint-to-png/), bevaras de tillsammans med bildens formatering.

**Fungerar anpassade typsnitt i callouts, och kan deras utseende bevaras vid export?**

Ja. Aspose.Slides stödjer [inbäddning av typsnitt](/slides/sv/nodejs-java/embedded-font/) i presentationen och hanterar typsnittsinbäddning under export, såsom [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/), vilket säkerställer att callouts ser likadana ut på olika system.