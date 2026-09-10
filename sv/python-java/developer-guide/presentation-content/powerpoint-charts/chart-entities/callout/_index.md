---
title: Hantera pratbubblor i presentationsdiagram med Python
linktitle: Pratbubbla
type: docs
url: /sv/python-java/callout/
keywords:
- diagrampratbubbla
- använd pratbubbla
- datamärkning
- etikettformat
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa och formatera pratbubblor i Aspose.Slides för Python via Java med korta kodexempel, kompatibla med PPT och PPTX för att automatisera presentationsarbetsflöden."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med pratbubblor för diagramdatamärkning i Aspose.Slides. Den visar hur du använder metoden [setShowLabelAsDataCallout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) för att visa etiketter som pratbubblor, hur du konfigurerar etikettinställningar relaterade till pratbubblor för ett ringdiagram, samt noterar att pratbubblor och deras utseende bevaras när presentationer exporteras till PDF, HTML5, SVG och rasterbildformat.

## **Använda pratbubblor**

Metoderna [getShowLabelAsDataCallout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) och [setShowLabelAsDataCallout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) i klassen [DataLabelFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datalabelformat/) bestämmer om en diagramdatamärkning visas som en pratbubbla eller som en vanlig datamärkning.

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

## **Ställ in en pratbubbla för ett ringdiagram**

Aspose.Slides för Python via Java stödjer att ställa in serie‑datamärkningspratbubblans form för ett ringdiagram. Följande exempel demonstrerar detta.

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

## **Vanliga frågor**

**Följs pratbubblor med när en presentation konverteras till PDF, HTML5, SVG eller bilder?**

Ja. Pratbubblor är en del av diagramrenderingen, så när du exporterar till [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/sv/python-java/export-to-html5/), [SVG](/slides/sv/python-java/render-a-slide-as-an-svg-image/), eller [raster images](/slides/sv/python-java/convert-powerpoint-to-png/), bevaras de tillsammans med bildens formatering.

**Fungerar anpassade typsnitt i pratbubblor, och kan deras utseende bevaras vid export?**

Ja. Aspose.Slides stödjer [embedding fonts](/slides/sv/python-java/embedded-font/) i presentationen och styr teckensnittsinbäddning vid export såsom [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/), vilket säkerställer att pratbubblorna ser likadana ut på olika system.