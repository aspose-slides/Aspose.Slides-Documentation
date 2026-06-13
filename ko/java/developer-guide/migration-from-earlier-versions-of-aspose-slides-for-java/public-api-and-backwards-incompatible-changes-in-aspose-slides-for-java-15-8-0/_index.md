---
title: Aspose.Slides for Java 15.8.0의 공개 API 및 뒤로 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
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
description: "Aspose.Slides for Java에서 공개 API 업데이트 및 중단되는 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="primary" %}} 
이 페이지에서는 Aspose.Slides for Java 15.8.0 API와 함께 도입된 모든 [added](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 또는 [removed](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 클래스, 메서드, 속성 및 기타 변경 사항을 나열합니다.
{{% /alert %}} 
## **공개 API 변경 사항**
#### **IChartSeries 및 ChartSeries에 getDoughnutHoleSize(), setDoughnutHoleSize(byte) 메서드가 추가되었습니다.**
도넛 차트의 구멍 크기를 지정합니다.
``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```