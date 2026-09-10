---
title: Anpassen von 3D-Diagrammen in Präsentationen mit Python
linktitle: 3D Diagramm
type: docs
url: /de/python-java/3d-chart/
keywords:
- 3D-Diagramm
- Rotation
- Tiefe
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie 3-D-Diagramme in Aspose.Slides für Python via Java erstellen und anpassen, mit Unterstützung für PPT- und PPTX-Dateien - verbessern Sie noch heute Ihre Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man ein 3D‑Diagramm in Aspose.Slides anpasst, indem man die Einstellungen von [Rotation3D](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotation3d/) wie [setRotationX](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotation3d/#setDepthPercents) und [setRightAngleAxes](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotation3d/#setRightAngleAxes) konfiguriert. Er führt durch das Erstellen einer Präsentation, das Hinzufügen eines 3D‑Diagramms mit Standarddaten, das Anwenden der erforderlichen 3D‑Ansichtseinstellungen und das Speichern der modifizierten Präsentation als PPTX‑Datei.

## **X‑Rotation, Y‑Rotation und Tiefe eines 3D‑Diagramms festlegen**
Aspose.Slides für Python über Java bietet eine einfache API zum Festlegen dieser Eigenschaften. Das folgende Beispiel zeigt, wie man die X‑Rotation, Y‑Rotation und die Tiefe eines 3D‑Diagramms festlegt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Setzen Sie die 3D‑Rotations‑Eigenschaften.
5. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Zugriff auf die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Ein Diagramm mit Standarddaten hinzufügen.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Den Arbeitsblatt-Index für Diagrammdaten festlegen.
    default_worksheet_index = 0

    # Das Diagrammdaten-Workbook abrufen.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Serien hinzufügen.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Kategorien hinzufügen.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # 3D‑Rotations‑Eigenschaften festlegen.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Auf die zweite Diagrammserie zugreifen.
    series = chart.getChartData().getSeries().get_Item(1)

    # Seriendaten befüllen.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Die Präsentation speichern.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Klasse [ChartType](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/) verfügbar sind. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über die [chart API](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) in ein Bild exportieren oder [render the entire slide](/slides/de/python-java/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Dies ist nützlich, wenn Sie eine pixelgenaue Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne dass PowerPoint erforderlich ist.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden Sie schwere Texturen auf Wänden und Diagrammbereichen, reduzieren Sie nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in eine passend dimensionierte Ausgabe (Auflösung und Abmessungen), die den Zielanzeige‑ oder Druckanforderungen entspricht.