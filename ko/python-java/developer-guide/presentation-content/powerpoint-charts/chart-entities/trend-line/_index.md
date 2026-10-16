---
title: Python에서 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/python-java/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 멱 추세선
- 사용자 정의 추세선
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python용 Java를 통해 Aspose.Slides로 PowerPoint 차트에 추세선을 빠르게 추가하고 맞춤 설정하여 청중을 사로잡는 실용적인 가이드."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만드는 방법, 차트 시리즈에 추세선을 추가하는 방법, 그리고 지수형, 선형, 로그형, 이동 평균, 다항식, 그리고 멱형 등 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 라인 도형을 삽입하여 차트에 사용자 정의 선을 추가하는 방법을 설명하고, 앞뒤 추세선 투영 값 및 추세선이 PDF 또는 SVG로 내보낼 때와 차트를 이미지로 렌더링할 때 유지되는지에 대한 짧은 FAQ를 포함합니다.

## **추세선 추가**

사용 [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) 차트 시리즈에 추세선을 추가하고, [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/)으로 유형을 선택합니다. 예제는 기본 데이터로 클러스터형 열 차트를 생성하고 각각의 세 시리즈에 두 개의 추세선을 추가합니다.

지수형 추세선은 [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) 및 [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue)를 통해 방정식과 R 제곱 값을 숨기며, 선형 추세선은 빨간색입니다. 로그형 추세선은 [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding)를 사용해 사용자 정의 레이블을 지정합니다. 이동 평균은 세 데이터 포인트의 [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod)와 사용자 정의 [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName)를 사용합니다.

다항식 추세선은 [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder)로 세 차수로 설정하고, [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward)를 통해 한 카테고리 앞으로 확장합니다. 멱형 추세선은 [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward)를 통해 한 카테고리 뒤로 확장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **추세선 절편 설정**

사용 [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) 추세선의 Y 값을 X = 0에서 고정합니다. 이 설정은 선형, 지수형 및 다항식 추세선에서 지원됩니다.

예를 들어, 생산 비용 모델은 비생산 시점에도 알려진 고정 비용 100에서 시작해야 할 수 있습니다. 선형 추세선의 경우 절편을 고정하면 방정식 `y = ax + b`가 `b = 100`으로 제한되고, 기울기는 해당 제한 아래에서 데이터에 맞춰집니다. 이는 이미 맞춰진 선을 단순히 이동시키는 것이 아닙니다. 축 교차 설정은 차트 축이 만나게 되는 위치를 제어하며, 맞춰진 추세선의 계수를 변경하지 않습니다.

다음 예제는 1에서 4까지의 생산량과 170, 200, 230, 260의 비용을 사용해 산점도(XY) 차트를 생성합니다. 기본 자동 절편으로 차트를 저장하고, 절편을 100으로 설정한 뒤 두 번째 PPTX를 저장합니다. 두 파일은 절편 설정만 다릅니다. 추세선은 방정식을 표시하고 X = 0까지 뒤로 확장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

자동 계산을 사용하면 이 데이터는 `y = 30x + 140`을 생성합니다. 절편을 100으로 설정하면 대략 `y = 43.33x + 100`이 됩니다: 제로에서의 맞춰진 값이 알려진 기준선과 일치하지만, 선은 더 이상 모든 데이터 포인트를 통과하지 않습니다.

| 자동 절편 | 절편을 100으로 고정 |
| --- | --- |
| ![자동으로 계산된 절편 140을 가진 선형 추세선](intercept-automatic.png) | ![절편을 100으로 고정한 선형 추세선](intercept-fixed.png) |

두 이미지 모두 동일한 데이터와 축 스케일을 사용합니다. 추세선은 절편을 보여주기 위해 X = 0까지 뒤로 확장되었습니다.

기본적으로, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) 은 `NaN`을 반환합니다. 이는 절편이 지정되지 않았음을 의미하며, 0이 아닙니다. 절편은 이후 데이터에서 자동으로 계산됩니다.

## **사용자 정의 선 추가**

사용자 정의 선은 시리즈 데이터에서 계산된 추세선이 아니라 차트 위에 그려지는 도형입니다. 이 예제는 [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape)를 사용해 차트 위에 수평선을 슬라이드에 추가합니다. 선의 위치는 포인트 단위 슬라이드 좌표로 지정되어 차트의 왼쪽 가장자리에서 시작해 차트 중간에 놓이며, 너비는 차트 전체 너비와 일치합니다. [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) 메서드를 사용해 실선 빨간색 색상을 적용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**추세선의 '앞쪽' 및 '뒤쪽'은 무엇을 의미합니까?**

앞쪽/뒤쪽은 추세선을 앞이나 뒤로 투영한 길이입니다: 산점도(XY) 차트에서는 축 단위로, 비산점도 차트에서는 카테고리 수로 표시됩니다. 음수 값은 허용되지 않습니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 유지됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/) 또는 [SVG](/slides/ko/python-java/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다; 차트의 일부인 추세선은 이러한 작업 동안 유지됩니다. 차트 자체의 이미지를 [차트 이미지를 내보내기](/slides/ko/python-java/create-shape-thumbnails/)하는 메서드도 제공됩니다.