---
title: Aspose.Slides for Java 15.7.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
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
description: "Aspose.Slides for Java의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="info" %}} 
이 페이지에서는 Aspose.Slides for Java 15.7.0 API와 함께 도입된 [추가됨](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) 또는 [제거됨](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) 클래스, 메서드, 속성 등을 나열합니다.
{{% /alert %}} 
## **공용 API 변경 사항**
#### **Enum com.aspose.slides.ImagePixelFormat이 추가되었습니다**
Enum com.aspose.slides.ImagePixelFormat이 추가되었습니다. 이 열거형은 생성된 이미지의 픽셀 형식을 지정하는 데 사용됩니다.
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() 메서드가 추가되었습니다**
이 메서드는 시리즈 인덱스, 데이터 포인트 인덱스, parentSeriesGroup, isColorVaried 값 및 차트 스타일을 기반으로 데이터 포인트의 자동 색상을 반환합니다. fillType이 NotDefined인 경우 기본적으로 이 색상이 사용됩니다.
#### **Methods getPixelFormat(), setPixelFormat(int) 메서드가 com.aspose.slides.ITiffOptions에 추가되었습니다**
생성된 TIFF 이미지의 픽셀 형식을 지정하기 위해 com.aspose.slides.ITiffOptions 및 com.aspose.slides.TiffOptions에 Methods getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) 메서드가 추가되었습니다.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```