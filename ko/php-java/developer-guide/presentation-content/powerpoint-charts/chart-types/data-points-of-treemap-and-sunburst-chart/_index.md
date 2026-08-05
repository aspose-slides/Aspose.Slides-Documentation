---
title: PHP에서 트리맵 및 썬버스트 차트의 데이터 포인트 사용자 지정
linktitle: 트리맵 및 썬버스트 차트의 데이터 포인트
type: docs
url: /ko/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- 트리맵 차트
- 썬버스트 차트
- 계층형 차트
- 데이터 포인트
- 데이터 레이블
- 지점 색상
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 트리맵 및 썬버스트 차트에서 계층형 데이터를 생성하고 레벨, 레이블 및 색상을 사용자 지정하는 방법을 배웁니다."
---
## **개요**

Treemap 및 Sunburst 차트는 동일한 계층형 데이터를 표시하지만 레이아웃이 다릅니다. Treemap은 영역이 값에 해당하는 중첩 사각형으로 계층을 나타냅니다. Sunburst는 동심 원으로 그리며 최상위 그룹은 중심에 가깝고 잎 카테고리는 외곽 원에 위치합니다.

Aspose.Slides for PHP via Java에서는 각 숫자 값이 [ChartDataPoint](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/)입니다. Its [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) 메서드는 잎과 그 부모 그룹에 대한 접근을 제공합니다. 이 문서에서는 해당 매핑을 설명하고 동일한 샘플 데이터를 사용해 두 차트 유형을 만드는 방법과 서식을 지정하는 방법을 보여줍니다.

![소비자 및 비즈니스 지점을 포함한 트리맵 차트](treemap-hierarchy.png)

![동일한 소비자 및 비즈니스 계층 구조를 포함한 썬버스트 차트](sunburst-hierarchy.png)

## **카테고리, 데이터 포인트 및 레벨 이해하기**

아래 예제는 세 개의 카테고리 레벨과 하나의 숫자 시리즈를 사용합니다.

| 지점 | 줄기 | 잎 | 수익 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

각 행은 하나의 잎 카테고리와 하나의 데이터 포인트를 생성합니다. 카테고리 그룹 레벨은 해당 잎에서 부모까지의 경로를 설명합니다. 첫 번째 행의 경우 경로는 `Consumer > Computers > Laptops`입니다.

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) 메서드가 반환하는 인덱스는 잎에서 위쪽으로 올라갑니다.

| `getDataPointLevels()` 인덱스 | 논리 레벨 | Treemap 표현 | Sunburst 표현 |
| ---: | --- | --- | --- |
| `0` | 잎 | 값 사각형 | 외곽 링 세그먼트 |
| `1` | 줄기 | 부모 사각형 또는 헤더 | 중간 링 세그먼트 |
| `2` | 지점 | 최상위 사각형 또는 헤더 | 내부 링 세그먼트 |

이 순서는 두 차트 유형 모두 동일하지만 시각적 레이아웃은 다릅니다. 하나의 부모 세그먼트가 여러 잎과 공유됩니다. 해당 부모 세그먼트를 서식 지정하려면 그룹 내 첫 번째 데이터 포인트의 해당 레벨을 사용합니다. 예를 들어 `Consumer` 지점은 `Laptops` 포인트로 시작하고 `Software` 줄기는 `Licenses` 포인트로 시작합니다. 이러한 포인트에 대한 참조를 보관하는 것이 `$dataPoints->get_Item(0)`이나 `$dataPoints->get_Item(6)`와 같은 설명되지 않은 표현을 사용하는 것보다 더 명확하고 안전합니다.

## **두 차트 유형 만들기 및 사용자 지정**

다음 완전한 예제는 첫 번째 슬라이드에 Treemap을, 두 번째 슬라이드에 Sunburst를 생성합니다. 계층 구조를 구축하고, `Tablets` 값은 표시하며, 선택한 레벨에 고정 색상을 적용하고, 지점 레이블을 서식 지정한 다음 프레젠테이션을 저장합니다.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // 잎 카테고리를 추가합니다. 새로운 그룹이 시작될 때만 그룹화 항목이 설정됩니다;
        // 그 다음 카테고리들은 다른 항목이 설정될 때까지 해당 그룹에 남아 있습니다.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Tablets 잎에 카테고리와 값을 표시합니다.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // 그 지점의 첫 번째 잎을 통해 Consumer 지점을 서식 지정합니다.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // 그 줄기의 첫 번째 잎을 통해 Software 줄기를 서식 지정합니다.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout은 Treemap 부모 레이블에 영향을 주며; Sunburst는 링 세그먼트를 사용합니다.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

카테고리 셀과 값 셀은 동일한 워크시트 행을 사용하므로 컬렉션 위치가 정렬된 상태로 유지됩니다. 기존 차트를 수정할 때는 먼저 카테고리 행을 검사하고 서식 지정하려는 데이터 포인트와 레벨에 대한 이름 있는 참조를 저장하십시오.

## **동작 및 실용적인 고려 사항**

### **Treemap과 Sunburst 차이점**

- Treemap은 면적을 값으로, 중첩 사각형을 계층으로 사용합니다. 이 차트 유형에서 부모 레이블이 표시되는 방식을 제어하려면 [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#setParentLabelLayout) 메서드를 사용합니다.
- Sunburst는 각도를 값으로, 링 깊이를 계층으로 사용합니다. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartseries/#setParentLabelLayout) 은 링 레이블을 제어하지 않습니다.
- 두 차트 유형 모두 동일한 카테고리 그룹 레벨과 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) 가 반환하는 잎‑부모 순서를 사용하므로 데이터 구축 및 레벨 서식 지정 코드를 공유할 수 있습니다.
- 부모 값은 하위 잎에서 계산됩니다. 지점이나 줄기에 별도의 숫자 포인트를 추가하지 마십시오.

### **정렬 및 세그먼트 순서**

차트 레이아웃 엔진이 사각형과 링 세그먼트의 최종 위치를 결정합니다. 관련 카테고리 행을 함께 배치한 후 추가하되, 특정 사각형 위치나 시작 각도에 의존하지 마십시오. 순서 자체에 의미가 있다면 레이블에 포함하거나 명시적인 카테고리 축을 갖는 차트 유형을 사용하십시오.

### **테마 및 고정 색상**

서식이 지정되지 않은 차트 레벨은 프레젠테이션 테마에서 색상을 상속받습니다. 예제에서는 예측 가능한 출력을 위해 명시적인 RGB 채우기를 사용합니다. 차트가 테마 변경을 따라가야 한다면 고정 RGB 값 대신 스킴 색상을 사용하고 모든 레벨을 무조건 재정의하지 마십시오. 또한 지점이나 줄기 채우기를 변경한 후 레이블 대비를 확인하십시오.

### **레이블 및 사용 가능한 공간**

세그먼트가 너무 작으면 PowerPoint가 레이블을 숨기거나 잘라낼 수 있습니다. 차트 크기를 늘리거나 카테고리 이름을 짧게 하거나 표시되는 레이블 필드를 줄이면 보통 더 명확한 결과를 얻을 수 있습니다. 레이블은 [DataLabelFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat/) 를 통해 카테고리 이름, 시리즈 이름, 값을 결합할 수 있지만, 모든 필드를 활성화하면 계층형 차트를 읽기 어렵게 만들 수 있습니다.

### **내보내기 및 렌더링**

PPTX로 저장하면 차트를 편집할 수 있는 상태로 유지됩니다. Aspose.Slides가 프레젠테이션을 PDF 또는 이미지로 렌더링할 때 지원되는 채우기와 레이블 설정이 차트와 함께 렌더링됩니다. 글꼴 대체와 사용 가능한 레이아웃 공간의 작은 차이로 인해 줄 바꿈이나 레이블 가시성이 달라질 수 있으므로 필요한 글꼴을 설치하고 중요한 내보내기 대상에 대해 확인하십시오.

## **FAQ**

**부모 레벨을 변경하면 여러 잎에 영향을 미치는 이유는 무엇인가요?**

지점이나 줄기는 공유되는 시각적 세그먼트입니다. 해당 [ChartDataPointLevel](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatapointlevel/) 은 하위 잎을 통해 접근할 수 있지만 서식은 해당 잎만이 아니라 공유된 부모 세그먼트에 적용됩니다.

**데이터 레이블이 표시되지 않는 이유는?**

먼저 레이블의 [DataLabelFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/datalabelformat/) 객체에서 필요한 필드를 활성화하십시오. 그런 다음 세그먼트에 충분한 공간이 있는지 확인합니다. Treemap 부모 레이블 레이아웃, 차트 크기, 레이블 길이, 글꼴 크기 및 활성화된 필드 수가 레이블 표시 여부에 영향을 줍니다.

**세그먼트의 정확한 순서나 좌표를 설정할 수 있나요?**

소스 행 순서를 제어하고 각 그룹을 연속적으로 유지할 수는 있지만, 정확한 Treemap 사각형이나 Sunburst 각도를 지정할 수는 없습니다. 차트 레이아웃 엔진이 계층 구조, 값 및 사용 가능한 공간을 기반으로 계산합니다.

**프레젠테이션 테마가 변경된 후 색상이 바뀌는 이유는?**

테마 기반 채우기는 프레젠테이션 팔레트를 따르도록 설계되었습니다. 고정된 색상이 필요한 레벨에는 명시적인 RGB 색상을 적용하거나, 새로운 테마에 맞게 조정하려면 스킴 색상을 유지하십시오.

**PDF 및 이미지 내보내기에서 사용자 지정 서식이 보존되나요?**

예, 지원되는 차트 채우기와 레이블 설정은 렌더링 시 포함됩니다. 시스템 간 일관된 결과를 위해 필요한 글꼴을 제공하고 레이블 맞춤이 레이아웃에 의존하므로 최종 내보내기 크기를 테스트하십시오.

## **관련 문서**

- [Treemap 차트 만들기](/slides/ko/php-java/create-chart/#create-tree-map-charts)
- [Sunburst 차트 만들기](/slides/ko/php-java/create-chart/#create-sunburst-charts)
- [프레젠테이션 차트 내보내기](/slides/ko/php-java/export-chart/)
- [프레젠테이션 테마 관리](/slides/ko/php-java/presentation-theme/)