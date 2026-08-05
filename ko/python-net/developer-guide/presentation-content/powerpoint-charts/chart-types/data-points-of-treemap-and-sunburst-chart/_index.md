---
title: Python에서 Treemap 및 Sunburst 차트의 데이터 포인트 맞춤
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- 트리맵 차트
- 선버스트 차트
- 계층형 차트
- 데이터 포인트
- 데이터 레이블
- 브랜치 색
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET을 사용하여 Treemap 및 Sunburst 차트에서 계층 데이터를 만들고 레벨, 레이블 및 색상을 사용자 지정하는 방법을 배웁니다."
---
## **개요**

Treemap과 Sunburst 차트는 동일한 유형의 계층 데이터를 표시하지만 레이아웃이 다릅니다. Treemap은 영역이 리프 값에 해당하도록 중첩된 사각형으로 계층을 그립니다. Sunburst는 동심원 형태로 그리며, 최상위 그룹은 중앙에 가깝고 리프 카테고리는 외부 링에 배치됩니다.

Aspose.Slides for Python via .NET에서는 각 숫자 값이 [ChartDataPoint](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/) 입니다. 해당 [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) 컬렉션을 통해 리프와 상위 그룹에 접근할 수 있습니다. 이 문서는 그 매핑을 설명하고 동일한 샘플 데이터를 사용해 두 차트 유형을 생성하고 서식 지정하는 방법을 보여줍니다.

![소비자와 비즈니스 지점을 포함한 Treemap 차트](treemap-hierarchy.png)

![동일한 소비자와 비즈니스 계층을 가진 Sunburst 차트](sunburst-hierarchy.png)

## **카테고리, 데이터 포인트 및 레벨 이해**

아래 예제는 세 개의 카테고리 레벨과 하나의 숫자 시리즈를 포함합니다.

| 지점 | 분류 | 리프 | 매출 |
| --- | --- | --- | ---: |
| 소비자 | 컴퓨터 | 노트북 | 12 |
| 소비자 | 컴퓨터 | 데스크톱 | 8 |
| 소비자 | 모바일 | 전화 | 15 |
| 소비자 | 모바일 | 태블릿 | 6 |
| 비즈니스 | 서비스 | 컨설팅 | 10 |
| 비즈니스 | 서비스 | 지원 | 7 |
| 비즈니스 | 소프트웨어 | 라이선스 | 11 |
| 비즈니스 | 소프트웨어 | 구독 | 14 |

각 행은 하나의 리프 카테고리와 하나의 데이터 포인트를 생성합니다. 카테고리 그룹 레벨은 해당 리프에서 부모까지의 경로를 설명합니다. 첫 번째 행의 경우 경로는 `Consumer > Computers > Laptops` 입니다.

[ChartDataPoint.data_point_levels] 의 인덱스는 리프에서 위쪽으로 올라갑니다:

| `data_point_levels` 인덱스 | 논리 레벨 | 트리맵 표현 | 선버스트 표현 |
| ---: | --- | --- | --- |
| `0` | 리프 | 값 사각형 | 외부 링 세그먼트 |
| `1` | 스템 | 부모 사각형 또는 헤더 | 중간 링 세그먼트 |
| `2` | 브랜치 | 최상위 사각형 또는 헤더 | 내부 링 세그먼트 |

이 순서는 시각적 레이아웃이 다름에도 불구하고 두 차트 유형 모두 동일합니다. 부모 세그먼트는 여러 리프가 공유합니다. 이를 서식 지정하려면 해당 그룹의 첫 번째 데이터 포인트의 해당 레벨을 사용합니다. 예를 들어 `Consumer` 브랜치는 `Laptops` 포인트에서 시작하고, `Software` 스템은 `Licenses` 포인트에서 시작합니다. `data_points[0]`이나 `data_points[6]`과 같은 설명 없는 표현보다 이러한 포인트에 대한 참조를 유지하는 것이 더 명확하고 안전합니다.

## **두 차트 유형 만들기 및 사용자 지정**

다음 완전한 예제는 첫 번째 슬라이드에 Treemap을, 두 번째 슬라이드에 Sunburst를 생성합니다. 계층을 구성하고, `Tablets` 값은 표시하며, 선택된 레벨에 고정 색을 적용하고, 브랜치 레이블을 서식 지정한 뒤 프레젠테이션을 저장합니다.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # 리프 카테고리를 추가합니다. 새로운 그룹이 시작될 때만 그룹화 항목이 설정됩니다;
    # 다음 카테고리들은 다른 항목이 설정될 때까지 해당 그룹에 남아 있습니다.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # 태블릿 리프에 카테고리와 값을 표시합니다.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # 해당 브랜치의 첫 번째 리프를 통해 Consumer 브랜치를 서식 지정합니다.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # 해당 스템의 첫 번째 리프를 통해 Software 스템을 서식 지정합니다.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout 은 Treemap 부모 레이블에 영향을 주며; Sunburst는 링 세그먼트를 사용합니다.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

카테고리 셀과 값 셀은 동일한 워크시트 행을 사용하므로 컬렉션 위치가 정렬된 상태로 유지됩니다. 기존 차트를 수정할 때는 차트를 새로 만들지 않고 먼저 카테고리 행을 검사하고 서식 지정하려는 데이터 포인트와 레벨에 대한 명명된 참조를 저장하십시오.

## **동작 및 실용적인 고려 사항**

### **Treemap과 Sunburst 차이점**

- Treemap은 영역을 사용해 값을 전달하고 중첩된 사각형으로 계층을 나타냅니다. [ChartSeries.parent_label_layout] 속성은 이 차트 유형에서 부모 레이블이 표시되는 방식을 제어합니다.
- Sunburst는 각도를 사용해 값을 전달하고 링 깊이를 통해 계층을 나타냅니다. [ChartSeries.parent_label_layout] 은 링 레이블을 제어하지 않습니다.
- 두 차트 유형 모두 동일한 카테고리 그룹 레벨과 `data_point_levels` 에서의 리프‑대‑부모 순서를 사용하므로 데이터 빌드 및 레벨 서식 지정 코드를 공유할 수 있습니다.
- 부모 값은 하위 리프에서 계산됩니다. 브랜치나 스템에 별도의 숫자 포인트를 추가하지 마십시오.

### **정렬 및 세그먼트 순서**

차트 레이아웃 엔진이 사각형과 링 세그먼트의 최종 배치를 결정합니다. 관련 카테고리 행을 함께 정렬한 뒤 추가하되, 특정 사각형 위치나 시작 각도에 의존하지 마십시오. 순서가 의미가 있다면 레이블에 포함하거나 명시적인 카테고리 축을 갖는 차트 유형을 사용하십시오.

### **테마 및 고정 색**

서식이 지정되지 않은 차트 레벨은 프레젠테이션 테마에서 색을 상속합니다. 예제에서는 예측 가능한 출력을 위해 명시적인 RGB 채우기를 사용합니다. 차트가 테마 변경을 따라야 한다면 고정 RGB 값 대신 스킴 색을 사용하고 모든 레벨을 재정의하지 않도록 하세요. 또한 브랜치나 스템 채우기를 변경한 후 레이블 대비를 확인하십시오.

### **레이블 및 사용 가능한 공간**

세그먼트가 너무 작으면 PowerPoint가 레이블을 숨기거나 잘라낼 수 있습니다. 차트 크기를 늘리거나 카테고리명을 줄이거나 표시할 레이블 필드를 감소시키면 보통 더 명확한 결과를 얻을 수 있습니다. 레이블은 [DataLabelFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabelformat/)을 통해 카테고리명, 시리즈명, 값을 결합할 수 있지만 모든 필드를 활성화하면 계층 차트를 읽기 어렵게 만들 수 있습니다.

### **내보내기 및 렌더링**

PPTX로 저장하면 차트를 편집 가능한 상태로 유지합니다. Aspose.Slides가 프레젠테이션을 PDF 또는 이미지로 렌더링할 때 지원되는 채우기와 레이블 설정이 차트와 함께 렌더링됩니다. 글꼴 대체와 레이아웃 공간의 미세한 차이가 줄 바꿈이나 레이블 가시성에 영향을 줄 수 있으므로 필요한 글꼴을 설치하고 중요한 내보내기 대상에서 확인하십시오.

## **FAQ**

**왜 부모 레벨을 변경하면 여러 리프에 영향을 미칩니까?**

브랜치 또는 스템은 공유되는 시각적 세그먼트입니다. 해당 [ChartDataPointLevel](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointlevel/) 은 하위 리프를 통해 접근할 수 있지만 서식은 해당 리프만이 아니라 공유된 부모 세그먼트에 적용됩니다.

**데이터 레이블이 누락된 이유는 무엇입니까?**

먼저 레이블의 [DataLabelFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabelformat/) 객체에서 필요한 필드를 활성화하십시오. 그런 다음 세그먼트에 충분한 공간이 있는지 확인하십시오. Treemap 부모 레이블 레이아웃, 차트 크기, 레이블 길이, 글꼴 크기 및 활성화된 필드 수가 레이블 표시 여부에 영향을 줍니다.

**세그먼트의 정확한 순서나 좌표를 지정할 수 있습니까?**

소스 행 순서를 제어하고 각 그룹을 연속적으로 유지할 수는 있지만 정확한 Treemap 사각형이나 Sunburst 각도를 지정할 수는 없습니다. 차트 레이아웃 엔진이 계층, 값 및 사용 가능한 공간을 기반으로 계산합니다.

**프레젠테이션 테마가 변경된 후 색이 바뀌는 이유는 무엇입니까?**

테마 기반 채우기는 프레젠테이션 팔레트를 따르도록 설계되었습니다. 고정되어 있어야 하는 레벨에는 명시적인 RGB 색을 적용하거나 새 테마에 맞게 스킴 색을 유지하십시오.

**PDF 및 이미지 내보내기에서 사용자 지정 서식이 보존됩니까?**

예, 지원되는 차트 채우기와 레이블 설정은 렌더링 시 포함됩니다. 시스템 간 일관된 결과를 위해 필요한 글꼴을 제공하고 레이블 맞춤은 레이아웃에 따라 달라지므로 최종 내보내기 크기를 테스트하십시오.

## **관련 항목**

- [트리맵 차트 만들기](/slides/ko/python-net/create-chart/#create-tree-map-charts)
- [Sunburst 차트 만들기](/slides/ko/python-net/create-chart/#create-sunburst-charts)
- [프레젠테이션 차트 내보내기](/slides/ko/python-net/export-chart/)
- [프레젠테이션 테마 관리](/slides/ko/python-net/presentation-theme/)