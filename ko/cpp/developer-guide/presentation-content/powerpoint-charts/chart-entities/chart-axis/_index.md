---
title: C++를 사용하여 프레젠테이션에서 차트 축을 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/cpp/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 사용자 지정
- 축 조작
- 축 관리
- 축 속성
- 최대값
- 최소값
- 축 선
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "보고서와 시각화를 위해 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Aspose.Slides for C++를 사용하는 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides for C++를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 서식 지정, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트에서 수직 축의 최대값 가져오기**

기본 데이터가 포함된 영역 차트를 추가하려면 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)을(를) 생성합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 유지하려면 [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/)을(를) 호출합니다.

축 한계값을 얻으려면 [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/)와 [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/)를 읽고, 눈금 간격을 위해 [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/)와 [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/)를 사용합니다. 날짜 축과 관련된 시간 단위 스케일은 [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/)와 [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/)이(가) 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **축 사이의 데이터 전환**

차트 데이터에서 시리즈와 범주의 역할을 교환하려면 [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/)을(를) 사용합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터가 그룹화되는 방식을 변경하지만, 수평 및 수직 축을 교환하지는 않습니다. 예제에서는 [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/)을(를) 사용하여 기본 데이터를 `Sheet1!A1:D5`에 바인딩하고(헤더 행 및 범주 열 포함) 행과 열을 전환하기 전에 수행합니다. 결과적으로 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **축의 플롯 순서 반전**

[set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/)를 사용하여 범주 축이나 값 축의 순서를 반전시킵니다. 예를 들어, 가로 막대 차트에서 프로젝트 단계가 워크시트와 동일한 순서인 위에서 아래(계획, 개발, 테스트)로 표시될 수 있습니다. 축을 반전하면 플롯 방향이 변경되지만, 워크시트 데이터를 정렬하거나 재배열하지는 않습니다. 반면에 [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/)은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈가 있는 가로 막대 차트를 생성합니다. 정상 순서, 반전된 범주, 반전된 값이라는 세 개의 슬라이드를 가진 프레젠테이션을 저장합니다. 각 사본은 동일한 데이터 집합을 사용하며, 각 사본마다 하나의 축만 반전됩니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// Slide 2: display the first category at the top.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Keep the horizontal value axis at the bottom.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Slide 3: reverse only the horizontal numeric scale.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

축을 반전하면 수직 축을 플롯의 반대쪽으로 이동할 수도 있습니다. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/)은 구성 중인 축과 다른 축이 교차하는 위치를 제어합니다. 슬라이드 2에서는 반전된 범주 축에 `Maximum`을 설정하여 수평 값 축을 하단에 유지합니다. 특정 교차점을 지정하려면 [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/)을(를) 사용하십시오. 방향을 변경할 때 교차 설정을 확인하세요, 특히 차트에 사용자 정의 교차점이 이미 있는 경우. 정상 플롯 방향을 복원하려면 `false`와 함께 `set_IsPlotOrderReversed`를 호출합니다; 교차 설정은 별개입니다.

| 정상 순서 (슬라이드 1) | 반전된 범주 (슬라이드 2) | 반전된 값 (슬라이드 3) |
| --- | --- | --- |
| ![수평 막대 차트 (정상 범주 및 값 축 순서)](axis-order-normal.png) | ![수평 막대 차트 (범주가 위에서 아래로 표시)](axis-order-categories-reversed.png) | ![수평 막대 차트 (값 축이 반전되고 오른쪽에 0)](axis-order-values-reversed.png) |
| 범주는 아래에서 위로 진행하고, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행합니다. 값과 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축이 오른쪽에 있는 0에서 교차합니다. |

## **라인 차트에서 수직 축 비활성화**

수직 축에 `false`와 함께 [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/)를 사용하여 축을 숨깁니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 수직 축을 숨긴 상태로 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **라인 차트에서 수평 축 비활성화**

수평 축에 `false`와 함께 [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/)를 사용하여 축을 숨깁니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 수평 축을 숨긴 상태로 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **범주 축 변경**

[set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/)을(를) 사용하여 날짜 또는 텍스트 범주 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 모양인 차트가 포함된 `ExistingChart.pptx`를 필요로 하며, 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 수평 축을 날짜 축으로 변경합니다. [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/)에 `false`를, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/)에 `1`을, [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/)에 월을 지정하면 주요 눈금이 한 달 간격으로 배치됩니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **범주 축 레이블 간격 제어**

차트에 많은 범주가 있을 때 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄입니다. [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/)에 `false`를 설정한 다음 원하는 범주 간격으로 [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/)을 사용합니다. 텍스트 범주의 정상 순서에서는 첫 번째 범주부터 카운트가 시작됩니다:

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | 범주 1, 범주 2, 범주 3, ... 범주 24 |
| `2` | 범주 1, 범주 3, 범주 5, ... 범주 23 |
| `3` | 범주 1, 범주 4, 범주 7, ... 범주 22 |

간격 `3`은 3번째 레이블마다 표시하고, 표시된 레이블 사이에 두 개의 레이블이 숨겨집니다. 이는 해당 열을 제거하지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금표시에도 별도 제어가 있습니다. [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/)에 `false`를 설정하고 [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/)을 사용하여 간격을 지정합니다. 예를 들어, `1`은 각 범주 간격마다 눈금표시를 유지하면서 레이블은 3번째 범주마다만 표시합니다. [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/)에 표시 가능한 스타일을 지정하여 결과를 확인할 수 있습니다. 자동 간격 속성을 `true`로 다시 설정하면 차트가 해당 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 범주와 하나의 시리즈를 생성한 뒤 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 독립적인 눈금표시가 있는 수동 레이블 간격, 그리고 복원된 자동 간격. 두 사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션이 필요 없습니다. 가로 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// Slide 2: show every third label, but keep a tick mark for every category.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: let the chart choose both intervals again.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 범주 레이블이 표시되어 두 줄로 넘깁니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![24개 열 모두 표시된 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째마다 레이블이 한 줄에 표시되고, 눈금표시는 모든 범주 간격에 유지됩니다. 레이블이 없는 열을 포함한 24개 전체 열이 동일한 값으로 표시됩니다. 슬라이드 3은 위의 자동 외관을 복원합니다.

![24개 열 모두 표시된 3 간격 수동 범주 레이블](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 열, 라인, 영역 또는 막대 차트의 범주 축)에 이 범주 수 간격을 사용합니다. 열 차트에서는 수평 축이 되고, 가로 막대 차트에서는 범주 축이 수직이므로 [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/)에 적용합니다. 눈금표시 간격은 시리즈 축이 있는 차트에서도 적용됩니다.

범주 레이블 간격을 값 축의 숫자 스케일을 설정하는 데 사용하지 마십시오. 값 축에서는 [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/)이 값 차이를 지정합니다: 예를 들어, 주요 단위가 `10`이면 축이 0에서 시작할 때 0, 10, 20 등이 눈금으로 표시됩니다. `3`의 범주 레이블 간격은 데이터 값에 관계없이 범주 위치를 셉니다. 산점도와 버블 차트는 텍스트 범주 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [범주 축 변경](#change-a-category-axis)에서 설명한 바와 같이 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값에 대한 날짜 형식 설정**

예제에서는 기본 차트 데이터를 4개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장됩니다. 날짜 축을 선택하려면 [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/)을 사용하고, [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/)으로 소스 연결 서식을 해제한 뒤, [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/)에 `yyyy`를 할당하여 셀 서식과 무관하게 범주 레이블이 네 자리 연도로 표시되게 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **차트 축 제목 회전 각도 설정**

[set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/)으로 수직 축 제목을 활성화하고 제목 텍스트를 제공한 뒤, [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/)을 사용하여 제목을 회전시킵니다. 각도는 도 단위이며, 이 예제에서는 값 축 제목을 90도 회전한 열 차트를 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **범주 또는 값 축의 축 위치 설정**

[set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/)을 사용하여 값 축이 범주 축을 범주 사이에서 교차할지 범주 눈금에서 교차할지 제어합니다. 이 속성은 범주 축에 적용됩니다. 예제에서는 열 차트의 수평 범주 축에 `true`로 설정하고 결과를 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **차트 값 축에 표시 단위 설정**

[set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/)을 사용하여 기본 데이터를 변경하지 않고 값 축 레이블을 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/)을 `Millions`로 설정하면 60,000,000 값이 60으로 표시됩니다. 예제에서는 열 차트를 만들고 수직 축에 백만 표시 단위를 적용합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **로그 값 축 구성**

양의 값이 여러 자릿수에 걸쳐 있을 때 로그 값 축이 유용합니다. 예를 들어, 서비스가 5개 기간에 걸쳐 10, 100, 1,000, 10,000, 100,000 요청을 받을 수 있습니다. 선형 스케일에서는 작은 값이 0에 가깝게 몰려 보입니다. 로그 스케일은 상대적 성장 비교를 쉽게 해주며, 같은 거리는 동일한 비율을 나타냅니다.

값 축에 `true`와 함께 [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/)을 호출하고 [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/)으로 기준을 선택합니다. 이는 기존 값의 표시 방식을 변경하지만 데이터 자체를 변경하거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 관계를 나타내는 별도 기능입니다.

### **값 축 및 기준 선택**

라인 또는 열 차트에서는 값 축이 [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/)입니다. 가로 막대 차트에서는 [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/)가 값 축입니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X 값에는 수평 축, Y 값에는 수직 축, 혹은 두 축을 모두 선택합니다. 범주 축에 로그 스케일을 적용하지 마십시오.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 기준을 사용할 수 있으며, `2.5`와 같은 소수 기준도 지원됩니다. 기준 `10`을 사용할 경우 10, 100, 1,000, 10,000과 같은 연속적인 거듭 제곱이 동일한 간격을 가집니다.

### **선형 및 로그 스케일링 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 5개의 요청 수를 가진 라인 차트를 만들고, 해당 슬라이드를 복제한 뒤 두 번째 슬라이드에 기준 10 로그 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// 첫 번째 슬라이드는 선형으로 유지하고 복사본의 값 축 스케일만 변경합니다.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**선형 스케일 (슬라이드 1):** 같은 수직 거리는 요청 수의 동일한 차이를 나타냅니다. 가장 큰 값이 차트를 압도해 작은 값들을 구분하기 어렵게 합니다.

![선형 값 축에 5개 요청 수가 표시된 PowerPoint 라인 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 같은 수직 거리는 동일한 비율을 나타냅니다. 각 기간의 요청 수는 이전 기간보다 10배이므로 점들이 기준 10 스케일에서 직선으로 상승합니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![기준 10 로그 값 축에 같은 5개 요청 수가 표시된 PowerPoint](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 사용 전에 데이터를 확인하십시오. 0 또는 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 분석에 해당 값을 제외하는 것이 적절하면 그 이유를 설명하십시오. 작은 양수로 조용히 대체하지 마십시오; 이는 데이터 의미를 바꿉니다. 로그 축에 수동으로 설정한 최소값이나 최대값도 양수이어야 합니다.

## **FAQ**

**하나의 축이 다른 축과 교차하는 값(축 교차)을 어떻게 설정합니까?**

[set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/)을 사용하여 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/)을 사용하십시오; 이러한 설정을 통해 축 교차를 적절한 기준선으로 이동할 수 있습니다.

**축에 대한 눈금 레이블 위치를 어떻게 지정합니까?**

[set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/)에 [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/)의 값(`Low`, `High`, `NextTo`, `None`)을 지정합니다. 눈금 자체를 제어하려면 [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) 또는 [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/)을 사용하십시오; 이는 레이블 위치와 별개입니다.