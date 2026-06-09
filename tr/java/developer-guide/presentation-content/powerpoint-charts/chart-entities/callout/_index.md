---
title: Java Kullanarak Sunum Grafiklerinde Callout'ları Yönetme
linktitle: Callout
type: docs
url: /tr/java/callout/
keywords:
- grafik çağrısı
- callout kullanımı
- veri etiketi
- etiket biçimi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da callout'ları oluşturun ve biçimlendirin, kısa kod örnekleriyle, PPT ve PPTX ile uyumlu olarak sunum iş akışlarını otomatikleştirin."
---
## **Overview**

Bu makale, Aspose.Slides'da grafik veri etiketleri için callout'larla nasıl çalışılacağını açıklar. `setShowLabelAsDataCallout` yönteminin etiketleri callout olarak görüntülemek için nasıl kullanılacağını, bir doughnut grafik için callout ile ilgili etiket ayarlarının nasıl yapılandırılacağını ve callout'ların ve görünümlerinin sunumlar PDF, HTML5, SVG ve raster görüntü formatlarına dışa aktarıldığında korunduğunu belirtir.

## **Using Callouts**
Yeni [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) ve [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) yöntemleri [DataLabelFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/datalabelformat) sınıfına ve [IDataLabelFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idatalabelformat) arayüzüne eklenmiştir. Bu yöntemler, belirtilen grafiğin veri etiketinin veri callout olarak mı yoksa veri etiketi olarak mı görüntüleneceğini belirler.

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

## **Set a Callout for a Doughnut Chart**
Aspose.Slides for Java, bir Doughnut grafik için serinin veri etiketi callout şekli ayarlamayı destekler. Aşağıda örnek bir kod verilmiştir.

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

**Are callouts preserved when converting a presentation to PDF, HTML5, SVG, or images?**

Evet. Callout'lar grafik render'ının bir parçasıdır, bu yüzden [PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [HTML5](/slides/tr/java/export-to-html5/), [SVG](/slides/tr/java/render-a-slide-as-an-svg-image/) veya [raster images](/slides/tr/java/convert-powerpoint-to-png/) formatlarına dışa aktardığınızda, slaytın biçimlendirmesiyle birlikte korunur.

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

Evet. Aspose.Slides, sunuma [embedding fonts](/slides/tr/java/embedded-font/) eklemeyi destekler ve [PDF](/slides/tr/java/convert-powerpoint-to-pdf/) gibi dışa aktarımlarda yazı tipi yerleşimini kontrol eder, böylece callout'lar farklı sistemlerde aynı şekilde görünür.