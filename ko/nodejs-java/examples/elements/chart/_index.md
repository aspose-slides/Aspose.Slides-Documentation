---
title: 차트
type: docs
weight: 60
url: /ko/nodejs-java/examples/elements/chart/
keywords:
- 코드 예제
- 차트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java로 차트를 마스터하세요: 차트를 만들고, 형식 지정하고, 데이터를 바인딩하며, PPT, PPTX 및 ODP 형식으로 내보내는 JavaScript 예제."
---
다양한 차트 유형을 **Aspose.Slides for Node.js via Java** 로 추가, 액세스, 제거 및 업데이트하는 예시입니다. 아래 코드 조각은 기본 차트 작업을 보여줍니다.

## **차트 추가**

이 메서드는 첫 번째 슬라이드에 단순한 영역 차트를 추가합니다.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 슬라이드에 간단한 영역 차트를 추가합니다.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **차트 액세스**

차트를 만든 후에는 Shape 컬렉션을 통해 차트를 가져올 수 있습니다.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 슬라이드의 첫 번째 차트에 접근합니다.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **차트 제거**

다음 코드는 슬라이드에서 차트를 제거합니다.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 차트를 제거합니다.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **차트 데이터 업데이트**

제목과 같은 차트 속성을 변경할 수 있습니다.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // 차트 제목을 변경합니다.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```