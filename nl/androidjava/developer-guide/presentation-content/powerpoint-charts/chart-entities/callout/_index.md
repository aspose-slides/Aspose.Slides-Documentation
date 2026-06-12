---
title: Callouts beheren in presentatiediagrammen op Android
linktitle: Callout
type: docs
url: /nl/androidjava/callout/
keywords:
- grafiek-callout
- callout gebruiken
- gegevenslabel
- labelopmaak
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en style callouts in Aspose.Slides voor Android met beknopte Java-codevoorbeelden, compatibel met PPT en PPTX om presentatieworkflows te automatiseren."
---
## **Overzicht**

Dit artikel legt uit hoe u met callouts voor gegevenslabels in diagrammen werkt in Aspose.Slides. Het toont hoe u de `setShowLabelAsDataCallout`‑methode gebruikt om labels als callouts weer te geven, hoe u callout‑gerelateerde labelinstellingen voor een donut‑diagram configureert, en vermeldt dat callouts en hun uiterlijk behouden blijven wanneer presentaties worden geëxporteerd naar PDF, HTML5, SVG en raster‑afbeeldingsformaten.

## **Callouts gebruiken**
Nieuwe methoden [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) en [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) zijn toegevoegd aan de klasse [DataLabelFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/datalabelformat) en de interface [IDataLabelFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idatalabelformat). Deze methoden bepalen of het gegevenslabel van het opgegeven diagram wordt weergegeven als data‑callout of als gegevenslabel.

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

## **Callout instellen voor een donut‑diagram**
Aspose.Slides voor Android via Java biedt ondersteuning voor het instellen van de callout‑vorm van de gegevenslabelreeks voor een donut‑diagram. Hieronder staat een voorbeeld.

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

**Worden callouts behouden bij het converteren van een presentatie naar PDF, HTML5, SVG of afbeeldingen?**

Ja. Callouts maken deel uit van de weergave van het diagram, dus wanneer u exporteert naar [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), [HTML5](/slides/nl/androidjava/export-to-html5/), [SVG](/slides/nl/androidjava/render-a-slide-as-an-svg-image/) of [rasterafbeeldingen](/slides/nl/androidjava/convert-powerpoint-to-png/), blijven ze behouden samen met de opmaak van de dia.

**Werken aangepaste lettertypen in callouts, en kan hun uiterlijk behouden blijven bij export?**

Ja. Aspose.Slides ondersteunt het [inbedden van lettertypen](/slides/nl/androidjava/embedded-font/) in de presentatie en regelt het inbedden van lettertypen tijdens exporten zoals [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), waardoor de callouts er op verschillende systemen identiek uitzien.