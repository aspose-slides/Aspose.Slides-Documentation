---
title: Gerenciar chamadas em gráficos de apresentação no Android
linktitle: Chamada
type: docs
url: /pt/androidjava/callout/
keywords:
- chamada de gráfico
- usar chamada
- rótulo de dados
- formato de rótulo
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Crie e estilize chamadas no Aspose.Slides para Android com exemplos concisos de código Java, compatíveis com PPT e PPTX para automatizar fluxos de trabalho de apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com chamadas para rótulos de dados de gráficos no Aspose.Slides. Ele mostra como usar o método `setShowLabelAsDataCallout` para exibir rótulos como chamadas, como configurar as configurações de rótulo relacionadas a chamadas para um gráfico de rosca e observa que as chamadas e sua aparência são preservadas quando as apresentações são exportadas para PDF, HTML5, SVG e formatos de imagem raster.

## **Usando chamadas**
Novos métodos [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) e [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) foram adicionados à classe [DataLabelFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/datalabelformat) e à interface [IDataLabelFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idatalabelformat). Esses métodos determinam se o rótulo de dados do gráfico especificado será exibido como chamada de dados ou como rótulo de dados.

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

## **Definir uma chamada para um gráfico de rosca**
Aspose.Slides para Android via Java oferece suporte à definição da forma de chamada de rótulo de dados da série para um gráfico de rosca. A seguir, exemplo de amostra é fornecido.

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

## **Perguntas frequentes**

**As chamadas são preservadas ao converter uma apresentação para PDF, HTML5, SVG ou imagens?**

Sim. As chamadas fazem parte da renderização do gráfico, portanto, ao exportar para [PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/), [HTML5](/slides/pt/androidjava/export-to-html5/), [SVG](/slides/pt/androidjava/render-a-slide-as-an-svg-image/) ou [imagens raster](/slides/pt/androidjava/convert-powerpoint-to-png/), elas são preservadas juntamente com a formatação do slide.

**Fontes personalizadas funcionam nas chamadas e sua aparência pode ser preservada na exportação?**

Sim. O Aspose.Slides oferece suporte à [incorporação de fontes](/slides/pt/androidjava/embedded-font/) na apresentação e controla a incorporação de fontes durante exportações como [PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/), garantindo que as chamadas mantenham a mesma aparência em diferentes sistemas.