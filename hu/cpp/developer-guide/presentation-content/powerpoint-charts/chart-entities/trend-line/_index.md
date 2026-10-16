---
title: Trendvonalak hozzáadása prezentáció diagramokhoz C++-ban
linktitle: Trendvonal
type: docs
url: /hu/cpp/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint diagramokban az Aspose.Slides for C++ segítségével — egy gyakorlati útmutató, amely segít lekötni a közönséget."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk trendvonalakat a bemutató diagramokhoz az Aspose.Slides használatával. Megmutatja, hogyan hozzunk létre diagramot, hogyan adjunk trendvonalakat a diagram sorozataihoz, és a különböző trendvonal típusokkal dolgozzunk, beleértve az exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány típusúakat.

Leírja továbbá, hogyan adhatunk egy egyéni vonalat a diagramhoz egy vonal alakzat beszúrásával, valamint egy rövid GYIK-ot tartalmaz a trendvonal előre és hátra vetített értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e PDF vagy SVG export során és a diagramok képként történő megjelenítésekor.

## **Trendvonal hozzáadása**

Használja a [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) metódust trendvonal hozzáadásához egy diagram sorozathoz, a típus kiválasztásához a [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/) segítségét. Az példa egy alapértelmezett adatokkal rendelkező csoportosított oszlopdiagramot hoz létre, és minden három sorozatához két trendvonalat ad hozzá.

Az exponenciális trendvonal elrejti egyenletét és R-négyzet értékét a [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) és a [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/) segítségével, míg a lineáris trendvonal piros. A logaritmikus trendvonal a [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) használja egy egyedi címke létrehozásához. A mozgó átlag a [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) használja három adatpont átlagolásához, és a [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) egyedi névhez.

A polinomiális trendvonal a [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) segítségével állítja be a háromfokú fokszámot, és egy kategóriával előre nyúlik a [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). A hatvány trendvonal egy kategóriával hátra nyúlik a [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

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

## **Trendvonal metszéspont beállítása**

Használja a [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) metódust a trendvonal Y értékének X = 0-nál rögzítéséhez. Ez a beállítás támogatott lineáris, exponenciális és polinomiális trendvonalaknál.

Például egy termelési költség modellnek az ismert, 100 egységű fix költségnél kell kezdődnie, még akkor is, ha a nem nulla termelési mennyiségeknél mért értékek más alapvonalat sugallnak. Lineáris trendvonal esetén a metszéspont rögzítése a `y = ax + b` képletet `b = 100`‑ra korlátozza; a meredekség az adatokhoz illeszkedik ebben a feltételben. Ez nem egyszerűen csak áthelyezi a már illesztett vonalat. A tengelykereszteződés beállítások azt szabályozzák, hogy a diagram tengelyei hol találkoznak, nem a trendvonal illesztett együtthatóit.

Az alábbi példa egy szórt (XY) diagramot hoz létre 1‑től 4‑ig terjedő termelési mennyiségekkel és 170, 200, 230 és 260 költségekkel. A diagramot az alapértelmezett automatikus metszésponttal menti, beállítja a metszéspontot 100‑ra, és egy második PPTX‑et ment. A két fájl csak a metszéspont beállításban tér el. A trendvonal megjeleníti egyenletét, és visszanyúlik X = 0‑ig.

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

Automatikus számítás esetén ezek az adatok `y = 30x + 140` képletet adnak. A metszéspont 100‑ra állítása helyette körülbelül `y = 43.33x + 100` eredményt ad: a nulla értéknél illesztett érték megegyezik az ismert alapvonallal, míg a vonal már nem halad át minden adatponton.

| Automatikus metszéspont | 100-as rögzített metszéspont |
| --- | --- |
| ![Lineáris trendvonal automatikusan kiszámított 140-es metszésponttal](intercept-automatic.png) | ![Lineáris trendvonal 100-as rögzített metszésponttal](intercept-fixed.png) |

Mindkét kép ugyanazokat az adatokat és tengelyskálákat használja. A trendvonalak vissza vannak nyújtva X = 0‑ig, hogy mutassák a metszéspontjaikat.

Alapértelmezés szerint a tulajdonság `std::numeric_limits<double>::quiet_NaN()` értéket tartalmaz, ami nem meghatározott metszéspontot jelez, nem nullát. Ezután a metszéspontot automatikusan számítja ki az adatból.

## **Egyéni vonal hozzáadása**

Egy egyéni vonal egy a diagram felett rajzolt alakzat, nem a sorozat adatokból számított trendvonal. Ez a példa a [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) használja, hogy egy vízszintes vonalat adjunk a diára a diagram felett. A vonal pozíciója a dia koordinátáiban van megadva, pontokban mérve, így a diagram bal szélén kezdődik és a diagram magasságának felénél helyezkedik el. Szélessége megegyezik a diagram szélességével. A [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) által visszaadott vonalformátum szilárd piros színt ad a vonalnak.

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

## **GYIK**

**Mit jelent a 'forward' és a 'backward' egy trendvonal esetén?**

Ezek a trendvonal előre/hátra vetített hossza: szórt (XY) diagramoknál – tengelyegységekben; nem szórt diagramoknál – kategóriák számában. Csak nem negatív értékek engedélyezettek.

**Megmarad a trendvonal a prezentáció PDF vagy SVG formátumba exportálásakor, vagy diára történő képkénti rendereléskor?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/) vagy [SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak a diagram részét képezve megmaradnak ezek során. Egy metódus is elérhető a diagram képének [exportálása](/slides/hu/cpp/shape-thumbnails/) számára.