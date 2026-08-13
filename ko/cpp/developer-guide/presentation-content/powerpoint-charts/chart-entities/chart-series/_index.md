---
title: C++에서 프레젠테이션의 차트 데이터 시리즈 관리
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
description: "C++를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 너비 및 음수 값을 관리하는 방법을 배웁니다."
---
## **개요**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [IChartSeries](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/)는 관련 값 한 세트를 나타내며, 시리즈에 있는 각 [IChartDataPoint](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/)은 하나 이상의 워크북 셀을 참조합니다. [IChartCategory](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartcategory/) 개체는 시리즈가 공유하는 라벨 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트만 저장되는 것이 아니라 [IChartDataCell](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/) 개체와 연결됩니다.

일반적인 카테고리 차트의 경우 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고 나머지 셀에 시리즈 값을 저장합니다. [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/getcell/)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용하여 차트를 만들 때 유용하지만, 모든 기존 차트가 이 방식을 사용한다고 가정하지 마세요. 로드된 프레젠테이션에서는 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하세요.

차트 설정에는 세 가지 범위가 있습니다.

- 시리즈 수준 설정 예: [IChartSeries::get_Format](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/get_format/) 은 하나의 시리즈에 속한 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정 예: [IChartDataPoint::get_Format](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/get_format/) 은 하나의 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [IChartSeriesGroup](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 경우 [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) 를 통해 그룹에 접근하세요.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 모두에 서식이 존재하면 해당 포인트에 대해 포인트 서식이 우선합니다.

![차트 시리즈 파워포인트](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/get_overlap/) 은 2D 차트에서 막대 또는 열이 겹치는 정도를 -100%에서 100%까지 보고합니다. 이는 부모 시리즈 그룹에 대한 설정을 읽기 전용으로 투영한 값입니다. 해당 그룹에 포함된 모든 호환 시리즈를 업데이트하려면 [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) 를 호출하세요. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에만 적용되며, 복합 차트의 관련 없는 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다:

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

[IChartSeries::get_Format](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/get_format/) 을 사용하여 전체 시리즈의 기본 채우기를 설정합니다. 포인트에 이미 명시적인 채우기가 있는 경우 해당 포인트의 [IChartDataPoint::get_Format](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/get_format/) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다:

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

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터형 열 차트에 대해 기본 워크북이 생성될 때 셀 B1(행 0, 열 1)은 첫 번째 시리즈 이름을 포함합니다. 아래 예제의 명명된 상수는 이 구조를 명시적으로 보여줍니다:

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

또는 [IChartSeries::get_Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/get_name/) 이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하는 것을 방지합니다:

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

## **자동 시리즈 채우기 색상 가져오기**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) 은 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 이 메서드를 호출하면 계산된 색상을 읽어올 뿐, 새로운 채우기를 할당하지는 않습니다.

다음 예제는 기본 시리즈 각각의 자동 색상을 출력합니다:

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

정확한 색상은 차트 스타일과 테마에 따라 달라집니다.

## **시리즈에 대해 부정값 채우기 색상 반전 설정**

막대, 열 및 버블 시리즈의 경우 [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) 을 사용하면 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤, [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) 로 음수 값 색상을 지정합니다. 워크북의 음수 숫자는 변경되지 않으며, 표시 색상만 바뀝니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0에는 시리즈 이름이, 열 0에는 카테고리 이름이, 열 1에는 값이 들어 있습니다:

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

한 포인트에 대해서만 반전을 활성화하려면 [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) 를 사용합니다. 아래 예제에서는 시리즈에 대한 반전을 비활성화하고 선택된 포인트에만 활성화합니다. 또한 포인트에 음수 값을 할당해 효과를 확인할 수 있습니다:

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

## **특정 데이터 포인트 값 삭제**

포인트를 비우고 다른 포인트는 유지하려면 해당 워크북 셀을 `nullptr` 로 설정합니다. 열 차트의 경우 플롯된 값은 [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) 로 얻을 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만 차트는 해당 값을 차트의 빈값 설정에 따라 빈 값으로 처리합니다.

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 삭제합니다:

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

산점도 차트는 X와 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 사용합니다. 삭제하려는 값에 해당하는 셀만 비우세요. 다른 포인트를 유지하려면 [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) 를 호출하지 마세요. 해당 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비 대비 백분율로 표시한 값입니다. 겹침과 마찬가지로 이 값은 하나의 시리즈가 아니라 부모 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) 를 호출하세요. 값이 클수록 클러스터 사이의 공간이 넓어지고, 값이 작을수록 클러스터가 더 촘촘해집니다.

다음 예제는 간격 너비를 변경하고 최종 프레젠테이션만 저장합니다:

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

![간격 너비](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원하나요?**

[ChartType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/charttype/) 열거형으로 정의된 모든 차트 유형이 차트 데이터를 사용하지만, 시리즈마다 값 구조와 설정이 동일하지는 않습니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기도 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하세요. 겹침과 간격 너비와 같은 옵션은 호환 가능한 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇인가요?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseriesgroup/) 은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 여러 그룹을 포함할 수 있으므로 한 시리즈를 통해 도달한 그룹을 변경해도 차트의 모든 시리즈가 바뀌지는 않습니다.

**새로 만든 차트에 기본 데이터가 포함되어 있나요?**

예. 기본적으로 [IShapeCollection::AddChart](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addchart/) 은 샘플 시리즈, 카테고리 및 값을 생성합니다. 이 셀들을 편집하거나 완전한 사용자 정의 데이터 세트를 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 비울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 개체는 워크북 셀과 어떻게 연결되나요?**

시리즈 이름, 카테고리 라벨 및 데이터 포인트 값은 [IChartDataWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/) 의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 구성할 때는 카테고리 행과 시리즈 값 행을 정렬하여 각 포인트가 의도한 카테고리 아래에 플롯되도록 하세요.

**전체 시리즈가 아니라 하나의 포인트만 비우려면 어떻게 하나요?**

해당 값 셀을 `nullptr` 로 설정하면 포인트의 카테고리 위치는 유지되면서 빈 포인트가 됩니다. 전체 포인트를 삭제하려는 경우에만 [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) 을 호출하세요. 카테고리도 함께 삭제한다면 모든 시리즈가 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시되나요?**

결과는 차트 유형과 [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/get_displayblanksas/) 설정에 따라 다릅니다. 지원되는 차트는 빈 값을 간격, 0값, 혹은 인접 포인트 연결 등으로 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하세요.

**음수 값은 어떻게 서식이 적용되나요?**

지원되는 막대, 열 및 버블 시리즈의 경우 [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) 을 호출하고 [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) 로 색상을 지정합니다. 개별 포인트에 대해서는 [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) 로 동작을 재정의할 수 있습니다. 이러한 메서드는 서식에만 영향을 미치며 저장된 숫자 값은 변경되지 않습니다.

**시리즈와 포인트 모두 서식이 지정된 경우 어느 것이 우선 적용되나요?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식을 사용하거나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일과 테마를 따릅니다. 겹침 및 간격 너비와 같은 그룹 설정은 레이아웃을 제어하며 포인트 수준 서식 오버라이드가 아닙니다.

**차트에 포함될 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides 에는 별도의 고정 시리즈 수 제한이 없습니다. 실제 제한은 프레젠테이션 파일 크기, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성 등에 따라 결정됩니다.

**열이 너무 가깝거나 너무 멀리 떨어져 있으면 무엇을 수정해야 하나요?**

적절한 부모 시리즈 그룹에 대해 [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) 를 호출하세요. 값을 늘리면 클러스터 간 간격이 넓어지고, 값을 줄이면 클러스터가 더 가까워집니다.