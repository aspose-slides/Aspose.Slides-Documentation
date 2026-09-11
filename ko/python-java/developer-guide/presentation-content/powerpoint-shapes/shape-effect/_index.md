---
title: Python을 Java와 함께 사용하여 프레젠테이션에 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/python-java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 글로우 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint에서 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/python-java/shape-formatting/#gradient-fill) 또는 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사 효과를 만들거나, 도형에 글로우를 퍼뜨리는 등 다양한 시각적 효과를 구현할 수 있습니다.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.  

* 일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. 프리셋 옵션은 보기 좋은 두 개 이상의 효과 조합을 미리 정의한 것입니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하여 멋진 조합을 찾는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 [EffectFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effectformat/) 클래스 아래에 속성 및 메서드를 제공하여 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있게 합니다.

## **그림자 효과 적용**

다음 Python 코드는 사각형에 외부 그림자 효과([EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effectformat/#getOuterShadowEffect))를 적용하는 방법을 보여 줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **반사 효과 적용**

다음 Python 코드는 도형에 반사 효과를 적용하는 방법을 보여 줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **글로우 효과 적용**

다음 Python 코드는 도형에 글로우 효과를 적용하는 방법을 보여 줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **소프트 엣지 효과 적용**

다음 Python 코드는 도형에 소프트 엣지 효과를 적용하는 방법을 보여 줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

네, 그림자, 반사, 글로우 등 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 모습을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

네, 그룹화된 도형 전체에 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.