---
title: "PHP에서 PowerPoint 프레젠테이션 차트 만들기 또는 업데이트하기"
linktitle: "차트 만들기 또는 업데이트하기"
type: docs
weight: 10
url: /ko/php-java/create-chart/
keywords:
- 차트 추가
- 차트 만들기
- 차트 편집
- 차트 변경
- 차트 업데이트
- 산점도 차트
- 원형 차트
- 선 차트
- 트리맵 차트
- 주식 차트
- 상자·수염 차트
- 퍼널 차트
- 썬버스트 차트
- 히스토그램 차트
- 레이다 차트
- 다중 카테고리 차트
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 차트를 만들고 사용자 지정합니다. 실용적인 코드 예제로 차트를 추가, 서식 지정 및 편집합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 차트를 만들고 사용자 지정하는 포괄적인 가이드를 제공합니다. 슬라이드에 차트를 프로그래밍 방식으로 추가하고, 데이터를 채우며, 특정 디자인 요구 사항에 맞게 다양한 서식 옵션을 적용하는 방법을 배웁니다. 문서 전체에 걸쳐 프레젠테이션 및 차트 개체 초기화부터 시리즈, 축, 레전드 구성까지 각 단계를 설명하는 상세 코드 예제가 포함되어 있습니다. 이 가이드를 따라 하면 동적 차트 생성을 애플리케이션에 통합하는 방법을 확실히 이해하고, 데이터 기반 프레젠테이션을 손쉽게 만들 수 있습니다.

## **차트 만들기**

차트는 데이터를 빠르게 시각화하고 표나 스프레드시트에서 바로 알기 어려운 인사이트를 제공하는 데 도움이 됩니다.

**차트를 만들어야 하는 이유**

차트를 사용하면 다음을 할 수 있습니다

* 프레젠테이션의 단일 슬라이드에 대량의 데이터를 집계·압축·요약
* 데이터의 패턴과 추세를 드러냄
* 시간 경과에 따른 또는 특정 측정 단위에 대한 데이터의 방향과 모멘텀 추정
* 이상값, 편차, 오류, 비논리적 데이터 등을 발견
* 복잡한 데이터를 전달·프레젠테이션

PowerPoint에서는 삽입 기능을 통해 다양한 차트 템플릿을 사용해 차트를 만들 수 있습니다. Aspose.Slides를 사용하면 일반 차트(일반적인 차트 유형 기반)와 사용자 지정 차트를 만들 수 있습니다.

{{% alert color="primary" %}}  
차트를 만들 수 있도록 Aspose.Slides는 [ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ChartType) 클래스를 제공합니다. 이 클래스 아래의 필드는 다양한 차트 유형에 해당합니다.  
{{% /alert %}}  

### **일반 차트 만들기**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>단계:</em> PowerPoint 차트 만들기 </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>단계:</em> 프레젠테이션 차트 만들기 </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 차트 만들기 </strong></a>

_Code Steps:_

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 데이터를 포함한 차트를 추가하고 원하는 차트 유형을 지정합니다. 
4. 차트에 제목을 추가합니다. 
5. 차트 데이터 워크시트에 접근합니다.
6. 기본 시리즈와 카테고리를 모두 삭제합니다.
7. 새로운 시리즈와 카테고리를 추가합니다.
8. 차트 시리즈에 새로운 데이터를 추가합니다.
9. 차트 시리즈에 채우기 색을 지정합니다.
10. 차트 시리즈에 레이블을 추가합니다. 
11. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 PHP 코드는 일반 차트를 만드는 방법을 보여 줍니다:

```php
  # PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # 기본 데이터가 포함된 차트를 추가합니다
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # 차트 제목을 설정합니다
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # 첫 번째 시리즈가 값을 표시하도록 설정합니다
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # 차트 데이터 시트의 인덱스를 설정합니다
    $defaultWorksheetIndex = 0;
    # 차트 데이터 워크시트를 가져옵니다
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 기본 생성된 시리즈와 카테고리를 삭제합니다
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # 새 시리즈를 추가합니다
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # 새 카테고리를 추가합니다
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # 첫 번째 차트 시리즈를 가져옵니다
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 이제 시리즈 데이터를 채웁니다
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # 시리즈의 채우기 색상을 설정합니다
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 두 번째 차트 시리즈를 가져옵니다
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 시리즈 데이터를 채웁니다
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # 시리즈의 채우기 색상을 설정합니다
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # 새 시리즈의 각 카테고리에 대한 사용자 정의 레이블을 생성합니다
    # 첫 번째 레이블이 카테고리 이름을 표시하도록 설정합니다
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # 세 번째 레이블에 값을 표시합니다
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # 차트가 포함된 프레젠테이션을 저장합니다
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **산점도 차트 만들기**
산점도 차트(또는 산점 플롯, x‑y 그래프)는 두 변수 간의 패턴을 확인하거나 상관 관계를 보여줄 때 자주 사용됩니다.

다음 경우에 산점도 차트를 사용할 수 있습니다

* 쌍을 이룬 수치 데이터가 있을 때
* 두 변수가 서로 잘 맞을 때
* 두 변수가 연관되어 있는지 확인하고 싶을 때
* 종속 변수에 대해 여러 값을 갖는 독립 변수가 있을 때

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>단계:</em> 산점도 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>단계:</em> PowerPoint 산점도 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 산점도 차트 만들기 </strong></a>

1. 위의 [일반 차트 만들기](#creating-normal-charts) 절을 그대로 따릅니다.
2. 세 번째 단계에서 차트를 추가하고 차트 유형을 다음 중 하나로 지정합니다.
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _산점도 차트를 나타냅니다._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _곡선으로 연결된 데이터 마커가 있는 산점도 차트를 나타냅니다._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _곡선으로 연결된 데이터 마커가 없는 산점도 차트를 나타냅니다._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _직선으로 연결된 데이터 마커가 있는 산점도 차트를 나타냅니다._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _직선으로 연결된 데이터 마커가 없는 산점도 차트를 나타냅니다._

다음 PHP 코드는 다양한 마커 시리즈를 사용한 산점도 차트를 만드는 방법을 보여 줍니다:

```php
  # PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $slide = $pres->getSlides()->get_Item(0);
    # 기본 차트를 생성합니다
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # 기본 차트 데이터 워크시트 인덱스를 가져옵니다
    $defaultWorksheetIndex = 0;
    # 차트 데이터 워크시트를 가져옵니다
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 데모 시리즈를 삭제합니다
    $chart->getChartData()->getSeries()->clear();
    # 새 시리즈를 추가합니다
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # 첫 번째 차트 시리즈를 가져옵니다
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 시리즈에 새 포인트 (1:3)를 추가합니다
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # 새 포인트 (2:10)를 추가합니다
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # 시리즈 유형을 변경합니다
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # 차트 시리즈 마커를 변경합니다
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # 두 번째 차트 시리즈를 가져옵니다
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 해당 위치에 새 포인트 (5:2)를 추가합니다
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # 새 포인트 (3:1)를 추가합니다
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # 새 포인트 (2:2)를 추가합니다
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # 새 포인트 (5:1)를 추가합니다
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # 차트 시리즈 마커를 변경합니다
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **원형 차트 만들기**

원형 차트는 데이터의 전체 대비 부분 관계를 보여줄 때 가장 적합합니다. 특히 범주형 라벨과 숫자 값이 있는 경우에 유용합니다. 그러나 라벨이나 파트가 너무 많다면 막대 차트를 고려하는 것이 좋습니다.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>단계:</em> 원형 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>단계:</em> PowerPoint 원형 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 원형 차트 만들기 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 얻습니다.
3. 기본 데이터를 포함하고 원하는 유형([ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ChartType).Pie)으로 차트를 추가합니다.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/)에 접근합니다.
5. 기본 시리즈와 카테고리를 삭제합니다.
6. 새로운 시리즈와 카테고리를 추가합니다.
7. 차트 시리즈에 새로운 데이터를 추가합니다.
8. 차트 포인트를 추가하고 원형 차트 구역에 사용자 정의 색을 지정합니다.
9. 시리즈 레이블을 설정합니다.
10. 시리즈 레이블에 리더 라인을 설정합니다.
11. 원형 차트 슬라이드의 회전 각도를 설정합니다.
12. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 PHP 코드는 원형 차트를 만드는 방법을 보여 줍니다:

```php
  # PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $slides = $pres->getSlides()->get_Item(0);
    # 기본 데이터가 포함된 차트를 추가합니다
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # 차트 제목을 설정합니다
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 첫 번째 시리즈가 값을 표시하도록 설정합니다
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
    # 시리즈 데이터를 채웁니다
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # 새로운 버전에서 작동하지 않음
    # 새로운 포인트를 추가하고 섹터 색상을 설정합니다
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # 섹터 테두리를 설정합니다
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # 섹터 테두리를 설정합니다
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # 섹터 테두리를 설정합니다
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # 새 시리즈의 각 카테고리에 대한 사용자 정의 레이블을 생성합니다
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # 차트에 리더 라인을 표시합니다
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # 파이 차트 섹터의 회전 각도를 설정합니다
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # 차트가 포함된 프레젠테이션을 저장합니다
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **선 차트 만들기**

선 차트(선 그래프)는 시간 경과에 따른 값 변화를 보여줄 때 가장 적합합니다. 선 차트를 사용하면 동시에 많은 데이터를 비교하고, 시간에 따른 변화와 추세를 추적하며, 데이터 시리즈의 이상 현상을 강조할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.
1. 기본 데이터를 포함하고 원하는 유형(`ChartType::Line`)으로 차트를 추가합니다.
1. 차트 데이터 IChartDataWorkbook에 접근합니다.
1. 기본 시리즈와 카테고리를 삭제합니다.
1. 새로운 시리즈와 카테고리를 추가합니다.
1. 차트 시리즈에 새로운 데이터를 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 PHP 코드는 선 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

기본적으로 선 차트의 포인트는 직선으로 연결됩니다. 대신 점선을 사용하려면 다음과 같이 원하는 대시 유형을 지정하면 됩니다:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **트리맵 차트 만들기**

트리맵 차트는 판매 데이터와 같이 카테고리 별 상대 크기를 보여주고, 동시에 각 카테고리에서 큰 기여도를 차지하는 항목에 주목하고자 할 때 가장 적합합니다.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>단계:</em> 트리맵 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>단계:</em> PowerPoint 트리맵 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 트리맵 차트 만들기 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 얻습니다.
3. 기본 데이터를 포함하고 원하는 유형([ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ChartType).TreeMap)으로 차트를 추가합니다.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/)에 접근합니다.
5. 기본 시리즈와 카테고리를 삭제합니다.
6. 새로운 시리즈와 카테고리를 추가합니다.
7. 차트 시리즈에 새로운 데이터를 추가합니다.
8. 수정된 프레젠테이션을 PPTX 파일로 저장합니다

다음 PHP 코드는 트리맵 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # 브랜치 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # 브랜치 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **주식 차트 만들기**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>단계:</em> 주식 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>단계:</em> PowerPoint 주식 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 주식 차트 만들기 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 얻습니다.
3. 기본 데이터를 포함하고 원하는 유형([ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ChartType).OpenHighLowClose)으로 차트를 추가합니다.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/)에 접근합니다.
5. 기본 시리즈와 카테고리를 삭제합니다.
6. 새로운 시리즈와 카테고리를 추가합니다.
7. 차트 시리즈에 새로운 데이터를 추가합니다.
8. HiLowLines 형식을 지정합니다.
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다

다음 PHP 샘플 코드는 주식 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **상자·수염 차트 만들기**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>단계:</em> 상자·수염 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>단계:</em> PowerPoint 상자·수염 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 상자·수염 차트 만들기 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 가져옵니다.
3. 기본 데이터를 포함하고 원하는 유형([ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ChartType).BoxAndWhisker)으로 차트를 추가합니다.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/)에 접근합니다.
5. 기본 시리즈와 카테고리를 삭제합니다.
6. 새로운 시리즈와 카테고리를 추가합니다.
7. 차트 시리즈에 새로운 데이터를 추가합니다.
8. 수정된 프레젠테이션을 PPTX 파일로 저장합니다

다음 PHP 코드는 상자·수염 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **퍼널 차트 만들기**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>단계:</em> 퍼널 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>단계:</em> PowerPoint 퍼널 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 퍼널 차트 만들기 </strong></a>


1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 얻습니다.
3. 기본 데이터를 포함하고 원하는 유형([ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ChartType).Funnel)으로 차트를 추가합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다

다음 PHP 코드는 퍼널 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **썬버스트 차트 만들기**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>단계:</em> 썬버스트 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>단계:</em> PowerPoint 썬버스트 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 썬버스트 차트 만들기 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 얻습니다.
3. 기본 데이터를 포함하고 원하는 유형([ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ChartType).sunburst)으로 차트를 추가합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다

다음 PHP 코드는 썬버스트 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # 브랜치 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # 브랜치 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **히스토그램 차트 만들기**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>단계:</em> 히스토그램 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>단계:</em> PowerPoint 히스토그램 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 히스토그램 차트 만들기 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 얻습니다.
3. 기본 데이터를 포함하고 원하는 유형([ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ChartType).Histogram)으로 차트를 추가합니다.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/)에 접근합니다.
5. 기본 시리즈와 카테고리를 삭제합니다.
6. 새로운 시리즈와 카테고리를 추가합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다

다음 PHP 코드는 히스토그램 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **레이다 차트 만들기**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>단계:</em> 레이다 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>단계:</em> PowerPoint 레이다 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 레이다 차트 만들기 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 가져옵니다. 
3. 데이터를 포함하고 원하는 차트 유형(`ChartType::Radar`)을 지정하여 차트를 추가합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다

다음 PHP 코드는 레이다 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **다중 카테고리 차트 만들기**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>단계:</em> 다중 카테고리 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>단계:</em> PowerPoint 다중 카테고리 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 다중 카테고리 차트 만들기 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 가져옵니다. 
3. 기본 데이터를 포함하고 원하는 유형([ChartType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ChartType).ClusteredColumn)으로 차트를 추가합니다.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/)에 접근합니다.
5. 기본 시리즈와 카테고리를 삭제합니다.
6. 새로운 시리즈와 카테고리를 추가합니다.
7. 차트 시리즈에 새로운 데이터를 추가합니다.
8. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 PHP 코드는 다중 카테고리 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # 시리즈 추가
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # 차트가 포함된 프레젠테이션 저장
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **맵 차트 만들기**

맵 차트는 데이터를 포함한 지역을 시각화한 것입니다. 맵 차트는 지리적 영역별 데이터나 값을 비교할 때 가장 적합합니다.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>단계:</em> 맵 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>단계:</em> PowerPoint 맵 차트 만들기 </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 맵 차트 만들기 </strong></a>

다음 PHP 코드는 맵 차트를 만드는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **콤보 차트 만들기**

콤보 차트(또는 복합 차트)는 하나의 그래프에 두 개 이상의 차트 유형을 결합합니다. 이 차트를 사용하면 두 개 이상의 데이터 세트를 강조·비교·검토할 수 있어 관계를 파악하는 데 도움이 됩니다.

![The combination chart](combination_chart.png)

다음 PHP 코드는 위에 표시된 콤보 차트를 PowerPoint 프레젠테이션에 만드는 방법을 보여 줍니다:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // 차트 제목을 설정합니다.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // 차트 레전드를 설정합니다.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // 기본 생성된 시리즈와 카테고리를 삭제합니다.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // 새 카테고리를 추가합니다.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // 첫 번째 시리즈를 추가합니다.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // 가로 축을 설정합니다.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // 세로 축을 설정합니다.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // 세로 주요 격자선 색상을 설정합니다.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // 보조 가로 축을 설정합니다.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // 보조 세로 축을 설정합니다.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **차트 업데이트**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>단계:</em> PowerPoint 차트 업데이트 </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>단계:</em> 프레젠테이션 차트 업데이트 </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>단계:</em> PowerPoint 프레젠테이션 차트 업데이트 </strong></a>

1. 업데이트하려는 차트를 포함한 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 사용해 슬라이드 참조를 얻습니다.
3. 모든 도형을 순회하여 원하는 차트를 찾습니다.
4. 차트 데이터 워크시트에 접근합니다.
5. 시리즈 값을 변경하여 차트 데이터 시리즈를 수정합니다.
6. 새 시리즈를 추가하고 데이터를 채웁니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 PHP 코드는 차트를 업데이트하는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # 기본 데이터가 포함된 차트를 가져옵니다
    $chart = $sld->getShapes()->get_Item(0);
    # 차트 데이터 시트의 인덱스를 설정합니다
    $defaultWorksheetIndex = 0;
    # 차트 데이터 워크시트를 가져옵니다
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 차트 카테고리 이름을 변경합니다
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # 첫 번째 차트 시리즈를 가져옵니다
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 이제 시리즈 데이터를 업데이트합니다
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1"); // 시리즈 이름 수정

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # 두 번째 차트 시리즈를 가져옵니다
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 이제 시리즈 데이터를 업데이트합니다
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2"); // 시리즈 이름 수정

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # 이제 새로운 시리즈를 추가합니다
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # 세 번째 차트 시리즈를 가져옵니다
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # 이제 시리즈 데이터를 채웁니다
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # 차트가 포함된 프레젠테이션을 저장합니다
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **차트 데이터 범위 설정**

차트의 데이터 범위를 설정하려면 다음을 수행하십시오:

1. 차트를 포함한 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 슬라이드 참조를 얻습니다.
3. 모든 도형을 순회하여 원하는 차트를 찾습니다.
4. 차트 데이터를 접근하고 범위를 설정합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 PHP 코드는 차트의 데이터 범위를 설정하는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **차트에서 기본 마커 사용**

차트에서 기본 마커를 사용하면 각 차트 시리즈에 자동으로 서로 다른 기본 마커 기호가 적용됩니다.

다음 PHP 코드는 차트 시리즈 마커를 자동으로 설정하는 방법을 보여 줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # 두 번째 차트 시리즈를 가져옵니다
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # 이제 시리즈 데이터를 채웁니다
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Aspose.Slides에서 지원하는 차트 유형은 무엇인가요?**

Aspose.Slides는 막대, 선, 원형, 영역, 산점도, 히스토그램, 레이다 등 다양한 [차트 유형](https://reference.aspose.com/slides/ko/php-java/aspose.slides/charttype/)을 지원합니다. 이 유연성을 통해 데이터 시각화 요구에 가장 적합한 차트 유형을 선택할 수 있습니다.

**슬라이드에 새 차트를 어떻게 추가하나요?**

차트를 추가하려면 먼저 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 만들고, 인덱스로 원하는 슬라이드를 가져온 다음, 차트 유형과 초기 데이터를 지정하여 차트를 추가하는 메서드를 호출합니다. 이 과정은 차트를 프레젠테이션에 직접 삽입합니다.

**차트에 표시되는 데이터를 어떻게 업데이트하나요?**

차트의 데이터를 업데이트하려면 차트 워크북([ChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/))에 접근하고, 기본 시리즈와 카테고리를 삭제한 뒤 사용자 정의 데이터를 추가합니다. 이를 통해 최신 데이터를 반영하도록 차트를 새로 고칠 수 있습니다.

**차트의 모양을 사용자 지정할 수 있나요?**

예, Aspose.Slides는 다양한 사용자 지정 옵션을 제공합니다. 색상, 글꼴, 레이블, 레전드 및 기타 [서식 요소](/slides/ko/php-java/chart-entities/)를 수정하여 차트를 특정 디자인 요구 사항에 맞게 조정할 수 있습니다.