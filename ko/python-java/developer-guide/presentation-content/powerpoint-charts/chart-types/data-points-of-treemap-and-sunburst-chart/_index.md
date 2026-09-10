---
title: Python에서 Treemap 및 Sunburst 차트의 데이터 포인트 사용자 지정
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- 트리맵 차트
- Sunburst 차트
- 계층형 차트
- 데이터 포인트
- 데이터 레이블
- 브랜치 색상
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 Treemap 및 Sunburst 차트에서 계층형 데이터를 생성하고 레벨, 레이블 및 색상을 사용자 지정하는 방법을 배우세요."
---
## **개요**

Treemap 및 Sunburst 차트는 동일한 계층형 데이터를 표시하지만 레이아웃이 다릅니다. Treemap은 영역이 리프 값에 해당하도록 중첩된 직사각형으로 계층을 그립니다. Sunburst는 동심원 형태로 그리며, 최상위 그룹은 중앙에 가깝고 리프 카테고리는 외부 원에 위치합니다.

Aspose.Slides for Python via Java에서 각 숫자 값은 [ChartDataPoint](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/). 해당 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) 메서드는 리프와 해당 부모 그룹에 접근할 수 있게 합니다. 이 문서에서는 해당 매핑을 설명하고 동일한 샘플 데이터를 사용하여 두 차트 유형을 생성하고 서식 지정하는 방법을 보여줍니다.

![소비자 및 비즈니스 지점을 포함한 Treemap 차트](treemap-hierarchy.png)

![동일한 소비자 및 비즈니스 계층 구조를 가진 Sunburst 차트](sunburst-hierarchy.png)

## **카테고리, 데이터 포인트 및 레벨 이해**

아래에 사용된 샘플은 세 개의 카테고리 레벨과 하나의 숫자 시리즈를 가지고 있습니다:

| 브랜치 | 스텀 | 리프 | 수익 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

각 행은 하나의 리프 카테고리와 하나의 데이터 포인트를 생성합니다. 카테고리 그룹화 레벨은 해당 리프에서 부모까지의 경로를 설명합니다. 첫 번째 행의 경로는 `Consumer > Computers > Laptops`입니다.

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getDataPointLevels)에서 반환되는 인덱스는 리프에서 위쪽으로 진행합니다:

| `getDataPointLevels()` 인덱스 | 논리 레벨 | Treemap 표현 | Sunburst 표현 |
| ---: | --- | --- | --- |
| `0` | 리프 | 값 사각형 | 외부 링 세그먼트 |
| `1` | 스텀 | 부모 사각형 또는 헤더 | 중간 링 세그먼트 |
| `2` | 브랜치 | 최상위 사각형 또는 헤더 | 내부 링 세그먼트 |

이 순서는 시각적 레이아웃은 다르지만 두 차트 유형 모두 동일합니다. 부모 세그먼트는 여러 리프가 공유합니다. 이를 서식 지정하려면 해당 그룹의 첫 번째 데이터 포인트에 해당하는 레벨을 사용합니다. 예를 들어 `Consumer` 브랜치는 `Laptops` 포인트로 시작하고, `Software` 스텀은 `Licenses` 포인트로 시작합니다. 이러한 포인트에 대한 참조를 유지하는 것이 `data_points.get_Item(0)` 또는 `data_points.get_Item(6)`와 같은 설명되지 않은 표현을 사용하는 것보다 더 명확하고 안전합니다.

## **두 차트 유형 모두 생성 및 사용자 지정**

다음 전체 예제는 첫 번째 슬라이드에 Treemap을, 두 번째 슬라이드에 Sunburst를 생성합니다. 계층 구조를 구축하고, `Tablets` 값이 표시되며, 선택한 레벨에 고정 색상을 적용하고, 브랜치 레이블을 서식 지정한 후 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # 리프 카테고리를 추가합니다. 그룹 항목은 새 그룹이 시작될 때만 설정됩니다;
        # 다음 카테고리들은 다른 항목이 설정될 때까지 해당 그룹에 남아 있습니다.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Tablets 리프에 카테고리와 값을 표시합니다.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # 해당 브랜치의 첫 번째 리프를 통해 Consumer 브랜치를 서식 지정합니다.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # 해당 스템의 첫 번째 리프를 통해 Software 스템을 서식 지정합니다.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout은 Treemap 부모 레이블에 영향을 주고; Sunburst는 링 세그먼트를 사용합니다.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

카테고리 셀과 값 셀은 동일한 워크시트 행을 사용하므로 컬렉션 위치가 정렬된 상태를 유지합니다. 새 차트를 생성하는 대신 기존 차트를 사용할 경우, 먼저 카테고리 행을 검사하고 서식 지정하려는 데이터 포인트와 레벨에 대한 명명된 참조를 저장하십시오.

## **동작 및 실용적인 고려 사항**

### **Treemap 및 Sunburst 차이점**

- Treemap은 면적을 사용해 값을 전달하고 중첩된 직사각형으로 계층을 전달합니다. 해당 차트 유형에서 부모 레이블이 표시되는 방식을 제어하는 메서드는 [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#setParentLabelLayout)입니다.
- Sunburst는 각도를 사용해 값을 전달하고 링 깊이로 계층을 전달합니다. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#setParentLabelLayout)은 해당 차트의 링 레이블을 제어하지 않습니다.
- 두 차트 유형 모두 동일한 카테고리 그룹화 레벨과 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getDataPointLevels)에서 반환되는 동일한 리프-부모 순서를 사용하므로 데이터 구축 및 레벨 서식 지정 코드를 공유할 수 있습니다.
- 부모 값은 하위 리프에서 계산됩니다. 브랜치나 스텀에 별도의 숫자 포인트를 추가하지 마십시오.

### **정렬 및 세그먼트 순서**

차트 레이아웃 엔진이 직사각형과 링 세그먼트의 최종 배치를 결정합니다. 관련 카테고리 행을 함께 배치한 후 추가하되, 특정 직사각형 위치나 시작 각도에 의존하지 마십시오. 순서에 의미가 있다면 레이블에 포함하거나 명시적인 카테고리 축을 갖는 차트 유형을 사용하십시오.

### **테마 및 고정 색상**

서식이 지정되지 않은 차트 레벨은 프레젠테이션 테마에서 색상을 상속합니다. 예제에서는 예측 가능한 결과를 위해 명시적인 RGB 채우기를 사용합니다. 차트가 테마 변경을 따라야 한다면 고정 RGB 값 대신 스키마 색상을 사용하고 모든 레벨을 덮어쓰는 것을 피하십시오. 또한 브랜치나 스텀 채우기를 변경한 후 레이블 대비를 확인하십시오.

### **레이블 및 사용 가능한 공간**

PowerPoint는 세그먼트가 너무 작을 경우 레이블을 숨기거나 잘라낼 수 있습니다. 차트 크기를 늘리거나 카테고리 이름을 짧게 하거나 표시되는 레이블 필드를 줄이면 일반적으로 더 명확한 결과를 얻을 수 있습니다. 레이블은 [DataLabelFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datalabelformat/)을 통해 카테고리 이름, 시리즈 이름 및 값을 결합할 수 있지만, 모든 필드를 활성화하면 계층형 차트를 읽기 어려워지는 경우가 많습니다.

### **내보내기 및 렌더링**

PPTX로 저장하면 차트를 편집 가능한 상태로 유지합니다. Aspose.Slides가 프레젠테이션을 PDF나 이미지로 렌더링할 때, 지원되는 채우기와 레이블 설정이 차트와 함께 렌더링됩니다. 글꼴 대체 및 사용 가능한 레이아웃 공간의 작은 차이가 줄 바꿈이나 레이블 가시성을 변경할 수 있으므로 필요한 글꼴을 설치하고 중요한 내보내기 대상이 올바른지 확인하십시오.

## **FAQ**

**왜 부모 레벨을 변경하면 여러 리프에 영향을 줍니까?**

브랜치나 스텀은 공유된 시각적 세그먼트입니다. 해당 [ChartDataPointLevel](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapointlevel/)은 하위 리프를 통해 접근할 수 있지만, 서식은 해당 리프만이 아니라 공유된 부모 세그먼트에 적용됩니다.

**왜 데이터 레이블이 누락되나요?**

먼저 레이블의 [DataLabelFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datalabelformat/) 객체에서 필요한 필드를 활성화하십시오. 그런 다음 세그먼트에 충분한 공간이 있는지 확인합니다. Treemap 부모 레이블 레이아웃, 차트 크기, 레이블 길이, 글꼴 크기 및 활성화된 필드 수가 레이블 표시 가능 여부에 영향을 줍니다.

**세그먼트의 정확한 순서나 좌표를 지정할 수 있나요?**

소스 행 순서를 제어하고 각 그룹을 연속적으로 유지할 수는 있지만, 정확한 Treemap 직사각형이나 Sunburst 각도를 지정할 수는 없습니다. 차트 레이아웃 엔진이 계층 구조, 값 및 사용 가능한 공간을 기반으로 계산합니다.

**프레젠테이션 테마가 변경된 후 색상이 왜 바뀌나요?**

테마 기반 채우기는 프레젠테이션 팔레트를 따르도록 설계되었습니다. 고정되어 있어야 하는 레벨에는 명시적인 RGB 색상을 적용하거나, 새로운 테마에 맞출 때는 스키마 색상을 유지하십시오.

**PDF 및 이미지 내보내기에서 사용자 지정 서식이 유지되나요?**

예, 지원되는 차트 채우기와 레이블 설정은 렌더링 시 포함됩니다. 시스템 간 일관된 결과를 얻으려면 필요한 글꼴을 제공하고, 레이블 맞춤이 레이아웃에 따라 달라지므로 최종 내보내기 크기를 테스트하십시오.

## **관련 항목**

- [Treemap 차트 만들기](/slides/ko/python-java/create-chart/#create-tree-map-charts)
- [Sunburst 차트 만들기](/slides/ko/python-java/create-chart/#create-sunburst-charts)
- [프레젠테이션 차트 내보내기](/slides/ko/python-java/export-chart/)
- [프레젠테이션 테마 관리](/slides/ko/python-java/presentation-theme/)