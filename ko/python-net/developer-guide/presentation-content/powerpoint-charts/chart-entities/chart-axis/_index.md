---
title: Python을 사용한 프레젠테이션 차트 축 커스터마이징
linktitle: 차트 축
type: docs
url: /ko/python-net/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 커스터마이징
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
description: "보고서와 시각화를 위해 PowerPoint 및 OpenDocument 프레젠테이션에서 차트 축을 커스터마이징하기 위해 .NET을 통한 Python용 Aspose.Slides 사용 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 축을 사용자 지정하는 방법을 설명합니다. 실제 축 값을 가져오는 방법, 축 간 데이터 교환, 선형 차트에서 수직 또는 수평 축 숨기기, 범주 축 유형 변경, 범주 축 값의 날짜 형식 설정, 축 제목 회전, 축 위치 설정, 값 축에 단위 레이블 표시 방법을 보여 줍니다.

## **차트 수직 축에서 최대값 가져오기**
Aspose.Slides for Python via .NET을 사용하면 수직 축의 최소값과 최대값을 얻을 수 있습니다. 다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 액세스합니다.
3. 기본 데이터가 포함된 차트를 추가합니다.
4. 축의 실제 최대값을 가져옵니다.
5. 축의 실제 최소값을 가져옵니다.
6. 축의 실제 주요 단위(major unit)를 가져옵니다.
7. 축의 실제 보조 단위(minor unit)를 가져옵니다.
8. 축의 실제 주요 단위 눈금(major unit scale)을 가져옵니다.
9. 축의 실제 보조 단위 눈금(minor unit scale)을 가져옵니다.

위 단계들을 구현한 샘플 코드는 Python에서 필요한 값을 가져오는 방법을 보여 줍니다:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# 프레젠테이션을 저장합니다
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **축 간 데이터 교환**
Aspose.Slides를 사용하면 축 간의 데이터를 빠르게 교환할 수 있습니다—수직 축(y축)의 데이터가 수평 축(x축)으로 이동하고 그 반대도 마찬가지입니다. 

다음 Python 코드는 차트에서 축 간 데이터 교환 작업을 수행하는 방법을 보여 줍니다:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 빈 프레젠테이션을 생성합니다
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #행과 열을 전환합니다
    chart.chart_data.switch_row_column()
            
    # 프레젠테이션을 저장합니다
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **선형 차트에서 수직 축 비활성화**

다음 Python 코드는 선형 차트에서 수직 축을 숨기는 방법을 보여 줍니다:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **선형 차트에서 수평 축 비활성화**

다음 코드는 선형 차트에서 수평 축을 숨기는 방법을 보여 줍니다:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **범주 축 변경**

**CategoryAxisType** 속성을 사용하면 원하는 범주 축 유형(**date** 또는 **text**)을 지정할 수 있습니다. 다음 Python 코드는 해당 작업을 시연합니다: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **범주 축 값의 날짜 형식 설정**
Aspose.Slides for Python via .NET을 사용하면 범주 축 값의 날짜 형식을 설정할 수 있습니다. 다음 Python 코드에서 작업이 시연됩니다:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 축 제목 회전 각도 설정**
Aspose.Slides for Python via .NET을 사용하면 차트 축 제목의 회전 각도를 설정할 수 있습니다. 다음 Python 코드가 작업을 보여 줍니다:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **범주 축 또는 값 축에서 위치 축 설정**
Aspose.Slides for Python via .NET을 사용하면 범주 축 또는 값 축에서 축 위치를 설정할 수 있습니다. 다음 Python 코드가 작업 수행 방법을 보여 줍니다:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 값 축에 단위 레이블 표시 활성화**
Aspose.Slides for Python via .NET을 사용하면 차트 값 축에 단위 레이블을 표시하도록 구성할 수 있습니다. 다음 Python 코드가 작업을 시연합니다:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**한 축이 다른 축을 교차하는 값(축 교차점)을 어떻게 설정합니까?**

축은 [교차 설정](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/axis/cross_type/)을 제공합니다: 0에서 교차하거나, 최대 범주/값에서 교차하거나, 특정 숫자 값에서 교차하도록 선택할 수 있습니다. 이는 X축을 위나 아래로 이동하거나 기준선을 강조할 때 유용합니다.

**눈금 레이블을 축에 대해 어떻게 배치할 수 있습니까(옆, 밖, 안)?**

[label position](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/axis/major_tick_mark/)을 "cross", "outside", "inside" 중 하나로 설정합니다. 이는 가독성에 영향을 주며, 특히 작은 차트에서 공간을 절약하는 데 도움이 됩니다.