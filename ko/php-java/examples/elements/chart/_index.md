---
title: 차트
type: docs
weight: 60
url: /ko/php-java/examples/elements/chart/
keywords:
- 차트
- 차트 추가
- 차트 액세스
- 차트 제거
- 차트 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 차트를 만들고 사용자 지정합니다: 데이터 추가, 시리즈·축·레이블 형식 지정, 유형 변경 및 내보내기—PPT, PPTX 및 ODP에서 작동합니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 다양한 차트 유형을 추가, 액세스, 제거 및 업데이트하는 예제입니다. 아래 스니펫은 기본 차트 작업을 보여줍니다.

## **차트 추가**

이 메서드는 첫 번째 슬라이드에 간단한 영역 차트를 추가합니다.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에 간단한 열 차트를 추가합니다.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **차트 액세스**

도형 컬렉션에서 차트를 가져옵니다.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 차트에 액세스합니다.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **차트 제거**

다음 코드는 슬라이드에서 차트를 제거합니다.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 차트라고 가정합니다.
        $chart = $slide->getShapes()->get_Item(0);

        // 차트를 제거합니다.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **차트 데이터 업데이트**

제목과 같은 차트 속성을 변경할 수 있습니다.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 차트라고 가정합니다.
        $chart = $slide->getShapes()->get_Item(0);

        // 차트 제목을 변경합니다.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```