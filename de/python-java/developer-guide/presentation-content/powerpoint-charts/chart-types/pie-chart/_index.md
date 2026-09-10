---
title: Kreisdiagramme in Präsentationen mit Python via Java anpassen
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
description: "Erfahren Sie, wie Sie Kreisdiagramme in Python via Java mit Aspose.Slides erstellen und anpassen, exportierbar nach PowerPoint, und Ihre Datenpräsentation in Sekunden verbessern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Kreisdiagrammen in Aspose.Slides arbeitet. Er zeigt, wie man Optionen für das zweite Diagramm bei „Pie of Pie“ und „Bar of Pie“-Diagrammen konfiguriert und wie man die automatische Segmentfärbung für ein Standard‑Kreisdiagramm aktiviert.

Die Beispiele konzentrieren sich auf praktische Schritte zur Diagrammanpassung, wie das Hinzufügen eines Diagramms zu einer Folie, das Anpassen von Reihen‑ und Beschriftungseinstellungen, das Ersetzen der Standard‑Diagrammdaten durch benutzerdefinierte Kategorien und Werte sowie das Speichern der aktualisierten Präsentation.

## **Optionen für das zweite Plot bei Pie of Pie‑ und Bar of Pie‑Diagrammen**

Aspose.Slides für Python via Java unterstützt Optionen für das zweite Plot bei Pie of Pie‑ und Bar of Pie‑Diagrammen. Dieser Abschnitt zeigt, wie man diese Optionen mit Aspose.Slides festlegt. Folgen Sie diesen Schritten:

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekt.
1. Fügen Sie ein Diagramm zur Folie hinzu.
1. Geben Sie die Optionen für das zweite Plot des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Das folgende Beispiel setzt verschiedene Eigenschaften eines Pie of Pie‑Diagramms.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    # Füge ein Diagramm zur Folie hinzu.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Setze verschiedene Eigenschaften.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Schreibe die Präsentation auf die Festplatte.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Automatisches Festlegen der Segmentfarben für Kuchendiagramme**

Aspose.Slides für Python via Java bietet eine einfache API zum automatischen Festlegen der Segmentfarben für Kuchendiagramme. Das folgende Beispiel demonstriert, wie diese Einstellungen angewendet werden.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie den Diagrammtitel.
1. Legen Sie den Index des Datenarbeitsblatts des Diagramms fest.
1. Holen Sie das Diagrammdatentabellen‑Workbook.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie eine neue Reihe hinzu.
1. Konfigurieren Sie die neue Reihe so, dass Werte angezeigt werden.

Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    # Füge ein Diagramm mit Standarddaten hinzu.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Setze den Diagrammtitel.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Setze den Index des Datenarbeitsblatts des Diagramms.
    default_worksheet_index = 0

    # Hole das Diagramm‑Daten‑Workbook.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Lösche die Standard‑Reihen und -Kategorien.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Füge neue Kategorien hinzu.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Füge eine neue Reihe hinzu.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Befülle die Daten der Reihe.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Setze die neue Reihe so, dass Werte angezeigt werden.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Werden die Varianten 'Pie of Pie' und 'Bar of Pie' unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/) ein sekundäres Plot für Kreisdiagramme, einschließlich der Typen „Pie of Pie“ und „Bar of Pie“.

**Kann ich nur das Diagramm als Bild (z. B. PNG) exportieren?**

Ja, Sie können das Diagramm selbst [exportieren Sie das Diagramm selbst als Bild](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) (z. B. PNG), ohne die gesamte Präsentation.