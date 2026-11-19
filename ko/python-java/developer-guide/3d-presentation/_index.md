---
title: Python을 사용한 프레젠테이션에서 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/python-java/3d-presentation/
keywords:
- 3D PowerPoint
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
description: "Aspose.Slides와 함께 Java를 통해 Python에서 PowerPoint 모양 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Python via Java는 모양 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 생성, 편집, 보존 및 렌더링할 수 있습니다. 이 문서는 회전, 돌출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="Note" %}}
이 문서는 PowerPoint 모양 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 아닙니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때, Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

모양에 3D 서식을 적용하려면 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) 메서드를 사용합니다. 이 메서드는 해당 모양의 3D 장면을 제어하는 [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)을 반환합니다.

텍스트의 경우, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) 메서드를 사용합니다. 이는 모양 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어 대상 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정에 맞춥니다. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면에 하이라이트와 그림자가 표시되는 방식을 변경합니다. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | 평면, 무광, 플라스틱 또는 금속과 같은 표면 재질. | 동일한 형태를 더 평평하게, 부드럽게, 광택 있게 또는 금속성으로 보이게 합니다. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 모양이 앞면에서 뒤쪽으로 얼마나 확장되는지. | 평면 모양을 눈에 보이는 두꺼운 3D 객체로 변환합니다. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | 돌출된 면의 색상. | 깊이를 가시화하거나 측면 색을 앞면 채우기와 일치시킵니다. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 특히 베벨 및 재질 설정과 함께 모양이나 텍스트의 깊이를 미세 조정합니다. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | 앞면 및 뒷면에 돌출되거나 둥근 가장자리. | 날카롭고 평평한 면 대신 부드럽거나 성형된 가장자리를 추가합니다. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | 3D 객체 주변의 외곽선. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **3D 모양 만들기**

모양이 설득력 있게 3D로 보이려면 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정, 기본 전면 뷰가 돌출을 가릴 수 있기 때문입니다.
- 조명 설정, 조명이 면과 측면을 읽기 쉽게 만들기 때문입니다.
- 재질 설정, 표면이 빛이 렌더링되는 방식을 영향을 주기 때문입니다.
- 돌출 또는 깊이 설정, 평면 모양에 두께가 필요하기 때문입니다.

다음 예제는 사각형을 만들고, 앞면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은 도 단위이며, 돌출 높이는 100 포인트입니다. 이 예제는 슬라이드를 기본 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다.

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

렌더링된 슬라이드 이미지에서는 사각형이 두꺼운 3D 블록으로 표시됩니다:

![앞면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링](img_01_01.png)

## **카메라로 모양 회전하기**

PowerPoint에서 3D 회전은 3-D 회전 창에서 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전과 대응됩니다.

![X, Y, Z 회전 값이 강조된 PowerPoint 3-D 회전 창](img_02_01.png)

Aspose.Slides에서 카메라에 접근하려면 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) 를 사용합니다. 이 예제는 사각형을 만들고, 직교 전면 뷰를 선택한 뒤 X, Y, Z 회전을 각각 20, 30, 40도로 설정합니다. 파일을 저장하지 않고 메모리 내에서 모양을 구성합니다:

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

시청자가 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이는 슬라이드의 2D 모양 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

### **템플릿 모양에서 카메라 방향 복사**

템플릿 모양의 방향을 일치시키려면 [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) 로 카메라 사전 설정을 읽고, [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation) 로 회전 각도를 읽습니다. 이 예제는 `template.pptx`를 열고 첫 번째 슬라이드의 첫 번째 모양에서 두 번째 모양으로 카메라 방향을 복사합니다. 두 모양 모두 이미 3D 조명이 적용되어 있으며, 두 번째 모양에는 명시적인 카메라 회전이 없습니다.

각도는 도 단위입니다. 인덱스 `0`은 위도, 인덱스 `1`은 경도, 인덱스 `2`는 회전입니다. 이 순서대로 [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) 에 전달합니다. 소스가 `None`을 반환하면 명시적인 회전이 없으므로 두 번째 모양의 각도를 설정하지 않습니다. `(0, 0, 0)`과 같은 명시적인 회전은 세 개의 0을 반환하므로 복사해야 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`camera-copy.pptx`를 PowerPoint에서 다시 열면, 오른쪽 화살표가 왼쪽 사각형과 동일한 카메라 사전 설정 및 회전을 가지고 있습니다. 두 모양 모두 동일한 조명과 돌출 깊이를 사용합니다.

![위에서 오른쪽으로 바라본, 일치하는 카메라 방향을 가진 파란색 3D 사각형과 오른쪽 화살표](camera-orientation.png)

## **돌출 및 깊이 추가**

돌출은 모양을 앞면 뒤쪽으로 확장하여 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 면의 색을 설정합니다.

![돌출 색상 및 돌출 높이 속성과 매핑된 PowerPoint 깊이 제어](img_02_02.png)

[ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) 로 두께를 설정하고, [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) 로 측면 색을 가져옵니다. 이 예제는 사각형에 100포인트 돌출을 적용하고 보라색 측면을 부여하며, 카메라를 회전시켜 두께를 드러냅니다. 파일을 저장하지 않고 메모리 내에서 모양을 구성합니다:

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

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) 메서드는 3D 모양의 깊이를 설정합니다. [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) 메서드는 이 예제와 같이 돌출 효과의 높이를 제어합니다.

## **그라디언트 또는 그림 채우기를 3D 효과와 함께 사용하기**

3D 서식은 모양 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서도 동일한 카메라, 조명, 재질 및 돌출 설정을 사용할 수 있습니다.

이 예제는 앞면에 파란색에서 주황색으로 변하는 그라디언트를 적용하고, 150포인트 돌출에 어두운 주황색을 적용합니다. 그라디언트 정지는 0과 100에서 시작과 끝을 표시합니다. 카메라 회전 값은 도 단위이며, 슬라이드는 기본 크기의 두 배인 PNG 이미지로 렌더링됩니다:

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

![파란색-주황색 그라디언트 채우기와 주황색 돌출을 가진 3D 사각형 렌더링](img_02_03.png)

그림 채우기를 사용하려면, 이미지를 프레젠테이션에 추가하고 모양 채우기에 할당합니다. 이 예제는 작업 디렉터리에 "image.jpg"라는 파일이 존재해야 합니다. 그림을 사각형에 맞게 확대하고, 150포인트 돌출을 적용하며, 카메라 회전을 도 단위로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리 내에서 모양을 구성합니다:

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

![앞면에 사진 채우기와 주황색 돌출을 가진 3D 사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

모양 3D 서식은 모양 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 문자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 주황색-흰색 격자 패턴 텍스트를 만들고, 위쪽 아치를 적용하며, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) 을 통해 3D 설정을 구성합니다. 돌출 높이와 깊이는 포인트 단위이며, 조명 회전은 도 단위입니다. 모양 채우기와 외곽선은 숨겨져 텍스트만 보이게 합니다. 이 예제는 기본 슬라이드 크기의 두 배인 PNG 이미지를 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

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

![아치형 WordArt 변환, 주황색 패턴 채우기 및 어두운 돌출을 가진 3D 텍스트 렌더링](img_02_05.png)

## **3D 모양에서 텍스트를 평평하게 유지하기**

모양의 3D 외관을 유지하면서 텍스트를 읽기 쉽게 하려면, [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat) 을 통해 [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) 를 호출합니다. 값이 `True`이면 텍스트가 3D 장면에서 제외되고, `False`이면 텍스트가 장면에 참여하여 3D 방향을 따릅니다.

이 설정은 모양의 3D 서식을 제거하지 않습니다: 카메라, 조명, 재질 및 돌출은 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) 을 통해 계속 구성됩니다. 또한 일반 회전과도 다릅니다. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) 은 슬라이드 평면에서 모양을 회전시키고, [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) 은 텍스트의 경계 상자 내에서 사용자 지정 회전을 제어합니다. 텍스트를 3D 장면에서 제외해도 이러한 각도는 재설정되지 않습니다.

다음 독립 실행형 예제는 텍스트가 있는 파란 사각형을 만들고 원본 옆에 복제합니다. 두 모양은 동일한 3D 서식을 가지고 있으며, 텍스트 설정만 다릅니다: 왼쪽은 `False`, 오른쪽은 `True`. 카메라 각도는 도 단위이며, 돌출 높이는 40포인트입니다. 이 예제는 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 기본 크기의 두 배인 PNG로 렌더링합니다:

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

왼쪽에서는 텍스트가 3D 방향을 따릅니다. 오른쪽에서는 텍스트가 평평하게 유지되어 더 쉽게 읽을 수 있습니다. 두 사각형 모두 동일한 가시적 돌출과 3D 방향을 유지합니다.

![옆에 나란히 배치된 3D 사각형: 왼쪽 텍스트는 3D 방향을 따르고 오른쪽은 평평하게 유지](keep_text_flat.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 유지합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 2D 결과로 래스터화되거나 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/python-java/convert-powerpoint-to-png/) 로 렌더링하거나, [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/) 로 내보내거나, [HTML](/slides/ko/python-java/convert-powerpoint-to-html/) 로 내보내거나, [비디오 변환](/slides/ko/python-java/convert-powerpoint-to-video/) 을 위해 프레임을 생성할 때 적용됩니다.

다음 사항을 유념하십시오:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 객체는 내보낸 후 시청자가 회전시킬 수 없습니다.
- 최종 외관은 카메라, 라이트 릭, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 검사해야 하면, [유효한 모양 속성](/slides/ko/python-java/shape-effective-properties/) 을 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정으로 보존되지 않고 렌더링됩니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 모양 및 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 인터랙티브 3D 장면으로 만들어 시청자가 회전할 수 있게 하지 않습니다. PPTX에서는 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 남아 있습니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 회전, 돌출, 베벨, 조명 및 재질과 같은 일반 PowerPoint 모양 또는 텍스트에 적용되는 서식입니다. 이 문서는 3D 효과에 대해 다룹니다.

**눈에 보이는 3D 모양에 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 돌출 또는 깊이를 설정해야 합니다. 실제로는 조명 릭과 재질도 설정해 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**모양과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 모양 본문에는 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) 를, 텍스트에는 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) 를 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타나나요?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환에 사용되는 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 출력에는 렌더링된 모습이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. [유효한 모양 속성](/slides/ko/python-java/shape-effective-properties/) 에 설명된 유효 서식 API를 사용해 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽을 수 있습니다.