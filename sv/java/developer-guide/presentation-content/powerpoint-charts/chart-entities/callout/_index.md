---
title: Hantera callouts i presentationsdiagram med Java
linktitle: Callout
type: docs
url: /sv/java/callout/
keywords:
- diagram-callout
- använd callout
- datamärkning
- etikettformat
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa och formatera callouts i Aspose.Slides för Java med koncisa kodexempel, kompatibla med PPT och PPTX för att automatisera presentationsarbetsflöden."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med callouts för diagramdatamärkning i Aspose.Slides. Den visar hur man använder metoden `setShowLabelAsDataCallout` för att visa märken som callouts, hur man konfigurerar callout‑relaterade märkesinställningar för ett munkdiagram, samt påpekar att callouts och deras utseende bevaras när presentationer exporteras till PDF, HTML5, SVG och rasterbildformat.

## **Använda callouts**
Nya metoder [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) och [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) har lagts till i klassen [DataLabelFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/datalabelformat) och gränssnittet [IDataLabelFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idatalabelformat). Dessa metoder bestämmer om en specificerad diagrams datamärkning ska visas som data‑callout eller som datamärkning.

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

## **Ställ in en callout för ett munkdiagram**
Aspose.Slides för Java erbjuder stöd för att ange seriedatamärknings‑callout‑form för ett munkdiagram. Nedan ges ett exempel på kod.

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

**Behålls callouts när en presentation konverteras till PDF, HTML5, SVG eller bilder?**

Ja. Callouts är en del av diagramåtergivningen, så när du exporterar till [PDF](/slides/sv/java/convert-powerpoint-to-pdf/), [HTML5](/slides/sv/java/export-to-html5/), [SVG](/slides/sv/java/render-a-slide-as-an-svg-image/) eller [rasterbilder](/slides/sv/java/convert-powerpoint-to-png/) bevaras de tillsammans med bildens formatering.

**Fungerar anpassade teckensnitt i callouts, och kan deras utseende bevaras vid export?**

Ja. Aspose.Slides stöder [inbäddning av teckensnitt](/slides/sv/java/embedded-font/) i presentationen och styr teckensnittsinbäddning vid export, exempelvis till [PDF](/slides/sv/java/convert-powerpoint-to-pdf/), vilket säkerställer att callouts ser likadana ut på olika system.