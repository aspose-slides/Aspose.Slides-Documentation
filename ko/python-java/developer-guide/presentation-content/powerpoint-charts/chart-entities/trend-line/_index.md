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
- 거듭제곱 추세선
- 사용자 정의 추세선
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java을 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 사용자 지정하세요 — 청중을 사로잡는 실용 가이드."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만들고, 차트 시리즈에 추세선을 추가하며, 지수형, 선형, 로그형, 이동 평균, 다항식 및 거듭제곱 등 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 선 모양을 삽입하여 차트에 사용자 정의 선을 추가하는 방법을 설명하고, 앞/뒤 추세선 투영 값과 추세선이 PDF 또는 SVG로 내보내거나 차트를 이미지로 렌더링할 때 유지되는지에 대한 간단한 FAQ를 포함합니다.

## **추세선 추가**

Aspose.Slides for Python via Java는 다양한 차트 추세선을 관리하기 위한 간단한 API를 제공합니다:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터와 원하는 유형으로 차트를 추가합니다(이 예제는 [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/#ClusteredColumn)을 사용합니다).
1. 차트 시리즈 1에 지수형 추세선을 추가합니다.
1. 차트 시리즈 1에 선형 추세선을 추가합니다.
1. 차트 시리즈 2에 로그형 추세선을 추가합니다.
1. 차트 시리즈 2에 이동 평균 추세선을 추가합니다.
1. 차트 시리즈 3에 다항식 추세선을 추가합니다.
1. 차트 시리즈 3에 거듭제곱 추세선을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 추세선이 포함된 차트를 생성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Presentation 클래스의 인스턴스를 생성합니다.
presentation = Presentation()
try:
    # 클러스터드 컬럼 차트를 생성합니다.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # 차트 시리즈 1에 지수형 추세선을 추가합니다.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # 차트 시리즈 1에 선형 추세선을 추가합니다.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # 차트 시리즈 2에 로그형 추세선을 추가합니다.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # 차트 시리즈 2에 이동 평균 추세선을 추가합니다.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # 차트 시리즈 3에 다항식 추세선을 추가합니다.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # 차트 시리즈 3에 거듭제곱 추세선을 추가합니다.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # 프레젠테이션을 저장합니다.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **사용자 정의 선 추가**

Aspose.Slides for Python via Java는 차트에 사용자 정의 선을 추가하기 위한 간단한 API를 제공합니다. 선택한 슬라이드의 차트에 일반 선을 추가하려면 다음 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- 인덱스로 슬라이드에 대한 참조를 가져옵니다.
- ShapeCollection 클래스의 [addChart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addChart) 메서드를 사용하여 새 차트를 생성합니다.
- [addAutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAutoShape) 메서드와 [ShapeType.Line](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapetype/#Line)를 사용하여 선 모양을 추가합니다.
- 도형 선의 색상을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 사용자 정의 선이 포함된 차트를 생성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Presentation 클래스의 인스턴스를 생성합니다.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**추세선에서 'forward'와 'backward'는 무엇을 의미하나요?**

이는 추세선을 앞이나 뒤로 연장한 길이를 의미합니다. 산점도(XY) 차트의 경우 축 단위로 측정되며, 비산점도 차트의 경우 카테고리 수로 측정됩니다. 음수 값은 허용되지 않습니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 유지되나요?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ko/python-java/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다. 차트의 일부인 추세선은 이러한 작업 중에 유지됩니다. 차트 자체의 이미지를 [내보내는](/slides/ko/python-java/create-shape-thumbnails/) 메서드도 제공됩니다.