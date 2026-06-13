---
title: Aspose.Slides for .NET 15.11.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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
description: "Aspose.Slides for .NET의 공개 API 업데이트와 호환성 깨지는 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="primary" %}} 

이 페이지에서는 Aspose.Slides for .NET 15.11.0 API와 함께 도입된 [추가된](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) 또는 [제거된](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) 클래스, 메서드, 속성 등과 기타 변경사항을 모두 나열합니다.

{{% /alert %}} 
## **공용 API 변경사항**

#### **DataLabelCollection 클래스의 사용되지 않는 속성이 삭제되었습니다**
DataLabelCollection 클래스의 사용되지 않는 속성이 삭제되었습니다:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **Presentation 클래스에 새로운 속성 FirstSlideNumber가 추가되었습니다**
Presentation에 추가된 새로운 속성 FirstSlideNumber는 프레젠테이션의 첫 슬라이드 번호를 가져오거나 설정할 수 있게 합니다.

새로운 FirstSlideNumber 값을 지정하면 모든 슬라이드 번호가 다시 계산됩니다.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```