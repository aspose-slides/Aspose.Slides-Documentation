---
title: Python을 사용한 프레젠테이션에서 차트 데이터 레이블 관리
linktitle: 데이터 레이블
type: docs
url: /ko/python-java/chart-data-label/
keywords:
- 차트
- 데이터 레이블
- 데이터 정밀도
- 백분율
- 레이블 거리
- 레이블 위치
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 차트 데이터 레이블을 추가하고 서식 지정하여 보다 매력적인 슬라이드를 만드는 방법을 배웁니다."
---
## **소개**

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하도록 도와줍니다. 이 문서에서는 값 서식 지정, 백분율 표시, 레이블 텍스트 읽기, 축 최대값을 초과하는 레이블 제어, 범주 축 레이블 간격 조정, 파이 차트 레이블 위치 지정 방법을 설명합니다.

## **차트 데이터 레이블에서 데이터 정밀도 설정**

[setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) 를 사용하여 시리즈 값을 서식 지정합니다. 이 예제는 기본 데이터를 사용해 선 차트를 만들고, 데이터 표를 표시하며 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 서식은 천 단위 구분 기호와 두 자리 소수점을 표시하지만 기본 값은 변경하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **레이블로 백분율 표시**

누적 컬럼 차트에서 각 값을 해당 범주의 총합에 대한 백분율로 계산하고, [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) 이 반환하는 텍스트 프레임에 텍스트를 할당합니다. 이 예제는 기본 차트 데이터를 사용하고, 8포인트 글꼴에 소수점 두 자리까지 표시되는 백분율을 표시합니다. 총합이 0인 범주는 나눗셈 오류를 방지하기 위해 건너뜁니다. 차트 데이터가 변경되면 사용자 정의 레이블 텍스트를 다시 계산해야 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트 데이터 레이블에 백분율 기호 설정**

값이 분수 형태로 저장된 경우, [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) 을 사용하여 백분율을 표시합니다. 소스 셀과 독립적으로 레이블 서식을 적용하려면 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) 에 `False` 를 전달합니다.

이 예제는 네 개 범주에 빨간색과 파란색 시리즈가 있는 100% 누적 컬럼 차트를 만들고, 각 값 쌍이 1이 되도록 합니다. 레이블 서식 `0.0%` 은 `0.30` 을 `30.0%` 로 표시하고, 수직 축은 소수점 두 자리로 표시합니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **데이터 레이블의 실제 텍스트 읽기**

[getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) 을 사용하면 데이터 레이블 설정에 의해 생성된 텍스트를 가져올 수 있습니다. 이는 레이블을 보고서에 추출하거나 프레젠테이션 내용을 검색하거나 생성된 차트를 검증할 때 유용합니다. 아래 예제에서는 기본 [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) 이 각 범주 이름, 시리즈 이름 및 값을 결합합니다. 한 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) 에서 사용자 정의 텍스트를 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

데이터 포인트에 저장된 숫자는 `0.75` 그대로이며, 레이블에는 `75%`와 함께 범주 및 시리즈 이름이 표시됩니다. 사용자 정의 텍스트는 생성된 레이블 텍스트를 대체합니다. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) 은 어느 경우든 결과 레이블 문자열을 반환합니다. 표시된 레이블만 추출하려면 위 예제와 같이 [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) 을 별도로 확인하십시오.

## **축 최대값을 초과하는 데이터 레이블 제어**

축 범위를 수동으로 제한하면 일부 데이터 포인트가 최대값을 초과할 수 있습니다. [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) 을 사용하여 해당 레이블을 표시할지 여부를 제어합니다. 이 설정은 레이블 가시성을 변경하지만 축 범위나 기본 데이터 값은 변경하지 않습니다.

아래 예제는 값이 60과 120인 2D 군집형 컬럼 차트를 만들고, 수직 축에 대해 [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) 에 `False` 를 전달한 뒤 [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) 로 최대값을 100으로 설정합니다. 첫 번째 슬라이드는 최대값을 초과하는 레이블을 허용하고, 복사본 슬라이드는 이를 비활성화합니다. 두 슬라이드 모두 `DataLabelsOverMaximum.pptx` 로 저장됩니다.

값 레이블을 활성화하려면 [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) 를 사용합니다. 차트 수준 설정만으로는 값 표시가 자동으로 활성화되지 않으며 개별 레이블의 비활성화된 값 표시를 덮어쓰지도 않습니다. 이 예제는 전체 시리즈에 값을 활성화하고 [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) 을 사용해 각 컬럼 외부 끝에 레이블을 배치합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

다음 이미지는 Microsoft PowerPoint 로 렌더링된 저장된 슬라이드를 보여줍니다. `True` 로 설정하면 레이블 **120** 이 상단 경계에 표시되고, `False` 로 설정하면 숨겨집니다. 레이블 **60** 은 계속 표시되며, 축 최대값은 **100** 으로 유지되고 두 번째 데이터 포인트는 두 경우 모두 **120** 입니다.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![축 최대값이 100인 상태에서 값 레이블 120을 표시하는 PowerPoint 차트](data-labels-over-maximum-true.png) | ![축 최대값이 100인 상태에서 값 레이블 120을 숨기는 PowerPoint 차트](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
이 예제는 값 축이 있는 2D 컬럼 차트를 사용합니다. 파이 차트와 도넛 차트처럼 값 축이 없는 차트는 이 방식으로 축 최대값을 제한할 수 없습니다.
{{% /alert %}}

## **축에서 레이블 거리 설정**

[setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) 을 사용하여 범주 축 레이블과 축 사이의 거리를 제어합니다. 값은 축 레이블 최대 글꼴 크기의 백분율입니다. 이 예제는 군집형 컬럼 차트를 만들고 수평 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 연결된 레이블이 아니라 범주 축 레이블에 영향을 줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **레이블 위치 조정**

파이 차트에서 데이터 레이블 위치를 조정해 간격을 개선하고 리더 라인을 위한 공간을 확보합니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고 레이블을 슬라이스 외부에 배치한 뒤, [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) 와 [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) 를 사용해 수평 및 수직 오프셋을 조정합니다. 이러한 오프셋은 차트 너비와 높이에 대한 비율로 지정됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![조정된 데이터 레이블 위치가 있는 파이 차트](pie-chart-adjusted-label.png)

## **리더 라인 서식 지정**

파이 차트 레이블이 슬라이스 밖에 있을 때 리더 라인은 각 값을 올바른 슬라이스와 연결하는 데 도움이 됩니다. 대비되는 색상과 약간 두꺼운 선은 연결을 쉽게 따라갈 수 있게 하며, 투명도와 점선 스타일은 라인을 시각적으로 방해되지 않게 합니다.

[getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) 을 사용하여 시리즈 데이터 레이블 컬렉션 수준에서 리더 라인을 서식 지정합니다. `series.getLabels().getLeaderLinesFormat().getLine()` 에 있는 설정은 개별 레이블이 아닌 컬렉션에 적용됩니다.

이 예제는 기본 데이터를 사용해 파이 차트를 만들고 슬라이스 외부에 값을 표시한 뒤 [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines) 를 활성화합니다. 차트 너비와 높이의 비율로 표현된 [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) 와 [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) 오프셋을 사용해 두 레이블을 슬라이스에서 더 멀리 이동시킵니다. 입력 프레젠테이션은 필요하지 않습니다.

라인의 [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) 은 알파 값 191(전체 255 중)인 고체 파란색을 설정하여 약 25% 투명도를 제공합니다. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) 은 두께를 2포인트로 설정하고, [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) 은 선을 점선으로 만듭니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # 두 레이블을 슬라이스에서 더 멀리 이동합니다.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

리더 라인을 활성화해도 모든 레이블에 라인이 표시되는 것은 보장되지 않습니다. 가시성은 레이블 위치와 차트 레이아웃 동작에 따라 달라집니다. 이 예제에서는 두 개의 이동된 레이블에만 보이는 리더 라인이 있으며, 슬라이스에 가깝게 남은 레이블은 라인이 필요하지 않습니다.

다음 이미지는 Aspose.Slides 로 렌더링된 저장된 `FormattedLeaderLines.pptx` 를 보여줍니다:

![두 개의 외부 레이블을 파이 슬라이스와 연결하는 파란색, 반투명 점선 리더 라인이 있는 파이 차트](formatted-leader-lines.png)

## **열 차트 위에 다중 행 데이터 레이블 추가**

이 예제는 플롯 영역 위에 두 행의 데이터 레이블을 가진 컬럼 차트를 만들고, Series A는 보이는 컬럼을 표시하며 Series B와 Series C는 추가 레이블을 제공합니다. 두 시리즈의 컬럼은 채우기와 외곽선을 제거해 숨깁니다. [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) 메서드는 세 시리즈를 동일한 범주 중심에 맞춥니다.

[ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) 설정은 레이블 행을 위한 공간을 예약합니다. [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) 이 기본 위치를 계산한 후, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) 와 [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) 가 수평 정렬을 유지하고 수직 오프셋을 적용해 레이블을 두 행으로 배치합니다. 숫자는 여전히 시리즈 값에 연결된 데이터 레이블이며, 행 머리글만 별도의 텍스트 도형으로 존재합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # B와 C의 컬럼을 숨기지만 데이터 레이블은 유지합니다.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # 세 시리즈를 동일한 범주 중심에 맞춥니다.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # 이 간결한 예제에 대해 격자선을 적게 사용합니다.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # 플롯 위에 두 행의 데이터 레이블을 위한 공간을 예약합니다.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # 기본 수평 위치를 유지합니다. Y는 다음에서의 오프셋입니다
            # 기본 레이블 위치에서 차트 높이 비율로 표현된 오프셋입니다.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # 행 머리글만 별도의 텍스트 도형입니다.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![플롯 영역 위에 두 행의 데이터 레이블이 있는 컬럼 차트](multiple-rows-of-labels.png)

## **FAQ**

**데이터 레이블이 밀집된 차트에서 겹치는 것을 어떻게 방지할 수 있나요?**

자동 레이블 배치, 리더 라인, 작은 글꼴 크기를 결합하고 필요에 따라 일부 필드(예: 범주)를 숨기거나 극값·핵심 포인트에만 레이블을 표시합니다.

**값이 0, 음수 또는 비어 있는 경우에만 레이블을 비활성화하려면 어떻게 해야 하나요?**

레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 0, 음수 또는 누락된 값에 대해 표시를 끄는 규칙을 적용합니다.

**PDF/이미지로 내보낼 때 레이블 스타일을 일관되게 유지하려면 어떻게 해야 하나요?**

글꼴 종류와 크기를 명시적으로 설정하고, 렌더링 환경에 해당 글꼴이 존재하는지 확인해 대체 글꼴이 사용되지 않도록 합니다.