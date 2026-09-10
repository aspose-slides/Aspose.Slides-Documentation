---
title: Administrar callouts en gráficos de presentación usando Python
linktitle: Callout
type: docs
url: /es/python-java/callout/
keywords:
- callout de gráfico
- usar callout
- etiqueta de datos
- formato de etiqueta
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crea y da estilo a los callouts en Aspose.Slides para Python via Java con ejemplos de código concisos, compatibles con PPT y PPTX para automatizar flujos de trabajo de presentaciones."
---
## **Descripción general**

Este artículo explica cómo trabajar con los callouts para las etiquetas de datos de un gráfico en Aspose.Slides. Muestra cómo usar el método [setShowLabelAsDataCallout](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) para mostrar las etiquetas como callouts, cómo configurar los ajustes de etiquetas relacionados con los callouts para un gráfico de rosquilla, y señala que los callouts y su apariencia se conservan cuando las presentaciones se exportan a PDF, HTML5, SVG y formatos de imagen raster.

## **Uso de callouts**

Los métodos [getShowLabelAsDataCallout](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) y [setShowLabelAsDataCallout](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) de la clase [DataLabelFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/) determinan si una etiqueta de datos del gráfico se muestra como callout o como una etiqueta de datos normal.

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

## **Establecer un callout para un gráfico de rosquilla**

Aspose.Slides for Python via Java admite la configuración de la forma de callout de la etiqueta de datos de la serie para un gráfico de rosquilla. El siguiente ejemplo lo demuestra.

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

## **Preguntas frecuentes**

**¿Se conservan los callouts al convertir una presentación a PDF, HTML5, SVG o imágenes?**

Sí. Los callouts forman parte del renderizado del gráfico, por lo que al exportar a [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/es/python-java/export-to-html5/), [SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/), o [imágenes raster](/slides/es/python-java/convert-powerpoint-to-png/), se conservan junto con el formato de la diapositiva.

**¿Funcionan las fuentes personalizadas en los callouts y puede preservarse su apariencia al exportar?**

Sí. Aspose.Slides admite [incrustar fuentes](/slides/es/python-java/embedded-font/) en la presentación y controla la incrustación de fuentes durante exportaciones como [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), asegurando que los callouts se vean igual en diferentes sistemas.