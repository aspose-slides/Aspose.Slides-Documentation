---
title: Anpassen von 3D-Diagrammen in Präsentationen mit Python
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
description: "Erfahren Sie, wie Sie 3-D-Diagramme in Aspose.Slides für Python via .NET erstellen und anpassen, mit Unterstützung für PPT-, PPTX- und ODP-Dateien - verbessern Sie noch heute Ihre Präsentationen."
---

## **Festlegen der Eigenschaften RotationX, RotationY und DepthPercents eines 3D-Diagramms**
Aspose.Slides für Python via .NET bietet eine einfache API zum Festlegen dieser Eigenschaften. Der folgende Artikel hilft Ihnen, verschiedene Eigenschaften wie X-Y-Rotation, **DepthPercents** usw. zu setzen. Der Beispielcode wendet das Festlegen der oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Eigenschaften von Rotation3D.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstelle eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
            
    # Greife auf die erste Folie zu
    slide = presentation.slides[0]

    # Füge ein Diagramm mit Standarddaten hinzu
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Setze den Index des Diagrammdatenblatts
    defaultWorksheetIndex = 0

    # Hole das Diagrammdaten-Arbeitsblatt
    fact = chart.chart_data.chart_data_workbook

    # Füge Serien hinzu
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Füge Kategorien hinzu
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Setze Rotation3D-Eigenschaften
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Nimm die zweite Diagrammserie
    series = chart.chart_data.series[1]

    # Nun die Seriendaten befüllen
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Setze OverLap-Wert
    series.parent_series_group.overlap = 100         

    # Schreibe die Präsentation auf die Festplatte
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Welche Diagrammtypen unterstützen den 3D-Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D-Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D-Typen, die über die Aufzählung [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) verfügbar sind. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) in der API-Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D-Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über die [chart API](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) oder die gesamte Folie [rendern](/slides/de/python-net/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG exportieren. Dies ist nützlich, wenn Sie eine pixelgenaue Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie leistungsfähig ist das Erstellen und Rendern großer 3D-Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D-Effekte minimal, vermeiden schwere Texturen auf Wänden und Plot-Bereichen, begrenzen Sie nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in einer angemessen großen Ausgabe (Auflösung und Abmessungen), die den Zielanzeige- oder Druckanforderungen entspricht.