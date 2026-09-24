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

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. A [ChartSeries](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/)는 관련 값 집합을 나타내며, 시리즈의 각 [ChartDataPoint](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/)는 하나 이상 워크북 셀을 참조합니다. [ChartCategory](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트에만 저장되는 것이 아니라 [ChartDataCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatacell/) 객체와 연결됩니다.

일반적인 카테고리 차트의 경우, 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고 나머지 셀에 시리즈 값을 저장합니다. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/#getCell) 에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터로 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정하지는 마세요. 로드된 프레젠테이션에서는 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 검사하십시오.

차트 설정은 세 가지 다른 범위가 있습니다:

- 시리즈 수준 설정(예: [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getFormat))은 하나의 시리즈에 속한 모든 포인트의 기본 모양을 제공합니다.
- 데이터 포인트 설정(예: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getFormat))은 하나의 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침이나 간격 너비와 같은 옵션을 설정해야 할 때는 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 를 통해 그룹에 접근하십시오.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 서식이 모두 존재하면 해당 포인트에 대해서는 포인트 서식이 우선합니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getOverlap) 은 2D 차트에서 막대나 열이 겹치는 정도를 -100%부터 100%까지 보고합니다. 이는 상위 시리즈 그룹에 대한 설정을 읽기 전용으로 투영한 값입니다. 해당 그룹에 포함된 모든 호환 시리즈를 업데이트하려면 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setOverlap) 를 사용하십시오. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에만 적용되며, 복합 차트에서 관련 없는 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈를 포함하는 그룹의 겹침을 설정합니다:

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

    # 새 차트에는 샘플 시리즈, 카테고리 및 값이 포함되어 있습니다.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![The series overlap](series_overlap.png)

## **시리즈 채우기 색 변경**

전체 시리즈에 대한 기본 채우기를 설정하려면 [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getFormat) 을 사용하십시오. 포인트에 이미 명시적인 채우기가 있는 경우 해당 포인트의 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getFormat) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 실선 파란색 채우기를 적용합니다:

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

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 열 차트용 기본 워크북에서 셀 B1은 행 0, 열 1에 위치하며 첫 번째 시리즈의 이름을 포함합니다. 아래 예제의 명명된 변수들은 이 구조를 명시적으로 보여줍니다:

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

또한 [ChartSeries.getName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getName) 이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하지 않으므로 안전합니다:

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

## **자동 시리즈 채우기 색 가져오기**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 은 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 이 메서드를 호출하면 계산된 색상을 읽을 뿐 새로운 채우기를 할당하지는 않습니다.

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

정확한 색은 차트 스타일과 테마에 따라 달라집니다.

## **시리즈에 대한 반전 채우기 색 설정**

막대, 열 및 버블 시리즈의 경우, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#setInvertIfNegative) 를 사용하면 음수값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 실선으로 설정하고 반전을 활성화한 뒤, [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 음수값 색을 지정하십시오. 워크북에 저장된 음수값 자체는 변하지 않으며, 표시 색만 변경됩니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈만 남기고 교체합니다. 워크시트 행 0에 시리즈 이름, 열 0에 카테고리 이름, 열 1에 값을 배치합니다:

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

한 포인트에만 반전을 적용하려면 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 를 사용하십시오. 아래 예제에서는 시리즈에 대한 반전을 비활성화하고 선택한 포인트에만 활성화합니다. 포인트에 음수값을 할당하여 효과를 확인할 수 있습니다:

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

다른 포인트는 유지하면서 하나의 포인트를 비우려면 해당 워크북 셀을 `None` 으로 설정하십시오. 열 차트의 경우 플롯된 값은 [ChartDataPoint.getValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getValue) 로 확인할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만, 차트는 값이 비어 있다고 간주합니다.

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

산점도는 X와 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 사용합니다. 삭제하려는 값에 해당하는 셀만 비우십시오. 다른 포인트를 유지하고 싶다면 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapointcollection/#clear) 를 호출하지 마십시오. 이 메서드는 컬렉션의 모든 포인트를 제거합니다.

## **빈 셀 표시 제어**

빈 워크북 셀은 누락된 데이터를 나타내며, `0` 을 포함한 셀은 알려진 숫자 값을 나타냅니다. 셀을 비우려면 `None` 을 인수로 하여 [ChartDataCell.setValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatacell/#setValue) 를 호출하십시오. 숫자 0 은 빈 셀 설정에 관계없이 0 으로 남습니다.

차트가 빈 셀을 어떻게 표시할지 선택하려면 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setDisplayBlanksAs) 를 사용하십시오. 이 설정은 차트 전체에 적용되며, 빈 셀을 0 값이나 보간값으로 채우지 않고 어떻게 플롯할지 결정합니다.

다음 독립 실행형 예제는 하나의 시리즈를 가진 꺾은선 차트를 만들고, Day 3 의 값을 비운 뒤 각 모드별로 차트를 저장합니다. 입력 파일은 필요하지 않습니다. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/) 은 워크시트 0, 열 0을 카테고리 레이블에, 열 1을 값에 사용하며, 행 0에는 시리즈 이름을 둡니다. 최종 데이터는 `10, 20, empty, 30, 40` 입니다:

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

    # Day 3을 실제로 빈 상태로 두면서, 해당 카테고리와 데이터 포인트는 유지합니다.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

각 출력 파일은 저장 전 설정된 모드에 따라 이름이 지정됩니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나의 버전만 저장하려면 원하는 모드만 지정하고 프레젠테이션을 한 번 저장하면 됩니다.

아래 비교는 세 파일 모두 동일한 데이터를 보여줍니다. Day 3 은 모든 경우에 워크북에서 비어 있습니다:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

보이는 효과는 차트 유형에 따라 다릅니다. 꺾은선 차트는 세 모드를 쉽게 비교할 수 있지만, 막대 및 열 차트는 누락된 카테고리를 연결할 선이 없으므로 `Span` 이 위와 같은 연결 구간을 만들 수 없습니다. 누락된 열과 0 높이 열도 비슷해 보일 수 있습니다. 마찬가지로 마커만 있는 산점도는 연결 선이 없습니다. 모든 차트 유형에서 세 가지 뚜렷한 결과를 기대하지 말고, 사용 중인 차트 타입의 출력을 확인하십시오.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 백분율로 나타낸 값입니다. 겹침과 마찬가지로 이는 개별 시리즈가 아니라 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 를 호출하십시오. 값이 클수록 클러스터 사이의 공간이 넓어지고, 작을수록 밀집됩니다.

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

**어떤 차트 유형이 데이터 시리즈를 지원합니까?**

[ChartType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/) 열거형에 포함된 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 값 구조나 설정이 다릅니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도는 X와 Y 값을 사용하며, 버블 차트는 추가로 버블 크기를 사용합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하십시오. 겹침 및 간격 너비와 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇입니까?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/) 은 그룹 수준 플로팅 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 하나 이상의 그룹을 가질 수 있으므로, 한 시리즈를 통해 접근한 그룹의 설정을 변경해도 차트의 모든 시리즈에 영향을 주지는 않습니다.

**새로 만든 차트에 기본 데이터가 포함되어 있습니까?**

예. 기본적으로 [ShapeCollection.addChart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addChart) 은 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 완전히 사용자 지정된 데이터 세트를 추가하기 전에 시리즈와 카테고리 컬렉션을 모두 비울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결됩니까?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/) 의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 지정 데이터를 구성할 때는 카테고리 행과 시리즈‑값 행이 정렬되어 각 포인트가 의도한 카테고리 아래에 플롯되도록 하십시오.

**전체 시리즈가 아니라 하나의 포인트만 어떻게 삭제합니까?**

해당 값 셀을 `None` 로 설정하면 포인트의 카테고리 위치는 유지되면서 빈 포인트가 됩니다. 모든 포인트를 삭제하려는 경우에만 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapointcollection/#clear) 를 사용하십시오. 카테고리 자체를 삭제한다면, 모든 시리즈가 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시됩니까?**

표시 방식은 차트 유형 및 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setDisplayBlanksAs) 에서 설정한 값에 따라 다릅니다. 지원되는 차트는 빈 값을 간격, 0 값 또는 인접 포인트 연결 중 하나로 표시할 수 있습니다. 프레젠테이션에 맞는 설정을 선택하십시오. 자세한 예제와 시각적 비교는 **[빈 셀 표시 제어](#control-the-display-of-empty-cells)** 를 참고하십시오.

**음수 값은 어떻게 서식이 지정됩니까?**

지원되는 막대, 열 및 버블 시리즈에 대해 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#setInvertIfNegative) 를 호출하고, [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 로 반환된 색을 지정하십시오. 개별 포인트에 대해서는 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 로 동작을 재정의할 수 있습니다. 이 메서드들은 서식에만 영향을 주며 저장된 숫자 값은 변경되지 않습니다.

**시리즈와 포인트 모두 서식이 지정된 경우 어느 것이 우선합니까?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식을 사용하거나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 따릅니다. 겹침·간격 너비와 같은 그룹 설정은 레이아웃을 제어하며 포인트 수준 서식 재정의가 아닙니다.

**차트에 포함될 수 있는 시리즈 수에 제한이 있습니까?**

Aspose.Slides 에는 별도의 고정 시리즈 수 제한이 없습니다. 실제 제한은 프레젠테이션 파일 크기, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성 등에 의해 결정됩니다.

**열이 너무 가깝거나 너무 떨어져 있을 때 어떻게 수정합니까?**

적절한 상위 시리즈 그룹에 대해 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 를 호출하십시오. 값을 늘리면 클러스터 간 간격이 넓어지고, 값을 줄이면 클러스터가 서로 가까워집니다.