---
title: 차트
type: docs
weight: 60
url: /ko/python-java/examples/elements/chart/
keywords:
- 차트
- 차트 추가
- 차트 접근
- 차트 제거
- 차트 업데이트
- 코드 예제
- 파워포인트
- 오픈문서
- 프레젠테이션
- 파이썬
- 자바
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 차트를 생성하고 액세스하며 제거하고 업데이트합니다."
---
이 문서는 **Aspose.Slides for Python via Java**를 사용하여 프레젠테이션에 차트를 추가, 액세스, 제거 및 업데이트하는 방법을 보여줍니다.

[Installation](/slides/ko/python-java/installation/)에 설명된 대로 패키지를 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후 API를 가져옵니다. 나머지 예제를 위해 `chart.pptx`를 생성하려면 먼저 추가 예제를 실행하십시오.

## **차트 추가**

첫 번째 슬라이드에 영역 차트를 추가하고 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 첫 번째 슬라이드에 영역 차트를 추가합니다.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트 접근**

첫 번째 슬라이드의 도형 컬렉션에서 첫 번째 차트를 찾습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 슬라이드에서 첫 번째 차트에 접근합니다.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **차트 제거**

슬라이드에서 첫 번째 차트를 제거하고 수정된 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 슬라이드에서 첫 번째 차트를 찾고 제거합니다.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트 데이터 업데이트**

차트 제목을 표시하고 텍스트를 변경한 뒤, 업데이트된 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 슬라이드에서 첫 번째 차트를 찾습니다.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # 차트 제목을 표시하고 텍스트를 변경합니다.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```