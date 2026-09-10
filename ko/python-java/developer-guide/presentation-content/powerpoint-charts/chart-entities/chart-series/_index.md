---
title: Python 프레젠테이션에서 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/python-java/chart-series/
keywords:
- 차트 시리즈
- 시리즈 겹침
- 시리즈 색상
- 시리즈 이름
- 데이터 포인트
- 워크북 셀
- 시리즈 간격
- 음수 값
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 너비 및 음수 값을 관리하는 방법을 배웁니다."
---
## **개요**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [ChartSeries](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/)는 관련 값 하나의 집합을 나타내며, 시리즈의 각 [ChartDataPoint](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/)은 하나 이상의 워크북 셀을 참조합니다. [ChartCategory](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트만으로 저장되는 것이 아니라 [ChartDataCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatacell/) 객체와 연결됩니다.

일반적인 카테고리 차트에서는 기본 워크북이 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고 나머지 셀을 시리즈 값에 사용합니다. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/#getCell) 에 전달되는 워크시트, 행, 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터로 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정하지 마세요. 로드된 프레젠테이션의 경우, 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하십시오.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정은 [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getFormat) 와 같이 한 시리즈의 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정은 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getFormat) 와 같이 한 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 때는 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 를 통해 그룹에 접근하십시오.

명시적인 포인트 혹은 시리즈 채우기(fill)가 설정되지 않은 경우, 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 포맷이 모두 존재하면 포인트 포맷이 해당 포인트에 대해 우선합니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getOverlap) 은 2D 차트에서 막대나 열이 겹치는 정도를 -100%부터 100%까지 보고합니다. 이는 상위 시리즈 그룹에 대한 설정의 읽기 전용 투영입니다. 해당 그룹의 모든 호환 시리즈를 업데이트하려면 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setOverlap) 을 사용하십시오. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에만 적용되며, 복합 차트의 무관한 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # 새 차트에는 샘플 시리즈, 카테고리 및 값이 포함됩니다.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![The series overlap](series_overlap.png)

## **시리즈 채우기 색상 변경**

전체 시리즈에 대한 기본 채우기를 설정하려면 [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getFormat) 을 사용합니다. 포인트에 명시적인 채우기가 이미 있는 경우 해당 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getFormat) 설정이 그 포인트에 대한 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![The color of the series](series_color.png)

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 열 차트를 위한 기본 워크북에서 셀 B1은 행 0, 열 1에 해당하며 첫 번째 시리즈의 이름을 포함합니다. 다음 예제의 명명된 변수들은 그 구조를 명시적으로 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

또한 [ChartSeries.getName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getName) 이 이미 참조하는 셀을 업데이트할 수 있습니다. 이 접근 방식은 기존 차트에서 특정 행과 열을 가정하는 것을 피합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![The series name](series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 은 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상을 읽을 뿐, 새로운 채우기를 할당하지는 않습니다.

다음 예제는 각 기본 시리즈의 자동 색상을 출력합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

기본 차트 스타일에 대한 예시 출력:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

정확한 색상은 차트 스타일 및 테마에 따라 달라집니다.

## **차트 시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#setInvertIfNegative) 를 사용하여 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤, [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 음수 값 색상을 지정하십시오. 워크북의 음수 숫자는 변하지 않으며, 표시 색상만 변경됩니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0은 시리즈 이름, 열 0은 카테고리 이름, 열 1은 값을 포함합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![The inverted solid fill color](inverted_solid_fill_color.png)

한 포인트에 대해서만 반전을 적용하려면 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 를 사용하십시오. 아래 예제에서는 시리즈에 대한 반전을 비활성화하고 선택된 포인트에만 활성화합니다. 해당 포인트에는 효과가 보이도록 음수 값도 할당합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **특정 데이터 포인트 값 삭제**

한 포인트만 비우고 다른 포인트는 유지하려면 해당 백업 워크북 셀을 `None` 로 설정하십시오. 열 차트의 경우 플롯된 값은 [ChartDataPoint.getValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getValue) 로 확인할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만 차트는 해당 값을 빈값으로 처리합니다(차트의 빈값 설정에 따름).

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 삭제합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

산점도 차트는 X와 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 사용합니다. 삭제하려는 값에 해당하는 셀만 비우십시오. 다른 포인트를 유지하려면 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapointcollection/#clear) 를 호출하지 마십시오. 이 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **시리즈 간격 너비 설정**

간격 너비(gap width)는 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 백분율로 나타낸 것입니다. 겹침과 마찬가지로 이는 개별 시리즈가 아니라 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 을 호출하십시오. 값이 크면 클러스터 사이에 더 많은 공간이 생기고, 값이 작으면 클러스터가 더 촘촘해집니다.

다음 예제는 간격 너비를 변경하고 최종 프레젠테이션만 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![The gap width](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원하나요?**

[ChartType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/) 열거형에 정의된 모든 차트 유형이 차트 데이터를 사용하지만, 시리즈마다 값 구조나 설정이 동일하지는 않습니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기도 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하십시오. 겹침(overlap) 및 간격(gap width) 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇인가요?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/) 은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 하나 이상의 그룹을 가질 수 있으므로, 한 시리즈를 통해 접근한 그룹을 변경한다고 해서 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되어 있나요?**

예. 기본적으로 [ShapeCollection.addChart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addChart) 은 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 완전히 사용자 정의된 데이터 세트를 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 지울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체가 워크북 셀과 어떻게 연결되나요?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/) 의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 구축할 때는 카테고리 행과 시리즈-값 행이 정렬되어 각 포인트가 의도한 카테고리 아래에 플롯되도록 하세요.

**전체 시리즈가 아니라 한 포인트만 삭제하려면 어떻게 하나요?**

해당 값 셀을 `None` 로 설정하면 포인트의 카테고리 위치는 유지되면서 빈 포인트가 됩니다. 전체 포인트를 삭제하려는 경우에만 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapointcollection/#clear) 를 사용하십시오. 카테고리 자체를 삭제하는 경우 모든 시리즈를 업데이트하여 값이 카테고리 컬렉션과 정렬되도록 해야 합니다.

**빈 포인트는 어떻게 표시되나요?**

결과는 차트 유형 및 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setDisplayBlanksAs) 에 설정된 값에 따라 달라집니다. 지원되는 차트에서는 빈값을 간격, 0값, 또는 인접 포인트 연결 방식으로 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하십시오.

**음수 값은 어떻게 서식이 적용되나요?**

지원되는 막대, 열 및 버블 시리즈의 경우 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#setInvertIfNegative) 를 호출하고 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 반환되는 색상을 지정하십시오. 개별 포인트에 대해서는 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 로 동작을 재정의할 수 있습니다. 이러한 메서드는 서식에만 영향을 미치며 저장된 숫자 값은 변경되지 않습니다.

**시리즈와 포인트 모두 서식이 지정된 경우 어느 것이 우선인가요?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식이나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침(overlap) 및 간격(gap width) 같은 그룹 설정은 레이아웃을 제어하며 포인트 수준 서식 재정의가 아닙니다.

**차트에 포함될 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides 에는 별도의 고정 시리즈 수 제한이 없습니다. 실제 제한은 프레젠테이션 파일 크기, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성 등에 따라 결정됩니다.

**열이 너무 가깝거나 떨어져 있으면 무엇을 바꿔야 하나요?**

적절한 상위 시리즈 그룹에 대해 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 를 호출하십시오. 값을 높이면 클러스터 사이 간격이 넓어지고, 값을 낮추면 클러스터가 더 가까워집니다.