---
title: .NET에서 프레젠테이션 차트 축 사용자 지정
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
- 축 선
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

이 문서에서는 Aspose.Slides for .NET을 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 카테고리 레이블 및 틱 마크 간격, 날짜 카테고리와 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트에서 수직 축의 최대값 가져오기**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)을 생성하고 기본 데이터가 있는 영역 차트를 추가합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 유지하기 위해 [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/)을 호출합니다.

축 한계를 위해 [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) 및 [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/)을 읽고, 틱 간격을 위해 [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) 및 [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/)을 읽습니다. 날짜 축과 관련된 시간 단위 스케일은 [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) 및 [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/)이 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

## **축 사이 데이터 교환**

[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)을 사용하여 차트 데이터에서 계열과 카테고리의 역할을 교환합니다. 이전 카테고리는 계열이 되고, 이전 계열은 카테고리가 됩니다. 이는 데이터 그룹화를 변경하지만 가로축과 세로축을 교환하지는 않습니다. 예제에서는 [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/)을 사용하여 기본 데이터를 `Sheet1!A1:D5`(헤더 행 및 카테고리 열 포함)에 바인딩한 후 행과 열을 전환합니다. 네 개의 계열과 세 개의 카테고리가 있는 차트를 저장합니다.

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

## **축의 플롯 순서 반전**

[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/)을 사용하여 카테고리 축 또는 값 축의 순서를 반전합니다. 예를 들어, 가로 막대 차트에서 프로젝트 단계가 워크시트와 동일한 순서(계획, 개발, 테스트)로 위에서 아래로 표시될 수 있습니다. 축을 반전하면 플롯 방향이 바뀌지만 워크북 데이터가 정렬되거나 재배열되지 않습니다. 비교를 위해 [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)은 계열과 카테고리의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 계열을 가진 가로 막대 차트를 만들고, 세 개의 슬라이드를 저장합니다: 일반 순서, 역순 카테고리, 역순 값. 각 복사본은 동일한 데이터 집합을 사용하며, 각 복사본에서 하나의 축만 반전됩니다.

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

// Slide 2: 첫 번째 카테고리를 상단에 표시합니다.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// 수평 값 축을 하단에 유지합니다.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: 수평 숫자 스케일만 반전합니다.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

축을 반전하면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)은 다른 축이 설정된 축과 교차하는 위치를 제어합니다. 슬라이드 2에서 역순 카테고리 축에 `Maximum`을 설정하면 가로 값 축이 하단에 유지됩니다. 특정 교차점을 지정하려면 [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)를 사용합니다. 방향을 변경할 때 특히 차트에 사용자 지정 교차점이 있는 경우 교차 설정을 확인하세요. `IsPlotOrderReversed`를 `false`로 되돌리면 정상적인 플롯 방향이 복원됩니다; 교차 설정은 별도로 관리됩니다.

| 일반 순서 (슬라이드 1) | 카테고리 역순 (슬라이드 2) | 값 역순 (슬라이드 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| 카테고리가 아래에서 위로 진행하고, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행합니다. 값 및 워크북 행 순서는 변경되지 않습니다. | 카테고리는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 카테고리 축은 오른쪽 영점에서 교차합니다. |

## **선 차트에서 수직 축 비활성화**

수직 축에 대해 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)을 `false`로 설정하여 숨깁니다. 예제에서는 기본 데이터가 있는 선 차트를 생성하고 수직 축을 숨긴 상태로 저장합니다.

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

## **선 차트에서 수평 축 비활성화**

수평 축에 대해 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)을 `false`로 설정하여 숨깁니다. 예제에서는 기본 데이터가 있는 선 차트를 생성하고 수평 축을 숨긴 상태로 저장합니다.

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

## **카테고리 축 변경**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)을 설정하여 날짜 축 또는 텍스트 카테고리 축을 선택합니다. 이 예제에는 첫 번째 슬라이드의 첫 번째 도형이 차트인 `ExistingChart.pptx`가 필요하며, 카테고리 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 가로 축을 날짜 축으로 변경합니다. [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/)을 `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/)을 `1`, [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/)을 `Months`로 설정하면 주요 틱이 한 달 간격으로 표시됩니다.

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

## **카테고리 축 레이블 간격 제어**

차트에 카테고리가 많을 때 카테고리 또는 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄입니다. [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/)을 `false`로 설정한 다음, 원하는 카테고리 간격에 따라 [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/)을 지정합니다. 텍스트 카테고리가 정상 순서에 있을 때는 첫 번째 카테고리부터 계산됩니다.

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

간격 `3`은 세 번째 레이블마다 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 해당 열을 제거하지는 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

틱 마크는 별도의 제어가 가능합니다. [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/)을 `false`로 설정하고 [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/)으로 간격을 지정합니다. 예를 들어 `1`은 모든 카테고리 간격에 틱 마크를 유지하면서 레이블은 3번째 카테고리마다만 표시합니다. [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/)을 눈에 보이는 스타일로 설정하여 결과를 확인할 수 있습니다. 두 자동 간격 속성을 다시 `true`로 설정하면 차트가 해당 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 카테고리와 하나의 계열을 만든 뒤 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 독립 틱 마크가 있는 수동 레이블 간격, 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션은 필요하지 않으며, 가로 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

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

// 슬라이드 2: 매 세 번째 레이블을 표시하되, 모든 카테고리에 대한 틱 마크는 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째 카테고리 레이블마다 표시되고 두 줄로 자동 래핑됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블마다 한 줄에 표시되고 틱 마크는 모든 카테고리 간격에 유지됩니다. 레이블이 없는 24개의 열 전체가 동일한 값과 함께 표시됩니다. 슬라이드 3은 위의 자동 표시를 복원합니다.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 카테고리 축(예: 열, 선, 영역 또는 막대 차트의 카테고리 축)에 이 카테고리 간격을 사용합니다. 열 차트에서는 가로 축이 카테고리 축이며, 가로 막대 차트에서는 카테고리 축이 세로이므로 [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)에 적용합니다. 틱 마크 간격은 계열 축이 있는 차트에도 적용됩니다.

값 축의 숫자 스케일을 설정하려면 카테고리 레이블 간격을 사용하지 마세요. 값 축에서 [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/)은 값 차이를 지정합니다(예: `10`이면 0, 10, 20 …). 카테고리 레이블 간격 `3`은 데이터 값에 관계없이 카테고리 위치를 셉니다. 산점도와 버블 차트는 텍스트 카테고리 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [카테고리 축 변경](#change-a-category-axis) 섹션에 설명된 대로 시간 기반 주요 단위와 스케일을 사용하세요.

## **카테고리 축 값의 날짜 형식 설정**

예제는 기본 차트 데이터를 4개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장됩니다. [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)을 날짜 축으로 설정하고, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)를 비활성화한 뒤, [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)에 `yyyy`를 지정하면 셀 서식과 무관하게 카테고리 레이블이 4자리 연도로 표시됩니다.

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

수직 축에 [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)을 활성화하고 제목 텍스트를 제공한 뒤, [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/)을 설정하여 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전시킨 열 차트를 저장합니다.

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

## **카테고리 또는 값 축에 대한 축 위치 설정**

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/)를 사용하여 값 축이 카테고리 축을 카테고리 사이에 교차할지, 카테고리 틱 마크에서 교차할지 제어합니다. 이 속성은 카테고리 축에만 적용됩니다. 예제는 열 차트의 가로 카테고리 축에 `true`를 설정하고 결과를 저장합니다.

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

## **값 축에 표시 단위 설정**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/)을 설정하면 기본 데이터를 변경하지 않고 값 축 레이블을 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/)을 `Millions`로 지정하면 60,000,000 값이 60으로 표시됩니다. 예제는 열 차트를 생성하고 세로 축에 백만 단위 표시 단위를 적용합니다.

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

## **로그arithmic 값 축 구성**

양의 값이 여러 자릿수에 걸쳐 변동할 때 로그arithmic 값 축이 유용합니다. 예를 들어, 서비스가 5개 기간 동안 10, 100, 1,000, 10,000, 100,000 요청을 받을 수 있습니다. 선형 스케일에서는 작은 값이 0 근처에 몰려 보입니다. 로그 스케일은 동일한 거리를 동일한 비율로 나타내어 상대적 성장 비교를 쉽게 합니다.

값 축에 [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/)을 `true`로 설정하고, [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/)를 사용해 기준을 선택합니다. 이는 기존 값 표시 방식을 변경하지만 데이터 자체를 변경하거나 로그arithmic 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 별도 기능입니다.

### **값 축 및 기준 선택**

선 또는 열 차트에서는 값 축이 [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)입니다. 가로 막대 차트에서는 [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/)가 값 축입니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X 값에 가로 축, Y 값에 세로 축을 선택하거나 둘 다 적용합니다. 카테고리 축에는 로그arithmic 스케일을 적용하지 마세요.

기본 로그arithmic 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 기준을 사용할 수 있으며, `2.5`와 같은 소수점 기준도 지원됩니다. 기준 `10`을 사용하면 10, 100, 1,000, 10,000 등 연속적인 거듭 제곱이 동일한 간격으로 배치됩니다.

### **선형 스케일과 로그arithmic 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 5개의 요청 수를 가진 선 차트를 만든 뒤 해당 슬라이드를 복제하고 두 번째 슬라이드에서 기준 10 로그arithmic 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

**선형 스케일 (슬라이드 1):** 동일한 수직 거리가 요청 수의 동일한 차이를 나타냅니다. 가장 큰 값이 차트를 압도하여 작은 값이 구분하기 어렵습니다.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**로그arithmic 스케일 (슬라이드 2):** 동일한 수직 거리가 동일한 비율을 나타냅니다. 각 기간의 요청 수가 이전 기간의 10배이므로, 기준 10 스케일에서 점이 직선으로 상승합니다. 축 레이블은 여전히 원본 요청 수를 표시합니다.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그arithmic 스케일은 양수 값만 표시할 수 있습니다. 적용 전에 데이터를 확인하세요. 0 또는 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하세요. 해당 값들을 제외하는 것이 분석에 적절하다면 그 이유를 설명해야 합니다. 작은 양수로 조용히 대체하면 데이터 의미가 변합니다. 로그arithmic 축에 수동으로 지정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**축이 다른 축을 교차하는 값을 어떻게 설정하나요 (축 교차점)?**

[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)을 사용해 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)을 설정합니다. 이 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**틱 레이블을 축에 대해 어떻게 위치시키나요?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/)을 [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/)과 함께 사용합니다: `Low`, `High`, `NextTo` 또는 `None`. 틱 마크 자체를 제어하려면 [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) 또는 [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)을 사용합니다; 이는 레이블 위치와 별개입니다.