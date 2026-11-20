---
title: .NET에서 프레젠테이션의 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/net/chart-axis/
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
- 축 라인
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하는 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides for .NET을 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주와 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트의 수직 축에서 최대 값 가져오기**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)을 만들고 기본 데이터가 있는 영역 차트를 추가합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 만들기 위해 [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/)을 호출합니다.

축 한계에 대해 [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/)와 [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/)을 읽고, 눈금 간격에 대해 [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/)와 [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/)을 읽습니다. 날짜 축과 관련된 시간 단위 스케일은 [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/)과 [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/)이 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **축 사이의 데이터 교환**

[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)을 사용하여 차트 데이터에서 시리즈와 범주의 역할을 교환합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터가 그룹화되는 방식을 변경하지만, 수평 및 수직 축을 교환하는 것은 아닙니다. 예제에서는 [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/)을 사용하여 기본 데이터를 `Sheet1!A1:D5`(머리글 행 및 범주 열 포함)와 연결한 후 행과 열을 전환합니다. 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **축의 플롯 순서 역전**

[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/)을 사용하여 범주 축 또는 값 축의 플롯 순서를 역전시킵니다. 예를 들어, 가로 막대 차트에서 프로젝트 단계가 워크시트와 동일한 순서(계획, 개발, 테스트)로 위에서 아래로 표시될 수 있습니다. 축을 역전하면 플롯 방향이 바뀔 뿐, 워크북 데이터를 정렬하거나 재배열하지는 않습니다. 비교를 위해 [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈가 있는 가로 막대 차트를 만들고, 정상 순서, 역전된 범주, 역전된 값 순서의 세 슬라이드를 저장합니다. 각 사본은 동일한 데이터 세트를 사용하며, 각 사본에서 하나의 축만 역전됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Slide 2: 첫 번째 범주를 위에 표시합니다.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// 수평 값 축을 아래에 유지합니다.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: 수평 숫자 스케일만 역전합니다.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

축을 역전하면 수직 축을 플롯의 반대쪽으로 이동할 수도 있습니다. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)은 구성 중인 축이 다른 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 역전된 범주 축에 `Maximum`을 설정하여 수평 값 축을 아래쪽에 유지합니다. 특정 교차 지점을 지정하려면 [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)을 사용합니다. 방향을 변경할 때는 기존에 사용자 지정 교차 지점이 있는 경우 교차 설정을 확인하십시오. `IsPlotOrderReversed`를 `false`로 다시 설정하면 정상 플롯 방향이 복원되며, 교차 설정은 별도로 유지됩니다.

| 정상 순서 (슬라이드 1) | 역전된 범주 (슬라이드 2) | 값 역전 (슬라이드 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| 범주는 아래에서 위로 진행하고, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행합니다. 값 및 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽 영점에서 교차합니다. |

## **라인 차트의 수직 축 비활성화**

수직 축에 대해 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)을 `false`로 설정하여 숨깁니다. 예제에서는 기본 데이터가 있는 라인 차트를 만들고 수직 축이 숨겨진 상태로 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **라인 차트의 수평 축 비활성화**

수평 축에 대해 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)을 `false`로 설정하여 숨깁니다. 예제에서는 기본 데이터가 있는 라인 차트를 만들고 수평 축이 숨겨진 상태로 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **차트 격자선 표시 또는 숨기기**

축이 표시하는 격자선을 확인하려면 [ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/)와 [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/)를 읽습니다. 두 속성은 읽기 전용입니다. 소규모 격자선을 표시하거나 숨기려면 [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/)의 선 채우기를 사용하십시오. 보이는 색상의 단색 채우기를 설정하면 표시되고, `FillType.NoFill`을 사용하면 숨겨집니다. 주요 격자선에 대한 대응 설정은 [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`입니다. 격자선 채우기를 변경해도 축 표시와 눈금은 유지됩니다.

이 클러스터형 컬럼 차트의 수직 축은 주요 격자선이 표시되고 소규모 격자선이 숨겨진 상태로 시작합니다. 예제에서는 먼저 소규모 격자선을 주황색으로 표시한 뒤 다시 숨기고 프레젠테이션을 저장합니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| 소규모 격자선 활성화 | 소규모 격자선 숨김 |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **범주 축 변경**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)을 설정하여 날짜 또는 텍스트 범주 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `ExistingChart.pptx`와 숫자형 Excel 날짜 값이 들어 있는 범주 셀을 전제로 합니다. 수평 축을 날짜 축으로 변경합니다. [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/)을 `false`로, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/)을 `1`로, 그리고 [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/)을 `Months`로 설정하면 주요 눈금이 한 달 간격으로 배치됩니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

### **데이터에서 범주 축 유형 결정**

범주를 채운 후 [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/)을 호출하고, 선택된 유형을 확인하려면 [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/)을 읽습니다. 동일한 차트가 텍스트 레이블 또는 숫자형 날짜 값을 받을 때 유용합니다. 이 메서드는 호출 시 유형을 결정하며, 이후 데이터 변경을 다시 평가하는 지속 모드를 활성화하지는 않습니다. 범주를 교체한 후 다시 호출하십시오.

다음 예제는 텍스트 범주가 있는 차트를 만들고 `Text`를 출력합니다. 그런 다음 범주 셀 값을 날짜로 교체하고 메서드를 다시 호출하면 `Date`가 출력됩니다. 날짜는 [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate)에서 반환되는 숫자형 OLE 자동화 값으로 저장되며, 문자열 형태가 아닙니다. [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/)은 이러한 값이 표시되는 방식을 제어하지만 텍스트를 숫자형 날짜로 변환하지는 않습니다. 범주 셀에 대한 자세한 내용은 [차트 워크북](/slides/ko/net/chart-workbook/)을 참고하십시오.

입력에 텍스트 범주 또는 숫자형 날짜가 포함되는 것이 알려진 경우 자동 결정을 사용하십시오. 일반적인 숫자 레이블, 혼합 범주 또는 빈 데이터의 경우 의도된 의미에 맞게 [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/)을 명시적으로 설정하십시오. 숫자만으로는 범주가 날짜임을 나타내지 않습니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // 텍스트

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // 날짜

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **범주 축 레이블 간격 제어**

차트에 범주가 많이 있는 경우 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/)을 `false`로 설정한 다음, [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/)을 원하는 범주 간격으로 설정합니다. 텍스트 범주가 정상 순서에 있을 때는 첫 번째 범주부터 카운트합니다:

| 간격 | 예시에서 표시되는 레이블 |
| --- | --- |
| `1` | 범주 1, 범주 2, 범주 3, … 범주 24 |
| `2` | 범주 1, 범주 3, 범주 5, … 범주 23 |
| `3` | 범주 1, 범주 4, 범주 7, … 범주 22 |

`3` 간격은 매 세 번째 레이블만 표시하고 두 레이블은 숨깁니다. 해당 열 자체는 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금은 별도의 제어가 가능합니다. [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/)을 `false`로 설정하고 [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/)으로 간격을 지정합니다. 예를 들어 `1`은 각 범주 간격마다 눈금을 두면서 레이블은 매 세 번째 범주에만 표시됩니다. [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/)을 눈에 보이는 스타일로 설정하면 결과를 확인할 수 있습니다. 자동 간격 속성을 다시 `true`로 되돌리면 차트가 간격을 다시 선택합니다.

다음 독립 실행형 예제는 24개의 범주와 하나의 시리즈를 만들고 `CategoryAxisIntervals.pptx`에 세 슬라이드를 저장합니다: 자동 간격, 레이블 간격을 수동으로 지정하고 눈금을 독립적으로 유지, 자동 간격 복원. 두 사본 모두 원본 차트 데이터를 보존합니다. 입력 프레젠테이션은 필요하지 않으며, 수평 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// 슬라이드 2: 매 세 번째 레이블을 표시하되, 각 범주마다 눈금을 유지합니다.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// 슬라이드 3: 차트가 두 간격을 다시 선택하도록 합니다.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 범주 레이블이 표시되고 두 줄로 래핑됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블만 한 줄에 표시되고, 눈금은 각 범주 간격마다 유지됩니다. 레이블이 없는 24개의 열도 동일한 값으로 그대로 보입니다. 슬라이드 3은 위의 자동 모습을 복원합니다.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 컬럼, 라인, 영역 또는 막대 차트의 범주 축)에서는 이 범주 수 간격을 사용합니다. 컬럼 차트에서는 수평 축이며, 가로 막대 차트에서는 범주 축이 수직이므로 이러한 설정을 [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)에 적용하십시오. 눈금 간격은 축이 하나인 차트의 시리즈 축에도 적용됩니다.

범주 레이블 간격을 값 축의 숫자 스케일을 설정하는 데 사용하지 마십시오. 값 축에서는 [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/)이 값 차이를 지정합니다(예: `10`은 0, 10, 20,…). 범주 레이블 간격 `3`은 데이터 값과 무관하게 범주 위치만 셉니다. 산점도 및 버블 차트는 텍스트 범주 축이 아니라 값 축을 사용합니다. 날짜 축의 경우 [범주 축 변경](#change-a-category-axis) 섹션에 설명된 시간 기반 주요 단위 및 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제에서는 기본 차트 데이터를 네 개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE 자동화 일련 번호로 저장됩니다. [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)을 날짜 축으로 설정하고, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)를 비활성화한 뒤, [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)에 `yyyy`를 지정하면 셀 서식과 관계없이 범주 레이블에 연도가 네 자리로 표시됩니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **차트 축 제목 회전 각도 설정**

수직 축에 대해 [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)을 활성화하고 제목 텍스트를 제공한 뒤, [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/)을 설정하여 제목을 회전합니다. 각도는 도 단위이며, 이 예제에서는 값 축 제목을 90도 회전시킨 컬럼 차트를 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **범주 또는 값 축의 축 위치 설정**

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/)를 사용하여 값 축이 범주 축 사이에 교차할지 범주 눈금에 교차할지를 제어합니다. 이 속성은 범주 축에 적용됩니다. 예제에서는 컬럼 차트의 수평 범주 축에 `true`를 설정하고 결과를 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **차트 값 축에 표시 단위 설정**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/)을 설정하면 값 축의 레이블을 데이터 자체를 변경하지 않고 스케일링할 수 있습니다. [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/)을 `Millions`로 설정하면 60,000,000이 60으로 표시됩니다. 예제에서는 컬럼 차트를 만들고 수직 축에 백만 단위를 적용합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **로그값 축 구성**

양의 값이 여러 차수에 걸쳐 크게 차이날 때 로그값 축을 사용하면 유용합니다. 예를 들어, 서비스가 5개 기간 동안 10, 100, 1 000, 10 000, 100 000 요청을 받는다고 가정합니다. 선형 스케일에서는 작은 값들이 0에 가까워 함께 표시됩니다. 로그 스케일에서는 동일한 거리당 동일한 비율을 나타내어 성장 비교가 쉬워집니다.

값 축에 [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/)을 `true`로 설정하고, [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/)를 사용하여 기준을 선택합니다. 이는 기존 값이 표시되는 방식을 변경하지만, 데이터 자체를 바꾸거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춰진 별도 기능입니다.

### **값 축 및 기준 선택**

라인이나 컬럼 차트의 경우 값 축은 [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)입니다. 가로 막대 차트에서는 [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/)가 값 축이 됩니다. 산점도와 버블 차트는 두 개의 값 축을 가지고 있으므로 X 값에는 수평 축, Y 값에는 수직 축을 선택하거나 둘 다 적용합니다. 범주 축에는 로그 스케일을 적용하지 마십시오.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 기준을 사용할 수 있으며, `2.5`와 같은 소수 기준도 지원됩니다. 기준이 `10`일 때 10, 100, 1 000, 10 000과 같은 연속적인 거듭제곱이 동일한 간격으로 배치됩니다.

### **선형 및 로그 스케일 비교**

다음 독립 실행형 예제는 첫 번째 슬라이드에 5개의 요청 수를 가진 라인 차트를 만들고, 해당 슬라이드를 복제한 뒤 두 번째 슬라이드에 기준 10 로그값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// 첫 번째 슬라이드는 선형으로 유지하고 복사본의 값 축 스케일만 변경합니다.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**선형 스케일 (슬라이드 1):** 동일한 수직 거리는 동일한 요청 수 차이를 나타냅니다. 가장 큰 값이 차트를 지배하여 작은 값이 구분하기 어렵습니다.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리는 동일한 비율을 나타냅니다. 각 기간의 요청 수가 이전 기간보다 10배씩 증가하므로, 기준 10 스케일에서 점들이 직선으로 상승합니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양의 값만 표시할 수 있습니다. 사용 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값을 제외하는 것이 분석에 적절하다면 그 이유를 설명해야 합니다. 작은 양수로 조용히 대체하면 데이터 의미가 바뀝니다. 로그 축에 대해 수동으로 지정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**축이 다른 축을 교차하는 값(축 교차점)을 어떻게 설정합니까?**

[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)을 사용하여 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)을 설정합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**축에 대해 눈금 레이블을 어떻게 배치합니까?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/)을 [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/)(`Low`, `High`, `NextTo`, `None`) 중 하나로 설정합니다. 눈금 자체를 제어하려면 [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) 또는 [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)을 사용합니다. 이들은 레이블 위치와는 별개입니다.