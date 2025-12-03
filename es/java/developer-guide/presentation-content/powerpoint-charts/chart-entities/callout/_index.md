---
title: Administrar callouts en gráficos de presentación con Java
linktitle: Llamada
type: docs
url: /es/java/callout/
keywords:
- callout de gráfico
- usar callout
- etiqueta de datos
- formato de etiqueta
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Cree y diseñe callouts en Aspose.Slides para Java con ejemplos de código concisos, compatibles con PPT y PPTX para automatizar flujos de trabajo de presentación."
---

## **Uso de Callouts**
Se han añadido los nuevos métodos [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) y [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) a la clase [DataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/datalabelformat) y a la interfaz [IDataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat). Estos métodos determinan si la etiqueta de datos del gráfico especificado se mostrará como llamada de datos o como etiqueta de datos.
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


## **Establecer Callout para gráfico de dona**
Aspose.Slides for Java ofrece soporte para establecer la forma de la llamada de etiqueta de datos de serie para un gráfico de dona. A continuación se muestra un ejemplo.
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


## **Preguntas frecuentes**

**¿Se conservan los callouts al convertir una presentación a PDF, HTML5, SVG o imágenes?**

Sí. Los callouts forman parte del renderizado del gráfico, por lo que al exportar a [PDF](/slides/es/java/convert-powerpoint-to-pdf/), [HTML5](/slides/es/java/export-to-html5/), [SVG](/slides/es/java/render-a-slide-as-an-svg-image/) o [raster images](/slides/es/java/convert-powerpoint-to-png/), se conservan junto con el formato de la diapositiva.

**¿Funcionan las fuentes personalizadas en los callouts y se puede conservar su apariencia al exportar?**

Sí. Aspose.Slides soporta [embedding fonts](/slides/es/java/embedded-font/) en la presentación y controla la incrustación de fuentes durante exportaciones como [PDF](/slides/es/java/convert-powerpoint-to-pdf/), asegurando que los callouts mantengan el mismo aspecto en diferentes sistemas.