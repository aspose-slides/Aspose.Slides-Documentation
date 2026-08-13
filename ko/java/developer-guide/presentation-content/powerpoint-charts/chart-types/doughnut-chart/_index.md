---
title: Java를 사용한 프레젠테이션에서 도넛 차트 사용자 정의
linktitle: 도넛 차트
type: docs
weight: 30
url: /ko/java/doughnut-chart/
keywords:
- 도넛 차트
- 중앙 구멍
- 구멍 크기
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 도넛 차트를 생성하고 사용자 정의하는 방법을 알아보세요. PowerPoint 형식을 지원하여 동적 프레젠테이션을 만들 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 도넛 차트를 슬라이드에 추가하고, 중앙 구멍의 크기를 설정한 다음 프레젠테이션을 저장하는 방법을 보여줍니다. `setDoughnutHoleSize` 메서드에 중점을 두고, 코드에서 이 차트 유형을 사용자 정의하는 데 필요한 기본 단계를 설명합니다.

또한 여러 시리즈를 사용해 여러 개의 링을 만들기, 폭발된(donut) 차트 사용, 차트를 래스터 이미지 또는 SVG로 내보내기와 같은 도넛 차트 관련 시나리오를 다루는 짧은 FAQ도 포함되어 있습니다.

## **도넛 차트에서 중앙 구멍 크기 지정**
{{% alert color="info" %}} 

Aspose.Slides for Java는 이제 도넛 차트의 구멍 크기를 지정할 수 있습니다. 이 항목에서는 예제를 통해 도넛 차트의 구멍 크기를 지정하는 방법을 살펴봅니다.

{{% /alert %}} 

도넛 차트의 구멍 크기를 지정하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 객체를 인스턴스화합니다.
1. 슬라이드에 도넛 차트를 추가합니다.
1. 도넛 차트의 구멍 크기를 지정합니다.
1. 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 도넛 차트의 구멍 크기를 설정했습니다.

```java
import com.aspose.slides.*;

// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### 여러 개의 링을 가진 다단계 도넛을 만들 수 있나요?

예. 단일 도넛 차트에 여러 시리즈를 추가하면 각 시리즈가 별도의 링이 됩니다. 링 순서는 컬렉션에 있는 시리즈 순서에 따라 결정됩니다.

### “폭발된”(분리된 조각) 도넛 차트를 지원하나요?

예. Exploded Doughnut [차트 유형](https://reference.aspose.com/slides/ko/java/com.aspose.slides/charttype/)과 데이터 포인트의 폭발 속성이 제공되어 개별 조각을 분리할 수 있습니다.

### 보고서를 위해 도넛 차트의 이미지(PNG/SVG)를 얻으려면 어떻게 해야 하나요?

차트는 도형이므로 [래스터 이미지](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getImage-int-float-float-)로 렌더링하거나 차트를 [SVG 이미지](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)로 내보낼 수 있습니다.