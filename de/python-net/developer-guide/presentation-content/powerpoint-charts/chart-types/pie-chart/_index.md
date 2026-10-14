---
title: Kreisdiagramme in Präsentationen mit Python anpassen
linktitle: Kreisdiagramm
type: docs
url: /de/python-net/pie-chart/
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
- Aspose.Slides
description: "Erstellen und Anpassen von Kreisdiagrammen in Python mit Aspose.Slides. Konfigurieren Sie sekundäre Plots, zeigen Sie Datenbeschriftungen an und wenden Sie automatische Segmentfarben in PowerPoint an."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Kreisdiagrammen in Aspose.Slides arbeitet. Er zeigt, wie sekundäre Plot‑Optionen für Pie‑of‑Pie‑ und Bar‑of‑Pie‑Diagramme konfiguriert werden und wie die automatische Färbung von Segmenten für ein Standard‑Kreisdiagramm aktiviert wird.

Die Beispiele konzentrieren sich auf Aufgaben zur Diagrammanpassung, wie das Hinzufügen eines Diagramms zu einer Folie, das Anpassen von Serien‑ und Beschriftungseinstellungen, das Ersetzen der Standarddiagrammdaten durch benutzerdefinierte Kategorien und Werte sowie das Speichern der aktualisierten Präsentation.

## **Zweite Plot‑Optionen für Pie‑of‑Pie‑ und Bar‑of‑Pie‑Diagramme**

Aspose.Slides for Python via .NET unterstützt sekundäre Plot‑Optionen für Pie‑of‑Pie‑ und Bar‑of‑Pie‑Diagramme. Diese Optionen steuern die Größe des sekundären Plots und wie Datenpunkte zwischen den beiden Plots aufgeteilt werden.

Das folgende Beispiel erstellt ein Pie‑of‑Pie‑Diagramm in einer neuen Präsentation und zeigt die Werte der Datenpunkte als Beschriftungen an. Die [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) Eigenschaft legt die Größe des sekundären Plots auf 149 % des Hauptplots fest. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) wählt eine prozentbasierte Aufteilung, und [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) setzt die Schwelle auf 53 %.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Werte anzeigen und den sekundären Plot konfigurieren.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Auswählen von Kategorien für den sekundären Plot**

Verwenden Sie benutzerdefiniertes Aufteilen, wenn Sie bestimmte Kategorien im sekundären Plot gruppieren möchten, unabhängig von ihren prozentualen Werten. Beispielsweise könnte ein Verkaufsbericht Online und Events zusammen anzeigen, damit die Leser diese beiden Kanäle vergleichen können, obwohl sie 35 % bzw. 10 % des Gesamtumsatzes ausmachen.

Setzen Sie [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) auf [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) und wählen Sie die Punkte über [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/) aus. Die [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) Methode der Sammlung akzeptiert entweder einen nullbasierten Index in der Serie oder ein Datenpunkt‑Objekt. In diesem Beispiel wählt Index 1 Online aus, und der Punkt bei Index 3 wählt Events aus. Partners wird ebenfalls vorübergehend hinzugefügt und anschließend mit [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/) ausgeschlossen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Ersetzen Sie die Standarddaten durch Verkäufe nach Kanal.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Wählen Sie Online anhand seines nullbasierten Index und Events anhand seines Datenpunktobjekts aus.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Schließen Sie Partners von der Auswahl aus, ohne die Quelldaten zu löschen.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) und Events (10) erscheinen als separate Segmente im sekundären Plot. Im primären Plot werden sie durch ein kombiniertes Segment mit dem Wert 45 dargestellt, zusammen mit Retail (40) und Partners (15). Das Entfernen von Partners aus der benutzerdefinierten Auswahl lässt es im primären Plot erhalten; es entfernt die Kategorie oder ihren Wert nicht aus den Quelldaten des Diagramms.

Das folgende Bild zeigt die gespeicherte Präsentation in PowerPoint:

![Pie‑of‑Pie‑Diagramm mit Online und Events im sekundären Plot und ihrem kombinierten Wert von 45 im primären Plot](pie_of_pie_custom.png)

## **Automatisches Festlegen der Farben von Pie‑Chart‑Segmenten**

Aspose.Slides for Python via .NET kann Diagrammsegmenten automatisch unterschiedliche Farben zuweisen. Das folgende Beispiel erstellt ein Kreisdiagramm mit zentriertem Titel und ersetzt die Standarddaten durch drei Quartalskategorien und deren Werte. Die [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) Eigenschaft zeigt die Werte 20, 50 und 30 als Beschriftungen an, während [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) für jedes Segment eine unterschiedliche Farbe aktiviert.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Fügen Sie einen zentrierten Diagrammtitel hinzu.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Ersetzen Sie die Standarddaten mithilfe des ersten Arbeitsblatts.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Werte anzeigen und den Segmenten unterschiedliche Farben zuweisen.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Werden die Pie‑of‑Pie‑ und Bar‑of‑Pie‑Varianten unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) einen sekundären Plot für Kreisdiagramme, einschließlich der Pie‑of‑Pie‑ und Bar‑of‑Pie‑Typen.

**Kann ich nur das Diagramm als Bild exportieren (zum Beispiel PNG)?**

Ja, Sie können [das Diagramm selbst als Bild exportieren](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (z. B. PNG) exportieren, ohne die gesamte Präsentation zu exportieren.