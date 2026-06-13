---
title: 차트
type: docs
weight: 60
url: /ko/java/examples/elements/chart/
keywords:
- 코드 예제
- 차트
- 파워포인트
- 오픈문서
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java로 차트를 마스터하세요: 차트를 만들고, 서식을 지정하고, 데이터를 바인딩하며, PPT, PPTX 및 ODP 형식으로 차트를 내보내는 Java 예제."
---
**Aspose.Slides for Java**를 사용하여 다양한 차트 유형을 추가, 액세스, 제거 및 업데이트하는 예제입니다. 아래 스니펫은 기본 차트 작업을 보여줍니다.

## **차트 추가**

이 메서드는 첫 번째 슬라이드에 간단한 영역 차트를 추가합니다.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 첫 번째 슬라이드에 간단한 영역 차트를 추가합니다.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **차트 액세스**

차트를 만든 후, shape 컬렉션을 통해 차트를 검색할 수 있습니다.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // 슬라이드에서 첫 번째 차트에 접근합니다.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
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

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // 차트를 제거합니다.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **차트 데이터 업데이트**

제목과 같은 차트 속성을 변경할 수 있습니다.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // 차트 제목을 변경합니다.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```