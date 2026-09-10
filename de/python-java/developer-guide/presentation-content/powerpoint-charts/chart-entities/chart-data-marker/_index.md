---
title: Chart-Datenmarker in Präsentationen mit Python verwalten
linktitle: Datenmarker
type: docs
url: /de/python-java/chart-data-marker/
keywords:
- Diagramm
- Datenpunkt
- Marker
- Markeroptionen
- Markergröße
- Fülltyp
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Chart-Datenmarker in Aspose.Slides für Python über Java anpassen und die Wirkung von Präsentationen in PPT- und PPTX-Formaten mit klaren Python-Codebeispielen steigern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Datenmarkern von Diagrammen in Aspose.Slides arbeitet. Er zeigt, wie man ein Diagramm erstellt, eine Serie und ihre Datenpunkte zugreift, Bildfüllungen auf Marker auf Datenpunktebene anwendet, die Markergröße anpasst und die aktualisierte Präsentation speichert. Außerdem wird darauf hingewiesen, dass Standard‑Marker‑Formen über die Aufzählung [MarkerStyleType](https://reference.aspose.com/slides/de/python-java/aspose.slides/markerstyletype/) verfügbar sind und dass das Erscheinungsbild der Marker beim Exportieren von Diagrammen in Rasterformate oder SVG beibehalten wird.

## **Diagramm‑Marker‑Optionen festlegen**

Marker können auf Diagrammdatenpunkten innerhalb einer bestimmten Serie gesetzt werden. Um Diagramm‑Marker‑Optionen festzulegen, führen Sie die folgenden Schritte aus:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
- Erstellen Sie das Standarddiagramm.
- Legen Sie die Bilder fest.
- Greifen Sie auf die erste Diagrammserie zu.
- Fügen Sie neue Datenpunkte hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Das folgende Beispiel setzt Diagramm‑Marker‑Optionen auf Datenpunktebene.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Leere Präsentation erstellen.
presentation = Presentation()
try:
    # Zugriff auf die erste Folie
    slide = presentation.getSlides().get_Item(0)

    # Standarddiagramm erstellen
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Standard-Worksheet-Index für Diagrammdaten abrufen.
    default_worksheet_index = 0

    # Diagrammdaten-Arbeitsbuch abrufen.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Demo‑Serie löschen
    chart.getChartData().getSeries().clear()

    # Neue Serie hinzufügen
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Erstes Bild laden.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Zweites Bild laden.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Zugriff auf die erste Diagrammserie.
    series = chart.getChartData().getSeries().get_Item(0)

    # Datenpunkte hinzufügen.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Größe des Diagrammserien‑Markers ändern.
    series.getMarker().setSize(15)

    # Präsentation mit Diagramm speichern
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welche Marker‑Formen sind standardmäßig verfügbar?**

Standardformen sind verfügbar (Kreis, Quadrat, Raute, Dreieck usw.); die Liste wird durch die Klasse [MarkerStyleType](https://reference.aspose.com/slides/de/python-java/aspose.slides/markerstyletype/) definiert. Wenn Sie eine nicht standardmäßige Form benötigen, verwenden Sie einen Marker mit einer Bildfüllung, um benutzerdefinierte Visualisierungen zu emulieren.

**Werden Marker beim Export eines Diagramms in ein Bild oder SVG beibehalten?**

Ja. Beim Rendern von Diagrammen in [Rasterformate](/slides/de/python-java/convert-powerpoint-to-png/) oder beim Speichern von [Formen als SVG](/slides/de/python-java/render-a-slide-as-an-svg-image/) behalten Marker ihr Aussehen und ihre Einstellungen bei, einschließlich Größe, Füllung und Kontur.