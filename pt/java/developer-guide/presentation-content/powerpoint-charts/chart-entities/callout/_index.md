---
title: Gerenciar Callouts em Gráficos de Apresentação Usando Java
linktitle: Chamada
type: docs
url: /pt/java/callout/
keywords:
- callout de gráfico
- usar callout
- rótulo de dados
- formato de rótulo
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Crie e estilize callouts no Aspose.Slides para Java com exemplos de código concisos, compatíveis com PPT e PPTX para automatizar fluxos de trabalho de apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com callouts para rótulos de dados de gráficos no Aspose.Slides. Ele mostra como usar o método `setShowLabelAsDataCallout` para exibir rótulos como callouts, como configurar as definições de rótulo relacionadas a callouts para um gráfico Doughnut e observa que os callouts e sua aparência são preservados ao exportar apresentações para PDF, HTML5, SVG e formatos de imagem raster.

## **Usando Callouts**
Novos métodos [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) e [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) foram adicionados à classe [DataLabelFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/datalabelformat) e à interface [IDataLabelFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idatalabelformat). Esses métodos determinam se o rótulo de dados do gráfico especificado será exibido como callout de dados ou como rótulo de dados.

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

## **Definir um Callout para um Gráfico Doughnut**
Aspose.Slides for Java fornece suporte para definir a forma do callout de rótulo de dados da série para um gráfico Doughnut. O exemplo abaixo é fornecido.

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

**As chamadas são preservadas ao converter uma apresentação para PDF, HTML5, SVG ou imagens?**

Sim. As chamadas fazem parte da renderização do gráfico, portanto, ao exportar para [PDF](/slides/pt/java/convert-powerpoint-to-pdf/), [HTML5](/slides/pt/java/export-to-html5/), [SVG](/slides/pt/java/render-a-slide-as-an-svg-image/), ou [raster images](/slides/pt/java/convert-powerpoint-to-png/), elas são preservadas junto com a formatação do slide.

**Fontes personalizadas funcionam em chamadas e sua aparência pode ser preservada na exportação?**

Sim. Aspose.Slides suporta [embedding fonts](/slides/pt/java/embedded-font/) na apresentação e controla a incorporação de fontes durante exportações como [PDF](/slides/pt/java/convert-powerpoint-to-pdf/), garantindo que os callouts tenham a mesma aparência em diferentes sistemas.