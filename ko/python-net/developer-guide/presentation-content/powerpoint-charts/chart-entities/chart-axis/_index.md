---
title: Python을 사용한 프레젠테이션 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/python-net/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 차트 축을 사용자 지정하는 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides for Python via .NET를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트의 수직 축에서 최대값 가져오기**

기본 데이터가 있는 영역 차트를 추가하고 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 을(를) 생성합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 유지하기 위해 [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) 을 호출합니다.

축 한계를 위해 [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) 과 [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) 을 읽고, 눈금 간격을 위해 [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) 과 [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) 을 읽습니다. 날짜 축과 관련된 시간 단위 스케일을 제공하는 [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) 과 [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) 도 있습니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

차트 데이터에서 시리즈와 범주의 역할을 교환하려면 [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) 을 사용합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터가 그룹화되는 방식을 변경하지만 가로와 세로 축을 교환하는 것은 아닙니다. 예제에서는 [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) 를 사용하여 기본 데이터를 `Sheet1!A1:D5`(헤더 행 및 범주 열 포함)에 바인딩한 후 행과 열을 전환합니다. 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

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

## **축의 플로팅 순서 반전**

범주 축이나 값 축을 반전하려면 [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) 를 사용합니다. 예를 들어, 가로 막대 차트는 워크시트와 동일한 순서인 상단에서 하단으로 프로젝트 단계(계획, 개발, 테스트)를 표시할 수 있습니다. 축을 반전하면 플로팅 방향이 바뀌지만 워크북 데이터가 정렬되거나 재배열되지는 않습니다. 반면에 [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) 은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈를 가진 가로 막대 차트를 생성합니다. 정상 순서, 범주 역순, 값 역순의 세 슬라이드를 저장합니다. 각 복사본은 같은 데이터 세트를 사용하고, 각 복사본에서 하나의 축만 반전됩니다.

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

    # 슬라이드 2: 첫 번째 범주를 상단에 표시합니다.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # 수평 값 축을 하단에 유지합니다.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # 슬라이드 3: 수평 숫자 스케일만 반전합니다.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

축을 반전하면 수직 축을 플롯의 반대쪽으로 이동할 수도 있습니다. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) 은 구성 중인 축과 다른 축이 교차하는 위치를 제어합니다. 슬라이드 2에서는 반전된 범주 축에 `MAXIMUM` 을 설정하면 수평 값 축이 하단에 유지됩니다. 특정 교차점을 지정하려면 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) 를 사용합니다. 방향을 변경할 때는 특히 차트에 사용자 지정 교차점이 있는 경우 교차 설정을 확인하십시오. `is_plot_order_reversed` 를 `False` 로 되돌리면 정상 플로팅 방향이 복원됩니다. 교차 설정은 별도로 유지됩니다.

| 정상 순서 (슬라이드 1) | 범주 역순 (슬라이드 2) | 값 역순 (슬라이드 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| 범주는 아래에서 위로 진행되고; 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행됩니다. 값과 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고; 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽의 0에서 교차합니다. |

## **라인 차트에서 수직 축 비활성화**

수직 축에 대해 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) 를 `False` 로 설정하여 숨깁니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 수직 축이 숨겨진 상태로 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **라인 차트에서 수평 축 비활성화**

수평 축에 대해 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) 를 `False` 로 설정하여 숨깁니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 수평 축이 숨겨진 상태로 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **범주 축 변경**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 을 설정하여 날짜 축 또는 텍스트 범주 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 모양이 차트이고 범주 셀에 Excel 날짜 값(숫자) 이 포함된 `ExistingChart.pptx` 를 필요로 합니다. 가로 축을 날짜 축으로 변경합니다. [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) 을 `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 을 `1`, [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) 을 `months` 로 설정하면 주요 눈금이 한 달 간격으로 배치됩니다.

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

## **범주 축 레이블 간격 제어**

차트에 많은 범주가 있는 경우 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) 을 `False` 로 설정한 다음 [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) 에 원하는 범주 간격을 지정합니다. 정상 순서의 텍스트 범주의 경우 첫 번째 범주에서 카운트가 시작됩니다.

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | 범주 1, 범주 2, 범주 3, ... 범주 24 |
| `2` | 범주 1, 범주 3, 범주 5, ... 범주 23 |
| `3` | 범주 1, 범주 4, 범주 7, ... 범주 22 |

`3` 간격은 세 번째 레이블마다 표시되며, 표시된 레이블 사이에 두 개의 레이블이 숨겨집니다. 해당 열이 제거되는 것은 아닙니다. 자동 간격은 사용 가능한 공간에 따라 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금표에도 별도 제어가 있습니다. [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) 을 `False` 로 설정하고 [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) 으로 간격을 지정합니다. 예를 들어 `1` 은 각 범주 간격마다 눈금표를 유지하면서 레이블은 세 번째 범주마다만 표시됩니다. [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 을 눈에 보이는 스타일로 설정하여 결과를 확인할 수 있습니다. 자동 간격 속성을 다시 `True` 로 설정하면 차트가 해당 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 범주와 하나의 시리즈를 만든 다음 `CategoryAxisIntervals.pptx` 에 세 슬라이드를 저장합니다: 자동 간격, 레이블 간격 수동(눈금표는 독립) 및 자동 간격 복원. 두 복사본 모두 원본 차트 데이터를 유지합니다. 입력 프레젠테이션이 필요하지 않으며, 가로 레이블 텍스트가 밀도 차이를 쉽게 확인하게 합니다.

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

    # 슬라이드 2: 매 세 번째 레이블을 표시하되, 각 범주마다 눈금표를 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 레이블이 표시되고 두 줄로 나뉩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블만 한 줄에 표시되고 눈금표는 각 범주 간격마다 유지됩니다. 레이블이 없는 24개의 열도 동일한 값으로 그대로 표시됩니다. 슬라이드 3은 위에 표시된 자동 모양을 복원합니다.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(열, 선, 영역 또는 막대 차트의 범주 축) 에서 이 범주 개수 간격을 사용합니다. 열 차트에서는 가로 축이 됩니다. 가로 막대 차트에서는 범주 축이 세로이므로 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) 에 적용합니다. 눈금표 간격은 축이 하나인 차트의 시리즈 축에도 적용됩니다.

값 축의 숫자 눈금 크기를 설정하려면 범주 레이블 간격을 사용하지 마세요. 값 축에서는 [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 이 값 차이를 지정합니다. 예를 들어 `10` 의 주요 단위는 축이 0부터 시작할 때 0, 10, 20 등으로 눈금을 표시합니다. `3` 의 범주 레이블 간격은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도와 버블 차트는 텍스트 범주 축이 아닌 값 축을 사용합니다. 날짜 축에서는 [범주 축 변경](#change-a-category-axis) 섹션에 설명된 시간 기반 주요 단위와 스케일을 사용하세요.

## **범주 축 값의 날짜 형식 설정**

예제는 기본 차트 데이터를 네 개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장됩니다. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 을 날짜 축으로 설정하고, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) 를 비활성화한 뒤, [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) 에 `yyyy` 를 지정하면 셀 서식과 무관하게 범주 레이블에 4자리 연도가 표시됩니다.

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

수직 축에 대해 [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) 를 활성화하고 제목 텍스트를 제공한 다음, [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) 를 설정하여 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전한 열 차트를 저장합니다.

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

## **범주 또는 값 축에서 축 위치 설정**

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) 를 사용하여 값 축이 범주 축을 범주 사이에서 교차할지 범주 눈금표에서 교차할지 제어합니다. 이 속성은 범주 축에 적용됩니다. 예제에서는 열 차트의 가로 범주 축에 `True` 로 설정하고 결과를 저장합니다.

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

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) 을 설정하면 기본 데이터를 변경하지 않고 값 축 레이블을 스케일링할 수 있습니다. [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) 을 `MILLIONS` 로 설정하면 60,000,000 값이 60 으로 표시됩니다. 예제는 열 차트를 만들고 수직 축에 백만 표시 단위를 적용합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **로그 값 축 구성**

양의 값이 여러 자릿수에 걸쳐 있을 때 로그 값 축이 유용합니다. 예를 들어 서비스가 5기간에 걸쳐 10, 100, 1,000, 10,000, 100,000 요청을 받을 수 있습니다. 선형 스케일에서는 작은 값이 0 근처에 몰려 보입니다. 로그 스케일은 같은 거리마다 같은 비율을 나타내어 상대 성장률을 비교하기 쉽게 합니다.

값 축에 대해 [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) 을 `True` 로 설정하고 [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) 로 기준을 선택합니다. 이는 기존 값의 표시 방법만 변경하고 데이터 자체를 바꾸거나 로그 추세선을 추가하지 않습니다. 추세선은 데이터에 맞춘 관계를 나타내는 별도 기능입니다.

### **값 축 및 기준 선택**

라인 차트나 열 차트의 경우 값 축은 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) 입니다. 가로 막대 차트에서는 [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) 이 값 축이 됩니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X 값에는 가로 축, Y 값에는 세로 축을 선택하거나 모두 적용합니다. 범주 축에는 로그 스케일을 적용하지 마세요.

기본 로그 기준은 `10` 입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 기준을 사용할 수 있으며, `2.5`와 같은 소수 기준도 지원됩니다. 기준이 `10`이면 10, 100, 1,000, 10,000 등의 연속적인 거듭 제곱이 동일하게 배치됩니다.

### **선형 및 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 다섯 개 요청 수를 가진 라인 차트를 만든 뒤, 해당 슬라이드를 복제하고 두 번째 슬라이드에서 기준 10 로그 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

**선형 스케일 (슬라이드 1):** 동일한 수직 거리는 요청 수 차이를 나타냅니다. 가장 큰 값이 차트를 지배해 작은 값이 구분하기 어려워집니다.

![PowerPoint의 선형 값 축에 다섯 개 요청 수를 표시한 선 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리는 같은 비율을 나타냅니다. 각 기간은 이전보다 10배 많은 요청을 받으므로 점이 기준 10 스케일에서 직선으로 상승합니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![PowerPoint에서 동일한 다섯 개 요청 수를 10진 로그 값 축에 표시](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 활성화하기 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 분석에 따라 해당 값을 제외하는 것이 적절하다면 그 이유를 설명해야 합니다. 작은 양수로 조용히 대체하면 데이터 의미가 바뀌므로 피하십시오. 로그 축에 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **자주 묻는 질문**

**하나의 축이 다른 축과 교차하는 값을 어떻게 설정합니까(축 교차)?**

[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) 을 사용하여 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) 을 설정합니다. 이러한 설정을 통해 축 교차를 적절한 기준선으로 이동시킬 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 배치합니까?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) 을 사용하여 [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) 을 `LOW`, `HIGH`, `NEXT_TO` 또는 `NONE` 중 하나로 설정합니다. 눈금 자체를 제어하려면 [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 또는 [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) 을 사용합니다; 이는 레이블 위치와 별개입니다.