---
title: C++에서 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/cpp/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 거듭제곱 추세선
- 사용자 정의 추세선
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 사용자 정의하세요 — 청중을 사로잡는 실용적인 가이드."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 생성하고 차트 시리즈에 추세선을 추가하며, 지수, 선형, 로그, 이동 평균, 다항식 및 거듭제곱 등 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 선 모양을 삽입하여 차트에 사용자 정의 선을 추가하는 방법을 설명하고, 앞·뒤 추세선 투영값과 PDF 또는 SVG로 내보낼 때 또는 차트를 이미지로 렌더링할 때 추세선이 유지되는지에 대한 간단한 FAQ를 포함합니다.

## **추세선 추가**

[ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/)을 사용하여 차트 시리즈에 추세선을 추가하고, [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/)으로 유형을 선택합니다. 예제에서는 기본 데이터가 있는 클러스터형 세로 막대 차트를 만들고 각 세 개의 시리즈에 두 개의 추세선을 추가합니다.

지수 추세선은 [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) 및 [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/)를 통해 방정식과 R-제곱 값을 숨기고, 선형 추세선은 빨간색으로 표시됩니다. 로그 추세선은 [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/)을 사용하여 사용자 정의 레이블을 지정합니다. 이동 평균은 [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/)를 사용해 세 데이터 포인트를 평균하고, [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/)으로 사용자 정의 이름을 설정합니다.

다항식 추세선은 [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/)를 사용해 차수를 세 개로 설정하고, [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/)를 통해 한 카테고리 앞쪽으로 연장합니다. 거듭제곱 추세선은 [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/)를 사용해 한 카테고리 뒤쪽으로 연장합니다.

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

## **추세선 절편 설정**

[ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/)을 사용하여 X = 0에서 추세선의 Y 값을 고정합니다. 이 설정은 선형, 지수 및 다항식 추세선에 대해 지원됩니다.

예를 들어, 생산 비용 모델에서 측정값이 다른 기준선을 제시하더라도 100이라는 알려진 고정 비용에서 시작해야 할 수 있습니다. 선형 추세선의 경우 절편을 고정하면 방정식 `y = ax + b`가 `b = 100`으로 제한되고, 기울기는 해당 제한 하에서 데이터에 맞추어집니다. 이는 이미 맞춰진 선을 단순히 이동시키는 것이 아닙니다. 축 교차 설정은 차트 축이 만나는 위치를 제어할 뿐, 맞춰진 추세선의 계수를 변경하지 않습니다.

다음 예제는 생산량이 1~4이고 비용이 170, 200, 230, 260인 산점도(XY) 차트를 생성합니다. 기본 자동 절편으로 차트를 저장한 뒤, 절편을 100으로 설정하고 두 번째 PPTX 파일을 저장합니다. 두 파일은 절편 설정만 다릅니다. 추세선은 방정식을 표시하고 X = 0까지 뒤로 연장됩니다.

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

자동 계산 시, 이 데이터는 `y = 30x + 140`을 생성합니다. 절편을 100으로 설정하면 대략 `y = 43.33x + 100`이 됩니다. 즉, 영점에서의 맞춰진 값이 알려진 기준선과 일치하지만, 선은 더 이상 모든 데이터 포인트를 통과하지 않습니다.

| 자동 절편 | 절편 100 고정 |
| --- | --- |
| ![자동으로 계산된 절편 140을 가진 선형 추세선](intercept-automatic.png) | ![절편 100으로 고정된 선형 추세선](intercept-fixed.png) |

두 이미지 모두 동일한 데이터와 축 눈금을 사용합니다. 추세선은 절편을 보여주기 위해 X = 0까지 뒤로 연장되었습니다.

기본값으로 이 속성은 `std::numeric_limits<double>::quiet_NaN()`을 포함하며, 이는 절편이 지정되지 않았음을 의미하고 0이 아닙니다. 그런 경우 절편은 데이터에서 자동으로 계산됩니다.

## **사용자 정의 선 추가**

사용자 정의 선은 시리즈 데이터에서 계산된 추세선이 아니라 차트 위에 그려지는 도형입니다. 이 예제에서는 [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/)을 사용하여 차트 위에 가로선을 추가합니다. 선의 위치는 포인트 단위의 슬라이드 좌표로 지정되며, 차트 왼쪽 가장자리에서 시작해 차트 중간 높이에 배치됩니다. 선의 너비는 차트 전체 너비와 일치합니다. [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/)이 반환하는 선 형식으로 선에 단색 빨간색을 적용합니다.

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

**‘앞쪽’과 ‘뒤쪽’은 추세선에서 무엇을 의미합니까?**

추세선을 앞쪽 또는 뒤쪽으로 투영한 길이입니다. 산점도(XY) 차트에서는 축 단위로, 비산점도 차트에서는 카테고리 수로 표시됩니다. 음수 값은 허용되지 않습니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 유지됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/) 또는 [SVG](/slides/ko/cpp/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다; 차트의 일부인 추세선은 이러한 작업 중에 유지됩니다. 차트 자체의 이미지를 [내보내는](/slides/ko/cpp/shape-thumbnails/) 메서드도 제공됩니다.