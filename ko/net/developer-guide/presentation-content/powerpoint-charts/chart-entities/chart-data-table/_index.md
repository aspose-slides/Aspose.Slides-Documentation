---
title: .NET에서 프레젠테이션의 차트 데이터 테이블 사용자 지정
linktitle: 데이터 테이블
type: docs
url: /ko/net/chart-data-table/
keywords:
- 차트 데이터
- 데이터 테이블
- 글꼴 속성
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 및 C#를 사용하여 PowerPoint 프레젠테이션에서 차트 데이터 테이블의 글꼴, 테두리 및 범례 키를 사용자 지정합니다."
---
## **개요**

Aspose.Slides for .NET을 사용하면 차트의 데이터 표를 표시하고 텍스트 서식, 테두리 및 범례 키를 사용자 지정할 수 있습니다. 이 문서에서는 표를 활성화하고, 텍스트를 서식 지정하며, 각 종류의 테두리를 제어하고, 범례 키를 표시하거나 숨기는 방법을 설명합니다. 예제에서는 구성된 차트를 PPTX 파일로 저장합니다.

## **글꼴 속성 설정**

차트의 데이터 표를 표시하려면 [HasDataTable](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chart/hasdatatable/) 를 `true` 로 설정합니다. [ChartDataTable](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chart/chartdatatable/) 을 사용하여 표에 접근하고 텍스트 서식을 구성합니다.

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 사용하여 로드합니다.
1. 첫 번째 슬라이드에 클러스터형 열 차트를 추가합니다.
1. 차트의 데이터 표를 활성화합니다.
1. [FontBold](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/fontbold/) 로 굵은 텍스트를 활성화하고, [FontHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/fontheight/) 를 `20` 으로 설정하여 20포인트 텍스트를 지정합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 예제는 작업 디렉터리에 최소 한 개 슬라이드가 포함된 `test.pptx` 파일이 필요합니다. 위치 (50, 50)에 기본 데이터가 있는 차트를 추가하고 너비 600 포인트, 높이 400 포인트로 설정합니다. 저장된 `output.pptx` 에는 데이터 표가 활성화되고 지정된 글꼴 설정이 적용된 차트가 포함됩니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **데이터 표 테두리 사용자 지정**

[IChart.HasDataTable](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/hasdatatable/) 로 표를 활성화하고 [IChart.ChartDataTable](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/chartdatatable/) 을 통해 접근합니다. 세 가지 유형의 테두리를 독립적으로 제어할 수 있습니다:

- [HasBorderHorizontal](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatatable/hasborderhorizontal/) 은 가로 셀 테두리를 제어합니다.
- [HasBorderVertical](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatatable/hasbordervertical/) 은 세로 셀 테두리를 제어합니다.
- [HasBorderOutline](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatatable/hasborderoutline/) 은 표의 외곽 테두리를 제어합니다.

각 속성을 `true` 로 설정하면 해당 테두리가 표시되고 `false` 로 설정하면 숨깁니다. 다음 예제는 기본 데이터가 있는 클러스터형 열 차트를 생성하고 가로 테두리와 외곽 테두리를 표시하며 세로 테두리를 숨깁니다. 입력 파일이 필요하지 않으며 차트의 위치와 크기는 포인트 단위로 지정됩니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

아래 비교는 네 경우 모두 동일한 차트 데이터와 범례 키 설정을 사용합니다. 모든 테두리를 활성화한 상태에서 각 변형은 하나의 테두리 속성만 비활성화합니다. 왼쪽 아래 변형이 예제와 동일한 테두리 설정을 갖습니다.

![모든 테두리가 활성화된 차트 데이터 테이블, 가로 테두리 없음, 세로 테두리 없음, 외곽 테두리 없음](data-table-borders.png)

## **범례 키 표시 또는 숨기기**

범례 키는 데이터 표의 시리즈 이름 옆에 표시되는 작은 색 표시입니다. 독자는 이를 통해 각 표 행을 차트 시리즈와 일치시킬 수 있습니다. [ShowLegendKey](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatatable/showlegendkey/) 를 `true` 로 설정하면 이 표시가 나타나고 `false` 로 설정하면 숨깁니다.

차트의 별도 범례는 [IChart.HasLegend](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/haslegend/) 로 제어됩니다. 이 설정은 독립적이며, 별도 범례를 숨겨도 데이터 표 내부의 키가 숨겨지지 않으며, 표의 키를 숨겨도 별도 범례가 숨겨지지 않습니다.

다음 예제는 기본 데이터가 있는 차트를 생성하고 데이터 표를 활성화한 뒤 별도 범례를 숨기면서 내부에 범례 키를 표시합니다. 모든 표 테두리는 명시적으로 활성화됩니다. 입력 프레젠테이션이 필요하지 않으며, 표의 키만 숨기려면 `dataTable.ShowLegendKey` 를 `false` 로 변경합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

아래 비교는 같은 표를 범례 키가 활성화된 경우와 비활성화된 경우로 보여줍니다. 모든 테두리는 계속 활성화되고, 별도 차트 범례는 두 경우 모두 숨겨집니다.

![왼쪽에 범례 키가 표시되고 오른쪽에 숨겨진 차트 데이터 테이블](data-table-legend-keys.png)

## **FAQ**

**차트 데이터 표에 범례 키를 표시할 수 있나요?**

예. [ShowLegendKey](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/datatable/showlegendkey/) 를 `true` 로 설정하면 범례 키가 표시되고 `false` 로 설정하면 숨겨집니다.

**프레젠테이션을 PDF, HTML 또는 이미지로 내보낼 때 데이터 표가 유지되나요?**

예. Aspose.Slides는 차트와 표시된 데이터 표를 슬라이드의 일부로 렌더링하여 [PDF](/slides/ko/net/convert-powerpoint-to-pdf/), [HTML](/slides/ko/net/convert-powerpoint-to-html/), [images](/slides/ko/net/convert-powerpoint-to-png/) 로 내보냅니다.

**템플릿에서 로드한 차트의 데이터 표를 작업할 수 있나요?**

예. 기존 프레젠테이션이나 템플릿에서 로드한 차트의 경우, [HasDataTable](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chart/hasdatatable/) 을 사용하여 데이터 표가 표시되는지 확인하거나 변경할 수 있습니다.

**데이터 표가 활성화된 차트를 어떻게 찾을 수 있나요?**

각 슬라이드의 도형을 순회하면서 차트를 식별하고, 해당 차트의 [HasDataTable](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chart/hasdatatable/) 속성을 확인합니다. 값이 `true` 이면 데이터 표가 활성화된 것입니다.