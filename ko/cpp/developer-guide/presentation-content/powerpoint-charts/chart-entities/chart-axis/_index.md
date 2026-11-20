---
title: C++를 사용하여 프레젠테이션에서 차트 축 사용자 지정
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
- 축선
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 Aspose.Slides for C++를 사용하여 차트 축을 사용자 지정하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides for C++를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행 및 열 전환, 축 표시 여부, 카테고리 레이블 및 눈금 간격, 날짜 카테고리 및 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트의 수직 축에서 최대값 가져오기**

기본 데이터가 포함된 영역 차트를 추가하기 위해 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)을 생성합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 유지하기 위해 [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/)을 호출합니다.

축 한계값을 얻으려면 [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/)와 [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/)을 읽고, 눈금 간격을 얻으려면 [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/)와 [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/)을 사용합니다. 날짜 축과 관련된 시간 단위 스케일을 제공하는 [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/)와 [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/)도 사용할 수 있습니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

## **축 간 데이터 교환**

[SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/)을 사용하여 차트 데이터에서 계열과 범주의 역할을 교환합니다. 이전의 각 범주는 계열이 되고, 이전의 각 계열은 범주가 됩니다. 이는 데이터가 그룹화되는 방식을 변경하지만 수평 및 수직 축을 교환하는 것은 아닙니다. 예제에서는 [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/)을 사용해 기본 데이터를 `Sheet1!A1:D5`에 바인딩하고(헤더 행 및 범주 열 포함) 행과 열을 전환한 후 차트를 저장합니다. 네 개의 계열과 세 개의 범주가 포함된 차트를 저장합니다.

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

## **축의 플로팅 순서 역전**

[set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/)을 사용하여 카테고리 축 또는 값 축의 순서를 역전시킵니다. 예를 들어, 가로 막대 차트에서 프로젝트 단계가 워크시트와 동일한 순서(계획, 개발, 테스트)로 위에서 아래로 표시될 수 있습니다. 축을 역전시키면 플로팅 방향이 바뀔 뿐, 워크북 데이터가 정렬되거나 재배열되지는 않습니다. 비교를 위해, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/)은 계열과 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 계열을 가진 가로 막대 차트를 만들고, 세 개의 슬라이드(일반 순서, 역전된 범주, 역전된 값)로 프레젠테이션을 저장합니다. 각 복사본은 동일한 데이터 세트를 사용하며, 각 복사본에서는 하나의 축만 역전됩니다.

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

축을 역전시키면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/)은 다른 축이 구성 중인 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 역전된 범주 축에 `Maximum`을 설정하여 수평 값 축이 하단에 유지되도록 합니다. 특정 교차 지점을 지정하려면 [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/)을 사용합니다. 방향을 변경할 때 교차 설정을 확인하십시오. 특히 차트에 사용자 지정 교차 지점이 이미 있는 경우에 중요합니다. `set_IsPlotOrderReversed`를 `false`로 호출하면 정상 플로팅 방향으로 복원됩니다; 교차 설정은 별도로 유지됩니다.

| 일반 순서 (슬라이드 1) | 역전된 범주 (슬라이드 2) | 역전된 값 (슬라이드 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| 범주가 아래에서 위로 진행하고, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행합니다. 값과 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽 영점에서 교차합니다. |

## **선형 차트에서 수직 축 비활성화**

수직 축에 `false`를 전달하여 [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/)를 호출하면 축을 숨길 수 있습니다. 예제에서는 기본 데이터를 가진 선형 차트를 만들고 수직 축을 숨긴 상태로 저장합니다.

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

## **선형 차트에서 수평 축 비활성화**

수평 축에 `false`를 전달하여 [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/)를 호출하면 축을 숨길 수 있습니다. 예제에서는 기본 데이터를 가진 선형 차트를 만들고 수평 축을 숨긴 상태로 저장합니다.

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

## **차트 눈금선 표시 또는 숨기기**

축이 표시하는 눈금선을 확인하려면 [get_ShowMajorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showmajorgridlines/)와 [get_ShowMinorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showminorgridlines/)을 사용합니다. 두 속성은 읽기 전용입니다. 보조 눈금선을 표시하려면 [get_MinorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_minorgridlinesformat/)을 사용하고 선 채우기를 실선이며 보이는 색으로 설정합니다. 숨기려면 채우기를 [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)으로 설정합니다. 주요 눈금선도 동일한 방식으로 [get_MajorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_majorgridlinesformat/)을 사용해 변경할 수 있습니다. 눈금선 채우기를 변경해도 축 표시와 눈금 표시가 보존됩니다.

이 클러스터형 세로 막대 차트의 수직 축은 처음에 주요 눈금선만 표시됩니다. 예제에서는 보조 눈금선을 주황색으로 표시한 뒤 다시 숨기고 프레젠테이션을 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
auto axis = chart->get_Axes()->get_VerticalAxis();
std::cout << std::boolalpha << "Initial: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

auto minorFill = axis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat();
minorFill->set_FillType(FillType::Solid);
minorFill->get_SolidFillColor()->set_Color(Color::get_DarkOrange());
std::cout << "Enabled: minor=" << axis->get_ShowMinorGridLines() << '\n';

minorFill->set_FillType(FillType::NoFill);
std::cout << "Hidden: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

presentation->Save(u"ChartGridlines.pptx", SaveFormat::Pptx);
```

| 보조 눈금선 표시 | 보조 눈금선 숨김 |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **범주 축 변경**

[set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/)을 사용하여 날짜 축이나 텍스트 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `ExistingChart.pptx`를 필요로 하며, 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 수평 축을 날짜 축으로 변경합니다. [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/)을 `false`로, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/)을 `1`로, [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/)을 `Months`로 설정하면 주요 눈금이 한 달 간격으로 배치됩니다.

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

### **데이터에서 범주 축 유형 자동 결정**

범주를 채운 후 [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/)를 호출하고, 이어서 [get_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_categoryaxistype/)를 호출해 선택된 유형을 확인합니다. 이 방법은 차트가 텍스트 레이블 또는 숫자형 날짜 값을 받을 때 유용합니다. 메서드는 호출 시점에 유형을 결정하며, 이후 데이터 변경에 대해 지속적으로 재평가되는 모드를 활성화하지 않습니다. 범주를 교체한 뒤 다시 호출하십시오.

다음 예제는 텍스트 범주가 있는 차트를 만든 뒤 `Text`를 출력합니다. 그런 다음 범주 셀 값을 날짜로 교체하고 메서드를 다시 호출해 `Date`를 출력합니다. 날짜는 [System::DateTime::ToOADate](https://reference.aspose.com/slides/cpp/system/datetime/tooadate/)가 반환하는 숫자형 OLE Automation 값으로 저장되며, 날짜 문자열이 아닙니다. [set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/)은 이러한 값이 표시되는 방식을 제어하지만, 텍스트를 숫자형 날짜로 변환하지는 않습니다. 범주 셀에 대한 자세한 내용은 [Chart Workbook](/slides/ko/cpp/chart-workbook/)를 참조하십시오.

입력에 텍스트 범주 또는 숫자형 날짜가 포함된 것이 알려진 경우 자동 결정을 사용하십시오. 일반적인 숫자 레이블, 혼합 범주 또는 빈 데이터의 경우 의도한 의미에 맞게 명시적으로 [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_categoryaxistype/)을 호출하십시오. 숫자 값만으로는 범주가 날짜임을 판단할 수 없습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/date_time.h>
#include <system/console.h>
#include <system/enum.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto seriesName = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());
auto labels = std::array<System::String, 3>{u"First", u"Second", u"Third"};

for (auto i = 0; i < labels.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(labels[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box((i + 1) * 10));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // 텍스트

auto dates = std::array<System::DateTime, 3>{System::DateTime(2026, 1, 1), System::DateTime(2026, 1, 2), System::DateTime(2026, 2, 1)};

for (auto i = 0; i < dates.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0);
    categoryCell->set_Value(System::ObjectExt::Box(dates[i].ToOADate()));
    categoryCell->set_CustomNumberFormat(u"yyyy-mm-dd");
}

axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // 날짜

presentation->Save(u"AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
```


## **범주 축 레이블 간격 제어**

차트에 많은 범주가 있을 때, 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/)을 `false`로 설정한 뒤, 원하는 범주 간격으로 [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/)을 지정합니다. 정상 순서의 텍스트 범주의 경우, 첫 번째 범주부터 계산이 시작됩니다:

| 간격 | 예제에서 표시된 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` 간격은 세 번째 레이블마다 하나씩 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 해당 열 자체는 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 선택되며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금표에도 별도 제어가 있습니다. [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/)을 `false`로 설정하고 [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/)으로 간격을 지정하십시오. 예를 들어, `1`은 모든 범주 간격마다 눈금표를 배치하지만 레이블은 매 3번째 범주에만 표시합니다. 눈금 모양을 보이게 하려면 [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/)을 사용하십시오. 자동 간격 속성을 `true`로 다시 설정하면 차트가 자동으로 간격을 선택합니다.

다음 자체 포함 예제는 24개의 범주와 하나의 계열을 만든 뒤 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 레이블 간격 수동(눈금표는 독립) 및 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션이 필요하지 않으며, 가로 레이블 텍스트가 밀도 차이를 쉽게 확인할 수 있게 합니다.

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

// 슬라이드 2: 모든 세 번째 레이블을 표시하되, 각 범주마다 눈금표는 유지합니다.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// 슬라이드 3: 차트가 두 간격을 다시 선택하도록 합니다.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 범주 레이블이 표시되고 두 줄로 줄 바꿈됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블만 한 줄에 표시되고, 눈금표는 모든 범주 간격에 유지됩니다. 레이블이 없는 모든 24개의 열도 동일한 값으로 보이며, 슬라이드 3에서는 자동 표시 형태가 복원됩니다.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **올바른 축과 간격 선택**

텍스트 범주 축(예: 열, 선, 영역 또는 막대 차트의 범주 축)에는 이 범주 개수 간격을 사용하십시오. 열 차트에서는 가로 축이며, 가로 막대 차트에서는 범주 축이 세로이므로 [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/)에 적용하십시오. 눈금표 간격은 계열 축이 있는 차트에도 적용됩니다.

값 축의 숫자 스케일을 설정하려면 범주 레이블 간격을 사용하지 마십시오. 값 축에서는 [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/)이 값 차이를 지정합니다(예: `10`은 0, 10, 20…처럼 표시). `3` 간격의 범주 레이블은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도와 버블 차트는 텍스트 범주 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [Change a Category Axis](#change-a-category-axis)에서 설명한 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제에서는 기본 차트 데이터를 연간 값 네 개로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장됩니다. [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/)으로 날짜 축을 선택하고, [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/)으로 셀 서식과 연결을 해제한 뒤, [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/)에 `yyyy`를 지정해 레이블이 셀 서식과 무관하게 4자리 연도로 표시되게 합니다.

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

[set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/)으로 수직 축 제목을 활성화하고 제목 텍스트를 제공한 뒤, [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/)을 사용해 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전한 채 열 차트를 저장합니다.

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

## **범주 축 또는 값 축에 대한 축 위치 설정**

[set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/)을 사용하면 값 축이 범주 축과 교차할 위치를 범주 사이 또는 범주 눈금표에 지정할 수 있습니다. 이 속성은 범주 축에 적용됩니다. 예제는 열 차트의 가로 범주 축에 `true`를 설정하고 결과를 저장합니다.

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

## **값 축에 표시 단위 설정**

[set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/)을 사용하면 기본 데이터를 변경하지 않고 값 축 레이블을 스케일링할 수 있습니다. [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/)을 `Millions`로 설정하면 60,000,000 값이 60으로 표시됩니다. 예제는 열 차트를 만든 뒤 수직 축에 백만 표시 단위를 적용합니다.

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

## **로그 스케일 값 축 구성**

양의 값이 여러 자릿수에 걸쳐 있을 때 로그 값 축이 유용합니다. 예를 들어, 서비스가 5개 기간 동안 10, 100, 1,000, 10,000, 100,000 요청을 받는 경우를 생각해 보십시오. 선형 스케일에서는 작은 값이 0 근처에 모여 보입니다. 로그 스케일은 비율을 기준으로 거리를 동일하게 만들어 증가를 비교하기 쉽게 합니다: 동일한 거리 = 동일한 비율, 동일한 차이와는 다릅니다.

값 축에 `true`를 전달해 [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/)을 호출하고, [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/)으로 기준을 선택합니다. 이는 기존 값의 표시 방식을 변경하지만 데이터 자체를 바꾸거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 별도 기능입니다.

### **값 축과 기준 선택**

선형 또는 열 차트에서는 값 축이 [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/)입니다. 가로 막대 차트에서는 [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/)가 값 축입니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X 값은 가로 축, Y 값은 세로 축에 적용하거나 둘 다 적용합니다. 범주 축에 로그 스케일을 적용하지 마십시오.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 범위의 기준을 사용할 수 있으며, `2.5`와 같은 소수 기준도 지원됩니다. 기준이 `10`이면 10, 100, 1,000, 10,000 등이 동일 간격으로 배치됩니다.

### **선형과 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 5개 요청 수를 가진 선형 차트를 만든 뒤, 두 번째 슬라이드를 복제하고 기준 10의 로그 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

**선형 스케일 (슬라이드 1):** 동일한 수직 거리는 요청 수 차이를 나타냅니다. 가장 큰 값이 차트를 압도해 작은 값이 구별하기 어렵습니다.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리는 동일한 비율을 나타냅니다. 각 기간의 요청 수가 이전보다 10배씩 증가하므로, 기준 10 로그 스케일에서는 점들이 직선으로 상승합니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 사용 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 분석에 따라 해당 값을 제외하는 것이 적절하다면 그 이유를 설명하십시오. 작은 양수로 대체하면 데이터 의미가 바뀌므로 조용히 대체하지 마십시오. 로그 축에 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**축이 다른 축을 교차하는 위치(축 교차)를 어떻게 설정하나요?**

[set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/)을 사용해 교차 동작을 선택하십시오. 숫자형 교차 값을 지정하려면 [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/)을 사용합니다. 이러한 설정으로 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 배치하나요?**

[set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/)를 사용하고, [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) 중 `Low`, `High`, `NextTo`, `None` 중 하나를 선택하십시오. 눈금표 자체를 제어하려면 [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) 또는 [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/)을 사용하십시오; 이는 레이블 배치와는 별개입니다.