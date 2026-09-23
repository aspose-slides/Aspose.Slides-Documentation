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

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하는 데 도움을 줍니다. 이 문서에서는 값 서식 지정, 백분율 표시, 레이블 텍스트 읽기, 범주 축 레이블 간격 조정 및 파이 차트 레이블 위치 지정 방법을 설명합니다.

## **차트 데이터 레이블에서 데이터 정밀도 설정**

시리즈 값을 서식 지정하려면 [NumberFormatOfValues](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/numberformatofvalues/)를 사용합니다. 이 예제는 기본 데이터를 사용하여 라인 차트를 만들고, 데이터 표를 표시하며 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 형식은 천 단위 구분 기호와 두 개의 소수점을 표시하지만 기본 값은 변경하지 않습니다.

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

## **레이블로 백분율 표시**

스택드 컬럼 차트의 경우, 각 값을 해당 범주의 전체 합계에 대한 백분율로 계산하고 텍스트를 [TextFrameForOverriding](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)에 할당합니다. 이 예제는 기본 차트 데이터를 사용하며, 8포인트 글꼴로 소수점 두 자리까지 백분율을 표시합니다. 총합이 0인 범주는 나눗셈 오류를 방지하기 위해 건너뜁니다. 차트 데이터가 변경되면 사용자 지정 레이블 텍스트를 다시 계산하십시오.

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

값이 분수로 저장된 경우, 백분율을 표시하려면 [NumberFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatalabelformat/numberformat/)을 사용합니다. 레이블 형식을 원본 셀과 독립적으로 적용하려면 [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/)를 `false`로 설정합니다.

이 예제는 네 개 범주에 걸쳐 빨간색과 파란색 시리즈가 있는 100% 스택드 컬럼 차트를 생성합니다. 각 값 쌍은 합계가 1이 됩니다. 레이블 형식 `0.0%`는 0.30을 30.0%로 표시하고, 세로 축은 소수점 두 자리로 표시합니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

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

데이터 레이블의 설정으로 생성된 텍스트를 가져오려면 [GetActualLabelText](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatalabel/getactuallabeltext/)를 사용합니다. 이 기능은 보고서를 위한 레이블 추출, 프레젠테이션 내용 검색, 또는 생성된 차트 검증에 유용합니다. 아래 예제에서는 기본 [data label format](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatalabelformat/)이 각 범주 이름, 시리즈 이름 및 값을 결합합니다. 한 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [TextFrameForOverriding](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)에서 가져온 사용자 지정 텍스트를 사용합니다.

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

데이터 포인트에 저장된 숫자는 `0.75`이며, 레이블에 `75%`와 범주 및 시리즈 이름이 표시되더라도 그대로 유지됩니다. 사용자 지정 텍스트는 생성된 레이블 텍스트를 대체합니다. [GetActualLabelText](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatalabel/getactuallabeltext/)은 두 경우 모두 결과 레이블 문자열을 반환합니다. 위와 같이 보이는 레이블만 추출하려면 [IsVisible](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatalabel/isvisible/)를 별도로 확인하십시오.

## **축으로부터 레이블 거리 설정**

[LabelOffset](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/iaxis/labeloffset/)을 사용하여 범주 축 레이블과 축 사이의 거리를 제어합니다. 값은 축 레이블의 최대 글꼴 크기의 백분율입니다. 이 예제는 클러스터드 컬럼 차트를 만들고 가로 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 부착된 레이블이 아니라 범주 축 레이블에 영향을 줍니다.

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

파이 차트에서 데이터 레이블 위치를 조정하여 간격을 개선하고 리더 라인에 여유를 만듭니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고 레이블을 조각 외부에 배치하며 [X](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ilayoutable/x/) 및 [Y](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ilayoutable/y/) 오프셋을 조정합니다. 이러한 오프셋은 각각 차트 너비와 높이에 대한 상대값입니다.

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

![조정된 데이터 레이블 위치가 적용된 파이 차트](pie-chart-adjusted-label.png)

## **FAQ**

**데이터 레이블이 복잡한 차트에서 겹치는 것을 어떻게 방지할 수 있나요?**

자동 레이블 배치, 리더 라인, 및 폰트 크기 축소를 결합하십시오; 필요하면 일부 필드(예: 범주)를 숨기거나 극값 또는 핵심 포인트에 대해서만 레이블을 표시하십시오.

**0, 음수 또는 빈 값에 대해서만 레이블을 비활성화하려면 어떻게 해야 하나요?**

레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0 값, 음수 값 또는 누락된 값에 대한 표시를 끕니다.

**PDF/이미지로 내보낼 때 일관된 레이블 스타일을 보장하려면 어떻게 해야 하나요?**

글꼴 패밀리와 크기를 명시적으로 설정하고, 대체 글꼴 사용을 방지하려면 렌더링 환경에 해당 글꼴이 존재하는지 확인하십시오.