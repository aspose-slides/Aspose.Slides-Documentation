---
title: Beheer callouts in presentatiediagrammen met Python
linktitle: Uitlegballon
type: docs
url: /nl/python-java/callout/
keywords:
- grafiek callout
- callout gebruiken
- databelabel
- labelopmaak
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Creëer en style callouts in Aspose.Slides voor Python via Java met beknopte codevoorbeelden, compatibel met PPT en PPTX om presentatiewerkstromen te automatiseren."
---
## **Overzicht**

Dit artikel legt uit hoe je met callouts voor grafiekdatavelden in Aspose.Slides werkt. Het laat zien hoe je de [setShowLabelAsDataCallout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout)‑methode gebruikt om labels als callouts weer te geven, hoe je callout‑gerelateerde labelinstellingen voor een donutgrafiek configureert, en vermeldt dat callouts en hun uiterlijk behouden blijven wanneer presentaties worden geëxporteerd naar PDF, HTML5, SVG en raster‑afbeeldingsformaten.

## **Callouts gebruiken**

De [getShowLabelAsDataCallout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout)‑ en [setShowLabelAsDataCallout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout)‑methoden van de [DataLabelFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabelformat/)‑klasse bepalen of een grafiekdataveld wordt weergegeven als een callout of als een standaarddataveld.

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

## **Een callout instellen voor een donutgrafiek**

Aspose.Slides for Python via Java ondersteunt het instellen van de callout‑vorm voor de reeksdatavelden van een donutgrafiek. Het volgende voorbeeld toont dit.

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

**Worden callouts behouden bij het converteren van een presentatie naar PDF, HTML5, SVG of afbeeldingen?**

Ja. Callouts maken deel uit van de grafiekrendering, dus wanneer je exporteert naar [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/nl/python-java/export-to-html5/), [SVG](/slides/nl/python-java/render-a-slide-as-an-svg-image/) of [raster‑afbeeldingen](/slides/nl/python-java/convert-powerpoint-to-png/), blijven ze behouden samen met de opmaak van de dia.

**Werken aangepaste lettertypen in callouts, en kan hun uiterlijk behouden blijven bij export?**

Ja. Aspose.Slides ondersteunt [embedding fonts](/slides/nl/python-java/embedded-font/) in de presentatie en regelt het insluiten van lettertypen tijdens exporten zoals [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/), waardoor de callouts er op verschillende systemen hetzelfde uitzien.