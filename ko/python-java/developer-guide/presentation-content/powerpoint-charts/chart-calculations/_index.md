---
title: Python via Java에서 프레젠테이션을 위한 차트 계산 최적화
linktitle: 차트 계산
type: docs
weight: 50
url: /ko/python-java/chart-calculations/
keywords:
- 차트 계산
- 차트 요소
- 요소 위치
- 실제 위치
- 자식 요소
- 상위 요소
- 차트 값
- 실제 값
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 PPT 및 PPTX 용 차트 계산, 데이터 업데이트 및 정밀 제어를 이해하고 실용적인 Python 코드 예제를 제공합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 차트 계산 및 레이아웃 데이터를 처리하기 위한 API를 제공합니다. 이 문서에서는 차트 요소의 실제 값, 즉 차트 요소의 실제 위치와 크기 및 차트 축의 실제 값을 가져오는 방법을 보여줍니다. 또한 이러한 값은 차트 레이아웃 검증 후에 채워진다는 점을 설명합니다.

또한 이 문서에서는 상위 차트 요소의 실제 위치를 가져오는 방법과 제목, 축, 범례 및 눈금선과 같은 차트 구성 요소를 숨기는 방법을 설명합니다. 이러한 예제를 통해 차트 레이아웃 정보를 검토하고 PowerPoint 프레젠테이션에서 차트 요소의 표시 여부를 프로그래밍 방식으로 제어할 수 있습니다.

## **차트 요소의 실제 값 계산**
Aspose.Slides for Python via Java는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. [Axis](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/) 클래스의 메서드는 차트 축의 실제 값([getActualMaxValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/#getActualMaxValue),[getActualMinValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/#getActualMinValue),[getActualMajorUnit](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/#getActualMajorUnit),[getActualMinorUnit](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/#getActualMinorUnit),[getActualMajorUnitScale](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/#getActualMajorUnitScale),[getActualMinorUnitScale](https://reference.aspose.com/slides/ko/python-java/aspose.slides/axis/#getActualMinorUnitScale))에 대한 정보를 제공합니다. 먼저 [Chart.validateChartLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#validateChartLayout) 메서드를 호출하여 이러한 속성을 실제 값으로 채워야 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **상위 차트 요소의 실제 위치 계산**
Aspose.Slides for Python via Java는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. [ChartPlotArea](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartplotarea/) 클래스의 메서드는 차트 플롯 영역의 실제 위치와 크기([getActualX](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartplotarea/#getActualX),[getActualY](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartplotarea/#getActualY),[getActualWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartplotarea/#getActualWidth),[getActualHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartplotarea/#getActualHeight))에 대한 정보를 제공합니다. 먼저 [Chart.validateChartLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#validateChartLayout) 메서드를 호출하여 이러한 속성을 실제 값으로 채워야 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **차트 요소 숨기기**
이 섹션에서는 차트에서 정보를 숨기는 방법을 설명합니다. Aspose.Slides for Python via Java를 사용하면 **제목, 수직 축, 수평 축**, 및 **눈금선**을 숨길 수 있습니다. 다음 코드 예제는 이러한 속성을 사용하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # 차트 제목 숨기기.
    chart.setTitle(False)

    # 값 축 숨기기.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # 카테고리 축 숨기기.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # 범례 숨기기.
    chart.setLegend(False)

    # 주요 격자선 숨기기.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # 첫 번째 시리즈만 유지합니다. 끝에서 제거하면 남은 인덱스가 유효하게 유지됩니다.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # 시리즈 선 색상 설정.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**외부 Excel 워크북을 데이터 소스로 사용할 수 있으며, 재계산에 어떤 영향을 줍니까?**

예. 차트는 외부 워크북을 참조할 수 있습니다. 외부 소스를 연결하거나 새로 고치면 해당 워크북에서 수식과 값이 가져와지며, 차트는 열기/편집 작업 중에 업데이트를 반영합니다. API를 사용하면 [외부 워크북 지정](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setExternalWorkbook) 경로를 지정하고 연결된 데이터를 관리할 수 있습니다.

**회귀를 직접 구현하지 않고도 추세선을 계산하고 표시할 수 있나요?**

예. [Trendlines](/slides/ko/python-java/trend-line/) (선형, 지수 등) 은 Aspose.Slides에 의해 추가 및 업데이트되며, 매개변수는 시리즈 데이터에서 자동으로 재계산되므로 직접 계산을 구현할 필요가 없습니다.

**프레젠테이션에 외부 링크가 있는 차트가 여러 개 있는 경우, 각 차트가 사용한 워크북을 제어할 수 있나요?**

예. 각 차트는 자체 [external workbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setExternalWorkbook)을 지정할 수 있으며, 차트별로 외부 워크북을 독립적으로 생성하거나 교체할 수 있습니다.