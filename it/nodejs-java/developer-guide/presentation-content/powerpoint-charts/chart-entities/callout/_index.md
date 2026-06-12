---
title: Gestire i callout nei grafici delle presentazioni usando JavaScript
linktitle: Callout
type: docs
url: /it/nodejs-java/callout/
keywords:
- callout del grafico
- utilizzare callout
- etichetta dati
- formato etichetta
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea e formatta i callout in Aspose.Slides per Node.js tramite Java con esempi di codice concisi, compatibili con PPT e PPTX per automatizzare i flussi di lavoro delle presentazioni."
---
## **Panoramica**

Questo articolo spiega come utilizzare i callout per le etichette dei dati del grafico in Aspose.Slides. Mostra come usare il metodo `setShowLabelAsDataCallout` per visualizzare le etichette come callout, come configurare le impostazioni delle etichette correlate ai callout per un grafico a ciambella e osserva che i callout e il loro aspetto vengono preservati quando le presentazioni vengono esportate in PDF, HTML5, SVG e formati di immagine raster.

## **Utilizzo dei Callout**

Sono stati aggiunti i nuovi metodi [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) e [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) alla classe [DataLabelFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datalabelformat) e alla classe [DataLabelFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datalabelformat). Questi metodi determinano se l'etichetta dei dati del grafico specificato verrà visualizzata come callout o come etichetta dei dati.

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

## **Impostare il Callout per il Grafico a Ciambella**

Aspose.Slides per Node.js via Java fornisce il supporto per impostare la forma del callout dell'etichetta dei dati della serie per un grafico a ciambella. Di seguito è riportato un esempio di codice.

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

**I callout vengono preservati durante la conversione di una presentazione in PDF, HTML5, SVG o immagini?**

Sì. I callout fanno parte del rendering del grafico, quindi quando si esporta in [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/it/nodejs-java/export-to-html5/), [SVG](/slides/it/nodejs-java/render-a-slide-as-an-svg-image/) o [immagini raster](/slides/it/nodejs-java/convert-powerpoint-to-png/), vengono preservati insieme alla formattazione della diapositiva.

**I caratteri personalizzati funzionano nei callout e il loro aspetto può essere preservato durante l'esportazione?**

Sì. Aspose.Slides supporta [l'incorporamento dei caratteri](/slides/it/nodejs-java/embedded-font/) nella presentazione e gestisce l'incorporamento dei caratteri durante le esportazioni, ad esempio in [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), garantendo che i callout mantengano lo stesso aspetto su sistemi diversi.