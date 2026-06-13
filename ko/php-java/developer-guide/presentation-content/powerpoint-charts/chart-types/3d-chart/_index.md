---
title: PHP를 사용한 프레젠테이션에서 3D 차트 사용자 지정
linktitle: 3D 차트
type: docs
url: /ko/php-java/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 PPT 및 PPTX 파일을 지원하는 3D 차트를 만들고 사용자 지정하는 방법을 배우고 오늘 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서에서는 `RotationX`, `RotationY`, `DepthPercents`, `RightAngleAxes`와 같은 `Rotation3D` 설정을 구성하여 Aspose.Slides에서 3D 차트를 사용자 지정하는 방법을 설명합니다. 프레젠테이션을 만들고, 기본 데이터가 포함된 3D 차트를 추가하고, 필요한 3D 보기 설정을 적용한 다음, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 단계별로 안내합니다.

## **3D 차트의 RotationX, RotationY 및 DepthPercents 속성 설정**
Aspose.Slides for PHP via Java는 이러한 속성을 설정하기 위한 간단한 API를 제공합니다. 다음 문서는 **X, Y 회전, DepthPercents** 등 다양한 속성을 설정하는 방법을 안내합니다. 샘플 코드는 앞에서 언급한 속성을 적용하는 예제를 보여줍니다.

1. 다음과 같이 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 액세스합니다.
1. 기본 데이터가 포함된 차트를 추가합니다.
1. Rotation3D 속성을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```php
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 액세스
    $slide = $pres->getSlides()->get_Item(0);
    # 기본 데이터가 있는 차트 추가
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # 차트 데이터 시트의 인덱스 설정
    $defaultWorksheetIndex = 0;
    # 차트 데이터 워크시트 가져오기
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 시리즈 추가
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # 카테고리 추가
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Rotation3D 속성 설정
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # 두 번째 차트 시리즈 가져오기
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 이제 시리즈 데이터 채우기
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # OverLap 값 설정
    $series->getParentSeriesGroup()->setOverlap(100);
    # 프레젠테이션을 디스크에 저장
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **자주 묻는 질문**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇입니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D와 같은 3D 열 차트 변형 및 [ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/) 클래스를 통해 제공되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참조에서 [ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/) 멤버를 확인하십시오.

**보고서나 웹용 3D 차트의 래스터 이미지를 얻을 수 있습니까?**

네. [chart API](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getImage)를 사용해 차트를 이미지로 내보내거나 [전체 슬라이드 렌더링](/slides/ko/php-java/convert-powerpoint-to-png/)을 통해 PNG 또는 JPEG와 같은 형식으로 저장할 수 있습니다. 이는 픽셀 단위로 정확한 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드, 웹 페이지 등에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 구축하고 렌더링하는 성능은 어떻습니까?**

성능은 데이터 양과 시각적 복잡성에 따라 다릅니다. 최적의 결과를 위해 3D 효과를 최소화하고, 차트 영역 및 플롯 영역에 무거운 텍스처 사용을 피하며, 가능한 경우 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이 또는 인쇄 요구에 맞게 적절한 해상도와 크기로 출력하도록 렌더링하십시오.