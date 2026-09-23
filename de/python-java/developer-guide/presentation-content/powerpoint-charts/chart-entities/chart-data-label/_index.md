---
title: Diagrammdatenbeschriftungen in Präsentationen mit Python verwalten
linktitle: Datenbeschriftung
type: docs
url: /de/python-java/chart-data-label/
keywords:
- Diagramm
- Datenbeschriftung
- Datenpräzision
- Prozentsatz
- Beschriftungsabstand
- Beschriftungsposition
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenbeschriftungen in PowerPoint-Präsentationen mit Aspose.Slides für Python via Java hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---
## **Einleitung**

Datenbeschriftungen zeigen Informationen zu Diagrammserien und einzelnen Datenpunkten an und helfen den Lesern, Werte zu identifizieren und das Diagramm zu verstehen. Dieser Artikel erklärt, wie man Werte formatiert, Prozentsätze anzeigt, den Beschriftungstext ausliest, den Abstand von Kategorienachsenbeschriftungen anpasst und Beschriftungen von Kreisdiagrammen positioniert.

## **Datenpräzision in Diagrammdatenbeschriftungen festlegen**

Verwenden Sie [setNumberFormatOfValues](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#setNumberFormatOfValues), um Serienwerte zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Standarddaten, zeigt dessen Datentabelle an und aktiviert Wertbeschriftungen für die erste Serie. Das Format `#,##0.00` zeigt ein Tausendertrennzeichen und zwei Dezimalstellen an, ohne die zugrunde liegenden Werte zu ändern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Prozentsätze als Beschriftungen anzeigen**

Für ein gestapeltes Säulendiagramm berechnen Sie jeden Wert als Prozentsatz des Gesamtsummenwerts seiner Kategorie und weisen den Text dem Textfeld zu, das von [getTextFrameForOverriding](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) zurückgegeben wird. Dieses Beispiel verwendet die Standarddiagrammdaten und zeigt Prozentsätze mit zwei Dezimalstellen in einer 8‑Pt‑Schrift an. Kategorien mit einer Gesamtsumme von Null werden übersprungen, um eine Division durch Null zu vermeiden. Berechnen Sie den benutzerdefinierten Beschriftungstext neu, wenn sich die Diagrammdaten ändern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Prozentzeichen mit Diagrammdatenbeschriftungen festlegen**

Wenn Werte als Brüche gespeichert sind, verwenden Sie [setNumberFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabelformat/#setNumberFormat), um Prozentsätze anzuzeigen. Übergeben Sie `False` an [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), um das Beschriftungsformat unabhängig von den Quellzellen anzuwenden.

Dieses Beispiel erstellt ein 100 % gestapeltes Säulendiagramm mit roten und blauen Serien über vier Kategorien. Jeder Werte‑Paar‑Satz summiert sich zu 1. Das Beschriftungsformat `0.0%` zeigt 0.30 als 30.0 % an, während die vertikale Achse zwei Dezimalstellen verwendet. Beide Serien verwenden weißen Beschriftungstext mit 10 Pt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Den tatsächlichen Text von Datenbeschriftungen lesen**

Verwenden Sie [getActualLabelText](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabel/#getActualLabelText), um den von den Einstellungen einer Datenbeschriftung erzeugten Text abzurufen. Dies ist nützlich, wenn Sie Beschriftungen für Berichte extrahieren, Präsentationsinhalte durchsuchen oder generierte Diagramme validieren möchten. Im nachfolgenden Beispiel kombiniert das Standard‑[Datenbeschriftungsformat](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabelformat/) jeden Kategorienamen, Seriennamen und Wert. Ein Punkt formatiert seinen Wert als Prozentsatz, ein anderer nutzt benutzerdefinierten Text aus [getTextFrameForOverriding](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Die in einem Datenpunkt gespeicherte Zahl bleibt `0.75`, selbst wenn ihre Beschriftung `75%` zusammen mit den Kategorie‑ und Seriennamen anzeigt. Benutzerdefinierter Text ersetzt den automatisch erzeugten Beschriftungstext. [getActualLabelText](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabel/#getActualLabelText) gibt in beiden Fällen die resultierende Beschriftungszeichenkette zurück. Prüfen Sie [isVisible](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabel/#isVisible) separat, wie oben gezeigt, wenn Sie nur sichtbare Beschriftungen extrahieren möchten.

## **Abstand der Beschriftung von einer Achse festlegen**

Verwenden Sie [setLabelOffset](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#setLabelOffset), um den Abstand zwischen Kategorienachsenbeschriftungen und der Achse zu steuern. Der Wert ist ein Prozentsatz der maximalen Schriftgröße der Achsenbeschriftungen. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm und setzt den horizontalen Achsenbeschriftungs‑Offset auf 500. Diese Einstellung wirkt sich auf Kategorienachsenbeschriftungen aus, nicht auf Beschriftungen, die einzelnen Datenpunkten zugeordnet sind.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Beschriftungsposition anpassen**

Bei einem Kreisdiagramm passen Sie die Positionen der Datenbeschriftungen an, um den Abstand zu verbessern und Platz für Führungslinien zu schaffen.

Dieses Beispiel zeigt den Wert des ersten Datenpunkts, platziert seine Beschriftung außerhalb des Sektors und passt die horizontalen sowie vertikalen Offsets mit [setX](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabel/#setX) und [setY](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabel/#setY) an. Diese Offsets stehen relativ zur Diagrammbreite bzw. -höhe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Kreisdiagramm mit angepasster Datenbeschriftungsposition](pie-chart-adjusted-label.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen bei dichten Diagrammen überlappen?**

Kombinieren Sie die automatische Beschriftungsplatzierung, Führungslinien und eine reduzierte Schriftgröße; bei Bedarf können Sie einige Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für Extremwerte bzw. Schlüssel­punkte anzeigen.

**Wie kann ich Beschriftungen nur für Null‑, negative oder fehlende Werte deaktivieren?**

Filtern Sie die Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Setzen Sie die Schriftfamilie und -größe explizit und prüfen Sie, ob die Schrift im Render‑Umfeld verfügbar ist, um einen Fallback zu vermeiden.