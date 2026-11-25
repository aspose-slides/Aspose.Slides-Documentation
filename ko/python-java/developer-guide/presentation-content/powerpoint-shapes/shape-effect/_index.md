---
title: Python via Java를 사용한 프레젠테이션에서 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/python-java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 광채 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들세요."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/python-java/shape-formatting/#gradient-fill)나 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 실감 나는 반사 효과를 만들거나, 도형의 발광을 확산시킬 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 6가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

효과 조합 중 일부는 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. Preset 옵션은 보기 좋은 두 개 이상의 효과 조합입니다. 따라서 프리셋을 선택하면 다양한 효과를 테스트하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있는 [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) 클래스 아래에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for Python via Java는 도형에 대한 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에 대비되어 돋보이게 할 수 있습니다. 그림자는 도형의 가장자리를 넘어 확장되어 도형이 슬라이드 위에 떠 있는 인상을 줍니다. 템플릿의 조명 및 스타일에 맞게 색상, 방향, 거리 및 흐림 반경을 조정하십시오.

다음 Python 코드는 사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect)를 적용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![그림자 효과](shadow_effect.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때 내부 그림자를 사용하면 카드나 패널에 움푹 들어간 모습을 부여할 수 있습니다. 외부 그림자는 도형 밖으로 확장되어 도형이 떠 있는 것처럼 보이게 하는 반면, 내부 그림자는 가장자리 내부를 음영 처리합니다.

[enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect)를 호출한 다음 [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect)에서 반환된 그림자를 구성합니다. 흐림 반경 값이 클수록 가장자리가 부드러워집니다.

다음 Python 예제는 연파란 카드를 어두운 회색 내부 그림자와 함께 만들고 PPTX 파일로 저장합니다. 그림자 방향은 225도, 거리 7포인트, 흐림 반경 6포인트입니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![내부 그림자가 있는 연파란 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 EffectFormat에서 [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect)를 호출하십시오.

### **프리셋 그림자 적용, 변경 및 제거**

[enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect)를 호출한 다음 [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset)으로 [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/)을 선택합니다. 동일한 도형에서 프리셋을 변경하여 스타일을 전환할 수 있습니다. [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect)를 호출하면 채우기와 외곽선을 유지하면서 그림자를 제거합니다.

예제는 각 단계에서 사각형을 복제하여 한 슬라이드에 네 가지 상태를 나란히 비교할 수 있게 합니다. 두 그림자는 모두 10포인트씩 오프셋됩니다. 225° 방향은 첫 번째 그림자를 사각형 위쪽 및 왼쪽에 배치하고, 45° 방향은 두 번째 그림자를 아래쪽 및 오른쪽에 배치합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 원본 | 첫 번째 프리셋 | 두 번째 프리셋 | 제거 후 |
| :---: | :---: | :---: | :---: |
| ![그림자 없음](preset_shadow_original.png) | ![좌상단 그림자](preset_shadow_top_left.png) | ![우하단 그림자](preset_shadow_bottom_right.png) | ![제거 후 그림자 없음](preset_shadow_removed.png) |

## **반사 효과 적용**

Aspose.Slides for Python via Java에서 반사 효과를 적용하려면 도형에 거울 같은 반사를 추가하고 거리, 투명도, 크기와 같은 매개변수를 조정할 수 있습니다. 이 효과는 도형에 보다 세련되고 고급스러운 외관을 제공하여 프레젠테이션의 미학을 향상시킵니다. 간단한 코드로 손쉽게 구현할 수 있어 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

다음 Python 코드는 도형에 [반사 효과](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect)를 적용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![반사 효과](reflection_effect.png)

## **광채 효과 적용**

Aspose.Slides for Python via Java에서 도형에 광채 효과를 적용하면 부드럽고 빛나는 후광을 도형 주위에 추가할 수 있으며, 색상 및 크기와 같은 속성을 조정할 수 있습니다. 이 효과는 도형을 강조하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 더해 줍니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 Python 코드는 도형에 [광채 효과](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect)를 적용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![광채 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for Python via Java에서 부드러운 가장자리 효과를 적용하면 도형 가장자리 주위에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 미묘하고 정교한 외관을 제공하여 부드러운 외관이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 얻을 수 있습니다.

다음 Python 코드는 도형에 [부드러운 가장자리 효과](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect)를 적용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![부드러운 가장자리 효과](soft_edges_effect.png)

## **블러 효과 적용**

도형 블러를 사용하면 도형의 채우기와 외곽선을 부드럽게 할 수 있지만 도형 자체는 편집 가능하게 유지됩니다. 도형의 EffectFormat에서 [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect)를 호출하십시오. 반경은 포인트(1/72인치) 단위로 측정되며, 값이 클수록 블러가 강해집니다. 반경이 0이면 외관에 변화가 없습니다.

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) 설정은 효과의 가시 경계를 제어합니다. `False`이면 블러가 원래 그린 경계(외곽선 포함) 안으로 클리핑되고, `True`이면 경계를 넘어 확장될 수 있습니다. 어느 설정도 도형의 위치나 크기를 변경하지 않습니다.

아래 비교는 전체에 동일한 채우기, 외곽선 및 도형 크기를 사용합니다. 상단 행은 `grow = False`를, 하단 행은 `grow = True`를 사용합니다.

![블러 반경 5포인트와 15포인트, grow 비활성화 및 활성화 상태를 비교한 원본 사각형](shape_blur_comparison.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 Python 예제는 주황색 사각형에 어두운 파란색 외곽선을 만들고 5포인트 블러를 적용한 뒤, 다시 [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect)를 호출하여 15포인트 블러로 업데이트합니다. 두 블러 상태를 모두 저장한 후 [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect)를 호출하여 블러가 없는 도형을 저장합니다.

도형 블러는 채우기와 외곽선을 함께 영향을 미칩니다. 부드러운 가장자리 효과는 도형 가장자리를 흐리게 하며, 그림자 블러는 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 내용에 적용되지만, 이 예제는 도형을 이미지로 변환하지 않고 직접 도형의 EffectFormat에 블러를 적용합니다.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 광채 등 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형 전체에 효과를 적용할 수 있습니다. 효과는 그룹 전체에 적용됩니다.