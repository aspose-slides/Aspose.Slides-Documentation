---
title: Python을 사용한 프레젠테이션에서 차트 축 사용자 지정
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
description: 보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Java를 통해 Python용 Aspose.Slides를 사용하는 방법을 알아보세요.
---
## **개요**

이 문서는 Aspose.Slides에서 차트 축을 사용자 지정하는 방법을 설명합니다. 실제 축 값 가져오기, 축 간 데이터 교환, 선 차트에서 수직 또는 수평 축 숨기기, 범주 축 유형 변경, 범주 축 값에 대한 날짜 형식 설정, 축 제목 회전, 축 위치 설정 및 값 축의 표시 단위 설정 방법을 보여줍니다.

## **차트 수직 축의 최대값 가져오기**

Aspose.Slides for Python via Java을 사용하면 수직 축의 최소값 및 최대값을 얻을 수 있습니다. 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 액세스합니다.
3. 기본 데이터로 차트를 추가합니다.
4. 축의 실제 최대값을 가져옵니다.
5. 축의 실제 최소값을 가져옵니다.
6. 축의 실제 주요 단위를 가져옵니다.
7. 축의 실제 보조 단위를 가져옵니다.
8. 축의 실제 주요 단위 스케일을 가져옵니다.
9. 축의 실제 보조 단위 스케일을 가져옵니다.

위 단계들을 구현한 샘플 코드로, Python에서 필요한 값을 가져오는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # 프레젠테이션을 저장합니다
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **축 간 데이터 교환**

Aspose.Slides를 사용하면 축 간 데이터를 신속하게 교환할 수 있습니다—수직 축(y축)에 표시된 데이터가 수평 축(x축)으로 이동하고 그 반대도 마찬가지입니다.

다음 Python 코드가 차트에서 축 간 데이터 교환 작업을 수행하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # 차트의 기본 데이터를 워크북에 로드합니다 — switchRowColumn가 워크북을 전치시키므로,
    # 먼저 채워야 합니다
    workbook = chart.getChartData().getChartDataWorkbook()

    # 행과 열을 전환합니다
    chart.getChartData().switchRowColumn()

    # 프레젠테이션을 저장합니다
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **선 차트에서 수직 축 비활성화**

다음 Python 코드는 선 차트의 수직 축을 숨기는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **선 차트에서 수평 축 비활성화**

다음 코드는 선 차트의 수평 축을 숨기는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **범주 축 변경**

[setCategoryAxisType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/#setCategoryAxisType) 메서드를 사용하여 원하는 범주 축 유형(**date** 또는 **text**)을 지정할 수 있습니다. 다음 Python 코드는 해당 작업을 시연합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **범주 축 값에 대한 날짜 형식 설정**

Aspose.Slides for Python via Java를 사용하면 범주 축 값에 대한 날짜 형식을 설정할 수 있습니다. 다음 Python 코드에서 해당 작업을 시연합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트 축 제목 회전 각도 설정**

Aspose.Slides for Python via Java를 사용하면 차트 축 제목의 회전 각도를 설정할 수 있습니다. 다음 Python 코드가 해당 작업을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **범주 축 또는 값 축에서 축 위치 설정**

Aspose.Slides for Python via Java를 사용하면 범주 축 또는 값 축에서 축 위치를 설정할 수 있습니다. 다음 Python 코드가 작업 수행 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트 값 축에 표시 단위 설정**

Aspose.Slides for Python via Java를 사용하면 차트 값 축의 표시 단위를 설정할 수 있습니다. 축은 해당 단위에 따라 눈금 레이블을 스케일링합니다: [DisplayUnitType.Millions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/displayunittype/#Millions)를 사용하면 60,000,000까지 표시되는 축이 0~60으로 표시됩니다. 다음 Python 코드가 해당 작업을 시연합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**축이 서로 교차하는 값(축 교차점)을 어떻게 설정합니까?**

축은 [crossing setting](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/#setCrossType)을 제공합니다: 0, 최대 범주/값, 또는 특정 수치값에서 교차하도록 선택할 수 있습니다. 이는 X축을 위아래로 이동하거나 기준선을 강조할 때 유용합니다.

**눈금 표시를 축에 상대적으로(교차, 외부, 내부) 어떻게 배치합니까?**

[tick mark position](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/#setMajorTickMark)을 "cross", "outside" 또는 "inside"로 설정합니다. 이는 가독성에 영향을 주며, 특히 작은 차트에서 공간을 절약하는 데 도움이 됩니다.