---
title: Aspose.Slides for .NET 15.5.0의 공개 API 및 이전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
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
description: "Aspose.Slides for .NET의 공개 API 업데이트와 파괴적인 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="primary" %}} 

이 페이지에서는 Aspose.Slides for .NET 15.5.0 API와 함께 도입된 모든 [추가된](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) 또는 [제거된](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) 클래스, 메서드, 속성 등과 기타 변경 사항을 나열합니다.

{{% /alert %}} 
## **공개 API 변경 사항**
#### **CommonSlideViewProperties Class와 ICommonSlideViewProperties Interface가 추가되었습니다**
Aspose.Slides.CommonSlideViewProperties 클래스와 Aspose.Slides.ICommonSlideViewProperties 인터페이스는 공통 슬라이드 보기 속성(현재는 보기 확대/축소 옵션)을 나타냅니다.
#### **IAxis.LabelOffset Property가 추가되었습니다**
IAxis.LabelOffset 속성은 축에서 레이블까지의 거리를 지정합니다. 카테고리 축 또는 날짜 축에 적용됩니다.
#### **IChartTextBlockFormat.AutofitType Property가 추가되었습니다**
이 속성을 변경하면 차트의 특정 부분, 즉 DataLabel 및 DataLabelFormat에만 영향을 줄 수 있습니다(PowerPoint 2013에서는 전체 지원; PowerPoint 2007에서는 렌더링에 영향을 주지 않음).
#### **IChartTextBlockFormat.WrapText Property가 추가되었습니다**
이 속성을 변경하면 차트의 특정 부분, 즉 DataLabel 및 DataLabelFormat에만 영향을 줄 수 있습니다(PowerPoint 2007/2013에서 전체 지원).
#### **Margin Properties가 IChartTextBlockFormat에 추가되었습니다**
이 속성을 변경하면 차트의 특정 부분, 즉 DataLabel 및 DataLabelFormat에만 영향을 줄 수 있습니다(PowerPoint 2013에서는 전체 지원; PowerPoint 2007에서는 렌더링에 영향을 주지 않음).
#### **ViewProperties.NotesViewProperties Property가 추가되었습니다**
Aspose.Slides.ViewProperties.NotesViewProperties 속성이 추가되었습니다. 이는 노트 보기 모드와 관련된 공통 보기 속성을 지정합니다.
#### **ViewProperties.SlideViewProperties Property가 추가되었습니다**
Aspose.Slides.ViewProperties.SlideViewProperties 속성이 추가되었습니다. 이는 슬라이드 보기 모드와 관련된 공통 보기 속성을 지정합니다.