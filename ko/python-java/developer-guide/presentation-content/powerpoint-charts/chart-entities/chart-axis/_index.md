---
title: Python을 사용한 프레젠테이션의 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/python-java/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 사용자 지정
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
- 프레젠테이션
- Python
- Aspose.Slides
description: "보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Java를 통한 Python용 Aspose.Slides 사용 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides for Python via Java에서 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 교환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트 수직 축의 최대값 가져오기**

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)을 만들고 기본 데이터가 있는 영역 차트를 추가합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 유지하려면 [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout)을 호출합니다.

축 한계를 위해 [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) 및 [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue)을 읽고, 눈금 간격을 위해 [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) 및 [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit)을 읽습니다. 날짜 축과 관련된 시간 단위 스케일은 [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) 및 [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale)에서 제공합니다. 예제는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **축 간 데이터 교환**

차트 데이터에서 시리즈와 범주의 역할을 교환하려면 [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn)을 사용합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이 작업은 데이터 그룹화를 변경하며 수평 및 수직 축을 교환하지는 않습니다. 예제는 [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange)을 사용해 기본 데이터를 `Sheet1!A1:D5`(헤더 행과 범주 열 포함)에 바인딩한 뒤 행과 열을 교환합니다. 결과 차트는 4개의 시리즈와 3개의 범주를 가집니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **선 차트에서 수직 축 비활성화**

수직 축에 대해 `False`와 함께 [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible)를 호출하면 축이 숨겨집니다. 예제는 기본 데이터가 있는 선 차트를 만들고 수직 축을 숨긴 채 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **선 차트에서 수평 축 비활성화**

수평 축에 대해 `False`와 함께 [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible)를 호출하면 축이 숨겨집니다. 예제는 기본 데이터가 있는 선 차트를 만들고 수평 축을 숨긴 채 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **범주 축 변경**

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType)를 사용해 날짜 축 또는 텍스트 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `ExistingChart.pptx`를 필요로 하며, 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 수평 축을 날짜 축으로 변경합니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit)를 `False`로, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit)를 `1`로, 그리고 [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale)를 [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months)로 설정하면 주요 눈금이 한 달 간격으로 배치됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **범주 축 레이블 간격 제어**

차트에 범주가 많이 있을 때 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing)를 `False`로 호출한 뒤 원하는 범주 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing)에 전달합니다. 텍스트 범주의 정상 순서에서는 첫 번째 범주부터 번호 매김이 시작됩니다.

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | 범주 1, 범주 2, 범주 3, ... 범주 24 |
| `2` | 범주 1, 범주 3, 범주 5, ... 범주 23 |
| `3` | 범주 1, 범주 4, 범주 7, ... 범주 22 |

`3` 간격은 세 번째 레이블마다 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 이는 해당 열을 제거하지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 선택되며 반드시 모든 레이블을 표시하지는 않습니다.

눈금에도 별도의 제어가 있습니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing)를 `False`로 호출하고 [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing)으로 간격을 설정합니다. 예를 들어 `1`은 각 범주 간격마다 눈금을 유지하면서 레이블은 매 세 번째 범주에만 표시됩니다. [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark)를 가시적인 스타일로 설정해 결과를 확인합니다. 두 자동 간격 설정자를 다시 `True`로 호출하면 차트가 자동 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 범주와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx`에 세 슬라이드를 저장합니다: 자동 간격, 레이블 간격 수동 설정(독립 눈금 포함), 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션이 필요하지 않습니다. 수평 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # 슬라이드 2: 세 번째 레이블만 표시하되, 각 범주마다 눈금은 유지합니다.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # 슬라이드 3: 차트가 두 간격을 다시 선택하도록 합니다.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Automatic spacing (slide 1):** In this rendering, every second category label is displayed and wraps onto two lines. The automatic result can vary with chart size, fonts, and the renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manual spacing (slide 2):** Every third label is displayed on one line, while tick marks remain at every category interval. All 24 columns, including those without labels, remain visible with the same values. Slide 3 restores the automatic appearance shown above.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Correct Axis and Interval Selection**

텍스트 범주 축(예: 열, 선, 영역 또는 막대 차트의 범주 축)에서는 이 범주 개수 간격을 사용합니다. 열 차트에서는 수평 축이며, 가로 막대 차트에서는 범주 축이 수직이므로 [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis)에서 반환된 축에 이 설정을 적용합니다. 눈금 간격은 값을 축으로 갖는 차트의 시리즈 축에도 적용됩니다.

값 축의 숫자 스케일을 지정하려면 레이블 간격을 사용하지 마십시오. 값 축에서 [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit)은 값 차이를 지정합니다(예: `10`은 0, 10, 20 등). `3` 간격의 범주 레이블은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도와 버블 차트는 텍스트 범주 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [Change a Category Axis](#change-a-category-axis)에서 설명한 대로 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제는 기본 차트 데이터를 네 개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호(1899‑12‑30 이후 경과 일수) 형태로 저장됩니다. [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType)와 [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date)를 사용하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource)를 `False`로 설정한 뒤 `yyyy`를 [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat)에 전달하면 셀 서식과 무관하게 네 자리 연도가 범주 레이블에 표시됩니다.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트 축 제목 회전 각도 설정**

수직 축에 대해 `True`와 함께 [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle)를 호출하고 제목 텍스트를 제공한 뒤, 제목 텍스트 블록 서식에서 회전 각도를 지정합니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전시킨 열 차트를 저장합니다.

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **범주 또는 값 축의 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories)를 사용해 값 축이 범주 축을 범주 사이에 교차할지, 범주 눈금에 교차할지 제어합니다. 이 설정은 범주 축에만 적용됩니다. 예제는 열 차트의 수평 범주 축에 `True`를 설정하고 결과를 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **값 축의 표시 단위 설정**

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit)을 사용하면 기본 데이터를 변경하지 않고 값 축 레이블을 스케일링할 수 있습니다. [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000이 60으로 표시됩니다. 예제는 열 차트를 만든 뒤 수직 축에 백만 단위 표시를 적용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **로그값 축 구성**

양의 값이 여러 자릿수에 걸쳐 있는 경우 로그값 축이 유용합니다. 예를 들어 한 서비스가 다섯 기간 동안 10, 100, 1,000, 10,000, 100,000 요청을 받는 경우를 생각해 보세요. 선형 스케일에서는 작은 값들이 0 근처에 몰려 보입니다. 로그 스케일은 동일한 거리마다 동일한 비율을 나타내어 상대 성장률을 쉽게 비교할 수 있게 합니다.

값 축에 `True`와 함께 [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic)를 호출하고, [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase)으로 기반을 선택합니다. 이는 기존 값의 표시 방식을 바꾸지만 데이터 자체를 변경하거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춰 만든 별도 기능입니다.

### **값 축과 기반 선택**

선 또는 열 차트에서는 값 축이 [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis)에서 반환됩니다. 가로 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis)에서 반환됩니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X 값에는 수평 축, Y 값에는 수직 축을, 또는 둘 다 사용할 수 있습니다. 범주 축에는 로그 스케일을 적용하지 마십시오.

기본 로그 기반은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 사용 가능하며, `2.5`와 같은 소수 기반도 지원됩니다. 기반 `10`에서는 10, 100, 1,000, 10,000 등이 균등하게 배치됩니다.

### **선형 스케일과 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 요청 수 5개를 가진 선 차트를 만든 뒤, 해당 슬라이드를 복제하고 두 번째 슬라이드에 기반 10 로그값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # 첫 번째 슬라이드는 선형으로 유지하고 복사본의 값 축 스케일만 변경합니다.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Linear scale (slide 1):** Equal vertical distances represent equal differences in request counts. The largest value dominates the chart, making the smaller values difficult to distinguish.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logarithmic scale (slide 2):** Equal vertical distances represent equal ratios. Each period has ten times as many requests as the previous one, so the points form a straight rising line on the base-10 scale. The axis labels still show the original request counts.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Zero 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 활성화하기 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값을 제외하는 것이 분석에 적합하다면 그 이유를 설명해야 합니다. 데이터를 작은 양수로 대체하면 의미가 바뀌므로 조용히 바꾸지 마십시오. 로그 축에 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**한 축이 다른 축을 교차하는 위치(축 교차)를 어떻게 설정합니까?**

[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType)을 사용해 교차 동작을 선택하고, 숫자 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt)를 사용합니다. 이러한 설정으로 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 배치합니까?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) 중 `Low`, `High`, `NextTo`, `None`을 사용해 [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition)를 호출합니다. 눈금 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) 또는 [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark)를 사용합니다; 이는 레이블 위치와 별개입니다.