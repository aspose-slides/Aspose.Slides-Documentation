---
title: Aspose.Slides for .NET 16.1.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}}

이 페이지에서는 Aspose.Slides for .NET 16.1.0 API와 함께 도입된 모든 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) 클래스, 메서드, 속성 등 및 기타 변경 사항을 나열합니다.

{{% /alert %}}
## **공개 API 변경 사항**

#### **Property RotationAngle 가 IChartTextBlockFormat 및 ITextFrameFormat 인터페이스에 추가되었습니다**
Property RotationAngle는 인터페이스 Aspose.Slides.Charts.IChartTextBlockFormat와 Aspose.Slides.ITextFrameFormat에 추가되었습니다.
이는 경계 상자 내 텍스트에 적용되는 사용자 정의 회전을 지정합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}
```
#### **OdpException이 Aspose.Slides.Odp에서 Aspose.Slides 네임스페이스로 이동했습니다**