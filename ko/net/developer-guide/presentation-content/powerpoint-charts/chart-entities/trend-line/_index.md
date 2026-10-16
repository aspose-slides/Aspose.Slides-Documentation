---
title: .NET에서 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/net/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 멱 추세선
- 맞춤형 추세선
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 사용자 지정하십시오 — 청중을 사로잡는 실용적인 가이드."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만드는 방법, 차트 시리즈에 추세선을 추가하는 방법, 그리고 지수, 선형, 로그, 이동 평균, 다항식 및 멱형 등 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 선 모양을 삽입하여 차트에 사용자 정의 선을 추가하는 방법을 설명하고, forward와 backward 추세선 투영값 및 PDF 또는 SVG로 내보내거나 차트를 이미지로 렌더링할 때 추세선이 보존되는지에 대한 간단한 FAQ를 포함합니다.

## **추세선 추가**

차트 시리즈에 추세선을 추가하려면 [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/)을 사용하고, 유형은 [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/)으로 선택합니다. 예제는 기본 데이터로 클러스터된 열 차트를 생성하고 각 시리즈 3개에 두 개의 추세선을 추가합니다.

지수 추세선은 [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) 및 [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/)을 통해 식과 R 제곱 값을 숨기고, 선형 추세선은 빨간색입니다. 로그 추세선은 사용자 정의 레이블을 위해 [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/)을 사용합니다. 이동 평균은 세 개 데이터 포인트의 [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/)와 사용자 정의 [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/)을 사용합니다.

다항식 추세선은 [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/)가 3이며, [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/)를 통해 한 카테고리 앞으로 확장됩니다. 멱형 추세선은 [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/)를 통해 한 카테고리 뒤로 확장됩니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **추세선 절편 설정**

X = 0에서 추세선의 Y 값을 고정하려면 [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/)을 사용합니다. 이 설정은 선형, 지수 및 다항식 추세선에 지원됩니다.

예를 들어, 생산 비용 모델은 비정량 생산량에서 측정값이 다른 기준선을 제시하더라도 알려진 고정 비용 100에서 시작해야 할 수 있습니다. 선형 추세선의 경우 절편을 고정하면 방정식 `y = ax + b`가 `b = 100`이 되며, 기울기는 그 제약 하에서 데이터에 맞추어집니다. 이는 이미 맞춰진 선을 단순히 이동시키는 것이 아닙니다. 축 교차 설정은 차트 축이 만나는 위치를 제어하며, 맞춰진 추세선의 계수를 변경하지는 않습니다.

다음 예제는 생산량 1~4와 비용 170, 200, 230, 260을 갖는 산점도(XY) 차트를 생성합니다. 기본 자동 절편으로 차트를 저장하고, 절편을 100으로 설정한 뒤 두 번째 PPTX를 저장합니다. 두 파일은 절편 설정만 다릅니다. 추세선은 식을 표시하고 X = 0까지 뒤로 확장됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

자동 계산을 사용하면 이 데이터는 `y = 30x + 140`을 생성합니다. 절편을 100으로 설정하면 대략 `y = 43.33x + 100`이 됩니다: 0에서의 적합값이 알려진 기준선과 일치하지만, 선은 더 이상 모든 데이터 포인트를 통과하지 않습니다.

| 자동 절편 | 절편 100 고정 |
| --- | --- |
| ![자동으로 계산된 절편 140을 가진 선형 추세선](intercept-automatic.png) | ![절편 100을 고정한 선형 추세선](intercept-fixed.png) |

두 이미지 모두 같은 데이터와 축 눈금을 사용합니다. 추세선은 절편을 보여주기 위해 X = 0까지 뒤로 확장됩니다.

기본적으로 해당 속성은 `double.NaN`을 포함하며, 이는 0이 아닌 지정되지 않은 절편을 의미합니다. 절편은 이후 데이터에서 자동으로 계산됩니다.

## **사용자 정의 선 추가**

사용자 정의 선은 시리즈 데이터에서 계산된 추세선이 아니라 차트 위에 그려지는 도형입니다. 이 예제는 [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/)을 사용하여 차트 위 슬라이드에 수평선을 추가합니다. 선의 위치는 포인트 단위의 슬라이드 좌표로 지정되어 차트 왼쪽 가장자리에서 시작해 차트의 절반 높이 지점에 배치됩니다. 너비는 차트의 너비와 동일합니다. [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/)은 선에 단색 빨간색을 지정합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **자주 묻는 질문**

**추세선의 'forward'와 'backward'는 무엇을 의미합니까?**

이 값은 추세선을 앞으로/뒤로 투영한 길이를 나타냅니다. 산점도(XY) 차트에서는 축 단위로, 비산점도 차트에서는 카테고리 수로 표시됩니다. 음수 값은 허용되지 않습니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 보존됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/net/convert-powerpoint-to-pdf/) 또는 [SVG](/slides/ko/net/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다. 차트의 일부인 추세선은 이러한 작업 중에 보존됩니다. 또한 차트 자체의 이미지를 [차트 이미지 내보내기](/slides/ko/net/create-shape-thumbnails/)하는 메서드도 제공됩니다.