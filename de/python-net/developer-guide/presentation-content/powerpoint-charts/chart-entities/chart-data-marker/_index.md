---
title: Diagrammdatenmarker in Präsentationen mit Python verwalten
linktitle: Datenmarker
type: docs
url: /de/python-net/chart-data-marker/
keywords:
- Diagramm
- Datenpunkt
- Marker
- Markeroptionen
- Markergröße
- Fülltyp
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenmarker in Aspose.Slides anpassen und die Wirkung von Präsentationen in den Formaten PPT, PPTX und ODP mit anschaulichen Codebeispielen steigern."
---

## **Diagramm‑Markeroptionen festlegen**
Die Marker können für Diagrammdatenpunkte innerhalb bestimmter Reihen festgelegt werden. Um Diagramm‑Markeroptionen zu setzen, folgen Sie bitte den untenstehenden Schritten:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- Erstellen des Standarddiagramms.
- Bild festlegen.
- Erste Diagrammreihe übernehmen.
- Neuen Datenpunkt hinzufügen.
- Präsentation auf dem Datenträger speichern.

Im nachfolgenden Beispiel haben wir die Diagramm‑Markeroptionen auf Ebene der Datenpunkte festgelegt.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstelle eine Instanz der Klasse Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Erstelle das Standarddiagramm
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Abrufen des Indexes des Standarddatenarbeitsblatts des Diagramms
    defaultWorksheetIndex = 0

    # Abrufen des Diagrammdaten-Arbeitsblatts
    fact = chart.chart_data.chart_data_workbook

    # Demo‑Reihen löschen
    chart.chart_data.series.clear()

    # Neue Reihe hinzufügen
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Bild festlegen
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Bild festlegen
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Erste Diagrammreihe übernehmen
    series = chart.chart_data.series[0]

    # Neuen Punkt (1:3) dort hinzufügen.
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

    # Diagrammreihen‑Marker ändern
    series.marker.size = 15

    # Präsentation auf dem Datenträger speichern
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Welche Markerformen sind standardmäßig verfügbar?**

Standardformen sind verfügbar (Kreis, Quadrat, Raute, Dreieck usw.); die Liste wird durch die Aufzählung [MarkerStyleType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/markerstyletype/) definiert. Wenn Sie eine nicht standardmäßige Form benötigen, verwenden Sie einen Marker mit Bildfüllung, um benutzerdefinierte Visualisierungen zu emulieren.

**Werden Marker beim Exportieren eines Diagramms in ein Bild oder SVG beibehalten?**

Ja. Beim Rendern von Diagrammen zu [Rasterformaten](/slides/de/python-net/convert-powerpoint-to-png/) oder beim Speichern von [Formen als SVG](/slides/de/python-net/render-a-slide-as-an-svg-image/) behalten Marker ihr Aussehen und ihre Einstellungen bei, einschließlich Größe, Füllung und Kontur.