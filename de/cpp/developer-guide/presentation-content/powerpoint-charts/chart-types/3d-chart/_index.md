---
title: Anpassen von 3D-Diagrammen in Präsentationen mit C++
linktitle: 3D Diagramm
type: docs
url: /de/cpp/3d-chart/
keywords:
- 3D-Diagramm
- Rotation
- Tiefe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für C++. Passen Sie Drehung, Höhenverhältnisse, Diagrammtiefe und den Abstand zwischen Serien mit C++-Beispielen an."
---
## **Übersicht**

Aspose.Slides für C++ ermöglicht es Ihnen, die Ansicht eines 3D‑Diagramms über [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Dieser Artikel zeigt, wie Sie Drehung, Höhenverhältnisse, Tiefe, rechtwinklige Achsen und den Abstand zwischen Serien anpassen und die Präsentation anschließend im PPTX‑Format speichern.

## **Drehung und Tiefe eines 3D‑Diagramms festlegen**

Das nachstehende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) und verwendet [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/), um ein gruppiertes 3D‑Säulendiagramm zur ersten Folie hinzuzufügen. Es ersetzt die Standardserien und -kategorien durch zwei Serien mit jeweils drei Werten. Der Arbeitsblattindex `0` identifiziert das erste Datenarbeitsblatt des Diagramms; Zeile `0` enthält die Seriennamen und Spalte `0` die Kategorienamen.

Die Methoden [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) und [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) setzen die Drehung des Diagramms auf jeweils 40 bzw. 270 Grad. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) legt die Tiefe auf 150 % seiner Breite fest, während [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) rechtswinklige Achsen anstelle von Perspektive aktiviert. Die resultierende Präsentation enthält das befüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Höhenverhältnisse eines 3D‑Diagramms anpassen**

Verwenden Sie [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/), um die Höhe eines 3D‑Diagramms als Prozentsatz seiner Breite festzulegen. Damit ändern Sie die Proportionen der 3D‑Szene, ohne das Diagrammobjekt auf der Folie zu skalieren.

Das folgende Beispiel erstellt ein [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑Diagramm mit den Standarddaten: drei Serien und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50 %, 100 % und 200 %. Position, Breite und Höhe des Diagramms bleiben unverändert. Daten, Drehung, Tiefe, Serienabstand und Formatierung sind in allen drei Dateien identisch; nur das Höhen‑Prozent wird geändert.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Die folgenden Bilder aus dem entsprechenden .NET‑Beispiel wurden mit Microsoft PowerPoint exportiert und zeigen dieselben Höhe‑Einstellungen. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, ein größerer Prozentsatz eine höhere Szene innerhalb desselben Diagrammobjekts. PowerPoint kann zudem die Achsen‑Tick‑Intervalle und die Beschriftungsposition an die Szene anpassen.

| Höhe: 50% | Höhe: 100% | Höhe: 200% |
| --- | --- | --- |
| ![3D‑Säulendiagramm mit einer Höhe von 50 % seiner Breite](height_percent_50.png) | ![3D‑Säulendiagramm mit einer Höhe von 100 % seiner Breite](height_percent_100.png) | ![3D‑Säulendiagramm mit einer Höhe von 200 % seiner Breite](height_percent_200.png) |

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Wirkung |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Höhe des Diagrammobjekts auf der Folie, in Punkten. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Markerbreite. |

Die Höhen‑Einstellung beeinflusst 3D‑Säulen‑ und Balkendiagramme, einschließlich Zylinder‑, Kegel‑ und Pyramidenvarianten, sowie 3D‑Linien‑, Flächen‑, Kuchen‑ und Oberflächendiagramme. Der obige Vergleich verwendet den verifizierten Typ `Column3D`. Die Einstellung ändert das Aussehen eines 2D‑Diagramms `ClusteredColumn` oder eines `BubbleWith3D`‑Diagramms nicht; diese Namen sind Mitglieder der [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑Aufzählung. Weitere Diagramm‑Formatierungseinstellungen finden Sie unter [Diagrammformatierung](/slides/de/cpp/chart-formatting/).

## **Abstand zwischen Serien anpassen**

Verwenden Sie [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/), um den Abstand zwischen Datenserien entlang der Tiefenachse eines 3D‑Diagramms zu steuern, ausgedrückt als Prozentsatz der Markerbreite. Verwenden Sie Werte von **0 bis 500** (einschließlich): `0` entfernt den Abstand, während höhere Werte den Abstand vergrößern. Bei fester Diagrammtiefe führt ein größerer Abstand dazu, dass die Marker entlang der Tiefenachse dünner werden.

Greifen Sie über [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) auf die Gruppe zu. Die Einstellung gilt für jede Serie in dieser Gruppe, nicht nur für die Serie, über die zugegriffen wurde. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) gibt die Einstellung der übergeordneten Gruppe zurück.

Diese Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich ihrer Zylinder‑, Kegel‑ und Pyramidenvarianten, sowie auf 3D‑Linien‑ und Flächendiagramme. Das Aussehen hängt davon ab, ob die Serien in der Tiefe, gruppiert oder gestapelt angeordnet sind. Für einen klaren Vergleich der Abstände zwischen einzelnen Serien verwenden Sie `ChartType::Column3D` aus der [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑Aufzählung.

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Wirkung |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Markerbreite. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Abstand zwischen benachbarten Balken‑ oder Säulen‑clustern, als Prozentsatz der Balken‑ bzw. Säulenbreite. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Gesamttiefe des Diagramms, als Prozentsatz der Diagrammbreite. |

Das nachfolgende eigenständige Beispiel verwendet die Standarddiagrammdaten, die drei Serien und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Drehung, Abstandsbreite und Diagrammtiefe; nur die Abstandstiefe ändert sich.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Die folgenden Bilder aus dem entsprechenden .NET‑Beispiel wurden mit Microsoft PowerPoint exportiert und zeigen dieselben Einstellungen für die Abstandstiefe.

| Abstandstiefe: 0% | Abstandstiefe: 500% |
| --- | --- |
| ![3D‑Säulendiagramm ohne Abstand zwischen Serien entlang der Tiefenachse](gap_depth_0.png) | ![3D‑Säulendiagramm mit einem Abstand von 500 % zwischen Serien entlang der Tiefenachse](gap_depth_500.png) |

## **Ändern des 3D‑Serientyps und der Balkenform**

In einem gruppierten Zylinderdiagramm beginnt die erste Serie mit Zylinderbalken. Das Beispiel liest [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) und [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) vor und nach jeder Änderung.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| Änderung der ersten Serie | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Diagramm erstellen | `ClusteredCylinder` | `Cylinder` |
| Aufruf von [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) mit `ClusteredCone` | `ClusteredCone` | `Cone` |
| Aufruf von [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) mit `Box` | `ClusteredColumn3D` | `Box` |

Das Setzen der Form auf `Box` ändert zudem den Serientyp zu `ClusteredColumn3D`. Wenn Ihr Code nach dem Serientyp verzweigt, rufen Sie `series->get_Type()` nach dem Ändern der Form auf. Ein vor dem Ändern zwischengespeicherter Wert würde weiterhin den `ClusteredCone`‑Zweig auswählen.

![PowerPoint-Vergleich, der die erste Serie von links nach rechts als Zylinder, Kegel und rechteckige Säulen zeigt](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑Aufzählung bereitgestellt werden. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder der [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑Aufzählung in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm mit [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) in ein Bild exportieren oder [die gesamte Folie rendern](/slides/de/cpp/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG. Dies ist nützlich, wenn Sie eine Raster‑Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen an Wänden und Zeichenflächen, begrenzen nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in einer angemessenen Ausgabegröße (Auflösung und Abmessungen), die den Ziel‑Anzeige‑ oder Druckanforderungen entspricht.