---
title: Diagrammberechnungen für Präsentationen in Python via Java optimieren
linktitle: Diagrammberechnungen
type: docs
weight: 50
url: /de/python-java/chart-calculations/
keywords:
- Diagrammberechnungen
- Diagrammelemente
- Elementposition
- tatsächliche Position
- Kindelement
- Elternelement
- Diagrammwerte
- tatsächlicher Wert
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verstehen Sie Diagrammberechnungen, Datenaktualisierungen und Präzisionssteuerung in Aspose.Slides für Python via Java für PPT und PPTX, mit praktischen Python‑Codebeispielen."
---
## **Übersicht**

Aspose.Slides stellt APIs zum Arbeiten mit Diagrammberechnungen und Layoutdaten in Präsentationen bereit. Dieser Artikel zeigt, wie die tatsächlichen Werte von Diagrammelementen abgerufen werden können, einschließlich der tatsächlichen Position und Größe von Diagrammelementen sowie der tatsächlichen Werte der Diagrammachsen. Er erklärt außerdem, dass diese Werte nach der Validierung des Diagrammlayouts befüllt werden.

Zusätzlich demonstriert der Artikel, wie die tatsächliche Position übergeordneter Diagrammelemente ermittelt und wie Diagrammkomponenten wie Titel, Achsen, Legende und Rasterlinien ausgeblendet werden können. Zusammen helfen Ihnen diese Beispiele, Diagrammlayoutinformationen zu untersuchen und die Sichtbarkeit von Diagrammelementen in PowerPoint‑Präsentationen programmgesteuert zu steuern.

## **Tatsächliche Werte von Diagrammelementen berechnen**
Aspose.Slides für Python via Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Methoden der [Axis](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/)‑Klasse liefern Informationen über die tatsächlichen Werte der Diagrammachsen ([getActualMaxValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Rufen Sie zuerst die Methode [Chart.validateChartLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#validateChartLayout) auf, um diese Eigenschaften mit den tatsächlichen Werten zu befüllen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Tatsächliche Position übergeordneter Diagrammelemente berechnen**
Aspose.Slides für Python via Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Methoden der [ChartPlotArea](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartplotarea/)‑Klasse liefern Informationen über die tatsächliche Position und Größe des Diagramm‑Plot‑Bereichs ([getActualX](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartplotarea/#getActualHeight)). Rufen Sie zuerst die Methode [Chart.validateChartLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#validateChartLayout) auf, um diese Eigenschaften mit den tatsächlichen Werten zu befüllen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Diagrammelemente ausblenden**
Dieser Abschnitt erklärt, wie Informationen aus einem Diagramm ausgeblendet werden können. Mit Aspose.Slides für Python via Java können Sie den **Titel, die vertikale Achse, die horizontale Achse** und **Rasterlinien** ausblenden. Das folgende Codebeispiel zeigt, wie diese Eigenschaften verwendet werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Diagrammtitel ausblenden.
    chart.setTitle(False)

    # Wertachse ausblenden.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Kategorienachse ausblenden.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Legende ausblenden.
    chart.setLegend(False)

    # Große Rasterlinien ausblenden.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Nur die erste Serie behalten. Das Entfernen vom Ende her stellt sicher, dass die übrigen Indizes gültig bleiben.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Farbe der Serienlinie festlegen.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Funktionieren externe Excel‑Arbeitsmappen als Datenquelle und wie wirkt sich das auf die Neuberechnung aus?**

Ja. Ein Diagramm kann auf eine externe Arbeitsmappe verweisen: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Änderungen während Öffnen/Bearbeiten wider. Die API ermöglicht es Ihnen, den Pfad zur externen Arbeitsmappe anzugeben und die verknüpften Daten zu verwalten.

**Kann ich Trendlinien berechnen und anzeigen, ohne selbst eine Regression zu implementieren?**

Ja. [Trendlines](/slides/de/python-java/trend-line/) (linear, exponentiell und weitere) werden von Aspose.Slides hinzugefügt und aktualisiert; ihre Parameter werden automatisch aus den Seriendaten neu berechnet, sodass Sie keine eigenen Berechnungen implementieren müssen.

**Wenn eine Präsentation mehrere Diagramme mit externen Verlinkungen enthält, kann ich steuern, welche Arbeitsmappe jedes Diagramm für berechnete Werte verwendet?**

Ja. Jedes Diagramm kann auf seine eigene [external workbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#setExternalWorkbook) verweisen, oder Sie können pro Diagramm eine externe Arbeitsmappe erstellen/ersetzen, unabhängig von den anderen.