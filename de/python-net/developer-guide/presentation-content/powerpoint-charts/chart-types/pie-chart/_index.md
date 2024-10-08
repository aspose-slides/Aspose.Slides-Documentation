---
title: Kuchendiagramm
type: docs
url: /de/python-net/pie-chart/
keywords: "Kuchendiagramm, Plot-Optionen, Slice-Farben, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Plot-Optionen für Kuchendiagramme und Slice-Farben in PowerPoint-Präsentationen in Python"
---

## **Zweite Plot-Optionen für Kuchendiagramme und Balkendiagramme**
Aspose.Slides für Python über .NET unterstützt jetzt zweite Plot-Optionen für Kuchendiagramme oder Balkendiagramme. In diesem Thema werden wir anhand eines Beispiels sehen, wie man diese Optionen mit Aspose.Slides angibt. Um die Eigenschaften anzugeben, folgen Sie bitte den folgenden Schritten:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klassenobjekt.
1. Fügen Sie das Diagramm auf der Folie hinzu.
1. Geben Sie die zweiten Plot-Optionen des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir verschiedene Eigenschaften des Kuchendiagramms eingestellt.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    # Fügen Sie das Diagramm auf der Folie hinzu
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Stellen Sie verschiedene Eigenschaften ein
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Schreiben Sie die Präsentation auf die Festplatte
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Automatische Kuchendiagramm-Slice-Farben festlegen**
Aspose.Slides für Python über .NET bietet eine einfache API zum Festlegen automatischer Farben für Kuchendiagramm-Slices. Der Beispielcode zeigt, wie man die oben genannten Eigenschaften festlegt.

1. Erstellen Sie eine Instanz der Presentation-Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie den Diagrammtitel.
1. Setzen Sie die erste Serie auf Werte anzeigen.
1. Setzen Sie den Index des Datensatzblatts des Diagramms.
1. Holen Sie sich das Datenarbeitsblatt des Diagramms.
1. Löschen Sie die standardmäßig generierten Serien und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei darstellt
with slides.Presentation() as presentation:
	# Greifen Sie auf die erste Folie zu
	slide = presentation.slides[0]

	# Fügen Sie ein Diagramm mit Standarddaten hinzu
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Setzen Sie den Diagrammtitel
	chart.chart_title.add_text_frame_for_overriding("Beispieltitel")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Setzen Sie die erste Serie auf Werte anzeigen
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Setzen Sie den Index des Datenblatts des Diagramms
	defaultWorksheetIndex = 0

	# Holen Sie sich das Datenarbeitsblatt des Diagramms
	fact = chart.chart_data.chart_data_workbook

	# Löschen Sie die standardmäßig generierten Serien und Kategorien
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Hinzufügen neuer Kategorien
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "Erstes Quartal"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "Zweites Quartal"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "Drittes Quartal"))

	# Hinzufügen neuer Serien
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Serie 1"), chart.type)

	# Jetzt die Seriendaten ausfüllen
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```