---
title: Diagrammachsen in Präsentationen mit Python anpassen
linktitle: Diagrammachse
type: docs
url: /de/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-axis/
keywords:
- diagrammachse
- vertikale achse
- horizontale achse
- achse anpassen
- achse manipulieren
- achse verwalten
- achseneigenschaften
- maximalwert
- minimalwert
- achsenlinie
- datumsformat
- achsentitel
- achsenposition
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für Python via .NET nutzen, um Diagrammachsen in PowerPoint- und OpenDocument-Präsentationen für Berichte und Visualisierungen anzupassen."
---

## **Ermitteln der Maximalwerte auf der vertikalen Achse von Diagrammen**
Aspose.Slides for Python via .NET ermöglicht es Ihnen, die minimalen und maximalen Werte einer vertikalen Achse zu erhalten. Führen Sie die folgenden Schritte aus:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Ermitteln Sie den tatsächlichen Maximalwert der Achse.
1. Ermitteln Sie den tatsächlichen Minimalwert der Achse.
1. Ermitteln Sie die tatsächliche Haupteinheit der Achse.
1. Ermitteln Sie die tatsächliche Untereinheit der Achse.
1. Ermitteln Sie die tatsächliche Skalierung der Haupteinheit der Achse.
1. Ermitteln Sie die tatsächliche Skalierung der Untereinheit der Achse.

Dieser Beispielcode – eine Umsetzung der obigen Schritte – zeigt, wie Sie die benötigten Werte in Python erhalten:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Saves the presentation
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Austausch der Daten zwischen Achsen**
Aspose.Slides ermöglicht es Ihnen, die Daten zwischen den Achsen schnell auszutauschen – die auf der vertikalen Achse (y‑Achse) dargestellten Daten werden zur horizontalen Achse (x‑Achse) verschoben und umgekehrt. 

Dieser Python-Code zeigt, wie Sie den Datenaustausch zwischen den Achsen in einem Diagramm ausführen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creates empty presentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Switches rows and columns
    chart.chart_data.switch_row_column()
            
    # Saves presentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Deaktivieren der vertikalen Achse für Liniendiagramme**

Dieser Python-Code zeigt, wie Sie die vertikale Achse eines Liniendiagramms ausblenden:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Deaktivieren der horizontalen Achse für Liniendiagramme**

Dieser Code zeigt, wie Sie die horizontale Achse eines Liniendiagramms ausblenden:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Ändern der Kategorienachse**

Mit der Eigenschaft **CategoryAxisType** können Sie Ihren gewünschten Typ für die Kategorienachse (**date** oder **text**) festlegen. Dieser Python-Code demonstriert den Vorgang: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Festlegen des Datumsformats für den Kategorienachsenwert**
Aspose.Slides for Python via .NET ermöglicht das Festlegen des Datumsformats für einen Kategorienachsenwert. Der Vorgang wird in diesem Python-Code demonstriert:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Festlegen des Rotationswinkels für den Diagrammachsentitel**
Aspose.Slides for Python via .NET ermöglicht das Festlegen des Rotationswinkels für einen Diagrammachsentitel. Dieser Python-Code demonstriert den Vorgang:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Festlegen der Position der Achse in einer Kategorien- oder Wertachse**
Aspose.Slides for Python via .NET ermöglicht das Festlegen der Position der Achse in einer Kategorien- oder Wertachse. Dieser Python-Code zeigt, wie Sie die Aufgabe ausführen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktivieren der Anzeigeeinheitsbeschriftung auf der Diagrammwertachse**
Aspose.Slides for Python via .NET ermöglicht das Konfigurieren eines Diagramms so, dass ein Einheitsetikett auf seiner Wertachse angezeigt wird. Dieser Python-Code demonstriert den Vorgang:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere kreuzt (Achsenkreuzung)?**

Achsen bieten eine [Kreuzungseinstellung](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): Sie können wählen, ob sie bei Null, beim maximalen Kategorien‑/Wertbereich oder bei einem bestimmten numerischen Wert kreuzen. Dies ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder eine Basislinie hervorzuheben.

**Wie kann ich die Tick‑Beschriftungen relativ zur Achse positionieren (neben, außen, innen)?**

Stellen Sie die [Beschriftungsposition](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) auf "cross", "outside" oder "inside" ein. Dies beeinflusst die Lesbarkeit und hilft, Platz zu sparen, insbesondere bei kleinen Diagrammen.