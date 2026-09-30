---
title: 프레젠테이션에서 Python을 사용해 차트 범례 맞춤 설정
linktitle: 차트 범례
type: docs
url: /ko/python-java/chart-legend/
keywords:
- 차트 범례
- 범례 위치
- 글꼴 크기
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용해 맞춤형 범례 서식으로 PowerPoint 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides for Python via Java는 PowerPoint 프레젠테이션에서 차트 범례를 사용자 지정할 수 있는 옵션을 제공합니다. 이 문서에서는 범례를 위치시키고 크기를 지정하는 방법, 전체 범례의 글꼴 크기를 설정하는 방법, 개별 범례 항목을 서식 지정하는 방법, 선택한 항목을 숨기거나 복원하는 방법을 보여줍니다.

FAQ에서는 범례를 위한 공간을 예약하기, 다중 라인 레이블 표시하기, 프레젠테이션 테마에서 서식을 상속받기 등 관련 동작을 다룹니다.

## **범례 위치 지정**

차트 크기의 비율로 범례의 위치와 크기를 지정하려면 범례의 [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth), 및 [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) 메서드를 사용합니다.

이 예제는 프레젠테이션을 만들고 첫 번째 슬라이드에 기본 데이터가 포함된 클러스터드 열 차트를 추가합니다. 원하는 범례 오프셋과 크기를 차트 너비와 높이로 나누어 상대값으로 변환합니다: 범례는 차트 왼쪽 상단 모서리에서 50 포인트만큼 오프셋되고 크기는 100 × 100 포인트로 지정됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # 차트에 대한 상대적인 범례 위치와 크기를 지정합니다.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **범례의 글꼴 크기 설정**

범례의 [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) 메서드를 사용하여 텍스트 서식을 가져오고, [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) 메서드로 글꼴 크기를 포인트 단위로 설정합니다.

이 예제는 기본 데이터가 포함된 차트를 만든 뒤 범례 텍스트의 크기를 20 포인트로 지정합니다. 또한 수직 축에 대한 자동 경계를 비활성화하고 범위를 -5에서 10으로 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **개별 범례 항목의 글꼴 크기 설정**

범례의 [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) 메서드가 반환하는 컬렉션을 사용하여 특정 항목의 서식에 접근합니다. 항목 인덱스는 0부터 시작하므로 인덱스 `1`은 두 번째 항목을 의미합니다.

이 예제는 기본 데이터에 최소 두 개의 시리즈가 포함된 클러스터드 열 차트를 생성합니다. 두 번째 범례 항목을 굵게, 기울임꼴, 20포인트 파란색 텍스트로 서식 지정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **개별 범례 항목 숨기기**

보조 시리즈를 데이터는 그대로 두면서 범례에서 제외하려면 [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry) 를 통해 얻은 항목에 대해 [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) 를 `True` 로 호출합니다. 이렇게 하면 선택한 범례 항목만 숨겨지고 시리즈나 데이터 포인트는 제거되지 않습니다. 반대로 [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) 를 `False` 로 호출하면 전체 범례가 숨겨집니다.

아래 예제는 기본 데이터를 사용해 여러 시리즈가 포함된 클러스터드 열 차트를 만든 후 두 번째 시리즈의 범례 항목(인덱스 `1`)을 숨기고 프레젠테이션을 저장합니다. 그런 다음 `False` 로 [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) 를 호출해 항목을 복원하고 두 번째 사본을 저장합니다. 두 파일 모두에서 열은 그대로 표시됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # 차트 데이터를 변경하지 않고 같은 항목을 복원합니다.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

아래 비교는 모든 항목이 표시된 차트와 두 번째 항목이 숨겨진 차트를 보여줍니다. 두 번째 시리즈의 열은 변함없이 유지됩니다.

![모든 범례 항목이 표시된 차트와 범례에서 시리즈 2가 숨겨진 차트 비교; 모든 열은 계속 표시됩니다.](hide-legend-entry.png)

열, 막대 및 선 차트에서는 범례 항목이 시리즈를 식별합니다. 파이 차트에서는 개별 데이터 포인트(슬라이스)를 식별하므로 선택한 슬라이스에 대해 [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) 를 사용합니다. API 문서에는 `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, `BarOfPie` 차트 유형에 대한 데이터 포인트 메서드가 명시되어 있습니다. 도넛 차트에는 해당 메서드가 포함되지 않으므로 적용되지 않는다고 가정하지 마십시오.

## **FAQ**

**차트가 범례를 겹치지 않고 공간을 할당하도록 할 수 있나요?**  
예. [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) 를 `False` 로 호출하면 범례가 플롯 영역과 겹치는 대신 공간을 예약합니다.

**멀티라인 범례 레이블을 만들 수 있나요?**  
예. 사용 가능한 너비가 충분하지 않을 경우 긴 레이블이 자동으로 줄바꿈됩니다. 또한 시리즈 이름에 줄바꿈 문자를 삽입해 강제로 줄을 나눌 수 있습니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르게 하려면 어떻게 해야 하나요?**  
범례의 색상, 채우기 및 글꼴을 설정하지 않고 그대로 두면 테마 서식을 상속받습니다. 명시적인 서식 지정은 해당 테마 설정을 우선 적용합니다.