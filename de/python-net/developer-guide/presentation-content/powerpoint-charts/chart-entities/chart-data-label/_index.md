---
title: Diagrammdatenauszeichnungen in Präsentationen mit Python verwalten
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
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenauszeichnungen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---

## **Übersicht**

Datenauszeichnungen in einem Diagramm zeigen Details zur Diagrammdatenreihe oder zu einzelnen Datenpunkten an. Sie ermöglichen es dem Leser, Datenreihen schnell zu erkennen, und machen Diagramme leichter verständlich. In Aspose.Slides für Python können Sie Datenauszeichnungen für jedes Diagramm aktivieren, anpassen und formatieren – Sie wählen, was angezeigt werden soll (Werte, Prozentsätze, Reihen‑ oder Kategorienamen), wo die Beschriftungen positioniert werden und wie sie aussehen (Schriftart, Zahlenformat, Trennzeichen, Führungs‑Linien und mehr). Dieser Artikel gibt einen Überblick über die wichtigsten APIs und Beispiele, die Sie benötigen, um klare, informative Beschriftungen zu Ihren Diagrammen hinzuzufügen.

## **Datenauszeichnungs‑Präzision festlegen**

Diagrammdatenauszeichnungen zeigen häufig numerische Werte, die eine einheitliche Präzision erfordern. Dieser Abschnitt zeigt, wie Sie die Anzahl der Dezimalstellen für Datenauszeichnungen in Aspose.Slides durch Anwendung eines geeigneten Zahlenformats steuern.

Das folgende Python‑Beispiel zeigt, wie Sie die numerische Präzision für Diagrammdatenauszeichnungen festlegen:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Prozentsätze als Beschriftungen anzeigen**

Mit Aspose.Slides können Sie Prozentsätze als Datenauszeichnungen in Diagrammen anzeigen. Das nachstehende Beispiel berechnet den Anteil jedes Punktes innerhalb seiner Kategorie und formatiert die Beschriftung, um den Prozentsatz anzuzeigen.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Save the presentation containing the chart.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Prozentzeichen bei Diagrammdatenauszeichnungen anzeigen**

Dieser Abschnitt zeigt, wie Sie Prozentsätze in Diagrammdatenauszeichnungen anzeigen und das Prozentzeichen mithilfe von Aspose.Slides hinzufügen. Sie lernen, wie Sie Prozentwerte für ganze Reihen oder einzelne Punkte aktivieren (ideal für Kreis‑, Ring‑ und 100 % gestapelte Diagramme) und wie Sie die Formatierung über Beschriftungsoptionen oder ein benutzerdefiniertes Zahlenformat steuern.

Das folgende Python‑Beispiel zeigt, wie Sie einem Diagramm‑Datenauszeichnungs‑Text ein Prozentzeichen hinzufügen:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a slide reference by index.
    slide = presentation.slides[0]

    # Create a PercentsStackedColumn chart on the slide.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Get the chart data workbook.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Add a new series.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Set the series fill color.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Set label format properties.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Add a new series.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Set the fill type and color.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Save the presentation.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Beschriftungsabstand von der Achse festlegen**

Dieser Abschnitt zeigt, wie Sie den Abstand zwischen Datenauszeichnungen und der Diagrammachse in Aspose.Slides steuern. Das Anpassen dieses Versatzes verhindert Überlappungen und verbessert die Lesbarkeit bei dichten Visualisierungen.

Der folgende Python‑Code zeigt, wie Sie den Beschriftungsabstand von der Kategorienachse bei einem achsbasierten Diagramm festlegen:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Get a slide reference.
    slide = presentation.slides[0]

    # Create a clustered column chart on the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Set the label distance from the category (horizontal) axis.
    chart.axes.horizontal_axis.label_offset = 500

    # Save the presentation.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Beschriftungsposition anpassen**

Wenn Sie ein Diagramm erstellen, das keine Achsen verwendet, z. B. ein Kreis‑Diagramm, können die Datenauszeichnungen zu nahe am Rand liegen. In diesem Fall passen Sie die Beschriftungsposition an, damit Führungs‑Linien klar sichtbar sind.

Der folgende Python‑Code zeigt, wie Sie die Beschriftungsposition bei einem Kreis‑Diagramm anpassen:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Geänderte Beschriftungsposition](changed_label_position.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenauszeichnungen bei dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Führungs‑Linien und kleinere Schriftgrößen; bei Bedarf einzelne Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für extreme/ Schlüssel‑Punkte anzeigen.

**Wie kann ich Beschriftungen nur für Null‑, Negativ‑ oder leere Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte nach einer definierten Regel aus.

**Wie stelle ich einen konsistenten Beschriftungsstil beim Export nach PDF/Bildern sicher?**

Setzen Sie Schriftarten (Familie, Größe) explizit und prüfen Sie, dass die Schriftart auf der Rendering‑Seite verfügbar ist, um Fallback‑Schriften zu vermeiden.