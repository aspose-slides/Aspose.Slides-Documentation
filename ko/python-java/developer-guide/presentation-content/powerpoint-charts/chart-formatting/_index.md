---
title: Python에서 프레젠테이션 차트 형식 지정
linktitle: 차트 형식 지정
type: docs
weight: 60
url: /ko/python-java/chart-formatting/
keywords:
- 차트 형식 지정
- 차트 형식 지정
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
description: "Aspose.Slides for Python via Java에서 차트 형식 지정을 배우고, 전문가 수준의 눈에 띄는 스타일링으로 PowerPoint 프레젠테이션을 향상시켜 보세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션의 차트를 형식화하는 방법을 설명합니다. 축, 눈금선, 제목, 범례, 플롯 영역 및 배경 채우기와 같은 주요 차트 요소를 사용자 지정하여 차트 데이터의 모양과 가독성을 향상시키는 방법을 보여줍니다.

또한 차트 텍스트의 글꼴 속성을 설정하고, 차트 데이터에 사전 정의 및 사용자 지정 숫자 형식을 적용하며, 차트 영역에 둥근 모서리를 활성화하는 방법을 시연합니다. 이러한 예제를 통해 프레젠테이션에서 차트의 시각적 스타일과 데이터 표시를 모두 제어하는 방법을 알 수 있습니다.

## **차트 엔터티 형식 지정**
Aspose.Slides for Python via Java를 사용하면 개발자가 처음부터 슬라이드에 사용자 정의 차트를 추가할 수 있습니다. 이 문서에서는 범주 축과 값 축을 포함한 다양한 차트 엔터티를 형식화하는 방법을 설명합니다.

Aspose.Slides for Python via Java는 다양한 차트 엔터티를 관리하고 사용자 지정 값을 사용하여 형식화할 수 있는 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 액세스합니다.
1. 기본 데이터가 포함된 원하는 유형의 차트를 추가합니다(이 예제는 [ChartType.LineWithMarkers](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/#LineWithMarkers)를 사용합니다).
1. 차트 값 축에 액세스하고 다음 속성을 설정합니다:
   1. 값 축 주요 눈금선에 대해 **Line format**을 설정합니다.
   1. 값 축 보조 눈금선에 대해 **Line format**을 설정합니다.
   1. 값 축에 대해 **Number Format**을 설정합니다.
   1. 값 축에 대해 **minimum, maximum, major, and minor units**를 설정합니다.
   1. 값 축 데이터에 대해 **Text Properties**를 설정합니다.
   1. 값 축에 **Title**을 설정합니다.
1. 차트 범주 축에 액세스하고 다음 속성을 설정합니다:
   1. 범주 축 주요 눈금선에 대해 **Line format**을 설정합니다.
   1. 범주 축 보조 눈금선에 대해 **Line format**을 설정합니다.
   1. 범주 축 데이터에 대해 **Text Properties**를 설정합니다.
   1. 범주 축에 **Title**을 설정합니다.
   1. 범주 축에 대해 **Label Positioning**을 설정합니다.
   1. 범주 축 레이블에 대해 **Rotation Angle**을 설정합니다.
1. 차트 범례에 액세스하고 해당 **text properties**를 설정합니다.
1. 차트와 겹치지 않도록 차트 범례를 표시합니다.
1. 차트 **secondary value axis**에 액세스하고 다음 속성을 설정합니다:
   1. 보조 **value axis**를 활성화합니다.
   1. 보조 값 축에 대해 **Line Format**을 설정합니다.
   1. 보조 값 축에 대해 **Number Format**을 설정합니다.
   1. 보조 값 축에 대해 **minimum, maximum, major, and minor units**를 설정합니다.
1. 첫 번째 차트 시리즈를 보조 값 축에 플롯합니다.
1. 차트 뒤쪽 벽 채우기 색상을 설정합니다.
1. 차트 플롯 영역 채우기 색상을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Presentation 클래스의 인스턴스를 생성합니다
presentation = Presentation()
try:
    # 첫 번째 슬라이드에 액세스합니다
    slide = presentation.getSlides().get_Item(0)

    # 샘플 차트를 추가합니다
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # 차트 제목을 설정합니다
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # 값 축의 주요 눈금선 형식을 설정합니다
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # 값 축의 보조 눈금선 형식을 설정합니다
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # 값 축의 숫자 형식을 설정합니다
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # 차트의 최대값 및 최소값을 설정합니다
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # 값 축 텍스트 속성을 설정합니다
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # 값 축 제목을 설정합니다
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # 범주 축의 주요 눈금선 형식을 설정합니다
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # 범주 축의 보조 눈금선 형식을 설정합니다
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # 범주 축 텍스트 속성을 설정합니다
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # 범주 축 제목을 설정합니다
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # 범주 축 레이블 위치를 설정합니다
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # 범주 축 레이블 회전 각도를 설정합니다
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # 범례 텍스트 속성을 설정합니다
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # 차트와 겹치지 않게 차트 범례를 표시합니다

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # 보조 값 축을 설정합니다
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # 보조 값 축의 숫자 형식을 설정합니다
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # 차트의 최대값 및 최소값을 설정합니다
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # 차트 뒤쪽 벽 색상을 설정합니다
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # 플롯 영역 색상을 설정합니다
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # 프레젠테이션을 저장합니다
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트에 대한 글꼴 속성 설정**
Aspose.Slides for Python via Java는 차트에 대한 글꼴 속성 설정을 지원합니다. 다음 단계에 따라 글꼴 속성을 설정하세요:

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
- 슬라이드에 차트를 추가합니다.
- 글꼴 높이를 설정합니다.
- 수정된 프레젠테이션을 저장합니다.

다음 예제는 이러한 단계를 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation 클래스의 인스턴스를 생성합니다
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **숫자 형식 설정**
Aspose.Slides for Python via Java는 차트 데이터 형식을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 액세스합니다.
1. 기본 데이터가 포함된 원하는 유형의 차트를 추가합니다(이 예제는 [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/#ClusteredColumn)를 사용합니다).
1. 가능한 사전 정의 값 중에서 사전 정의 숫자 형식을 설정합니다.
1. 각 차트 시리즈의 데이터 셀을 순회하며 숫자 형식을 설정합니다.
1. 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation 클래스의 인스턴스를 생성합니다
presentation = Presentation()
try:
    # 첫 번째 프레젠테이션 슬라이드에 액세스합니다
    slide = presentation.getSlides().get_Item(0)

    # 기본 클러스터드 컬럼 차트를 추가합니다
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # 차트 시리즈 컬렉션에 액세스합니다
    chart_series_collection = chart.getChartData().getSeries()

    # 모든 차트 시리즈를 순회합니다
    for chart_series in chart_series_collection:
        # 시리즈의 모든 데이터 포인트를 순회합니다
        for data_point in chart_series.getDataPoints():
            # 숫자 형식을 설정합니다
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # 프레젠테이션을 저장합니다
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

사용 가능한 사전 정의 숫자 형식 및 해당 인덱스는 아래에 나열됩니다:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **차트 영역 둥근 테두리 설정**
Aspose.Slides for Python via Java는 [Chart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/) 클래스의 [hasRoundedCorners](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#hasRoundedCorners) 및 [setRoundedCorners](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setRoundedCorners) 메서드를 통해 차트 영역에 둥근 모서리를 지원합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트 테두리 선의 채우기 유형 및 스타일을 설정합니다.
1. 둥근 모서리를 활성화합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 예제는 이러한 단계를 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Presentation 클래스의 인스턴스를 생성합니다
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**열/영역에 반투명 채우기를 적용하면서 테두리는 불투명하게 유지할 수 있나요?**

예. 채우기 투명도와 테두리는 별도로 구성됩니다. 이는 복잡한 시각화에서 격자와 데이터의 가독성을 향상시키는 데 유용합니다.

**데이터 레이블이 겹칠 때 어떻게 처리할 수 있나요?**

글꼴 크기를 줄이거나, 불필요한 레이블 구성 요소(예: 범주)를 비활성화하고, 레이블 오프셋/위치를 설정하며, 필요에 따라 선택된 포인트에만 레이블을 표시하거나, 형식을 "값 + 범례"로 전환하세요.

**시리즈에 그라디언트 또는 패턴 채우기를 적용할 수 있나요?**

예. 일반적으로 단색 및 그라디언트/패턴 채우기를 모두 사용할 수 있습니다. 실제로는 그라디언트를 적게 사용하고 격자와 텍스트와의 대비를 감소시키는 조합은 피하세요.