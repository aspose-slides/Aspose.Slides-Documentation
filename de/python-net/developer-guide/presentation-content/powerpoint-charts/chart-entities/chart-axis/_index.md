---
title: Diagrammachse
type: docs
url: /python-net/chart-axis/
keywords: "PowerPoint Diagrammachse, Präsentationsdiagramme, Python, Diagrammachse manipulieren, Diagrammdaten"
description: "Bearbeiten Sie PowerPoint-Diagrammachsen in Python"
---


## **Maximalwerte auf der vertikalen Achse in Diagrammen abrufen**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, die Minimal- und Maximalwerte auf einer vertikalen Achse zu erhalten. Gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Holen Sie den tatsächlichen Maximalwert auf der Achse.
1. Holen Sie den tatsächlichen Minimalwert auf der Achse.
1. Holen Sie die tatsächliche Hauptgröße der Achse.
1. Holen Sie die tatsächliche Neben Größe der Achse.
1. Holen Sie die tatsächliche Hauptgrößenskalierung der Achse.
1. Holen Sie die tatsächliche Neben Größenskalierung der Achse.

Dieser Beispielcode - eine Implementierung der obigen Schritte - zeigt Ihnen, wie Sie die erforderlichen Werte in Python abrufen:

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
	
	# Speichert die Präsentation
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Daten zwischen Achsen tauschen**
Aspose.Slides ermöglicht es Ihnen, die Daten schnell zwischen den Achsen zu tauschen – die auf der vertikalen Achse (y-Achse) dargestellten Daten werden auf die horizontale Achse (x-Achse) verschoben und umgekehrt.

Dieser Python-Code zeigt Ihnen, wie Sie die Daten zwischen den Achsen in einem Diagramm tauschen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellt eine leere Präsentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    # Tauscht Zeilen und Spalten
    chart.chart_data.switch_row_column()
            
    # Speichert die Präsentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Deaktivieren der vertikalen Achse für Liniendiagramme**

Dieser Python-Code zeigt Ihnen, wie Sie die vertikale Achse für ein Liniendiagramm ausblenden:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Deaktivieren der horizontalen Achse für Liniendiagramme**

Dieser Code zeigt Ihnen, wie Sie die horizontale Achse für ein Liniendiagramm ausblenden:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Ändern der Kategoriеachse**

Mit der **CategoryAxisType**-Eigenschaft können Sie Ihren bevorzugten Kategoriеachsentyp (**Datum** oder **Text**) angeben. Dieser Code in Python demonstriert die Operation: 

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

## **Festlegen des Datumsformats für den Kategoriеachsenwert**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, das Datumsformat für einen Kategoriеachsenwert festzulegen. Die Operation wird in diesem Python-Code demonstriert:

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

## **Festlegen des Drehwinkels für den Titel der Diagrammachse**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, den Drehwinkel für einen Titel der Diagrammachse festzulegen. Dieser Python-Code demonstriert die Operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Festlegen der Positionsachse in einer Kategorie oder Werteachse**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, die Positionsachse in einer Kategorie- oder Werteachse festzulegen. Dieser Python-Code zeigt, wie Sie die Aufgabe durchführen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktivieren der Anzeigeeinheit Beschriftung auf der Diagrammwertachse**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, ein Diagramm so zu konfigurieren, dass eine Einheitenspezifische Beschriftung auf seiner Diagrammwertachse angezeigt wird. Dieser Python-Code demonstriert die Operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```