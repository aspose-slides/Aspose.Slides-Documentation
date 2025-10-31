---
title: Diagrammachsen in Präsentationen mit Python anpassen
linktitle: Diagrammarchse
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
- maximaler Wert
- minimaler Wert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für Python über .NET verwenden, um Diagrammachsen in PowerPoint- und OpenDocument-Präsentationen für Berichte und Visualisierungen anzupassen."
---

## **Ermitteln der Maximalwerte auf der vertikalen Achse von Diagrammen**
Aspose.Slides für Python über .NET ermöglicht das Abrufen der minimalen und maximalen Werte einer vertikalen Achse. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
4. Ermitteln Sie den tatsächlichen maximalen Wert der Achse.  
5. Ermitteln Sie den tatsächlichen minimalen Wert der Achse.  
6. Ermitteln Sie die tatsächliche Haupteinheit der Achse.  
7. Ermitteln Sie die tatsächliche Nebeneinheit der Achse.  
8. Ermitteln Sie die tatsächliche Hauptskalierung der Achse.  
9. Ermitteln Sie die tatsächliche Nebenskala der Achse.  

Dieses Beispiel—eine Umsetzung der obigen Schritte—zeigt, wie Sie die erforderlichen Werte in Python erhalten:

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

## **Vertauschen der Daten zwischen Achsen**
Aspose.Slides ermöglicht das schnelle Vertauschen der Daten zwischen Achsen – die auf der vertikalen Achse (y‑Achse) dargestellten Daten werden auf die horizontale Achse (x‑Achse) verschoben und umgekehrt.  

Dieser Python‑Code zeigt, wie Sie den Datentausch zwischen Achsen in einem Diagramm durchführen:

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

Dieser Python‑Code zeigt, wie Sie die vertikale Achse eines Liniendiagramms ausblenden:

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

## **Ändern der Kategorieachse**

Mit der Eigenschaft **CategoryAxisType** können Sie den gewünschten Kategorieachsentyp (**date** oder **text**) festlegen. Dieser Python‑Code demonstriert den Vorgang:

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

## **Festlegen des Datumsformats für Kategorieachsenwerte**
Aspose.Slides für Python über .NET ermöglicht das Festlegen des Datumsformats für einen Kategorieachsenwert. Der Vorgang wird in diesem Python‑Code gezeigt:

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

## **Festlegen des Drehwinkels für den Diagrammachsentitel**
Aspose.Slides für Python über .NET ermöglicht das Festlegen des Drehwinkels für den Diagrammachsentitel. Dieser Python‑Code demonstriert den Vorgang:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Festlegen der Position der Achse in einer Kategorie‑ oder Werteachse**
Aspose.Slides für Python über .NET ermöglicht das Festlegen der Achsenposition in einer Kategorie‑ oder Werteachse. Dieser Python‑Code zeigt, wie die Aufgabe ausgeführt wird:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktivieren der Anzeigeeinheitsbeschriftung auf der Werteachse**
Aspose.Slides für Python über .NET ermöglicht das Konfigurieren eines Diagramms, um eine Einheitbeschriftung auf seiner Werteachse anzuzeigen. Dieser Python‑Code demonstriert den Vorgang:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenschnitt)?**

Achsen bieten eine [crossing setting](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): Sie können wählen, ob sie bei Null, bei der maximalen Kategorie/Wert oder bei einem bestimmten numerischen Wert schneiden. Das ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder um eine Basislinie hervorzuheben.

**Wie kann ich die Beschriftungen der Achsenticks relativ zur Achse positionieren (nebeneinander, außen, innen)?**

Setzen Sie die [label position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) auf „cross“, „outside“ oder „inside“. Dies beeinflusst die Lesbarkeit und hilft, Platz zu sparen, insbesondere bei kleinen Diagrammen.