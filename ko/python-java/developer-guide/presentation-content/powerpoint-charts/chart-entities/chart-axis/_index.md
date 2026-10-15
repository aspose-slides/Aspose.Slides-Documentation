---
title: Python을 사용하여 프레젠테이션에서 차트 축 맞춤 설정
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
- 축 선
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션의 차트 축을 맞춤 설정하고 보고서와 시각화를 만들는 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides for Python via Java를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주와 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트 수직 축에서 최대값 가져오기**

기본 데이터가 있는 영역 차트를 추가하고 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)을 생성합니다. 차트 레이아웃을 최신 상태로 유지하려면 계산된 축 값을 읽기 전에 [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout)을 호출합니다.

축 제한을 위해 [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue)와 [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue)를 읽고, 눈금 간격은 [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit)와 [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit)을 사용합니다. 날짜 축에 관련된 시간 단위 스케일은 [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale)와 [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale)에서 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

차트 데이터에서 시리즈와 범주의 역할을 바꾸려면 [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn)을 사용합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터 그룹화를 변경하지만 가로 및 세로 축을 교환하지는 않습니다. 예제에서는 [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange)를 사용해 기본 데이터를 `Sheet1!A1:D5`(헤더 행 및 범주 열 포함)에 바인딩한 다음 행과 열을 전환합니다. 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

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

## **축의 플롯 순서 반전**

카테고리 축 또는 값 축을 반전하려면 [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed)을 사용합니다. 예를 들어 수평 막대 차트는 워크시트와 동일한 순서(계획, 개발, 테스트)로 상단에서 하단으로 프로젝트 단계가 표시될 수 있습니다. 축을 반전하면 플롯 방향이 바뀔 뿐, 워크북 데이터가 정렬되거나 재배열되지 않습니다. 비교를 위해 [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn)은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈가 있는 수평 막대 차트를 만들고, 세 개의 슬라이드를 저장합니다: 정상 순서, 범주 반전, 값 반전. 각 복사본은 동일한 데이터 집합을 사용하고, 각 복사본마다 하나의 축만 반전됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # 슬라이드 2: 첫 번째 범주를 위에 표시합니다.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # 수평 값 축을 아래에 유지합니다.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # 슬라이드 3: 수평 숫자 스케일만 반전합니다.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

축을 반전하면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType)은 구성 중인 축과 교차하는 다른 축의 위치를 제어합니다. 슬라이드 2에서는 반전된 범주 축에 대해 [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum)으로 호출하여 수평 값 축을 하단에 유지합니다. 특정 교차점을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt)를 사용합니다. 방향을 변경할 때는 교차 설정을 확인하십시오, 특히 차트에 사용자 정의 교차점이 이미 있는 경우에 그렇습니다. `False`와 함께 [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed)를 호출하면 정상 플롯 방향으로 복원됩니다; 교차 설정은 별도로 유지됩니다.

| 정상 순서 (슬라이드 1) | 반전된 범주 (슬라이드 2) | 반전된 값 (슬라이드 3) |
| --- | --- | --- |
| ![범주와 값 축 순서가 정상인 수평 막대 차트](axis-order-normal.png) | ![범주가 위에서 아래로 표시되는 수평 막대 차트](axis-order-categories-reversed.png) | ![값 축이 반전되고 오른쪽에 0이 표시되는 수평 막대 차트](axis-order-values-reversed.png) |
| 범주는 아래에서 위로, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행됩니다. 값과 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽 0에서 교차합니다. |

## **라인 차트에서 수직 축 비활성화**

수직 축에 대해 `False`와 함께 [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible)를 호출하여 숨깁니다. 예제는 기본 데이터가 있는 라인 차트를 만들고 수직 축을 숨긴 채 저장합니다.

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

## **라인 차트에서 수평 축 비활성화**

수평 축에 대해 `False`와 함께 [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible)를 호출하여 숨깁니다. 예제는 기본 데이터가 있는 라인 차트를 만들고 수평 축을 숨긴 채 저장합니다.

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

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType)을 사용하여 날짜 축 또는 텍스트 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `ExistingChart.pptx`를 필요로 하며, 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 가로 축을 날짜 축으로 변경합니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit)와 `False`를, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit)와 `1`을, 그리고 [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale)와 [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months)를 사용하면 주요 눈금이 1개월 간격으로 배치됩니다.

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

차트에 범주가 많이 있을 때 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄입니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing)과 `False`를 호출한 뒤, 원하는 범주 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing)에 전달합니다. 텍스트 범주의 정상 순서에서는 첫 번째 범주부터 번호가 매겨집니다.

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

간격이 `3`이면 3번째 레이블마다 하나씩 표시되고, 표시된 레이블 사이에 두 개의 레이블이 숨겨집니다. 해당 열은 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금선도 별도의 제어가 가능합니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing)과 `False`를 호출하고 [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing)으로 간격을 설정합니다. 예를 들어 `1`은 각 범주 간격마다 눈금선을 유지하면서 레이블은 3번째 범주마다만 표시됩니다. 눈에 보이도록 [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark)를 사용하십시오. 자동 간격 설정자를 다시 `True`로 호출하면 차트가 자동 간격을 다시 선택합니다.

아래 자체 포함 예제는 24개의 범주와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 독립 눈금선이 있는 수동 레이블 간격, 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션은 필요하지 않으며, 수평 레이블 텍스트가 밀도 차이를 쉽게 확인하게 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpace.startJVM()

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

    # 슬라이드 2: 세 번째 레이블마다 표시하되, 각 범주마다 눈금선을 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 레이블이 표시되고 두 줄로 줄 바꿈됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![모든 24 열이 보이는 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블만 한 줄에 표시되고, 눈금선은 모든 범주 간격에 그대로 유지됩니다. 레이블이 없는 24개의 열도 동일한 값으로 표시됩니다. 슬라이드 3은 위와 같은 자동 표시를 복원합니다.

![모든 24 열이 보이는 세 번째 레이블 수동 간격](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 열, 라인, 영역 또는 막대 차트의 범주 축)의 경우 이 범주 개수 간격을 사용하십시오. 열 차트에서는 가로 축이며, 수평 막대 차트에서는 범주 축이 세로이므로 [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis)에서 반환된 축에 적용합니다. 눈금선 간격은 값 축이 있는 차트에서도 적용됩니다.

값 축의 숫자 스케일을 설정하려면 범주 레이블 간격을 사용하지 마십시오. 값 축에서는 [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit)이 값 차이를 지정합니다(예: `10`이면 0, 10, 20…). 범주 레이블 간격 `3`은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도와 버블 차트는 텍스트 범주 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [Change a Category Axis](#change-a-category-axis)에서 설명한 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제에서는 기본 차트 데이터를 4개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호(1899년 12월 30일부터 일수)로 저장됩니다. [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType)과 [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date)를 사용하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource)를 `False`로, `yyyy`를 [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat)에 전달하면 셀 서식과 무관하게 범주 레이블에 4자리 연도가 표시됩니다.

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

## **차트 축 제목에 회전 각도 설정**

수직 축에 대해 `True`와 함께 [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle)를 호출하고 제목 텍스트를 지정한 뒤, 제목 텍스트 블록 서식에서 회전 각도를 설정합니다. 각도는 도 단위이며, 이 예제는 값 축 제목이 90도 회전된 열 차트를 저장합니다.

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
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **범주 또는 값 축에 대한 축 위치 설정**

[value axis가 범주 축 사이에 교차되는지 여부를 제어하려면 [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories)를 사용합니다]. 이 설정은 범주 축에 적용됩니다. 예제에서는 열 차트의 가로 범주 축에 `True`를 설정하고 결과를 저장합니다.

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

## **차트 값 축에 표시 단위 설정**

[value axis 레이블을 기본 데이터를 변경하지 않고 스케일링하려면 [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit)를 사용합니다]. [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000 값이 60으로 표시됩니다. 예제는 열 차트를 만들고 수직 축에 백만 표시 단위를 적용합니다.

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

양수 값이 여러 차수에 걸쳐 있을 때 로그값 축이 유용합니다. 예를 들어 서비스가 5기간 동안 10, 100, 1,000, 10,000, 100,000 요청을 받는 경우, 선형 스케일에서는 작은 값이 0에 가깝게 모여 보입니다. 로그 스케일은 같은 거리마다 같은 비율을 나타내어 상대 성장률을 비교하기 쉽게 합니다.

값 축에 `True`와 함께 [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic)를 호출하고, [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase)로 기준을 선택합니다. 이는 기존 값의 표시 방식을 변경하지만 데이터 자체를 바꾸거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 별도 기능입니다.

### **값 축 및 기준 선택**

라인 또는 열 차트의 경우 값 축은 [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis)에서 반환됩니다. 수평 막대 차트의 경우 [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis)에서 반환됩니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X값에는 수평 축, Y값에는 수직 축을, 또는 두 축 모두에 적용합니다. 범주 축에는 로그 스케일을 적용하지 마십시오.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지의 정수를 사용할 수 있으며, `2.5`와 같은 소수 기준도 지원합니다. 기준이 `10`이면 10, 100, 1,000, 10,000 등이 동일한 간격으로 표시됩니다.

### **선형과 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 5개의 요청 수를 가진 라인 차트를 만들고, 두 번째 슬라이드에서 해당 슬라이드를 복제한 뒤 기준 10 로그값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

**선형 스케일 (슬라이드 1):** 동일한 수직 거리는 요청 수의 동일한 차이를 나타냅니다. 가장 큰 값이 차트를 지배해 작은 값이 구분하기 어렵습니다.

![선형 값 축에서 다섯 개 요청 수를 표시한 라인 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리는 동일한 비율을 나타냅니다. 각 기간의 요청 수가 이전보다 10배이므로, 기준 10 로그 스케일에서는 점들이 직선으로 상승합니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![기준 10 로그값 축에서 동일한 다섯 개 요청 수를 표시한 차트](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 적용하기 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값을 제외하는 것이 분석에 적합하다면 그 이유를 설명하십시오. 작은 양수로 조용히 대체하면 데이터 의미가 바뀝니다. 로그 축에 수동으로 지정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**축이 다른 축과 교차하는 값을 어떻게 설정합니까(축 교차점)?**

[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType)을 사용해 교차 동작을 선택하고, 숫자 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt)를 사용합니다. 이 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 위치시킵니까?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/)의 `Low`, `High`, `NextTo`, `None`을 사용해 [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition)를 호출합니다. 눈금선 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) 또는 [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark)를 사용하십시오; 이는 레이블 위치와 별개입니다.