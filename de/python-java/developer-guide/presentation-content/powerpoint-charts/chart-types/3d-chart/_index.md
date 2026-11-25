---
title: 3D-Diagramme in Präsentationen mit Python anpassen
linktitle: 3D-Diagramm
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
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für Python via Java. Passen Sie Rotation, Höhenverhältnisse, Diagrammtiefe und den Abstand zwischen Reihen mit Python-Beispielen an."
---
## **Übersicht**

Aspose.Slides für Python via Java ermöglicht es Ihnen, die Ansicht eines 3D‑Diagramms über die Methode [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) anzupassen. Dieser Artikel zeigt, wie Sie Rotation, Höhenverhältnisse, Tiefe, rechtwinklige Achsen und den Abstand zwischen Reihen anpassen und die Präsentation dann im PPTX‑Format speichern.

## **Drehung und Tiefe eines 3D‑Diagramms festlegen**

Das nachstehende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) und verwendet [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart), um ein gestapeltes 3D‑Säulendiagramm auf die erste Folie hinzuzufügen. Es ersetzt die Standard‑Reihen und -Kategorien durch zwei Reihen mit jeweils drei Werten. Der Arbeitsblatt‑Index `0` bezeichnet das erste Daten‑Arbeitsblatt des Diagramms; Zeile `0` enthält die Reihen‑Namen und Spalte `0` die Kategorien‑Bezeichnungen.

Die Methoden [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) und [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) setzen die Rotation des Diagramms auf 40 bzw. 270 Grad. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) legt die Tiefe auf 150 % seiner Breite fest, während [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) rechtwinklige Achsen anstelle von Perspektive aktiviert. Die resultierende Präsentation enthält das mit Daten gefüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

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

## **Bildfüllung auf einer 3D‑Diagrammoberfläche anwenden**

Ein 3D‑Diagramm besitzt drei Oberflächen, die Sie unabhängig füllen können: die [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), die [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) und den [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). Setzen Sie den [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) der Oberfläche auf `Picture` und weisen Sie ein Bild zu. Setzen Sie sowohl den [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) als auch den [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) der Oberfläche auf `Stretch`, um ein Exemplar des Bildes über die gesamte Oberfläche zu strecken.

Speichern Sie [arrow.png](arrow.png) im Arbeitsverzeichnis. Das Beispiel dreht das Diagramm und erhöht den Maximalwert der vertikalen Achse, sodass der Boden zwischen den Säulen sichtbar ist. Anschließend klont es die Folie zweimal und wendet den Pfeil jeweils auf eine andere Oberfläche an. Alle drei Diagramme behalten dieselben Daten, den Betrachtungswinkel und den Hintergrund bei.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint zeigt die drei Folien wie folgt.

| Seitenwand | Rückwand | Boden |
| --- | --- | --- |
| ![Pfeil, der in das Diagramm entlang der Seitenwand zeigt](side-wall.png) | ![Pfeil, der nach rechts über die Rückwand zeigt](back-wall.png) | ![Pfeil, der nach rechts über den Boden zwischen den Säulen zeigt](floor.png) |

## **Höhenverhältnisse eines 3D‑Diagramms anpassen**

Verwenden Sie [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents), um die Höhe eines 3D‑Diagramms als Prozentsatz seiner Breite festzulegen. Dadurch werden die Proportionen der 3D‑Szene geändert, ohne das Diagrammobjekt auf der Folie zu skalieren.

Das folgende Beispiel erstellt ein [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)‑Diagramm mit den Standarddaten: drei Reihen und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50 %, 100 % und 200 %. Position, Breite und Höhe des Diagramms bleiben unverändert. Daten, Rotation, Tiefe, Reihenabstand und Formatierung sind in allen drei Dateien identisch; nur das Höhen‑Prozent wird geändert.

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

Die folgenden Abbildungen zeigen dieselben Höheneinstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, ein größerer Prozentsatz eine höhere Szene innerhalb desselben Diagrammobjekts. PowerPoint kann zudem die Achsen‑Tick‑Intervalle und die Beschriftungsplatzierung an die Szene anpassen.

| Höhe: 50 % | Höhe: 100 % | Höhe: 200 % |
| --- | --- | --- |
| ![3D‑Säulendiagramm mit einer Höhe von 50 % seiner Breite](height_percent_50.png) | ![3D‑Säulendiagramm mit einer Höhe von 100 % seiner Breite](height_percent_100.png) | ![3D‑Säulendiagramm mit einer Höhe von 200 % seiner Breite](height_percent_200.png) |

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Auswirkung |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Höhe des Diagrammobjekts auf der Folie in Punkten. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Abstand zwischen Reihen entlang der Tiefenachse als Prozentsatz der Marker‑Breite. |

Die Höheneinstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich Zylinder-, Kegel- und Pyramiden‑Varianten, sowie auf 3D‑Linien-, Flächen-, Kreis‑ und Oberflächendiagramme. Der obige Vergleich verwendet den geprüften Typ `Column3D`. Die Einstellung ändert das Erscheinungsbild eines 2D‑Diagramms `ClusteredColumn` oder eines `BubbleWith3D`‑Diagramms nicht; diese Namen sind Mitglieder der Klasse [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Weitere Diagramm‑Formatierungseinstellungen finden Sie unter [Chart Formatting](/slides/de/python-java/chart-formatting/).

## **Abstand zwischen Reihen anpassen**

Verwenden Sie [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth), um den Abstand zwischen Datenreihen entlang der Tiefenachse eines 3D‑Diagramms zu steuern, ausgedrückt als Prozentsatz der Marker‑Breite. Verwenden Sie Werte von **0 bis 500**, inklusive: `0` entfernt den Abstand, während größere Werte den Abstand vergrößern. Bei fester Diagrammtiefe führt ein größerer Abstand zu dünneren Markern entlang der Tiefenachse.

Greifen Sie über [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) auf die Gruppe zu. Die Einstellung gilt für jede Reihe in dieser Gruppe, nicht nur für die Reihe, über die zugegriffen wurde. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) gibt den Tiefenabstand zurück und spiegelt die Einstellung der übergeordneten Gruppe wider.

Diese Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich ihrer Zylinder‑, Kegel- und Pyramiden‑Varianten, sowie auf 3D‑Linien‑ und Flächendiagramme. Das Erscheinungsbild hängt davon ab, ob die Reihen in der Tiefe, gruppiert oder gestapelt angeordnet sind. Für einen klaren Vergleich der Abstände zwischen einzelnen Reihen verwenden Sie `ChartType.Column3D` aus der Klasse [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Auswirkung |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Abstand zwischen Reihen entlang der Tiefenachse als Prozentsatz der Marker‑Breite. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern als Prozentsatz der Balken‑ bzw. Säulenbreite. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Gesamttiefe des Diagramms als Prozentsatz der Diagrammbreite. |

Das folgende eigenständige Beispiel verwendet die Standard‑Diagrammdaten, die drei Reihen und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Rotation, Lückenbreite und Diagrammtiefe; nur die Lücken‑Tiefe ändert sich.

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

Die folgenden Abbildungen zeigen dieselben Lücken‑Tiefe‑Einstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert.

| Lücken‑Tiefe: 0 % | Lücken‑Tiefe: 500 % |
| --- | --- |
| ![3D‑Säulendiagramm ohne Abstand zwischen Reihen entlang der Tiefenachse](gap_depth_0.png) | ![3D‑Säulendiagramm mit einem Abstand von 500 % zwischen Reihen entlang der Tiefenachse](gap_depth_500.png) |

## **3D‑Reihentyp und Balkenform ändern**

In einem gruppierten Zylinder‑Diagramm beginnt die erste Reihe mit einer zylindrischen Balkenform. Das Beispiel gibt die ganzzahligen Werte aus, die von [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) und [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) vor und nach jeder Änderung zurückgegeben werden. Die Tabelle enthält die entsprechenden Konstantennamen.

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

| Änderung der ersten Reihe | Reihentyp | Balkenform |
| --- | --- | --- |
| Diagramm erstellen | `ClusteredCylinder` | `Cylinder` |
| Reihentyp auf `ClusteredCone` setzen | `ClusteredCone` | `Cone` |
| Balkenform auf `Box` setzen | `ClusteredColumn3D` | `Box` |

Das Setzen der Form auf `Box` ändert auch den Reihentyp zu `ClusteredColumn3D`. Wenn Ihr Code abhängig vom Reihentyp verzweigt, rufen Sie nach dem Ändern der Form `series.getType()` auf. Ein vor der Zuweisung zwischengespeicherter Wert würde weiterhin den `ClusteredCone`‑Zweig auswählen.

![PowerPoint‑Vergleich, der die erste Reihe von links nach rechts als Zylinder, Kegel und rechteckige Säulen zeigt](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Klasse [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) bereitgestellt werden. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm mit [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) oder die gesamte Folie mit [die gesamte Folie rendern](/slides/de/python-java/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG exportieren. Das ist nützlich, wenn Sie eine Raster‑Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbinden möchten, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen an Wänden und Plot‑Bereichen, begrenzen nach Möglichkeit die Anzahl der Datenpunkte pro Reihe und rendern Sie in eine angemessen dimensionierte Ausgabe (Auflösung und Abmessungen), die den Ziel‑Anzeige‑ oder Druckanforderungen entspricht.