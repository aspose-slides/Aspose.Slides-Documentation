---
title: Daten Tabelle für Diagramme
type: docs
url: /python-net/chart-data-table/
keywords: "Schriftarten-Eigenschaften, Daten Tabelle für Diagramme, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Schriftarten-Eigenschaften für die Datenbank Tabelle von Diagrammen in PowerPoint-Präsentationen in Python festlegen"
---

## **Schriftarten-Eigenschaften für Daten Tabelle von Diagrammen festlegen**
Aspose.Slides für Python über .NET unterstützt das Ändern der Farben von Kategorien in der Farbserie.

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klassenobjekt.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Legen Sie die Diagrammtabelle fest.
1. Legen Sie die Schriftgröße fest.
1. Speichern Sie die modifizierte Präsentation.

Unten ist ein Beispiel angegeben.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```