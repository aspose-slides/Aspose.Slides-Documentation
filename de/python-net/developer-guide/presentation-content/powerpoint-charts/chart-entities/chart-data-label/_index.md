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
description: "Erfahren Sie, wie Sie Diagrammdatenbeschriftungen in PowerPoint‑Präsentationen mithilfe von Aspose.Slides für Python via .NET hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---
## **Einleitung**

Datenbeschriftungen zeigen Informationen zu Diagrammserien und einzelnen Datenpunkten an und helfen den Lesern, Werte zu identifizieren und das Diagramm zu verstehen. Dieser Artikel erklärt, wie Werte formatiert, Prozentsätze angezeigt, Beschriftungstexte ausgelesen, Beschriftungen jenseits des Achsenmaximums gesteuert, der Abstand von Kategorienachsenbeschriftungen angepasst und Beschriftungen von Kreisdiagrammen positioniert werden.

## **Datenpräzision in Diagrammbeschriftungen festlegen**

Verwenden Sie [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/), um Serienwerte zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Standarddaten, zeigt dessen Datentabelle an und aktiviert Wertebeschriftungen für die erste Serie. Das Format `#,##0.00` zeigt ein Tausendertrennzeichen und zwei Dezimalstellen an, ohne die zugrunde liegenden Werte zu ändern.

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

## **Prozentsatz als Beschriftungen anzeigen**

Für ein gestapeltes Säulendiagramm berechnen Sie jeden Wert als Prozentsatz seiner Kategoriensumme und weisen den Text [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) zu. Dieses Beispiel verwendet die Standarddiagrammdaten und zeigt Prozentsätze mit zwei Dezimalstellen in einer 8‑Pt‑Schrift an. Kategorien mit einer Gesamtsumme von Null werden übersprungen, um eine Division durch Null zu vermeiden. Berechnen Sie den benutzerdefinierten Beschriftungstext neu, wenn sich die Diagrammdaten ändern.

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

## **Prozentzeichen mit Diagrammbeschriftungen festlegen**

Wenn Werte als Brüche gespeichert sind, verwenden Sie [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/), um Prozentsätze anzuzeigen. Setzen Sie [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) auf `False`, um das Beschriftungsformat unabhängig von den Quellzellen anzuwenden.

Dieses Beispiel erstellt ein 100 % gestapeltes Säulendiagramm mit roten und blauen Serien über vier Kategorien. Jeder Wertepaar summiert sich zu 1. Das Beschriftungsformat `0.0%` zeigt 0.30 als 30.0 % an, während die vertikale Achse zwei Dezimalstellen verwendet. Beide Serien verwenden weiße Beschriftungen mit 10 Pt.

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

## **Den tatsächlichen Text von Datenbeschriftungen auslesen**

Verwenden Sie [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/), um den durch die Einstellungen einer Datenbeschriftung erzeugten Text abzurufen. Dies ist nützlich, wenn Beschriftungen für Berichte extrahiert, Präsentationsinhalte durchsucht oder generierte Diagramme validiert werden. Im folgenden Beispiel kombiniert das Standard‑[data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) jeweils den Namen der Kategorie, den Namen der Serie und den Wert. Ein Punkt formatiert seinen Wert als Prozentsatz, ein anderer verwendet benutzerdefinierten Text aus [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Die in einem Datenpunkt gespeicherte Zahl bleibt `0.75`, selbst wenn seine Beschriftung `75 %` zusammen mit den Kategorie‑ und Seriennamen anzeigt. Benutzerdefinierter Text ersetzt die automatisch erzeugte Beschriftung. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) liefert in beiden Fällen den resultierenden Beschriftungsstring. Prüfen Sie [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) separat, wie oben gezeigt, wenn Sie nur sichtbare Beschriftungen extrahieren möchten.

## **Datenbeschriftungen jenseits des Achsenmaximums steuern**

Wenn Sie einen Achsenbereich manuell begrenzen, können einige Datenpunkte dessen Maximum überschreiten. Verwenden Sie [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/), um zu bestimmen, ob deren Datenbeschriftungen angezeigt werden. Diese Einstellung ändert die Sichtbarkeit der Beschriftungen; sie ändert weder den Achsenbereich noch die zugrunde liegenden Werte.

Das folgende Beispiel erstellt ein 2D‑ gruppiertes Säulendiagramm mit Werten 60 und 120. Es setzt [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) auf `False` und [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) auf 100 für die vertikale Achse. Die erste Folie erlaubt Beschriftungen über dem Maximum; eine Kopie dieser Folie deaktiviert sie. Beide Folien werden in `DataLabelsOverMaximum.pptx` gespeichert.

Aktivieren Sie Wertebeschriftungen mit [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Die Einstellung auf Diagrammebene aktiviert die Wertanzeige nicht eigenständig und überschreibt nicht die deaktivierte Anzeige einzelner Beschriftungen. Dieses Beispiel aktiviert Werte für die gesamte Serie und verwendet [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/), um die Beschriftungen am äußeren Ende jeder Säule zu platzieren.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Die folgenden Bilder zeigen die gespeicherten Folien, wie sie von Microsoft PowerPoint gerendert werden. Bei `True` ist die Beschriftung **120** an der oberen Grenze sichtbar; bei `False` ist sie verborgen. Die Beschriftung **60** bleibt sichtbar, das Achsenmaximum bleibt **100**, und der zweite Datenpunkt bleibt **120** in beiden Fällen.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Diagrammtyp" %}}

Dieses Beispiel verwendet ein 2D‑Säulendiagramm mit einer Wertachse. Diagramme ohne Wertachse, wie Kreis‑ und Donut‑Diagramme, besitzen kein Achsenmaximum, das auf diese Weise begrenzt werden könnte.

{{% /alert %}}

## **Abstand der Beschriftung von einer Achse festlegen**

Verwenden Sie [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/), um den Abstand zwischen den Kategorienachsen‑Beschriftungen und der Achse zu steuern. Der Wert ist ein Prozentsatz der maximalen Schriftgröße der Achsenbeschriftungen. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm und setzt den Horizontalachsen‑Beschriftungsversatz auf 500. Diese Einstellung wirkt sich auf die Kategorienachsen‑Beschriftungen aus, nicht auf Beschriftungen, die einzelnen Datenpunkten zugewiesen sind.

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

Bei einem Kreis‑Diagramm können Sie die Position der Datenbeschriftungen anpassen, um Abstände zu verbessern und Platz für Führungslinien zu schaffen.

Dieses Beispiel zeigt den Wert des ersten Datenpunkts, platziert seine Beschriftung außerhalb des Sektors und passt die [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/)‑ und [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/)‑Versätze an. Diese Versätze beziehen sich jeweils auf die Diagrammbreite bzw. -höhe.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Mehrere Zeilen Datenbeschriftungen über einem Säulendiagramm hinzufügen**

Dieses Beispiel erstellt ein Säulendiagramm mit zwei Zeilen Datenbeschriftungen über dem Plot‑Bereich. Serie A zeigt die sichtbaren Säulen, während Serie B und Serie C die zusätzlichen Beschriftungen bereitstellen. Ihre Säulen werden ausgeblendet, indem Füllung und Kontur entfernt werden. Die [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/)‑Eigenschaft richtet alle drei Serien mit denselben Kategorienzentren aus.

Die [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/)‑Einstellungen reservieren Platz für die Beschriftungszeilen. Nachdem [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) die Standardpositionen berechnet hat, erhalten [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) und [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) die horizontale Ausrichtung und erhalten vertikale Versätze, um die Beschriftungen in zwei Zeilen anzuordnen. Die Zahlen bleiben Datenbeschriftungen, die mit den Serienwerten verknüpft sind; nur die Zeilenüberschriften sind separate Textformen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Verstecke die Spalten von B und C, aber behalte deren Datenbeschriftungen bei.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Richte alle drei Serien an denselben Kategorienzentren aus.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Verwende weniger Gitternetzlinien für dieses kompakte Beispiel.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Reserviere Platz über dem Plot für zwei Zeilen Datenbeschriftungen.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Behalte die Standard‑horizontal‑Position bei.
            # die Standard‑Beschriftungsposition, ausgedrückt als Bruchteil der Diagrammhöhe.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Nur die Zeilenüberschrift ist eine separate Textform.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen in dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Führungslinien und reduzierte Schriftgröße; bei Bedarf einzelne Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für Extrem‑ oder Schlüsselpunkte anzeigen.

**Wie kann ich Beschriftungen nur für Null‑, negative  oder leere Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen einheitlichen Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Setzen Sie Schriftfamilie und -größe explizit und prüfen Sie, dass die Schrift in der Rendering‑Umgebung verfügbar ist, um Fallbacks zu vermeiden.