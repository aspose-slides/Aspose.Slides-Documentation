---
title: Aspose.Slides for Java 16.1.0의 공용 API 및 역호환성 깨지는 변경 사항
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- 마이그레이션
- 레거시 코드
- 최신 코드
- 레거시 접근 방식
- 최신 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 공용 API 업데이트와 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}}

이 페이지에는 Aspose.Slides for Java 16.1.0 API와 함께 도입된 모든 [added](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) 또는 [removed](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) 클래스, 메서드, 속성 및 기타 변경 사항이 나열됩니다.

{{% /alert %}} 
## **공용 API 변경 사항**


#### **IChartTextBlockFormat 및 ITextFrameFormat 인터페이스에 getRotationAngle() 및 setRotationAngle() 메서드가 추가되었습니다**
com.aspose.slides.IChartTextBlockFormat 및 com.aspose.slides.ITextFrameFormat 인터페이스에 getRotationAngle() 및 setRotationAngle() 메서드가 추가되었습니다.
이 메서드는 경계 상자 내 텍스트에 적용되는 사용자 정의 회전에 대한 접근을 제공합니다.

``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```