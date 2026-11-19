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
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für Python via Java. Passen Sie Rotation, Höhenverhältnisse, Diagrammtiefe und den Abstand zwischen Serien mit Python-Beispielen an."
---
## **Übersicht**

Aspose.Slides für Python via Java ermöglicht es Ihnen, die Ansicht eines 3D‑Diagramms über die [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D)‑Methode anzupassen. Dieser Artikel zeigt, wie man Rotation, Höhenverhältnisse, Tiefe, rechtwinklige Achsen und Abstände zwischen Reihen anpasst und die Präsentation dann im PPTX‑Format speichert.

## **Drehung und Tiefe eines 3D‑Diagramms festlegen**

Das untenstehende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) und verwendet [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart), um ein gestapeltes 3D‑Säulendiagramm auf seiner ersten Folie hinzuzufügen. Es ersetzt die Standard‑Reihen und -Kategorien durch zwei Reihen, die jeweils drei Werte enthalten. Der Arbeitsblatt‑Index `0` identifiziert das erste Daten‑Arbeitsblatt des Diagramms; Zeile `0` enthält die Reihen‑Namen und Spalte `0` die Kategorien‑Bezeichnungen.

Die Methoden [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) und [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) stellen die Drehung des Diagramms auf 40 bzw. 270 Grad ein. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) legt die Tiefe auf 150% seiner Breite fest, während [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) rechtwinklige Achsen anstelle von Perspektive aktiviert. Die resultierende Präsentation enthält das gefüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Höhenverhältnisse eines 3D‑Diagramms anpassen**

Verwenden Sie [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents), um die Höhe eines 3D‑Diagramms als Prozentsatz seiner Breite festzulegen. Dadurch ändern sich die Proportionen der 3D‑Szene, ohne das Diagramm‑Objekt auf der Folie zu skalieren.

Das folgende Beispiel erstellt ein [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)‑Diagramm mit den Standarddaten: drei Reihen und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50%, 100% und 200%. Position, Breite und Höhe des Diagramms bleiben unverändert. Daten, Drehung, Tiefe, Reihenabstand und Formatierung sind in allen drei Dateien identisch; nur der Höhen‑Prozentsatz ändert sich.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die folgenden Bilder veranschaulichen dieselben Höheneinstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, ein größerer Prozentsatz eine höhere Szene innerhalb desselben Diagramm‑Objekts. PowerPoint kann zudem die Achsen‑Tick‑Intervalle und Beschriftungspositionen an die Szene anpassen.

| Höhe: 50% | Höhe: 100% | Höhe: 200% |
| --- | --- | --- |
| ![3D‑Säulendiagramm mit einer Höhe von 50% seiner Breite](height_percent_50.png) | ![3D‑Säulendiagramm mit einer Höhe von 100% seiner Breite](height_percent_100.png) | ![3D‑Säulendiagramm mit einer Höhe von 200% seiner Breite](height_percent_200.png) |

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Auswirkung |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Höhe des Diagramm‑Objekts auf der Folie in Punkten. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Abstand zwischen Reihen entlang der Tiefen‑Achse als Prozentsatz der Markierungsbreite. |

Die Höheneinstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑, Flächen‑, Kreis‑ und Oberflächendiagramme. Der obige Vergleich verwendet den verifizierten `Column3D`‑Typ. Die Einstellung ändert das Aussehen eines 2D‑`ClusteredColumn`‑Diagramms oder eines `BubbleWith3D`‑Diagramms nicht; diese Namen sind Mitglieder der Klasse [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Weitere Diagramm‑Design‑Einstellungen finden Sie unter [Diagrammformatierung](/slides/de/python-java/chart-formatting/).

## **Abstand zwischen Reihen anpassen**

Verwenden Sie [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth), um den Abstand zwischen Datenreihen entlang der Tiefen‑Achse eines 3D‑Diagramms zu steuern, angegeben als Prozentsatz der Markierungsbreite. Verwenden Sie Werte von **0 bis 500**, inklusiv: `0` entfernt den Abstand, während höhere Werte den Abstand vergrößern. Bei fester Diagrammtiefe führt ein größerer Abstand zu dünneren Markierungen entlang der Tiefen‑Achse.

Greifen Sie über [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) auf die Gruppe zu. Die Einstellung gilt für jede Reihe in dieser Gruppe, nicht nur für die Reihe, über die zugegriffen wird. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) gibt den Tiefen‑Abstand zurück und spiegelt die Einstellung der übergeordneten Gruppe wider.

Diese Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich ihrer Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑ und Flächendiagramme. Das Erscheinungsbild hängt davon ab, ob die Reihen in der Tiefe, gruppiert oder gestapelt angeordnet sind. Für einen klaren Vergleich von Abständen zwischen einzelnen Reihen verwenden Sie `ChartType.Column3D` aus der Klasse [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Auswirkung |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Abstand zwischen Reihen entlang der Tiefen‑Achse als Prozentsatz der Markierungsbreite. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern als Prozentsatz der Balken‑ bzw. Säulenbreite. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Gesamttiefe des Diagramms als Prozentsatz der Diagrammbreite. |

Das folgende eigenständige Beispiel verwendet die Standard‑Diagrammdaten, die drei Reihen und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Drehung, Abstand‑Breite und Diagrammtiefe; nur der Abstand‑Tiefe ändert sich.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die folgenden Bilder veranschaulichen dieselben Einstellungen für den Abstand in der Tiefe im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert.

| Abstand Tiefe: 0% | Abstand Tiefe: 500% |
| --- | --- |
| ![3D‑Säulendiagramm ohne Abstand zwischen Reihen entlang der Tiefen‑Achse](gap_depth_0.png) | ![3D‑Säulendiagramm mit einem 500%igen Abstand zwischen Reihen entlang der Tiefen‑Achse](gap_depth_500.png) |

## **3D‑Serientyp und Balkenform ändern**

In einem gruppierten Zylinder‑Diagramm beginnt die erste Reihe mit einer zylindrischen Balkenform. Das Beispiel gibt die Ganzzahlwerte aus, die von [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) und [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) vor und nach jeder Änderung zurückgegeben werden. Die Tabelle liefert die entsprechenden Konstantennamen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Änderung der ersten Reihe | Serientyp | Balkenform |
| --- | --- | --- |
| Diagramm erstellen | `ClusteredCylinder` | `Cylinder` |
| Serientyp auf `ClusteredCone` setzen | `ClusteredCone` | `Cone` |
| Balkenform auf `Box` setzen | `ClusteredColumn3D` | `Box` |

Das Setzen der Form auf `Box` ändert zudem den Serientyp zu `ClusteredColumn3D`. Wenn Ihr Code abhängig vom Serientyp verzweigt, rufen Sie `series.getType()` nach dem Ändern der Form auf. Ein vor der Zuweisung zwischengespeicherter Wert würde weiterhin den `ClusteredCone`‑Zweig auswählen.

![PowerPoint‑Vergleich, der die erste Reihe von links nach rechts als Zylinder, Kegel und rechteckige Säulen zeigt](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100% Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Klasse [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) bereitgestellt werden. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm mit [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) in ein Bild exportieren oder [die gesamte Folie rendern](/slides/de/python-java/convert-powerpoint-to-png/), um Formate wie PNG oder JPEG zu erhalten. Dies ist nützlich, wenn Sie eine Raster‑Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten wollen, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden Sie schwere Texturen an Wänden und Plot‑Bereichen, begrenzen Sie nach Möglichkeit die Anzahl der Datenpunkte pro Reihe und rendern Sie in einer angemessenen Ausgabegröße (Auflösung und Abmessungen), die zur Zielanzeige oder zum Druck passt.