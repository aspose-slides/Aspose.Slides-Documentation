---
title: Aspose.Slides for .NET 15.7.0의 공개 API 및 호환 불가능한 변경 사항
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- 마이그레이션
- 레거시 코드
- 최신 코드
- 레거시 접근 방식
- 최신 접근 방식
- 파워포인트
- 오픈문서
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "공개 API 업데이트와 Aspose.Slides for .NET의 호환성 깨지는 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지는 Aspose.Slides for .NET 15.7.0 API와 함께 도입된, [추가](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) 또는 [제거](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/)된 클래스, 메서드, 속성 등과 기타 변경 사항을 모두 나열합니다.

{{% /alert %}} 
## **공개 API 변경 사항**
#### **Enum ImagePixelFormat가 추가되었습니다**
생성된 이미지의 픽셀 형식을 지정하기 위해 Enum Aspose.Slides.Export.ImagePixelFormat가 추가되었습니다.
#### **IChartDataPoint.GetAutomaticDataPointColor() 메서드가 추가되었습니다**
시리즈 인덱스, 데이터 포인트 인덱스, ParentSeriesGroup, IsColorVaried 속성 및 차트 스타일을 기반으로 데이터 포인트의 자동 색상을 반환합니다.
FillType이 NotDefined인 경우, 이 색상이 기본값으로 사용됩니다.
#### **RenderToGraphics 메서드가 Slide에 추가되었습니다**
Aspose.Slides.Slide에 슬라이드를 Graphics 개체로 렌더링하기 위해 Method RenderToGraphics(및 그 오버로드)가 추가되었습니다.
#### **PixelFormat 속성이 ITiffOptions 및 TiffOptions에 추가되었습니다**
생성된 TIFF 이미지의 픽셀 형식을 지정하기 위해 Aspose.Slides.Export.ITiffOptions 및 Aspose.Slides.Export.TiffOptions에 Property PixelFormat가 추가되었습니다.