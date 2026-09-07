---
title: Python을 사용하여 프레젠테이션에 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/python-java/3d-presentation/
keywords:
- 3D 파워포인트
- 3D 프레젠테이션
- 3D 회전
- 3D 깊이
- 3D 압출
- 3D 그라디언트
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java를 통해 Python에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Python via Java는 도형 및 텍스트에 대해 PowerPoint 스타일의 3D 서식을 만들고, 편집하고, 보존하고, 렌더링할 수 있습니다. 이 문서는 회전, 압출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="Note" %}}

이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것이며, 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.

{{% /alert %}}

[Installation](/slides/ko/python-java/installation/)에 설명된 대로 패키지를 설치합니다. 각 예제는 `asposeslides`를 가져오고, 필요하면 JVM을 시작한 뒤 API를 가져옵니다. 그림 채우기 예제는 작업 디렉터리에 `image.jpg` 파일이 있어야 합니다.

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [Shape.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getThreeDFormat) 를 사용하십시오. 반환된 서식 객체는 해당 도형의 3D 장면을 제어합니다.

텍스트의 경우 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#getThreeDFormat) 를 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getCamera) | 시점, 미리 설정된 카메라 유형, 회전, 확대/축소 및 원근법. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 프리셋에 맞출 때. |
| [getLightRig](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getLightRig) | 조명 프리셋, 방향 및 조명 회전. | 3D 표면의 하이라이트와 그림자 표시 방식을 변경할 때. |
| [getMaterial](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getMaterial) 및 [setMaterial](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setMaterial) | 평면, 무광, 플라스틱, 금속 등 표면 재질. | 동일한 형상을 더 평평하게, 부드럽게, 광택 있게 또는 금속처럼 보이게 할 때. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getExtrusionHeight) 및 [setExtrusionHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 도형 앞면으로부터 뒤쪽으로 얼마나 뻗어 있는지. | 평면 도형을 눈에 보이는 두께가 있는 3D 객체로 만들 때. |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getExtrusionColor) | 압출된 면의 색상. | 깊이를 가시화하거나 앞면 채우기와 색을 맞출 때. |
| [getDepth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getDepth) 및 [setDepth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 도형이나 텍스트에 깊이를 미세 조정할 때, 특히 베벨 및 재질 설정과 함께 사용. |
| [getBevelTop](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getBevelTop) 및 [getBevelBottom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getBevelBottom) | 앞면 및 뒷면 가장자리에 적용되는 돌출 또는 둥근 모서리. | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가할 때. |
| [getContourColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getContourWidth), 및 [setContourWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setContourWidth) | 3D 객체 주변의 외곽선. | 렌더링된 출력에서 객체 경계를 강조하고 싶을 때. |

## **3D 도형 만들기**

도형이 설득력 있게 3D로 보이려면 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정 – 기본 전면 뷰에서는 압출이 가려질 수 있습니다.
- 조명 설정 – 조명이 면과 측면을 읽기 쉽게 만듭니다.
- 재질 설정 – 표면이 빛에 어떻게 반응하는지를 결정합니다.
- 압출 또는 깊이 설정 – 평면 도형에 두께가 필요합니다.

다음 예제는 사각형을 만들고, 앞면에 텍스트를 추가하고, 3D 서식을 적용한 뒤 프레젠테이션을 PPTX로 저장하고 슬라이드를 PNG 이미지로 렌더링합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

렌더링된 슬라이드 이미지는 두꺼운 3D 블록 형태의 사각형을 보여줍니다:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3D 회전은 3‑D Rotation 패널에서 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전과 동일합니다.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides에서는 [Shape.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getThreeDFormat) 로 반환된 3D 서식을 통해 카메라 유형과 회전을 설정합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

시청자가 객체를 보는 방식을 바꿀 필요가 있을 때 카메라를 사용합니다. 이는 슬라이드의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

## **압출 및 깊이 추가하기**

압출은 앞면 뒤쪽으로 도형을 연장시켜 두꺼워 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 색상을 설정합니다.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

두께를 위한 압출 높이와 측면 색상을 위한 압출 색상을 설정합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

PowerPoint의 깊이 값을 직접 사용하거나 깊이를 베벨, 재질, 텍스트 효과와 결합해야 할 때 깊이 설정을 사용합니다. 많은 도형 시나리오에서 압출 높이가 가시적인 압출을 직접 표현하므로 더 명확한 설정입니다.

## **그라디언트 또는 그림 채우기와 3D 효과 사용하기**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

다음 예제는 도형에 그라디언트 채우기를 적용하고 측면에 더 어두운 압출 색을 사용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

렌더링된 출력은 앞면에 그라디언트를 유지하고 압출을 별도로 렌더링합니다:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

그림 채우기를 사용하려면 그림을 프레젠테이션에 추가하고 도형 채우기에 할당합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

그림은 앞면에 렌더링되고, 압출은 3D 측면 표면으로 렌더링됩니다:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 압출, 재질, 조명, 카메라 설정이 필요한 WordArt와 유사한 효과에 유용합니다.

다음 예제는 패턴 채우기가 적용된 텍스트를 만들고, WordArt 변환을 적용하고, [TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 에 3D 설정을 구성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

텍스트는 곡선형이며 압출된 3D 레터링으로 렌더링됩니다:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 2D 결과로 래스터화되거나 그려집니다. 이는 슬라이드를 PNG로 렌더링하거나 PDF, HTML로 내보내거나 비디오 변환용 프레임을 생성할 때 모두 적용됩니다.

다음 사항을 기억하세요:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 내보낸 후에는 사용자가 객체를 회전할 수 없습니다.
- 최종 외형은 카메라, 라이트 릭, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인하려면 유효 서식 API를 사용하십시오.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 렌더링되어 저장되며 편집 가능한 3D 설정은 보존되지 않습니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형 및 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 사용자가 회전할 수 있는 인터랙티브 3D 장면으로 만들지는 못합니다. PPTX에서는 3D 서식이 지원되는 경우 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이는 무엇인가요?**

3D 모델은 프레젠테이션에 삽입된 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 서식으로, 회전, 압출, 베벨, 조명, 재질 등이 포함됩니다. 이 문서는 3D 효과에 대해 다룹니다.

**가시적인 3D 도형을 만들기 위해 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 압출 또는 깊이 중 하나를 설정해야 합니다. 실제로는 라이트 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 도형 본문에는 [Shape.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getThreeDFormat), 텍스트에는 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#getThreeDFormat) 를 사용하십시오.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 표시되나요?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환용 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 외형이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽으려면 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getEffective) 를 사용하십시오.