---
title: .NET에서 프레젠테이션의 차트 축 맞춤
linktitle: 차트 축
type: docs
url: /ko/net/chart-axis/
keywords:
- 차트 축
- 세로 축
- 가로 축
- 축 맞춤
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
description: "보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 맞춤하기 위해 Aspose.Slides for .NET을 사용하는 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides for .NET을 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주와 형식 지정, 제목 회전, 축 위치 지정 및 표시 단위를 다룹니다.

## **차트의 세로 축에서 최대 값 가져오기**

기본 데이터가 포함된 영역 차트를 추가하기 위해 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)을(를) 생성합니다. 계산된 축 값을 읽기 전에 차트 레이아웃이 최신 상태가 되도록 [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/)을(를) 호출합니다.

축 한계를 위해 [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/)와 [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/)을(를) 읽고, 눈금 간격을 위해 [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/)와 [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/)을(를) 읽습니다. 날짜 축과 관련된 시간 단위 눈금은 [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/)와 [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/)이 제공합니다. 예제는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

## **축 간 데이터 전환**

[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)을(를) 사용하여 차트 데이터에서 계열과 범주 역할을 교환합니다. 이전의 각 범주는 계열이 되고, 이전의 각 계열은 범주가 됩니다. 이는 데이터 그룹화 방식을 변경하지만 가로 및 세로 축을 교환하지는 않습니다. 예제는 [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/)을(를) 사용하여 기본 데이터를 `Sheet1!A1:D5`에 바인딩하고(헤더 행 및 범주 열 포함) 행과 열을 전환합니다. 네 개의 계열과 세 개의 범주가 있는 차트를 저장합니다.

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

## **라인 차트의 세로 축 비활성화**

세로 축에 대해 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)을 `false`로 설정하여 축을 숨깁니다. 예제는 기본 데이터가 포함된 라인 차트를 생성하고 세로 축을 숨긴 상태로 저장합니다.

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

## **라인 차트의 가로 축 비활성화**

가로 축에 대해 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)을 `false`로 설정하여 축을 숨깁니다. 예제는 기본 데이터가 포함된 라인 차트를 생성하고 가로 축을 숨긴 상태로 저장합니다.

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

## **범주 축 변경**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)을 설정하여 날짜 또는 텍스트 범주 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `ExistingChart.pptx`가 필요하며, 범주 셀에 숫자형 Excel 날짜 값이 포함되어 있습니다. 가로 축을 날짜 축으로 변경합니다. [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/)을 `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/)을 `1`, 그리고 [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/)을 월 단위로 설정하면 주요 눈금이 한 달 간격으로 배치됩니다.

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

## **범주 축 레이블 간격 제어**

차트에 많은 범주가 있는 경우 범주 또는 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/)을 `false`로 설정한 다음, 원하는 범주 간격으로 [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/)을 설정합니다. 텍스트 범주의 경우 일반 순서대로 첫 번째 범주부터 계산이 시작됩니다.

| 간격 | 예제에서 표시된 레이블 |
| --- | --- |
| `1` | 카테고리 1, 카테고리 2, 카테고리 3, ... 카테고리 24 |
| `2` | 카테고리 1, 카테고리 3, 카테고리 5, ... 카테고리 23 |
| `3` | 카테고리 1, 카테고리 4, 카테고리 7, ... 카테고리 22 |

`3` 간격은 매 세 번째 레이블만 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 해당 열은 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하는 것은 아닙니다.

눈금은 별도의 제어 옵션이 있습니다. [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/)을 `false`로 설정하고 [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/)을 사용하여 눈금 간격을 지정합니다. 예를 들어 `1`은 각 범주 간격마다 눈금을 유지하지만 레이블은 매 세 번째 범주에만 표시됩니다. 눈에 보이도록 [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/)을 가시적인 스타일로 설정합니다. 자동 간격 속성을 다시 `true`로 설정하면 차트가 해당 간격을 다시 선택합니다.

다음 독립형 예제는 24개의 범주와 하나의 계열을 만든 다음 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 레이블 간격을 수동으로 지정하고 눈금을 독립적으로 유지하는 경우, 그리고 자동 간격을 복원한 경우. 두 사본은 원본 차트 데이터를 보존합니다. 입력 프레젠테이션은 필요하지 않으며, 가로 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

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

// 슬라이드 2: 매 세 번째 레이블을 표시하지만 각 범주마다 눈금을 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 범주 레이블이 표시되고 두 줄로 자동 줄바꿈됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![24개의 모든 열이 표시된 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째마다 레이블이 한 줄에 표시되고 눈금은 각 범주 간격마다 유지됩니다. 레이블이 없는 24개의 열도 동일한 값으로 표시됩니다. 슬라이드 3은 위에서 보여진 자동 모양을 복원합니다.

![세 번째 간격의 수동 범주 레이블 간격, 24개의 모든 열이 표시됨](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 열, 라인, 영역 또는 막대 차트의 범주 축)에서 이 범주 개수 간격을 사용합니다. 열 차트에서는 가로 축이 됩니다. 가로 막대 차트에서는 범주 축이 세로이므로 이러한 설정을 [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)에 적용합니다. 눈금 간격은 계열 축이 있는 차트에도 적용됩니다.

범주 레이블 간격을 값 축의 숫자 스케일을 설정하는 데 사용하지 마십시오. 값 축에서 [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/)은 값 차이를 지정합니다. 예를 들어 `10`의 주요 단위는 축이 0에서 시작할 때 0, 10, 20 등으로 눈금을 배치합니다. `3`의 범주 레이블 간격은 데이터 값과 무관하게 범주 위치를 기준으로 계산합니다. 산점도 및 버블 차트는 텍스트 범주 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [Change a Category Axis](#change-a-category-axis)에서 설명한 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제는 기본 차트 데이터를 네 개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장됩니다. [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)을 날짜 축으로 설정하고, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)를 비활성화한 뒤, [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)에 `yyyy`를 할당하면 셀 서식과 무관하게 범주 레이블에 네 자리 연도가 표시됩니다.

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

## **차트 축 제목의 회전 각도 설정**

세로 축에 [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)을 활성화하고 제목 텍스트를 제공한 뒤, [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/)을 설정하여 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전한 열 차트를 저장합니다.

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

## **범주 또는 값 축에서 축 위치 설정**

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/)을 사용하여 값 축이 범주 축을 범주 사이에 교차할지 범주 눈금에 교차할지를 제어합니다. 이 속성은 범주 축에 적용됩니다. 예제는 열 차트의 가로 범주 축에 대해 이를 `true`로 설정하고 결과를 저장합니다.

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

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/)을 설정하면 기본 데이터를 변경하지 않고 값 축 레이블을 확대/축소할 수 있습니다. [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/)을 `Millions`로 지정하면 60,000,000 값이 60으로 표시됩니다. 예제는 열 차트를 생성하고 세로 축에 백만 단위를 적용합니다.

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

## **FAQ**

**축이 교차하는 값을 어떻게 설정합니까(축 교차점)?**

[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)을 사용하여 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)을 설정합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동시킬 수 있습니다.

**축에 대해 눈금 레이블을 어떻게 배치합니까?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/)을 [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/)을 사용해 `Low`, `High`, `NextTo` 또는 `None` 중 하나로 설정합니다. 눈금 자체를 제어하려면 [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) 또는 [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)을 사용합니다; 이는 레이블 배치와 별개입니다.