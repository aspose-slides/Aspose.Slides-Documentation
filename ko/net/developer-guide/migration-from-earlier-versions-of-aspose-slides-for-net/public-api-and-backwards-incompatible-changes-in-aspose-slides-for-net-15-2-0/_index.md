---
title: Aspose.Slides for .NET 15.2.0의 공용 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- 마이그레이션
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 모던 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공용 API 업데이트와 중단되는 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지에서는 Aspose.Slides for .NET 15.2.0 API에 도입된 모든 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) 클래스, 메서드, 속성 등을 나열하고, 기타 변경 사항을 제공합니다.

{{% /alert %}} 
## **공용 API 변경 사항**
#### **AddDataPointForDoughnutSeries 메서드가 추가되었습니다**
IChartDataPointCollection.AddDataPointForDoughnutSeries() 메서드의 두 가지 오버로드가 추가되어 도넛 차트 유형의 시리즈에 데이터 포인트를 추가할 수 있습니다.
#### **Aspose.Slides.SmartArt.SmartArtShape 클래스가 Aspose.Slides.GeometryShape 클래스로부터 상속되었습니다**
Aspose.Slides.SmartArt.SmartArtShape 클래스가 Aspose.Slides.GeometryShape 클래스에서 상속되었습니다. 이 변경으로 Aspose.Slides 객체 모델이 개선되고 SmartArtShape 클래스에 새로운 기능이 추가되었습니다.
#### **인덱스로 차트 데이터 포인트 및 차트 카테고리를 제거하는 메서드가 추가되었습니다**
IChartDataPointCollection.RemoveAt(int index) 메서드가 추가되어 인덱스로 차트 데이터 포인트를 제거할 수 있습니다.  
IChartCategoryCollection.RemoveAt(int index) 메서드가 추가되어 인덱스로 차트 카테고리를 제거할 수 있습니다.
#### **PptXPptY 값이 Aspose.Slides.Animation.PropertyType 열거형에 추가되었습니다**
직렬화 문제 해결을 위해 Aspose.Slides.Animation.PropertyType 열거형에 PptXPptY 값이 추가되었습니다.
#### **System.Drawing.Color GetAutomaticSeriesColor() 메서드가 Aspose.Slides.Charts.IChartSeries에 추가되었습니다**
GetAutomaticSeriesColor 메서드는 시리즈 인덱스와 차트 스타일을 기반으로 자동 색상을 반환합니다. FillType이 NotDefined인 경우 기본적으로 이 색상이 사용됩니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```