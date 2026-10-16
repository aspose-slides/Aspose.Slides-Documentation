---
title: Python으로 프레젠테이션의 차트 데이터 레이블 관리
linktitle: 데이터 레이블
type: docs
url: /ko/python-net/chart-data-label/
keywords:
- 차트
- 데이터 레이블
- 데이터 정밀도
- 백분율
- 레이블 거리
- 레이블 위치
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션에 차트 데이터 레이블을 추가하고 서식 지정하는 방법을 배워 보다 매력적인 슬라이드를 만들 수 있습니다."
---
## **소개**

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하도록 돕습니다. 이 문서에서는 값 서식 지정, 백분율 표시, 레이블 텍스트 읽기, 축 최대값을 초과하는 레이블 제어, 범주 축 레이블 간격 조정 및 파이 차트 레이블 위치 지정 방법을 설명합니다.

## **차트 데이터 레이블에서 데이터 정밀도 설정**

시리즈 값을 서식 지정하려면 [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/)를 사용합니다. 이 예제는 기본 데이터가 있는 라인 차트를 생성하고, 데이터 테이블을 표시하며, 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 형식은 천 단위 구분 기호와 소수점 두 자리를 표시하지만 기본 값은 변경하지 않습니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **백분율을 레이블로 표시**

스택형 열 차트의 경우 각 값을 해당 범주 총계에 대한 백분율로 계산하고 텍스트를 [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)에 할당합니다. 이 예제는 기본 차트 데이터를 사용하고 8포인트 글꼴로 소수점 두 자리 백분율을 표시합니다. 총계가 0인 범주는 나눗셈 오류를 방지하기 위해 건너뛰습니다. 차트 데이터가 변경되면 사용자 정의 레이블 텍스트를 다시 계산합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 데이터 레이블에 백분율 기호 설정**

값이 분수 형태로 저장된 경우 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/)를 사용하여 백분율을 표시합니다. [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/)를 `False`로 설정하면 원본 셀과 독립적으로 레이블 형식이 적용됩니다.

이 예제는 네 개 범주에 걸쳐 빨간색과 파란색 시리즈가 포함된 100% 스택형 열 차트를 생성합니다. 각 값 쌍은 합계가 1이 됩니다. 레이블 형식 `0.0%`는 0.30을 30.0%로 표시하고, 수직 축은 소수점 두 자리로 표시합니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **데이터 레이블의 실제 텍스트 읽기**

데이터 레이블 설정에 의해 생성된 텍스트를 검색하려면 [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/)를 사용합니다. 이는 보고서용 레이블을 추출하거나 프레젠테이션 내용을 검색하거나 생성된 차트를 검증할 때 유용합니다. 아래 예제에서 기본 [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/)은 각 범주 이름, 시리즈 이름 및 값을 결합합니다. 하나의 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)에서 사용자 정의 텍스트를 사용합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

데이터 포인트에 저장된 숫자는 `0.75`이며, 레이블에 범주 및 시리즈 이름과 함께 `75%`가 표시되더라도 값은 그대로입니다. 사용자 정의 텍스트가 생성된 레이블 텍스트를 대체합니다. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/)는 어느 경우든 결과 레이블 문자열을 반환합니다. 표시된 레이블만 추출하려는 경우 위와 같이 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/)를 별도로 확인하십시오.

## **축 최대값을 초과하는 데이터 레이블 제어**

축 범위를 수동으로 제한하면 일부 데이터 포인트가 최대값을 초과할 수 있습니다. [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/)를 사용하여 해당 데이터 레이블을 표시할지 여부를 제어합니다. 이 설정은 레이블 표시 여부만 변경하며, 축 범위나 기본 데이터 값은 변경하지 않습니다.

아래 예제는 값이 60과 120인 2D 군집 열 차트를 생성합니다. 수직 축에 대해 [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/)를 `False`로, [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/)를 100으로 설정합니다. 첫 번째 슬라이드는 최대값을 초과하는 레이블을 허용하고, 해당 슬라이드의 복사본은 이를 비활성화합니다. 두 슬라이드 모두 `DataLabelsOverMaximum.pptx`에 저장됩니다.

[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/)를 사용하여 값 레이블을 활성화합니다. 차트 수준 설정은 자체적으로 값 표시를 활성화하거나 개별 레이블의 비활성화된 값 표시를 재정의하지 않습니다. 이 예제는 전체 시리즈에 값을 활성화하고 [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/)를 사용하여 각 열의 외부 끝에 레이블을 배치합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

다음 이미지들은 Microsoft PowerPoint에서 렌더링된 저장된 슬라이드를 보여줍니다. `True`일 경우 레이블 **120**이 상단 경계에 표시되고, `False`일 경우 숨겨집니다. 레이블 **60**은 계속 표시되며, 축 최대값은 **100**으로 유지되고, 두 번째 데이터 포인트는 두 경우 모두 **120**으로 유지됩니다.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
이 예제는 값 축이 있는 2D 열 차트를 사용합니다. 파이 차트 및 도넛 차트와 같이 값 축이 없는 차트는 이러한 방식으로 제한할 축 최대값이 없습니다.
{{% /alert %}}

## **축에서 레이블 거리 설정**

[label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/)를 사용하여 범주 축 레이블과 축 사이의 거리를 제어합니다. 값은 축 레이블 최대 글꼴 크기의 백분율입니다. 이 예제는 군집 열 차트를 생성하고 가로 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 연결된 레이블이 아니라 범주 축 레이블에 영향을 줍니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **레이블 위치 조정**

파이 차트에서 데이터 레이블 위치를 조정하여 간격을 개선하고 리더 라인을 위한 공간을 확보합니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고 레이블을 슬라이스 외부에 배치하며 [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/)와 [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) 오프셋을 조정합니다. 이러한 오프셋은 각각 차트 너비와 높이에 대한 비율입니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **리더 라인 서식 지정**

파이 차트 레이블이 슬라이스 밖에 있을 때, 리더 라인은 각 값을 올바른 슬라이스와 연결하는 데 도움이 됩니다. 대비되는 색상과 약간 두꺼운 선은 연결을 더 쉽게 인식하게 하고, 투명도와 점선 스타일은 라인을 시각적으로 눈에 띄지 않게 유지합니다.

[leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/)를 사용하여 시리즈 데이터 레이블 컬렉션 수준에서 리더 라인을 서식 지정합니다. `series.labels.leader_lines_format.line`의 설정은 개별 레이블이 아니라 컬렉션에 적용됩니다.

이 예제는 기본 데이터가 있는 파이 차트를 생성하고 슬라이스 외부에 값을 표시하며 [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/)를 활성화합니다. [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/)와 [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) 오프셋을 사용하여 두 레이블을 슬라이스에서 더 멀리 이동시키며, 오프셋은 차트 너비와 높이에 대한 비율로 표현됩니다. 입력 프레젠테이션은 필요하지 않습니다.

라인의 [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/)은 255 중 191의 알파 값을 가진 솔리드 블루 색상을 설정하여 약 25% 투명도를 제공합니다. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/)는 두께를 2 포인트로 설정하고, [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/)는 라인을 점선으로 만듭니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # 두 레이블을 슬라이스에서 더 멀리 이동시킵니다.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

리더 라인을 활성화해도 모든 레이블에 라인이 표시된다는 보장은 없습니다. 가시성은 레이블 배치와 차트 레이아웃 동작에 따라 결정됩니다. 이 예제에서는 두 개의 이동된 레이블에 보이는 리더 라인이 있으며, 슬라이스에 가깝게 남아 있는 레이블은 필요하지 않습니다.

다음 이미지는 Aspose.Slides로 렌더링된 저장된 `FormattedLeaderLines.pptx`를 보여줍니다:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **열 차트 위에 데이터 레이블 여러 행 추가**

이 예제는 플롯 영역 위에 두 행의 데이터 레이블이 있는 열 차트를 생성합니다. Series A는 보이는 열을 표시하고, Series B와 Series C는 추가 레이블을 제공합니다. 해당 열은 채우기와 윤곽선을 제거하여 숨깁니다. [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) 속성은 세 시리즈를 동일한 범주 중심에 맞춥니다.

[plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) 설정은 레이블 행을 위한 공간을 예약합니다. [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)이 기본 위치를 계산한 후, [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/)와 [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/)는 수평 정렬을 유지하고 수직 오프셋을 적용하여 레이블을 두 행으로 배치합니다. 숫자는 여전히 시리즈 값에 연결된 데이터 레이블이며, 행 제목만 별도의 텍스트 도형입니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # B와 C의 열을 숨기되, 데이터 레이블은 유지합니다.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # 세 시리즈를 모두 동일한 범주 중심에 맞춥니다.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # 이 간결한 예제에서는 눈금선을 적게 사용합니다.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # 플롯 위에 두 행의 데이터 레이블을 위한 공간을 예약합니다.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # 기본 수평 위치를 유지합니다. Y는 다음으로부터의 오프셋입니다
            # 기본 레이블 위치이며, 차트 높이 비율로 표현됩니다.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # 행 제목만 별도의 텍스트 도형입니다.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**데이터 레이블이 빽빽한 차트에서 겹치는 것을 어떻게 방지할 수 있나요?**  
자동 레이블 배치, 리더 라인 및 글꼴 크기 축소를 결합합니다; 필요하면 일부 필드(예: 범주)를 숨기거나 극값 또는 핵심 포인트에만 레이블을 표시합니다.

**값이 0, 음수 또는 비어있는 경우에만 레이블을 비활성화하려면 어떻게 해야 하나요?**  
레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0값, 음수값 또는 누락된 값에 대해 표시를 끕니다.

**PDF/이미지로 내보낼 때 일관된 레이블 스타일을 보장하려면 어떻게 해야 하나요?**  
글꼴 가족과 크기를 명시적으로 설정하고, 렌더링 환경에 해당 글꼴이 존재하는지 확인하여 대체 글꼴 사용을 방지합니다.