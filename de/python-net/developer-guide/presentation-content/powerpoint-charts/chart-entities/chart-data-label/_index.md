---
title: Diagrammdatenbeschriftungen in Präsentationen mit Python verwalten
linktitle: Datenbeschriftung
type: docs
url: /de/python-net/chart-data-label/
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
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenbeschriftungen in PowerPoint-Präsentationen mit Aspose.Slides für Python über .NET hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---
## **Einleitung**

Datenbeschriftungen zeigen Informationen über Diagrammserien und einzelne Datenpunkte an und helfen den Lesern, Werte zu identifizieren und das Diagramm zu verstehen. Dieser Artikel erklärt, wie Werte formatiert, Prozentsätze angezeigt, Beschriftungstexte gelesen, der Abstand von Kategorienachsenbeschriftungen angepasst und Beschriftungen von Kreisdiagrammen positioniert werden.

## **Datenpräzision in Diagramm-Datenbeschriftungen festlegen**

Verwenden Sie [number_format_of_values](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/number_format_of_values/), um Serienwerte zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Standarddaten, zeigt seine Datentabelle an und aktiviert Wertebeschriftungen für die erste Serie. Das Format `#,##0.00` zeigt ein Tausendertrennzeichen und zwei Dezimalstellen an, ohne die zugrunde liegenden Werte zu ändern.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Prozentsätze als Beschriftungen anzeigen**

Für ein gestapeltes Säulendiagramm berechnet man jeden Wert als Prozentsatz der Gesamtsumme seiner Kategorie und weist den Text [text_frame_for_overriding](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) zu. Dieses Beispiel verwendet die Standarddiagrammdaten und zeigt Prozentsätze mit zwei Dezimalstellen in einer 8‑Punkt‑Schrift an. Kategorien mit einer Gesamtsumme von Null werden übersprungen, um eine Division durch Null zu vermeiden. Berechnen Sie den benutzerdefinierten Beschriftungstext neu, wenn sich die Diagrammdaten ändern.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Prozentzeichen mit Diagramm-Datenbeschriftungen festlegen**

Wenn Werte als Bruchteile gespeichert sind, verwenden Sie [number_format](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabelformat/number_format/), um Prozentsätze anzuzeigen. Setzen Sie [is_number_format_linked_to_source](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) auf `False`, um das Beschriftungsformat unabhängig von den Quelldaten anzuwenden.

Dieses Beispiel erstellt ein 100‑% gestapeltes Säulendiagramm mit roten und blauen Serien über vier Kategorien. Jede Wertepaare summieren sich zu 1. Das Beschriftungsformat `0.0%` zeigt 0.30 als 30.0 % an, während die vertikale Achse zwei Dezimalstellen verwendet. Beide Serien verwenden weiße Beschriftungen mit 10 Punkt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Den tatsächlichen Text von Datenbeschriftungen lesen**

Verwenden Sie [get_actual_label_text](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabel/get_actual_label_text/), um den durch die Einstellungen einer Datenbeschriftung erzeugten Text abzurufen. Dies ist nützlich beim Extrahieren von Beschriftungen für Berichte, Durchsuchen von Präsentationsinhalten oder Validieren generierter Diagramme. Im nachstehenden Beispiel kombiniert das Standard‑[Datenbeschriftungsformat](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabelformat/) den Namen jeder Kategorie, den Namen der Serie und den Wert. Ein Punkt formatiert seinen Wert als Prozentsatz, ein anderer verwendet benutzerdefinierten Text aus [text_frame_for_overriding](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Die in einem Datenpunkt gespeicherte Zahl bleibt `0.75`, auch wenn die Beschriftung `75 %` zusammen mit den Kategorie‑ und Serientnamen anzeigt. Benutzerdefinierter Text ersetzt den generierten Beschriftungstext. [get_actual_label_text](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) gibt den resultierenden Beschriftungsstring in beiden Fällen zurück. Prüfen Sie [is_visible](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabel/is_visible/) separat, wie oben gezeigt, wenn Sie nur sichtbare Beschriftungen extrahieren möchten.

## **Beschriftungsabstand von einer Achse festlegen**

Verwenden Sie [label_offset](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/axis/label_offset/), um den Abstand zwischen den Kategorienachsen‑Beschriftungen und der Achse zu steuern. Der Wert ist ein Prozentsatz der maximalen Schriftgröße der Achsenbeschriftungen. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm und setzt den Beschriftungsoffset der horizontalen Achse auf 500. Diese Einstellung wirkt sich auf Kategorienachsen‑Beschriftungen aus, nicht auf an einzelne Datenpunkte angehängte Beschriftungen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Beschriftungsposition anpassen**

Passen Sie bei einem Kreisdiagramm die Positionen der Datenbeschriftungen an, um den Abstand zu verbessern und Platz für Führungslinien zu schaffen.

Dieses Beispiel zeigt den Wert des ersten Datenpunkts, legt seine Beschriftung außerhalb des Segments und passt die [x](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabel/x/)‑ und [y](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabel/y/)‑Offsets an. Diese Offsets beziehen sich jeweils auf die Diagrammbreite bzw. -höhe.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Kreisdiagramm mit angepasster Datenbeschriftungsposition](pie-chart-adjusted-label.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen in dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Führungslinien und reduzierte Schriftgröße; bei Bedarf Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für Extremwerte oder Schlüssel­punkte anzeigen.

**Wie kann ich Beschriftungen nur für Null‑, Negative‑ oder Leere‑Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren nach PDF/Bildern sicherstellen?**

Setzen Sie Schriftfamilie und -größe explizit und prüfen Sie, dass die Schriftart in der Renderumgebung verfügbar ist, um ein Fallback zu vermeiden.