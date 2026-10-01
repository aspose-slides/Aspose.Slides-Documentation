---
title: Python으로 프레젠테이션에서 차트 축 맞춤 설정
linktitle: 차트 축
type: docs
url: /ko/python-net/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 맞춤 설정
- 축 조작
- 축 관리
- 축 속성
- 최대값
- 최소값
- 축 선
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 차트 축을 맞춤 설정하고 보고서와 시각화를 만들 수 있는 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides for Python via .NET을 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주와 서식 지정, 제목 회전, 축 위치 지정 및 표시 단위를 다룹니다.

## **차트에서 수직 축의 최대값 가져오기**

기본 데이터가 포함된 영역 차트를 추가하려면 [프레젠테이션](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)을 생성합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 유지하기 위해 [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)을 호출합니다.

축 범위에 대해 [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) 및 [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/)을 읽고, 눈금 간격에 대해 [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) 및 [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/)을 읽습니다. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) 및 [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/)은 날짜 축과 관련된 시간 단위 스케일을 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

차트 데이터에서 시리즈와 범주의 역할을 교환하려면 [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/)을 사용합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터 그룹화 방식을 변경하지만 수평 및 수직 축을 교환하지는 않습니다. 예제에서는 행과 열을 전환하기 전에 기본 데이터를 `Sheet1!A1:D5`에 바인딩하기 위해 [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)를 사용합니다(헤더 행 및 범주 열 포함). 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

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

## **라인 차트에서 수직 축 비활성화**

수직 축의 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)을 `False`로 설정하여 숨깁니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 수직 축을 숨긴 상태로 저장합니다.

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

수평 축의 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)을 `False`로 설정하여 숨깁니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 수평 축을 숨긴 상태로 저장합니다.

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

날짜 또는 텍스트 범주 축을 선택하려면 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)을 설정합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형이 차트이며 범주 셀에 숫자 Excel 날짜 값이 포함된 `ExistingChart.pptx`가 필요합니다. 수평 축을 날짜 축으로 변경합니다. [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/)을 `False`로, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)을 `1`로, [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/)을 months(월)로 설정하면 주요 눈금이 한 달 간격으로 표시됩니다.

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

차트에 범주가 많이 있는 경우 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/)을 `False`로 설정한 다음 원하는 범주 간격으로 [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/)을 지정합니다. 텍스트 범주의 경우 정상 순서에서 첫 번째 범주부터 카운트가 시작됩니다:

| 간격 | 예제에 표시되는 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` 간격은 세 번째 레이블마다 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 해당 열을 제거하지는 않습니다. 자동 간격은 사용 가능한 공간을 기반으로 간격을 선택하며, 반드시 모든 레이블을 표시하는 것은 아닙니다.

눈금은 별도로 제어합니다. [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/)을 `False`로 설정하고 [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/)으로 간격을 지정합니다. 예를 들어 `1`은 각 범주 간격마다 눈금을 유지하지만 레이블은 세 번째 범주마다만 표시됩니다. [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/)을 눈에 보이는 스타일로 설정하면 결과를 확인할 수 있습니다. 자동 간격 속성을 `True`로 되돌리면 차트가 다시 해당 간격을 선택합니다.

다음은 자체 포함 예제로 24개의 범주와 하나의 시리즈를 만든 다음 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 레이블 간격을 수동으로 지정하고 눈금을 독립적으로 유지, 자동 간격 복원. 두 개의 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션이 필요하지 않습니다. 수평 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

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

    # 슬라이드 2: 매 세 번째 레이블을 표시하지만, 각 범주마다 눈금표시는 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 범주 레이블이 표시되고 두 줄로 줄바꿈됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![모든 24열이 보이는 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블이 한 줄에 표시되며, 눈금은 각 범주 간격마다 유지됩니다. 레이블이 없는 열을 포함한 모든 24열이 동일한 값으로 계속 표시됩니다. 슬라이드 3은 위에 표시된 자동 모습을 복원합니다.

![모든 24열이 보이는 세 번째 레이블 수동 간격](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 열, 라인, 영역 또는 막대 차트의 범주 축)에서 이 범주 수 간격을 사용합니다. 열 차트에서는 수평 축이 됩니다. 가로 막대 차트에서는 범주 축이 수직이므로 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)에 이 설정을 적용합니다. 눈금 간격은 축이 하나만 있는 차트의 시리즈 축에도 적용됩니다.

값 축의 수치 스케일을 설정하려면 범주 레이블 간격을 사용하지 마십시오. 값 축에서는 [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)이 값 차이를 지정합니다. 예를 들어 `10`의 주요 단위는 축이 0에서 시작할 때 0, 10, 20 등에 눈금을 만듭니다. `3`의 범주 레이블 간격은 데이터 값과 무관하게 범주 위치를 세는 것입니다. 산점도 및 버블 차트는 텍스트 범주 축이 아니라 값 축을 사용합니다. 날짜 축의 경우 [범주 축 변경](#change-a-category-axis) 섹션에 설명된 대로 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제는 기본 차트 데이터를 4개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장됩니다. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)을 날짜 축으로 설정하고, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)를 비활성화한 다음 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)에 `yyyy`를 지정하여 셀 서식과 무관하게 범주 레이블에 4자리 연도가 표시되도록 합니다.

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

## **차트 축 제목의 회전 각도 설정**

수직 축에 [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/)을 활성화하고 제목 텍스트를 제공한 뒤 [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/)을 설정하여 제목을 회전시킵니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전한 열 차트를 저장합니다.

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

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/)을 사용하여 값 축이 범주 축을 범주 사이에 교차할지 아니면 범주 눈금에 교차할지를 제어합니다. 이 속성은 범주 축에 적용됩니다. 예제는 열 차트의 수평 범주 축에 이를 `True`로 설정하고 결과를 저장합니다.

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

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/)을 설정하여 값 축 레이블을 데이터 자체를 변경하지 않고 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/)을 `MILLIONS`로 설정하면 60,000,000 값이 60으로 표시됩니다. 예제는 열 차트를 만들고 수직 축에 백만 표시 단위를 적용합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **자주 묻는 질문**

**하나의 축이 다른 축을 교차하는 값(축 교차)을 어떻게 설정합니까?**

[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/)을 사용하여 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)을 설정합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**축에 대해 눈금 레이블을 어떻게 위치시키나요?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) 중 `LOW`, `HIGH`, `NEXT_TO` 또는 `NONE`을 사용하여 [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/)을 설정합니다. 눈금 자체를 제어하려면 [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 또는 [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/)을 사용합니다; 이는 레이블 위치와 별개입니다.