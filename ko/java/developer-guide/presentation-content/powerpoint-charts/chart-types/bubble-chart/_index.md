---
title: Java를 사용한 프레젠테이션의 버블 차트 사용자 정의
linktitle: 버블 차트
type: docs
url: /ko/java/bubble-chart/
keywords:
- 버블 차트
- 버블 크기
- 크기 스케일링
- 크기 표현
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint에서 강력한 버블 차트를 만들고 맞춤 설정하여 데이터 시각화를 손쉽게 향상시키세요."
---
## **Overview**

이 문서는 Aspose.Slides에서 버블 차트를 사용하는 방법을 보여줍니다. `setBubbleSizeScale` 메서드를 사용한 버블 크기 스케일링과 `setBubbleSizeRepresentation` 메서드를 사용한 버블 크기 값 표현 방식을 두 가지 맞춤 옵션으로 다룹니다.

예제에서는 버블 차트를 생성하고, 크기 스케일을 조정하며, 버블 크기 표현을 너비로 전환하는 방법을 시연합니다. 또한 “Bubble with 3‑D” 차트 유형 지원 여부를 명확히 하고, 실제 차트 제한이 성능 및 대상 PowerPoint 버전에 따라 달라짐을 언급하며, 내보내기가 Aspose.Slides 렌더링 엔진을 통해 차트 모양을 유지한다는 내용의 짧은 FAQ 섹션도 포함합니다.

## **Bubble Chart Size Scaling**
Aspose.Slides for Java는 버블 차트 크기 스케일링을 지원합니다. Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--) , [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) 및 [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) 메서드가 추가되었습니다. 아래 샘플 예제가 제공됩니다.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Represent Data as Bubble Chart Sizes**
[**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) 및 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) 메서드가 [IChartSeries](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartSeries) , [IChartSeriesGroup](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartSeriesGroup) 인터페이스 및 관련 클래스에 추가되었습니다. **BubbleSizeRepresentation**은 버블 차트에서 버블 크기 값이 어떻게 표시되는지를 지정합니다. 가능한 값은 [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/BubbleSizeRepresentationType#Area) 와 [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/BubbleSizeRepresentationType#Width) 입니다. 따라서 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/BubbleSizeRepresentationType) 열거형이 추가되어 버블 차트 크기로 데이터를 표현하는 가능한 방식을 지정합니다. 아래에 샘플 코드가 제공됩니다.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

Yes. There is a separate chart type, "Bubble with 3-D." It applies 3‑D styling to the bubbles but does not add an additional axis; the data remain X‑Y‑S (size). The type is available in the [chart type](https://reference.aspose.com/slides/ko/java/com.aspose.slides/charttype/) class.

**Is there a limit on the number of series and points in a bubble chart?**

There is no hard limit at the API level; constraints are determined by performance and the target PowerPoint version. It is recommended to keep the number of points reasonable for readability and rendering speed.

**How will export affect the appearance of a bubble chart (PDF, images)?**

Export to supported formats preserves the chart’s appearance; rendering is performed by the Aspose.Slides engine. For raster/vector formats, general chart‑graphics rendering rules apply (resolution, anti‑aliasing), so choose sufficient DPI for printing.