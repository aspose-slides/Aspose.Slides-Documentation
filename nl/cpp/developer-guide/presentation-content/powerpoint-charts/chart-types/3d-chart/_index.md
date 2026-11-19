---
title: 3D-diagrammen aanpassen in presentaties met C++
linktitle: 3D-diagram
type: docs
url: /nl/cpp/3d-chart/
keywords:
- 3D-diagram
- rotatie
- diepte
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak 3D-diagrammen in PowerPoint-presentaties met Aspose.Slides voor C++. Pas rotatie, hoogte-proporties, diagramdiepte en de afstand tussen series aan met C++-voorbeelden."
---
## **Overzicht**

Aspose.Slides for C++ stelt je in staat de weergave van een 3D‑diagram aan te passen via [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Dit artikel laat zien hoe je rotatie, hoogteproporties, diepte, hoeken‑van‑assen en de afstand tussen series kunt aanpassen, en vervolgens de presentatie opslaat in PPTX‑formaat.

## **Instellen van rotatie en diepte van een 3D‑diagram**

Het onderstaande voorbeeld maakt een [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) aan en gebruikt [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) om een gestapeld 3D‑kolomdiagram toe te voegen aan de eerste dia. Het vervangt de standaard series en categorieën door twee series met elk drie waarden. Werkblad‑index `0` geeft het eerste gegevenswerkblad van het diagram aan; rij `0` bevat de serienaam en kolom `0` de categorielabels.

De methoden [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) en [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) stellen de rotatie van het diagram respectievelijk in op 40 en 270 graden. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) stelt de diepte in op 150 % van de breedte, terwijl [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) rechte‑hoeken‑assen inschakelt in plaats van perspectief. De resulterende presentatie bevat het gevulde diagram met deze 3D‑weergave‑instellingen.

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

## **Aanpassen van de hoogte‑proporties van een 3D‑diagram**

Gebruik [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) om de hoogte van een 3D‑diagram in te stellen als een percentage van de breedte. Dit wijzigt de proporties van de 3D‑scene zonder de grootte van het diagramobject op de dia aan te passen.

Het onderstaande voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑diagram met de standaardgegevens: drie series en vier categorieën. Het slaat drie presentaties op met hoogte‑proporties van 50 %, 100 % en 200 %. De positie, breedte en hoogte van het diagram blijven gelijk. De gegevens, rotatie, diepte, seriële afstand en opmaak zijn identiek in alle drie de bestanden; alleen het hoogte‑percentage wijzigt.

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

De onderstaande afbeeldingen uit het gelijkwaardige .NET‑voorbeeld zijn geëxporteerd met Microsoft PowerPoint en illustreren dezelfde hoogte‑instellingen. Een kleiner percentage levert een plattere scene op, terwijl een groter percentage een hogere scene binnen hetzelfde diagramobject oplevert. PowerPoint kan ook de interval‑ en label‑plaatsing van de assen aanpassen om de scene passend te maken.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D‑kolomdiagram met hoogte ingesteld op 50 % van de breedte](height_percent_50.png) | ![3D‑kolomdiagram met hoogte ingesteld op 100 % van de breedte](height_percent_100.png) | ![3D‑kolomdiagram met hoogte ingesteld op 200 % van de breedte](height_percent_200.png) |

Deze methoden regelen verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Hoogte van de 3D‑scene als percentage van de breedte. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Hoogte van het diagramobject op de dia, in punten. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Diepte van de 3D‑scene als percentage van de breedte. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Afstand tussen series langs de diepte‑as, als percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief cilinder‑, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑, vlak‑, taart‑ en oppervlakdiagrammen. De bovenstaande vergelijking gebruikt het gevalideerde type `Column3D`. De instelling verandert niet het uiterlijk van een 2D‑`ClusteredColumn`‑diagram of een `BubbleWith3D`‑diagram; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑enumeratie. Voor andere diagram‑opmaak‑instellingen, zie [Chart Formatting](/slides/nl/cpp/chart-formatting/).

## **Aanpassen van de kloof tussen series**

Gebruik [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) om de afstand tussen dataseries langs de diepte‑as van een 3D‑diagram te regelen, uitgedrukt als een percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de kloof, terwijl hogere waarden de spatiëring vergroten. Bij een vaste diagramdiepte zorgt een grotere kloof ervoor dat de markers dunner worden langs de diepte‑as.

Benader de groep via [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). De instelling wordt toegepast op elke serie in die groep, niet alleen op de serie die wordt gebruikt om er toegang toe te krijgen. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) retourneert de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief hun cilinder‑, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑ en vlakdiagrammen. Het uiterlijk hangt af van of de series in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van kloof tussen afzonderlijke series, gebruik `ChartType::Column3D` uit de [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑enumeratie.

| Methode | Effect |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Afstand tussen series langs de diepte‑as, als percentage van de markerbreedte. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Afstand tussen aangrenzende balk‑ of kolomclusters, als percentage van de balk‑ of kolombreedte. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Totale diagramdiepte, als percentage van de diagrambreedte. |

Het onderstaande zelfstandige voorbeeld gebruikt de standaarddiagramgegevens, die drie series en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, kloofbreedte en diagramdiepte; alleen de kloofdiepte verandert.

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

De onderstaande afbeeldingen uit het gelijkwaardige .NET‑voorbeeld zijn geëxporteerd met Microsoft PowerPoint en illustreren dezelfde kloofdiepte‑instellingen.

| Kloofdiepte: 0% | Kloofdiepte: 500% |
| --- | --- |
| ![3D‑kolomdiagram zonder kloof tussen series langs de diepte‑as](gap_depth_0.png) | ![3D‑kolomdiagram met een kloof van 500 % tussen series langs de diepte‑as](gap_depth_500.png) |

## **Wijzigen van het 3D‑serietype en de staafvorm**

In een gegroepeerd cilinderdiagram start de eerste serie met cilindrische balken. Het voorbeeld leest [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) en [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) vóór en na elke wijziging.

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

| Wijziging van de eerste serie | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Call [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) with `ClusteredCone` | `ClusteredCone` | `Cone` |
| Call [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) with `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` wijzigt ook het serietype naar `ClusteredColumn3D`. Als je code vertakkingen maakt op basis van het serietype, roep dan `series->get_Type()` aan na het wijzigen van de vorm. Een vóór de wijziging gecachte waarde zou nog steeds de `ClusteredCone`‑vertakking selecteren.

![PowerPoint‑vergelijking die de eerste serie toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **FAQ**

**Welke diagramtypen ondersteunen 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die beschikbaar worden gesteld via de [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)-enumeratie. Voor een exacte, actuele lijst, bekijk de leden van [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) in de API‑referentie van de geïnstalleerde versie.

**Kan ik een raster‑afbeelding van een 3D‑diagram krijgen voor een rapport of het web?**

Ja. Je kunt een diagram naar een afbeelding exporteren met [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) of [de gehele dia renderen](/slides/nl/cpp/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer je een raster‑voorbeeld nodig hebt of het diagram wilt insluiten in documenten, dashboards of webpagina’s zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D‑diagrammen?**

De prestaties hangen af van het gegevensvolume en de visuele complexiteit. Voor optimale resultaten houd je 3D‑effecten tot een minimum, vermijd je zware texturen op muren en plot‑gebieden, beperk je het aantal datapoints per serie waar mogelijk, en render je naar een output van passende grootte (resolutie en afmetingen) afgestemd op het doelscherm of de afdrukbehoeften.