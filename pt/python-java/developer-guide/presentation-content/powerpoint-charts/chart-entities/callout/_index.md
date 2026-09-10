---
title: Gerenciar Callouts em Gráficos de Apresentação usando Python
linktitle: Callout
type: docs
url: /pt/python-java/callout/
keywords:
- callout de gráfico
- usar callout
- rótulo de dados
- formato de rótulo
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Crie e estilize callouts no Aspose.Slides para Python via Java com exemplos de código concisos, compatíveis com PPT e PPTX para automatizar fluxos de trabalho de apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com callouts para rótulos de dados de gráfico no Aspose.Slides. Ele mostra como usar o método [setShowLabelAsDataCallout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) para exibir rótulos como callouts, como configurar as definições de rótulo relacionadas a callouts para um gráfico de rosca e observa que os callouts e sua aparência são preservados quando as apresentações são exportadas para PDF, HTML5, SVG e formatos de imagem raster.

## **Usando Callouts**

Os métodos [getShowLabelAsDataCallout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) e [setShowLabelAsDataCallout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) da classe [DataLabelFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datalabelformat/) determinam se um rótulo de dados de gráfico é exibido como um callout ou como um rótulo de dados padrão.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir um Callout para um Gráfico de Rosca**

Aspose.Slides for Python via Java suporta a definição da forma de callout de rótulo de dados da série para um gráfico de rosca. O exemplo a seguir demonstra isso.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Os callouts são preservados ao converter uma apresentação para PDF, HTML5, SVG ou imagens?**

Sim. Os callouts fazem parte da renderização do gráfico, portanto, ao exportar para [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/pt/python-java/export-to-html5/), [SVG](/slides/pt/python-java/render-a-slide-as-an-svg-image/), ou [raster images](/slides/pt/python-java/convert-powerpoint-to-png/), eles são preservados juntamente com a formatação do slide.

**Fontes personalizadas funcionam em callouts e sua aparência pode ser preservada na exportação?**

Sim. Aspose.Slides suporta [embedding fonts](/slides/pt/python-java/embedded-font/) na apresentação e controla a incorporação de fontes durante exportações como [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/), garantindo que os callouts tenham a mesma aparência em diferentes sistemas.