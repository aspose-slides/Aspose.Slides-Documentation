---
title: Python에서 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/python-net/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 멱 추세선
- 사용자 지정 추세선
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: ".NET을 통한 Python용 Aspose.Slides로 PowerPoint 차트에 추세선을 빠르게 추가하고 사용자 지정하세요 — 청중을 사로잡는 실용적인 가이드."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만들고, 차트 시리즈에 추세선을 추가하며, 지수, 선형, 로그, 이동 평균, 다항식, 멱 등 여러 추세선 유형을 다루는 방법을 보여줍니다.

또한 선 모양을 삽입하여 차트에 사용자 지정 선을 추가하는 방법을 설명하고, 앞·뒤 추세선 투영 값과 PDF 또는 SVG로 내보내거나 차트를 이미지로 렌더링할 때 추세선이 유지되는지에 대한 간단한 FAQ를 포함합니다.

## **추세선 추가**

차트 시리즈에 추세선을 추가하려면 [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/)를 사용하고, 유형은 [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/)으로 선택합니다. 예제는 기본 데이터가 있는 군집형 열 차트를 만들고 각 시리즈(총 3개)마다 두 개의 추세선을 추가합니다.

지수 추세선은 [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) 및 [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/)를 통해 식과 R제곱값을 숨기며, 선형 추세선은 빨간색입니다. 로그 추세선은 사용자 지정 레이블을 위해 [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/)를 사용합니다. 이동 평균은 세 데이터 포인트의 [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/)와 사용자 지정 [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/)를 사용합니다.

다항식 추세선은 [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/)값이 3이며, [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/)를 통해 한 카테고리 앞으로 확장됩니다. 멱 추세선은 [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/)를 통해 한 카테고리 뒤로 확장됩니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **추세선 절편 설정**

[intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/)를 사용하여 X = 0에서 추세선의 Y 값을 고정합니다. 이 설정은 선형, 지수 및 다항식 추세선에서 지원됩니다.

예를 들어, 생산 비용 모델은 비록 비정량 생산량에서 측정값이 다른 기준선을 시사하더라도, 알려진 고정 비용 100에서 시작해야 할 수 있습니다. 선형 추세선의 경우, 절편을 고정하면 방정식 `y = ax + b`가 `b = 100`으로 제한되고, 기울기는 해당 제한 하에 데이터에 맞게 추정됩니다. 이는 이미 맞춰진 선을 단순히 이동시키는 것이 아닙니다. 축 교차 설정은 차트 축이 만나는 위치를 제어하며, 맞춰진 추세선의 계수를 제어하지 않습니다.

다음 예제는 생산량 1부터 4까지와 비용 170, 200, 230, 260을 갖는 산점도(XY) 차트를 생성합니다. 기본 자동 절편으로 차트를 저장하고, 절편을 100으로 설정한 뒤 두 번째 PPTX를 저장합니다. 두 파일은 절편 설정만 다릅니다. 추세선은 식을 표시하고 X = 0까지 뒤로 연장됩니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

자동 계산을 사용하면 이 데이터는 `y = 30x + 140`을 생성합니다. 절편을 100으로 설정하면 약 `y = 43.33x + 100`이 됩니다: zero에서의 추정값이 알려진 기준선과 일치하지만, 선은 더 이상 모든 데이터 포인트를 통과하지 않습니다.

| 자동 절편 | 절편 100 고정 |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

두 이미지 모두 동일한 데이터와 축 눈금을 사용합니다. 추세선은 절편을 표시하기 위해 X = 0까지 뒤로 연장됩니다.

기본적으로 해당 속성은 `float("nan")`을 포함하며, 이는 0이 아니라 명시되지 않은 절편을 의미합니다. 이후 절편은 데이터에서 자동으로 계산됩니다.

## **사용자 지정 선 추가**

사용자 지정 선은 시리즈 데이터에서 계산된 추세선이 아니라 차트 위에 그려지는 도형입니다. 이 예제는 [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/)를 사용하여 차트 위 슬라이드에 가로선을 추가합니다. 선의 위치는 포인트 단위 슬라이드 좌표로 지정되어 차트 왼쪽 가장자리에서 시작해 차트 중간 높이에 위치합니다. 너비는 차트 너비와 동일합니다. [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/)을 사용해 선에 단색 빨간색을 적용합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**추세선의 'forward'와 'backward'는 무엇을 의미합니까?**

이는 추세선을 앞·뒤로 투영한 길이를 나타냅니다. 산점도(XY) 차트에서는 축 단위이며, 비산점도 차트에서는 카테고리 수로 표시됩니다. 음수 값은 허용되지 않습니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 유지됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/) 또는 [SVG](/slides/ko/python-net/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다; 차트의 일부인 추세선은 이러한 작업 중에 보존됩니다. 차트 자체의 이미지를 [내보내는](/slides/ko/python-net/create-shape-thumbnails/) 메서드도 제공됩니다.