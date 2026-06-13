---
title: Aspose.Slides for .NET 14.10.0의 공개 API 및 뒤로 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
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
description: "Aspose.Slides for .NET의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}} 

이 페이지는 Aspose.Slides for .NET 14.10.0 API와 함께 도입된, [추가된](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) 또는 [제거된](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) 클래스, 메서드, 속성 등과 기타 변경 사항을 모두 나열합니다.

{{% /alert %}} 
## **Public API 변경 사항**
#### **Aspose.Slides.FieldType.Footer 필드 유형이 추가되었습니다**
Footer 필드 유형은 이 유형의 필드를 생성할 수 있는 구현 및 유효한 프레젠테이션 직렬화를 위해 추가되었습니다.
#### **Enum 요소 ShapeElementFillSource.Own가 삭제되었습니다**
중복된 것으로 인해 Enum 요소 ShapeElementFillSource.Own가 삭제되었습니다. ShapeElementFillSource.Own 대신 ShapeElementFillSource.Shape를 사용하십시오.
#### **차트 데이터 포인트 및 카테고리 제거를 위한 메서드가 추가되었습니다**
다음 메서드들은 차트 데이터 포인트 컬렉션에서 차트 데이터 포인트를 제거할 수 있도록 추가되었습니다:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

다음 메서드는 포함된 컬렉션에서 차트 카테고리를 제거할 수 있도록 추가되었습니다:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //ChartCategory.Remove()로 제거

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //ChartCategoryCollection.Remove()로 제거

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//ChartDataPoint.Remove()로 제거

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **사용 중단된 Aspose.Slides.ParagraphFormat 속성이 제거되었습니다**
BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle 속성이 제거되었습니다. 이 속성들은 오래전에 사용 중단(Obsolete)으로 표시되었습니다.
#### **불필요하고 사용 중단된 생성자가 제거되었습니다**
다음 생성자들이 제거되었습니다:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)