---
title: Callouts in Präsentationsdiagrammen mit Python verwalten
linktitle: Callout
type: docs
url: /de/python-java/callout/
keywords:
- Diagramm-Callout
- Callout verwenden
- Datenbeschriftung
- Beschriftungsformat
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen und formatieren Sie Callouts in Aspose.Slides für Python via Java mit kurzen Codebeispielen, kompatibel mit PPT und PPTX, um Präsentations-Workflows zu automatisieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Callouts für Datenbeschriftungen von Diagrammen in Aspose.Slides verwendet. Er zeigt, wie die Methode [setShowLabelAsDataCallout](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) genutzt wird, um Beschriftungen als Callouts darzustellen, wie callout‑bezogene Beschriftungseinstellungen für ein Ringdiagramm konfiguriert werden und dass Callouts und ihr Aussehen beim Export von Präsentationen nach PDF, HTML5, SVG und Rasterbildformaten erhalten bleiben.

## **Verwendung von Callouts**

Die Methoden [getShowLabelAsDataCallout](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) und [setShowLabelAsDataCallout](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) der Klasse [DataLabelFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabelformat/) bestimmen, ob eine Diagrammdatenbeschriftung als Callout oder als reguläre Datenbeschriftung angezeigt wird.

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

## **Callout für ein Ringdiagramm festlegen**

Aspose.Slides for Python via Java unterstützt das Festlegen der Callout‑Form der Serien‑Datenbeschriftung für ein Ringdiagramm. Das folgende Beispiel demonstriert dies.

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

**Werden Callouts beim Konvertieren einer Präsentation in PDF, HTML5, SVG oder Bilder beibehalten?**

Ja. Callouts sind Teil der Diagrammdarstellung, sodass sie beim Export nach [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/de/python-java/export-to-html5/), [SVG](/slides/de/python-java/render-a-slide-as-an-svg-image/) oder [Rasterbildern](/slides/de/python-java/convert-powerpoint-to-png/) zusammen mit der Formatierung der Folie erhalten bleiben.

**Funktionieren benutzerdefinierte Schriftarten in Callouts und kann ihr Aussehen beim Export beibehalten werden?**

Ja. Aspose.Slides unterstützt das [Einbetten von Schriftarten](/slides/de/python-java/embedded-font/) in die Präsentation und steuert das Einbetten von Schriftarten bei Exporten wie [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), wodurch die Callouts auf verschiedenen Systemen gleich aussehen.