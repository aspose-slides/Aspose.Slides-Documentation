---
title: Dodaj linie trendu do wykresów w prezentacji w C++
linktitle: Linia trendu
type: docs
url: /pl/cpp/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- niestandardowa linia trendu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides dla C++ — praktyczny przewodnik, który przyciągnie uwagę Twojej publiczności."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z różnymi typami linii trendu, w tym wykładniczą, liniową, logarytmiczną, średnią kroczącą, wielomianową i potęgową.

Opisuje również, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ na temat wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazów.

## **Dodaj linię trendu**

Użyj [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) aby dodać linię trendu do serii wykresu, wybierając jej typ za pomocą [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). Przykład tworzy skumulowany wykres słupkowy z domyślnymi danymi i dodaje dwie linie trendu do każdej z trzech serii.

Linia trendu wykładnicza ukrywa równanie i wartość R-kwadrat przy użyciu [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) i [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/), podczas gdy linia trendu liniowa jest czerwona. Linia trendu logarytmiczna używa [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) dla własnej etykiety. Średnia krocząca używa [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) do średniowania trzech punktów danych oraz [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) dla własnej nazwy.

Linia trendu wielomianowa używa [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) aby ustawić stopień na trzy i przedłuża jedną kategorię do przodu za pomocą [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). Linia trendu potęgowa przedłuża jedną kategorię do tyłu za pomocą [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **Ustaw przecięcie linii trendu**

Użyj [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) aby ustawić wartość Y linii trendu przy X = 0. To ustawienie jest obsługiwane dla linii trendu liniowych, wykładniczych i wielomianowych.

Na przykład model kosztów produkcji może wymagać rozpoczęcia od znanych stałych kosztów wynoszących 100, nawet gdy pomiary przy niezerowych wolumenach produkcji sugerują inną bazę. Dla linii trendu liniowej, ustalenie przecięcia wymusza równanie `y = ax + b` na `b = 100`; nachylenie jest dopasowywane do danych przy tym ograniczeniu. Nie powoduje to po prostu przesunięcia już dopasowanej linii. Ustawienia przecięcia osi kontrolują, gdzie osie wykresu się spotykają, a nie współczynniki dopasowanej linii trendu.

Poniższy przykład tworzy wykres punktowy (XY) z wolumenami produkcji od 1 do 4 oraz kosztami 170, 200, 230 i 260. Zapisuje wykres z domyślnym automatycznym przecięciem, ustawia przecięcie na 100 i zapisuje drugi plik PPTX. Dwa pliki różnią się wyłącznie ustawieniem przecięcia. Linia trendu wyświetla swoje równanie i przedłuża się do X = 0.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

Przy automatycznym obliczaniu te dane dają `y = 30x + 140`. Ustawienie przecięcia na 100 daje w przybliżeniu `y = 43.33x + 100`: dopasowana wartość przy zerze pasuje do znanej bazy, podczas gdy linia nie przechodzi już przez każdy punkt danych.

| Automatyczne przecięcie | Ustawione przecięcie 100 |
| --- | --- |
| ![Liniowa linia trendu z automatycznie obliczonym przecięciem 140](intercept-automatic.png) | ![Liniowa linia trendu z ustawionym przecięciem 100](intercept-fixed.png) |

Oba obrazy używają tych samych danych i skal osi. Linie trendu są przedłużane do X = 0, aby pokazać ich przecięcia.

Domyślnie właściwość zawiera `std::numeric_limits<double>::quiet_NaN()`, co oznacza nieokreślone przecięcie, a nie zero. Przecięcie jest wtedy obliczane automatycznie na podstawie danych.

## **Dodaj własną linię**

Własna linia to kształt narysowany nad wykresem, a nie linia trendu obliczona na podstawie danych serii. Ten przykład używa [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) aby dodać poziomą linię do slajdu nad wykresem. Pozycja linii jest określona w współrzędnych slajdu, mierzonej w punktach, więc zaczyna się od lewej krawędzi wykresu i znajduje się w połowie wysokości wykresu. Jej szerokość odpowiada szerokości wykresu. Format linii zwrócony przez [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) nadaje linii jednolity czerwony kolor.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Co oznaczają „forward” i „backward” w kontekście linii trendu?**

Są to długości linii trendu projekowane do przodu lub do tyłu: dla wykresów punktowych (XY) – w jednostkach osi; dla wykresów innych niż punktowe – w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana podczas eksportu prezentacji do PDF lub SVG, lub przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/) lub [SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/) oraz renderuje wykresy do obrazów; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest także metoda do [eksportu obrazu wykresu](/slides/pl/cpp/shape-thumbnails/).