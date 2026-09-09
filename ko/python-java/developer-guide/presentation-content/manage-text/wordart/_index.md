---
title: Python via Java에서 WordArt 효과 만들기 및 적용
linktitle: WordArt
type: docs
weight: 110
url: /ko/python-java/wordart/
keywords:
- 워드아트
- 워드아트 만들기
- 워드아트 템플릿
- 워드아트 효과
- 그림자 효과
- 반사 효과
- 발광 효과
- 워드아트 변환
- 3D 효과
- 외곽 그림자 효과
- 내부 그림자 효과
- 파워포인트
- 프레젠테이션
- 파이썬
- 자바
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 WordArt 효과를 만들고 맞춤화합니다. 이 단계별 가이드는 개발자가 Python via Java로 전문적인 텍스트를 사용해 프레젠테이션을 향상시킬 수 있도록 도와줍니다."
---
## **개요**

WordArt 효과를 사용하면 PowerPoint 프레젠테이션에 시각적으로 매력적이고 스타일리시한 텍스트를 추가할 수 있습니다. Aspose.Slides를 사용하면 개발자가 Microsoft PowerPoint와 마찬가지로 Office 없이도 프로그래밍 방식으로 WordArt를 생성, 사용자 지정 및 관리할 수 있습니다. 이 문서에서는 텍스트 변환, 채우기 스타일, 외곽선, 그림자 및 기타 서식 옵션을 적용하여 프레젠테이션 내용을 보다 표현력 있고 매력적으로 만드는 방법을 포함해 WordArt 작업에 대한 개요를 제공합니다. WordArt는 텍스트를 그래픽 개체처럼 다룰 수 있게 해줍니다. 텍스트를 보다 매력적이거나 눈에 띄게 만들기 위해 적용되는 효과 또는 특수 수정으로 구성됩니다.

## **간단한 WordArt 템플릿 만들고 텍스트에 적용하기**

**Aspose.Slides 사용**

먼저 다음 Python 코드를 사용해 간단한 텍스트를 생성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
다음으로 폰트 크기를 늘려 효과를 더 눈에 띄게 합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Microsoft PowerPoint 사용**

Microsoft PowerPoint에서 WordArt 효과 메뉴로 이동합니다:

![PowerPoint의 WordArt 효과 메뉴](image-20200930113926-1.png)

오른쪽 메뉴에서 미리 정의된 WordArt 효과를 선택할 수 있고, 왼쪽 메뉴에서 새 WordArt에 대한 설정을 지정할 수 있습니다.

다음은 사용할 수 있는 일부 매개변수 또는 옵션입니다:

![WordArt 서식 옵션](image-20200930114015-3.png)

**Aspose.Slides 사용**

다음 코드를 사용해 텍스트에 [PatternStyle.SmallGrid](https://reference.aspose.com/slides/ko/python-java/aspose.slides/patternstyle/#SmallGrid) 패턴 채우기를 적용하고 검은색 텍스트 테두리를 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

결과 텍스트:

![패턴 채우기와 검은 외곽선이 적용된 텍스트](image-20200930114108-4.png)

## **다른 WordArt 효과 적용하기**

**Microsoft PowerPoint 사용**

프로그램 인터페이스에서 텍스트, 텍스트 블록, 도형 또는 유사 요소에 다음 효과를 적용할 수 있습니다:

![PowerPoint의 텍스트 및 도형 효과](image-20200930114129-5.png)

예를 들어 그림자, 반사 및 발광 효과는 텍스트에 적용할 수 있고, 3D 서식 및 3D 회전 효과는 텍스트 블록에 적용할 수 있으며, 부드러운 가장자리 효과는 도형에 적용할 수 있습니다(3D 서식 효과가 설정되지 않아도 적용됩니다).

### **그림자 효과 적용**

다음 Python 코드는 텍스트에만 그림자 효과를 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Aspose.Slides API는 [OuterShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/innershadow/) 및 [PresetShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presetshadow/)의 세 가지 그림자 유형을 지원합니다.

[PresetShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presetshadow/)를 사용하면 미리 정의된 값을 통해 텍스트에 그림자를 적용할 수 있습니다.

**Microsoft PowerPoint 사용**

PowerPoint에서는 하나의 그림자 유형만 사용할 수 있습니다. 예시는 다음과 같습니다:

![PowerPoint의 그림자 설정](image-20200930114225-6.png)

**Aspose.Slides 사용**

Aspose.Slides는 실제로 두 가지 그림자 유형을 동시에 적용할 수 있습니다: [InnerShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/innershadow/) 및 [PresetShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presetshadow/)입니다.

**주의 사항:**

- [OuterShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/outershadow/)와 [PresetShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presetshadow/)을 동시에 사용할 경우, [OuterShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/outershadow/) 효과만 적용됩니다.
- [OuterShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/outershadow/)와 [InnerShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/innershadow/)을 동시에 사용할 경우, 적용되는 효과는 PowerPoint 버전에 따라 다릅니다. 예를 들어 PowerPoint 2013에서는 효과가 두 배가 되지만, PowerPoint 2007에서는 [OuterShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/outershadow/) 효과만 적용됩니다.

### **텍스트에 반사 적용**

다음 Python(Java) 코드 샘플을 통해 텍스트에 반사를 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **텍스트에 발광 효과 적용**

다음 코드를 사용해 텍스트에 발광 효과를 적용하여 빛나거나 돋보이게 합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

작업 결과:

![발광 효과가 적용된 텍스트](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
그림자, 반사 및 발광의 매개변수를 변경할 수 있습니다. 효과 속성은 텍스트의 각 부분에 별도로 설정됩니다.
{{% /alert %}}

### **WordArt에서 변환 사용**

전체 텍스트 블록을 변환하려면 [TextFrameFormat.setTransform](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setTransform)를 사용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

결과:

![아치 변환이 적용된 텍스트](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Microsoft PowerPoint와 Aspose.Slides for Python via Java 모두 미리 정의된 여러 변환 유형을 제공합니다.
{{% /alert %}}

**PowerPoint 사용**

미리 정의된 변환 유형에 접근하려면 **서식** → **텍스트 효과** → **변환**으로 이동합니다.

**Aspose.Slides 사용**

변환 유형을 선택하려면 [TextShapeType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textshapetype/) 열거형을 사용합니다.

### **텍스트 및 도형에 3D 효과 적용**

다음 샘플 코드를 사용해 텍스트 도형에 3D 효과를 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

결과 텍스트 및 도형:

![3D 효과가 적용된 텍스트 도형](image-20200930114816-9.png)

다음 Python 코드를 사용해 텍스트에 3D 효과를 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

작업 결과:

![3D 효과가 적용된 텍스트](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
텍스트 또는 도형에 3D 효과를 적용하고 효과 간 상호 작용은 특정 규칙에 따라 결정됩니다.

텍스트와 해당 텍스트를 포함하는 도형에 대한 장면을 고려하십시오. 3D 효과는 3D 객체 표현과 객체가 배치되는 장면을 포함합니다.

- 도형과 텍스트 모두에 장면이 설정된 경우, 도형 장면이 우선하며 텍스트 장면은 무시됩니다.
- 도형에 자체 장면이 없고 3D 표현만 있는 경우 텍스트 장면이 사용됩니다.
- 도형에 원래 3D 효과가 전혀 없을 경우, 도형은 평면이며 3D 효과는 텍스트에만 적용됩니다.

이 규칙은 [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getLightRig) 및 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getCamera) 메서드와 관련이 있습니다.
{{% /alert %}}

## **텍스트에 외곽 그림자 효과 적용**

Aspose.Slides for Python via Java는 [OuterShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/outershadow/) 및 [InnerShadow](https://reference.aspose.com/slides/ko/python-java/aspose.slides/innershadow/) 클래스를 제공하여 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)의 텍스트에 그림자 효과를 적용할 수 있습니다. 단계별로 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용해 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 사각형 도형을 추가합니다.
4. 도형에 연결된 텍스트 프레임에 접근합니다.
5. 도형 채우기를 비활성화합니다.
6. 외곽 그림자 효과를 활성화합니다.
7. 그림자 흐림 반경을 설정합니다.
8. 그림자 방향을 설정합니다.
9. 그림자 거리를 설정합니다.
10. 그림자를 왼쪽 위에 정렬합니다.
11. 그림자 색상을 검은색으로 설정합니다.
12. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.

위 단계의 구현 예시인 Python(Java) 샘플 코드는 텍스트에 외곽 그림자 효과를 적용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # 슬라이드에 대한 참조 가져오기
    slide = presentation.getSlides().get_Item(0)

    # 사각형 유형의 AutoShape 추가
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # 사각형에 TextFrame 추가
    auto_shape.addTextFrame("Aspose TextBox")

    # 텍스트 그림자를 얻기 위해 도형 채우기 비활성화
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # 외곽 그림자를 추가하고 모든 필요한 매개변수 설정
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # 프레젠테이션을 디스크에 저장
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **도형에 내부 그림자 효과 적용**

다음 단계대로 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드에 대한 참조를 가져옵니다.
3. 사각형 도형을 추가합니다.
4. 내부 그림자 효과를 활성화합니다.
5. 모든 필요한 매개변수를 설정합니다.
6. 그림자 색상 유형을 테마 색상으로 설정합니다.
7. 테마 색상을 지정합니다.
8. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.

위 단계에 기반한 샘플 코드는 Python(Java)에서 도형 안의 텍스트에 내부 그림자 효과를 적용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # 슬라이드에 대한 참조 가져오기
    slide = presentation.getSlides().get_Item(0)

    # 사각형 유형의 AutoShape 추가
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # 사각형에 TextFrame 추가
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # InnerShadowEffect 활성화
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # 필요한 모든 매개변수 설정
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # ColorType을 Scheme으로 설정
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Scheme 색상 설정
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # 프레젠테이션 저장
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**다양한 글꼴이나 스크립트(예: 아랍어, 중국어)에서도 WordArt 효과를 사용할 수 있나요?**

예, Aspose.Slides는 유니코드를 지원하며 모든 주요 글꼴 및 스크립트와 함께 작동합니다. 언어에 관계없이 그림자, 채우기 및 외곽선과 같은 WordArt 효과를 적용할 수 있지만, 글꼴 가용성 및 렌더링은 시스템에 설치된 글꼴에 따라 달라질 수 있습니다.

**슬라이드 마스터 요소에도 WordArt 효과를 적용할 수 있나요?**

예, 마스터 슬라이드의 도형(제목 자리 표시자, 바닥글 또는 배경 텍스트 포함)에 WordArt 효과를 적용할 수 있습니다. 마스터 레이아웃에 대한 변경 사항은 해당 슬라이드에 연결된 모든 슬라이드에 반영됩니다.

**WordArt 효과가 프레젠테이션 파일 크기에 영향을 줍니까?**

조금 영향을 줍니다. 그림자, 발광 및 그라디언트 채우기와 같은 WordArt 효과는 추가 서식 메타데이터로 인해 파일 크기를 약간 늘릴 수 있지만, 차이는 일반적으로 무시할 수준입니다.

**프레젠테이션을 저장하지 않고 WordArt 효과 결과를 미리 볼 수 있나요?**

예, [Shape.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage) 또는 [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)를 사용해 WordArt가 포함된 슬라이드를 이미지(PNG, JPEG 등)로 렌더링할 수 있습니다. 이를 통해 전체 프레젠테이션을 저장하거나 내보내기 전 메모리 내 또는 화면에서 결과를 미리 볼 수 있습니다.