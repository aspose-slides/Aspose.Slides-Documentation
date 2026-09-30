---
title: ".NET에서 프레젠테이션의 차트 범례 사용자 지정"
linktitle: "차트 범례"
type: docs
url: /ko/net/chart-legend/
keywords:
- "차트 범례"
- "범례 위치"
- "글꼴 크기"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET을 사용하여 차트 범례를 사용자 지정하고 맞춤형 범례 서식으로 PowerPoint 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides for .NET은 PowerPoint 프레젠테이션에서 차트 범례를 사용자 지정할 수 있는 옵션을 제공합니다. 이 문서에서는 범례의 위치와 크기를 지정하고, 전체 범례의 글꼴 크기를 설정하고, 개별 범례 항목을 서식 지정하며, 선택한 항목을 숨기거나 복원하는 방법을 보여줍니다.

FAQ에서는 범례에 대한 공간을 확보하고, 다중 행 레이블을 표시하며, 프레젠테이션 테마에서 서식을 상속받는 등 관련 동작을 다룹니다.

## **범례 위치 지정**

범례의 [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), 및 [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) 속성을 사용하여 차트 크기의 비율로 위치와 크기를 지정합니다.

이 예제는 프레젠테이션을 만든 다음 첫 번째 슬라이드에 기본 데이터를 가진 클러스터형 열 차트를 추가합니다. 원하는 범례 오프셋 및 차원 값을 차트의 너비와 높이로 나누어 상대값으로 변환합니다: 범례는 차트의 왼쪽 상단 모서리에서 50 포인트만큼 오프셋되고 크기는 100 × 100 포인트입니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **범례의 글꼴 크기 설정**

범례의 [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/)를 사용하여 텍스트 서식에 접근하고, [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)를 포인트 단위로 설정합니다.

이 예제는 기본 데이터를 가진 차트를 생성하고 범례 텍스트를 20 포인트로 설정합니다. 또한 수직 축에 대한 자동 경계를 비활성화하고 범위를 -5에서 10으로 설정합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **개별 범례 항목의 글꼴 크기 설정**

범례의 [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) 컬렉션을 사용하여 특정 항목의 서식에 접근합니다. 항목 인덱스는 0부터 시작하므로 인덱스 `1`은 두 번째 항목을 의미합니다.

이 예제는 기본 데이터에 최소 두 개의 시리즈가 포함된 클러스터형 열 차트를 생성합니다. 두 번째 범례 항목을 굵게, 기울임꼴 및 20포인트 파란색 텍스트로 서식 지정합니다.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **개별 범례 항목 숨기기**

보조 시리즈를 데이터는 표시하면서 범례에서 제외하려면, [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/)를 통해 [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/)를 `true`로 설정합니다. 이렇게 하면 선택된 범례 항목만 숨겨지고 시리즈나 데이터 포인트는 제거되지 않습니다. 반대로 [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/)를 `false`로 설정하면 전체 범례가 숨겨집니다.

아래 예제는 기본 데이터를 사용하여 여러 시리즈가 포함된 클러스터형 열 차트를 만들고, 두 번째 시리즈의 범례 항목(인덱스 `1`)을 숨긴 뒤 프레젠테이션을 저장합니다. 그런 다음 `Hide`를 `false`로 설정하여 항목을 복원하고 두 번째 사본을 저장합니다. 두 파일 모두에서 열은 여전히 표시됩니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// 차트 데이터를 변경하지 않고 동일한 항목을 복원합니다.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

아래 비교는 모든 항목이 표시된 차트와 두 번째 항목이 숨겨진 차트를 보여줍니다. 두 번째 시리즈의 열은 변경되지 않습니다.

![모든 범례 항목이 표시되고 Series 2가 범례에서 숨겨진 차트 비교; 모든 열이 계속 표시됩니다.](hide-legend-entry.png)

컬럼, 바, 라인 차트에서는 범례 항목이 시리즈를 식별합니다. 파이 차트에서는 개별 데이터 포인트(슬라이스)를 식별하므로 선택한 슬라이스에 대해 [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/)를 사용합니다. API는 `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, `BarOfPie` 차트 유형에 대해 이 데이터 포인트 속성을 문서화합니다. 이 목록에 포함되지 않은 도넛 차트에는 적용되지 않는다고 가정하지 마세요.

## **FAQ**

**차트가 범례 위에 겹치지 않고 범례를 위한 공간을 할당하도록 할 수 있나요?**  
예. [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/)를 `false`로 설정하면 범례가 플롯 영역과 겹치지 않고 공간을 확보하도록 할 수 있습니다.

**다중 행 범례 레이블을 만들 수 있나요?**  
예. 사용 가능한 너비가 부족할 경우 긴 레이블이 자동으로 줄 바꿈됩니다. 시리즈 이름에 개행 문자를 삽입하여 줄 바꿈을 요구할 수도 있습니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르게 하려면 어떻게 해야 하나요?**  
범례의 색상, 채우기 및 글꼴을 설정하지 않으면 테마 서식을 상속받습니다. 명시적인 서식은 해당 테마 설정을 덮어씁니다.