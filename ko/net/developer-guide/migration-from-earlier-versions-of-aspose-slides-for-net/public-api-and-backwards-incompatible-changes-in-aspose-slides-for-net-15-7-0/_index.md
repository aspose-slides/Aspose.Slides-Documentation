---
title: Aspose.Slides for .NET 15.7.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
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
description: "Aspose.Slides for .NET의 공개 API 업데이트와 호환성 파괴 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}} 

이 페이지는 Aspose.Slides for .NET 15.7.0 API에 도입된 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) 클래스, 메서드, 속성 등을 모두 나열하고 기타 변경 사항을 보여줍니다.

{{% /alert %}} 
## **공용 API 변경 사항**
#### **Enum ImagePixelFormat이 추가되었습니다**
Enum Aspose.Slides.Export.ImagePixelFormat이 추가되었습니다 for specifying pixel format for the generated images.
#### **IChartDataPoint.GetAutomaticDataPointColor() 메서드가 추가되었습니다**
시리즈 인덱스, 데이터 포인트 인덱스, ParentSeriesGroup, IsColorVaried 속성 및 차트 스타일을 기반으로 데이터 포인트의 자동 색상을 반환합니다.
FillType이 NotDefined인 경우 기본값으로 이 색상이 사용됩니다.
#### **Slide에 RenderToGraphics 메서드가 추가되었습니다**
Aspose.Slides.Slide에 슬라이드를 Graphics 객체로 렌더링하기 위해 Method RenderToGraphics(및 그 오버로드)가 추가되었습니다.
#### **ITiffOptions 및 TiffOptions에 PixelFormat 속성이 추가되었습니다**
생성된 TIFF 이미지의 픽셀 형식을 지정하기 위해 Aspose.Slides.Export.ITiffOptions 및 Aspose.Slides.Export.TiffOptions에 Property PixelFormat이 추가되었습니다.