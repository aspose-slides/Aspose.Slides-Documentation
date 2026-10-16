---
title: Trendlijnen toevoegen aan presentatiegrafieken in C++
linktitle: Trendlijn
type: docs
url: /nl/cpp/trend-line/
keywords:
- grafiek
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdend gemiddelde trendlijn
- polynomiale trendlijn
- machttrendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Voeg snel trendlijnen toe en pas ze aan in PowerPoint‑grafieken met Aspose.Slides voor C++ — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe u trendlijnen aan presentatiesgrafieken kunt toevoegen met Aspose.Slides. Het laat zien hoe u een grafiek maakt, trendlijnen aan reeksen van de grafiek toevoegt en hoe u verschillende soorten trendlijnen gebruikt, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynomisch en macht.

Het beschrijft ook hoe u een aangepaste lijn aan een grafiek toevoegt door een lijnvorm in te voegen, en bevat een korte FAQ over de waarden voor projectie van trendlijnen naar voren en naar achteren en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het weergeven van grafieken als afbeeldingen.

## **Een trendlijn toevoegen**

Gebruik [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) om een trendlijn aan een grafiekreeks toe te voegen, waarbij u het type selecteert met [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). Het voorbeeld maakt een gegroepeerde kolomgrafiek met standaardgegevens en voegt twee trendlijnen toe aan elk van de drie reeksen.

De exponentiële trendlijn verbergt zijn vergelijking en R‑kwadraat‑waarde via [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) en [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/), terwijl de lineaire trendlijn rood is. De logaritmische trendlijn gebruikt [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) voor een aangepast label. Het voortschrijdend gemiddelde gebruikt [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) om drie datapunten te middelen en [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) voor een eigen naam.

De polynomische trendlijn gebruikt [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) om de graad op drie te zetten en strekt één categorie naar voren uit via [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). De macht‑trendlijn strekt één categorie naar achteren uit via [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

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

## **Een intercept voor een trendlijn instellen**

Gebruik [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) om de Y‑waarde van een trendlijn vast te zetten op X = 0. Deze instelling wordt ondersteund voor lineaire, exponentiële en polynomische trendlijnen.

Bijvoorbeeld, een kostenmodel voor productie moet mogelijk starten bij bekende vaste kosten van 100, zelfs wanneer metingen bij niet‑nul productievolumes een andere basislijn suggereren. Voor een lineaire trendlijn dwingt het vastzetten van de intercept de vergelijking `y = ax + b` tot `b = 100`; de helling wordt dan passend berekend onder deze beperking. Het verplaatst niet simpelweg een reeds passende lijn. Instellingen voor het kruisen van assen bepalen waar de assen elkaar ontmoeten, niet de coëfficiënten van de berekende trendlijn.

Het volgende voorbeeld maakt een spreidings‑ (XY‑)grafiek met productiemengden van 1 tot 4 en kosten van 170, 200, 230 en 260. Het slaat de grafiek op met de standaard automatische intercept, stelt de intercept in op 100 en slaat een tweede PPTX op. De twee bestanden verschillen alleen in de intercept‑instelling. De trendlijn toont zijn vergelijking en strekt terug tot X = 0.

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

Met automatische berekening leveren deze gegevens `y = 30x + 140`. Het instellen van de intercept op 100 levert ongeveer `y = 43.33x + 100`: de berekende waarde bij nul komt overeen met de bekende basislijn, terwijl de lijn niet langer door elk datapunt gaat.

| Automatische intercept | Vaste intercept van 100 |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

Beide afbeeldingen gebruiken dezelfde gegevens en as‑schalen. De trendlijnen zijn teruggestrekt tot X = 0 om hun intercepten te tonen.

Standaard bevat de eigenschap `std::numeric_limits<double>::quiet_NaN()`, wat een niet‑gespecificeerde intercept weergeeft in plaats van nul. De intercept wordt dan automatisch uit de gegevens berekend.

## **Een aangepaste lijn toevoegen**

Een aangepaste lijn is een vorm die over de grafiek wordt getekend in plaats van een trendlijn die uit reeksen wordt berekend. Dit voorbeeld gebruikt [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) om een horizontale lijn aan de dia boven de grafiek toe te voegen. De positie van de lijn wordt gespecificeerd in dia‑coördinaten, gemeten in punten, zodat hij begint bij de linkerrand van de grafiek en halverwege de grafiek langsloopt. De breedte komt overeen met de breedte van de grafiek. Het lijnformaat dat wordt geretourneerd door [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) geeft de lijn een solide rode kleur.

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

**Wat betekenen ‘forward’ en ‘backward’ voor een trendlijn?**

Het zijn de lengtes van de trendlijn die vooruit/achteruit worden geprojecteerd: voor spreidings‑ (XY‑)grafieken — in as‑eenheden; voor niet‑spreidingsgrafieken — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn bewaard bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/) of [SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/) en rendert grafieken naar afbeeldingen; trendlijnen, als onderdeel van de grafiek, blijven behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van de grafiek zelf te [exporteren](/slides/nl/cpp/shape-thumbnails/).