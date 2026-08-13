---
title: Aspose.Slides for .NET 15.8.0의 공개 API 및 뒤로 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
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
description: "Aspose.Slides for .NET의 공개 API 업데이트와 파괴적인 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="info" %}} 
이 페이지에서는 Aspose.Slides for .NET 15.8.0 API에서 도입된 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) 혹은 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) 클래스, 메서드, 속성 등 및 기타 변경 사항을 모두 나열합니다.
{{% /alert %}} 
## **Public API Changes**
#### **Property DoughnutHoleSize Has Been Added to IChartSeries and ChartSeries**
IChartSeries 및 ChartSeries에 DoughnutHoleSize 속성이 추가되었습니다.
도넛 차트의 구멍 크기를 지정합니다.
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}
```