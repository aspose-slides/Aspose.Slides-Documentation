---
title: Gestisci i callout nei grafici delle presentazioni su Android
linktitle: Callout
type: docs
url: /it/androidjava/callout/
keywords:
- callout grafico
- usare callout
- etichetta dati
- formato etichetta
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea e formatta i callout in Aspose.Slides per Android con esempi di codice Java concisi, compatibili con PPT e PPTX per automatizzare i flussi di lavoro delle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con i callout per le etichette dei dati dei grafici in Aspose.Slides. Mostra come usare il metodo `setShowLabelAsDataCallout` per visualizzare le etichette come callout, come configurare le impostazioni delle etichette correlate ai callout per un grafico a ciambella e osserva che i callout e il loro aspetto sono conservati quando le presentazioni vengono esportate in PDF, HTML5, SVG e formati di immagine raster.

## **Uso dei Callout**
Sono stati aggiunti i nuovi metodi [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) e [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) alla classe [DataLabelFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/datalabelformat) e all'interfaccia [IDataLabelFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idatalabelformat). Questi metodi determinano se l’etichetta dei dati del grafico specificato sarà visualizzata come callout o come etichetta dati.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta un Callout per un Grafico a Ciambella**
Aspose.Slides per Android tramite Java fornisce il supporto per impostare la forma del callout dell’etichetta di serie dati per un grafico a ciambella. Di seguito è riportato un esempio.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**I callout vengono conservati quando si converte una presentazione in PDF, HTML5, SVG o immagini?**

Sì. I callout fanno parte del rendering del grafico, quindi quando si esporta in [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), [HTML5](/slides/it/androidjava/export-to-html5/), [SVG](/slides/it/androidjava/render-a-slide-as-an-svg-image/), o [immagini raster](/slides/it/androidjava/convert-powerpoint-to-png/), vengono conservati insieme alla formattazione della diapositiva.

**I font personalizzati funzionano nei callout e il loro aspetto può essere conservato durante l'esportazione?**

Sì. Aspose.Slides supporta [l'incorporamento dei font](/slides/it/androidjava/embedded-font/) nella presentazione e controlla l’incorporamento dei font durante le esportazioni come [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), garantendo che i callout abbiano lo stesso aspetto su sistemi diversi.