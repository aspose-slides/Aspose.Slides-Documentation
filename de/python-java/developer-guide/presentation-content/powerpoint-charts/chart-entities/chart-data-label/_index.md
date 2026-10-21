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
description: "Erfahren Sie, wie Sie Diagrammdatenbeschriftungen in PowerPoint‑Präsentationen mit Aspose.Slides für Python via Java hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---
## **Einleitung**

Datenbeschriftungen zeigen Informationen über Diagrammreihen und einzelne Datenpunkte an und helfen den Lesern, Werte zu identifizieren und das Diagramm zu verstehen. Dieser Artikel erklärt, wie man Werte formatiert, Prozentsätze anzeigt, Beschriftungstext liest, Beschriftungen jenseits des Achsenmaximums steuert, den Abstand von Achsenkategorienbeschriftungen anpasst und Positionen von Kreisdiagrammbeschriftungen festlegt.

## **Datenpräzision in Diagrammdatenbeschriftungen festlegen**

Verwenden Sie [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues), um die Werte der Reihen zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Standarddaten, zeigt dessen Datentabelle an und aktiviert Wertebeschriftungen für die erste Reihe. Das Format `#,##0.00` zeigt ein Tausendertrennzeichen und zwei Dezimalstellen an, ohne die zugrunde liegenden Werte zu ändern.

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

Um die numerischen Zellen in der eingebetteten Arbeitsmappe eines Diagramms zu formatieren, siehe [Benutzerdefinierte Zahlenformate für Arbeitsmappenzellen festlegen](/slides/de/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Dieses Beispiel zeigt außerdem, dass Wertebeschriftungen den Formaten ihrer Quellzellen folgen, wobei die gespeicherten numerischen Werte erhalten bleiben.

## **Prozentsatz als Beschriftungen anzeigen**

Für ein gestapeltes Säulendiagramm berechnen Sie jeden Wert als Prozentsatz des Gesamtsumme seiner Kategorie und weisen den Text dem Textfeld zu, das von [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) zurückgegeben wird. Dieses Beispiel verwendet die Standarddiagrammdaten und zeigt Prozentsätze mit zwei Dezimalstellen in einer 8‑Punkt‑Schrift an. Kategorien mit einer Gesamtsumme von Null werden übersprungen, um eine Division durch Null zu vermeiden. Berechnen Sie den benutzerdefinierten Beschriftungstext neu, wenn sich die Diagrammdaten ändern.

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

## **Prozentzeichen mit Diagramm-Datenbeschriftungen festlegen**

Wenn Werte als Brüche gespeichert sind, verwenden Sie [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat), um Prozentsätze anzuzeigen. Übergeben Sie `False` an [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), um das Beschriftungsformat unabhängig von den Quellzellen anzuwenden.

Dieses Beispiel erstellt ein 100 % gestapeltes Säulendiagramm mit roten und blauen Reihen über vier Kategorien. Jede Wertepaare summieren sich zu 1. Das Beschriftungsformat `0.0%` zeigt 0,30 als 30,0 % an, während die vertikale Achse zwei Dezimalstellen verwendet. Beide Reihen verwenden weißen Beschriftungstext mit 10 Punkten.

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

Verwenden Sie [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText), um den von den Einstellungen einer Datenbeschriftung erzeugten Text abzurufen. Dies ist nützlich, wenn Sie Beschriftungen für Berichte extrahieren, Präsentationsinhalte durchsuchen oder generierte Diagramme validieren. Im nachstehenden Beispiel kombiniert das Standard-[Datenbeschriftungsformat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) jeden Kategorienamen, Seriennamen und Wert. Ein Punkt formatiert seinen Wert als Prozentsatz, ein anderer verwendet benutzerdefinierten Text von [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Die in einem Datenpunkt gespeicherte Nummer bleibt `0.75`, selbst wenn ihre Beschriftung `75%` zusammen mit den Kategorie‑ und Seriennamen anzeigt. Benutzerdefinierter Text ersetzt den generierten Beschriftungstext. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) gibt in beiden Fällen die resultierende Beschriftungszeichenkette zurück. Prüfen Sie [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) separat, wie oben gezeigt, wenn Sie nur sichtbare Beschriftungen extrahieren möchten.

## **Datenbeschriftungen jenseits des Achsenmaximums steuern**

Wenn Sie einen Achsenbereich manuell begrenzen, können einige Datenpunkte das Maximum überschreiten. Verwenden Sie [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum), um zu steuern, ob deren Datenbeschriftungen angezeigt werden. Diese Einstellung ändert die Sichtbarkeit der Beschriftung; sie ändert nicht den Achsenbereich oder die zugrunde liegenden Datenwerte.

Das nachstehende Beispiel erstellt ein 2D gruppiertes Säulendiagramm mit Werten 60 und 120. Es übergibt `False` an [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) und setzt das Maximum auf 100 mit [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) auf der vertikalen Achse. Die erste Folie erlaubt Beschriftungen jenseits des Maximums; eine Kopie dieser Folie deaktiviert sie. Beide Folien werden in `DataLabelsOverMaximum.pptx` gespeichert.

Aktivieren Sie Wertebeschriftungen mit [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Die Diagramm‑Ebene‑Einstellung aktiviert die Anzeige von Werten nicht von selbst und überschreibt nicht die deaktivierte Werteanzeige einer einzelnen Beschriftung. Dieses Beispiel aktiviert Werte für die gesamte Reihe und verwendet [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition), um Beschriftungen am äußeren Ende jeder Säule zu platzieren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die folgenden Bilder zeigen die gespeicherten Folien, die von Microsoft PowerPoint gerendert wurden. Mit `True` ist die Beschriftung **120** an der oberen Grenze sichtbar; mit `False` ist sie ausgeblendet. Die Beschriftung **60** bleibt sichtbar, das Achsenmaximum bleibt bei **100**, und der zweite Datenpunkt bleibt in beiden Fällen **120**.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
This example uses a 2D column chart with a value axis. Charts without a value axis, such as pie and doughnut charts, do not have an axis maximum to limit in this way.
{{% /alert %}}

## **Abstand der Beschriftung von einer Achse festlegen**

Verwenden Sie [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset), um den Abstand zwischen den Kategorienachsen‑Beschriftungen und der Achse zu steuern. Der Wert ist ein Prozentsatz der maximalen Schriftgröße der Achsenbeschriftungen. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm und setzt den Horizontalachsen‑Beschriftungsversatz auf 500. Diese Einstellung wirkt sich auf die Kategorienachsen‑Beschriftungen aus, nicht auf Beschriftungen, die an einzelnen Datenpunkten befestigt sind.

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

In einem Kreisdiagramm passen Sie die Positionen der Datenbeschriftungen an, um den Abstand zu verbessern und Platz für Führungs‑Linien zu schaffen.

Dieses Beispiel zeigt den Wert des ersten Datenpunkts, platziert seine Beschriftung außerhalb des Segments und passt seine horizontalen und vertikalen Versätze mit [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) und [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) an. Diese Versätze beziehen sich jeweils auf die Diagrammbreite bzw. -höhe.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Führungs‑Linien formatieren**

Wenn Kreisdiagrammbeschriftungen außerhalb ihrer Segmente liegen, helfen Führungs‑Linien den Lesern, jeden Wert dem richtigen Segment zuzuordnen. Eine kontrastierende Farbe und eine leicht dickere Linie können diese Verbindungen leichter nachvollziehbar machen, während Transparenz und ein gestrichelter Stil die Linien visuell unaufdringlich halten.

Verwenden Sie [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat), um Führungs‑Linien auf Ebene der Datenbeschriftungssammlung einer Reihe zu formatieren. Die Einstellungen in `series.getLabels().getLeaderLinesFormat().getLine()` gelten für die Sammlung, nicht für eine einzelne Beschriftung.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten, zeigt Werte außerhalb der Segmente an und aktiviert [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines). Es verschiebt zwei Beschriftungen weiter von ihren Segmenten weg mittels [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) und [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY)-Versätzen, ausgedrückt als Bruchteile der Diagrammbreite und -höhe. Keine Eingabepräsentation ist erforderlich.

Die Linien‑[getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) setzt eine solide blaue Farbe mit einem Alpha‑Wert von 191 von 255, was etwa 25 % Transparenz ergibt. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) stellt die Dicke auf 2 Punkte ein, und [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) macht die Linie gestrichelt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # Verschiebe zwei Beschriftungen weiter von ihren Segmenten.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Aktivieren von Führungs‑Linien garantiert nicht, dass für jede Beschriftung eine Linie erscheint. Die Sichtbarkeit hängt von der Beschriftungsposition und dem Layout‑Verhalten des Diagramms ab. In diesem Beispiel haben die beiden versetzten Beschriftungen sichtbare Führungs‑Linien; die Beschriftungen, die nah an ihren Segmenten bleiben, benötigen keine.

Das folgende Bild zeigt das gespeicherte `FormattedLeaderLines.pptx`, das mit Aspose.Slides gerendert wurde:

![Kreisdiagramm mit blauen, halbtransparenten, gestrichelten Führungs‑Linien, die zwei äußere Beschriftungen mit ihren Segmenten verbinden](formatted-leader-lines.png)

## **Mehrere Zeilen von Datenbeschriftungen über einem Säulendiagramm hinzufügen**

Dieses Beispiel erstellt ein Säulendiagramm mit zwei Zeilen von Datenbeschriftungen über dem Plot‑Bereich. Serie A zeigt die sichtbaren Säulen, während Serie B und Serie C die zusätzlichen Beschriftungen bereitstellen. Ihre Säulen werden ausgeblendet, indem Füllung und Kontur entfernt werden. Die Methode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) richtet alle drei Serien an denselben Kategoriezentren aus.

Die [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/)-Einstellungen reservieren Platz für die Beschriftungszeilen. Nachdem [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) die Standardpositionen berechnet hat, bewahren [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) und [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) die horizontale Ausrichtung und wenden vertikale Versätze an, um die Beschriftungen in zwei Reihen anzuordnen. Die Zahlen bleiben Datenbeschriftungen, die mit den Reihenwerten verknüpft sind; nur die Zeilenüberschriften sind separate Textformen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Verstecke die Spalten von B und C, aber behalte ihre Datenbeschriftungen.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Richte alle drei Reihen anhand der gleichen Kategorienmitten aus.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Verwende weniger Gitternetzlinien für dieses kompakte Beispiel.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Reserviere Platz über dem Diagramm für zwei Zeilen von Datenbeschriftungen.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Behalte die Standard‑Horizontale‑Position bei. Y ist ein Versatz von
            # der Standard‑Beschriftungsposition, ausgedrückt als ein Bruchteil der Diagrammhöhe.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Nur die Zeilenüberschrift ist eine separate Textform.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Säulendiagramm mit zwei Zeilen von Datenbeschriftungen über dem Plot‑Bereich](multiple-rows-of-labels.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen in dichten Diagrammen überlappen?**

Automatische Beschriftungsplatzierung, Führungs‑Linien und reduzierte Schriftgröße kombinieren; bei Bedarf einige Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für extreme Werte bzw. Schlüssel­punkte anzeigen.

**Wie kann ich Beschriftungen nur für Null‑, negative oder leere Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Setzen Sie explizit die Schriftfamilie und -größe und prüfen Sie, dass die Schrift im Rendering‑Umfeld verfügbar ist, um ein Ausweichen zu vermeiden.