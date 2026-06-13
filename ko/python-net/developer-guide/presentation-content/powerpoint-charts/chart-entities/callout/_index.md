---
title: 파이썬을 사용한 프레젠테이션 차트의 콜아웃 관리
linktitle: 콜아웃
type: docs
url: /ko/python-net/callout/
keywords:
- 차트 콜아웃
- 콜아웃 사용
- 데이터 레이블
- 레이블 형식
- Python
- Aspose.Slides
description: "Aspose.Slides for Python .NET에서 콜아웃을 생성하고 스타일링하는 방법을 간결한 코드 예제로 보여줍니다. PPT, PPTX 및 ODP와 호환되어 프레젠테이션 워크플로를 자동화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 데이터 레이블에 대한 콜아웃을 사용하는 방법을 설명합니다. `show_label_as_data_callout` 속성을 사용하여 레이블을 콜아웃으로 표시하는 방법, 도넛 차트에 대한 콜아웃 관련 레이블 설정을 구성하는 방법, 그리고 프레젠테이션을 PDF, HTML5, SVG 및 래스터 이미지 형식으로 내보낼 때 콜아웃과 그 모양이 보존되는지에 대해 안내합니다.

## **콜아웃 사용**
새 속성 **show_label_as_data_callout**이 **DataLabelFormat** 클래스에 추가되어 지정된 차트의 데이터 레이블을 데이터 콜아웃으로 표시할지 데이터 레이블로 표시할지를 결정합니다. 아래 예시에서는 콜아웃을 설정했습니다.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **도넛 차트에 콜아웃 설정**
Aspose.Slides for Python via .NET은 도넛 차트에 대한 시리즈 데이터 레이블 콜아웃 모양을 설정하는 기능을 제공합니다. 아래 샘플 예제가 있습니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **자주 묻는 질문**

**프레젠테이션을 PDF, HTML5, SVG 또는 이미지로 변환할 때 콜아웃이 보존되나요?**

예. 콜아웃은 차트 렌더링의 일부이므로 [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/ko/python-net/export-to-html5/), [SVG](/slides/ko/python-net/render-a-slide-as-an-svg-image/), [래스터 이미지](/slides/ko/python-net/convert-powerpoint-to-png/) 로 내보낼 때 슬라이드 서식과 함께 보존됩니다.

**맞춤 글꼴이 콜아웃에 적용되며 내보낼 때 모양이 유지되나요?**

예. Aspose.Slides는 프레젠테이션에 [글꼴 포함](/slides/ko/python-net/embedded-font/)을 지원하며, [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/) 등으로 내보낼 때 글꼴 포함을 제어하여 콜아웃이 다양한 시스템에서 동일하게 표시되도록 합니다.