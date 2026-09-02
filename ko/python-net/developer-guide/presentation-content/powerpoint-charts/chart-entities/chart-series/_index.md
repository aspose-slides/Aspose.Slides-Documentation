---
title: Python을 사용한 프레젠테이션의 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/python-net/chart-series/
keywords:
- 차트 시리즈
- 시리즈 겹침
- 시리즈 색상
- 카테고리 색상
- 시리즈 이름
- 데이터 포인트
- 시리즈 간격
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python으로 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 폭 및 음수 값을 관리하는 방법을 배웁니다."
---
## **개요**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. A [ChartSeries](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/)는 관련 값들의 한 집합을 나타내며, 시리즈에 있는 각 [ChartDataPoint](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/)는 하나 이상의 워크북 셀을 가리킵니다. [ChartCategory](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트로만 저장되는 것이 아니라 [ChartDataCell](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatacell/) 객체와 연결됩니다.

일반적인 카테고리 차트에서 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고, 나머지 셀을 시리즈 값에 사용합니다. [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터로 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정해서는 안 됩니다. 로드된 프레젠테이션의 경우, 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하십시오.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정은 [ChartSeries.format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/format/)와 같이 하나의 시리즈에 속한 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정은 [ChartDataPoint.format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/format/)와 같이 하나의 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/)에 속한 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 때는 [ChartSeries.parent_series_group](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/parent_series_group/)을 통해 그룹에 접근합니다.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우, 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 서식이 모두 존재하면 해당 포인트에 대해 포인트 서식이 우선합니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[ChartSeries.overlap](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/overlap/)은 2D 차트에서 막대나 열이 -100%부터 100%까지 얼마나 겹치는지를 표시합니다. 이는 부모 시리즈 그룹에 대한 설정을 읽기 전용으로 투영한 값입니다. [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/overlap/)을 설정하면 해당 그룹의 모든 호환 시리즈가 업데이트됩니다. 이 옵션은 그룹화된 막대 또는 열을 표시하는 차트 유형에 적용되며, 복합 차트에서 관련 없는 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 새 차트에는 샘플 시리즈, 카테고리 및 값이 포함되어 있습니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![The series overlap](series_overlap.png)

## **시리즈 채우기 색상 변경**

[ChartSeries.format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/format/)을 사용하여 전체 시리즈에 대한 기본 채우기를 설정합니다. 포인트에 이미 명시적인 채우기가 있는 경우, 해당 포인트의 [ChartDataPoint.format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/format/) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![The color of the series](series_color.png)

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터형 열 차트용 기본 워크북에서 셀 B1은 행 0, 열 1에 위치하고 첫 번째 시리즈 이름을 포함합니다. 아래 예제의 명명된 상수는 해당 구조를 명시적으로 나타냅니다:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

또한 [ChartSeries.name](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/name/)이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 접근 방식은 기존 차트에서 특정 행과 열을 가정하는 것을 피합니다:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![The series name](series_name.png)

## **자동 시리즈 채우기 색상 얻기**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/)는 시리즈 인덱스와 차트 스타일에서 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 이 메서드를 호출하면 계산된 색상을 읽어올 뿐, 새로운 채우기를 할당하지는 않습니다.

다음 예제는 각 기본 시리즈의 자동 색상을 출력합니다:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

기본 차트 스타일에 대한 예시 출력:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

정확한 색상은 차트 스타일 및 테마에 따라 다릅니다.

## **차트 시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/invert_if_negative/)를 사용하면 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤, [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)를 통해 음수 값 색상을 지정합니다. 워크북에 있는 음수 값 자체는 변경되지 않으며, 표시 색상만 바뀝니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0에는 시리즈 이름이, 열 0에는 카테고리 이름이, 열 1에는 값이 들어 있습니다:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![The inverted solid fill color](inverted_solid_fill_color.png)

포인트별로 반전을 활성화하려면 [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)를 사용하십시오. 아래 예제에서는 시리즈에 대한 반전을 비활성화하고 선택한 포인트에만 활성화합니다. 또한 해당 포인트에 음수 값을 할당하여 효과를 확인할 수 있습니다:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **특정 데이터 포인트 값 지우기**

한 포인트만 비워두고 다른 포인트는 유지하려면 해당 포인트가 참조하는 워크북 셀을 `None`으로 설정합니다. 열 차트의 경우 플롯된 값은 [ChartDataPoint.value](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/value/)를 통해 접근할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만 차트는 해당 값을 차트의 빈값 설정에 따라 빈 값으로 처리합니다.

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 지웁니다:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

산점도 차트는 X와 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 사용합니다. 제거하려는 값에 해당하는 셀만 비우세요. 다른 포인트를 유지하고 싶을 때는 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointcollection/clear/)를 호출하지 마십시오. 해당 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **시리즈 간격 폭 설정**

간격 폭은 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 백분율로 나타낸 값입니다. 겹침과 마찬가지로 이는 개별 시리즈가 아니라 부모 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)을 설정하면 됩니다. 값이 클수록 클러스터 사이에 더 많은 공간이 생기고, 값이 작을수록 더 촘촘해집니다.

다음 예제는 간격 폭을 변경하고 최종 프레젠테이션만 저장합니다:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![The gap width](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원합니까?**

[ChartType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/charttype/) 열거형으로 표현되는 모든 차트 유형이 차트 데이터를 사용하지만, 시리즈마다 동일한 값 구조나 설정을 갖지는 않습니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하십시오. 겹침(overlap)과 간격 폭(gap width) 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇입니까?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/)은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 여러 그룹을 가질 수 있으므로, 한 시리즈를 통해 접근한 그룹을 변경해도 차트의 모든 시리즈가 바뀌지는 않습니다.

**새로 만든 차트에 기본 데이터가 포함되어 있습니까?**

예. 기본적으로 [ShapeCollection.add_chart](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_chart/)는 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 완전히 사용자 지정된 데이터 세트를 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 지울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결됩니까?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 지정 데이터를 만들 때는 카테고리 행과 시리즈 값 행이 정렬되어 각 포인트가 의도한 카테고리 아래에 플롯되도록 유지하십시오.

**전체 시리즈가 아니라 하나의 포인트만 지우려면 어떻게 합니까?**

해당 값 셀을 `None`으로 설정하면 포인트의 카테고리 위치는 유지되면서 빈 포인트가 됩니다. 전체 포인트를 제거하려는 경우에만 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointcollection/clear/)을 사용하십시오. 카테고리 자체를 삭제하는 경우에는 모든 시리즈가 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시됩니까?**

표시 방식은 차트 유형과 [Chart.display_blanks_as](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/display_blanks_as/) 설정에 따라 달라집니다. 지원되는 차트는 빈 값을 간격, 0값, 혹은 인접 포인트 연결 방식 중 하나로 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하십시오.

**음수 값은 어떻게 서식화됩니까?**

지원되는 막대, 열 및 버블 시리즈의 경우 [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/invert_if_negative/)를 활성화하고 [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)를 설정하십시오. 개별 포인트에 대해서는 [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)로 동작을 재정의할 수 있습니다. 이러한 속성은 서식에만 영향을 미치며 저장된 숫자 값은 변경되지 않습니다.

**시리즈와 포인트가 모두 서식이 지정된 경우 어느 것이 우선합니까?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식이나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침(overlap)과 간격 폭(gap width)과 같은 그룹 속성은 레이아웃을 제어하며 포인트 수준 서식 재정의가 아닙니다.

**차트에 포함될 수 있는 시리즈 수에 제한이 있습니까?**

Aspose.Slides는 별도의 고정 시리즈 수 제한을 두지 않습니다. 실제로는 프레젠테이션 파일 제약, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성이 실용적인 제한을 결정합니다.

**열이 너무 가깝거나 너무 멀리 떨어져 있을 때 무엇을 변경해야 합니까?**

해당 부모 시리즈 그룹의 [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)을 설정하십시오. 값을 높이면 클러스터 사이 간격이 넓어지고, 값을 낮추면 클러스터가 더 가깝게 배치됩니다.