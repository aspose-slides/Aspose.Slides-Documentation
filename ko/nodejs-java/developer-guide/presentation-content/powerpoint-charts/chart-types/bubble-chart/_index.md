---
title: 프레젠테이션에서 JavaScript를 사용하여 버블 차트 사용자 지정
linktitle: 버블 차트
type: docs
url: /ko/nodejs-java/bubble-chart/
keywords:
- 버블 차트
- 버블 크기
- 크기 스케일링
- 크기 표현
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js via Java를 사용하여 PowerPoint에서 강력한 버블 차트를 만들고 사용자 지정하여 데이터 시각화를 쉽게 향상시킵니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 버블 차트를 사용하는 방법을 보여줍니다. 여기서는 `setBubbleSizeScale` 메서드를 통해 버블 크기를 조정하고 `setBubbleSizeRepresentation` 메서드를 통해 버블 크기 값의 표현 방식을 제어하는 두 가지 맞춤 옵션을 다룹니다.

예제에서는 버블 차트를 생성하고, 크기 스케일링을 조정하며, 버블 크기 표현을 너비 사용으로 전환하는 방법을 설명합니다. 또한 “Bubble with 3‑D” 차트 유형에 대한 지원 여부를 명확히 하고, 실제 차트 제한은 성능 및 대상 PowerPoint 버전에 따라 달라짐을 언급하며, 내보내기가 Aspose.Slides 렌더링 엔진을 통해 차트 모양을 보존한다는 내용을 포함한 짧은 FAQ 섹션이 포함되어 있습니다.

## **버블 차트 크기 스케일링**
Aspose.Slides for Node.js via Java은 버블 차트 크기 스케일링을 지원합니다. In Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) and [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) methods have been added. Below sample example is given. 

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **버블 차트 크기로 데이터 표시**
Methods [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) and [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) have been added to [ChartSeries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartSeriesGroup) classs, and related classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) and [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Accordingly, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/BubbleSizeRepresentationType) enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **자주 묻는 질문**

**"3‑D 효과가 있는 버블 차트"가 지원되며 일반 차트와는 어떻게 다른가요?**

Yes. There is a separate chart type, "Bubble with 3-D." It applies 3-D styling to the bubbles but does not add an additional axis; the data remain X‑Y‑S (size). The type is available in the [chart type](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/charttype/) enumeration.

**버블 차트에서 시리즈와 포인트의 수에 제한이 있나요?**

There is no hard limit at the API level; constraints are determined by performance and the target PowerPoint version. It is recommended to keep the number of points reasonable for readability and rendering speed.

**내보내기가 버블 차트(PDF, 이미지)의 모양에 어떤 영향을 미칩니까?**

Export to supported formats preserves the chart’s appearance; rendering is performed by the Aspose.Slides engine. For raster/vector formats, general chart‑graphics rendering rules apply (resolution, anti‑aliasing), so choose sufficient DPI for printing.