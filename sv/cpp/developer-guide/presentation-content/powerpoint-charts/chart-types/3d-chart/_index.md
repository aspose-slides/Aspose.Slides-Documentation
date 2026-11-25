---
title: Anpassa 3D-diagram i presentationer med C++
linktitle: 3D-diagram
type: docs
url: /sv/cpp/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa 3D-diagram i PowerPoint-presentationer med Aspose.Slides för C++. Justera rotation, höjdförhållanden, diagramdjup och avstånd mellan serier med C++-exempel."
---
## **Översikt**

Aspose.Slides för C++ låter dig anpassa vyn av ett 3D-diagram via [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Den här artikeln visar hur du justerar rotation, höjdförhållanden, djup, räta vinkel‑axlar och avstånd mellan serier, och sedan sparar presentationen i PPTX-format.

## **Ställ in rotation och djup för ett 3D-diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) och använder [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) för att lägga till ett staplat 3D‑kolumn‑diagram på dess första bild. Det ersätter standardserierna och -kategorierna med två serier som innehåller tre värden vardera. Arbetsbladindexet `0` identifierar diagrammets första datablad; rad `0` innehåller serienamnen och kolumn `0` innehåller kategorierna.

Metoderna [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) och [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) sätter diagrammets rotation till 40 respektive 270 grader. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) sätter dess djup till 150 % av dess bredd, medan [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) aktiverar räta vinkel‑axlar istället för perspektiv. Den resulterande presentationen innehåller diagrammet med dessa 3D‑vyinställningar.

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

## **Applicera en bildfyllning på en 3D-diagramyta**

Du kan fylla [sidovägg](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), [bakvägg](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) och [golv](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) i ett 3D‑diagram separat. Ställ in ytkens [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) till `Picture` och tilldela en bild. För att passa en kopia av bilden över ytan, ställ in både [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) och ytkens [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) till `Stretch`.

Spara [arrow.png](arrow.png) i arbetskatalogen. Exemplet roterar diagrammet och höjer maxvärdet på den vertikala axeln så att golvet syns mellan kolumnerna. Det klonar sedan bilden två gånger och applicerar pilen på en annan yta på varje bild. Alla tre diagrammen behåller samma data, vyvinkel och bakgrund.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Microsoft PowerPoint visar de tre bilderna enligt följande.

| Sidovägg | Bakvägg | Golv |
| --- | --- | --- |
| ![Pil som pekar in i diagrammet längs sidoväggen](side-wall.png) | ![Pil som pekar åt höger över bakväggen](back-wall.png) | ![Pil som pekar åt höger över golvet mellan kolumnerna](floor.png) |

## **Justera höjdförhållandena för ett 3D-diagram**

Använd [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) för att sätta diagrammets höjd som en procentandel av dess bredd. Detta ändrar proportionerna i 3D‑scenen utan att ändra storleken på diagramobjektet på bilden.

Följande exempel skapar ett [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdförhållanden på 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, serieavstånd och formatering är identiska i alla tre filer; endast höjdprocenten ändras.

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

Följande bilder från motsvarande .NET‑exempel exporterades med Microsoft PowerPoint och visar samma höjdinställningar. En mindre procentandel ger en flackare scen, medan en större procentandel ger en högre scen inom samma diagramobjekt. PowerPoint kan också justera axelns tick‑intervall och etikettplacering för att passa scenen.

| Höjd: 50 % | Höjd: 100 % | Höjd: 200 % |
| --- | --- | --- |
| ![3D‑kolumndiagram med höjden satt till 50 % av dess bredd](height_percent_50.png) | ![3D‑kolumndiagram med höjden satt till 100 % av dess bredd](height_percent_100.png) | ![3D‑kolumndiagram med höjden satt till 200 % av dess bredd](height_percent_200.png) |

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Höjden på 3D‑scenen som en procentandel av dess bredd. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Höjden på diagramobjektet på bilden, i punkter. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Djupet på 3D‑scenen som en procentandel av dess bredd. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |

Höjdinställningen påverkar 3D‑kolumn‑ och stapeldiagram, inklusive cylinder-, kon- och pyramidvarianter, samt 3D‑linje-, område-, paj- och ytdiagram. Jämförelsen ovan använder den verifierade typen `Column3D`. Inställningen ändrar inte utseendet på ett 2D‑`ClusteredColumn`‑diagram eller ett `BubbleWith3D`‑diagram; dessa namn är medlemmar i uppräkningen [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). För andra diagramutseende‑inställningar, se [Chart Formatting](/slides/sv/cpp/chart-formatting/).

## **Justera avståndet mellan serier**

Använd [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) för att kontrollera avståndet mellan dataserier längs djupaxeln i ett 3D‑diagram, uttryckt som en procentandel av markörens bredd. Använd värden från **0 till 500**, inklusive: `0` tar bort avståndet, medan större värden ökar avståndet. Med ett fast diagramdjup gör ett ökat avstånd markörerna tunnare längs djupaxeln.

Kom åt gruppen via [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Inställningen gäller för varje serie i den gruppen, inte bara för den serie som användes för åtkomst. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) returnerar gruppens inställning.

Denna inställning påverkar 3D‑kolumn‑ och stapeldiagram, inklusive deras cylinder-, kon- och pyramidvarianter, samt 3D‑linje‑ och områdesdiagram. Utseendet beror på om serierna är arrangerade i djup, grupperade eller staplade. För en tydlig jämförelse av avstånd mellan separata serier, använd `ChartType::Column3D` från uppräkningen [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Avstånd mellan intilliggande stapel- eller kolumnkluster, som en procentandel av stapelns eller kolumnens bredd. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Totalt diagramdjup, som en procentandel av diagrammets bredd. |

Följande fristående exempel använder standarddiagramdata, som innehåller tre serier och fyra kategorier. Det sparar två presentationer med identiska data, rotation, avståndsbredd och diagramdjup; endast avståndsdjupet ändras.

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

Följande bilder från motsvarande .NET‑exempel exporterades med Microsoft PowerPoint och visar samma avståndsdjup‑inställningar.

| Avståndsdjup: 0 % | Avståndsdjup: 500 % |
| --- | --- |
| ![3D‑kolumndiagram utan avstånd mellan serier längs djupaxeln](gap_depth_0.png) | ![3D‑kolumndiagram med ett 500 % avstånd mellan serier längs djupaxeln](gap_depth_500.png) |

## **Ändra 3D-serietyp och stapelform**

I ett grupperat cylinderdiagram börjar den första serien med cylindriska staplar. Exemplet läser [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) och [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) före och efter varje förändring.

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

| Ändring av den första serien | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Call [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) with `ClusteredCone` | `ClusteredCone` | `Cone` |
| Call [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) with `Box` | `ClusteredColumn3D` | `Box` |

Att sätta formen till `Box` ändrar också serietypen till `ClusteredColumn3D`. Om din kod har villkor baserade på serietypen, anropa `series->get_Type()` efter att ha ändrat formen. ett värde som cachats innan förändringen skulle fortfarande välja `ClusteredCone`‑grenen.

![PowerPoint‑jämförelse som visar den första serien som cylindrar, koner och rektangulära kolumner från vänster till höger](series-shapes.png)

## **FAQ**

**Vilka diagramtyper stödjer 3D‑läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av kolumndiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via uppräkningen [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). För en exakt, aktuell lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild med [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) eller [rendera hela bilden](/slides/sv/cpp/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en rasterförhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterande är konstruktion och rendering av stora 3D‑diagram?**

Prestanda beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekterna minimala, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämpligt stor output (upplösning och dimensioner) som matchar målskärmen eller utskriftsbehoven.