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
description: "Aspose.Slides for Python via Java를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식 지정, 겹침, 간격 너비 및 음수 값을 관리하는 방법을 배웁니다."
---
## **개요**

차트는 플롯된 값을 워크북 셀에 저장하거나 숫자 리터럴로 직접 저장할 수 있습니다. A [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) 은 관련된 값 집합 하나를 나타내며, 각 [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) 은 해당 시리즈의 포인트를 나타냅니다. [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 기본 데이터를 사용하여 만든 차트에서는 시리즈 이름, 카테고리 및 포인트 값이 차트 워크북의 [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) 객체를 사용합니다.

일반적인 카테고리 차트의 경우 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고, 나머지 셀을 시리즈 값에 사용합니다. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) 에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용하여 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정하지 마십시오. 로드된 프레젠테이션의 경우 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하십시오.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정은 [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) 와 같이 하나의 시리즈에 속한 모든 포인트의 기본 모양을 제공합니다.
- 데이터 포인트 설정은 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) 와 같이 하나의 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 경우 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 를 통해 그룹에 접근하십시오.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우 차트 스타일 및 테마가 자동 모양을 결정합니다. 시리즈와 포인트 서식이 모두 존재하면 해당 포인트에 대해 포인트 서식이 우선합니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

클러스터드 실린더 차트의 경우, [3D 시리즈 유형 또는 막대 모양 변경](/slides/ko/python-java/3d-chart/#change-the-3d-series-type-and-bar-shape) 이 첫 번째 시리즈에 어떤 영향을 미치는지 확인하십시오.

## **숫자 리터럴을 사용하여 시리즈 값 설정**

시리즈 값이 애플리케이션 데이터나 계산 결과에서 나오고 워크시트 셀 참조가 필요하지 않을 때 숫자 리터럴을 사용하십시오. 각 포인트의 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) 결과를 [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble) 로 할당하기 전에 [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) 와 [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) 를 호출하십시오.

컬렉션 설정은 해당 시리즈의 모든 포인트 값에 대한 소스 유형을 제어합니다. 각 포인트 값의 [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) 메서드는 선택된 유형을 보고합니다; 컬렉션 설정을 통해 변경하십시오. `Worksheet` 인 경우 [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) 을 사용하여 참조된 셀에 접근합니다. `DoubleLiterals` 인 경우 [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) 이나 `setAsLiteralDouble` 을 사용해 숫자를 직접 읽거나 씁니다.

다음 예제는 기본 시리즈와 카테고리를 갖는 열 차트를 만든 뒤, 첫 번째 시리즈의 기존 포인트에 10, 20 등 계산된 값을 할당합니다. 프레젠테이션을 저장하고 다시 열어 저장된 값을 출력합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

포인트 값 소스 유형은 차트의 내부 또는 외부 워크북 구성을 식별하는 [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) 와 별개입니다. 숫자 리터럴을 사용한다고 해서 삽입된 워크북이 자동으로 제거되는 것은 아닙니다. 이 예제에서는 워크북이 카테고리 레이블, 시리즈 이름 및 다른 시리즈에 대해 계속 사용됩니다. 워크북 관리에 대해서는 [Chart Workbook](/slides/ko/python-java/chart-workbook/) 를 참조하십시오.

산점도 및 버블 차트의 경우, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) 와 [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) 를 사용해 각각 [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) 와 [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) 의 소스를 선택하십시오. 버블 차트는 또한 [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) 를 사용해 [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) 의 소스를 선택합니다. 각 해당 소스를 `DoubleLiterals` 로 설정한 뒤 해당 값의 `setAsLiteralDouble` 메서드로 숫자를 할당하십시오.

## **차트 시리즈 겹침 설정**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) 은 2D 차트에서 막대나 열이 -100%부터 100%까지 겹치는 비율을 보고합니다. 이는 상위 시리즈 그룹에 설정된 값의 읽기 전용 투사입니다. 해당 그룹의 모든 호환 시리즈를 업데이트하려면 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) 를 사용하십시오. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에만 적용되며, 조합 차트의 다른 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다.

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

전체 시리즈에 대한 기본 채우기를 설정하려면 [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) 을 사용하십시오. 포인트에 명시적인 채우기가 이미 있는 경우 해당 포인트의 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다.

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpime.JClass("java.awt.Color")

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

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 열 차트용 기본 워크북에서는 셀 B1(행 0, 열 1)에 첫 번째 시리즈의 이름이 들어 있습니다. 다음 예제의 명명된 변수들은 해당 구조를 명시적으로 나타냅니다.

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

또한 [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) 이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하지 않으므로 안전합니다.

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

### **여러 셀에서 이름을 가져와 시리즈 만들기**

제품 이름과 보고 기간이 별도의 워크북 셀에 저장된 경우 복합 시리즈 이름이 유용합니다. 예를 들어 B1 셀의 `Product A` 와 C1 셀의 `2026` 을 하나의 시리즈 이름으로 결합하면서 두 부분이 각각의 원본 셀에 연결된 상태를 유지할 수 있습니다.

[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) 을 사용해 이름 범위를 가져온 다음 해당 컬렉션을 [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) 에 전달하십시오. `skipHiddenCells` 인자는 숨겨진 셀을 포함할지 여부를 제어합니다: `True` 는 제외하고, `False` 는 포함합니다. 이 예제에서는 `False` 를 사용해 이름 범위의 모든 셀을 포함합니다.

다음 예제는 하나의 시리즈와 두 개의 데이터 포인트를 가진 프레젠테이션을 만듭니다. 셀 B1:C1 은 시리즈 이름만 제공하고, A2:A3 은 카테고리 레이블을 제공하며, B2:B3 은 숫자 값을 제공합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # 이 두 셀은 시리즈 이름을 제공합니다.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # 별도의 셀은 카테고리와 숫자 데이터 포인트를 제공합니다.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과 시리즈 이름은 `Product A 2026` 으로, 두 셀 값 사이에 공백이 들어갑니다. 범례에 두 열에 대해 하나의 항목으로 표시됩니다. 아래 이미지가 결과를 보여줍니다.

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 은 시리즈 인덱스와 차트 스타일에서 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용하는 색상입니다. 메서드를 호출하면 계산된 색상을 읽을 수 있으며, 새로운 채우기를 할당하지는 않습니다.

다음 예제는 기본 시리즈 각각의 자동 색상을 출력합니다.

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

기본 차트 스타일에 대한 예제 출력은 다음과 같습니다.

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

정확한 색상은 차트 스타일 및 테마에 따라 달라집니다.

## **시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) 를 사용해 음수값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤, [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 음수값 색상을 지정하십시오. 음수값 자체는 워크북에 그대로 유지되며, 표시 색상만 변경됩니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0 에는 시리즈 이름이, 열 0 에는 카테고리 이름이, 열 1 에는 값이 들어 있습니다.

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

포인트별로 반전을 활성화하려면 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 를 사용할 수 있습니다. 아래 예제에서는 시리즈에 대한 반전을 비활성화하고 선택한 포인트에만 활성화했습니다. 포인트에 음수값도 할당해 효과를 확인합니다.

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

## **특정 데이터 포인트 값 지우기**

다른 포인트를 유지하면서 한 포인트만 비우려면 해당 백업 워크북 셀을 `None` 로 설정하십시오. 열 차트의 경우 플롯된 값은 [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) 로 얻을 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만, 차트는 해당 값을 빈 값으로 처리합니다.

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 비웁니다.

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

산점도 차트는 X 셀과 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 별도로 사용합니다. 제거하려는 값에 해당하는 셀만 비우십시오. 다른 포인트를 유지하고 싶다면 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) 를 호출하지 마십시오. 해당 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **빈 셀 표시 제어**

값이 있는 숨김 셀은 빈 셀과 별개의 경우입니다. 숨겨진 워크시트 행 및 열의 데이터를 포함하거나 제외하려면 [Include Data from Hidden Rows and Columns](/slides/ko/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) 를 참조하십시오.

빈 워크북 셀은 누락된 데이터를 나타내며, `0` 이 들어 있는 셀은 알려진 숫자 값을 나타냅니다. 셀을 비우려면 [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) 에 `None` 을 전달하십시오. 숫자 0 은 빈 셀 설정에 관계없이 여전히 0 으로 남습니다.

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 를 사용해 차트가 빈 셀을 어떻게 표시할지 선택하십시오. 이 설정은 차트 전체에 적용되며, 빈 셀을 0 또는 보간된 값으로 채우지 않고 플롯 방식을 변경합니다.

다음 자체 포함 예제는 하나의 시리즈가 있는 선 차트를 만들고, Day 3 의 값을 비운 뒤 각 모드별로 차트를 저장합니다. 입력 파일이 필요하지 않습니다. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) 은 워크시트 0, 열 0 에 카테고리 레이블을, 열 1 에 값을 사용하며, 행 0 에는 시리즈 이름이 있습니다. 최종 데이터는 `10, 20, empty, 30, 40` 입니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Day 3을 실제로 비워 두되, 해당 카테고리와 데이터 포인트는 유지합니다.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

각 출력 파일은 저장하기 전에 할당된 모드를 포함합니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나의 버전만 저장하려면 원하는 모드만 할당하고 프레젠테이션을 한 번 저장하면 됩니다.

아래 비교는 세 파일 모두에서 동일한 데이터를 보여줍니다. Day 3 은 모든 경우 워크북에서 비어 있습니다:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

보이는 효과는 차트 유형에 따라 다릅니다. 선 차트는 세 모드를 모두 쉽게 비교할 수 있지만, 막대 및 열 차트는 누락된 카테고리를 연결할 선이 없으므로 `Span` 이 위와 같은 연결 구간을 만들 수 없습니다; 누락된 열과 높이가 0인 열도 비슷해 보일 수 있습니다. 마찬가지로 마커만 있는 산점도 차트에도 연결 선이 없습니다. 모든 차트 유형에서 세 가지 뚜렷한 결과를 기대하지 말고, 사용 중인 차트 유형에 대한 출력 결과를 확인하십시오.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 백분율로 나타낸 값입니다. 겹침과 마찬가지로 이는 개별 시리즈가 아닌 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 를 호출하십시오. 값이 크면 클러스터 사이에 더 많은 공간이 생기고, 값이 작으면 클러스터가 더 조밀해집니다.

다음 예제는 간격 너비를 변경하고 최종 프레젠테이션만 저장합니다.

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

## **시리즈 라인 표시 또는 숨기기**

시리즈 라인은 차트의 관련 부분을 시각적으로 연결합니다. 지원되는 스택형 막대 및 OfPie 차트에서 [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSeriesLines) 을 사용해 표시하거나 숨길 수 있습니다. 2차원 스택형 막대 및 열 차트에서는 카테고리 간에 해당 스택 경계를 연결하고, Pie of Pie 및 Bar of Pie 차트에서는 메인 플롯을 보조 플롯에 연결합니다. 이 설정은 다른 차트 유형에 대한 일반적인 연결 기능이 아닙니다.

그룹에 접근하려면 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 를 사용하십시오. 설정은 해당 그룹의 모든 시리즈에 적용됩니다. [ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#hasSeriesLines) 은 읽기 전용이며 상위 그룹 설정을 반영합니다; 업데이트하려면 그룹의 setter 를 호출하십시오.

다음 예제는 기본 데이터를 가진 하나의 [PieOfPie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#PieOfPie) 차트를 만들고, 시리즈 라인을 활성화한 뒤 비활성화한 두 프레젠테이션을 저장해 비교합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400)
    series = chart.getChartData().getSeries().get_Item(0)
    series_group = series.getParentSeriesGroup()

    series_group.setSeriesLines(True)
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx)

    series_group.setSeriesLines(False)
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Series lines enabled | Series lines disabled |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| 두 라인이 메인 파이와 보조 파이를 연결합니다. | 두 파이는 그대로 보이지만 연결 라인은 숨겨집니다. |

시리즈 라인은 데이터 레이블 리더 라인(레이블을 데이터 포인트에 연결)이나 눈금선(축 간격 표시) 혹은 선 차트의 데이터 값을 나타내는 선과는 다릅니다. 이 설정은 해당 요소들을 제어하지 않습니다.

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원합니까?**

[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 열거형으로 표시되는 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 값 구조나 설정이 동일하지는 않습니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기도 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하십시오. 겹침(overlap)과 간격 너비(gap width)와 같은 옵션은 호환되는 막대나 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇입니까?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) 은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 조합 차트는 둘 이상의 그룹을 포함할 수 있으므로, 하나의 시리즈를 통해 접근한 그룹을 변경한다고 해서 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되어 있습니까?**

예. 기본적으로 [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) 은 샘플 시리즈, 카테고리 및 값을 생성합니다. 해당 셀을 편집하거나 완전히 사용자 지정된 데이터 집합을 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 비울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결됩니까?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) 의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 지정 데이터를 만들 때는 각 포인트가 의도한 카테고리 아래에 플롯되도록 카테고리 행과 시리즈 값 행을 정렬하십시오.

**전체 시리즈가 아니라 하나의 포인트만 지우려면 어떻게 합니까?**

해당 값 셀을 `None` 으로 설정해 포인트의 카테고리 위치는 유지하면서 빈 포인트로 남깁니다. 모든 포인트를 제거하려는 경우에만 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) 를 사용하십시오. 다른 포인트를 유지하려면 해당 메서드를 호출하지 마십시오.

**빈 포인트는 어떻게 표시됩니까?**

결과는 차트 유형과 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 로 설정된 값에 따라 달라집니다. 지원되는 차트는 빈 영역을 간격(gap)으로, 0 값으로, 혹은 인접 포인트를 연결하는 방식으로 표시할 수 있습니다. 프레젠테이션의 누락된 데이터 의미에 맞는 설정을 선택하십시오. 자세한 예제와 시각적 비교는 [Control the Display of Empty Cells](#control-the-display-of-empty-cells) 를 참고하십시오.

**음수 값은 어떻게 서식이 지정됩니까?**

지원되는 막대, 열 및 버블 시리즈의 경우 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) 를 호출하고, [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 반환된 색상을 설정하십시오. 개별 포인트에 대해서는 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 로 동작을 재정의할 수 있습니다. 이러한 메서드는 서식에 영향을 주며, 저장된 숫자 값 자체는 변경하지 않습니다.

**시리즈와 포인트 둘 다 서식이 지정된 경우 어느 쪽이 우선합니까?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식이나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침(overlap)이나 간격(gap width) 등 그룹 설정은 레이아웃을 제어하며, 포인트 수준 서식 우선순위와는 별개입니다.

**차트가 포함할 수 있는 시리즈 수에 제한이 있습니까?**

Aspose.Slides 에는 별도의 고정 시리즈 수 제한이 없습니다. 실제 제한은 프레젠테이션 파일 제약, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성 등에 따라 결정됩니다.

**열이 너무 가깝거나 너무 멀리 떨어져 있을 때 어떻게 조정합니까?**

해당 상위 시리즈 그룹에 대해 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 를 호출하십시오. 값을 늘리면 클러스터 사이 간격이 넓어지고, 값을 줄이면 클러스터가 더 가깝게 배치됩니다.