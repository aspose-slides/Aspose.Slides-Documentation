---
title: Anpassen von Kreisdiagrammen in Präsentationen mit Python via Java
linktitle: Kreisdiagramm
type: docs
url: /de/python-java/pie-chart/
keywords:
- Kreisdiagramm
- Diagramm verwalten
- Diagramm anpassen
- Diagrammoptionen
- Diagrammeinstellungen
- Plot-Optionen
- Segmentfarbe
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von Kreisdiagrammen in Python via Java mit Aspose.Slides. Sekundäre Plots konfigurieren, Datenbeschriftungen anzeigen und automatische Segmentfarben in PowerPoint anwenden."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Kreisdiagrammen in Aspose.Slides arbeitet. Er zeigt, wie man sekundäre Plot‑Optionen für Pie of Pie‑ und Bar of Pie‑Diagramme konfiguriert und wie man die automatische Färbung der Segmente für ein Standard‑Kreisdiagramm aktiviert.

Die Beispiele konzentrieren sich auf Diagrammanpassungsaufgaben wie das Hinzufügen eines Diagramms zu einer Folie, das Anpassen von Reihen‑ und Beschriftungseinstellungen, das Ersetzen der Standarddiagrammdaten durch benutzerdefinierte Kategorien und Werte sowie das Speichern der aktualisierten Präsentation.

## **Optionen für den sekundären Plot bei Pie of Pie‑ und Bar of Pie‑Diagrammen**

Aspose.Slides für Python via Java unterstützt Optionen für den sekundären Plot bei Pie of Pie‑ und Bar of Pie‑Diagrammen. Diese Optionen steuern die Größe des sekundären Plots und wie Datenpunkte zwischen den beiden Plots aufgeteilt werden.

Das folgende Beispiel erstellt ein Pie of Pie‑Diagramm in einer neuen Präsentation und zeigt die Werte der Datenpunkte als Beschriftungen an. Die [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize)‑Methode setzt die Größe des sekundären Plots auf 149 % des Hauptplots. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) wählt eine prozentbasierte Aufteilung, und [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) legt die Schwelle auf 53 % fest.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Werte anzeigen und den sekundären Plot konfigurieren.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kategorien für den sekundären Plot auswählen**

Verwenden Sie benutzerdefinierte Aufteilung, wenn Sie bestimmte Kategorien im sekundären Plot gruppieren möchten, unabhängig von deren prozentualen Werten. Beispielsweise könnte ein Verkaufsbericht Online und Events zusammen anzeigen, sodass Leser diese beiden Kanäle vergleichen können, obwohl sie 35 % bzw. 10 % des Gesamtumsatzes ausmachen.

Rufen Sie [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) mit [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) auf und wählen Sie die Punkte über [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Die [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add)‑Methode der Sammlung akzeptiert einen nullbasierten Index in der Reihe; verwenden Sie [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem), um ein Datenpunkt‑Objekt hinzuzufügen. In diesem Beispiel wählt Index 1 Online aus, und der Punkt bei Index 3 wählt Events aus. Partners wird ebenfalls vorübergehend hinzugefügt und anschließend mit [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem) ausgeschlossen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Ersetzen Sie die Standarddaten durch Verkäufe nach Kanal.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Wählen Sie Online über seinen nullbasierten Index und Events über sein Datenpunkt-Objekt aus.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Schließen Sie Partners von der Auswahl aus, ohne die Quelldaten zu löschen.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) und Events (10) erscheinen als separate Segmente im sekundären Plot. Im primären Plot werden sie durch ein kombiniertes Segment mit dem Wert 45 dargestellt, zusammen mit Retail (40) und Partners (15). Das Entfernen von Partners aus der benutzerdefinierten Auswahl lässt es im primären Plot erhalten; es entfernt die Kategorie oder ihren Wert nicht aus den Quelldaten des Diagramms.

Das folgende Bild zeigt die gespeicherte Präsentation in PowerPoint:

![Pie of Pie‑Diagramm mit Online und Events im sekundären Plot und ihrem kombinierten Wert von 45 im primären Plot](pie_of_pie_custom.png)

## **Automatische Farben für Pie‑Diagramm‑Segmente festlegen**

Aspose.Slides für Python via Java kann automatisch verschiedene Farben den Segmenten eines Kreisdiagramms zuweisen. Das folgende Beispiel erstellt ein Kreisdiagramm mit einem zentrierten Titel und ersetzt die Standarddaten durch drei Quartalskategorien und deren Werte. Die [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue)‑Methode zeigt die Werte 20, 50 und 30 als Beschriftungen an, während [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) für jedes Segment eine unterschiedliche Farbe aktiviert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Zentrierten Diagrammtitel hinzufügen.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ersetzen Sie die Standarddaten mithilfe des ersten Arbeitsblatts.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Werte anzeigen und den Segmenten unterschiedliche Farben zuweisen.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Werden die Pie of Pie‑ und Bar of Pie‑Varianten unterstützt?**

Ja, die Bibliothek [supports](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) einen sekundären Plot für Kreisdiagramme, einschließlich der Pie of Pie‑ und Bar of Pie‑Typen.

**Kann ich nur das Diagramm als Bild exportieren (zum Beispiel PNG)?**

Ja, Sie können [export the chart itself as an image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (wie PNG) exportieren, ohne die gesamte Präsentation zu exportieren.