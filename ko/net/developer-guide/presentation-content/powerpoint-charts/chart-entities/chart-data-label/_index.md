---
title: .NET에서 프레젠테이션의 차트 데이터 레이블 관리
linktitle: 데이터 레이블
type: docs
url: /ko/net/chart-data-label/
keywords:
- 차트
- 데이터 레이블
- 데이터 정밀도
- 백분율
- 레이블 거리
- 레이블 위치
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PowerPoint 프레젠테이션에 Aspose.Slides for .NET을 사용하여 차트 데이터 레이블을 추가하고 형식화하여 보다 매력적인 슬라이드를 만드는 방법을 배우세요."
---
## **소개**

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하도록 돕습니다. 이 문서에서는 값 형식 지정, 백분율 표시, 레이블 텍스트 읽기, 축 최대값을 초과한 레이블 제어, 범주 축 레이블 간격 조정 및 파이 차트 레이블 위치 지정 방법을 설명합니다.

## **차트 데이터 레이블에서 데이터 정밀도 설정**

시리즈 값을 형식 지정하려면 [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/)를 사용합니다. 이 예제는 기본 데이터로 선 차트를 만들고, 데이터 테이블을 표시하며, 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 형식은 천 단위 구분 기호와 두 개의 소수점을 표시하지만 기본 값은 변경하지 않습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **라벨로 백분율 표시**

누적 컬럼 차트에서 각 값을 해당 범주의 총합에 대한 백분율로 계산하고 텍스트를 [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)에 할당합니다. 이 예제는 기본 차트 데이터를 사용하고 8포인트 글꼴로 소수점 두 자리까지 백분율을 표시합니다. 총합이 0인 범주는 나눗셈 오류를 방지하기 위해 건너뜁니다. 차트 데이터가 변경되면 사용자 지정 레이블 텍스트를 다시 계산해야 합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **차트 데이터 레이블에 백분율 기호 설정**

값이 분수로 저장된 경우, 백분율을 표시하려면 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/)을 사용합니다. 레이블 형식을 원본 셀과 독립적으로 적용하려면 [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/)을 `false`로 설정합니다.

이 예제는 네 개 범주에 걸쳐 빨강 및 파랑 시리즈가 포함된 100% 누적 컬럼 차트를 만듭니다. 각 값 쌍은 1이 되도록 합산됩니다. 레이블 형식 `0.0%`는 0.30을 30.0%로 표시하고, 수직 축은 두 자리 소수점을 사용합니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **데이터 레이블의 실제 텍스트 읽기**

[GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/)를 사용하여 데이터 레이블 설정에 의해 생성된 텍스트를 가져옵니다. 이는 보고서를 위한 레이블 추출, 프레젠테이션 내용 검색 또는 생성된 차트 검증에 유용합니다. 아래 예제에서 기본 [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/)은 각 범주 이름, 시리즈 이름 및 값을 결합합니다. 한 포인트는 값을 백분율로 형식 지정하고, 다른 포인트는 [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)의 사용자 지정 텍스트를 사용합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

데이터 포인트에 저장된 숫자는 `0.75`이며, 레이블에 `75%`와 범주 및 시리즈 이름이 표시되더라도 그대로 유지됩니다. 사용자 지정 텍스트는 생성된 레이블 텍스트를 대체합니다. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/)은 두 경우 모두 결과 레이블 문자열을 반환합니다. 표시된 레이블만 추출하려면 위와 같이 별도로 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/)을 확인하십시오.

## **축 최대값을 초과한 데이터 레이블 제어**

축 범위를 수동으로 제한하면 일부 데이터 포인트가 최대값을 초과할 수 있습니다. [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/)을 사용하여 해당 데이터 레이블을 표시할지 여부를 제어합니다. 이 설정은 레이블 가시성을 변경하지만 축 범위나 기본 데이터 값은 변경하지 않습니다.

아래 예제는 60과 120 값을 가진 2D 클러스터형 컬럼 차트를 만들고, 수직 축에 대해 [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/)을 `false`로, [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/)을 100으로 설정합니다. 첫 번째 슬라이드는 최대값을 초과한 레이블을 허용하고, 해당 슬라이드 복사본은 이를 비활성화합니다. 두 슬라이드 모두 `DataLabelsOverMaximum.pptx` 파일에 저장됩니다.

[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)를 사용하여 값 레이블을 활성화합니다. 차트 수준 설정만으로 값 표시가 자동으로 활성화되지는 않으며 개별 레이블의 비활성화된 값 표시를 재정의하지도 않습니다. 이 예제는 전체 시리즈에 대해 값을 활성화하고 [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/)을 사용해 각 컬럼 외부 끝에 레이블을 배치합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

다음 이미지들은 Microsoft PowerPoint에서 렌더링된 저장된 슬라이드를 보여줍니다. `true`인 경우 레이블 **120**이 상단 경계에 표시되고, `false`인 경우 숨겨집니다. 레이블 **60**은 계속 표시되며, 축 최대값은 **100**으로 유지되고, 두 번째 데이터 포인트는 두 경우 모두 **120**으로 유지됩니다.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
이 예제는 값 축이 있는 2D 컬럼 차트를 사용합니다. 파이 차트 및 도넛 차트와 같이 값 축이 없는 차트는 이러한 방식으로 제한할 축 최대값이 없습니다.
{{% /alert %}}

## **축으로부터 레이블 거리 설정**

[LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/)을 사용하여 범주 축 레이블과 축 사이의 거리를 제어합니다. 값은 축 레이블 최대 글꼴 크기의 백분율입니다. 이 예제는 클러스터형 컬럼 차트를 만들고 수평 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 붙은 레이블이 아니라 범주 축 레이블에 영향을 줍니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **레이블 위치 조정**

파이 차트에서 데이터 레이블 위치를 조정하여 간격을 개선하고 리더 라인 공간을 확보합니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고, 레이블을 조각 외부에 배치하며, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/)와 [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) 오프셋을 조정합니다. 이러한 오프셋은 차트 너비와 높이에 각각 상대적입니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![조정된 데이터 레이블 위치가 있는 파이 차트](pie-chart-adjusted-label.png)

## **컬럼 차트 위에 여러 행의 데이터 레이블 추가**

이 예제는 플롯 영역 위에 두 행의 데이터 레이블이 있는 컬럼 차트를 생성합니다. Series A는 표시되는 컬럼을 보여주고, Series B와 Series C는 추가 레이블을 제공합니다. 해당 컬럼은 채우기와 윤곽을 제거하여 숨깁니다. [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) 속성은 세 시리즈를 동일한 범주 중심에 맞춥니다.

[PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) 설정은 레이블 행을 위한 공간을 확보합니다. [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/)이 기본 위치를 계산한 후, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/)와 [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/)는 수평 정렬을 유지하고 수직 오프셋을 적용하여 레이블을 두 행으로 배치합니다. 숫자는 시리즈 값에 연결된 데이터 레이블로 남아 있으며, 행 머리글만 별도의 텍스트 도형입니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // B와 C의 열을 숨기되 데이터 레이블은 유지합니다.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Align all three series with the same category centers.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Use fewer gridlines for this compact example.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Reserve space above the plot for two rows of data labels.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // 기본 수평 위치를 유지합니다. Y는
        // 기본 레이블 위치에서 차트 높이 비율로 표현된 오프셋입니다.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // 행 머리글만 별도의 텍스트 도형입니다.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![플롯 영역 위에 두 행의 데이터 레이블이 있는 컬럼 차트](multiple-rows-of-labels.png)

## **FAQ**

**조밀한 차트에서 데이터 레이블이 겹치는 것을 어떻게 방지할 수 있나요?**  
자동 레이블 배치, 리더 라인 및 글꼴 크기 축소를 결합합니다; 필요하면 일부 필드(예: 범주)를 숨기거나 극값 및 핵심 포인트에만 레이블을 표시합니다.

**0, 음수 또는 빈 값에 대해서만 레이블을 비활성화하려면 어떻게 해야 하나요?**  
레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0, 음수 또는 누락된 값에 대한 표시를 끕니다.

**PDF/이미지로 내보낼 때 일관된 레이블 스타일을 보장하려면 어떻게 해야 하나요?**  
글꼴 패밀리와 크기를 명시적으로 설정하고, 렌더링 환경에서 해당 글꼴이 사용 가능한지 확인하여 대체가 발생하지 않도록 합니다.