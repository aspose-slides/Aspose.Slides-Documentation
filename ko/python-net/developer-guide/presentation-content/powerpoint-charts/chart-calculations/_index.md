---
title: Python을 사용한 프레젠테이션 차트 계산 최적화
linktitle: 차트 계산
type: docs
weight: 50
url: /ko/python-net/chart-calculations/
keywords:
- 차트 계산
- 차트 요소
- 요소 위치
- 실제 위치
- 하위 요소
- 상위 요소
- 차트 값
- 실제 값
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 PPT, PPTX 및 ODP용 차트 계산, 데이터 업데이트 및 정밀 제어를 실제 코드 예제와 함께 이해하십시오."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 차트 계산 및 레이아웃 데이터를 처리하기 위한 API를 제공합니다. 이 문서는 `ActualLayout`을 구현하는 요소의 실제 위치와 크기 및 차트 축의 실제 값을 포함한 차트 요소의 실제 값을 검색하는 방법을 보여줍니다. 또한 이러한 값들은 차트 레이아웃 검증 후에 채워진다는 점을 설명합니다.

추가로, 이 문서는 부모 차트 요소의 실제 위치를 얻는 방법과 제목, 축, 범례, 눈금선과 같은 차트 구성 요소를 숨기는 방법을 설명합니다. 이러한 예제를 통해 차트 레이아웃 정보를 검사하고 PowerPoint 프레젠테이션에서 차트 요소의 표시 여부를 프로그래밍 방식으로 제어할 수 있습니다.

## **차트 요소의 실제 값 계산**
Aspose.Slides for Python via .NET은 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. 이를 통해 차트 요소의 실제 값을 계산할 수 있습니다. 실제 값에는 [IActualLayout](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/iactuallayout/) 클래스를 상속받는 요소의 위치(IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight)와 실제 축 값(IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale)이 포함됩니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```



## **부모 차트 요소의 실제 위치 계산**
Aspose.Slides for Python via .NET은 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. IActualLayout의 속성은 부모 차트 요소의 실제 위치에 대한 정보를 제공합니다. 속성을 실제 값으로 채우려면 먼저 IChart.ValidateChartLayout() 메서드를 호출해야 합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```



## **차트에서 정보 숨기기**
이 항목에서는 차트에서 정보를 숨기는 방법을 설명합니다. Aspose.Slides for Python via .NET을 사용하면 차트에서 **제목, 세로 축, 가로 축** 및 **눈금선**을 숨길 수 있습니다. 아래 코드 예제는 이러한 속성을 사용하는 방법을 보여줍니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # 차트 제목 숨기기
    chart.has_title = False

    # 값 축 숨기기
    chart.axes.vertical_axis.is_visible = False

    # 범주 축 표시 여부
    chart.axes.horizontal_axis.is_visible = False

    # 범례 숨기기
    chart.has_legend = False

    # 주 격자선 숨기기
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # 시리즈 선 색상 설정
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**외부 Excel 통합 문서를 데이터 소스로 사용할 수 있나요? 그리고 재계산에 어떤 영향을 미치나요?**

예. 차트는 외부 통합 문서를 참조할 수 있습니다. 외부 소스를 연결하거나 새로 고치면 해당 통합 문서에서 수식과 값이 가져와지고, 차트는 열기/편집 작업 중에 업데이트를 반영합니다. API를 사용하면 [외부 통합 문서](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 경로를 지정하고 연결된 데이터를 관리할 수 있습니다.

**회귀 분석을 직접 구현하지 않고도 추세선을 계산하고 표시할 수 있나요?**

예. [Trendlines](/slides/ko/python-net/trend-line/) (선형, 지수형 등)은 Aspose.Slides에 의해 추가 및 업데이트되며, 매개변수는 시리즈 데이터에서 자동으로 재계산되므로 직접 계산을 구현할 필요가 없습니다.

**프레젠테이션에 외부 링크가 있는 여러 차트가 있는 경우, 각 차트가 사용할 통합 문서를 별도로 제어할 수 있나요?**

예. 각 차트는 자신의 [외부 통합 문서](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/)를 가리키도록 할 수 있으며, 차트별로 외부 통합 문서를 독립적으로 생성하거나 교체할 수 있습니다.