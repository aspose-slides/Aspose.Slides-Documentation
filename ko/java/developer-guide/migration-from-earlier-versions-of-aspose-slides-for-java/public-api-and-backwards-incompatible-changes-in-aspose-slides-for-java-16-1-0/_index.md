---
title: Aspose.Slides for Java 16.1.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
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
{{% alert color="primary" %}}

이 페이지는 Aspose.Slides for Java 16.1.0 API와 함께 도입된 모든 [추가된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) 또는 [제거된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) 클래스, 메서드, 속성 등과 기타 변경 사항을 나열합니다.

{{% /alert %}} 
## **공개 API 변경**

#### **IChartTextBlockFormat 및 ITextFrameFormat 인터페이스에 getRotationAngle() 및 setRotationAngle() 메서드가 추가되었습니다**
com.aspose.slides.IChartTextBlockFormat 및 com.aspose.slides.ITextFrameFormat 인터페이스에 getRotationAngle() 및 setRotationAngle() 메서드가 추가되었습니다. 이 메서드는 경계 상자 내 텍스트에 적용되는 사용자 지정 회전에 접근할 수 있게 합니다.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```