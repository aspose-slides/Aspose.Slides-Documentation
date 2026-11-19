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
description: "Vytvořte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro C++. Upravit rotaci, výškové proporce, hloubku grafu a mezery mezi sériemi pomocí příkladů v C++."
---
## **Přehled**

Aspose.Slides for C++ vám umožňuje přizpůsobit zobrazení 3D grafu pomocí [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Tento článek ukazuje, jak upravit rotaci, výškové proporce, hloubku, pravouhlé osy a mezery mezi sériemi a poté prezentaci uložit ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Níže uvedený příklad vytváří [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) a pomocí [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) přidává do první snímku seskupený 3D sloupcový graf. Nahrazuje výchozí série a kategorie dvěma sériemi obsahujícími po třech hodnotách. Index listu `0` identifikuje první datový list grafu; řádek `0` obsahuje názvy sérií a sloupec `0` obsahuje popisky kategorií.

Metody [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) a [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) nastavují rotaci grafu na 40 a 270 stupňů. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) nastavuje jeho hloubku na 150 % šířky, zatímco [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) povoluje pravouhlé osy místo perspektivy. Výsledná prezentace obsahuje vyplněný graf s těmito nastaveními 3D zobrazení.

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

## **Úprava výškových proporcí 3D grafu**

Použijte [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) pro nastavení výšky 3D grafu jako procenta jeho šířky. Tím změníte proporce 3D scény, aniž byste měnili velikost objektu grafu na snímku.

Následující příklad vytváří graf typu [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) s výchozími daty: tři série a čtyři kategorie. Uloží tři prezentace s výškovými proporcemi 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstávají pevné. Data, rotace, hloubka, mezera mezi sériemi a formátování jsou ve všech třech souborech identické; mění se pouze procento výšky.

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

Následující obrázky z ekvivalentního .NET příkladu byly exportovány pomocí Microsoft PowerPoint a ilustrují stejná nastavení výšky. Menší procento vytváří plošší scénu, zatímco větší procento vytváří vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly značek os a umístění popisků, aby scénu přizpůsobil.

| Výška: 50 % | Výška: 100 % | Výška: 200 % |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 % šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 % šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 % šířky](height_percent_200.png) |

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Výška 3D scény jako procento šířky. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Výška objektu grafu na snímku, v bodech. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Hloubka 3D scény jako procento šířky. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Mezery mezi sériemi podél osy hloubky, jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válcových, kuželových a pyramidových, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Porovnání výše používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy výčtu [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Další nastavení vzhledu grafu najdete v článku [Chart Formatting](/slides/cs/cpp/chart-formatting/).

## **Úprava mezery mezi sériemi**

Použijte [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) pro řízení vzdálenosti mezi datovými sériemi podél osy hloubky 3D grafu, vyjádřené jako procento šířky značky. Používejte hodnoty od **0 do 500**, včetně: `0` odstraní mezeru, vyšší hodnoty mezery zvětší. Při pevné hloubce grafu zvětšuje zvýšení mezery značky podél osy hloubky.

Přístup k skupině získáte pomocí [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Nastavení se vztahuje na všechny série v této skupině, ne jen na sérii, přes kterou je přistupováno. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) vrací nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich válcových, kuželových a pyramidových variant, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou série uspořádány v hloubce, seskupeny nebo naskládané. Pro přehledné srovnání mezer mezi jednotlivými sériemi použijte `ChartType::Column3D` z výčtu [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Mezery mezi sériemi podél osy hloubky, jako procento šířky značky. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Mezery mezi sousedními shluky sloupců nebo pruhů, jako procento šířky sloupce či pruhu. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Celková hloubka grafu, jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři série a čtyři kategorie. Uloží dvě prezentace se stejnými daty, rotací, šířkou mezery a hloubkou grafu; mění se jen hloubka mezery.

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

Následující obrázky z ekvivalentního .NET příkladu byly exportovány pomocí Microsoft PowerPoint a ilustrují stejné nastavení hloubky mezery.

| Mezery v hloubce: 0 % | Mezery v hloubce: 500 % |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi sériemi podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s 500 % mezerou mezi sériemi podél osy hloubky](gap_depth_500.png) |

## **Změna 3D typu série a tvaru pruhu**

V seskupeném válcovém grafu první série začíná válcovými pruhy. Příklad čte [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) a [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) před a po každé změně.

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

Nastavení tvaru na `Box` také mění typ série na `ClusteredColumn3D`. Pokud váš kód rozvětvuje podle typu série, zavolejte `series->get_Type()` po změně tvaru. Hodnota uložená před změnou by stále vedla k větvi `ClusteredCone`.

![Porovnání v PowerPointu ukazující první sérii jako válce, kužele a obdélníkové sloupce z leva doprava](series-shapes.png)

## **FAQ**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy vystavenými výčtem [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) v API referenci nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat do obrázku pomocí [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) nebo [renderovat celý snímek](/slides/cs/cpp/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete graf vložit do dokumentů, přístrojových panelů nebo webových stránek bez nutnosti PowerPointu.

**Jaký je výkon při vytváření a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky držte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a vykreslovacích plochách, omezte počet datových bodů na sérii, pokud je to možné, a renderujte do odpovídající velikosti výstupu (rozlišení a rozměry), aby odpovídaly cílovému displeji nebo tisku.