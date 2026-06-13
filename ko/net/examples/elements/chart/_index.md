---
title: 차트
type: docs
weight: 60
url: /ko/net/examples/elements/chart/
keywords:
- 차트
- 차트 추가
- 차트 액세스
- 차트 제거
- 차트 업데이트
- 코드 예제
- 파워포인트
- 오픈문서
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET으로 차트를 마스터하세요: 차트를 생성하고, 서식 지정하고, 데이터를 바인드하며, PPT, PPTX 및 ODP 형식으로 내보내는 C# 예제."
---
**Aspose.Slides for .NET**를 사용하여 다양한 차트 유형을 추가, 액세스, 제거 및 업데이트하는 예제입니다. 아래 스니펫은 기본 차트 작업을 보여줍니다.

## **차트 추가**

이 메서드는 첫 번째 슬라이드에 간단한 영역 차트를 추가합니다.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 첫 번째 슬라이드에 간단한 영역 차트를 추가합니다.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **차트 액세스**

차트를 만든 후에는 도형 컬렉션을 통해 차트를 가져올 수 있습니다.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // 슬라이드에 있는 첫 번째 차트에 접근합니다.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **차트 제거**

다음 코드는 슬라이드에서 차트를 제거합니다.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // 차트를 제거합니다.
    slide.Shapes.Remove(chart);
}
```

## **차트 데이터 업데이트**

제목과 같은 차트 속성을 변경할 수 있습니다.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // 차트 제목을 변경합니다.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```