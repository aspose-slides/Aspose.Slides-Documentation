---
title: Aspose.Slides for .NET 15.2.0의 공개 API 및 뒤로 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
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
description: "Aspose.Slides for .NET에서 공개 API 업데이트 및 중단되는 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}} 
이 페이지에서는 Aspose.Slides for .NET 15.2.0 API와 함께 도입된 [추가된](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) 또는 [제거된](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) 클래스, 메서드, 속성 등과 기타 변경 사항을 모두 나열합니다.
{{% /alert %}} 
## **Public API Changes**
#### **AddDataPointForDoughnutSeries Methods Have Been Added**
IChartDataPointCollection.AddDataPointForDoughnutSeries() 메서드의 두 오버로드가 도넛 차트 유형의 시리즈에 데이터 포인트를 추가하기 위해 추가되었습니다.
#### **Aspose.Slides.SmartArt.SmartArtShape Class Has Been Inherited from Aspose.Slides.GeometryShape Class**
Aspose.Slides.SmartArt.SmartArtShape 클래스가 Aspose.Slides.GeometryShape 클래스를 상속받았습니다. 이 변경으로 Aspose.Slides 객체 모델이 개선되고 SmartArtShape 클래스에 새로운 기능이 추가됩니다.
#### **Methods for Removing Chart Data Point and Chart Category by Index Has Been Added**
IChartDataPointCollection.RemoveAt(int index) 메서드가 인덱스로 차트 데이터 포인트를 제거하기 위해 추가되었습니다.
IChartCategoryCollection.RemoveAt(int index) 메서드가 인덱스로 차트 카테고리를 제거하기 위해 추가되었습니다.
#### **PptXPptY Value Has Been Added to Aspose.Slides.Animation.PropertyType Enumeration**
PptXPptY 값이 직렬화 문제 해결의 일환으로 Aspose.Slides.Animation.PropertyType 열거형에 추가되었습니다.
#### **System.Drawing.Color GetAutomaticSeriesColor() Method Has Been Added to Aspose.Slides.Charts.IChartSeries**
GetAutomaticSeriesColor 메서드는 시리즈 인덱스와 차트 스타일을 기반으로 시리즈의 자동 색상을 반환합니다. FillType이 NotDefined인 경우 기본적으로 이 색상이 사용됩니다.
``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```