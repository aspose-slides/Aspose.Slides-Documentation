---
title: JavaScript를 사용한 Treemap 및 Sunburst 차트 데이터 포인트 사용자 지정
linktitle: Treemap 및 Sunburst 차트 데이터 포인트
type: docs
url: /ko/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 차트
- Sunburst 차트
- 계층형 차트
- 데이터 포인트
- 데이터 레이블
- 브랜치 색상
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 Treemap 및 Sunburst 차트에서 계층형 데이터를 생성하고 레벨, 레이블 및 색상을 사용자 지정하는 방법을 배우세요."
---
## **개요**

Treemap과 Sunburst 차트는 동일한 계층형 데이터를 표시하지만 레이아웃이 다릅니다. Treemap은 영역이 값(리프)을 나타내는 중첩 사각형으로 계층을 그립니다. Sunburst는 동심원 형태로 그리며, 최상위 그룹은 중앙에 가깝고 리프 카테고리는 외부 링에 배치됩니다.

Aspose.Slides for Node.js via Java에서는 각 숫자 값을 [ChartDataPoint](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/) 로 표현합니다. 해당 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) 메서드는 리프와 그 상위 그룹에 접근할 수 있게 해줍니다. 이 문서에서는 그 매핑을 설명하고 동일한 샘플 데이터를 사용해 두 차트 유형을 만들고 서식 지정하는 방법을 보여줍니다.

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **카테고리, 데이터 포인트 및 레벨 이해**

아래에 사용된 샘플에는 세 개의 카테고리 레벨과 하나의 숫자 시리즈가 있습니다.

| Branch | Stem | Leaf | Revenue |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

각 행은 하나의 리프 카테고리와 하나의 데이터 포인트를 생성합니다. 카테고리 그룹화 레벨은 해당 리프에서 상위까지의 경로를 설명합니다. 첫 번째 행의 경우 경로는 `Consumer > Computers > Laptops` 입니다.

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) 에서 반환되는 인덱스는 리프에서 위쪽으로 진행됩니다.

| `getDataPointLevels()` 인덱스 | 논리 레벨 | Treemap 표현 | Sunburst 표현 |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

이 순서는 두 차트 유형 모두 동일하지만 시각적 레이아웃은 다릅니다. 하나의 상위 세그먼트가 여러 리프와 공유됩니다. 해당 세그먼트를 서식 지정하려면 해당 그룹의 첫 번째 데이터 포인트 레벨을 사용합니다. 예를 들어 `Consumer` 브랜치는 `Laptops` 포인트로 시작하고, `Software` 스템은 `Licenses` 포인트로 시작합니다. 이런 포인트에 대한 참조를 보관하는 것이 `dataPoints.get_Item(0)` 이나 `dataPoints.get_Item(6)` 같은 설명 없는 표현을 사용하는 것보다 명확하고 안전합니다.

## **두 차트 유형 모두 만들고 사용자 정의하기**

다음 완전한 예제는 첫 번째 슬라이드에 Treemap을, 두 번째 슬라이드에 Sunburst를 생성합니다. 계층을 구축하고, `Tablets` 값은 표시하며, 선택된 레벨에 고정 색상을 적용하고, 브랜치 레이블을 서식 지정한 뒤 프레젠테이션을 저장합니다.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // 리프 카테고리를 추가합니다. 새 그룹이 시작될 때만 그룹 항목이 설정됩니다;
        // 다음 카테고리들은 다른 항목이 설정될 때까지 해당 그룹에 남아 있습니다.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Tablets 리프에 카테고리와 값을 표시합니다.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Consumer 브랜치를 해당 브랜치의 첫 번째 리프를 통해 서식 지정합니다.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Software 스템을 해당 스템의 첫 번째 리프를 통해 서식 지정합니다.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout은 Treemap의 부모 레이블에 영향을 주며; Sunburst는 링 세그먼트를 사용합니다.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

카테고리 셀과 값 셀은 동일한 워크시트 행을 사용하므로 컬렉션 위치가 정렬된 상태를 유지합니다. 기존 차트를 수정할 때는 차트를 새로 만드는 것이 아니라, 먼저 카테고리 행을 검사하고 서식 지정하려는 데이터 포인트와 레벨에 대한 명명된 참조를 저장하십시오.

## **동작 및 실용적인 고려 사항**

### **Treemap과 Sunburst 차이점**

- Treemap은 면적을 사용해 값을 전달하고 중첩 사각형으로 계층을 전달합니다. 이 차트 유형에서 부모 레이블 표시 방식을 제어하는 메서드는 [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) 입니다.
- Sunburst는 각도를 사용해 값을 전달하고 링 깊이로 계층을 전달합니다. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) 은 링 레이블을 제어하지 않습니다.
- 두 차트 유형 모두 동일한 카테고리 그룹화 레벨과 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) 로 반환되는 리프‑상위 순서를 사용하므로 데이터 구축 및 레벨 서식 지정 코드를 공유할 수 있습니다.
- 부모 값은 하위 리프에서 계산됩니다. 브랜치나 스템에 별도의 숫자 포인트를 추가하지 마십시오.

### **정렬 및 세그먼트 순서**

차트 레이아웃 엔진이 사각형과 링 세그먼트의 최종 위치를 결정합니다. 관련 카테고리 행을 함께 배치한 뒤 추가하되, 특정 사각형 위치나 시작 각도에 의존하지 마십시오. 순서에 의미가 있다면 레이블에 포함하거나 명시적인 카테고리 축을 갖는 차트 유형을 사용하십시오.

### **테마 및 고정 색상**

서식이 지정되지 않은 차트 레벨은 프레젠테이션 테마에서 색을 상속받습니다. 예제에서는 예측 가능한 출력 결과를 위해 명시적인 RGB 채우기를 사용했습니다. 차트가 테마 변화를 따라야 한다면 고정 RGB 값 대신 스키마 색상을 사용하고 모든 레벨을 덮어쓰지 않도록 하십시오. 또한 브랜치나 스템 채우기를 변경한 후 레이블 대비를 확인하십시오.

### **레이블 및 사용 가능한 공간**

세그먼트가 너무 작으면 PowerPoint가 레이블을 숨기거나 잘라낼 수 있습니다. 차트 크기를 키우거나 카테고리 이름을 짧게 하거나 표시되는 레이블 필드를 줄이면 일반적으로 더 명확한 결과를 얻을 수 있습니다. 레이블은 [DataLabelFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabelformat/) 을 통해 카테고리명, 시리즈명, 값을 결합할 수 있지만, 모든 필드를 활성화하면 계층형 차트를 읽기 어렵게 만들 수 있습니다.

### **내보내기 및 렌더링**

PPTX로 저장하면 차트를 편집 가능하게 유지합니다. Aspose.Slides가 프레젠테이션을 PDF나 이미지로 렌더링할 때 지원되는 채우기와 레이블 설정이 차트와 함께 렌더링됩니다. 글꼴 대체와 사용 가능한 레이아웃 공간의 작은 차이가 줄 바꿈이나 레이블 가시성에 영향을 줄 수 있으므로 필요한 글꼴을 설치하고 중요한 내보내기 대상에 대해 검증하십시오.

## **FAQ**

**부모 레벨을 변경하면 여러 리프에 영향을 주는 이유는?**

브랜치나 스템은 공유되는 시각적 세그먼트입니다. 해당 [ChartDataPointLevel](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapointlevel/) 은 하위 리프를 통해 접근할 수 있지만, 서식은 해당 리프만이 아니라 공유된 부모 세그먼트에 적용됩니다.

**데이터 레이블이 보이지 않는 이유는?**

먼저 레이블의 [DataLabelFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabelformat/) 객체에서 필요한 필드를 활성화하십시오. 그런 다음 해당 세그먼트에 충분한 공간이 있는지 확인합니다. Treemap의 부모 레이블 레이아웃, 차트 크기, 레이블 길이, 글꼴 크기 및 활성화된 필드 수가 레이블 표시 여부에 영향을 줍니다.

**세그먼트의 정확한 순서나 좌표를 지정할 수 있나요?**

소스 행 순서를 제어하고 각 그룹을 연속적으로 유지할 수는 있지만, Treemap 사각형이나 Sunburst 각도를 정확히 지정할 수는 없습니다. 차트 레이아웃 엔진이 계층 구조, 값 및 사용 가능한 공간을 기반으로 계산합니다.

**프레젠테이션 테마가 바뀌면 색상이 바뀌는 이유는?**

테마 기반 채우기는 프레젠테이션 팔레트를 따르도록 설계되었습니다. 고정되어야 할 레벨에는 명시적인 RGB 색상을 적용하거나, 새 테마에 맞게 조정하려면 스키마 색상을 유지하십시오.

**PDF 및 이미지 내보내기에서 사용자 지정 서식이 유지되나요?**

예, 지원되는 차트 채우기와 레이블 설정은 렌더링 시 포함됩니다. 시스템 간 일관된 결과를 위해 필요한 글꼴을 제공하고 레이블 맞춤이 레이아웃에 따라 달라지므로 최종 내보내기 크기를 테스트하십시오.

## **관련 문서**

- [Create Treemap charts](/slides/ko/nodejs-java/create-chart/#creating-tree-map-charts)
- [Create Sunburst charts](/slides/ko/nodejs-java/create-chart/#creating-sunburst-charts)
- [Export presentation charts](/slides/ko/nodejs-java/export-chart/)
- [Manage presentation themes](/slides/ko/nodejs-java/presentation-theme/)