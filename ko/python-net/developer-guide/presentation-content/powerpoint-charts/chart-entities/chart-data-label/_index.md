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

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하는 데 도움을 줍니다. 이 문서에서는 값 서식 지정, 백분율 표시, 레이블 텍스트 읽기, 범주 축 레이블 간격 조정 및 파이 차트 레이블 위치 지정 방법을 설명합니다.

## **차트 데이터 레이블에서 데이터 정밀도 설정**

시리즈 값을 서식 지정하려면 [number_format_of_values](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/number_format_of_values/) 를 사용합니다. 이 예제는 기본 데이터가 있는 선형 차트를 만들고, 데이터 표를 표시하며, 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 서식은 천 단위 구분 기호와 소수점 두 자리를 표시하지만 기본 값은 변경되지 않습니다.

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

## **레이블을 백분율로 표시**

스택형 컬럼 차트의 경우 각 값을 해당 범주의 총계에 대한 백분율로 계산하고 텍스트를 [text_frame_for_overriding](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) 에 할당합니다. 이 예제는 기본 차트 데이터를 사용하고, 8포인트 글꼴로 소수점 두 자리 백분율을 표시합니다. 총계가 0인 범주는 나눗셈 오류를 방지하기 위해 건너뜁니다. 차트 데이터가 변경될 경우 사용자 지정 레이블 텍스트를 다시 계산해야 합니다.

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

값이 분수 형태로 저장된 경우, 백분율을 표시하려면 [number_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabelformat/number_format/) 을 사용합니다. [is_number_format_linked_to_source](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) 를 `False` 로 설정하면 레이블 서식이 원본 셀과 독립적으로 적용됩니다.

이 예제는 네 가지 범주에 걸쳐 빨간색과 파란색 시리즈를 가진 100% 스택형 컬럼 차트를 생성합니다. 각 값 쌍은 합계가 1이 됩니다. 레이블 서식 `0.0%` 은 0.30을 30.0% 로 표시하며, 세로 축은 소수점 두 자리로 표시됩니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

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

## **데이터 레이블 실제 텍스트 읽기**

데이터 레이블 설정에 의해 생성된 텍스트를 가져오려면 [get_actual_label_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) 를 사용합니다. 이는 보고서용 레이블 추출, 프레젠테이션 내용 검색 또는 생성된 차트 검증에 유용합니다. 아래 예제에서는 기본 [data label format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabelformat/) 이 각 범주 이름, 시리즈 이름 및 값을 결합합니다. 한 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [text_frame_for_overriding](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) 에서 사용자 지정 텍스트를 사용합니다.

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

데이터 포인트에 저장된 숫자는 `0.75` 로 유지되지만 레이블에는 `75%` 와 함께 범주 및 시리즈 이름이 표시됩니다. 사용자 지정 텍스트는 생성된 레이블 텍스트를 대체합니다. [get_actual_label_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) 은 두 경우 모두 결과 레이블 문자열을 반환합니다. 표시된 레이블만 추출하려면 위와 같이 [is_visible](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabel/is_visible/) 를 별도로 확인하십시오.

## **축으로부터 레이블 거리 설정**

축 레이블과 축 사이의 거리를 제어하려면 [label_offset](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/axis/label_offset/) 을 사용합니다. 값은 축 레이블의 최대 글꼴 크기에 대한 백분율입니다. 이 예제는 클러스터형 컬럼 차트를 만들고 가로 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 연결된 레이블이 아니라 범주 축 레이블에 영향을 줍니다.

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

이 예제는 첫 번째 데이터 포인트의 값을 표시하고, 레이블을 슬라이스 외부에 배치하며, [x](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabel/x/) 및 [y](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabel/y/) 오프셋을 조정합니다. 이러한 오프셋은 차트 너비와 높이에 대해 각각 상대적으로 적용됩니다.

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

![조정된 데이터 레이블 위치가 있는 파이 차트](pie-chart-adjusted-label.png)

## **FAQ**

**밀집된 차트에서 데이터 레이블이 겹치는 것을 어떻게 방지할 수 있나요?**

자동 레이블 배치, 리더 라인, 글꼴 크기 축소를 결합합니다; 필요하면 일부 필드(예: 범주)를 숨기거나 극값이나 핵심 포인트에만 레이블을 표시합니다.

**값이 0, 음수 또는 비어있는 경우에만 레이블을 비활성화하려면 어떻게 해야 하나요?**

레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 0값, 음수값 또는 정의된 규칙에 따라 결측값에 대한 표시를 끕니다.

**PDF/이미지로 내보낼 때 레이블 스타일을 일관되게 유지하려면 어떻게 해야 하나요?**

글꼴 패밀리와 크기를 명시적으로 설정하고, 렌더링 환경에 해당 글꼴이 존재하는지 확인하여 대체 글꼴 사용을 방지합니다.