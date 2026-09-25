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
- 3D 돌출
- 3D 그라디언트
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python via Java에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Python via Java는 도형 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 생성, 편집, 보존 및 렌더링할 수 있습니다. 이 문서는 회전, 돌출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 그리고 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="Note" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 것에 대해서는 다루지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때, Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [Shape.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getThreeDFormat) 메서드를 사용합니다. 이 메서드는 해당 도형의 3D 장면을 제어하는 [ThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/)을 반환합니다.

텍스트의 경우 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#getThreeDFormat) 메서드를 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getCamera) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근. | 3D 공간에서 객체를 회전시키거나 PowerPoint 3D 회전 사전 설정에 맞춥니다. |
| [getLightRig](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getLightRig) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면에서 하이라이트와 그림자가 표시되는 방식을 변경합니다. |
| [getMaterial](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getMaterial)와 [setMaterial](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setMaterial) | 평평, 무광, 플라스틱 또는 금속과 같은 표면 재질. | 같은 형상을 더 평평하게, 부드럽게, 광택이 나게, 혹은 금속처럼 보이게 합니다. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getExtrusionHeight)와 [setExtrusionHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 도형이 전면에서 뒤쪽으로 얼마나 확장되는지. | 평면 도형을 눈에 보이는 두꺼운 3D 객체로 전환합니다. |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getExtrusionColor) | 돌출된 측면의 색상. | 깊이를 가시화하거나 측면 색을 전면 채우기와 일치시킵니다. |
| [getDepth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getDepth)와 [setDepth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 특히 베벨 및 재질 설정과 함께 도형 또는 텍스트의 깊이를 미세 조정합니다. |
| [getBevelTop](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getBevelTop)와 [getBevelBottom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getBevelBottom) | 전면 및 후면 얼굴에 떠오른 또는 둥근 모서리. | 날카로운 평면 대신 부드럽거나 성형된 모서리를 추가합니다. |
| [getContourColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getContourColor)와 [getContourWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getContourWidth)와 [setContourWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setContourWidth) | 3D 객체 주위의 외곽선. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **3D 도형 만들기**

도형이 설득력 있게 3D로 보이려면 일반적으로 네 가지 유형의 설정이 필요합니다:

- 카메라 설정: 기본 전면 뷰가 돌출을 숨길 수 있기 때문입니다.
- 조명 설정: 조명이 면과 측면을 읽을 수 있게 만들기 때문입니다.
- 재질 설정: 표면이 빛이 렌더링되는 방식을 영향을 주기 때문입니다.
- 돌출 또는 깊이 설정: 평면 도형에 두께가 필요하기 때문입니다.

다음 예제는 사각형을 만들고, 전면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은 도 단위이며, 돌출 높이는 100 포인트입니다. 이 예제는 슬라이드를 기본 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

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

렌더링된 슬라이드 이미지에서 사각형은 두꺼운 3D 블록으로 표시됩니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링](img_01_01.png)

## **카메라를 사용하여 도형 회전**

PowerPoint에서 3D 회전은 3‑D 회전 패널에서 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전과 대응합니다.

![X, Y, Z 회전 값이 강조 표시된 PowerPoint 3‑D 회전 패널](img_02_01.png)

Aspose.Slides에서는 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getCamera) 를 통해 카메라에 접근합니다. 이 예제는 사각형을 만들고, 직교 전면 뷰를 선택한 뒤 X, Y, Z 회전을 각각 20°, 30°, 40°로 설정합니다. 파일을 저장하지 않고 메모리에서 도형을 구성합니다:

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

보는 사람이 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이는 슬라이드상의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용하는 3D 시점을 변경합니다.

## **돌출 및 깊이 추가**

돌출은 전면 뒤로 확장함으로써 도형을 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 얼굴의 색을 설정합니다.

![돌출 색 및 돌출 높이 속성에 매핑된 PowerPoint 깊이 제어](img_02_02.png)

두께를 설정하려면 [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setExtrusionHeight)를 사용하고, 측면 색상을 얻으려면 [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getExtrusionColor)를 사용합니다. 이 예제는 사각형에 100 포인트 돌출을 주고 측면을 보라색으로 설정한 뒤 카메라를 회전시켜 두께를 표시합니다. 파일을 저장하지 않고 메모리에서 도형을 구성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setDepth) 메서드는 3D 도형의 깊이를 설정합니다. [setExtrusionHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#setExtrusionHeight) 메서드는 이 예제와 같이 돌출 효과의 높이를 제어합니다.

## **3D 효과와 함께 그라디언트 또는 그림 채우기 사용**

3D 서식은 도형 채우기와 독립적입니다. 전면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서도 동일한 카메라, 조명, 재질 및 돌출 설정을 사용할 수 있습니다.

이 예제는 전면에 파란색‑주황색 그라디언트를 적용하고 150 포인트 돌출에 어두운 주황색을 적용합니다. 그라디언트는 0과 100에서 시작과 끝을 표시합니다. 카메라 회전 값은 도 단위이며, 슬라이드는 기본 크기의 두 배인 PNG 이미지로 렌더링됩니다:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

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

![파란‑주황 그라디언트 채우기와 주황색 돌출이 적용된 3D 사각형 렌더링](img_02_03.png)

대신 그림 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다. 이 예제는 작업 디렉터리에 "image.jpg" 라는 파일이 존재해야 합니다. 그림을 사각형에 맞게 늘리고 150 포인트 돌출을 적용하며 카메라 회전을 도 단위로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리에서 도형을 구성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

![전면에 사진 채우기와 주황색 돌출이 적용된 3D 사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 주황‑흰색 격자 패턴 텍스트를 만들고 위쪽 아치 효과를 적용한 뒤 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#getThreeDFormat) 을 통해 3D 설정을 구성합니다. 돌출 높이와 깊이는 포인트 단위이며, 조명 회전은 도 단위입니다. 도형 채우기와 외곽선은 숨겨져 텍스트만 보이게 합니다. 예제는 기본 슬라이드 크기의 두 배인 PNG 이미지를 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

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

![아치형 WordArt 변형, 주황색 패턴 채우기 및 어두운 돌출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **3D 도형에 텍스트를 평면으로 유지**

도형의 3D 외관을 유지하면서 텍스트를 읽기 쉽게 하려면 [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getTextFrameFormat) 를 통해 [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setKeepTextFlat) 을 호출합니다. 값이 `True`이면 텍스트가 3D 장면에서 벗어나 유지되고, `False`이면 텍스트가 장면에 참여해 3D 방향을 따릅니다.

이 설정은 도형의 3D 서식을 제거하지 않습니다: 카메라, 조명, 재질 및 돌출은 [Shape.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getThreeDFormat) 을 통해 계속 구성됩니다. 또한 일반 회전과도 다릅니다. [Shape.setRotation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#setRotation) 은 슬라이드 평면에서 도형을 회전시키고, [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setRotationAngle) 은 텍스트의 경계 상자 내에서 사용자 정의 회전을 제어합니다. 텍스트를 3D 장면에서 제외해도 해당 각도는 초기화되지 않습니다.

다음 독립형 예제는 텍스트가 있는 파란 사각형을 만들고 원본 옆에 복제합니다. 두 도형 모두 동일한 3D 서식을 가지고 있으며 텍스트 설정만 다릅니다: 왼쪽은 `False`, 오른쪽은 `True`. 카메라 각도는 도 단위이고 돌출 높이는 40 포인트입니다. 예제는 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 기본 크기의 두 배인 PNG로 렌더링합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

왼쪽에서는 텍스트가 3D 방향을 따릅니다. 오른쪽에서는 텍스트가 평면으로 유지되어 읽기 쉽습니다. 두 사각형 모두 동일한 보이는 돌출 및 3D 방향을 유지합니다.

![나란히 배치된 3D 사각형: 왼쪽은 텍스트가 3D 방향을 따르고 오른쪽은 평면으로 유지](keep_text_flat.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 래스터화되거나 2D 결과로 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/python-java/convert-powerpoint-to-png/) 로 렌더링하거나, [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/) 로 내보내거나, [HTML](/slides/ko/python-java/convert-powerpoint-to-html/) 로 내보내거나, [video conversion](/slides/ko/python-java/convert-powerpoint-to-video/) 용 프레임을 생성할 때 적용됩니다.

- 내보낸 이미지 및 PDF는 인터랙티브하지 않습니다. 객체는 내보낸 후 뷰어가 회전시킬 수 없습니다.
- 최종 화면은 카메라, 조명 장치, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되었거나 테마 기반 서식 값을 확인하려면 [effective shape properties](/slides/ko/python-java/shape-effective-properties/) 를 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정으로 보존되지 않고 렌더링됩니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형 및 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 뷰어가 회전시킬 수 있는 인터랙티브 3D 장면으로 만들지는 않습니다. PPTX에서는 해당 형식이 지원되는 경우 PowerPoint에서 3D 서식이 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 회전, 돌출, 베벨, 조명 및 재질과 같은 일반 PowerPoint 도형이나 텍스트에 적용되는 서식입니다. 이 문서는 3D 효과에 대해 다룹니다.

**보이는 3D 도형에 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 돌출 또는 깊이 중 하나를 설정해야 합니다. 실제로는 조명 장치와 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자가 나타나게 합니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 도형 본문에는 [Shape.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getThreeDFormat) 을, 텍스트에는 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#getThreeDFormat) 을 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타나나요?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환에 사용되는 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 출력에는 렌더링된 모습이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. [Shape Effective Properties](/slides/ko/python-java/shape-effective-properties/) 에서 설명한 효과적인 서식 API를 사용하여 최종 카메라, 조명 장치, 베벨 및 관련 3D 값을 읽을 수 있습니다.