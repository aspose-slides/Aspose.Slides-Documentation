---
title: Python을 사용한 프레젠테이션 차트 호출선 관리
linktitle: 호출선
type: docs
url: /ko/python-java/callout/
keywords:
- 차트 호출선
- 호출선 사용
- 데이터 레이블
- 레이블 형식
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 호출선을 생성하고 스타일을 지정하며, 간결한 코드 예제를 제공하고, PPT 및 PPTX와 호환되어 프레젠테이션 워크플로를 자동화합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 데이터 레이블에 대한 호출선을 사용하는 방법을 설명합니다. [setShowLabelAsDataCallout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) 메서드를 사용하여 레이블을 호출선으로 표시하는 방법, 도넛 차트에 대한 호출선 관련 레이블 설정을 구성하는 방법, 그리고 프레젠테이션을 PDF, HTML5, SVG 및 래스터 이미지 형식으로 내보낼 때 호출선과 그 모양이 보존된다는 점을 설명합니다.

## **호출선 사용**

DataLabelFormat 클래스의 [getShowLabelAsDataCallout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) 및 [setShowLabelAsDataCallout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) 메서드는 차트 데이터 레이블을 호출선으로 표시할지 일반 데이터 레이블로 표시할지를 결정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **도넛 차트에 호출선 설정**

Aspose.Slides for Python via Java는 도넛 차트에 대한 시리즈 데이터 레이블 호출선 모양 설정을 지원합니다. 다음 예제가 이를 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **자주 묻는 질문**

**프레젠테이션을 PDF, HTML5, SVG 또는 이미지로 변환할 때 호출선이 보존되나요?**

예. 호출선은 차트 렌더링의 일부이므로 [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/ko/python-java/export-to-html5/), [SVG](/slides/ko/python-java/render-a-slide-as-an-svg-image/), 또는 [raster images](/slides/ko/python-java/convert-powerpoint-to-png/) 로 내보낼 때 슬라이드 형식과 함께 보존됩니다.

**맞춤 글꼴이 호출선에서 작동하며, 내보낼 때 모양이 보존될 수 있나요?**

예. Aspose.Slides는 프레젠테이션에 [embedding fonts](/slides/ko/python-java/embedded-font/) 를 삽입하는 것을 지원하고, [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/) 등으로 내보낼 때 글꼴 포함을 제어하여 호출선이 다양한 시스템에서 동일하게 보이도록 보장합니다.