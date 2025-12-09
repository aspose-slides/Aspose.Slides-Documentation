---
title: Diagrammachsen in Präsentationen mit Python anpassen
linktitle: Diagrammachse
type: docs
url: /de/python-net/chart-axis/
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
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für Python via .NET verwenden, um Diagrammachsen in PowerPoint- und OpenDocument-Präsentationen für Berichte und Visualisierungen anzupassen."
---

## **Ermitteln der Maximalwerte auf der vertikalen Achse in Diagrammen**
Aspose.Slides for Python via .NET ermöglicht es Ihnen, die Minimal- und Maximalwerte einer vertikalen Achse zu erhalten. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Ermitteln Sie den tatsächlichen Maximalwert der Achse.
5. Ermitteln Sie den tatsächlichen Minimalwert der Achse.
6. Ermitteln Sie die tatsächliche Haupteinheit der Achse.
7. Ermitteln Sie die tatsächliche Nebeneinheit der Achse.
8. Ermitteln Sie die tatsächliche Skalierung der Haupteinheit der Achse.
9. Ermitteln Sie die tatsächliche Skalierung der Nebeneinheit der Achse.

Dieser Beispielcode – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie die erforderlichen Werte in Python erhalten:
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


## **Austausch der Daten zwischen Achsen**
Aspose.Slides ermöglicht es Ihnen, die Daten zwischen Achsen schnell zu vertauschen – die auf der vertikalen Achse (Y‑Achse) dargestellten Daten werden zur horizontalen Achse (X‑Achse) und umgekehrt verschoben.

Dieser Python‑Code zeigt, wie Sie den Datenaustausch zwischen Achsen in einem Diagramm durchführen:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellt leere Präsentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Wechselt Zeilen und Spalten
            
    # Speichert die Präsentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Deaktivieren der Vertikalachse für Liniendiagramme**
Dieser Python‑Code zeigt, wie Sie die Vertikalachse für ein Liniendiagramm ausblenden:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```


## **Deaktivieren der Horizontalachse für Liniendiagramme**
Dieser Code zeigt, wie Sie die Horizontalachse für ein Liniendiagramm ausblenden:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Ändern der Kategorienachse**
Mit der Eigenschaft **CategoryAxisType** können Sie Ihren bevorzugten Typ der Kategorienachse (**date** oder **text**) festlegen. Dieser Python‑Code demonstriert die Vorgehensweise: 
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


## **Festlegen des Datumsformats für den Wert der Kategorienachse**
Aspose.Slides für Python via .NET ermöglicht es Ihnen, das Datumsformat für einen Kategorienachsenwert festzulegen. Der Vorgang wird in diesem Python‑Code gezeigt:
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
Aspose.Slides für Python via .NET ermöglicht es Ihnen, den Rotationswinkel für einen Diagrammachsentitel festzulegen. Dieser Python‑Code demonstriert den Vorgang:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```


## **Festlegen der Position der Achse in einer Kategorien‑ oder Werteachse**
Aspose.Slides für Python via .NET ermöglicht es Ihnen, die Position der Achse in einer Kategorien‑ oder Werteachse festzulegen. Dieser Python‑Code zeigt, wie die Aufgabe ausgeführt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


## **Aktivieren der Anzeigeeinheitsbeschriftung auf der Werteachse des Diagramms**
Aspose.Slides für Python via .NET ermöglicht es Ihnen, ein Diagramm so zu konfigurieren, dass eine Einheitensbeschriftung auf seiner Werteachse angezeigt wird. Dieser Python‑Code demonstriert den Vorgang:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Wie lege ich den Wert fest, an dem sich eine Achse mit der anderen schneidet (Achsenkreuzung)?**

Achsen bieten eine [crossing setting](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): Sie können wählen, bei Null, beim maximalen Kategorie‑/Wert‑Punkt oder bei einem bestimmten numerischen Wert zu kreuzen. Dies ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder um eine Basislinie hervorzuheben.

**Wie kann ich die Tick‑Beschriftungen relativ zur Achse positionieren (neben, außen, innen)?**

Setzen Sie die [label position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) auf "cross", "outside" oder "inside". Dies beeinflusst die Lesbarkeit und hilft, insbesondere bei kleinen Diagrammen Platz zu sparen.