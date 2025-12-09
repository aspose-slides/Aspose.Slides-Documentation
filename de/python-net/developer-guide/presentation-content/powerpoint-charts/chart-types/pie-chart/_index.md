---
title: "Anpassen von Kreisdiagrammen in Präsentationen mit Python"
linktitle: "Kreisdiagramm"
type: docs
url: /de/python-net/pie-chart/
keywords:
- "Kreisdiagramm"
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
description: "Erfahren Sie, wie Sie mit Python und Aspose.Slides Kreisdiagramme erstellen und anpassen, exportierbar nach PowerPoint und OpenDocument, und Ihre Datenpräsentation in Sekunden verbessern."
---

## **Optionen für den sekundären Plot für Kreis‑von‑Kreis‑ und Balken‑von‑Kreis‑Diagramm**
Aspose.Slides für Python über .NET unterstützt jetzt Optionen für den sekundären Plot für Kreis‑von‑Kreis‑ oder Balken‑von‑Kreis‑Diagramme. In diesem Thema sehen wir anhand eines Beispiels, wie man diese Optionen mit Aspose.Slides festlegt. Bitte folgen Sie den untenstehenden Schritten:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klassenobjekt.
1. Fügen Sie dem Folienblatt ein Diagramm hinzu.
1. Geben Sie die Optionen für den sekundären Plot des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im nachfolgenden Beispiel haben wir verschiedene Eigenschaften des Kreis‑von‑Kreis‑Diagramms festgelegt.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    # Diagramm zur Folie hinzufügen
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Verschiedene Eigenschaften festlegen
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Präsentation auf die Festplatte schreiben
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```





## **Automatische Farben für Kuchendiagramm‑Segmente festlegen**
Aspose.Slides für Python über .NET bietet eine einfache API zum Festlegen automatischer Farben für Kuchendiagramm‑Segmente. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Presentation‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie den Diagrammtitel.
1. Lassen Sie die erste Datenreihe Werte anzeigen.
1. Legen Sie den Index des Diagrammdatenblatts fest.
1. Abrufen des Diagrammdaten‑Arbeitsblatts.
1. Löschen Sie die standardmäßig erzeugten Reihen und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Reihen hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt
with slides.Presentation() as presentation:
	# Zugriff auf die erste Folie
	slide = presentation.slides[0]

	# Diagramm mit Standarddaten hinzufügen
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Diagrammtitel festlegen
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Erste Serie auf Werte anzeigen setzen
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Index des Diagrammdatenblatts festlegen
	defaultWorksheetIndex = 0

	# Diagrammdaten-Arbeitsblatt abrufen
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

**Werden die Varianten „Pie of Pie“ und „Bar of Pie“ unterstützt?**

Ja, die Bibliothek [supports](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) einen sekundären Plot für Kuchendiagramme, einschließlich der Typen „Pie of Pie“ und „Bar of Pie“.

**Kann ich nur das Diagramm als Bild exportieren (z. B. PNG)?**

Ja, Sie können [export the chart itself as an image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (z. B. PNG) ohne die gesamte Präsentation.