---
title: PHP를 사용한 프레젠테이션 차트의 오류 막대 사용자 지정
linktitle: 오류 막대
type: docs
url: /ko/php-java/error-bar/
keywords:
- 오류 막대
- 맞춤값
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 차트에 오류 막대를 추가하고 사용자 지정하는 방법을 배우고, PowerPoint 프레젠테이션의 데이터 시각화를 최적화하세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에서 오류 막대를 다루는 방법을 설명합니다. 차트 시리즈에 오류 막대를 추가하고 X 및 Y 오류 막대 설정을 구성하며 고정값, 백분율 및 사용자 지정 값과 같은 다양한 값 유형을 적용하는 방법을 보여줍니다.

또한 시리즈의 개별 데이터 포인트 컬렉션을 사용하여 개별 데이터 포인트에 사용자 지정 오류 막대 값을 할당하는 방법을 시연합니다. 추가로 오류 막대가 내보내기 중에 어떻게 동작하는지, 마커 및 데이터 레이블과의 호환성, 관련 API 참조 클래스와 열거형을 찾을 수 있는 위치에 대한 간략한 설명도 포함하고 있습니다.

## **오류 막대 추가**
Aspose.Slides for PHP via Java은 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 사용자 지정 값 유형을 사용할 때 적용됩니다. 값을 지정하려면 시리즈의 [**data points**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriescollection/) 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용하십시오.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 막대 값과 형식을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```php
  # Presentation 클래스 인스턴스 생성
  $pres = new Presentation();
  try {
    # 버블 차트 생성
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # 오류 막대를 추가하고 형식 설정
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # 프레젠테이션 저장
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **사용자 지정 오류 막대 값 추가**
Aspose.Slides for PHP via Java은 사용자 지정 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/errorbarsformat/#getValueType) 메서드가 **Custom**을 반환할 때 적용됩니다. 값을 지정하려면 시리즈의 [**data points**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseriescollection/) 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용하십시오.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 차트 시리즈의 개별 데이터 포인트에 접근하여 개별 시리즈 데이터 포인트에 대한 오류 막대 값을 설정합니다.
1. 막대 값과 형식을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```php
  # Presentation 클래스 인스턴스 생성
  $pres = new Presentation();
  try {
    # 버블 차트 생성
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # 사용자 지정 오류 막대를 추가하고 형식 설정
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # 차트 시리즈 데이터 포인트에 접근하고 오류 막대 값을 설정
    # 개별 포인트
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # 차트 시리즈 포인트에 대한 오류 막대 설정
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # 프레젠테이션 저장
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**프레젠테이션을 PDF 또는 이미지로 내보낼 때 오류 막대는 어떻게 되나요?**

호환되는 버전이나 렌더러가 있는 경우 차트의 일부로 렌더링되며 변환 중에도 차트 서식과 함께 보존됩니다.

**오류 막대를 마커 및 데이터 레이블과 결합할 수 있나요?**

예. 오류 막대는 별도의 요소이며 마커 및 데이터 레이블과 호환됩니다. 요소가 겹칠 경우 서식을 조정해야 할 수 있습니다.

**API에서 오류 막대를 다루기 위한 속성과 클래스 목록은 어디에서 찾을 수 있나요?**

API 참조에 있습니다: [ErrorBarsFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/errorbarsformat/) 클래스와 관련 클래스인 [ErrorBarType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/errorbartype/) 및 [ErrorBarValueType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/errorbarvaluetype/).