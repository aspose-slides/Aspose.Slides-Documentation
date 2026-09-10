---
title: Python을 사용한 프레젠테이션의 버블 차트 맞춤화
linktitle: 버블 차트
type: docs
url: /ko/python-java/bubble-chart/
keywords:
- 버블 차트
- 버블 크기
- 크기 스케일링
- 크기 표현
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint에서 강력한 버블 차트를 만들고 맞춤화하여 데이터 시각화를 쉽게 향상시킵니다."
---
## **개요**

이 문서는 Aspose.Slides에서 버블 차트를 사용하는 방법을 보여줍니다. 여기서는 두 가지 특정 사용자 지정 옵션을 다룹니다: [setBubbleSizeScale](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) 메서드를 통한 버블 크기 스케일링 및 [setBubbleSizeRepresentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) 메서드를 통한 버블 크기 값 표시 방식 제어.

예제는 버블 차트를 생성하고, 크기 스케일을 조정하며, 버블 크기 표시 방식을 너비로 전환하는 방법을 보여줍니다. 또한 이 문서는 “Bubble with 3-D”(3D 효과가 있는 버블 차트) 유형 지원 여부를 명확히 하고, 실용적인 차트 제한이 성능 및 대상 PowerPoint 버전에 따라 달라짐을 언급하며, 내보내기가 Aspose.Slides 렌더링 엔진을 통해 차트 외관을 유지한다는 내용을 포함한 짧은 FAQ 섹션을 제공합니다.

## **버블 차트 크기 스케일링**
Aspose.Slides for Python via Java는 [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale), 그리고 [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) 메서드를 통해 버블 차트 크기 스케일링을 지원합니다. 다음 예제는 버블 크기를 스케일링하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **버블 차트 크기로 데이터 표시**
[**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) 및 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) 메서드는 [ChartSeriesGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/) 클래스에서 사용할 수 있습니다. 버블 크기 표시 방식은 버블 차트에서 버블 크기 값이 어떻게 표시되는지를 지정합니다. 가능한 값은 [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/ko/python-java/aspose.slides/bubblesizerepresentationtype/#Area)와 [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/ko/python-java/aspose.slides/bubblesizerepresentationtype/#Width)입니다. [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/ko/python-java/aspose.slides/bubblesizerepresentationtype/) 열거형은 데이터를 버블 차트 크기로 표시하는 가능한 방식을 지정합니다. 다음 예제는 너비를 사용하여 버블 크기를 표시하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **자주 묻는 질문**

**"3-D 효과가 있는 버블 차트"가 지원되며 일반 차트와 어떻게 다릅니까?**

네. 별도의 차트 유형인 “Bubble with 3-D”가 제공됩니다. 이 유형은 버블에 3-D 스타일을 적용하지만 추가 축을 만들지는 않으며, 데이터는 X‑Y‑S(크기) 형태로 유지됩니다. 해당 유형은 [chart type](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/) 클래스에서 사용할 수 있습니다.

**버블 차트에서 시리즈와 데이터 포인트 수에 제한이 있습니까?**

API 수준에서 강제된 제한은 없으며, 제한은 성능 및 대상 PowerPoint 버전에 따라 달라집니다. 가독성과 렌더링 속도를 고려하여 데이터 포인트 수를 적절히 유지하는 것이 권장됩니다.

**내보내기가 버블 차트의 외관에 어떤 영향을 줍니까( PDF, 이미지 등)?**

지원되는 형식으로 내보내면 차트의 외관이 유지됩니다. 렌더링은 Aspose.Slides 엔진이 수행합니다. 래스터/벡터 형식의 경우 일반 차트 그래픽 렌더링 규칙(해상도, 안티앨리어싱 등)이 적용되므로 인쇄용으로 충분한 DPI를 선택해야 합니다.