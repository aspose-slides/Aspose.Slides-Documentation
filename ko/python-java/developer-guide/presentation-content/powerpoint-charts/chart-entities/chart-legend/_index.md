---
title: Python을 사용하여 프레젠테이션에서 차트 범례 사용자 지정
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
description: "Aspose.Slides for Python via Java를 사용하여 차트 범례를 사용자 지정하고 맞춤형 범례 서식으로 PowerPoint 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides는 PowerPoint 프레젠테이션의 차트 범례를 사용자 지정할 수 있는 옵션을 제공합니다. 이 기사에서는 범례의 위치와 크기를 지정하고, 전체 범례의 글꼴 크기를 설정하며, 개별 범례 항목에 서식을 적용하는 방법을 보여줍니다.

또한 FAQ에서 여러 관련 동작을 다루는데, 범례가 겹치지 않도록 비오버레이 모드를 사용하여 플롯 영역에 범례를 위한 공간을 확보하고, 긴 범례 레이블이 자동으로 줄 바꿈되거나 줄 바꿈 문자를 사용할 수 있게 하며, 명시적인 텍스트 및 채우기 설정이 없을 경우 범례 서식이 프레젠테이션 테마에서 상속되도록 합니다.

## **범례 위치 지정**

범례 속성을 설정하려면 다음 단계를 따르세요:

1. [프레젠테이션](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 차트를 추가합니다.
1. 범례 속성을 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 예제는 차트 범례의 위치와 크기를 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 빈 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # 슬라이드에 대한 참조를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 슬라이드에 클러스터형 열 차트를 추가합니다.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # 범례 속성을 설정합니다.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **범례의 글꼴 크기 설정**

Aspose.Slides for Python via Java를 사용하면 범례의 글꼴 크기를 설정할 수 있습니다. 다음 단계를 따르세요:

1. [프레젠테이션](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 기본 차트를 생성합니다.
1. 글꼴 크기를 설정합니다.
1. 최소 축 값을 설정합니다.
1. 최대 축 값을 설정합니다.
1. 프레젠테이션을 디스크에 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 빈 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **개별 범례 항목의 글꼴 크기 설정**

Aspose.Slides for Python via Java를 사용하면 개별 범례 항목의 글꼴 크기를 설정할 수 있습니다. 다음 단계를 따르세요:

1. [프레젠테이션](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 기본 차트를 생성합니다.
1. 범례 항목에 접근합니다.
1. 글꼴 크기를 설정합니다.
1. 프레젠테이션을 디스크에 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# 빈 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**차트가 범례를 겹치지 않고 자동으로 공간을 할당하도록 범례를 활성화할 수 있나요?**

예. `False`와 함께 [setOverlay](https://reference.aspose.com/slides/ko/python-java/aspose.slides/legend/#setOverlay) 메서드를 사용하면 비오버레이 모드를 활성화할 수 있습니다. 이 경우 플롯 영역이 축소되어 범례를 수용합니다.

**다중 라인 범례 레이블을 만들 수 있나요?**

예. 공간이 부족할 경우 긴 레이블이 자동으로 줄바꿈되며, 시리즈 이름에 개행 문자(`\n`)를 넣어 강제 줄 바꿈도 지원됩니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르게 하려면 어떻게 해야 하나요?**

범례와 그 텍스트에 명시적인 색상, 채우기 또는 글꼴을 설정하지 마세요. 그러면 테마에서 상속받아 디자인이 변경될 때 올바르게 업데이트됩니다.