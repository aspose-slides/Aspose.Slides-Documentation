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
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에 차트 데이터 레이블을 추가하고 서식 지정하는 방법을 배우고, 보다 매력적인 슬라이드를 만들 수 있습니다."
---
## **소개**

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하는 데 도움을 줍니다. 이 문서에서는 값을 서식 지정하는 방법, 백분율을 표시하는 방법, 레이블 텍스트를 읽는 방법, 축 최대값을 초과하는 레이블을 제어하는 방법, 카테고리 축 레이블 간격을 조정하는 방법 및 파이 차트 레이블의 위치를 지정하는 방법을 설명합니다.

## **차트 데이터 레이블의 데이터 정밀도 설정**

[NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/)을 사용하여 시리즈 값을 서식 지정합니다. 이 예제는 기본 데이터를 사용하여 선 차트를 만들고, 데이터 테이블을 표시하며, 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 서식은 천 단위 구분 기호와 소수점 두 자리를 표시하지만 기본 값을 변경하지는 않습니다.

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

차트에 포함된 워크북의 숫자 셀을 서식 지정하려면 [Set Custom Number Formats for Workbook Cells](/slides/ko/net/chart-workbook/#set-custom-number-formats-for-workbook-cells)를 참조하십시오. 해당 예제에서는 소스 셀 서식을 유지하면서 저장된 숫자 값은 그대로 보존되는 상태에서 값 레이블이 해당 서식을 따르는 모습을 보여줍니다.

## **백분율을 레이블로 표시**

누적 세로 막대 차트에서 각 값을 해당 카테고리 합계에 대한 백분율로 계산하고 텍스트를 [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)에 할당합니다. 이 예제는 기본 차트 데이터를 사용하고 8포인트 글꼴에 소수점 두 자리 백분율을 표시합니다. 합계가 0인 카테고리는 나눗셈 오류를 방지하기 위해 건너뛰며, 차트 데이터가 변경되면 사용자 정의 레이블 텍스트를 다시 계산해야 합니다.

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

값이 분수 형태로 저장된 경우, [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/)을 사용하여 백분율을 표시합니다. [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/)를 `false`로 설정하면 소스 셀과 무관하게 레이블 서식이 적용됩니다.

이 예제는 네 개 카테고리와 빨강 및 파랑 시리즈가 포함된 100% 누적 세로 막대 차트를 생성합니다. 각 값 쌍은 합이 1이 됩니다. 레이블 서식 `0.0%`는 0.30을 30.0%로 표시하고, 세로 축은 소수점 두 자리로 표시합니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

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

[GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/)를 사용하여 데이터 레이블 설정에 의해 생성된 텍스트를 가져올 수 있습니다. 이는 보고서용 레이블 추출, 프레젠테이션 내용 검색 또는 생성된 차트 검증에 유용합니다. 아래 예제에서는 기본 [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/)이 각 카테고리 이름, 시리즈 이름 및 값을 결합합니다. 한 데이터 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)에서 사용자 정의 텍스트를 사용합니다.

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

데이터 포인트에 저장된 숫자는 `0.75`이며, 레이블에 `75%`와 카테고리 및 시리즈 이름이 함께 표시됩니다. 사용자 정의 텍스트가 생성된 레이블 텍스트를 대체합니다. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/)는 두 경우 모두 결과 레이블 문자열을 반환합니다. 표시 가능한 레이블만 추출하려면 위와 같이 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/)를 별도로 확인하십시오.

## **축 최대값을 초과하는 데이터 레이블 제어**

축 범위를 수동으로 제한하면 일부 데이터 포인트가 최대값을 초과할 수 있습니다. [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/)를 사용하여 해당 데이터 레이블을 표시할지 여부를 제어합니다. 이 설정은 레이블 가시성을 변경하지만 축 범위나 기본 데이터 값은 변경하지 않습니다.

아래 예제는 값이 60과 120인 2D 클러스터형 세로 막대 차트를 생성합니다. 세로 축에서 [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/)를 `false`로, [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/)를 100으로 설정합니다. 첫 번째 슬라이드는 최대값을 초과하는 레이블을 허용하고, 복사본 슬라이드는 이를 비활성화합니다. 두 슬라이드는 `DataLabelsOverMaximum.pptx` 파일에 저장됩니다.

[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)로 값 레이블을 활성화합니다. 차트 수준 설정만으로는 개별 레이블의 비활성화된 값 표시를 무시하거나 자동으로 값을 표시하지 않습니다. 이 예제는 전체 시리즈에 대해 값을 활성화하고 [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/)을 사용하여 각 열의 외측 끝에 레이블을 배치합니다.

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

다음 이미지들은 Microsoft PowerPoint에서 렌더링한 저장된 슬라이드를 보여줍니다. `true`인 경우 레이블 **120**이 상단 경계에 표시되고, `false`인 경우 숨겨집니다. 레이블 **60**은 계속 표시되며, 축 최대값은 **100**으로 유지되고 두 번째 데이터 포인트는 두 경우 모두 **120**으로 남습니다.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
이 예제는 값 축이 있는 2D 세로 막대 차트를 사용합니다. 파이 차트와 도넛 차트처럼 값 축이 없는 차트는 이와 같이 축 최대값을 제한할 수 없습니다.
{{% /alert %}}

## **축으로부터 레이블 거리 설정**

[LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/)을 사용하여 카테고리 축 레이블과 축 사이의 거리를 제어합니다. 값은 축 레이블 최대 글꼴 크기의 백분율입니다. 이 예제는 클러스터형 세로 막대 차트를 만들고 가로 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 붙은 레이블이 아니라 카테고리 축 레이블에 영향을 줍니다.

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

파이 차트에서 데이터 레이블 위치를 조정하여 간격을 개선하고 리더 라인을 위한 공간을 확보합니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고 레이블을 슬라이스 외부에 배치한 뒤, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/)와 [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) 오프셋을 조정합니다. 이러한 오프셋은 각각 차트 너비와 높이에 대한 비율로 지정됩니다.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **리더 라인 서식 지정**

파이 차트 레이블이 슬라이스 밖에 위치할 경우, 리더 라인은 각 값을 올바른 슬라이스에 매핑하는 데 도움이 됩니다. 대비되는 색상과 약간 두꺼운 선은 연결을 더 쉽게 따라갈 수 있게 하며, 투명도와 점선 스타일은 라인을 시각적으로 방해되지 않게 합니다.

[LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/)을 사용하여 시리즈 데이터 레이블 컬렉션 수준에서 리더 라인을 서식 지정합니다. `series.Labels.LeaderLinesFormat.Line`에 대한 설정은 개별 레이블이 아니라 컬렉션 전체에 적용됩니다.

이 예제는 기본 데이터를 사용한 파이 차트를 만들고, 슬라이스 외부에 값을 표시하며, [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/)을 활성화합니다. 두 레이블을 슬라이스에서 더 멀리 이동시키기 위해 차트 너비와 높이에 대한 비율로 [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/)와 [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) 오프셋을 사용합니다. 입력 프레젠테이션은 필요하지 않습니다.

라인의 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/)은 알파값 191(255 중)인 고체 파란색을 설정해 약 25% 투명도를 제공합니다. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/)은 두께를 2포인트로 지정하고, [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/)은 라인을 점선으로 만듭니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// 두 레이블을 슬라이스에서 더 멀리 이동합니다.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

리더 라인을 활성화해도 모든 레이블에 라인이 표시된다는 보장은 없습니다. 가시성은 레이블 배치와 차트 레이아웃 동작에 따라 달라집니다. 이 예제에서는 두 개의 이동된 레이블에만 리더 라인이 표시되고, 슬라이스에 가깝게 남은 레이블은 라인이 필요하지 않습니다.

다음 이미지는 Aspose.Slides로 렌더링한 저장된 `FormattedLeaderLines.pptx` 파일을 보여줍니다.

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **열 차트 위에 여러 행의 데이터 레이블 추가**

이 예제는 플롯 영역 위에 두 행의 데이터 레이블이 있는 열 차트를 생성합니다. Series A는 보이는 열을 표시하고, Series B와 Series C는 추가 레이블을 제공합니다. 이들의 열은 채우기와 윤곽선을 제거하여 숨깁니다. [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) 속성을 사용해 세 시리즈가 동일한 카테고리 중심에 정렬됩니다.

[PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) 설정은 레이블 행을 위한 공간을 예약합니다. [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/)이 기본 위치를 계산한 후, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/)와 [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/)가 수평 정렬을 유지하고 수직 오프셋을 적용해 레이블을 두 행으로 배치합니다. 숫자는 시리즈 값에 연결된 데이터 레이블이며, 행 헤더만 별도 텍스트 도형으로 존재합니다.

```csharp
using System.Drawing;
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

// 세 시리즈를 동일한 카테고리 중심에 정렬합니다.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// 이 간결한 예제에 그리드라인을 적게 사용합니다.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// 플롯 위에 두 행의 데이터 레이블을 위한 공간을 예약합니다.
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
        // 기본 수평 위치를 유지합니다. Y는 다음으로부터의 오프셋입니다.
        // 기본 레이블 위치이며, 차트 높이 비율로 표현됩니다.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // 행 제목만 별도의 텍스트 도형입니다.
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**데이터 레이블이 빽빽한 차트에서 겹치는 것을 어떻게 방지할 수 있나요?**

자동 레이블 배치, 리더 라인, 글꼴 크기 축소를 결합하고 필요에 따라 일부 필드(예: 카테고리)를 숨기거나 극값 및 핵심 포인트에만 레이블을 표시합니다.

**값이 0, 음수 또는 빈 값인 경우 레이블만 비활성화하려면 어떻게 해야 하나요?**

레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0값, 음수값 또는 누락된 값의 표시를 끕니다.

**PDF/이미지로 내보낼 때 레이블 스타일을 일관되게 유지하려면 어떻게 해야 하나요?**

글꼴 패밀리와 크기를 명시적으로 설정하고, 렌더링 환경에 해당 글꼴이 존재하는지 확인하여 대체 글꼴이 사용되지 않도록 합니다.