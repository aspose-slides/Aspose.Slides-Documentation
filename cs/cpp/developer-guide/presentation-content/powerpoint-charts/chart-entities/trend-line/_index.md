---
title: Přidání trendových čar do grafů v prezentaci v C++
linktitle: Trendová čára
type: docs
url: /cs/cpp/trend-line/
keywords:
- graf
- trendová čára
- exponenciální trendová čára
- lineární trendová čára
- logaritmická trendová čára
- trendová čára s klouzavým průměrem
- polynomická trendová čára
- mocninová trendová čára
- vlastní trendová čára
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte trendové čáry v grafech PowerPointu pomocí Aspose.Slides pro C++ — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do grafů v prezentaci trendové čáry. Ukazuje, jak vytvořit graf, přidat trendové čáry k sériím grafu a pracovat s několika typy trendových čar, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomické a mocninové.

Dále popisuje, jak přidat do grafu vlastní čáru vložením tvaru čáry, a obsahuje krátkou Často kladené otázky (FAQ) o hodnotách projekce trendové čáry dopředu a dozadu a o tom, zda jsou trendové čáry zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázků.

## **Přidání trendové čáry**

Použijte [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) k přidání trendové čáry do série grafu, přičemž její typ vyberete pomocí [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). Příklad vytvoří seskupený sloupcový graf s výchozími daty a přidá dvě trendové čáry ke každé ze svých tří sérií.

Exponenciální trendová čára skryje svou rovnici a hodnotu R‑krychle pomocí [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) a [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/), zatímco lineární trendová čára je červená. Logaritmická trendová čára používá [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) pro vlastní popisek. Klouzavý průměr používá [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) k průměrování tří datových bodů a [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) pro vlastní název.

Polynomická trendová čára používá [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) k nastavení stupně na tři a rozšiřuje o jednu kategorii dopředu pomocí [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). Mocninová trendová čára rozšiřuje o jednu kategorii dozadu pomocí [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

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

## **Nastavení průsečíku trendové čáry**

Použijte [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) k fixaci hodnoty Y trendové čáry při X = 0. Toto nastavení je podporováno pro lineární, exponenciální a polynomické trendové čáry.

Například model nákladů na výrobu může potřebovat začít s známými fixními náklady ve výši 100, i když měření při nenulových objemech výroby naznačují jiný výchozí stav. Pro lineární trendovou čáru fixace průsečíku omezuje rovnici `y = ax + b` na `b = 100`; sklon je přizpůsoben datům pod tímto omezením. Nejde jen o posunutí již přizpůsobené čáry. Nastavení průsečíku os určuje, kde se osy grafu protínají, nikoli koeficienty přizpůsobené trendové čáry.

Následující příklad vytvoří rozptylový (XY) graf s objemy výroby od 1 do 4 a náklady 170, 200, 230 a 260. Uloží graf s výchozím automatickým průsečím, nastaví průsečík na 100 a uloží druhý soubor PPTX. Tyto dva soubory se liší pouze nastavením průsečíku. Trendová čára zobrazuje svou rovnici a rozšiřuje se zpět na X = 0.

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

Při automatickém výpočtu tato data dávají `y = 30x + 140`. Nastavením průsečíku na 100 vznikne přibližně `y = 43.33x + 100`: hodnota při nule odpovídá známému výchozímu stavu, zatímco čára již neprochází všemi datovými body.

| Automatický průsečík | Fixní průsečík 100 |
| --- | --- |
| ![Lineární trendová čára s automaticky vypočteným průsečíkem 140](intercept-automatic.png) | ![Lineární trendová čára s fixním průsečíkem 100](intercept-fixed.png) |

Oba obrázky používají stejná data a měřítka os. Trendové čáry jsou rozšířeny zpět na X = 0, aby ukázaly své průsečíky.

Ve výchozím nastavení obsahuje vlastnost hodnotu `std::numeric_limits<double>::quiet_NaN()`, která představuje nespecifikovaný průsečík namísto nuly. Průsečík je pak automaticky vypočten z dat.

## **Přidání vlastní čáry**

Vlastní čára je tvar nakreslený přes graf, nikoli trendová čára vypočítaná ze sériových dat. Tento příklad používá [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) k přidání horizontální čáry do snímku přes graf. Pozice čáry je zadána ve souřadnicích snímku, měřených v bodech, takže začíná na levém okraji grafu a leží v polovině výšky grafu. Její šířka odpovídá šířce grafu. Formát čáry vrácený metodou [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) dává čáře plnou červenou barvu.

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

## **Často kladené otázky**

**Co znamenají ‘forward’ a ‘backward’ pro trendovou čáru?**

Jedná se o délky trendové čáry promítnuté dopředu/dozadu: pro rozptylové (XY) grafy — v jednotkách osy; pro jiné grafy — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Bude trendová čára zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/) nebo [SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/) a vykresluje grafy do obrázků; trendové čáry, jako součást grafu, jsou během těchto operací zachovány. K dispozici je také metoda k [exportovat obrázek grafu](/slides/cs/cpp/shape-thumbnails/).