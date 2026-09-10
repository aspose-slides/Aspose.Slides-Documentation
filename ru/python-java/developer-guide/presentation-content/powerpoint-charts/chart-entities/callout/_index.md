---
title: Управление выносками в диаграммах презентаций с использованием Python
linktitle: Выноска
type: docs
url: /ru/python-java/callout/
keywords:
- выноска диаграммы
- использование выноски
- подпись данных
- формат подписи
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте и оформляйте выноски в Aspose.Slides for Python via Java с помощью лаконичных примеров кода, совместимых с PPT и PPTX, для автоматизации рабочих процессов презентаций."
---
## **Обзор**

В этой статье объясняется, как работать с выносками для подписей данных диаграммы в Aspose.Slides. Показано, как использовать метод [setShowLabelAsDataCallout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) для отображения подписей в виде выноски, как настроить параметры меток, связанных с выноской, для кольцевой диаграммы, и отмечено, что выноски и их внешний вид сохраняются при экспорте презентаций в PDF, HTML5, SVG и растровые форматы изображений.

## **Использование выносок**

Методы [getShowLabelAsDataCallout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) и [setShowLabelAsDataCallout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) класса [DataLabelFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/) определяют, отображается ли подпись данных диаграммы как выноска или как обычная подпись.

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

## **Установка выноски для кольцевой диаграммы**

Aspose.Slides for Python via Java поддерживает установку формы выноски подписи данных серии для кольцевой диаграммы. Ниже приведён пример, демонстрирующий это.

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

**Сохраняются ли выноски при преобразовании презентации в PDF, HTML5, SVG или изображения?**

Да. Выноски являются частью отрисовки диаграммы, поэтому при экспорте в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/ru/python-java/export-to-html5/), [SVG](/slides/ru/python-java/render-a-slide-as-an-svg-image/), или [растровые изображения](/slides/ru/python-java/convert-powerpoint-to-png/), они сохраняются вместе с форматированием слайда.

**Работают ли пользовательские шрифты в выносках, и может ли их внешний вид сохраняться при экспорте?**

Да. Aspose.Slides поддерживает [встраивание шрифтов](/slides/ru/python-java/embedded-font/) в презентацию и управляет встраиванием шрифтов при экспорте, например в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), обеспечивая одинаковый внешний вид выносок на разных системах.