---
title: Python을 사용한 프레젠테이션 차트 데이터 시리즈 관리
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

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [ChartSeries](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/)는 관련 값의 한 집합을 나타내며, 시리즈의 각 [ChartDataPoint](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/)는 하나 이상의 워크북 셀을 참조합니다. [ChartCategory](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트만으로 저장되는 것이 아니라 [ChartDataCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatacell/) 객체와 연결됩니다.

일반적인 범주형 차트의 경우, 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고 나머지 셀을 시리즈 값에 사용합니다. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/#getCell)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용하여 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정하지 마십시오. 로드된 프레젠테이션의 경우, 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 검사하십시오.

차트 설정에는 세 가지 다른 범위가 있습니다:

- 시리즈 수준 설정은 [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getFormat)와 같이 하나의 시리즈에 있는 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정은 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getFormat)와 같이 한 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/)에 속하는 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 때는 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getParentSeriesGroup)을 통해 그룹에 접근하십시오.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우, 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 포맷이 모두 존재할 때는 해당 포인트에 대해 포인트 포맷이 우선합니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getOverlap)은 2D 차트에서 막대 또는 열이 -100%에서 100%까지 얼마나 겹치는지를 보고합니다. 이는 상위 시리즈 그룹에 대한 설정의 읽기 전용 투영값입니다. 해당 그룹의 모든 호환 시리즈를 업데이트하려면 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setOverlap)을 사용하십시오. 이 옵션은 그룹화된 막대 또는 열을 표시하는 차트 유형에 적용되며, 결합 차트에서 관련 없는 시리즈 그룹에는 영향을 주지 않습니다.

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

[ChartSeries.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getFormat)을 사용하여 전체 시리즈에 대한 기본 채우기를 설정합니다. 포인트에 이미 명시적인 채우기가 있는 경우, 해당 포인트의 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getFormat) 설정이 시리즈 채우기를 재정의합니다.

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

![시리즈 색상](series_color.png)

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터형 열 차트를 위해 생성된 기본 워크북에서 셀 B1은 행 0, 열 1에 위치하며 첫 번째 시리즈의 이름을 포함합니다. 다음 예제의 명명된 변수들은 해당 구조를 명시적으로 보여줍니다:

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

또한 [ChartSeries.getName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getName)이 이미 참조하고 있는 셀을 업데이트할 수 있습니다. 이 접근 방식은 기존 차트에서 특정 행과 열을 가정하는 것을 피합니다:

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

## **자동 시리즈 채우기 색상 가져오기**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor)은 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상을 읽을 뿐이며, 새로운 채우기를 할당하지는 않습니다.

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

기본 차트 스타일에 대한 예제 출력:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

정확한 색상은 차트 스타일 및 테마에 따라 달라집니다.

## **차트 시리즈에 대한 색상 반전 채우기 설정**

막대, 열 및 버블 시리즈의 경우, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#setInvertIfNegative)을 사용하면 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고, 반전을 활성화한 다음 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor)을 통해 음수 값 색상을 지정하십시오. 음수는 워크북에서 그대로 유지되며, 표시 색상만 변경됩니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0에는 시리즈 이름이, 열 0에는 카테고리 이름이, 열 1에는 값이 포함됩니다:

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

[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)를 사용하여 단일 포인트에 대한 반전을 활성화할 수 있습니다. 다음 예제에서는 시리즈에 대한 반전은 비활성화하고 선택된 포인트에만 활성화합니다. 포인트에 음수 값을 할당하여 효과를 확인할 수 있습니다:

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

다른 포인트를 제거하지 않고 하나의 포인트를 비워 두려면 해당 백업 워크북 셀을 `None`으로 설정합니다. 열 차트의 경우, 플롯된 값은 [ChartDataPoint.getValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getValue)을 통해 확인할 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 머무르지만 차트는 차트의 빈값 설정에 따라 해당 값을 빈칸으로 처리합니다.

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 지웁니다:

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

산점도 차트는 별도의 X와 Y 셀을 사용하고, 버블 차트는 크기 셀도 사용합니다. 제거하려는 값에 해당하는 셀만 지우십시오. 다른 포인트를 유지하려는 경우 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapointcollection/#clear)을 호출하지 마십시오. 이 메서드는 컬렉션의 모든 데이터 포인트를 제거하기 때문입니다.

## **빈 셀 표시 제어**

값을 포함한 숨김 셀은 빈 셀과 별개의 경우입니다. 숨겨진 워크시트 행 및 열의 데이터를 포함하거나 제외하려면 [숨겨진 행 및 열의 데이터 포함](/slides/ko/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)를 참조하십시오.

빈 워크북 셀은 누락된 데이터를 나타내며, `0`이 들어 있는 셀은 알려진 숫자 값을 나타냅니다. 셀을 비우려면 `None`을 사용하여 [ChartDataCell.setValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatacell/#setValue)을 호출하십시오. 숫자 0은 빈 셀 설정에 관계없이 0으로 유지됩니다.

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setDisplayBlanksAs)을 사용하여 차트가 빈 셀을 표시하는 방식을 선택합니다. 이 설정은 차트 전체에 적용됩니다. 빈 셀을 0이나 보간값으로 채우지 않고, 빈칸이 플롯되는 방식을 변경합니다.

다음 독립형 예제는 하나의 시리즈가 있는 라인 차트를 생성하고, Day 3의 값을 지운 후 각 모드별로 동일한 차트를 저장합니다. 입력 파일은 필요하지 않습니다. [ChartDataWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/)은 워크시트 0, 열 0을 카테고리 레이블에, 열 1을 값에 사용하며, 행 0에 시리즈 이름을 보관합니다. 최종 데이터는 `10, 20, empty, 30, 40`입니다.

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

    # Day 3을 실제로 비워 두고, 해당 카테고리와 데이터 포인트는 유지합니다.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

각 출력 파일은 저장하기 전에 지정된 모드를 저장합니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나의 버전만 저장하려면 원하는 모드를 지정하고 한 번만 프레젠테이션을 저장하면 되며, 모드를 반복해서 적용할 필요가 없습니다.

아래 비교는 세 파일 모두에서 동일한 데이터를 보여줍니다. 모든 경우에 워크북에서 Day 3은 비어 있습니다:

![동일한 데이터의 라인 차트: Gap은 Day 3에서 라인을 끊고, Zero는 라인을 0으로 떨어뜨리며, Span은 Day 2와 Day 4를 연결합니다.](display_blanks_as.png)

가시적인 효과는 차트 유형에 따라 다릅니다. 라인 차트는 세 가지 모드를 모두 쉽게 비교할 수 있습니다. 막대 및 열 차트는 누락된 카테고리를 연결할 라인이 없으므로 `Span`은 위와 같은 연결 구간을 만들 수 없습니다; 누락된 열과 높이가 0인 열도 유사하게 보일 수 있습니다. 마찬가지로 마커만 있는 산점도 차트에는 연결 라인이 없습니다. 모든 차트 유형에서 세 가지 뚜렷한 결과를 기대하지 말고, 사용 중인 차트 유형에 대한 출력 결과를 확인하십시오.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 열 클러스터 사이의 공간으로, 막대 또는 열 너비의 백분율로 표시됩니다. 겹침과 마찬가지로 이는 개별 시리즈가 아니라 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setGapWidth)을 호출하십시오. 값이 클수록 클러스터 사이의 공간이 넓어지고, 값이 작을수록 밀집됩니다.

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

![간격 너비](gap_width.png)

## **FAQ**

**데이터 시리즈를 지원하는 차트 유형은 무엇입니까?**

[ChartType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/) 열거형으로 표시되는 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 동일한 값 구조나 설정을 가지고 있지는 않습니다. 예를 들어, 범주형 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하십시오. 겹침 및 간격 너비와 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇입니까?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/)은 그룹 수준의 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 결합 차트는 둘 이상의 그룹을 가질 수 있으므로, 하나의 시리즈를 통해 접근한 그룹을 변경한다고 해서 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되어 있습니까?**

예. 기본적으로 [ShapeCollection.addChart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addChart)는 샘플 시리즈, 카테고리 및 값을 생성합니다. 완전히 사용자 정의 데이터를 추가하기 전에 해당 셀을 편집하거나 시리즈와 카테고리 컬렉션을 모두 지울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 생성할 수도 있습니다.

**차트 객체는 워크북 셀에 어떻게 연결됩니까?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [ChartDataWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 구축할 때는 카테고리 행과 시리즈-값 행이 정렬되도록 유지하여 각 포인트가 의도된 카테고리 아래에 플롯되도록 해야 합니다.

**전체 시리즈가 아니라 하나의 포인트만 지우려면 어떻게 해야 합니까?**

해당 값 셀을 `None`으로 설정하면 포인트의 카테고리 위치는 유지된 채 빈 포인트가 됩니다. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapointcollection/#clear)는 해당 시리즈의 모든 포인트를 제거하려는 경우에만 사용하십시오. 카테고리도 함께 제거한다면, 각 시리즈의 값이 카테고리 컬렉션과 정렬된 상태를 유지하도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시됩니까?**

결과는 차트 유형 및 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setDisplayBlanksAs)를 통해 구성된 값에 따라 다릅니다. 지원되는 차트는 빈칸을 간격, 0값 또는 인접 포인트 연결 중 하나로 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하십시오. 전체 예제와 시각적 비교는 [빈 셀 표시 제어](#control-the-display-of-empty-cells)를 참조하십시오.

**음수 값은 어떻게 포맷됩니까?**

지원되는 막대, 열 및 버블 시리즈의 경우, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#setInvertIfNegative)를 호출하고 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor)가 반환하는 색상을 설정하십시오. 개별 포인트에 대해서는 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)를 사용하여 동작을 재정의할 수 있습니다. 이러한 메서드는 포맷에 영향을 주며, 저장된 숫자 값에는 영향을 주지 않습니다.

**시리즈와 포인트가 모두 포맷될 때 어느 것이 우선합니까?**

명시적인 데이터 포인트 포맷이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 포맷을 사용하거나, 시리즈 포맷이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침 및 간격 너비와 같은 그룹 설정은 레이아웃을 제어하며, 포인트 수준의 포맷을 재정의하지 않습니다.

**차트가 포함할 수 있는 시리즈 수에 제한이 있습니까?**

Aspose.Slides는 별도의 고정 시리즈 수 제한을 두지 않습니다. 실제로는 프레젠테이션 파일 제한, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성이 실용적인 제한을 결정합니다.

**열이 너무 가깝거나 너무 떨어져 있을 때 무엇을 변경해야 합니까?**

적절한 상위 시리즈 그룹에서 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setGapWidth)를 호출하십시오. 값을 늘리면 클러스터 사이의 공간이 넓어지고, 값을 줄이면 클러스터가 더 가까워집니다.