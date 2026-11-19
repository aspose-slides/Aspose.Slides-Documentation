---
title: 3D-Diagramme in Präsentationen mit Python anpassen
linktitle: 3D-Diagramm
type: docs
url: /de/python-net/3d-chart/
keywords:
- 3D-Diagramm
- Drehung
- Tiefe
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für Python via .NET. Passen Sie Drehung, Höhenverhältnisse, Diagrammtiefe und den Abstand zwischen Serien mit Python-Beispielen an."
---
## **Übersicht**

Aspose.Slides für Python via .NET ermöglicht es Ihnen, die Ansicht eines 3D‑Diagramms über die Eigenschaft [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) anzupassen. Dieser Artikel demonstriert, wie man Drehung, Höhenverhältnisse, Tiefe, rechtwinklige Achsen und den Abstand zwischen Serien einstellt und die Präsentation im PPTX‑Format speichert.

## **Drehung und Tiefe eines 3D‑Diagramms festlegen**

Das folgende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und verwendet [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/), um ein gestapeltes 3D‑Säulendiagramm auf seiner ersten Folie hinzuzufügen. Es ersetzt die Standardserien und -kategorien durch zwei Serien mit jeweils drei Werten. Der Arbeitsblattindex `0` identifiziert das erste Datenarbeitsblatt des Diagramms; Zeile `0` enthält die Seriennamen und Spalte `0` die Kategorienamen.

Die Eigenschaften [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) und [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) setzen die Drehung des Diagramms auf 40 bzw. 270 Grad. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) legt die Tiefe auf 150% seiner Breite fest, während [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) rechtwinklige Achsen anstelle einer Perspektive aktiviert. Die resultierende Präsentation enthält das befüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

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

## **Höhenverhältnisse eines 3D‑Diagramms anpassen**

Verwenden Sie [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/), um die Höhe eines 3D‑Diagramms als Prozentsatz seiner Breite festzulegen. Dadurch werden die Proportionen der 3D‑Szene geändert, ohne das Diagrammobjekt auf der Folie zu skalieren.

Das folgende Beispiel erstellt ein [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Diagramm mit Standarddaten: drei Serien und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50%, 100% und 200%. Position, Breite und Höhe des Diagramms bleiben unverändert. Daten, Drehung, Tiefe, Serienabstand und Formatierung sind in allen drei Dateien identisch; nur der Höhen‑Prozentsatz ändert sich.

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

Die folgenden Bilder wurden aus den erzeugten Präsentationen mit Microsoft PowerPoint exportiert. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, während ein höherer Prozentsatz eine höhere Szene innerhalb desselben Diagrammobjekts erzeugt. PowerPoint kann auch Achsen‑Tick‑Intervalle und Beschriftungspositionen anpassen, um die Szene zu passen.

| Höhe: 50% | Höhe: 100% | Höhe: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

Diese Eigenschaften steuern unterschiedliche Aspekte des Diagramms:

| Eigenschaft | Auswirkung |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Höhe des Diagrammobjekts auf der Folie in Punkten. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Abstand zwischen Serien entlang der Tiefenachse als Prozentsatz der Markierungsbreite. |

Die Höhen‑Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich Zylinder-, Kegel- und Pyramiden‑Varianten, sowie auf 3D‑Linien-, Flächen-, Kuchen- und Oberflächendiagramme. Der obige Vergleich verwendet den verifizierten `COLUMN_3D`‑Typ. Die Einstellung ändert das Aussehen eines 2D‑`CLUSTERED_COLUMN`‑Diagramms oder eines `BUBBLE_WITH_3D`‑Diagramms nicht; diese Namen sind Mitglieder der Aufzählung [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Für weitere Diagramm‑Anzeigeeinstellungen siehe [Diagrammformatierung](/slides/de/python-net/chart-formatting/).

## **Abstand zwischen Serien anpassen**

Verwenden Sie [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/), um den Abstand zwischen Datenserien entlang der Tiefenachse eines 3D‑Diagramms zu steuern, angegeben als Prozentsatz der Markierungsbreite. Verwenden Sie Werte von **0 bis 500**, inklusive: `0` entfernt den Abstand, während höhere Werte den Abstand vergrößern. Bei fester Diagrammtiefe führt ein größerer Abstand dazu, dass die Markierungen entlang der Tiefenachse dünner werden.

Greifen Sie über [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) auf die Gruppe zu. Die Einstellung gilt für jede Serie in dieser Gruppe, nicht nur für die Serie, über die sie abgerufen wurde. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) ist schreibgeschützt und spiegelt die Einstellung der übergeordneten Gruppe wider.

Diese Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich ihrer Zylinder-, Kegel- und Pyramiden‑Varianten sowie 3D‑Linien‑ und Flächendiagramme. Das Aussehen hängt davon ab, ob die Serien in der Tiefe, gruppiert oder gestapelt angeordnet sind. Für einen klaren Vergleich der Abstände zwischen einzelnen Serien verwenden Sie `ChartType.COLUMN_3D` aus der Aufzählung [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Diese Eigenschaften steuern unterschiedliche Aspekte des Diagramms:

| Eigenschaft | Auswirkung |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Abstand zwischen Serien entlang der Tiefenachse als Prozentsatz der Markierungsbreite. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern als Prozentsatz der Balken‑ oder Säulenbreite. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Gesamttiefe des Diagramms als Prozentsatz der Diagrammbreite. |

Das folgende eigenständige Beispiel verwendet die Standarddiagrammdaten, die drei Serien und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Drehung, Lückenbreite und Diagrammtiefe; nur die Lückentiefe ändert sich.

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

| Lückentiefe: 0% | Lückentiefe: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **3D‑Serientyp und Balkenform ändern**

In einem gruppierten Zylinderdiagramm beginnt die erste Serie mit zylindrischen Balken. Das Beispiel liest [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) und [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) vor und nach jeder Änderung.

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

| Änderung der ersten Serie | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Diagramm erstellen | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Setze `type` auf `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Setze `bar_3d_shape` auf `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Das Setzen der Form auf `BOX` ändert auch den Serientyp zu `CLUSTERED_COLUMN_3D`. Wenn Ihr Code abhängig vom Serientyp verzweigt, lesen Sie `series.type` nach dem Ändern der Form. Ein vor der Zuweisung zwischengespeicherter Wert würde weiterhin den `CLUSTERED_CONE`‑Zweig auswählen.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Aufzählung [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) bereitgestellt werden. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm mit [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) in ein Bild exportieren oder [die gesamte Folie rendern](/slides/de/python-net/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG. Das ist nützlich, wenn Sie eine Rastervorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für beste Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden Sie schwere Texturen an Wänden und Plot‑Bereichen, begrenzen Sie nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in eine angemessen dimensionierte Ausgabe (Auflösung und Abmessungen), die den Zielanzeige‑ oder Druckanforderungen entspricht.