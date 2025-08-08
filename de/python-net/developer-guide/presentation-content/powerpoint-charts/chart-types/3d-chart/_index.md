---
title: 3D-Diagramme in Präsentationen mit Python anpassen
linktitle: 3D-Diagramm
type: docs
url: /de/python-net/3d-chart/
keywords:
- 3D-Diagramm
- Rotation
- Tiefe
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie in Aspose.Slides for Python via .NET 3-D-Diagramme erstellen und anpassen, mit Unterstützung für PPT-, PPTX- und ODP-Dateien—steigern Sie noch heute Ihre Präsentationen."
---

## **RotationX, RotationY und DepthPercents-Eigenschaften des 3D-Diagramms festlegen**
Aspose.Slides für Python über .NET bietet eine einfache API zum Festlegen dieser Eigenschaften. Der folgende Artikel hilft Ihnen, verschiedene Eigenschaften wie X,Y-Rotation, **DepthPercents** usw. festzulegen. Der Beispielcode zeigt die Einstellung der oben genannten Eigenschaften.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Rotation3D-Eigenschaften.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
            
    # Greifen Sie auf die erste Folie zu
    slide = presentation.slides[0]

    # Fügen Sie ein Diagramm mit Standarddaten hinzu
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Festlegen des Index des Diagrammdatenblatts
    defaultWorksheetIndex = 0

    # Abrufen des Diagramm-Datenarbeitsblatts
    fact = chart.chart_data.chart_data_workbook

    # Serien hinzufügen
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.type)

    # Kategorien hinzufügen
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Kategorie 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Kategorie 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Kategorie 3"))

    # Rotation3D-Eigenschaften festlegen
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Zweite Diagrammserie auswählen
    series = chart.chart_data.series[1]

    # Nun die Seriendaten befüllen
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Überlagerungswert festlegen
    series.parent_series_group.overlap = 100         

    # Präsentation auf die Festplatte schreiben
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```