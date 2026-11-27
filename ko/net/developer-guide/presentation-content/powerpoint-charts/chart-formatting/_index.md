---
title: .NET에서 프레젠테이션 차트 서식 지정
linktitle: 차트 서식 지정
type: docs
weight: 60
url: /ko/net/chart-formatting/
keywords:
- 차트 서식 지정
- 차트 서식
- 차트 개체
- 차트 속성
- 차트 설정
- 차트 옵션
- 글꼴 속성
- 둥근 테두리
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 차트 서식 지정 방법을 배우고, 사용자 지정 축, 글꼴, 숫자 형식 및 둥근 차트 테두리를 통해 PowerPoint 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 차트를 서식 지정하는 방법을 설명합니다. 축, 눈금선, 제목, 범례, 플롯 영역 및 벽 채우기와 같은 주요 차트 요소를 사용자 지정하여 차트 데이터의 모양과 가독성을 향상시키는 방법을 보여줍니다.

또한 차트 텍스트에 대한 글꼴 속성을 설정하고, 차트 데이터에 사전 정의된 숫자 형식을 적용하며, 차트 영역에 둥근 모서리를 활성화하는 방법을 시연합니다. 이러한 예제를 통해 프레젠테이션 차트의 시각적 스타일과 데이터 표시를 모두 제어하는 방법을 확인할 수 있습니다.

상승 및 하락 구간에 대해 별도의 채우기와 윤곽선을 적용하려면 [stock chart example](/slides/ko/net/create-chart/#create-stock-charts)를 참조하십시오.

## **Format Chart Entities**

[IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/)을 사용하여 차트 제목, 축, 눈금선, 범례 및 플롯 영역을 서식 지정합니다. 이 예제는 기본 데이터와 마커가 있는 라인 차트를 만든 다음 값 축과 범주 축에 대해 별도의 텍스트 및 선 스타일을 적용합니다. 글꼴 크기와 선 두께는 포인트 단위로 지정되며, 범주 레이블은 45도 회전됩니다.

값 축은 소스 셀과 무관하게 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/)을 사용합니다. 눈금은 -2에서 15까지이며, 주요 간격은 2, 보조 간격은 0.5입니다. 이 예제는 또한 백분율 서식을 [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/)을 천 단위로 설정한 것과 결합하므로 데이터의 의미와 규모에 맞게 이러한 설정을 조정하십시오. 범례는 [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/)가 비활성화되어 플롯 영역 외부에 배치됩니다. 백월과 바닥 채우기는 [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) 및 [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/)을 통해 구성되지만, 이러한 표면은 3D 차트에서만 표시됩니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Set Font Properties for a Chart**

[Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/)을 통해 차트 텍스트의 기본 글꼴 크기를 설정합니다. 이 예제는 20포인트 글꼴을 사용하는 클러스터형 열 차트를 만들고 [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)를 사용하여 첫 번째 시리즈에 값 레이블을 활성화합니다. 자체 명시적 글꼴 설정이 있는 텍스트 요소는 차트 기본값을 재정의할 수 있습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Reuse Text Frame Formatting for a Chart Legend**

범례를 슬라이드 제목에 맞추려면 첫 번째 단락의 [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/)에 글꼴을 설정합니다. 범례의 [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/)에 대해 [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/)를 호출합니다. 이 메서드는 텍스트 프레임 설정, 첫 번째 단락의 서식, 해당 단락의 기본 글꼴 속성을 읽어옵니다. 개별 부분이나 이후 단락에 직접 적용된 서식은 원본에 국한됩니다.

예제는 네이비 색상의 26포인트 Calibri 굵은 제목을 템플릿으로 사용합니다. 범례 스타일을 적용한 후 [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/)를 사용하여 동일한 서식을 별도의 캡션에 적용합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

저장된 프레젠테이션에서 범례와 캡션은 크기, 두께, 색상 면에서 제목과 일치합니다. 범례는 여전히 시리즈 이름을 표시하고, 캡션은 자체 텍스트를 유지합니다. 캡션의 일부 부분에 명시적 글꼴 크기가 이미 지정된 경우, 해당 크기가 복사된 단락 기본값보다 우선합니다.

| 복사 전 | 복사 후 |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **Set the Numeric Format**

[IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/)을 사용하여 차트 워크북 셀에 내장 숫자 형식을 적용합니다. 이 예제는 기본 셀 기반 데이터가 있는 클러스터형 열 차트를 만들고 각 시리즈 값 셀에 형식 인덱스 10(`0.00%`)을 적용합니다. 이렇게 하면 기본 숫자를 변경하지 않고 워크북에 표시되는 값이 변경됩니다(예: 0.25가 25.00%로 표시). 축 및 데이터 레이블 형식은 별도로 구성할 수 있습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

다음 표는 미국 영어 로케일에 대한 대표적인 Excel 형식과 함께 내장 숫자 형식 인덱스를 나열합니다. 정확한 형식 문자열과 표시 방식은 애플리케이션 및 로케일에 따라 다를 수 있으며, 특히 통화와 날짜 형식이 그렇습니다. 일부 Excel 형식은 OOXML 표준의 기본값과도 다를 수 있으며, 이는 [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)에서 설명합니다.

| 인덱스 | 형식 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Set Chart Area Rounded Borders**

[IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/)를 활성화하여 차트 영역의 모서리를 둥글게 합니다. 이 예제는 클러스터형 열 차트를 만든 다음 [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/)을 사용해 외곽선을 단색 회색 및 단일 선 스타일로 지정하고 프레젠테이션을 저장합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Edit Existing Chart Annotations**

차트에는 보고서 상태를 설명하는 텍스트 주석과 같은 사용자 정의 도형이 포함될 수 있습니다. 이러한 도형은 [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/)를 통해 액세스할 수 있으며, 차트 API 참조의 [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/)에도 나열됩니다. 차트가 소유한 도형은 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) 컬렉션에 포함됩니다.

차트 위에 배치된 일반 텍스트 상자는 차트의 일부처럼 보이더라도 슬라이드에 속합니다. [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)를 순회하면 차트와 일반 슬라이드 도형을 찾을 수 있지만 차트 내부의 개별 도형은 열거되지 않습니다. 차트 제목과 데이터 레이블은 별도의 차트 요소이며, 이 컬렉션의 사용자 정의 주석이 아닙니다.

[chart-annotations.pptx](chart-annotations.pptx)를 다운로드하고 응용 프로그램 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 "Preliminary results"라는 주석, 차트가 소유한 선, 그리고 "Slide overlay"라는 텍스트가 있는 일반 슬라이드 텍스트 상자가 포함된 차트가 있습니다. 예제는 해당 슬라이드에서 첫 번째 차트를 찾아 보고서를 게시할 준비가 되면 주석을 "Final results"로 변경합니다. 빈 컬렉션을 확인하고, [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 중 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/)이 널이 아니며 예상 텍스트를 가진 도형만 편집합니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

선과 슬라이드 텍스트 상자는 변경되지 않은 상태로 남습니다. 다음 이미지에서 입력 파일과 저장 후 다시 연 결과를 확인하십시오:

| 편집 전 | 편집 후 |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
예제는 최상위 차트 소유 도형만 검사합니다. 주석이 [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) 내부에 있는 경우 해당 그룹의 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) 컬렉션도 검사하십시오. 중첩된 그룹에 대해서는 이 과정을 재귀적으로 반복하고, 자식 도형에 동일한 텍스트 검사를 적용합니다. 그룹 자체는 컨테이너이며 텍스트 상자로 취급하지 마십시오.
{{% /alert %}}

## **FAQ**

**Can I set semi-transparent fills for columns/areas while keeping the border opaque?**  
예. 채우기 투명도와 외곽선은 별도로 구성됩니다. 이는 격자와 데이터가 밀집된 시각화에서 가독성을 높이는 데 유용합니다.

**How can I deal with data labels when they overlap?**  
글꼴 크기를 줄이거나, 필요 없는 레이블 구성 요소(예: 범주)를 비활성화하고, 레이블 위치를 조정하거나, 필요한 경우 선택한 포인트에만 레이블을 표시하거나, 형식을 "값 + 범례"로 전환하십시오.

**Can I apply gradient or pattern fills to series?**  
예. 시리즈는 단색, 그라디언트 및 패턴 채우기를 지원합니다. 실제 사용 시 그라디언트는 최소화하고, 격자와 텍스트 대비를 떨어뜨리는 조합은 피하십시오.