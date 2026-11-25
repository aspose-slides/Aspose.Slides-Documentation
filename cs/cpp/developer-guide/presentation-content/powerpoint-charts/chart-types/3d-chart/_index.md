---
title: Přizpůsobení 3D grafů v prezentacích pomocí C++
linktitle: 3D graf
type: docs
url: /cs/cpp/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvářejte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro C++. Nastavte rotaci, výškové poměry, hloubku grafu a mezery mezi sériemi s příklady v C++."
---
## **Přehled**

Aspose.Slides for C++ vám umožňuje přizpůsobit pohled na 3D graf prostřednictvím [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Tento článek ukazuje, jak upravit rotaci, výškové poměry, hloubku, pravouhlé osy a mezery mezi sériemi a poté uložit prezentaci ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Níže uvedený příklad vytvoří [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) a pomocí [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) přidá na první snímek seskupený 3D sloupcový graf. Nahradí výchozí série a kategorie dvěma sériemi, z nichž každá obsahuje tři hodnoty. Index listu `0` označuje první list s daty grafu; řádek `0` obsahuje názvy sérií a sloupec `0` popisky kategorií.

Metody [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) a [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) nastavují rotaci grafu na 40 a 270 stupňů. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) stanoví jeho hloubku na 150 % šířky, zatímco [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) povolí pravouhlé osy místo perspektivy. Výsledná prezentace obsahuje naplněný graf s těmito nastaveními 3D zobrazení.

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

## **Použití obrázkového výplně na povrch 3D grafu**

Můžete samostatně naplnit [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), [back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) a [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) 3D grafu. Nastavte [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) povrchu na `Picture` a přiřaďte obrázek. Pro roztažení jedné kopie obrázku přes celou plochu nastavte jak [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/), tak [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) na `Stretch`.

Uložte soubor [arrow.png](arrow.png) do pracovního adresáře. Příklad otáčí graf a zvyšuje maximální hodnotu na svislé ose, aby byla podlaha viditelná mezi sloupci. Poté klonuje snímek dvakrát a na každém snímku použije šipku na jiný povrch. Všechny tři grafy zachovávají stejná data, úhel pohledu i pozadí.

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

Microsoft PowerPoint zobrazuje tři snímky následovně.

| Boční stěna | Zadní stěna | Podlaha |
| --- | --- | --- |
| ![Šipka směřující do grafu podél boční stěny](side-wall.png) | ![Šipka směřující doprava přes zadní stěnu](back-wall.png) | ![Šipka směřující doprava přes podlahu mezi sloupci](floor.png) |

## **Úprava výškových poměrů 3D grafu**

Použijte [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) k nastavení výšky 3D grafu jako procenta jeho šířky. Tím změníte proporce 3D scény, aniž byste měnili velikost objektu grafu na snímku.

Následující příklad vytvoří graf typu [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) s výchozími daty: tři série a čtyři kategorie. Uloží tři prezentace s výškovými poměry 50 %, 100 % a 200 %. Poloha, šířka a výška grafu zůstávají pevné. Data, rotace, hloubka, mezery mezi sériemi a formátování jsou ve všech třech souborech identické; mění se pouze procento výšky.

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

Následující obrázky z ekvivalentního .NET příkladu byly exportovány pomocí Microsoft PowerPoint a ukazují stejná nastavení výšky. Menší procento vytváří plošší scénu, zatímco větší procento vytváří vyšší scénu v rámci stejného objektu grafu. PowerPoint může také upravit intervaly osových značek a umístění popisků, aby scéna lépe zapadla.

| Výška: 50 % | Výška: 100 % | Výška: 200 % |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 % šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 % šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 % šířky](height_percent_200.png) |

Tyto metody ovládají různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Výška 3D scény jako procento její šířky. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Výška objektu grafu na snímku v bodech. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Hloubka 3D scény jako procento její šířky. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Mezery mezi sériemi podél osy hloubky, jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válec, kužel a pyramida, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Výše uvedené srovnání používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy výčtu [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Pro další nastavení vzhledu grafu viz [Formátování grafu](/slides/cs/cpp/chart-formatting/).

## **Úprava mezery mezi sériemi**

Použijte [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) k řízení vzdálenosti mezi datovými sériemi podél osy hloubky 3D grafu, vyjádřené jako procento šířky značky. Používejte hodnoty **0 až 500**, včetně: `0` odstraní mezeru, vyšší hodnoty mezery zvětší. Při pevné hloubce grafu zvětšení mezery způsobí, že značky budou podél osy hloubky tenčí.

Přístup ke skupině získáte přes [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Nastavení se vztahuje na všechny série ve skupině, nikoli jen na tu, kterou použijete pro získání skupiny. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) vrací nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich válec, kužel a pyramida variant, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou série uspořádány v hloubce, seskupeny nebo naskládány. Pro jasné srovnání mezer mezi oddělenými sériemi použijte `ChartType::Column3D` z výčtu [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Tyto metody ovládají různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Mezery mezi sériemi podél osy hloubky, jako procento šířky značky. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Mezery mezi sousedními shluky sloupců nebo pruhů, jako procento šířky sloupce či pruhu. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři série a čtyři kategorie. Uloží dva soubory s identickými daty, rotací, šířkou mezery a hloubkou grafu; mění se jen hloubka mezery.

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

Následující obrázky z ekvivalentního .NET příkladu byly exportovány pomocí Microsoft PowerPoint a ukazují stejná nastavení hloubky mezery.

| Hloubka mezery: 0 % | Hloubka mezery: 500 % |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi sériemi podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s mezerou 500 % mezi sériemi podél osy hloubky](gap_depth_500.png) |

## **Změna 3D typu série a tvaru pruhu**

V seskupeném válcovém grafu první série začíná válcovými pruhy. Příklad načte [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) a [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) před a po každé změně.

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

| Změna první série | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Vytvoření grafu | `ClusteredCylinder` | `Cylinder` |
| Volání [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) s `ClusteredCone` | `ClusteredCone` | `Cone` |
| Volání [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) s `Box` | `ClusteredColumn3D` | `Box` |

Nastavení tvaru na `Box` také mění typ série na `ClusteredColumn3D`. Pokud ve vašem kódu rozvětvujete podle typu série, zavolejte po změně tvaru `series->get_Type()`. Hodnota načtená před změnou by stále vedla k větvi `ClusteredCone`.

![Porovnání v PowerPointu ukazující první sérii jako válcové, kuželové a obdélníkové sloupce zleva doprava](series-shapes.png)

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s dalšími 3D typy vystavenými skrze výčet [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) v API referenci vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat do obrázku pomocí [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) nebo [vyrenderovat celý snímek](/slides/cs/cpp/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete graf vložit do dokumentů, dashboardů či webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a renderování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky držte 3D efekty na minimu, vyhněte se těžkým texturám na zdech a ploše grafu, omezte počet datových bodů na sérii, pokud je to možné, a renderujte do vhodně velkého výstupu (rozlišení a rozměry), který odpovídá cílovému zobrazení nebo tisku.