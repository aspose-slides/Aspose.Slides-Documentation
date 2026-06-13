---
title: PHP를 사용하여 프레젠테이션에서 버블 차트 사용자 지정
linktitle: 버블 차트
type: docs
url: /ko/php-java/bubble-chart/
keywords:
- 버블 차트
- 버블 크기
- 크기 스케일링
- 크기 표현
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint에서 강력한 버블 차트를 쉽게 만들고 사용자 지정하여 데이터 시각화를 향상시킵니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 버블 차트를 사용하는 방법을 보여줍니다. `setBubbleSizeScale` 메서드를 통해 버블 크기 스케일링을 조정하고 `setBubbleSizeRepresentation` 메서드를 통해 버블 크기 값이 표시되는 방식을 제어하는 두 가지 특정 사용자 지정 옵션을 다룹니다.

예제에서는 버블 차트를 만들고, 크기 스케일링을 조정하며, 버블 크기 표시를 너비 사용으로 전환하는 방법을 보여줍니다. 또한 이 문서에는 “Bubble with 3-D” 차트 유형 지원 여부를 명확히 하고, 실질적인 차트 제한은 성능 및 대상 PowerPoint 버전에 따라 달라진다는 점을 언급하며, 내보내기가 Aspose.Slides 렌더링 엔진을 통해 차트 외관을 유지한다는 내용을 포함한 짧은 FAQ 섹션이 포함되어 있습니다.

## **버블 차트 크기 스케일링**
Aspose.Slides for PHP via Java은 버블 차트 크기 스케일링을 지원합니다. Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) 및 [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) 메서드가 추가되었습니다. 아래 샘플 예제가 제공됩니다.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **버블 차트 크기로 데이터 표현**
메서드 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) 및 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) 가 [ChartSeries](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriesgroup/) 클래스 및 관련 클래스에 추가되었습니다. **BubbleSizeRepresentation** 은 버블 차트에서 버블 크기 값이 표시되는 방식을 지정합니다. 가능한 값은 [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/BubbleSizeRepresentationType#Area) 와 [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/BubbleSizeRepresentationType#Width) 입니다. 따라서 데이터를 버블 차트 크기로 표현하는 가능한 방법을 지정하기 위해 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/BubbleSizeRepresentationType) 열거형이 추가되었습니다. 아래에 샘플 코드가 제공됩니다.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**"3-D 효과가 있는 버블 차트"가 지원되며, 일반 차트와는 어떻게 다른가요?**

예. 별도의 차트 유형인 "Bubble with 3-D"가 있습니다. 이 유형은 버블에 3‑D 스타일을 적용하지만 추가 축은 없으며 데이터는 X‑Y‑S(크기) 형태를 유지합니다. 해당 유형은 [chart type](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/) 클래스에서 사용할 수 있습니다.

**버블 차트에서 시리즈와 포인트 수에 제한이 있나요?**

API 수준에서는 명확한 제한이 없으며, 제약은 성능 및 대상 PowerPoint 버전에 따라 달라집니다. 가독성과 렌더링 속도를 위해 포인트 수를 적절히 유지하는 것이 권장됩니다.

**내보내기가 버블 차트의 외관에 어떤 영향을 미칩니까 (PDF, 이미지)?**

지원되는 형식으로 내보내면 차트의 외관이 유지됩니다. 렌더링은 Aspose.Slides 엔진에 의해 수행됩니다. 래스터/벡터 형식의 경우 일반적인 차트 그래픽 렌더링 규칙(해상도, 안티앨리어싱)이 적용되므로 인쇄용으로 충분한 DPI를 선택하십시오.