---
title: C++를 사용한 프레젠테이션에서 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/cpp/chart-series/
keywords:
- 차트 시리즈
- 시리즈 겹침
- 시리즈 색상
- 카테고리 색상
- 시리즈 이름
- 데이터 포인트
- 시리즈 간격
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 폭 및 음수 값을 관리하는 방법을 배우세요."
---
## **개요**

차트는 플롯된 값을 워크북 셀에 저장하거나 직접 숫자 리터럴로 저장할 수 있습니다. [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/)은 관련 값 집합을 나타내고, 각 [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/)은 해당 시리즈의 포인트를 나타냅니다. [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 기본 데이터로 생성된 차트에서는 시리즈 이름, 카테고리 및 포인트 값이 차트 워크북의 [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/) 객체를 사용합니다.

일반적인 카테고리 차트에서는 기본 워크북이 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고, 나머지 셀을 시리즈 값에 사용합니다. [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용해 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정해서는 안 됩니다. 로드된 프레젠테이션의 경우 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하십시오.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정은 [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/)와 같이 하나의 시리즈에 있는 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정은 [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/)와 같이 특정 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 때는 [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/)을 통해 그룹에 접근하십시오.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 포맷이 모두 존재하면 포인트 포맷이 해당 포인트에 대해 우선됩니다.

![차트 시리즈 파워포인트](chart-series-powerpoint.png)

## **숫자 리터럴을 사용하여 시리즈 값 설정**

시리즈 값이 애플리케이션 데이터나 계산 결과에서 나오고 워크시트 셀 참조가 필요하지 않을 때 숫자 리터럴을 사용하십시오. 각 포인트의 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_value/)에서 반환된 값을 [set_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/set_asliteraldouble/)에 할당하기 전에 [set_DataSourceTypeForValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforvalues/)를 [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/)와 함께 호출하십시오.

컬렉션 설정은 해당 시리즈에 포함된 모든 포인트 값의 원본 유형을 제어합니다. 각 포인트의 [IBaseChartValue::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ibasechartvalue/get_datasourcetype/)는 선택된 유형을 보고합니다; 컬렉션 설정을 통해 변경하십시오. `Worksheet`를 사용할 경우 [get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/isinglecellchartvalue/get_ascell/)을 사용해 참조된 셀에 접근합니다. `DoubleLiterals`를 사용할 경우 [get_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/get_asliteraldouble/)이나 `set_AsLiteralDouble`을 사용해 숫자를 직접 읽거나 씁니다.

다음 예제는 기본 시리즈와 카테고리를 가진 열 차트를 만든 후 첫 번째 시리즈의 기존 포인트에 10, 20 등으로 계산된 값을 할당합니다. 프레젠테이션을 저장하고 다시 열어 저장된 값을 출력합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

series->get_DataPoints()->set_DataSourceTypeForValues(DataSourceType::DoubleLiterals);
for (auto i = 0; i < series->get_DataPoints()->get_Count(); i++)
{
    series->get_DataPoints()->idx_get(i)->get_Value()->set_AsLiteralDouble((i + 1) * 10);
}

presentation->Save(u"numeric_literals.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"numeric_literals.pptx");
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedChart = ExplicitCast<IChart>(reopenedSlide->get_Shape(0));
auto reopenedSeries = reopenedChart->get_ChartData()->get_Series()->idx_get(0);
for (auto i = 0; i < reopenedSeries->get_DataPoints()->get_Count(); i++)
{
    auto point = reopenedSeries->get_DataPoints()->idx_get(i);
    Console::WriteLine(point->get_Value()->get_AsLiteralDouble());
}
reopenedPresentation->Dispose();
```

포인트 값 원본 유형은 차트의 내부 또는 외부 워크북 구성을 식별하는 [IChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_datasourcetype/)와 별개입니다. 숫자 리터럴을 사용한다고 해서 워크북 자체가 제거되는 것은 아닙니다. 이 예제에서는 워크북이 카테고리 레이블, 시리즈 이름 및 다른 시리즈에 계속 사용됩니다. 워크북 관리에 대해서는 [Chart Workbook](/slides/ko/cpp/chart-workbook/)를 참조하십시오.

산점도 및 버블 차트의 경우 [set_DataSourceTypeForXValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforxvalues/)와 [set_DataSourceTypeForYValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforyvalues/)를 호출해 각각 [get_XValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_xvalue/)와 [get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/)의 원본을 선택합니다. 버블 차트는 또한 [set_DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforbubblesizes/)를 사용해 [get_BubbleSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_bubblesize/)의 원본을 지정합니다. 해당 값을 `set_AsLiteralDouble` 메서드로 할당하기 전에 각 적용 가능한 원본을 `DoubleLiterals`로 설정하십시오.

## **차트 시리즈 겹침 설정**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/)은 2D 차트에서 막대나 열이 겹치는 정도를 -100에서 100 퍼센트까지 보고합니다. 이는 상위 시리즈 그룹에 대한 설정을 읽기 전용으로 투영한 값입니다. 해당 그룹에 포함된 모든 호환 시리즈를 업데이트하려면 [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/)를 호출하십시오. 이 옵션은 그룹화된 막대 또는 열을 표시하는 차트 유형에 적용되며, 콤비네이션 차트의 다른 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다.

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// 새 차트에는 샘플 시리즈, 카테고리 및 값이 포함됩니다.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

[IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/)을 사용해 전체 시리즈의 기본 채우기를 설정합니다. 포인트에 명시적인 채우기가 이미 있으면 해당 포인트의 [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![시리즈 색상](series_color.png)

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 열 차트를 위한 기본 워크북에서는 셀 B1이 행 0, 열 1에 위치하며 첫 번째 시리즈 이름을 포함합니다. 아래 예제의 명명된 상수는 해당 구조를 명시적으로 보여줍니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

또한 [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/)이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하지 않으므로 안전합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![시리즈 이름](series_name.png)

### **여러 셀에서 이름을 가져와 시리즈 만들기**

제품 이름과 보고 기간이 별개의 워크북 셀에 저장된 경우 복합 시리즈 이름이 유용합니다. 예를 들어 B1에 `Product A`가, C1에 `2026`이 저장되어 있다면 두 값을 결합해 하나의 시리즈 이름으로 만들면서 두 부분이 각각의 원본 셀에 연결된 상태를 유지할 수 있습니다.

[IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/)을 사용해 이름 범위를 가져온 뒤 해당 컬렉션을 [IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/)에 전달합니다. `skipHiddenCells` 인수는 숨겨진 셀을 포함할지 여부를 제어합니다: `true`이면 제외하고, `false`이면 포함합니다. 이 예제에서는 `false`를 사용해 이름 범위의 모든 셀을 포함합니다.

다음 예제는 하나의 시리즈와 두 개의 데이터 포인트를 가진 프레젠테이션을 생성합니다. 셀 B1:C1은 시리즈 이름만 제공하고, A2:A3은 카테고리 레이블을, B2:B3은 숫자 값을 제공합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 620.0f, 180.0f);
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
chart->set_HasLegend(true);

auto workbook = chartData->get_ChartDataWorkbook();
workbook->Clear(0);

// 이 두 셀은 시리즈 이름을 제공합니다.
auto productName = ObjectExt::Box<String>(u"Product A");
auto reportingPeriod = ObjectExt::Box<String>(u"2026");
workbook->GetCell(0, 0, 1, productName);
workbook->GetCell(0, 0, 2, reportingPeriod);
auto nameCells = workbook->GetCellCollection(u"Sheet1!$B$1:$C$1", false);
auto series = chartData->get_Series()->Add(nameCells, ChartType::ClusteredColumn);

// 별도의 셀은 카테고리와 숫자 데이터 포인트를 제공합니다.
auto northLabel = ObjectExt::Box<String>(u"North");
auto southLabel = ObjectExt::Box<String>(u"South");
auto northCategory = workbook->GetCell(0, 1, 0, northLabel);
auto southCategory = workbook->GetCell(0, 2, 0, southLabel);
chartData->get_Categories()->Add(northCategory);
chartData->get_Categories()->Add(southCategory);
auto northAmount = ObjectExt::Box<int>(120);
auto southAmount = ObjectExt::Box<int>(150);
auto northValue = workbook->GetCell(0, 1, 1, northAmount);
auto southValue = workbook->GetCell(0, 2, 1, southAmount);
series->get_DataPoints()->AddDataPointForBarSeries(northValue);
series->get_DataPoints()->AddDataPointForBarSeries(southValue);

presentation->Save(u"composite_series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과 시리즈 이름은 `Product A 2026`이며 두 셀 값 사이에 공백이 포함됩니다. 범례에는 두 열이 하나의 항목으로 표시됩니다. 아래 이미지는 결과를 보여줍니다:

![North와 South 값 및 복합 시리즈 이름 Product A 2026이 범례에 표시된 열 차트](composite_series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/)은 시리즈 인덱스와 차트 스타일에서 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상을 읽을 수 있지만 새로운 채우기를 지정하지는 않습니다.

다음 예제는 각 기본 시리즈의 자동 색상을 출력합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

기본 차트 스타일에 대한 예시 출력:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

정확한 색상은 차트 스타일 및 테마에 따라 달라집니다.

## **시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우 [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/)를 사용해 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤 [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/)를 통해 음수 값 색상을 지정하십시오. 음수 값 자체는 워크북에서 그대로 유지되며 표시 색상만 변경됩니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0에 시리즈 이름이, 열 0에 카테고리 이름이, 열 1에 값이 포함됩니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![반전된 단색 채우기 색상](inverted_solid_fill_color.png)

포인트 수준에서 반전을 활성화하려면 [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/)를 사용하십시오. 아래 예제에서는 시리즈에 대한 반전을 비활성화하고 선택한 포인트에만 반전을 활성화합니다. 포인트에도 음수 값을 할당해 효과를 확인합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **특정 데이터 포인트 값 지우기**

다른 포인트를 제거하지 않고 하나의 포인트만 비우려면 해당 백업 워크북 셀을 `nullptr`로 설정하십시오. 열 차트에서는 플롯된 값이 [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/)를 통해 얻을 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만 차트는 해당 값을 빈 값으로 처리합니다(차트의 빈값 설정에 따름).

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 삭제합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

산점도 차트는 X와 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 사용합니다. 제거하려는 값에 해당하는 셀만 비우십시오. 다른 포인트를 유지하려면 [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/)를 호출하지 말아야 합니다. 해당 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **빈 셀 표시 제어**

값이 있는 숨겨진 셀은 빈 셀과 별개의 경우입니다. 숨겨진 워크시트 행·열의 데이터를 포함하거나 제외하려면 [Include Data from Hidden Rows and Columns](/slides/ko/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns)를 참조하십시오.

빈 워크북 셀은 누락된 데이터를 나타내며, `0`이 들어 있는 셀은 알려진 숫자 값을 나타냅니다. 셀을 빈 상태로 만들려면 `nullptr`와 함께 [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/)를 호출하십시오. 숫자 0은 빈 셀 설정에 관계없이 0으로 유지됩니다.

[IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/)를 사용해 차트가 빈 셀을 표시하는 방식을 선택하십시오. 이 설정은 차트 전체에 적용되며, 빈 셀을 0이나 보간값으로 채우지 않고 어떻게 플롯할지 결정합니다.

다음 자체 포함 예제는 하나의 시리즈가 있는 꺾은선 차트를 만들고, Day 3의 값을 지운 뒤 각 모드별로 차트를 저장합니다. 입력 파일이 필요하지 않습니다. [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/)은 워크시트 0, 열 0을 카테고리 레이블에, 열 1을 값에 사용하고, 행 0에 시리즈 이름을 둡니다. 최종 데이터는 `10, 20, empty, 30, 40`입니다.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Day 3을 실제로 비워 두고, 카테고리와 데이터 포인트는 그대로 유지합니다.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

각 출력 파일은 저장 전에 지정된 모드 이름을 포함합니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나의 버전만 저장하려면 원하는 모드를 할당하고 프레젠테이션을 한 번만 저장하면 됩니다.

아래 비교는 세 파일 모두에서 동일한 데이터를 보여줍니다. Day 3은 모든 경우 워크북에서 빈 셀입니다:

![Day 3이 빈 셀인 경우: Gap는 라인을 끊고, Zero는 라인을 0까지 내리며, Span은 Day 2와 Day 4를 연결합니다.](display_blanks_as.png)

보이는 효과는 차트 유형에 따라 다릅니다. 라인 차트에서는 세 모드를 모두 쉽게 비교할 수 있지만, 막대·열 차트는 누락된 카테고리를 연결할 라인이 없으므로 `Span`이 위와 같은 연결 구간을 만들 수 없습니다. 누락된 열과 0 높이 열도 비슷하게 보일 수 있습니다. 마커만 있는 산점도 차트 역시 연결 라인이 없습니다. 모든 차트 유형에서 세 가지 뚜렷한 결과가 나올 것이라고 기대하지 말고, 사용 중인 차트 유형에 대해 출력 결과를 확인하십시오.

## **시리즈 간격 폭 설정**

간격 폭은 인접한 막대·열 클러스터 사이의 공간을 막대·열 폭의 백분율로 나타낸 것입니다. 겹침과 마찬가지로 개별 시리즈가 아닌 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/)를 호출하십시오. 값이 클수록 클러스터 사이의 공간이 넓어지고, 값이 작을수록 더 촘촘해집니다.

다음 예제는 간격 폭을 변경하고 최종 프레젠테이션만 저장합니다.

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![간격 폭](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원합니까?**

[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 열거형에 포함된 모든 차트 유형이 차트 데이터를 사용하지만, 시리즈마다 값 구조나 설정이 동일하지 않을 수 있습니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하십시오. 겹침(overlap) 및 간격 폭(gap width)과 같은 옵션은 호환되는 막대·열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇입니까?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/)은 그룹 수준 플로팅 설정을 공유하는 호환 시리즈를 포함합니다. 콤비네이션 차트는 둘 이상의 그룹을 포함할 수 있으므로 하나의 시리즈를 통해 접근한 그룹을 변경해도 차트 내 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함됩니까?**

예. 기본적으로 [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/)는 샘플 시리즈, 카테고리 및 값을 생성합니다. 해당 셀을 편집하거나 완전히 사용자 지정된 데이터 세트를 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 비울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결됩니까?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 지정 데이터를 구성할 때는 각 포인트가 의도한 카테고리 아래에 플롯되도록 카테고리 행과 시리즈 값 행을 정렬하십시오.

**시리즈 전체가 아니라 하나의 포인트만 지우려면 어떻게 합니까?**

포인트의 값 셀을 `nullptr`로 설정해 해당 포인트를 빈 상태로 유지하면서 카테고리 위치는 그대로 유지합니다. 모든 포인트를 삭제하려는 경우에만 [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/)를 호출하십시오. 카테고리도 함께 제거한다면 모든 시리즈가 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시됩니까?**

결과는 차트 유형과 [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) 설정에 따라 달라집니다. 지원되는 차트는 빈 셀을 간격(gap), 0값(zero) 또는 인접 포인트 연결(span)으로 표시할 수 있습니다. 프레젠테이션의 누락 데이터 의미에 맞는 설정을 선택하십시오. 전체 예제와 시각적 비교는 [Control the Display of Empty Cells](#control-the-display-of-empty-cells)를 참고하십시오.

**음수 값은 어떻게 포맷됩니까?**

지원되는 막대·열·버블 시리즈의 경우 [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/)를 호출하고 [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/)를 통해 색상을 지정하십시오. 개별 포인트에 대해서는 [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/)로 동작을 재정의할 수 있습니다. 이 메서드들은 포맷에 영향을 주며 저장된 숫자 값 자체는 바뀌지 않습니다.

**시리즈와 포인트 모두 포맷된 경우 어느 것이 우선합니까?**

명시적인 데이터 포인트 포맷이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 포맷을 사용하거나, 시리즈 포맷이 정의되지 않은 경우 자동 차트 스타일 및 테마를 따릅니다. 겹침이나 간격 폭과 같은 그룹 설정은 레이아웃을 제어하며 포인트 수준 포맷을 재정의하지 않습니다.

**차트에 포함될 수 있는 시리즈 수에 제한이 있습니까?**

Aspose.Slides에는 별도의 고정 시리즈 수 제한이 없습니다. 실제 제한은 프레젠테이션 파일 제한, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성 등에 따라 결정됩니다.

**열이 너무 가깝거나 너무 멀리 떨어져 있을 때 어떻게 조정합니까?**

적절한 상위 시리즈 그룹에 대해 [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/)를 호출하십시오. 값을 늘리면 클러스터 사이의 공간이 넓어지고, 값을 줄이면 클러스터가 더 가까워집니다.