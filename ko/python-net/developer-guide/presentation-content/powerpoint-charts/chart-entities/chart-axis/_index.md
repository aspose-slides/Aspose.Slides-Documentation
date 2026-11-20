---
title: Python을 사용한 프레젠테이션 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/python-net/chart-axis/
keywords:
- 차트 축
- 세로 축
- 가로 축
- 축 사용자 지정
- 축 조작
- 축 관리
- 축 속성
- 최대값
- 최소값
- 축 라인
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "보고서와 시각화를 위해 PowerPoint 및 OpenDocument 프레젠테이션에서 차트 축을 사용자 지정하는 방법을 Aspose.Slides for Python via .NET을 사용하여 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides for Python via .NET을 사용하여 차트 축을 사용자 정의하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트 세로축에서 최대값 가져오기**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)을 생성하고 기본 데이터가 포함된 영역 차트를 추가합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 유지하려면 [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)을 호출합니다.

축 한계를 확인하려면 [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/)와 [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/)를 읽고, 눈금 간격을 확인하려면 [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/)와 [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/)를 읽습니다. 날짜 축과 관련된 시간 단위 스케일은 [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/)와 [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/)이 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **축 사이의 데이터 교환**

[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/)을 사용하여 차트 데이터에서 시리즈와 범주의 역할을 교환합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터 그룹화 방식을 변경하지만 가로축과 세로축을 교환하지는 않습니다. 예제에서는 [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)을 사용하여 기본 데이터를 `Sheet1!A1:D5`에 바인딩하고(머리글 행과 범주 열 포함) 행과 열을 전환합니다. 그런 다음 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **축의 플롯 순서 반전**

[is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/)을 사용하여 범주 축 또는 값 축의 순서를 반전합니다. 예를 들어, 가로 막대 차트에서 프로젝트 단계가 워크시트와 동일한 순서(계획, 개발, 테스트)로 위에서 아래로 표시될 수 있습니다. 축을 반전하면 플롯 방향이 바뀌지만 워크북 데이터가 정렬되거나 재배열되지는 않습니다. 비교를 위해 [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/)은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈가 있는 가로 막대 차트를 생성합니다. 일반 순서, 범주 반전, 값 반전의 세 슬라이드를 포함하는 프레젠테이션을 저장합니다. 각 복사본은 동일한 데이터 집합을 사용하고, 각 복사본에서는 하나의 축만 반전됩니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # 슬라이드 2: 첫 번째 범주를 위에 표시합니다.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # 가로 값 축을 아래에 유지합니다.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # 슬라이드 3: 가로 숫자 스케일만 반전합니다.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

축을 반전하면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/)은 다른 축이 구성 중인 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 반전된 범주 축에 `MAXIMUM`을 설정하여 가로 값 축을 아래쪽에 유지합니다. 특정 교차점을 지정하려면 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)을 사용합니다. 방향을 변경할 때는 특히 차트에 사용자 지정 교차점이 있는 경우 교차 설정을 확인하십시오. 정상적인 플롯 방향을 복원하려면 `is_plot_order_reversed`를 `False`로 설정하면 됩니다; 교차 설정은 별개입니다.

| 일반 순서 (슬라이드 1) | 범주 반전 (슬라이드 2) | 값 반전 (슬라이드 3) |
| --- | --- | --- |
| ![일반 범주 및 값 축 순서를 가진 가로 막대 차트](axis-order-normal.png) | ![범주가 위에서 아래로 표시되는 가로 막대 차트](axis-order-categories-reversed.png) | ![값 축이 반전되고 오른쪽에 0이 표시되는 가로 막대 차트](axis-order-values-reversed.png) |
| 범주는 아래에서 위로 진행하고, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행합니다. 값과 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽 0에서 교차합니다. |

## **선 차트의 세로축 비활성화**

세로축에 대한 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)을 `False`로 설정하여 숨깁니다. 예제에서는 기본 데이터를 사용한 선 차트를 만들고 세로축을 숨긴 채 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **선 차트의 가로축 비활성화**

가로축에 대한 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)을 `False`로 설정하여 숨깁니다. 예제에서는 기본 데이터를 사용한 선 차트를 만들고 가로축을 숨긴 채 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 격자선 표시 또는 숨기기**

축이 표시하는 격자선을 확인하려면 [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/)과 [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/)을 읽습니다. 두 속성은 읽기 전용입니다. 소형 격자선을 표시하려면 [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/)의 선 채우기를 단색 채우기로 설정하고 보이는 색상을 선택합니다. 숨기려면 채우기 유형을 `FillType.NO_FILL`으로 설정합니다. 주요 격자선은 [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`을 사용합니다. 채우기를 변경해도 축 표시와 눈금은 유지됩니다.

이 클러스터드 열 차트의 세로축은 주요 격자선이 보이고 소형 격자선이 숨긴 상태로 시작합니다. 예제에서는 소형 격자선을 주황색으로 표시한 다음 다시 숨기고 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| 소형 격자선 표시 | 소형 격자선 숨김 |
| --- | --- |
| ![세로축의 주요 격자선 사이에 주황색 소형 격자선이 표시된 모습](minor-gridlines-enabled.png) | ![주요 격자선만 보이는 동일 열 차트](minor-gridlines-hidden.png) |

## **범주 축 변경**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)을 설정하여 날짜 축 또는 텍스트 범주 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `ExistingChart.pptx` 파일을 사용하며, 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 가로축을 날짜 축으로 변경합니다. [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/)을 `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)을 `1`, 그리고 [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/)을 `months`로 설정하면 주요 눈금이 1개월 간격으로 배치됩니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

### **데이터에서 범주 축 유형 결정**

범주를 채운 후 [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/)을 호출하고, [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)을 읽어 선택된 유형을 확인합니다. 이는 차트가 텍스트 레이블 또는 숫자형 날짜 값을 받는 경우에 유용합니다. 이 메서드는 호출 시 유형을 결정하며, 이후 데이터 변경에 대해 지속적으로 재평가하는 모드는 제공하지 않습니다. 범주를 교체한 후 다시 호출하십시오.

다음 예제는 텍스트 범주가 있는 차트를 만든 뒤 `TEXT`를 출력합니다. 그런 다음 범주 셀 값을 날짜로 교체하고 메서드를 다시 호출하면 `DATE`를 출력합니다. 날짜는 1899년 12월 30일을 기준으로 한 일수 형태의 숫자 OLE Automation 값으로 저장되며, 문자열이 아닙니다. [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/)은 이러한 값의 표시 방식을 제어하지만 텍스트를 숫자 날짜로 변환하지는 않습니다. 범주 셀에 대한 자세한 내용은 [Chart Workbook](/slides/ko/python-net/chart-workbook/)를 참조하십시오.

입력에 텍스트 범주 또는 숫자 날짜가 포함된 것이 확실할 때 자동 판단을 사용하십시오. 일반 숫자 레이블, 혼합 범주 또는 빈 데이터의 경우 의도에 맞는 의미를 갖도록 명시적으로 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)을 설정하십시오. 숫자 값만으로는 해당 범주가 날짜임을 판단할 수 없습니다.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # 텍스트

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # 날짜

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **범주 축 레이블 간격 제어**

차트에 많은 범주가 있을 때, 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/)을 `False`로 설정한 다음, [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/)을 원하는 범주 간격값으로 지정합니다. 일반 순서의 텍스트 범주에서는 첫 번째 범주부터 카운트가 시작됩니다:

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` 간격은 3번째 레이블마다 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 해당 열 자체가 삭제되지는 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금은 별도로 제어합니다. [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/)을 `False`로 설정하고 [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/)을 사용해 간격을 지정합니다. 예를 들어 `1`은 레이블이 3번째 범주마다 표시되더라도 모든 범주 간격에 눈금을 유지합니다. [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/)을 눈에 보이는 스타일로 설정하면 결과를 확인할 수 있습니다. 자동 간격 속성을 다시 `True`로 설정하면 차트가 해당 간격을 다시 선택합니다.

다음 독립 실행형 예제는 24개의 범주와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx`에 세 슬라이드를 저장합니다: 자동 간격, 레이블 간격을 수동으로 설정하고 눈금을 독립적으로 유지, 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션이 필요하지 않으며, 가로 레이블 텍스트가 밀도 차이를 쉽게 확인할 수 있게 합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # 슬라이드 2: 모든 세 번째 레이블을 표시하지만, 모든 범주에 눈금은 유지합니다.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # 슬라이드 3: 차트가 두 간격을 다시 선택하도록 합니다.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째 범주 레이블마다 표시되며 두 줄로 감싸집니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![모든 24열이 보이는 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블마다 한 줄에 표시되고, 눈금은 모든 범주 간격에 남아 있습니다. 레이블이 없는 24열도 동일한 값으로 표시됩니다. 슬라이드 3은 위의 자동 표시를 복원합니다.

![모든 24열이 보이는 세 번째 간격의 수동 범주 레이블](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(열, 선, 영역 또는 막대 차트의 범주 축)에서는 이 범주 개수 간격을 사용합니다. 열 차트에서는 가로축이, 가로 막대 차트에서는 세로축이 범주 축이므로 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)에 적용하십시오. 눈금 간격은 하나의 시리즈 축이 있는 차트에도 적용됩니다.

값 축의 숫자 스케일을 설정하려면 범주 레이블 간격을 사용하지 마십시오. 값 축에서는 [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)이 값 차이를 지정합니다(예: `10`이면 0, 10, 20…처럼 표시). 범주 레이블 간격 `3`은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도 및 버블 차트는 텍스트 범주 축 대신 값 축을 사용합니다. 날짜 축의 경우 [범주 축 변경](#change-a-category-axis)에서 설명한 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제에서는 기본 차트 데이터를 4개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장됩니다. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)을 날짜 축으로 설정하고, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)을 비활성화한 뒤, [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)에 `yyyy`를 지정하면 셀 서식과 무관하게 범주 레이블에 4자리 연도가 표시됩니다.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 축 제목 회전 각도 설정**

세로축에 [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/)을 활성화하고 제목 텍스트를 제공한 뒤, [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/)을 설정하여 제목을 회전시킵니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전한 열 차트를 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **범주 또는 값 축의 축 위치 설정**

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/)을 사용하여 값 축이 범주 축을 범주 사이에서 교차할지, 범주 눈금에서 교차할지 제어합니다. 이 속성은 범주 축에 적용됩니다. 예제에서는 열 차트의 가로 범주 축에 `True`로 설정하고 결과를 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 값 축에 표시 단위 설정**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/)을 설정하여 데이터 자체를 변경하지 않고 값 축 레이블을 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/)을 `MILLIONS`로 지정하면 60,000,000값이 60으로 표시됩니다. 예제에서는 열 차트를 만든 뒤 세로축에 백만 단위 표시를 적용합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **로그값 축 구성**

양의 값이 여러 자릿수에 걸쳐 변할 때 로그값 축이 유용합니다. 예를 들어, 서비스가 5개의 기간에 걸쳐 10, 100, 1,000, 10,000, 100,000 요청을 받는 경우, 선형 스케일에서는 작은 값이 0에 가까워 함께 보입니다. 로그 스케일은 같은 거리마다 같은 비율을 나타내어 상대적 성장 비교를 쉽게 합니다.

값 축에 [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/)을 `True`로 설정하고, [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/)를 사용해 기반을 선택합니다. 이는 기존 값의 표시 방식을 변경하지만 데이터 자체를 변경하거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 별도 기능입니다.

### **값 축 및 기반 선택**

선 또는 열 차트에서는 값 축이 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)입니다. 가로 막대 차트에서는 [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/)가 값 축입니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X값에 가로축, Y값에 세로축을 선택하거나 둘 다 적용합니다. 범주 축에는 로그 스케일을 적용하지 마십시오.

기본 로그 기반은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 기반을 사용할 수 있으며, `2.5`와 같은 소수 기반도 지원됩니다. 기반이 `10`일 때 10, 100, 1,000, 10,000과 같은 연속적인 거듭 제곱이 동일한 간격으로 배치됩니다.

### **선형 및 로그 스케일 비교**

다음 독립 실행형 예제는 첫 번째 슬라이드에 5개의 요청 수를 가진 선 차트를 만든 뒤, 해당 슬라이드를 복제하고 두 번째 슬라이드에 10진 로그값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # 첫 번째 슬라이드는 선형으로 유지하고 복사본의 값 축 스케일만 변경합니다.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**선형 스케일 (슬라이드 1):** 같은 수직 거리마다 요청 수 차이가 동일하게 표시됩니다. 가장 큰 값이 차트를 지배해 작은 값이 구분하기 어렵습니다.

![선형 값 축에 5개의 요청 수를 표시한 PowerPoint 선 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 같은 수직 거리마다 비율이 동일합니다. 각 기간의 요청 수가 이전보다 10배씩 증가하므로 10진 로그 스케일에서는 점이 직선 상승 형태를 이룹니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![PowerPoint에서 동일한 5개의 요청 수를 10진 로그값 축에 표시한 차트](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 사용 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값들을 분석에서 제외하는 것이 적절하다면 그 이유를 설명해야 합니다. 작은 양수 값으로 조용히 대체하면 데이터 의미가 바뀔 수 있습니다. 로그 축에 대해 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**하나의 축이 다른 축을 교차하는 값을 어떻게 설정합니까?**

[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/)을 사용해 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)을 설정합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**축에 대해 눈금 레이블을 어떻게 위치시키나요?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/)의 `LOW`, `HIGH`, `NEXT_TO`, `NONE` 중 하나를 사용해 [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/)을 설정합니다. 눈금 자체를 제어하려면 [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 또는 [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/)을 사용하십시오; 이는 레이블 위치와는 별개입니다.