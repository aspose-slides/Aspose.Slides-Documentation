---
title: .NET에서 프레젠테이션 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/net/chart-series/
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
- .NET
- C#
- Aspose.Slides
description: "C#를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 너비 및 음수 값을 관리하는 방법을 배웁니다."
---
## **개요**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [IChartSeries](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/)는 관련 값 집합을 나타내며, 시리즈의 각 [IChartDataPoint](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/)은 하나 이상의 워크북 셀을 가리킵니다. [IChartCategory](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartcategory/) 개체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트만으로 저장되지 않고 [IChartDataCell](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/) 개체와 연결됩니다.

일반적인 카테고리 차트의 경우, 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고, 나머지 셀을 시리즈 값에 사용합니다. [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/getcell/)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용해 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다는 가정은 하지 마세요. 로드된 프레젠테이션의 경우, 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 검사하세요.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정, 예를 들어 [IChartSeries.Format](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/format/)는 하나의 시리즈에 속한 모든 포인트의 기본 모양을 제공합니다.
- 데이터 포인트 설정, 예를 들어 [IChartDataPoint.Format](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/format/)는 하나의 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [IChartSeriesGroup](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/)에 속한 호환 시리즈에 적용됩니다. 겹침이나 간격 너비와 같은 옵션을 설정해야 할 때는 [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/parentseriesgroup/)을 통해 그룹에 접근하세요.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우, 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 서식이 모두 존재하면 포인트 서식이 해당 포인트에 우선합니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[IChartSeries.Overlap](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/overlap/)은 2D 차트에서 막대 또는 열이 겹치는 정도를 -100%에서 100%까지 보고합니다. 이는 상위 시리즈 그룹에 대한 설정을 읽기 전용으로 투영한 것입니다. [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/overlap/)을 설정하면 해당 그룹의 모든 호환 시리즈가 업데이트됩니다. 이 옵션은 그룹화된 막대 또는 열을 표시하는 차트 유형에 적용되며, 조합 차트의 무관한 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 새 차트에는 샘플 시리즈, 카테고리 및 값이 포함되어 있습니다.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

결과:

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

[IChartSeries.Format](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/format/)을 사용하여 전체 시리즈의 기본 채우기를 설정합니다. 포인트에 명시적인 채우기가 이미 지정된 경우, 해당 포인트의 [IChartDataPoint.Format](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/format/) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

결과:

![시리즈 색상](series_color.png)

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 열 차트에 대해 기본 워크북이 생성될 때, 셀 B1(행 0, 열 1)은 첫 번째 시리즈의 이름을 포함합니다. 다음 예제의 명명된 상수는 해당 구조를 명시합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

또한 [IChartSeries.Name](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/name/)이 이미 참조하고 있는 셀을 업데이트할 수 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하는 것을 피합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

결과:

![시리즈 이름](series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/)은 시리즈 인덱스와 차트 스타일에서 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상이 반환되며, 새로운 채우기가 할당되는 것은 아닙니다.

다음 예제는 각 기본 시리즈의 자동 색상을 출력합니다:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

기본 차트 스타일에 대한 예제 출력:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

정확한 색상은 차트 스타일 및 테마에 따라 달라집니다.

## **차트 시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/invertifnegative/)를 사용하면 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고, 반전을 활성화한 다음, [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)을 통해 음수 색상을 지정하세요. 워크북의 음수 값은 변경되지 않으며, 표시 색상만 변경됩니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0에는 시리즈 이름이, 열 0에는 카테고리 이름이, 열 1에는 값이 포함됩니다:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

결과:

![반전된 단색 채우기 색상](inverted_solid_fill_color.png)

또한 [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)를 통해 하나의 포인트에만 반전을 활성화할 수 있습니다. 다음 예제에서는 시리즈에 대한 반전이 비활성화되고 선택한 포인트에만 활성화됩니다. 포인트에 음수 값을 할당하여 효과를 확인합니다:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **특정 데이터 포인트 값 지우기**

하나의 포인트를 빈 상태로 만들고 다른 포인트를 유지하려면 해당 백업 워크북 셀을 `null`로 설정합니다. 열 차트의 경우 플롯된 값은 [IChartDataPoint.YValue](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/yvalue/)를 통해 확인할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만 차트는 해당 값을 차트의 빈값 설정에 따라 빈 것으로 처리합니다.

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 지웁니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

산점도 차트는 별도의 X 및 Y 셀을 사용하고, 버블 차트는 크기 셀도 사용합니다. 제거하려는 값에 해당하는 셀만 비우세요. 다른 포인트를 유지하려면 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapointcollection/clear/)을 호출하지 마세요. 해당 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 백분율로 나타낸 것입니다. 겹침과 마찬가지로, 이는 개별 시리즈가 아닌 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)을 설정하면 됩니다. 값이 클수록 클러스터 사이의 간격이 넓어지고, 값이 작을수록 더 촘촘해집니다.

다음 예제는 간격 너비를 변경하고 최종 프레젠테이션만 저장합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

결과:

![간격 너비](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원하나요?**

[ChartType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/charttype/) 열거형으로 표시되는 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 값 구조나 설정이 동일하지는 않습니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하세요. 겹침 및 간격 너비와 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇인가요?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/)은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 조합 차트는 둘 이상의 그룹을 포함할 수 있으므로, 하나의 시리즈를 통해 접근한 그룹을 변경한다고 해서 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되어 있나요?**

예. 기본적으로 [IShapeCollection.AddChart](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addchart/)는 샘플 시리즈, 카테고리 및 값을 생성합니다. 해당 셀을 편집하거나 시리즈와 카테고리 컬렉션을 모두 지운 뒤 완전히 사용자 정의된 데이터 세트를 추가할 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결되나요?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [IChartDataWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 만들 때는 카테고리 행과 시리즈‑값 행이 정렬되어 각 포인트가 의도한 카테고리 아래에 플롯되도록 하세요.

**전체 시리즈가 아닌 하나의 포인트만 어떻게 삭제하나요?**

해당 값 셀을 `null`로 설정하면 포인트의 카테고리 위치는 유지하면서 빈 포인트가 됩니다. 전체 시리즈를 삭제하려는 경우에만 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapointcollection/clear/)을 사용하세요. 카테고리도 함께 삭제한다면 모든 시리즈를 업데이트하여 값이 카테고리 컬렉션과 정렬되도록 해야 합니다.

**빈 포인트는 어떻게 표시되나요?**

결과는 차트 유형과 [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/displayblanksas/) 설정에 따라 달라집니다. 지원되는 차트는 빈 값을 간격, 0값 또는 인접 포인트 연결로 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하세요.

**음수 값은 어떻게 서식이 지정되나요?**

지원되는 막대, 열 및 버블 시리즈의 경우 [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/invertifnegative/)를 활성화하고 [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)를 설정하세요. 개별 포인트에 대해서는 [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)로 동작을 재정의할 수 있습니다. 이러한 속성은 서식에 영향을 주며, 저장된 숫자 값 자체는 변하지 않습니다.

**시리즈와 포인트 모두 서식이 지정된 경우 어느 것이 우선인가요?**

명시적인 데이터 포인트 서식이 해당 포인트에 우선합니다. 다른 포인트는 명시적인 시리즈 서식이나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침 및 간격 너비와 같은 그룹 속성은 레이아웃을 제어하며, 포인트 수준 서식 재정의와는 별개입니다.

**차트에 포함될 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides에는 별도의 고정 시리즈 수 제한이 없습니다. 실제 제한은 프레젠테이션 파일 제한, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성 등에 따라 결정됩니다.

**열이 너무 가깝거나 멀리 떨어져 있을 때는 무엇을 변경해야 하나요?**

적절한 상위 시리즈 그룹에서 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)를 설정하세요. 값을 늘리면 클러스터 사이의 간격이 넓어지고, 값을 줄이면 클러스터가 서로 가까워집니다.