---
title: Diagrammdatenmarkierung
type: docs
url: /python-net/chart-data-marker/
keywords: "Diagramm-Markierungsoptionen, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Diagramm-Markierungsoptionen in PowerPoint-Präsentationen in Python festlegen"
---

## **Diagramm-Markierungsoptionen festlegen**
Die Marker können an Diagrammdatenpunkten innerhalb bestimmter Serien festgelegt werden. Um die Diagramm-Markierungsoptionen festzulegen, folgen Sie bitte den folgenden Schritten:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Erstellen Sie das Standarddiagramm.
- Setzen Sie das Bild.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir die Diagramm-Markierungsoptionen auf Datenpunktebene festgelegt.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Erstellen des Standarddiagramms
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Abrufen des Standarddiagramm-Datenarbeitsblattindex
    defaultWorksheetIndex = 0

    # Abrufen des Diagramm-Datenarbeitsblatts
    fact = chart.chart_data.chart_data_workbook

    # Demo-Serie löschen
    chart.chart_data.series.clear()

    # Neue Serie hinzufügen
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.type)
            
    # Setzen Sie das Bild
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Setzen Sie das Bild
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Nehmen Sie die erste Diagrammserie
    series = chart.chart_data.series[0]

    # Fügen Sie dort einen neuen Punkt (1:3) hinzu.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Ändern des Markers der Diagrammserie
    series.marker.size = 15

    # Schreiben Sie die Präsentation auf die Festplatte
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```