---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu C++
linktitle: Wykres 3D
type: docs
url: /pl/cpp/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Twórz wykresy 3D w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++. Dostosuj obrót, proporcje wysokości, głębokość wykresu i odstępy między seriami za pomocą przykładów w C++."
---
## **Przegląd**

Aspose.Slides for C++ umożliwia dostosowanie widoku wykresu 3D za pomocą [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Ten artykuł pokazuje, jak regulować obrót, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustaw obrót i głębokość wykresu 3D**

Poniższy przykład tworzy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) i przy użyciu [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) dodaje wykres kolumnowy 3D skumulowany do pierwszego slajdu. Zastępuje domyślne serie i kategorie dwoma seriami zawierającymi po trzy wartości. Indeks arkusza `0` identyfikuje pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` etykiety kategorii.

Metody [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) i [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) ustawiają obrót wykresu odpowiednio na 40 i 270 stopni. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) ustawia jego głębokość na 150 % szerokości, natomiast [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) włącza osie pod kątem prostym zamiast perspektywy. Uzyskana prezentacja zawiera wykres z tymi ustawieniami widoku 3D.

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

## **Zastosuj wypełnienie obrazem na powierzchni wykresu 3D**

Można niezależnie wypełnić [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), [back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) i [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) wykresu 3D. Ustaw typ wypełnienia powierzchni na `Picture` za pomocą [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) i przypisz obraz. Aby dopasować jedną kopię obrazu do całej powierzchni, ustaw zarówno [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/), jak i [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) powierzchni na `Stretch`.

Zapisz [arrow.png](arrow.png) w katalogu roboczym. Przykład obraca wykres i podnosi maksymalną wartość na osi pionowej, aby podłoga była widoczna między kolumnami. Następnie klonuje slajd dwukrotnie i nakłada strzałkę na inną powierzchnię w każdym slajdzie. Wszystkie trzy wykresy zachowują te same dane, kąt widzenia i tło.

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

Microsoft PowerPoint wyświetla trzy slajdy w następujący sposób.

| Ściana boczna | Ściana tylna | Podłoga |
| --- | --- | --- |
| ![Strzałka wskazująca do wykresu wzdłuż ściany bocznej](side-wall.png) | ![Strzałka wskazująca w prawo wzdłuż ściany tylnej](back-wall.png) | ![Strzałka wskazująca w prawo wzdłuż podłogi między kolumnami](floor.png) |

## **Dostosuj proporcje wysokości wykresu 3D**

Użyj [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/), aby ustawić wysokość wykresu 3D jako procent jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) z domyślnymi danymi: trzy serie i cztery kategorie. Zapisuje trzy prezentacje z proporcjami wysokości 50 %, 100 % i 200 %. Pozycja, szerokość i wysokość wykresu pozostają stałe. Dane, obrót, głębokość, odstępy serii i formatowanie są identyczne we wszystkich trzech plikach; zmienia się tylko procent wysokości.

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

Poniższe obrazy pochodzące z odpowiedniego przykładu .NET zostały wyeksportowane przy użyciu Microsoft PowerPoint i ilustrują te same ustawienia wysokości. Mniejszy procent daje płaską scenę, większy procent – wyższą scenę przy tym samym obiekcie wykresu. PowerPoint może także dostosować interwały znaczników osi i rozmieszczenie etykiet, aby dopasować scenę.

| Wysokość: 50% | Wysokość: 100% | Wysokość: 200% |
| --- | --- | --- |
| ![Wykres słupkowy 3D z wysokością ustawioną na 50% jego szerokości](height_percent_50.png) | ![Wykres słupkowy 3D z wysokością ustawioną na 100% jego szerokości](height_percent_100.png) | ![Wykres słupkowy 3D z wysokością ustawioną na 200% jego szerokości](height_percent_200.png) |

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Wysokość sceny 3D jako procent jej szerokości. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Głębokość sceny 3D jako procent jej szerokości. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Odległość między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |

Ustawienie wysokości wpływa na wykresy kolumnowe i słupkowe 3D, w tym warianty cylindryczne, stożkowe i piramidowe, a także wykresy 3D liniowe, powierzchniowe, kołowe i obszarowe. Porównanie powyżej używa zweryfikowanego typu `Column3D`. Ustawienie nie zmienia wyglądu wykresu 2D `ClusteredColumn` ani wykresu `BubbleWith3D`; nazwy te są członkami wyliczenia [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Inne ustawienia wyglądu wykresu znajdują się w sekcji [Chart Formatting](/slides/pl/cpp/chart-formatting/).

## **Dostosuj odstęp między seriami**

Użyj [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/), aby kontrolować odległość między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażoną jako procent szerokości znacznika. Dozwolone wartości to **0 do 500**, włącznie: `0` usuwa odstęp, większe wartości zwiększają go. Przy stałej głębokości wykresu zwiększanie odstępu powoduje, że znaczniki stają się cieńsze wzdłuż osi głębokości.

Dostęp do grupy uzyskuje się przez [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Ustawienie dotyczy każdej serii w tej grupie, nie tylko serii użytej do uzyskania dostępu. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) zwraca ustawienie grupy nadrzędnej.

To ustawienie wpływa na wykresy kolumnowe i słupkowe 3D, w tym ich warianty cylindryczne, stożkowe i piramidowe, a także wykresy 3D liniowe i powierzchniowe. Wygląd zależy od tego, czy serie są rozmieszczone w głębokości, grupowane czy skumulowane. Dla wyraźnego porównania odstępów między oddzielnymi seriami użyj `ChartType::Column3D` z wyliczenia [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Odległość między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Odległość między sąsiadującymi grupami słupków lub kolumn, jako procent szerokości słupka lub kolumny. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Całkowita głębokość wykresu, jako procent szerokości wykresu. |

Poniższy przykład samodzielny wykorzystuje domyślne dane wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwie prezentacje z identycznymi danymi, obrotem, szerokością odstępu i głębokością wykresu; zmienia się tylko głębokość odstępu.

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

Poniższe obrazy pochodzące z odpowiedniego przykładu .NET zostały wyeksportowane przy użyciu Microsoft PowerPoint i ilustrują te same ustawienia głębokości odstępu.

| Odstęp między seriami: 0% | Odstęp między seriami: 500% |
| --- | --- |
| ![Wykres kolumnowy 3D bez odstępu między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres kolumnowy 3D z odstępem 500% między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmień typ serii 3D i kształt słupka**

W wykresie skumulowanym cylindrycznym pierwsza seria zaczyna się od słupków cylindrycznych. Przykład odczytuje [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) i [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) przed i po każdej zmianie.

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

| Zmiana pierwszej serii | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Call [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) with `ClusteredCone` | `ClusteredCone` | `Cone` |
| Call [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) with `Box` | `ClusteredColumn3D` | `Box` |

Ustawienie kształtu na `Box` zmienia również typ serii na `ClusteredColumn3D`. Jeśli Twój kod rozgałęzia się w zależności od typu serii, wywołaj `series->get_Type()` po zmianie kształtu. Wartość zapamiętana przed zmianą nadal wybrałaby gałąź `ClusteredCone`.

![Porównanie w PowerPoint pokazujące pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D oraz 100 % Stacked Column 3D, a także powiązane typy 3D udostępniane przez wyliczenie [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członki [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) w dokumentacji API swojej zainstalowanej wersji.

**Czy mogę uzyskać obraz rastrowy wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres do obrazu przy użyciu [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) lub [renderować cały slajd](/slides/pl/cpp/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd rastrowy lub chcesz osadzić wykres w dokumentach, dashboardach lub stronach internetowych bez wymogu użycia PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od wielkości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, ogranicz efekty 3D do niezbędnego minimum, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do odpowiednio dobranej rozdzielczości i wymiarów, dopasowanych do docelowego wyświetlacza lub potrzeb druku.