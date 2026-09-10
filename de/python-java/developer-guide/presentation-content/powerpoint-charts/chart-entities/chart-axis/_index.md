---
title: Diagrammachsen in Präsentationen mit Python anpassen
linktitle: Diagrammachse
type: docs
url: /de/python-java/chart-axis/
keywords:
- Diagrammachse
- vertikale Achse
- horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achseneigenschaften
- Maximalwert
- Minimalwert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Sie Aspose.Slides für Python via Java verwenden, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Diagrammachsen in Aspose.Slides anpassen. Er zeigt, wie Sie die tatsächlichen Achsenwerte abrufen, Daten zwischen Achsen austauschen, die vertikale oder horizontale Achse bei Liniendiagrammen ausblenden, den Typ der Kategorienachse ändern, das Datumsformat für Kategorienachsenwerte festlegen, einen Achsentitel rotieren, die Achsenposition setzen und die Anzeigeeinheit der Wertachse festlegen.

## **Ermitteln Sie die Maximalwerte auf der vertikalen Achse eines Diagramms**

Aspose.Slides für Python via Java ermöglicht das Abrufen der Minimal‑ und Maximalwerte einer vertikalen Achse. Folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Ermitteln Sie den tatsächlichen Maximalwert auf der Achse.
1. Ermitteln Sie den tatsächlichen Minimalwert auf der Achse.
1. Ermitteln Sie die tatsächliche Haupteinheit der Achse.
1. Ermitteln Sie die tatsächliche Nebeneinheit der Achse.
1. Ermitteln Sie die tatsächliche Skalierung der Haupteinheit der Achse.
1. Ermitteln Sie die tatsächliche Skalierung der Nebeneinheit der Achse.

Dieser Beispielcode – eine Umsetzung der obigen Schritte – zeigt, wie Sie die erforderlichen Werte in Python erhalten können:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Speichert die Präsentation
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Daten zwischen Achsen austauschen**

Aspose.Slides ermöglicht das schnelle Austauschen von Daten zwischen Achsen – die auf der vertikalen Achse (y‑Achse) dargestellten Daten werden zur horizontalen Achse (x‑Achse) verschoben und umgekehrt.

Dieser Python‑Code zeigt, wie Sie den Datenaustausch zwischen Achsen in einem Diagramm durchführen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Lädt die Standarddaten des Diagramms in die Arbeitsmappe — switchRowColumn transponiert die Arbeitsmappe,
    # daher muss sie zuerst befüllt werden
    workbook = chart.getChartData().getChartDataWorkbook()

    # Vertauscht Zeilen und Spalten
    chart.getChartData().switchRowColumn()

    # Speichert die Präsentation
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vertikale Achse für Liniendiagramme deaktivieren**

Dieser Python‑Code zeigt, wie Sie die vertikale Achse für ein Liniendiagramm ausblenden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Horizontale Achse für Liniendiagramme deaktivieren**

Dieser Code zeigt, wie Sie die horizontale Achse für ein Liniendiagramm ausblenden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategorieachse ändern**

Mit der [setCategoryAxisType](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#setCategoryAxisType)-Methode können Sie den gewünschten Typ der Kategorienachse (**date** oder **text**) festlegen. Dieser Python‑Code demonstriert die Vorgehensweise:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Datumsformat für Kategorieachsenwerte festlegen**

Aspose.Slides für Python via Java erlaubt das Festlegen des Datumsformats für einen Kategorienachsenwert. Die Vorgehensweise wird in diesem Python‑Code gezeigt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rotationswinkel für den Diagrammachsentitel festlegen**

Aspose.Slides für Python via Java ermöglicht das Setzen des Rotationswinkels für einen Diagrammachsentitel. Dieser Python‑Code demonstriert die Operation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Achsenposition auf einer Kategorien‑ oder Wertachse festlegen**

Aspose.Slides für Python via Java erlaubt das Festlegen der Achsenposition auf einer Kategorien‑ oder Wertachse. Dieser Python‑Code zeigt, wie die Aufgabe ausgeführt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Anzeigeeinheit auf einer Diagrammwertachse festlegen**

Aspose.Slides für Python via Java ermöglicht das Festlegen der Anzeigeeinheit einer Diagrammwertachse. Die Achse skaliert dann ihre Beschriftungen um diese Einheit: Mit [DisplayUnitType.Millions](https://reference.aspose.com/slides/de/python-java/aspose.slides/displayunittype/#Millions) wird eine Achse, die bis 60 000 000 reicht, mit 0 bis 60 beschriftet. Dieser Python‑Code demonstriert die Vorgehensweise:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenschnittpunkte)?**

Achsen bieten eine [crossing setting](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#setCrossType): Sie können wählen, ob sie bei Null, beim maximalen Kategorie‑/Wertbereich oder bei einem spezifischen numerischen Wert schneiden. Das ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder eine Basislinie hervorzuheben.

**Wie kann ich die Tick‑Markierungen relativ zur Achse positionieren (Kreuzung, außen, innen)?**

Setzen Sie die [tick mark position](https://reference.aspose.com/slides/de/python-java/aspose.slides/axis/#setMajorTickMark) auf „cross“, „outside“ oder „inside“. Das beeinflusst die Lesbarkeit und hilft, Platz zu sparen, insbesondere bei kleinen Diagrammen.