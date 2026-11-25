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
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für Python via .NET. Passen Sie Rotation, Höhenverhältnisse, Diagrammtiefe und Abstand zwischen Serien mit Python-Beispielen an."
---
## **Übersicht**

Aspose.Slides for Python via .NET ermöglicht es Ihnen, die Ansicht eines 3D‑Diagramms über die [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/)‑Eigenschaft anzupassen. Dieser Artikel zeigt, wie man Rotation, Höhenverhältnisse, Tiefe, rechtwinklige Achsen und den Abstand zwischen Serien anpasst und dann die Präsentation im PPTX‑Format speichert.

## **Rotation und Tiefe eines 3D‑Diagramms festlegen**

Das nachfolgende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und verwendet [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/), um ein gestapeltes 3D‑Säulendiagramm auf seiner ersten Folie hinzuzufügen. Es ersetzt die Standardserien und -kategorien durch zwei Serien mit jeweils drei Werten. Der Arbeitsblatt‑Index `0` bezeichnet das erste Daten‑Arbeitsblatt des Diagramms; Zeile `0` enthält die Seriennamen und Spalte `0` die Kategorienamen.

Die Eigenschaften [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) und [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) legen die Rotation des Diagramms auf 40 bzw. 270 Grad fest. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) setzt die Tiefe auf 150 % der Breite, während [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) rechte Winkel‑Achsen anstelle von Perspektive aktiviert. Die resultierende Präsentation enthält das gefüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bildfüllung auf einer 3D‑Diagrammoberfläche anwenden**

Sie können die [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) und [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) eines 3D‑Diagramms unabhängig voneinander füllen. Setzen Sie den [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) der Oberfläche auf `PICTURE` und weisen Sie ein Bild zu. Um ein Exemplar des Bildes über die gesamte Oberfläche zu strecken, setzen Sie sowohl den [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) als auch den [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) der Oberfläche auf `STRETCH`.

Speichern Sie [arrow.png](arrow.png) im Arbeitsverzeichnis. Das Beispiel dreht das Diagramm und erhöht den Maximalwert der vertikalen Achse, sodass der Boden zwischen den Säulen sichtbar ist. Es dupliziert die Folie zweimal und wendet den Pfeil auf jeder Folie einer anderen Oberfläche an. Alle drei Diagramme verwenden dieselben Daten, denselben Betrachtungswinkel und denselben Hintergrund.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint zeigt die drei Folien wie folgt an.

| Seitenwand | Rückwand | Boden |
| --- | --- | --- |
| ![Pfeil, der in das Diagramm entlang der Seitenwand zeigt](side-wall.png) | ![Pfeil, der nach rechts über die Rückwand zeigt](back-wall.png) | ![Pfeil, der nach rechts über den Boden zwischen den Säulen zeigt](floor.png) |

## **Höhenverhältnisse eines 3D‑Diagramms anpassen**

Verwenden Sie [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/), um die Höhe eines 3D‑Diagramms als Prozentsatz seiner Breite festzulegen. Dadurch werden die Proportionen der 3D‑Szene geändert, ohne das Diagrammobjekt auf der Folie zu skalieren.

Das nachfolgende Beispiel erstellt ein [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Diagramm mit den Standarddaten: drei Serien und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50 %, 100 % bzw. 200 %. Position, Breite und Höhe des Diagramms bleiben unverändert. Daten, Rotation, Tiefe, Serienabstand und Formatierung sind in allen drei Dateien identisch; nur das Höhen‑Prozent‑Verhältnis ändert sich.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Die folgenden Bilder wurden aus den erzeugten Präsentationen mit Microsoft PowerPoint exportiert. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, ein größerer Prozentsatz eine höhere Szene innerhalb desselben Diagrammobjekts. PowerPoint kann zudem die Achsentick‑Intervalle und die Beschriftungsposition an die Szene anpassen.

| Höhe: 50 % | Höhe: 100 % | Höhe: 200 % |
| --- | --- | --- |
| ![3D‑Säulendiagramm mit einer Höhe von 50 % seiner Breite](height_percent_50.png) | ![3D‑Säulendiagramm mit einer Höhe von 100 % seiner Breite](height_percent_100.png) | ![3D‑Säulendiagramm mit einer Höhe von 200 % seiner Breite](height_percent_200.png) |

Diese Eigenschaften steuern verschiedene Aspekte des Diagramms:

| Eigenschaft | Wirkung |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Höhe des Diagrammobjekts auf der Folie in Punkten. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Abstand zwischen Serien entlang der Tiefe‑Achse als Prozentsatz der Markenbreite. |

Die Höhen‑Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑, Flächen‑, Kuchen‑ und Oberflächendiagramme. Der obige Vergleich verwendet den geprüften `COLUMN_3D`‑Typ. Die Einstellung ändert das Aussehen eines 2D‑`CLUSTERED_COLUMN`‑Diagramms oder eines `BUBBLE_WITH_3D`‑Diagramms nicht; diese Namen sind Mitglieder der [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Aufzählung. Weitere Diagramm‑Anzeige‑Einstellungen finden Sie unter [Diagrammformatierung](/slides/de/python-net/chart-formatting/).

## **Abstand zwischen Serien anpassen**

Verwenden Sie [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/), um den Abstand zwischen Datenserien entlang der Tiefe‑Achse eines 3D‑Diagramms zu steuern, angegeben als Prozentsatz der Markenbreite. Verwenden Sie Werte von **0 bis 500**, inkl.: `0` entfernt den Abstand, höhere Werte vergrößern ihn. Bei fester Diagrammtiefe führt ein größerer Abstand zu dünneren Markern entlang der Tiefe‑Achse.

Greifen Sie über [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) auf die Gruppe zu. Die Einstellung gilt für jede Serie in dieser Gruppe, nicht nur für die Serie, über die zugegriffen wird. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) ist schreibgeschützt und spiegelt die Einstellung der übergeordneten Gruppe wider.

Diese Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich ihrer Zylinder‑, Kegel‑ und Pyramiden‑Varianten sowie auf 3D‑Linien‑ und Flächendiagramme. Das Erscheinungsbild hängt davon ab, ob die Serien in der Tiefe, gruppiert oder gestapelt angeordnet sind. Für einen klaren Vergleich von Abständen zwischen einzelnen Serien verwenden Sie `ChartType.COLUMN_3D` aus der [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Aufzählung.

Diese Eigenschaften steuern verschiedene Aspekte des Diagramms:

| Eigenschaft | Wirkung |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Abstand zwischen Serien entlang der Tiefe‑Achse als Prozentsatz der Markenbreite. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern als Prozentsatz der Balken‑ bzw. Säulenbreite. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Gesamte Diagrammtiefe als Prozentsatz der Diagrammbreite. |

Das folgende eigenständige Beispiel verwendet die Standarddiagrammdaten, die drei Serien und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Rotation, Abstand‑Breite und Diagrammtiefe; nur die Lückentiefe ändert sich.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Die folgenden Bilder wurden aus den erzeugten Präsentationen mit Microsoft PowerPoint exportiert.

| Lückentiefe: 0 % | Lückentiefe: 500 % |
| --- | --- |
| ![3D‑Säulendiagramm ohne Abstand zwischen Serien entlang der Tiefe‑Achse](gap_depth_0.png) | ![3D‑Säulendiagramm mit einem 500 %igen Abstand zwischen Serien entlang der Tiefe‑Achse](gap_depth_500.png) |

## **3D‑Serientyp und Balkenform ändern**

In einem gruppierten Zylinder‑Diagramm beginnt die erste Serie mit zylindrischen Balken. Das Beispiel liest [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) und [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) vor und nach jeder Änderung aus.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Änderung an der ersten Serie | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Diagramm erstellen | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Setze `type` auf `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Setze `bar_3d_shape` auf `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Das Setzen der Form auf `BOX` ändert außerdem den Serientyp zu `CLUSTERED_COLUMN_3D`. Wenn Ihr Code abhängig vom Serientyp verzweigt, lesen Sie `series.type` nach dem Ändern der Form. Ein vor der Zuweisung zwischengespeicherter Wert würde weiterhin den `CLUSTERED_CONE`‑Zweig auswählen.

![PowerPoint‑Vergleich, der die erste Serie von links nach rechts als Zylinder, Kegel und rechteckige Säulen zeigt](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, zusammen mit verwandten 3D‑Typen, die über die [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Aufzählung verfügbar sind. Für eine exakte, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm mit [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) in ein Bild exportieren oder [die gesamte Folie rendern](/slides/de/python-net/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG. Das ist nützlich, wenn Sie eine Rastervorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten wollen, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen an Wänden und Diagrammbereichen, begrenzen Sie nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in einer angemessenen Ausgabegröße (Auflösung und Abmessungen), die den Ziel­bildschirm‑ oder Druckanforderungen entspricht.