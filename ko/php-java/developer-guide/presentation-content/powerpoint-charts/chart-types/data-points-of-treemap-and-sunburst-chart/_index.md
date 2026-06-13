---
title: PHP를 사용하여 Treemap 및 Sunburst 차트의 데이터 포인트 맞춤 설정
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 차트
- Sunburst 차트
- 데이터 포인트
- 레이블 색상
- 브랜치 색상
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 Treemap 및 Sunburst 차트의 데이터 포인트를 관리하는 방법을 배우고, PowerPoint 형식과 호환됩니다."
---
## **소개**

PowerPoint 차트의 다른 유형들 중에서 두 가지 “계층적” 유형이 있습니다 - **Treemap** 및 **Sunburst** 차트 (Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph 또는 Multi Level Pie Chart 로도 알려짐). 이러한 차트는 트리 구조로 조직된 계층 데이터를 표시합니다 - 잎에서 브랜치의 상위까지. 잎은 시리즈 데이터 포인트에 의해 정의되며, 각 이후 중첩 그룹 수준은 해당 카테고리에 의해 정의됩니다. Aspose.Slides for PHP via Java는 Sunburst 차트와 Treemap의 데이터 포인트를 형식화할 수 있게 합니다.

다음은 Sunburst 차트이며, Series1 열의 데이터가 잎 노드를 정의하고, 다른 열들은 계층형 데이터 포인트를 정의합니다:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

프레젠테이션에 새로운 Sunburst 차트를 추가해 보겠습니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="또한 보기" %}} 
- [**PHP에서 PowerPoint 프레젠테이션 차트 만들기 또는 업데이트하기**](/slides/ko/php-java/create-chart/)
{{% /alert %}}

차트의 데이터 포인트를 형식화할 필요가 있는 경우, 다음을 사용해야 합니다:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointlevel/) 클래스와 [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) 메서드는 Treemap 및 Sunburst 차트의 데이터 포인트를 형식화하는 데 접근을 제공합니다. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointlevelsmanager/)는 다중 레벨 카테고리에 접근하기 위해 사용되며 - 이는 [**ChartDataPointLevel**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointlevel/) 객체들의 컨테이너를 나타냅니다. 기본적으로 이는 데이터 포인트에 특화된 속성이 추가된 [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartcategorylevelsmanager/)의 래퍼입니다. [**ChartDataPointLevel**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointlevel/) 클래스는 두 메서드: [**getFormat**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointlevel/#getFormat)와 [**getDataLabel**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointlevel/#getLabel)를 제공하며, 해당 설정에 접근할 수 있습니다.
## **데이터 포인트 값 표시**
"Leaf 4" 데이터 포인트의 값을 표시합니다:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **데이터 포인트 레이블 및 색상 설정**
"Branch 1" 데이터 레이블을 카테고리 이름 대신 시리즈 이름 ("Series1")을 표시하도록 설정합니다. 그런 다음 텍스트 색상을 노란색으로 설정합니다:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **데이터 포인트 브랜치 색상 설정**
"Steam 4" 브랜치의 색상을 변경합니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **자주 묻는 질문**

**Sunburst/Treemap에서 세그먼트의 순서(정렬)를 변경할 수 있나요?**

아니요. PowerPoint는 세그먼트를 자동으로 정렬합니다(보통 값이 큰 순서대로 시계 방향). Aspose.Slides도 이 동작을 그대로 따릅니다: 순서를 직접 변경할 수 없으며, 데이터를 사전 처리함으로써 원하는 순서를 구현해야 합니다.

**프레젠테이션 테마가 세그먼트와 레이블의 색상에 어떤 영향을 줍니까?**

차트 색상은 명시적으로 채우기/글꼴을 설정하지 않는 한 프레젠테이션의 [테마/팔레트](/slides/ko/php-java/presentation-theme/)를 상속합니다. 일관된 결과를 위해서는 필요한 수준에서 고정된 채우기와 텍스트 서식을 지정하십시오.

**PDF/PNG로 내보내면 사용자 지정 브랜치 색상 및 레이블 설정이 유지됩니까?**

예. 프레젠테이션을 내보낼 때 차트 설정(채우기, 레이블)이 출력 형식에 그대로 유지됩니다. 이는 Aspose.Slides가 차트 형식을 적용한 상태로 렌더링하기 때문입니다.

**차트 위에 사용자 지정 오버레이를 배치하기 위해 레이블/요소의 실제 좌표를 계산할 수 있나요?**

예. 차트 레이아웃이 검증된 후, 요소에 대해 실제 *x*와 실제 *y* 값을 얻을 수 있습니다(예: [DataLabel](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabel/)). 이를 통해 오버레이를 정확히 배치할 수 있습니다.