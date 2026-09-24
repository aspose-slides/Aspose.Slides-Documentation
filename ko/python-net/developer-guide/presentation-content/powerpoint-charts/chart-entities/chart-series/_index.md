---
title: Python을 사용한 프레젠테이션에서 차트 데이터 시리즈 관리
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
description: "Python을 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 너비 및 음수 값을 관리하는 방법을 배웁니다."
---
## **개요**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [ChartSeries](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/)는 관련 값들의 한 세트를 나타내며, 시리즈의 각 [ChartDataPoint](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/)는 하나 이상의 워크북 셀을 참조합니다. [ChartCategory](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트만으로 저장되는 것이 아니라 [ChartDataCell](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatacell/) 객체와 연결됩니다.

일반적인 카테고리 차트에서 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고 나머지 셀을 시리즈 값에 사용합니다. [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용하여 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정해서는 안 됩니다. 로드된 프레젠테이션의 경우 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하십시오.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정, 예를 들어 [ChartSeries.format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/format/)은 하나의 시리즈에 있는 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정, 예를 들어 [ChartDataPoint.format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/format/)은 한 포인트에 대한 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침이나 간격 너비와 같은 옵션을 설정해야 할 때는 [ChartSeries.parent_series_group](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/parent_series_group/)을 통해 그룹에 접근하십시오.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 포맷이 모두 존재하면 포인트 포맷이 해당 포인트에 우선 적용됩니다.

![차트 시리즈 파워포인트](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[ChartSeries.overlap](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/overlap/)은 2D 차트에서 막대나 열이 얼마나 겹치는지(-100%~100%)를 보고합니다. 이는 상위 시리즈 그룹에 대한 설정의 읽기 전용 투영입니다. [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/overlap/)을 설정하면 해당 그룹의 모든 호환 시리즈가 업데이트됩니다. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에 적용되며, 복합 차트에서 관련 없는 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 새 차트에는 샘플 시리즈, 카테고리 및 값이 포함됩니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

전체 시리즈에 대한 기본 채우기를 설정하려면 [ChartSeries.format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/format/)을 사용하십시오. 포인트에 명시적인 채우기가 이미 있는 경우 해당 [ChartDataPoint.format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/format/) 설정이 포인트의 시리즈 채우기를 재정의합니다.

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

![시리즈 색상](series_color.png)

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 열 차트용 기본 워크북에서 셀 B1은 행 0, 열 1에 위치하고 첫 번째 시리즈의 이름을 포함합니다. 다음 예제의 명명된 상수는 해당 구조를 명시적으로 나타냅니다:

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

또한 [ChartSeries.name](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/name/)이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행 및 열을 가정하는 것을 피합니다:

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

![시리즈 이름](series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/)는 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 이 메서드를 호출하면 계산된 색상을 읽어올 뿐, 새 채우기를 할당하지는 않습니다.

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

정확한 색상은 차트 스타일과 테마에 따라 달라집니다.

## **차트 시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우 [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/invert_if_negative/)를 사용하면 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤, [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)를 통해 음수 값 색상을 지정합니다. 워크북의 음수 값 자체는 변경되지 않으며, 표시 색상만 바뀝니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0에는 시리즈 이름, 열 0에는 카테고리 이름, 열 1에는 값이 들어 있습니다:

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

![반전된 단색 채우기 색상](inverted_solid_fill_color.png)

한 포인트에 대해서만 반전을 활성화하려면 [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)를 사용할 수 있습니다. 다음 예제에서는 시리즈에 대한 반전을 비활성화하고 선택한 포인트에만 활성화합니다. 포인트에 음수 값을 할당하여 효과를 확인합니다:

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

## **특정 데이터 포인트 값 삭제**

한 포인트만 비우고 다른 포인트는 유지하려면 해당 워크북 셀을 `None`으로 설정하십시오. 열 차트의 경우 플롯된 값은 [ChartDataPoint.value](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/value/)를 통해 사용할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만 차트는 해당 값을 빈 값으로 처리합니다(차트의 빈값 설정에 따름).

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 삭제합니다:

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

산점도 차트는 별도의 X 및 Y 셀을 사용하고, 버블 차트는 크기 셀도 사용합니다. 제거하려는 값에 해당하는 셀만 비우십시오. 다른 포인트를 유지하려면 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointcollection/clear/)를 호출하지 마세요. 이 메서드는 컬렉션의 모든 데이터 포인트를 삭제합니다.

## **빈 셀 표시 제어**

빈 워크북 셀은 데이터 누락을 나타내고, `0`이 포함된 셀은 알려진 숫자 값을 나타냅니다. 셀을 빈 상태로 만들려면 [ChartDataCell.value](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatacell/value/)를 `None`으로 설정하십시오. 숫자 0은 빈 셀 설정에 관계없이 0으로 유지됩니다.

[Chart.display_blanks_as](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/display_blanks_as/)를 사용하면 차트가 빈 셀을 어떻게 표시할지 선택할 수 있습니다. 이 설정은 차트 전체에 적용되며, 빈 셀을 0이나 보간값으로 채우지 않고 플롯 방식을 변경합니다.

다음 독립 실행형 예제는 하나의 시리즈를 가진 꺾은선 차트를 만들고, Day 3의 값을 삭제한 뒤 각 모드로 차트를 저장합니다. 입력 파일이 필요 없습니다. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/)은 워크시트 0, 열 0에 카테고리 레이블, 열 1에 값을 사용하며, 행 0에 시리즈 이름을 저장합니다. 최종 데이터는 `10, 20, empty, 30, 40`입니다.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Day 3을 실제로 비워두고, 해당 카테고리와 데이터 포인트는 유지합니다.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

각 출력 파일은 저장 전에 지정된 모드를 파일명에 포함합니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나의 버전만 저장하려면 원하는 모드만 지정하고 한 번 저장하면 됩니다.

아래 비교는 세 파일 모두 동일한 데이터를 보여줍니다. Day 3은 모든 경우 워크북에서 비어 있습니다:

![동일한 데이터가 있는 꺾은선 차트: Gap은 Day 3에서 라인을 끊고, Zero는 라인을 0으로 떨어뜨리며, Span은 Day 2와 Day 4를 연결합니다.](display_blanks_as.png)

시각적 효과는 차트 유형에 따라 다릅니다. 꺾은선 차트는 세 모드를 쉽게 비교할 수 있지만, 막대와 열 차트는 누락된 카테고리를 연결할 라인이 없어 `SPAN`이 위와 같은 연결 구간을 만들 수 없으며, 누락된 열과 0높이 열이 비슷해 보일 수 있습니다. 마찬가지로 마커만 있는 산점도 차트는 연결 라인이 없습니다. 모든 차트 유형에서 세 가지 뚜렷한 결과를 기대하지 말고, 사용 중인 차트 유형에 대한 출력을 확인하십시오.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 백분율로 나타낸 값입니다. 겹침과 마찬가지로 이는 개별 시리즈가 아니라 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번 [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)을 설정하면 됩니다. 값이 클수록 클러스터 사이의 공간이 넓어지고, 값이 작을수록 밀집됩니다.

다음 예제는 간격 너비를 변경하고 최종 프레젠테이션만 저장합니다:

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

![간격 너비](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원합니까?**

[ChartType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/charttype/) 열거형으로 표시되는 모든 차트 유형이 차트 데이터를 사용하지만, 시리즈마다 값 구조와 설정이 동일하지는 않습니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 방법을 사용하십시오. 겹침 및 간격 너비와 같은 옵션은 호환 가능한 막대나 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇입니까?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/)은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 하나 이상의 그룹을 포함할 수 있으므로, 한 시리즈를 통해 접근한 그룹을 변경한다고 해서 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되어 있습니까?**

예. 기본적으로 [ShapeCollection.add_chart](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_chart/)는 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 완전히 사용자 정의 데이터 세트를 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 지울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결됩니까?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 만들 때는 카테고리 행과 시리즈 값 행이 정렬되어 각 포인트가 의도한 카테고리 아래에 플롯되도록 유지하십시오.

**전체 시리즈가 아니라 한 포인트만 지우려면 어떻게 합니까?**

해당 값 셀을 `None`으로 설정하면 포인트의 카테고리 위치는 유지하면서 빈 포인트가 됩니다. 전체 시리즈를 제거하려는 경우에만 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointcollection/clear/)를 사용하십시오. 카테고리까지 삭제한다면 모든 시리즈의 값이 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시됩니까?**

결과는 차트 유형과 [Chart.display_blanks_as](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/display_blanks_as/) 설정에 따라 달라집니다. 지원되는 차트는 빈값을 간격, 0값 또는 인접 포인트 연결 중 하나로 표시할 수 있습니다. 프레젠테이션의 누락된 데이터 의미에 맞는 설정을 선택하십시오. 전체 예제와 시각적 비교는 **[빈 셀 표시 제어](#control-the-display-of-empty-cells)**를 참조하십시오.

**음수 값은 어떻게 서식이 지정됩니까?**

지원되는 막대, 열 및 버블 시리즈의 경우 [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/invert_if_negative/)을 활성화하고 [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)을 설정하십시오. 개별 포인트에 대해서는 [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)으로 동작을 재정의할 수 있습니다. 이러한 속성은 서식에 영향을 미치지만 저장된 숫자 값은 변경되지 않습니다.

**시리즈와 포인트 모두 서식이 지정된 경우 어느 것이 우선합니까?**

명시적인 데이터 포인트 서식이 해당 포인트에 우선 적용됩니다. 다른 포인트는 명시적인 시리즈 서식이나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침 및 간격 너비와 같은 그룹 속성은 레이아웃을 제어하며 포인트 수준 서식 우선순위에 영향을 주지 않습니다.

**차트에 포함할 수 있는 시리즈 수에 제한이 있습니까?**

Aspose.Slides는 별도의 고정 시리즈 수 제한을 두고 있지 않습니다. 실제 제한은 프레젠테이션 파일 제한, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성에 따라 결정됩니다.

**열이 너무 가깝거나 너무 멀리 떨어져 있을 때 어떻게 수정합니까?**

적절한 상위 시리즈 그룹에서 [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)를 설정하십시오. 값을 늘리면 클러스터 간 간격이 넓어지고, 값을 줄이면 클러스터가 서로 더 가깝게 배치됩니다.