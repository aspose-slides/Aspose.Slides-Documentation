---
title: Anpassen von 3D-Diagrammen in Präsentationen in .NET
linktitle: 3D-Diagramm
type: docs
url: /de/net/3d-chart/
keywords:
- 3D-Diagramm
- Drehung
- Tiefe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für .NET. Passen Sie Drehung, Höhenverhältnisse, Diagrammtiefe und Abstand zwischen Serien mit C#‑Beispielen an."
---
## **Übersicht**

Aspose.Slides for .NET ermöglicht es Ihnen, die Ansicht eines 3D-Diagramms über die [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) Eigenschaft anzupassen. Dieser Artikel zeigt, wie man Rotation, Höhenverhältnisse, Tiefe, rechtwinklige Achsen und den Abstand zwischen Serien einstellt und anschließend die Präsentation im PPTX-Format speichert.

## **Drehung und Tiefe eines 3D-Diagramms festlegen**

Das nachstehende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und verwendet [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/), um ein gruppiertes 3D-Säulendiagramm zur ersten Folie hinzuzufügen. Es ersetzt die Standardserien und -kategorien durch zwei Serien, die jeweils drei Werte enthalten. Der Arbeitsblatt‑Index `0` identifiziert das erste Daten‑Arbeitsblatt des Diagramms; Zeile `0` enthält die Seriennamen und Spalte `0` die Kategorienamen.

Die Eigenschaften [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) und [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) setzen die Diagrammdrehung auf 40 bzw. 270 Grad. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) legt die Tiefe auf 150 % der Breite fest, während [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) rechtwinklige Achsen anstelle von Perspektive aktiviert. Die resultierende Präsentation enthält das gefüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Bildfüllung auf einer 3D-Diagrammfläche anwenden**

Ein 3D-Diagramm hat drei Flächen, die Sie unabhängig voneinander füllen können: die [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) und [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Setzen Sie den [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) der ausgewählten Fläche auf `Picture` und weisen Sie ein Bild zu. Setzen Sie sowohl den [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) als auch den [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) der Fläche auf `Stretch`, um ein Exemplar des Bildes über die gesamte Fläche zu strecken.

Speichern Sie [arrow.png](arrow.png) im Arbeitsverzeichnis. Das Beispiel dreht das Diagramm und erhöht den Maximalwert der vertikalen Achse, sodass der Boden zwischen den Säulen sichtbar ist. Anschließend wird die Folie zweimal dupliziert, bevor der Pfeil auf jeweils einer anderen Fläche jeder Folie angewendet wird. Alle drei Diagramme behalten dieselben Daten, den Betrachtungswinkel und den Hintergrund bei.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint zeigt die drei Folien wie folgt.

| Seitenwand | Rückwand | Boden |
| --- | --- | --- |
| ![Pfeil, der entlang der Seitenwand in das Diagramm zeigt](side-wall.png) | ![Pfeil, der nach rechts über die Rückwand zeigt](back-wall.png) | ![Pfeil, der nach rechts über den Boden zwischen den Säulen zeigt](floor.png) |

## **Höhenverhältnisse eines 3D-Diagramms anpassen**

Verwenden Sie [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/), um die Höhe eines 3D-Diagramms als Prozentsatz seiner Breite festzulegen. Dadurch werden die Proportionen der 3D‑Szene geändert, ohne das Diagrammobjekt auf der Folie zu skalieren.

Das nachstehende Beispiel erstellt ein [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) Diagramm mit den Standarddaten: drei Serien und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50 %, 100 % und 200 %. Position, Breite und Höhe des Diagramms bleiben unverändert. Daten, Drehung, Tiefe, Serienabstand und Formatierung sind in allen drei Dateien identisch; nur das Höhen‑Prozentsatz ändert sich.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

Die folgenden Bilder wurden aus den erzeugten Präsentationen mit Microsoft PowerPoint exportiert. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, während ein größerer Prozentsatz eine höhere Szene innerhalb desselben Diagrammobjekts erzeugt. PowerPoint kann außerdem die Achsen‑Tick‑Intervalle und die Beschriftungsposition anpassen, um die Szene zu passen.

| Höhe: 50% | Höhe: 100% | Höhe: 200% |
| --- | --- | --- |
| ![3D‑Säulendiagramm mit einer Höhe von 50 % seiner Breite](height_percent_50.png) | ![3D‑Säulendiagramm mit einer Höhe von 100 % seiner Breite](height_percent_100.png) | ![3D‑Säulendiagramm mit einer Höhe von 200 % seiner Breite](height_percent_200.png) |

Diese Eigenschaften steuern verschiedene Aspekte des Diagramms:

| Eigenschaft | Auswirkung |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Höhe des Diagrammobjekts auf der Folie, in Punkten. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Markerbreite. |

Die Höhen‑Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑, Flächen‑, Kuchen‑ und Oberflächendiagramme. Der obige Vergleich verwendet den bestätigten Typ `Column3D`. Die Einstellung ändert das Aussehen eines 2D‑`ClusteredColumn`‑Diagramms oder eines `BubbleWith3D`‑Diagramms nicht; diese Namen sind Mitglieder der Aufzählung [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Weitere Diagramm‑Formatierungseinstellungen finden Sie unter [Chart Formatting](/slides/de/net/chart-formatting/).

## **Abstand zwischen Serien anpassen**

Verwenden Sie [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/), um den Abstand zwischen Datenserien entlang der Tiefenachse eines 3D‑Diagramms zu steuern, angegeben als Prozentsatz der Markerbreite. Verwenden Sie Werte von **0 bis 500** inkl.: `0` entfernt den Abstand, während höhere Werte den Abstand vergrößern. Bei fester Diagrammtiefe führt ein größerer Abstand dazu, dass die Marker entlang der Tiefenachse dünner werden.

Greifen Sie über [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) auf die Gruppe zu. Die Einstellung gilt für jede Serie in dieser Gruppe, nicht nur für die Serie, über die zugegriffen wurde. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) ist schreibgeschützt und spiegelt die Einstellung der übergeordneten Gruppe wider.

Diese Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich deren Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑ und Flächendiagramme. Das Aussehen hängt davon ab, ob die Serien in der Tiefe, gruppiert oder gestapelt angeordnet sind. Für einen klaren Vergleich der Abstände zwischen einzelnen Serien verwenden Sie `ChartType.Column3D` aus der Aufzählung [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Diese Eigenschaften steuern verschiedene Aspekte des Diagramms:

| Eigenschaft | Auswirkung |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Markerbreite. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Abstand zwischen benachbarten Balken- oder Säulenclustern, als Prozentsatz der Balken‑ bzw. Säulenbreite. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Gesamttiefe des Diagramms, als Prozentsatz der Diagrammbreite. |

Das folgende eigenständige Beispiel verwendet die Standarddiagrammdaten, die drei Serien und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Drehung, Lückenbreite und Diagrammtiefe; nur die Lückentiefe ändert sich.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

Die folgenden Bilder wurden aus den erzeugten Präsentationen mit Microsoft PowerPoint exportiert.

| Lückentiefe: 0 % | Lückentiefe: 500 % |
| --- | --- |
| ![3D‑Säulendiagramm ohne Abstand zwischen Serien entlang der Tiefenachse](gap_depth_0.png) | ![3D‑Säulendiagramm mit einem Abstand von 500 % zwischen Serien entlang der Tiefenachse](gap_depth_500.png) |

## **3D‑Serientyp und Balkenform ändern**

In einem gruppierten Zylinderdiagramm beginnt die erste Serie mit einer zylindrischen Balkenform. Das Beispiel liest [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) und [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) vor und nach jeder Änderung.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| Änderung an der ersten Serie | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Diagramm erstellen | `ClusteredCylinder` | `Cylinder` |
| `Type` auf `ClusteredCone` setzen | `ClusteredCone` | `Cone` |
| `Bar3DShape` auf `Box` setzen | `ClusteredColumn3D` | `Box` |

Durch das Setzen der Form auf `Box` wird auch der Serientyp auf `ClusteredColumn3D` geändert. Wenn Ihr Code Zweige basierend auf dem Serientyp bildet, lesen Sie `series.Type` nach dem Ändern der Form. Ein vorher zwischengespeicherter Wert würde weiterhin den `ClusteredCone`‑Zweig auswählen.

![PowerPoint-Vergleich, der die erste Serie von links nach rechts als Zylinder, Kegel und rechteckige Säulen zeigt](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Aufzählung [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) bereitgestellt werden. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) in ein Bild exportieren oder die gesamte Folie über [render the entire slide](/slides/de/net/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Dies ist nützlich, wenn Sie eine Raster‑Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen auf Wänden und Plot‑Bereichen, begrenzen nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in einer angemessenen Auflösung und Größe, die den Ziel‑Anzeige‑ oder Druckanforderungen entspricht.