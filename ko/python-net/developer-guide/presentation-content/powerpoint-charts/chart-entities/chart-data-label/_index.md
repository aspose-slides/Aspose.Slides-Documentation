---
title: Python을 사용한 프레젠테이션에서 차트 데이터 라벨 관리
linktitle: 데이터 라벨
type: docs
url: /ko/python-net/chart-data-label/
keywords:
- 차트
- 데이터 라벨
- 데이터 정밀도
- 백분율
- 라벨 거리
- 라벨 위치
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 차트 데이터 라벨을 추가하고 서식 지정하는 방법을 배우고, 보다 매력적인 슬라이드를 만들 수 있습니다."
---
## **개요**

차트의 데이터 라벨은 차트 데이터 시리즈 또는 개별 데이터 포인트에 대한 세부 정보를 표시합니다. 독자가 데이터 시리즈를 빠르게 식별할 수 있게 하며 차트를 보다 이해하기 쉽게 만듭니다. Aspose.Slides for Python에서는 차트에 대한 데이터 라벨을 활성화, 사용자 지정 및 서식 지정할 수 있으며, 표시할 내용(값, 백분율, 시리즈 또는 카테고리 이름), 라벨 위치, 모양(글꼴, 숫자 형식, 구분자, 리더 라인 등)을 선택할 수 있습니다. 본 문서는 차트에 명확하고 유용한 라벨을 추가하기 위해 필요한 핵심 API와 예제를 정리합니다.

## **데이터 라벨 정밀도 설정**

차트 데이터 라벨은 일관된 정밀도가 필요한 숫자 값을 표시하는 경우가 많습니다. 이 섹션에서는 적절한 숫자 형식을 적용하여 Aspose.Slides에서 데이터 라벨의 소수점 자리수를 제어하는 방법을 보여줍니다.

다음 Python 예제는 차트 데이터 라벨의 숫자 정밀도를 설정하는 방법을 보여줍니다:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **라벨에 백분율 표시**

Aspose.Slides를 사용하면 차트에 백분율을 데이터 라벨로 표시할 수 있습니다. 아래 예제는 각 포인트가 해당 카테고리 내에서 차지하는 비율을 계산하고 라벨을 백분율로 포맷합니다.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # 차트를 포함한 프레젠테이션을 저장합니다.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 데이터 라벨에 퍼센트 기호 표시**

이 섹션에서는 차트 데이터 라벨에 백분율을 표시하고 퍼센트 기호를 포함하는 방법을 보여줍니다. 전체 시리즈 또는 특정 포인트에 대한 백분율 값을 활성화하는 방법(파이, 도넛, 100% 스택 차트에 이상적)과 라벨 옵션 또는 사용자 지정 숫자 형식을 통해 서식을 제어하는 방법을 배울 수 있습니다.

다음 Python 예제는 차트 데이터 라벨에 퍼센트 기호를 추가하는 방법을 보여줍니다:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:

    # 인덱스로 슬라이드 참조를 가져옵니다.
    slide = presentation.slides[0]

    # 슬라이드에 PercentsStackedColumn 차트를 생성합니다.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # 차트 데이터 워크북을 가져옵니다.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # 새로운 시리즈를 추가합니다.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # 시리즈 채우기 색상을 설정합니다.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # 라벨 서식 속성을 설정합니다.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # 새로운 시리즈를 추가합니다.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # 채우기 유형과 색상을 설정합니다.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # 프레젠테이션을 저장합니다.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **축으로부터 라벨 거리 설정**

이 섹션에서는 Aspose.Slides에서 데이터 라벨과 차트 축 사이의 거리를 제어하는 방법을 보여줍니다. 이 오프셋을 조정하면 겹침을 방지하고 복잡한 시각화에서 가독성을 개선할 수 있습니다.

다음 Python 코드는 축 기반 차트를 사용할 때 범주 축으로부터 라벨 거리를 설정하는 방법을 보여줍니다:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:
    # 슬라이드 참조를 가져옵니다.
    slide = presentation.slides[0]

    # 슬라이드에 클러스터드 컬럼 차트를 생성합니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # 카테고리(가로) 축으로부터 라벨 거리 설정.
    chart.axes.horizontal_axis.label_offset = 500

    # 프레젠테이션을 저장합니다.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **라벨 위치 조정**

축을 사용하지 않는 차트(예: 파이 차트)를 만들 때 데이터 라벨이 가장자리와 너무 가깝게 표시될 수 있습니다. 이 경우 라벨 위치를 조정하여 리더 라인이 명확히 보이도록 합니다.

다음 Python 코드는 파이 차트에서 라벨 위치를 조정하는 방법을 보여줍니다:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Changed label position](changed_label_position.png)

## **FAQ**

**데이터 라벨이 빽빽한 차트에서 겹치는 것을 어떻게 방지할 수 있나요?**  
자동 라벨 배치, 리더 라인, 폰트 크기 감소를 결합합니다; 필요하면 일부 필드(예: 카테고리)를 숨기거나 극값/핵심 포인트에만 라벨을 표시합니다.

**0, 음수 또는 비어 있는 값에 대해서만 라벨을 비활성화하려면 어떻게 해야 하나요?**  
라벨을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0값, 음수값 또는 누락된 값에 대한 표시를 끕니다.

**PDF/이미지로 내보낼 때 일관된 라벨 스타일을 어떻게 보장할 수 있나요?**  
폰트(패밀리, 크기)를 명시적으로 설정하고, 렌더링 측에서 해당 폰트가 사용 가능한지 확인하여 대체 폰트가 적용되지 않도록 합니다.