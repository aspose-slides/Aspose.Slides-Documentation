---
title: Python을 사용한 프레젠테이션에서 파이 차트 맞춤 설정
linktitle: 파이 차트
type: docs
url: /ko/python-net/pie-chart/
keywords:
- 파이 차트
- 차트 관리
- 차트 사용자 지정
- 차트 옵션
- 차트 설정
- 플롯 옵션
- 슬라이스 색상
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 파이 차트를 만들고 사용자 지정합니다. 보조 플롯을 구성하고, 데이터 레이블을 표시하며, PowerPoint에서 자동 슬라이스 색상을 적용합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 원형 차트를 사용하는 방법을 설명합니다. 이 문서는 Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 원형 차트에 자동 슬라이스 색상을 적용하는 방법을 보여줍니다.

예제는 슬라이드에 차트를 추가하고, 시리즈 및 레이블 설정을 조정하고, 기본 차트 데이터를 사용자 지정 카테고리와 값으로 교체하며, 업데이트된 프레젠테이션을 저장하는 차트 사용자 지정 작업에 중점을 둡니다.

## **Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션**

Aspose.Slides for Python via .NET은 Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션을 지원합니다. 이러한 옵션은 보조 플롯의 크기와 두 플롯 간에 데이터 포인트가 어떻게 분할되는지를 제어합니다.

다음 예제는 새 프레젠테이션에 Pie of Pie 차트를 생성하고 데이터 포인트 값을 레이블로 표시합니다. [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) 속성은 보조 플롯 크기를 메인 플롯의 149%로 설정합니다. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/)는 백분율 기반 분할을 선택하고, [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/)은 임계값을 53%로 설정합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # 값 표시 및 보조 플롯 구성.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **보조 플롯을 위한 카테고리 선택**

특정 카테고리를 그 비율에 관계없이 보조 플롯에 그룹화하려면 사용자 지정 분할을 사용합니다. 예를 들어, 매출 보고서에서 Online과 Events를 함께 표시하여 독자가 이 두 채널을 비교할 수 있도록 할 수 있습니다(각각 전체 매출의 35%와 10%를 차지).

[pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/)를 [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/)으로 설정하고 [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/)를 통해 포인트를 선택합니다. 컬렉션의 [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) 메서드는 시리즈 내의 0부터 시작하는 인덱스 또는 데이터 포인트 객체를 허용합니다. 이 예제에서는 인덱스 1이 Online을 선택하고 인덱스 3이 Events를 선택합니다. Partners도 일시적으로 추가된 뒤 [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/)를 사용해 제외됩니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # 기본 데이터를 채널별 매출로 교체합니다.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Online을 0 기반 인덱스로, Events를 데이터 포인트 객체로 선택합니다.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Partners를 선택에서 제외하지만 원본 데이터를 삭제하지는 않습니다.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online(35) 및 Events(10)는 보조 플롯에서 별개의 슬라이스로 표시됩니다. 기본 플롯에서는 Retail(40) 및 Partners(15)와 함께 값이 45인 하나의 결합된 슬라이스로 나타납니다. Partners를 사용자 지정 선택에서 제거하면 기본 플롯에 남아 있지만 차트 원본 데이터에서 해당 카테고리나 값이 삭제되지는 않습니다.

다음 이미지는 PowerPoint에서 저장된 프레젠테이션을 보여줍니다:

![보조 플롯에서 Online 및 Events와 기본 플롯에서 결합된 값 45를 가진 Pie of Pie 차트](pie_of_pie_custom.png)

## **자동 원형 차트 슬라이스 색상 설정**

Aspose.Slides for Python via .NET은 원형 차트 슬라이스에 자동으로 서로 다른 색상을 할당할 수 있습니다. 다음 예제는 중앙에 제목이 있는 원형 차트를 만들고 기본 데이터를 3개의 분기별 카테고리와 해당 값으로 교체합니다. [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) 속성은 값 20, 50, 30을 레이블로 표시하고, [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/)는 각 슬라이스에 개별 색상을 적용합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # 차트 제목을 가운데 정렬하여 추가합니다.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 기본 데이터를 첫 번째 워크시트를 사용하여 교체합니다.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # 값 표시 및 슬라이스마다 다른 색상 지정.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Pie of Pie 및 Bar of Pie 변형이 지원됩니까?**

예, 라이브러리는 원형 차트에 대한 보조 플롯을 [지원합니다](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/), 여기에는 Pie of Pie 및 Bar of Pie 유형이 포함됩니다.

**차트를 이미지(예: PNG)로만 내보낼 수 있나요?**

예, 전체 프레젠테이션을 내보내지 않고 차트를 이미지로 [차트를 이미지로 내보내기](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (예: PNG) 할 수 있습니다.