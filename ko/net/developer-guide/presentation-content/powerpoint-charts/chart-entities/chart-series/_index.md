---
title: .NET 프레젠테이션에서 차트 데이터 시리즈 관리
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

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [IChartSeries](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/)는 관련 값의 한 세트를 나타내며, 시리즈의 각 [IChartDataPoint](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/)는 하나 이상의 워크북 셀을 참조합니다. [IChartCategory](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트로만 저장되는 것이 아니라 [IChartDataCell](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/) 객체와 연결됩니다.

일반적인 범주형 차트의 경우 기본 워크북은 0 행을 시리즈 이름에, 0 열을 카테고리 이름에 사용하고 나머지 셀은 시리즈 값에 사용합니다. [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/getcell/)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터로 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정하지 마십시오. 로드된 프레젠테이션의 경우, 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하십시오.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정으로, 예를 들어 [IChartSeries.Format](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/format/)은 하나의 시리즈에 포함된 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정으로, 예를 들어 [IChartDataPoint.Format](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/format/)은 하나의 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [IChartSeriesGroup](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 때는 [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/parentseriesgroup/)을 통해 그룹에 접근하십시오.

명시적인 포인트 또는 시리즈 채우기 설정이 없으면 차트 스타일 및 테마가 자동 모양을 결정합니다. 시리즈와 포인트 형식이 모두 존재할 경우, 해당 포인트에 대해 포인트 형식이 우선합니다.

![차트 시리즈 파워포인트](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[IChartSeries.Overlap](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/overlap/)은 2D 차트에서 막대나 열이 -100%에서 100%까지 겹치는 정도를 보고합니다. 이는 부모 시리즈 그룹 설정의 읽기 전용 투영입니다. 해당 그룹의 모든 호환 시리즈를 업데이트하려면 [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/overlap/)을 설정하십시오. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에 적용되며, 복합 차트의 무관한 시리즈 그룹에는 영향을 주지 않습니다.

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

// 새 차트에는 샘플 시리즈, 카테고리 및 값이 포함됩니다.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

결과:

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

[IChartSeries.Format](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/format/)을 사용하여 전체 시리즈에 대한 기본 채우기를 설정합니다. 포인트에 이미 명시적인 채우기가 있는 경우, 해당 [IChartDataPoint.Format](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/format/) 설정이 그 포인트에 대해 시리즈 채우기를 재정의합니다.

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

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터형 열 차트를 위해 생성된 기본 워크북에서 셀 B1은 행 0, 열 1에 위치하며 첫 번째 시리즈의 이름을 포함합니다. 다음 예제의 명명된 상수는 해당 구조를 명시적으로 나타냅니다:

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

[IChartSeries.Name](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/name/)이 이미 참조하는 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행 및 열을 가정하는 것을 피합니다:

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

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/)은 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상을 읽을 뿐이며, 새 채우기를 할당하지는 않습니다.

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

기본 차트 스타일에 대한 예시 출력:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

정확한 색상은 차트 스타일 및 테마에 따라 달라집니다.

## **차트 시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/invertifnegative/)을 사용하면 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤, [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)을 통해 음수 값 색상을 지정하십시오. 음수 값 자체는 워크북에서 변경되지 않으며, 표시 색상만 변경됩니다.

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

[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)을 사용하여 하나의 포인트에 대해 반전을 활성화할 수 있습니다. 다음 예제에서는 시리즈에 대해 반전이 비활성화되고 선택된 포인트에만 활성화됩니다. 또한 포인트에 음수 값을 지정하여 효과가 보이도록 합니다:

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

다른 포인트를 제거하지 않고 하나의 포인트를 비우려면 해당 백업 워크북 셀을 `null`로 설정하십시오. 열 차트의 경우 플롯된 값은 [IChartDataPoint.YValue](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/yvalue/)를 통해 확인할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만 차트는 차트의 빈값 설정에 따라 해당 값을 빈 값으로 처리합니다.

다음 예제는 첫 번째 시리즈에서 두 번째 포인트만 지웁니다:

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

산점도 차트는 별도의 X 및 Y 셀을 사용하고, 버블 차트는 크기 셀도 사용합니다. 제거하려는 값에 해당하는 셀만 지우십시오. 다른 포인트를 유지하려는 경우 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapointcollection/clear/)을 호출하지 마십시오. 이 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **빈 셀 표시 제어**

값이 있는 숨겨진 셀은 빈 셀과 별개의 경우입니다. 숨겨진 워크시트 행 및 열의 데이터를 포함하거나 제외하려면 [Include Data from Hidden Rows and Columns](/slides/ko/net/chart-workbook/#include-data-from-hidden-rows-and-columns)를 참조하십시오.

빈 워크북 셀은 누락된 데이터를 나타내며, `0`이 들어 있는 셀은 알려진 숫자 값을 나타냅니다. 셀을 비우려면 [IChartDataCell.Value](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/value/)을 `null`로 설정하십시오. 숫자 0은 빈 셀 설정에 관계없이 0으로 남습니다.

[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/displayblanksas/)를 사용하여 차트가 빈 셀을 표시하는 방식을 선택하십시오. 이 설정은 전체 차트에 적용됩니다. 빈 셀을 0 또는 보간값으로 채우지 않고, 빈 셀의 플롯 방식을 변경합니다.

다음 자체 포함 예제는 하나의 시리즈가 있는 라인 차트를 만들고, Day 3의 값을 지운 후 각 모드별로 동일한 차트를 저장합니다. 입력 파일은 필요하지 않습니다. [IChartDataWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/)은 워크시트 0, 열 0을 카테고리 레이블에, 열 1을 값에 사용하며; 행 0은 시리즈 이름을 보관합니다. 최종 데이터는 `10, 20, empty, 30, 40`입니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Day 3을 실제로 비워두고 카테고리와 데이터 포인트는 유지합니다.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

각 출력 파일은 저장 전에 할당된 모드를 저장합니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나의 버전만 저장하려면 원하는 모드를 할당하고, 모드를 반복하지 않고 프레젠테이션을 한 번 저장하십시오.

아래 비교에서는 세 파일 모두 동일한 데이터를 보여줍니다. 모든 경우에서 워크북의 Day 3은 비어 있습니다:

![같은 데이터의 라인 차트: Gap은 Day 3에서 선을 끊고, Zero는 선을 0으로 내리며, Span은 Day 2와 Day 4를 연결합니다.](display_blanks_as.png)

시각적 효과는 차트 유형에 따라 달라집니다. 라인 차트는 세 가지 모드를 쉽게 비교할 수 있게 합니다. 막대 및 열 차트는 누락된 카테고리를 연결할 선이 없으므로 `Span`은 위에 표시된 연결 구간을 만들 수 없습니다; 누락된 열과 높이가 0인 열도 비슷하게 보일 수 있습니다. 마찬가지로 마커만 있는 산점도 차트에도 연결 선이 없습니다. 모든 차트 유형에 대해 세 가지 뚜렷한 결과를 기대하지 말고, 사용 중인 유형에 대한 출력을 확인하십시오.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 열 클러스터 사이의 공간으로, 막대 또는 열 너비의 백분율로 표시됩니다. 겹침과 마찬가지로 이는 개별 시리즈가 아니라 상위 시리즈 그룹에 속합니다. 그룹에 대해 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)을 한 번 설정하십시오. 큰 값은 클러스터 사이에 더 많은 공간을 만들고, 작은 값은 클러스터를 더 촘촘하게 합니다.

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

**어떤 차트 유형이 데이터 시리즈를 지원합니까?**

전체 [ChartType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/charttype/) 열거형으로 나타내는 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 동일한 값 구조나 설정을 갖지는 않습니다. 예를 들어, 범주형 차트는 카테고리와 값을 사용하고, 산점도 차트는 X 및 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 방법을 사용하십시오. 겹침 및 간격 너비와 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇입니까?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/)은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 하나 이상의 그룹을 포함할 수 있으므로, 하나의 시리즈를 통해 접근한 그룹을 변경해도 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되어 있습니까?**

예. 기본적으로 [IShapeCollection.AddChart](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addchart/)은 샘플 시리즈, 카테고리 및 값을 생성합니다. 완전히 사용자 정의된 데이터 세트를 추가하기 전에 해당 셀을 편집하거나 시리즈와 카테고리 컬렉션을 모두 비울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀에 어떻게 연결됩니까?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [IChartDataWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 구축할 때는 카테고리 행과 시리즈-값 행을 정렬하여 각 포인트가 의도한 카테고리 아래에 플롯되도록 하십시오.

**전체 시리즈가 아니라 하나의 포인트만 어떻게 지우나요?**

관련 값 셀을 `null`로 설정하면 포인트의 카테고리 위치는 빈 포인트로 유지됩니다. 해당 시리즈의 모든 포인트를 제거하려는 경우에만 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapointcollection/clear/)을 사용하십시오. 카테고리도 제거하는 경우, 모든 시리즈를 업데이트하여 값이 카테고리 컬렉션과 정렬되도록 유지하십시오.

**빈 포인트는 어떻게 표시됩니까?**

결과는 차트 유형 및 [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/displayblanksas/)에 따라 달라집니다. 지원되는 차트는 빈 값을 간격, 0값, 또는 인접 포인트 연결 중 하나로 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하십시오. 전체 예제와 시각적 비교는 [Control the Display of Empty Cells](#control-the-display-of-empty-cells)를 참조하십시오.

**음수 값은 어떻게 서식이 지정됩니까?**

지원되는 막대, 열 및 버블 시리즈의 경우 [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/invertifnegative/)을 활성화하고 [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)을 설정하십시오. 개별 포인트에 대해서는 [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)으로 동작을 재정의할 수 있습니다. 이러한 속성은 서식에 영향을 주며 저장된 숫자 값에는 영향을 주지 않습니다.

**시리즈와 포인트가 모두 서식이 지정된 경우 어느 서식이 우선합니까?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식을 사용하거나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침 및 간격 너비와 같은 그룹 속성은 레이아웃을 제어하며 포인트 수준 서식을 재정의하지 않습니다.

**차트에 포함될 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides는 별도의 고정된 시리즈 수 제한을 두지 않습니다. 실제로는 프레젠테이션 파일 제한, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성이 실용적인 제한을 결정합니다.

**열이 너무 가깝거나 멀리 떨어져 있을 때 무엇을 변경해야 하나요?**

적절한 상위 시리즈 그룹에서 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)을 설정하십시오. 값을 늘리면 클러스터 사이의 공간이 넓어지고, 값을 줄이면 클러스터가 더 가까워집니다.