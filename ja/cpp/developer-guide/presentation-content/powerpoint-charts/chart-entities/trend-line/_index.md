---
title: C++ のプレゼンテーションチャートにトレンドラインを追加する
linktitle: トレンドライン
type: docs
url: /ja/cpp/trend-line/
keywords:
- チャート
- トレンドライン
- 指数トレンドライン
- 線形トレンドライン
- 対数トレンドライン
- 移動平均トレンドライン
- 多項式トレンドライン
- べき乗トレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides で PowerPoint のチャートにトレンドラインをすばやく追加・カスタマイズし、聴衆を惹きつける実践的ガイド。"
---
## **概要**

本記事では、Aspose.Slides を使用してプレゼンテーションのチャートにトレンドラインを追加する方法を説明します。チャートの作成方法、チャート系列へのトレンドラインの追加方法、および指数、線形、対数、移動平均、多項式、べき乗などの複数のトレンドラインタイプの使用方法を示します。

また、ラインシェイプを挿入してチャートにカスタムラインを追加する方法を説明し、前方および後方のトレンドライン投影値や、PDF や SVG へのエクスポート時、チャートを画像としてレンダリングする際にトレンドラインが保持されるかどうかに関する簡単な FAQ も掲載しています。

## **トレンドラインの追加**

チャート系列にトレンドラインを追加するには、[ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) を使用し、[TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/) でタイプを選択します。この例では、デフォルトデータを持つクラスター化された縦棒グラフを作成し、3 つの系列それぞれに 2 本のトレンドラインを追加します。

指数トレンドラインは、[ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) と [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/) を使用して式と決定係数 (R 二乗) を非表示にします。一方、線形トレンドラインは赤色です。対数トレンドラインは [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) を使用してカスタムラベルを設定します。移動平均は [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) で 3 つのデータポイントの平均を取り、[ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) でカスタム名を設定します。

多項式トレンドラインは [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) を使用して次数を 3 に設定し、[ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/) で 1 つのカテゴリを前方に拡張します。べき乗トレンドラインは [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/) で 1 つのカテゴリを後方に拡張します。

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

## **トレンドラインの切片を設定**

[ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) を使用して、X = 0 におけるトレンドラインの Y 値を固定します。この設定は線形、指数、および多項式トレンドラインでサポートされています。

たとえば、生産コストモデルは、非ゼロの生産量で測定した結果が別のベースラインを示唆していても、既知の固定費 100 から開始する必要がある場合があります。線形トレンドラインの場合、切片を固定すると方程式 `y = ax + b` が `b = 100` に制約され、傾きはその制約の下でデータに合わせて算出されます。これは既にフィットしたラインを単に移動させるだけではありません。軸交差設定はチャート軸が交わる位置を制御し、フィットしたトレンドラインの係数を変更するものではありません。

以下の例では、1〜4 の生産量とコスト 170、200、230、260 を持つ散布図 (XY) チャートを作成します。デフォルトの自動切片でチャートを保存し、切片を 100 に設定して 2 番目の PPTX を保存します。2 つのファイルは切片設定のみが異なります。トレンドラインは式を表示し、X = 0 まで後方に拡張します。

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

自動計算の場合、これらのデータは `y = 30x + 140` を生成します。切片を 100 に設定すると、おおよそ `y = 43.33x + 100` となります。ゼロでのフィット値が既知のベースラインに一致し、ラインはすべてのデータポイントを通らなくなります。

| 自動切片 | 切片 100 の固定 |
| --- | --- |
| ![自動計算された切片 140 の線形トレンドライン](intercept-automatic.png) | ![切片 100 に固定された線形トレンドライン](intercept-fixed.png) |

両方の画像は同じデータと軸スケールを使用しています。トレンドラインは切片を示すために X = 0 まで後方に拡張されています。

デフォルトでは、このプロパティは `std::numeric_limits<double>::quiet_NaN()` を含み、これはゼロではなく未指定の切片を表します。その後、切片はデータから自動的に計算されます。

## **カスタムラインの追加**

カスタムラインは、系列データから計算されたトレンドラインではなく、チャート上に描画されるシェイプです。この例では、[IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) を使用して、チャート上に水平線をスライドに追加します。ラインの位置はポイント単位のスライド座標で指定されるため、チャートの左端から開始し、チャートの高さの半分の位置に配置されます。幅はチャートの幅と同じです。[IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) が返すラインフォーマットにより、ラインは単色の赤色になります。

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

**トレンドラインの「前方」および「後方」は何を意味しますか？**

これはトレンドラインを前方または後方に投影した長さを示します。散布図 (XY) の場合は軸単位、非散布図の場合はカテゴリ数で表されます。0 以上の値のみが許可されます。

**プレゼンテーションを PDF や SVG にエクスポートしたり、スライドを画像としてレンダリングしたりするときに、トレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) または [SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。これらの操作中に、チャートの一部であるトレンドラインは保持されます。また、チャート自体の [チャートの画像をエクスポート](/slides/ja/cpp/shape-thumbnails/) するメソッドも利用可能です。