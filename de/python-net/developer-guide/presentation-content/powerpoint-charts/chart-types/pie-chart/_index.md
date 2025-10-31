---
title: "Kuchendiagramme in Präsentationen mit Python anpassen"
linktitle: "Kuchendiagramm"
type: docs
url: /de/python-net/pie-chart/
keywords:
- "Kuchendiagramm"
- "Diagramm verwalten"
- "Diagramm anpassen"
- "Diagrammoptionen"
- "Diagrammeinstellungen"
- "Plot-Optionen"
- "Segmentfarbe"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie Kuchendiagramme in Python mit Aspose.Slides erstellen und anpassen, exportierbar nach PowerPoint und OpenDocument, und Ihre Datenstorytelling in Sekunden verbessern."
---

## **Zweite Plot-Optionen für Pie‑of‑Pie‑ und Bar‑of‑Pie‑Diagramme**
Aspose.Slides für Python via .NET unterstützt jetzt zweite Plot‑Optionen für Pie‑of‑Pie‑ oder Bar‑of‑Pie‑Diagramme. In diesem Thema sehen wir anhand eines Beispiels, wie man diese Optionen mit Aspose.Slides festlegt. Um die Eigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klassenobjekt.
2. Fügen Sie dem Folie ein Diagramm hinzu.
3. Legen Sie die zweiten Plot‑Optionen des Diagramms fest.
4. Speichern Sie die Präsentation auf dem Datenträger.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    # Diagramm zur Folie hinzufügen
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Unterschiedliche Eigenschaften setzen
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Präsentation auf dem Datenträger speichern
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Automatische Segmentfarben für Kuchendiagramme festlegen**
Aspose.Slides für Python via .NET bietet eine einfache API zum Festlegen automatischer Segmentfarben für Kuchendiagramme. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Presentation‑Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Setzen Sie den Diagrammtitel.
5. Legen Sie für die erste Serie fest, dass Werte angezeigt werden.
6. Setzen Sie den Index des Diagrammdatensheets.
7. Holen Sie das Diagrammdaten‑Arbeitsblatt.
8. Löschen Sie standardmäßig generierte Serien und Kategorien.
9. Fügen Sie neue Kategorien hinzu.
10. Fügen Sie eine neue Serie hinzu.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiere die Presentation-Klasse, die eine PPTX-Datei repräsentiert
with slides.Presentation() as presentation:
	# Greife auf die erste Folie zu
	slide = presentation.slides[0]

	# Füge ein Diagramm mit Standarddaten hinzu
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Titel des Diagramms festlegen
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Erste Serie auf Werte anzeigen setzen
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Index des Diagrammdatensheets festlegen
	defaultWorksheetIndex = 0

	# Diagrammdaten-Arbeitsblatt holen
	fact = chart.chart_data.chart_data_workbook

	# Standardmäßig generierte Serien und Kategorien löschen
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Neue Kategorien hinzufügen
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Neue Serie hinzufügen
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Jetzt die Seriendaten füllen
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Werden die Varianten 'Pie of Pie' und 'Bar of Pie' unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) einen sekundären Plot für Kuchendiagramme, einschließlich der Typen 'Pie of Pie' und 'Bar of Pie'.

**Kann ich nur das Diagramm als Bild exportieren (z. B. PNG)?**

Ja, Sie können das Diagramm selbst als Bild [exportieren](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (z. B. PNG) ohne die gesamte Präsentation.