---
title: Diagrammdatenbeschriftung
type: docs
url: /de/python-net/chart-data-label/
keywords: "Diagrammdatenbeschriftung,Beschriftungsabstand, Python, Aspose.Slides für Python über .NET"
description: "Diagrammdatenbeschriftung und Abstand in Python festlegen"
---

Datenbeschriftungen in einem Diagramm zeigen Details zu den Datensätzen oder einzelnen Datenpunkten. Sie ermöglichen es den Lesern, Datensätze schnell zu identifizieren, und machen Diagramme leichter verständlich.

## **Genauigkeit der Daten in Diagrammdatenbeschriftungen festlegen**

Dieser Python-Code zeigt, wie Sie die Datenpräzision in einer Diagrammdatenbeschriftung festlegen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
	chart.has_data_table = True
	chart.chart_data.series[0].number_format_of_values = "#,##0.00"

	pres.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Prozentsätze als Beschriftungen anzeigen**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, Prozentanteile in angezeigten Diagrammen festzulegen. Dieser Python-Code demonstriert die Operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellt eine Instanz der Präsentationsklasse
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)
    series = chart.chart_data.series[0]
    total_for_Cat = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        cat = chart.chart_data.categories[k]
        for i in range(len(chart.chart_data.series)):
            total_for_Cat[k] += chart.chart_data.series[i].data_points[k].value.data

dataPontPercent = 0

for x in range(len(chart.chart_data.series)):
    series = chart.chart_data.series[x]
    series.labels.default_data_label_format.show_legend_key = False

    for j in range(len(series.data_points)):
        lbl = series.data_points[j].label
        dataPontPercent = series.data_points[j].value.data / total_for_Cat[j] * 100

        port = slides.Portion()
        port.text = "{0:.2f} %".format(dataPontPercent)
        port.portion_format.font_height = 8
        lbl.text_frame_for_overriding.text = ""
        para = lbl.text_frame_for_overriding.paragraphs[0]
        para.portions.add(port)

        lbl.data_label_format.show_series_name = False
        lbl.data_label_format.show_percentage = False
        lbl.data_label_format.show_legend_key = False
        lbl.data_label_format.show_category_name = False
        lbl.data_label_format.show_bubble_size = False

# Speichert die Präsentation, die das Diagramm enthält
presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Prozentsymbol mit Diagrammdatenbeschriftungen festlegen**
Dieser Python-Code zeigt, wie Sie das Prozentsymbol für eine Diagrammdatenbeschriftung festlegen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellt eine Instanz der Präsentationsklasse
with slides.Presentation() as presentation:

    # Holt eine Referenz auf eine Folie über ihren Index
    slide = presentation.slides[0]

    # Erstellt das ProzentGestapelteSäulendiagramm auf einer Folie
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    # Sets the NumberFormatLinkedToSource to false
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    defaultWorksheetIndex = 0

    # Holt das Diagrammdatenarbeitsblatt
    workbook = chart.chart_data.chart_data_workbook

    # Fügt neue Serien hinzu
    series = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 1, 0.65))

    # Setzt die Füllfarbe der Serie
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Setzt die LabelFormat-Eigenschaften
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Fügt neue Serien hinzu
    series2 = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 2, 0.35))

    # Setzt Fülltyp und Farbe
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Schreibt die Präsentation auf die Festplatte
    presentation.save("SetDatalabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Abstand der Beschriftung von der Achse festlegen**
Dieser Python-Code zeigt, wie Sie den Abstand der Beschriftung von einer Kategorienachse festlegen, wenn Sie ein Diagramm erstellen, das von Achsen gezeichnet wird:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

	# Erstellt eine Instanz der Präsentationsklasse
with slides.Presentation() as presentation:
    # Holt eine Referenz auf eine Folie
    sld = presentation.slides[0]
    
    # Erstellt ein Diagramm auf der Folie
    ch = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Setzt den Abstand der Beschriftung von einer Achse
    ch.axes.horizontal_axis.label_offset = 500

    # Schreibt die Präsentation auf die Festplatte
    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Standort der Beschriftung anpassen**

Wenn Sie ein Diagramm erstellen, das nicht auf einer Achse basiert, wie z.B. ein Kuchendiagramm, können die Datenbeschriftungen zu nah am Rand des Diagramms sein. In einem solchen Fall müssen Sie den Standort der Datenbeschriftung anpassen, damit die Führungsleitungen klar angezeigt werden.

Dieser Python-Code zeigt, wie Sie den Standort der Beschriftung in einem Kuchendiagramm anpassen:

```python
import aspose.slides as slides


with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 200, 200)

    series = chart.chart_data.series
    label = series[0].labels[0]

    label.data_label_format.show_value = True
    label.data_label_format.position = slides.charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![kuchendiagramm-angepasste-beschriftung](pie-chart-adjusted-label.png)