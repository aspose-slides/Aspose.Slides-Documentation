---
title: Aspose.Slides for Java 15.7.0의 공개 API 및 기존 호환성 깨지는 변경 사항
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공개 API 업데이트와 파괴적인 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="primary" %}} 

이 페이지에서는 Aspose.Slides for Java 15.7.0 API와 함께 도입된 모든 [추가됨](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) 또는 [제거됨](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) 클래스, 메서드, 속성 등을 나열하고, 기타 변경 사항을 보여줍니다.

{{% /alert %}} 
## **Public API Changes**
#### **Enum com.aspose.slides.ImagePixelFormat has been added**
생성된 이미지의 픽셀 형식을 지정하기 위해 Enum com.aspose.slides.ImagePixelFormat가 추가되었습니다.
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() method has been added**
이 메서드는 시리즈 인덱스, 데이터 포인트 인덱스, parentSeriesGroup, isColorVaried 값 및 차트 스타일을 기반으로 데이터 포인트의 자동 색상을 반환합니다. fillType이 NotDefined와 동일하면 이 색상이 기본값으로 사용됩니다.
#### **Methods getPixelFormat(), setPixelFormat(int) have been added to com.aspose.slides.ITiffOptions**
생성된 TIFF 이미지의 픽셀 형식을 지정하기 위해 com.aspose.slides.ITiffOptions 및 com.aspose.slides.TiffOptions에 getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) 메서드가 추가되었습니다.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```