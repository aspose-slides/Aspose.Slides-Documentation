---
title: Python에서 프레젠테이션의 차트 데이터 시리즈 관리
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

차트는 플롯된 값을 워크북 셀에 저장하거나 직접 숫자 리터럴로 저장할 수 있습니다. A [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) 은 관련 값의 한 세트를 나타내며, 각 [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) 은 해당 시리즈의 점을 나타냅니다. [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 기본 데이터로 만든 차트에서는 시리즈 이름, 카테고리 및 점 값이 차트 워크북의 [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) 객체를 사용합니다.

일반적인 범주형 차트에서 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고 나머지 셀을 시리즈 값에 사용합니다. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) 에 전달되는 워크시트, 행 및 열 인덱스는 0 기반입니다. 이 레이아웃은 기본 데이터로 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다는 가정은 하지 마십시오. 로드된 프레젠테이션에서는 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 검사하십시오.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정, 예: [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) 은 한 시리즈의 모든 점에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정, 예: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) 은 한 점에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) 에 속하는 호환 가능한 시리즈에 적용됩니다. 겹침이나 간격 너비와 같은 옵션을 설정해야 할 때는 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 를 통해 그룹에 접근하십시오.

명시적인 점 또는 시리즈 채우기가 설정되지 않은 경우 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 점 서식이 모두 존재하면 점 서식이 해당 점에 대해 우선합니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **숫자 리터럴을 사용하여 시리즈 값 설정**

시리즈 값이 애플리케이션 데이터나 계산 결과에서 나오고 워크시트 셀 참조가 필요하지 않을 때 숫자 리터럴을 사용하십시오. 각 점의 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) 결과를 [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble) 로 할당하기 전에 [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) 에 [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) 를 전달하십시오.

컬렉션 설정은 해당 시리즈의 모든 점 값의 소스 유형을 제어합니다. 각 점 값의 [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) 메서드는 선택된 유형을 보고합니다; 컬렉션 설정을 통해 변경하십시오. `Worksheet` 를 사용할 경우 [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) 로 참조 셀에 접근합니다. `DoubleLiterals` 를 사용할 경우 [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) 또는 `setAsLiteralDouble` 로 숫자를 직접 읽거나 씁니다.

다음 예제는 기본 시리즈와 카테고리를 가진 컬럼 차트를 만든 뒤 첫 번째 시리즈의 기존 점에 10, 20 등의 계산값을 할당합니다. 프레젠테이션을 저장하고 다시 열어 저장된 값을 출력합니다.

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

점 값 소스 유형은 차트의 내부 또는 외부 워크북 구성을 식별하는 [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) 와 별개입니다. 숫자 리터럴을 사용한다고 해서 워크북이 자동으로 제거되는 것은 아닙니다. 이 예제에서는 워크북이 카테고리 레이블, 시리즈 이름 및 다른 시리즈에 대해 계속 사용됩니다. 워크북 관리에 대해서는 [Chart Workbook](/slides/ko/python-java/chart-workbook/) 를 참조하십시오.

산점도와 버블 차트의 경우 [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) 와 [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) 를 사용해 각각 [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) 와 [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) 의 소스를 선택합니다. 버블 차트는 또한 [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) 로 [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) 의 소스를 선택합니다. 해당 값을 `DoubleLiterals` 로 설정한 뒤 `setAsLiteralDouble` 메서드로 숫자를 할당하십시오.

## **차트 시리즈 겹침 설정**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) 은 2D 차트에서 막대 또는 열이 겹치는 비율을 -100%에서 100%까지 반환합니다. 이는 상위 시리즈 그룹에 대한 설정을 읽기 전용으로 투영한 값입니다. 해당 그룹의 모든 호환 시리즈를 업데이트하려면 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) 를 사용하십시오. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에 적용되며, 복합 차트의 무관한 시리즈 그룹에는 영향을 주지 않습니다.

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

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

전체 시리즈의 기본 채우기를 설정하려면 [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) 을 사용하십시오. 점에 명시적인 채우기가 이미 존재하면 해당 점의 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다.

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

![시리즈 색상](series_color.png)

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 컬럼 차트의 기본 워크북에서는 셀 B1(행 0, 열 1)에 첫 번째 시리즈 이름이 들어 있습니다. 다음 예제의 변수들은 그 구조를 명시적으로 보여줍니다.

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

또한 [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) 이 이미 참조하고 있는 셀을 업데이트할 수 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하지 않으므로 안전합니다.

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

![시리즈 이름](series_name.png)

### **여러 셀에서 이름을 구성하여 시리즈 만들기**

제품 이름과 보고 기간이 각각 별도 워크북 셀에 저장된 경우 복합 시리즈 이름을 만들 수 있습니다. 예를 들어 B1 셀의 `Product A`와 C1 셀의 `2026`을 결합해 두 부분이 각각 원본 셀에 연결된 채 하나의 시리즈 이름으로 사용할 수 있습니다.

[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) 로 이름 범위를 가져온 뒤 해당 컬렉션을 [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) 에 전달하십시오. `skipHiddenCells` 인자는 숨겨진 셀을 포함할지 여부를 제어합니다: `True` 면 제외하고, `False` 면 포함합니다. 이 예제는 `False` 를 사용해 이름 범위의 모든 셀을 포함합니다.

다음 예제는 하나의 시리즈와 두 개의 데이터 포인트를 가진 프레젠테이션을 생성합니다. 셀 B1:C1 은 시리즈 이름만 제공하고, A2:A3 은 카테고리 레이블, B2:B3 은 숫자 값을 제공합니다.

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

    # 별도의 셀들이 카테고리와 숫자 데이터 포인트를 제공합니다.
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

결과 시리즈 이름은 `Product A 2026`이며, 두 셀 값 사이에 공백이 포함됩니다. 범례에 두 열에 대한 하나의 엔트리로 표시됩니다. 아래 이미지가 결과를 보여줍니다.

![North와 South 값이 포함된 컬럼 차트 및 범례에 복합 시리즈 이름 Product A 2026 표시](composite_series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 은 시리즈 인덱스와 차트 스타일에서 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상이며, 메서드 호출만으로 색상을 읽을 수 있고 새로운 채우기를 할당하지는 않습니다.

다음 예제는 각 기본 시리즈의 자동 색상을 출력합니다.

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

정확한 색상은 차트 스타일과 테마에 따라 달라집니다.

## **차트 시리즈에 대한 반전 채우기 색상 설정**

막대, 컬럼 및 버블 시리즈의 경우 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) 를 사용해 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤, [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 음수값 색상을 지정하십시오. 음수 값 자체는 워크북에 그대로 남으며 표시 색상만 변경됩니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0 은 시리즈 이름, 열 0 은 카테고리 이름, 열 1 은 값을 포함합니다.

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

![반전된 단색 채우기 색상](inverted_solid_fill_color.png)

한 점에 대해서만 반전을 활성화하려면 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 를 사용하십시오. 아래 예제에서는 시리즈에 대한 반전을 비활성화하고 선택한 점에만 활성화합니다. 해당 점에도 음수 값을 할당해 효과를 확인합니다.

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

다른 포인트는 유지하면서 한 포인트를 비우려면 해당 백업 워크북 셀을 `None` 으로 설정하십시오. 컬럼 차트의 경우 플롯된 값은 [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) 로 접근할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 머무르지만 차트는 해당 값을 빈값으로 처리합니다(차트의 빈값 설정에 따름).

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 지웁니다.

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

산점도는 X와 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 사용합니다. 제거하려는 값에 해당하는 셀만 지우십시오. 다른 포인트를 유지하려면 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) 를 호출하지 마십시오. 이 메서드는 컬렉션의 모든 데이터 포인트를 삭제합니다.

## **빈 셀 표시 제어**

값이 있는 숨겨진 셀은 빈 셀과 별개의 경우입니다. 숨겨진 워크시트 행 및 열의 데이터를 포함하거나 제외하려면 [Include Data from Hidden Rows and Columns](/slides/ko/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) 를 참조하십시오.

빈 워크북 셀은 누락된 데이터를 나타내며, `0` 이 들어 있는 셀은 알려진 숫자 값을 나타냅니다. 셀을 비우려면 [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) 에 `None` 을 전달하십시오. 숫자 0 은 빈 셀 설정에 관계없이 0 으로 유지됩니다.

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 를 사용해 차트가 빈 셀을 표시하는 방식을 선택하십시오. 이 설정은 차트 전체에 적용되며, 빈 셀을 0이나 보간값으로 채우지 않고 플롯 방식을 바꿉니다.

다음 자체 포함 예제는 라인 차트를 만들고, Day 3 의 값을 지운 뒤 각 모드별로 차트를 저장합니다. 입력 파일이 필요하지 않습니다. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) 은 워크시트 0, 열 0 에 카테고리 레이블, 열 1 에 값을 사용하고, 행 0 에 시리즈 이름을 둡니다. 최종 데이터는 `10, 20, empty, 30, 40` 입니다.

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

    # Day 3을 실제로 비워두고, 해당 카테고리와 데이터 포인트는 유지합니다.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

각 출력 파일은 저장 전에 지정된 모드에 따라 이름이 지정됩니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나만 저장하려면 원하는 모드만 지정하고 프레젠테이션을 한 번 저장하면 됩니다.

아래 비교는 세 파일 모두 동일한 데이터를 사용했을 때의 모습을 보여줍니다. Day 3 은 모든 경우 워크북에서 빈 셀입니다:

![라인 차트에 동일한 데이터: Gap 은 Day 3 에서 라인을 끊고, Zero 는 라인을 0 으로 내리며, Span 은 Day 2 에서 Day 4 로 연결합니다.](display_blanks_as.png)

시각적 효과는 차트 유형에 따라 다릅니다. 라인 차트는 세 모드를 쉽게 비교할 수 있지만, 막대와 컬럼 차트는 누락된 카테고리를 연결할 선이 없으므로 `Span` 이 보여지는 연결 구간을 만들 수 없습니다. 누락된 컬럼과 0 높이 컬럼도 유사하게 보일 수 있습니다. 마찬가지로 마커만 있는 산점도는 연결 선이 없습니다. 모든 차트 유형에서 세 가지 뚜렷한 결과를 기대하지 말고, 사용 중인 차트 유형에 대해 출력 결과를 확인하십시오.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 컬럼 클러스터 사이의 공간을 막대 또는 컬럼 너비의 백분율로 나타낸 것입니다. 겹침과 마찬가지로 이것은 개별 시리즈가 아니라 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 를 호출하십시오. 값이 클수록 클러스터 사이 간격이 넓어지고, 값이 작을수록 밀집됩니다.

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

![간격 너비](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원합니까?**

[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 열거형에 포함된 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 값 구조나 설정이 동일하지는 않습니다. 예를 들어 범주형 차트는 카테고리와 값을 사용하고, 산점도는 X와 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하십시오. 겹침 및 간격 너비와 같은 옵션은 호환되는 막대 또는 컬럼 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇입니까?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) 은 그룹 수준 플롯 설정을 공유하는 호환 가능한 시리즈를 포함합니다. 복합 차트는 여러 그룹을 포함할 수 있으므로, 한 시리즈를 통해 접근한 그룹을 변경해도 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되어 있습니까?**

예. 기본적으로 [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) 은 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 완전히 사용자 지정된 데이터 집합을 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 지울 수 있습니다. 오버로드를 사용해 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결됩니까?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) 의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 만들 때는 각 포인트가 의도한 카테고리 아래에 플롯되도록 카테고리 행과 시리즈 값 행을 정렬하십시오.

**전체 시리즈가 아닌 하나의 포인트만 지우려면 어떻게 합니까?**

해당 값 셀을 `None` 로 설정하면 포인트의 카테고리 위치는 유지하면서 빈 포인트가 됩니다. 모든 포인트를 삭제하려는 경우에만 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) 를 사용하십시오. 카테고리 자체를 제거한다면, 모든 시리즈가 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시됩니까?**

표시는 차트 유형과 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 로 설정된 값에 따라 달라집니다. 지원되는 차트는 빈 값을 간격, 0 값 또는 인접 포인트 연결 방식으로 표시할 수 있습니다. 프레젠테이션의 누락 데이터 의미에 맞는 설정을 선택하십시오. 전체 예제와 시각적 비교는 [Control the Display of Empty Cells](#control-the-display-of-empty-cells) 를 참고하십시오.

**음수 값은 어떻게 포맷됩니까?**

지원되는 막대, 컬럼 및 버블 시리즈의 경우 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) 를 호출하고 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 반환된 색상을 설정하십시오. 개별 포인트에 대해서는 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 로 동작을 재정의할 수 있습니다. 이러한 메서드는 서식에만 영향을 주며 저장된 숫자 값은 변경하지 않습니다.

**시리즈와 포인트 모두 서식이 지정된 경우 어느 것이 우선합니까?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식을 사용하거나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침이나 간격 너비와 같은 그룹 설정은 레이아웃을 제어하며 포인트 수준 서식보다 우선하지 않습니다.

**차트가 포함할 수 있는 시리즈 수에 제한이 있습니까?**

Aspose.Slides 자체에는 별도의 고정 시리즈 개수 제한이 없습니다. 실제로는 프레젠테이션 파일 제한, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성이 유용한 한계를 결정합니다.

**컬럼이 너무 가깝거나 너무 멀리 떨어져 있을 때 어떻게 해야 합니까?**

적절한 상위 시리즈 그룹에 대해 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 를 호출하십시오. 값을 높이면 클러스터 사이 간격이 넓어지고, 값을 낮추면 클러스터가 서로 가까워집니다.