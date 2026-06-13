---
title: PHP 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/php-java/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 거듭제곱 추세선
- 맞춤 추세선
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 사용자 지정하세요 — 청중을 사로잡는 실용적인 가이드."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 생성하고 차트 시리즈에 추세선을 추가하며, 지수, 선형, 로그, 이동 평균, 다항식 및 거듭제곱 등 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 라인 도형을 삽입하여 차트에 사용자 정의 선을 추가하는 방법을 설명하고, 앞·뒤 추세선 투영값 및 PDF 또는 SVG로 내보내거나 차트를 이미지로 렌더링할 때 추세선이 유지되는지에 대한 간단한 FAQ를 포함합니다.

## **추세선 추가**
Aspose.Slides for PHP via Java는 다양한 차트 추세선을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
3. 기본 데이터와 원하는 유형 중 하나로 차트를 추가합니다(이 예에서는 ChartType::ClusteredColumn을 사용합니다).
4. 차트 시리즈 1에 지수 추세선을 추가합니다.
5. 차트 시리즈 1에 선형 추세선을 추가합니다.
6. 차트 시리즈 2에 로그 추세선을 추가합니다.
7. 차트 시리즈 2에 이동 평균 추세선을 추가합니다.
8. 차트 시리즈 3에 다항식 추세선을 추가합니다.
9. 차트 시리즈 3에 거듭제곱 추세선을 추가합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 추세선이 포함된 차트를 만드는 데 사용됩니다.

```php
  # Presentation 클래스의 인스턴스 생성
  $pres = new Presentation();
  try {
    # 클러스터형 열 차트 생성
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # 시리즈 1에 지수 추세선 추가
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # 시리즈 1에 선형 추세선 추가
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 시리즈 2에 로그 추세선 추가
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # 시리즈 2에 이동 평균 추세선 추가
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # 시리즈 3에 다항식 추세선 추가
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # 시리즈 3에 거듭제곱 추세선 추가
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # 프레젠테이션 저장
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **맞춤선 추가**
Aspose.Slides for PHP via Java는 차트에 사용자 정의 선을 추가하기 위한 간단한 API를 제공합니다. 프레젠테이션의 선택된 슬라이드에 단순한 직선 형태의 선을 추가하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- Shapes 객체의 AddChart 메서드를 사용하여 새 차트를 만듭니다.
- Shapes 객체의 AddAutoShape 메서드를 사용하여 라인 유형의 AutoShape을 추가합니다.
- 도형 선의 색상을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 사용자 정의 선이 포함된 차트를 만드는 데 사용됩니다.

```php
  # Presentation 클래스의 인스턴스 생성
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**추세선에서 'forward'와 'backward'는 무엇을 의미합니까?**

이는 추세선을 앞쪽/뒤쪽으로 연장한 길이를 의미합니다. 산점도(XY) 차트의 경우 축 단위로, 비산점도 차트의 경우 카테고리 수로 표시됩니다. 0 이상의 값만 허용됩니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 유지됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ko/php-java/render-a-slide-as-an-svg-image/) 로 변환하고 차트를 이미지로 렌더링합니다. 차트의 일부인 추세선은 이러한 작업 중에 유지됩니다. 또한 차트 자체의 이미지를 [내보내는](/slides/ko/php-java/create-shape-thumbnails/) 메서드도 제공됩니다.