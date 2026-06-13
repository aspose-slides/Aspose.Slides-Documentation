---
title: 프레젠테이션에서 PHP를 사용한 원형 차트 맞춤 설정
linktitle: 원형 차트
type: docs
url: /ko/php-java/pie-chart/
keywords:
- 원형 차트
- 차트 관리
- 차트 맞춤 설정
- 차트 옵션
- 차트 설정
- 플롯 옵션
- 슬라이스 색상
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 원형 차트를 만들고 맞춤 설정하는 방법을 배우고, PowerPoint로 내보내어 몇 초 만에 데이터 스토리텔링을 강화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 원형 차트를 사용하는 방법을 설명합니다. 여기에서는 Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 원형 차트에 대해 자동 슬라이스 색상을 활성화하는 방법을 보여줍니다.

예제는 슬라이드에 차트를 추가하고, 시리즈 및 레이블 설정을 조정하고, 기본 차트 데이터를 사용자 정의 카테고리와 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 등 실용적인 차트 사용자 정의 단계에 중점을 둡니다.

## **Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션**
Aspose.Slides for PHP via Java는 Pie of Pie 또는 Bar of Pie 차트에 대한 보조 플롯 옵션을 지원합니다. 이 항목에서는 Aspose.Slides를 사용하여 해당 옵션을 지정하는 방법을 보여줍니다. 속성을 지정하려면 다음을 수행하십시오:

1. Presentation 클래스 개체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트의 보조 플롯 옵션을 지정합니다.
1. 프레젠테이션을 디스크에 기록합니다.

아래 예제에서는 Pie of Pie 차트의 다양한 속성을 설정했습니다.

```php
  # Presentation 클래스의 인스턴스를 생성합니다
  $pres = new Presentation();
  try {
    # 슬라이드에 차트 추가
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # 다양한 속성 설정
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # 프레젠테이션을 디스크에 저장
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **자동 원형 차트 슬라이스 색상 설정**
Aspose.Slides for PHP via Java는 자동 원형 차트 슬라이스 색상을 설정하기 위한 간단한 API를 제공합니다. 샘플 코드는 앞서 언급된 속성을 적용합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 기본 데이터가 있는 차트를 추가합니다.
1. 차트 제목을 설정합니다.
1. 첫 번째 시리즈를 값 표시로 설정합니다.
1. 차트 데이터 시트의 인덱스를 설정합니다.
1. 차트 데이터 워크시트를 가져옵니다.
1. 기본 생성된 시리즈와 카테고리를 삭제합니다.
1. 새 카테고리를 추가합니다.
1. 새 시리즈를 추가합니다.

수정된 프레젠테이션을 PPTX 파일로 기록합니다.

```php
  # Presentation 클래스의 인스턴스를 생성합니다
  $pres = new Presentation();
  try {
    # 기본 데이터가 있는 차트를 추가합니다
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # 차트 제목 설정
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 첫 번째 시리즈를 값 표시로 설정합니다
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # 차트 데이터 시트의 인덱스를 설정합니다
    $defaultWorksheetIndex = 0;
    # 차트 데이터 워크시트를 가져옵니다
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 기본 생성된 시리즈와 카테고리를 삭제합니다
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 새 카테고리를 추가합니다
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # 새 시리즈를 추가합니다
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # 이제 시리즈 데이터를 채웁니다
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **자주 묻는 질문**

**‘Pie of Pie’와 ‘Bar of Pie’ 변형이 지원됩니까?**

예, 라이브러리는 ‘Pie of Pie’ 및 ‘Bar of Pie’ 유형을 포함한 원형 차트에 대한 보조 플롯을 지원합니다.

**차트만 이미지(예: PNG)로 내보낼 수 있나요?**

예, 전체 프레젠테이션 없이 차트 자체를 이미지(예: PNG)로 내보낼 수 있습니다.