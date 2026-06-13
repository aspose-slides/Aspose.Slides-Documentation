---
title: Python에서 차트 데이터 시리즈 관리
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
description: 실용적인 코드 예제와 모범 사례를 통해 PowerPoint(PPT/PPTX)용 Python에서 차트 데이터 시리즈를 관리하는 방법을 배우고 데이터 프레젠테이션을 향상시키세요.
---
## **개요**

This article describes the role of [ChartSeries](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/) in Aspose.Slides for Python, focusing on how data is structured and visualized within presentations. These objects provide the foundational elements that define individual sets of data points, categories, and appearance parameters in a chart. By working with [ChartSeries](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/), developers can seamlessly integrate underlying data sources and maintain full control over how information is displayed, resulting in dynamic, data-driven presentations that clearly convey insights and analysis.

A series is a row or column of numbers plotted in a chart.

![차트 시리즈 파워포인트](chart-series-powerpoint.png)

## **시리즈 겹침 설정**

The [ChartSeries.overlap](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/overlap/) property controls how bars and columns overlap in a 2D chart by specifying a range from -100 to 100. Since this property is associated with the series group rather than individual chart series, it is read-only at the series level. To configure overlap values, use the `parent_series_group.overlap` read/write property, which applies the specified overlap to all series in that group.

Below is a Python example that demonstrates how to create a presentation, add a clustered column chart, access the first chart series, configure the overlap setting, and then save the result as a PPTX file:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 기본 데이터로 클러스터형 열 차트를 추가합니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # 시리즈 겹침을 설정합니다.
        series.parent_series_group.overlap = series_overlap

    # 프레젠테이션 파일을 디스크에 저장합니다.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

Aspose.Slides makes it straightforward to customize the fill colors of chart series, allowing you to highlight specific data points and create visually appealing charts. This is achieved through the [Format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/format/) object, which supports various fill types, color configurations, and other advanced styling options. After adding a chart to a slide and accessing the desired series, simply get a series and apply the appropriate fill color. Beyond solid fills, you can also leverage gradient or pattern fills for enhanced design flexibility. Once you’ve set the colors according to your requirements, save the presentation to finalize the updated look.

The following Python code example shows how to change the color of the first series:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 기본 데이터로 클러스터형 열 차트를 추가합니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # 첫 번째 시리즈의 색상을 설정합니다.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # 프레젠테이션 파일을 디스크에 저장합니다.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![시리즈 색상](series_color.png)

## **시리즈 이름 바꾸기** 

Aspose.Slides offers a simple way to modify the names of chart series, making it easier to label data in a clear and meaningful way. By accessing the relevant worksheet cell in the chart data, developers can customize how the data is presented. This modification is particularly useful when series names need to be updated or clarified based on the data’s context. After renaming the series, the presentation can be saved to persist the changes. 

Below is a Python code snippet demonstrating this process in action.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 기본 데이터로 클러스터형 열 차트를 추가합니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # 첫 번째 시리즈의 이름을 설정합니다.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # 프레젠테이션 파일을 디스크에 저장합니다.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

The following Python code shows an alternative way to change the series name:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 기본 데이터로 클러스터형 열 차트를 추가합니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # 첫 번째 시리즈의 이름을 설정합니다.
    series.name.as_cells[0].value = series_name

    # 프레젠테이션 파일을 디스크에 저장합니다.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

결과:

![시리즈 이름](series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

Aspose.Slides for Python allows you to get the automatic fill color for chart series within a plot area. After creating an instance of the [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) class, you can obtain a reference to the desired slide by index, then add a chart using your preferred type (such as `ChartType.CLUSTERED_COLUMN`). By accessing the series in the chart, you can get the automatic fill color.

The Python code below demonstrates this process in detail.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 기본 데이터로 클러스터형 열 차트를 추가합니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # 시리즈의 채우기 색상을 가져옵니다.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

예시 출력:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **시리즈에 대한 반전 채우기 색상 설정**

When your data series contains both positive and negative values, simply coloring every column or bar the same can make the chart hard to read. Aspose.Slides for Python lets you assign an invert fill color—a separate fill applied automatically to data points that fall below zero—so negative values stand out at a glance. In this section you’ll learn how to enable that option, choose an appropriate color, and save the updated presentation.

The following code example demonstrates the operation:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 새 범주를 추가합니다.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # 새 시리즈를 추가합니다.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # 시리즈 데이터를 채웁니다.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # 시리즈의 색상 설정을 지정합니다.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![반전된 단색 채우기 색상](inverted_solid_fill_color.png)

You can invert the fill color for a single data point rather than the whole series. Simply access the desired `ChartDataPoint` and set its `invert_if_negative` property to `True`.

The following code example shows how to do this:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **특정 데이터 포인트 데이터 지우기**

Sometimes a chart contains test values, outliers, or obsolete entries that you need to remove without rebuilding the entire series. Aspose.Slides for Python lets you target any data point by index, clear its contents, and instantly refresh the plot so the remaining points shift and the axes rescale automatically.

The following code exammple demonstrates the operation:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **시리즈 간격 너비 설정**

Gap width controls the amount of empty space between adjacent columns or bars—wider gaps emphasize individual categories, while narrower gaps create a denser, more compact look. Through Aspose.Slides for Python you can fine‑tune this parameter for an entire series, achieving exactly the visual balance your presentation requires without altering the underlying data.

The following code example shows how to set the gap width for a series:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# 빈 프레젠테이션을 생성합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 기본 데이터로 차트를 추가합니다.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # gap_width 값을 설정합니다.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![간격 너비](gap_width.png)

## **FAQ**

**하나의 차트에 포함될 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides imposes no fixed cap on the number of series you add. The practical ceiling is set by chart readability and by the memory available to your application.

**클러스터 내의 열이 너무 가깝거나 너무 멀리 떨어져 있으면 어떻게 해야 하나요?**

Adjust the [gap_width](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartseries/gap_width/) setting for that series (or its parent series group). Increasing the value widens the space between columns, while decreasing it brings them closer together.