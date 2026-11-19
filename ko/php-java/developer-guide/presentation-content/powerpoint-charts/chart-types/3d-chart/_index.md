---
title: PHP를 사용하여 프레젠테이션에서 3D 차트 맞춤 설정
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
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에 3D 차트를 생성합니다. 회전, 높이 비율, 차트 깊이 및 시리즈 간 간격을 PHP 예제로 조정합니다."
---
## **개요**

Aspose.Slides for PHP via Java은 [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) 메서드를 통해 3D 차트의 보기를 사용자 정의할 수 있습니다. 이 문서에서는 회전, 높이 비율, 깊이, 직각 축 및 시리즈 간 간격을 조정하고 프레젠테이션을 PPTX 형식으로 저장하는 방법을 보여줍니다.

## **3D 차트의 회전 및 깊이 설정**

아래 예제는 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)을 생성하고 [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart)를 사용하여 첫 번째 슬라이드에 누적 3D 열 차트를 추가합니다. 기본 시리즈와 범주를 각각 세 개의 값을 가진 두 개의 시리즈로 교체합니다. 워크시트 인덱스 `0`은 차트의 첫 번째 데이터 워크시트를 식별하고; 행 `0`은 시리즈 이름을, 열 `0`은 범주 레이블을 보유합니다.

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) 및 [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) 메서드는 차트의 회전을 각각 40도와 270도로 설정합니다. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents)는 너비의 150%로 깊이를 설정하고, [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes)는 원근 대신 직각 축을 사용하도록 합니다. 결과 프레젠테이션에는 이러한 3D 보기 설정이 적용된 차트가 포함됩니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **3D 차트의 높이 비율 조정**

[Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents)를 사용하여 3D 차트의 높이를 너비 대비 백분율로 설정합니다. 이렇게 하면 슬라이드의 차트 개체 크기를 변경하지 않고 3D 장면의 비율이 바뀝니다.

다음 예제는 기본 데이터(시리즈 3개, 카테고리 4개)를 사용하여 [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 차트를 생성합니다. 높이 비율을 50%, 100%, 200%로 설정한 세 개의 프레젠테이션을 저장합니다. 차트의 위치, 너비 및 높이는 고정된 상태로 유지됩니다. 데이터, 회전, 깊이, 시리즈 간 간격 및 서식은 세 파일 모두 동일하며, 높이 백분율만 변경됩니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

다음 이미지는 동일한 높이 설정을 .NET 예제와 동일하게 보여주며 Microsoft PowerPoint로 내보냈습니다. 작은 백분율은 더 평평한 장면을 만들고, 큰 백분율은 동일 차트 개체 내에서 더 높은 장면을 만듭니다. PowerPoint는 또한 축 눈금 간격 및 레이블 위치를 장면에 맞게 조정할 수 있습니다.

| 높이: 50% | 높이: 100% | 높이: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

이 메서드들은 차트의 다양한 측면을 제어합니다:

| Method | Effect |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 높이 비율(차트 너비 대비 3D 장면의 높이) |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | 슬라이드에서 차트 개체의 높이(포인트 단위) |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 너비 대비 3D 장면의 깊이 백분율 |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 마커 너비 대비 깊이 축을 따라 시리즈 간 간격 |

높이 설정은 실린더, 원뿔, 피라미드 변형을 포함한 3D 열 및 막대 차트와 3D 선, 영역, 원형, 표면 차트에 영향을 줍니다. 위 비교는 검증된 `Column3D` 유형을 사용했습니다. 이 설정은 2D `ClusteredColumn` 차트나 `BubbleWith3D` 차트의 외관을 변경하지 않으며, 이 이름들은 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 클래스의 멤버입니다. 다른 차트 외관 설정에 대해서는 [Chart Formatting](/slides/ko/php-java/chart-formatting/)을 참조하십시오.

## **시리즈 간 간격 조정**

[ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth)를 사용하여 3D 차트의 깊이 축을 따라 데이터 시리즈 간 거리를 마커 너비 대비 백분율로 제어합니다. **0부터 500**까지 포함하는 값을 사용합니다: `0`은 간격을 제거하고, 큰 값은 간격을 늘립니다. 차트 깊이가 고정된 상태에서 간격을 늘리면 깊이 축을 따라 마커가 얇아집니다.

[ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup)를 통해 그룹에 접근합니다. 이 설정은 해당 그룹의 모든 시리즈에 적용되며, 접근에 사용된 시리즈에만 국한되지 않습니다. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth)는 깊이 간격을 반환하고 부모 그룹의 설정을 반영합니다.

이 설정은 실린더, 원뿔, 피라미드 변형을 포함한 3D 열 및 막대 차트와 3D 선 및 영역 차트에 영향을 줍니다. 외관은 시리즈가 깊이 순으로 정렬되었는지, 클러스터링 되었는지, 누적으로 표시되는지에 따라 달라집니다. 개별 시리즈 간 간격을 명확히 비교하려면 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 클래스의 `ChartType::Column3D`를 사용하십시오.

이 메서드들은 차트의 다양한 측면을 제어합니다:

| Method | Effect |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 깊이 축을 따라 시리즈 간 간격, 마커 너비 대비 백분율 |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | 인접한 막대 또는 열 클러스터 간 간격, 막대 또는 열 너비 대비 백분율 |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 차트 전체 깊이, 차트 너비 대비 백분율 |

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

다음 독립형 예제는 기본 차트 데이터를 사용하며, 여기에는 세 개의 시리즈와 네 개의 카테고리가 포함됩니다. 동일한 데이터, 회전, 간격 너비 및 차트 깊이를 가진 두 개의 프레젠테이션을 저장합니다; 간격 깊이만 변경됩니다.

| 간격 깊이: 0% | 간격 깊이: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **3D 시리즈 유형 및 막대 모양 변경**

클러스터드 실린더 차트에서 첫 번째 시리즈는 실린더 막대 모양으로 시작합니다. 예제는 각 변경 전후에 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) 및 [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/)이 반환하는 정수 값을 출력합니다. 표에는 해당 상수 이름이 나와 있습니다.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 첫 번째 시리즈에 대한 변경 | 시리즈 유형 | 막대 모양 |
| --- | --- | --- |
| 차트 생성 | `ClusteredCylinder` | `Cylinder` |
| 시리즈 유형을 `ClusteredCone`으로 설정 | `ClusteredCone` | `Cone` |
| 막대 모양을 `Box`로 설정 | `ClusteredColumn3D` | `Box` |

`Box` 모양으로 설정하면 시리즈 유형도 `ClusteredColumn3D`로 변경됩니다. 코드가 시리즈 유형에 따라 분기한다면, 모양을 변경한 후에 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/)을 호출하십시오. 할당 전에 캐시된 값은 여전히 `ClusteredCone` 분기를 선택할 수 있습니다.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **FAQ**

**어떤 차트 유형이 Aspose.Slides에서 3D 모드를 지원합니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등 열 차트의 3D 변형과 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 클래스에서 제공되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참조에서 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 멤버를 확인하십시오.

**보고서나 웹용으로 3D 차트의 래스터 이미지를 얻을 수 있나요?**

예. [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) 또는 전체 슬라이드를 [render the entire slide](/slides/ko/php-java/convert-powerpoint-to-png/)와 같이 PNG 또는 JPEG 형식으로 내보낼 수 있습니다. 이는 래스터 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드, 웹 페이지에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 빌드하고 렌더링하는 성능은 어떻습니까?**

성능은 데이터 양과 시각적 복잡도에 따라 달라집니다. 최상의 결과를 위해 3D 효과를 최소화하고, 벽 및 플롯 영역에 무거운 텍스처를 피하며, 가능하면 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이 또는 인쇄 요구에 맞는 적절한 해상도와 차원으로 출력하십시오.