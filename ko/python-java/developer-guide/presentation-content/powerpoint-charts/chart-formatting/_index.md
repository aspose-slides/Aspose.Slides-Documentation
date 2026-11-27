---
title: Python에서 프레젠테이션 차트 서식 지정
linktitle: 차트 서식 지정
type: docs
weight: 60
url: /ko/python-java/chart-formatting/
keywords:
- 차트 서식 지정
- 차트 서식
- 차트 엔터티
- 차트 속성
- 차트 설정
- 차트 옵션
- 글꼴 속성
- 둥근 테두리
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Java를 통해 Python용 Aspose.Slides에서 차트 서식 지정 방법을 배우고, 사용자 정의 축, 글꼴, 숫자 형식 및 둥근 차트 테두리를 사용하여 PowerPoint 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 차트를 서식 지정하는 방법을 설명합니다. 축, 격자선, 제목, 범례, 플롯 영역 및 벽 채우기와 같은 핵심 차트 요소를 사용자 지정하여 차트 데이터의 외관과 가독성을 향상시키는 방법을 보여줍니다.

또한 차트 텍스트에 대한 글꼴 속성을 설정하고, 차트 데이터에 사전 정의된 숫자 형식을 적용하며, 차트 영역에 둥근 모서리를 적용하는 방법을 설명합니다. 이러한 예제를 통해 프레젠테이션 차트의 시각적 스타일과 데이터 표시를 모두 제어할 수 있습니다.

상승 및 하강 구간에 대한 별도 채우기와 외곽선에 대해서는 [주식 차트 예제](/slides/ko/python-java/create-chart/#create-stock-charts)를 참조하십시오.

## **차트 엔터티 서식 지정**

[Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/)을 사용하여 차트 제목, 축, 격자선, 범례 및 플롯 영역을 서식 지정합니다. 이 예제는 마커와 기본 데이터를 사용하여 꺾은선형 차트를 만든 다음 값 축과 범주 축에 개별 텍스트 및 선 스타일을 적용합니다. 글꼴 크기와 선 두께는 포인트 단위로 지정되며, 범주 레이블은 45도 회전됩니다.

값 축은 소스 셀과 독립적으로 [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat)을 사용합니다. 축 범위는 -2에서 15까지이며 주요 간격은 2, 보조 간격은 0.5입니다. 이 예제는 백분율 서식을 [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit)과 결합하여 천 단위로 표시하도록 설정하므로 데이터의 의미와 크기에 맞게 이러한 설정을 조정하십시오. 범례는 [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay)이 `False`로 호출되었기 때문에 플롯 영역 외부에 배치됩니다. 뒤쪽 벽과 바닥 채우기는 [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) 및 [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor)를 통해 구성되지만, 이러한 표면은 3D 차트에서만 표시됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트에 대한 글꼴 속성 설정**

[Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat)을 통해 차트 텍스트의 기본 글꼴 크기를 설정합니다. 이 예제는 20포인트 글꼴을 사용한 클러스터형 열 차트를 만들고, 첫 번째 시리즈에 대해 [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue)를 호출하여 값 레이블을 활성화합니다. 자체 명시적 글꼴 설정이 있는 텍스트 요소는 차트 기본값을 재정의할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트 범례에 대한 텍스트 프레임 서식 재사용**

범례를 슬라이드 머리글에 맞추려면 첫 번째 단락에서 [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)을 통해 머리글의 글꼴을 설정합니다. 범례의 [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat)에서 반환된 서식에 대해 [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom)를 호출합니다. 이렇게 하면 텍스트 프레임 설정, 첫 번째 단락의 서식 및 해당 단락의 기본 글꼴 속성이 복사됩니다. 개별 부분이나 이후 단락에 직접 적용된 서식은 원본에만 적용됩니다.

예제에서는 네이비 색상의 26포인트 Calibri 굵은 머리글을 템플릿으로 사용합니다. 범례 스타일을 적용한 후에는 [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo)를 호출하여 동일한 서식을 별도 캡션에 적용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LegendPositionType, NullableBool, Presentation, SaveFormat, ShapeType, StyleType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, False)
    source_text_frame = heading.addTextFrame("Quarterly sales")
    paragraph = source_text_frame.getParagraphs().get_Item(0)
    font = paragraph.getParagraphFormat().getDefaultPortionFormat()
    font.setLatinFont(FontData("Calibri"))
    font.setFontHeight(26)
    font.setFontBold(NullableBool.True_)
    font.getFillFormat().setFillType(FillType.Solid)
    font.getFillFormat().getSolidFillColor().setColor(Color(32, 64, 96))

    chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360)
    chart.setStyle(StyleType.Style3)
    workbook = chart.getChartData().getChartDataWorkbook()
    for column, series_name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.getCell(0, 0, column).setValue(series_name)
    for quarter in range(1, 5):
        workbook.getCell(0, quarter, 0).setValue(f"Q{quarter}")

    chart.setLegend(True)
    legend = chart.getLegend()
    legend.setPosition(LegendPositionType.Bottom)
    legend_format = legend.getTextFormat()
    legend_format.copyFrom(source_text_frame)

    caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, False)
    caption_text_frame = caption.addTextFrame("Sales in millions of dollars")
    legend_format.copyTo(caption_text_frame)

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

저장된 프레젠테이션에서 범례와 캡션은 크기, 굵기 및 색상이 머리글과 일치합니다. 범례는 여전히 시리즈 이름을 표시하고, 캡션은 자체 텍스트를 유지합니다. 캡션의 어떤 부분에 이미 명시적 글꼴 크기가 지정되어 있으면 해당 크기가 복사된 단락 기본값보다 우선합니다.

| 복사 전 | 복사 후 |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **숫자 형식 설정**

[ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat)을 사용하여 차트 워크북 셀에 내장된 숫자 형식을 적용합니다. 이 예제는 기본 셀 기반 데이터가 있는 클러스터형 열 차트를 만들고 각 시리즈 값 셀에 형식 인덱스 10(`0.00%`)을 적용합니다. 이렇게 하면 기본 숫자는 변경되지 않고도 워크북에서 값이 25.00%와 같이 표시됩니다. 축 및 데이터 레이블 형식은 별도로 구성할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

다음 표는 미국(English (United States)) 로케일에 대한 대표적인 Excel 형식과 함께 내장 숫자 형식 인덱스를 나열합니다. 정확한 형식 문자열과 표시 방식은 응용 프로그램 및 로케일에 따라 다를 수 있으며, 특히 통화와 날짜 형식에서 차이가 있습니다. 일부 Excel 형식은 [Microsoft의 숫자 형식 구현 노트](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)에서 설명한 OOXML 표준 기본값과도 다를 수 있습니다.

| 인덱스 | 형식 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **차트 영역 둥근 테두리 설정**

[Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners)에 `True`를 전달하여 차트 영역의 모서리를 둥글게 만듭니다. 이 예제는 클러스터형 열 차트를 만든 다음 [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat)을 사용해 외곽선에 단색 회색과 단일 선 스타일을 지정하고 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **기존 차트 주석 편집**

차트에는 보고서 상태를 설명하는 텍스트 주석과 같은 사용자 정의 모양이 포함될 수 있습니다. 이러한 모양은 [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes)를 통해 액세스합니다. [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes)에서 반환된 컬렉션에는 차트에 소유된 모양이 들어 있습니다.

차트 위에 배치된 일반 텍스트 상자는 차트의 일부처럼 보이더라도 슬라이드에 속합니다. [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes)를 반복하면 차트와 일반 슬라이드 모양을 찾을 수 있지만 차트 내부의 개별 모양은 열거되지 않습니다. 차트 제목과 데이터 레이블은 별도의 차트 요소이며, 이 컬렉션에 포함된 사용자 정의 주석이 아닙니다.

[chart-annotations.pptx](chart-annotations.pptx)를 다운로드하여 애플리케이션 작업 디렉터리에 배치합니다. 첫 번째 슬라이드에는 "Preliminary results"라는 주석, 차트가 소유한 선, 그리고 "Slide overlay"라는 일반 슬라이드 텍스트 상자가 포함된 차트가 있습니다. 예제는 해당 슬라이드의 첫 번째 차트를 찾아 보고서가 발표 준비가 되면 주석을 "Final results"로 변경합니다. 빈 컬렉션을 확인하고, [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)에서 `None`이 아닌 텍스트 프레임을 반환하는 경우에만 [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame)과 예상 텍스트를 검증합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

선과 슬라이드 텍스트 상자는 변경되지 않은 상태로 남습니다. 아래 이미지는 입력 파일과 저장 후 다시 연 결과를 보여줍니다.

| 편집 전 | 편집 후 |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
예제는 최상위 차트 소유 모양만 검사합니다. 주석이 [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) 내부에 있는 경우 해당 그룹의 [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) 컬렉션도 검사해야 합니다. 중첩된 그룹에 대해 동일한 텍스트 검사를 재귀적으로 수행하십시오. 그룹 자체는 컨테이너이며 텍스트 상자로 취급하지 마십시오.
{{% /alert %}}

## **FAQ**

**열/영역에 반투명 채우기를 적용하면서 테두리를 불투명하게 유지할 수 있나요?**

예, 채우기 투명도와 외곽선은 별도로 구성됩니다. 이는 격자와 데이터가 복잡한 시각화에서 가독성을 높이는 데 유용합니다.

**데이터 레이블이 겹칠 때 어떻게 처리할 수 있나요?**

글꼴 크기를 줄이거나, 필요하지 않은 레이블 요소(예: 범주)를 비활성화하고, 레이블 위치를 조정하거나, 필요한 경우 선택된 포인트에만 레이블을 표시하거나, 형식을 "값 + 범례"로 전환하십시오.

**시리즈에 그라디언트 또는 패턴 채우기를 적용할 수 있나요?**

예, 시리즈는 단색, 그라디언트 및 패턴 채우기를 지원합니다. 실제로는 그라디언트를 최소한으로 사용하고, 격자와 텍스트 대비를 떨어뜨리는 조합은 피하는 것이 좋습니다.