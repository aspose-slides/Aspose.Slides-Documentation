---
title: Python에서 도형 잠금으로 프리젠테이션 편집 제한
linktitle: 프리젠테이션 편집 제한
type: docs
weight: 60
url: /ko/python-java/applying-protection-to-presentation/
keywords:
- 편집 방지
- 편집으로부터 보호
- 도형 잠금
- 위치 잠금
- 선택 잠금
- 크기 조정 잠금
- 그룹화 잠금
- PowerPoint
- PPTX
- 프리젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PPTX 프리젠테이션에서 도형을 잠그고 잠금 해제하여 선택, 이동, 크기 조정 및 그룹화를 제한하는 방법을 배웁니다."
---
## **배경**

Aspose.Slides for Python via Java의 일반적인 사용 사례는 자동화된 워크플로우의 일부로 PowerPoint (PPTX) 프리젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 사용자가 이러한 프리젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 콘텐츠를 보존하는 데 도움이 될 수 있습니다.

이 문서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프리젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금은 개별 도형에 대한 특정 편집 작업을 제한할 수 있게 해줍니다.

## **슬라이드 구성**

프리젠테이션 슬라이드는 자동도형, 표, OLE 개체, 그룹화된 도형, 그림 프레임, 비디오 프레임, 연결선 및 프리젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 이루어져 있습니다. Aspose.Slides for Python via Java에서 슬라이드의 각 요소는 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 클래스를 상속하는 객체로 표현됩니다.

다양한 도형 유형은 서로 다른 잠금 옵션을 제공합니다. [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) 클래스는 도형 잠금의 기본 클래스입니다. Aspose.Slides for Python via Java는 다음 잠금 클래스를 제공합니다:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) 자동도형을 잠급니다.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) 연결선 도형을 잠급니다.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) 그래픽 개체를 잠급니다.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) 그룹 도형을 잠급니다.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 그림 프레임을 잠급니다.  

전체 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)에 걸쳐 잠금을 적용하려면 슬라이드를 반복하면서 지원되는 각 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

호환되는 프리젠테이션 편집기는 도형 잠금을 사용하여 개별 편집 작업을 제한합니다. 파일 암호화 및 문서 수준 쓰기 보호는 별도의 [프레젠테이션 보호 설정](/slides/ko/python-java/password-protected-presentation/)입니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for Python via Java는 슬라이드의 도형을 다루기 위해 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 클래스를 제공합니다.

예제는 자동도형에 대해 `True`와 함께 [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked), [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) 를 호출하고, 그룹 도형, 연결선 및 그림 프레임에 대해 동등한 잠금을 적용합니다. 연결선은 이동을 위해 [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) 를 사용하고; 그룹은 그룹화를 제한하기 위해 [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) 도 사용합니다.

예제는 기존 PPTX 프리젠테이션을 로드하고, 각 슬라이드의 도형 컬렉션에 있는 도형을 검사한 다음 이러한 제한이 적용된 복사본을 저장합니다. 처리되는 네 유형이 아닌 도형은 변경되지 않은 상태로 남깁니다. 루프는 그룹 내부의 하위 도형을 탐색하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **보호 제거**

도형 잠금을 제거하려면 해당 값을 `False` 로 설정합니다. 다음 예제는 도형 잠금이 적용된 프리젠테이션을 로드하고 [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/)을 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 `False` 를 [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) 에 전달하여 그룹화 제한을 제거하고 프리젠테이션의 복사본을 저장합니다. 다른 잠금 설정은 그대로 유지됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **그림 자르기 보존**

작업 디렉터리에 `photo.jpg` 라는 사진을 넣습니다. 예제는 왼쪽에서 12%, 오른쪽에서 8%를 자른 후 [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) 를 `True` 로 호출하여 자르기를 보존합니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`PictureLocked.pptx`에서 사진을 선택하면 PowerPoint가 **Crop** 명령을 비활성화합니다.

### **다이어그램 그룹 유지**

예제는 사각형과 화살표를 그룹화한 다음 [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) 를 `True` 로 호출하여 두 도형을 함께 유지합니다. 그룹을 이동하거나 구성 요소의 채우기를 변경할 수는 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`DiagramLocked.pptx`에서 전체 다이어그램을 선택하면 PowerPoint가 **Ungroup** 명령을 비활성화합니다.

### **기존 도형 잠금 보고**

템플릿을 검토하려면 템플릿을 열고 각 도형에 대한 잠금 객체를 읽습니다. [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) 메서드는 해당 객체의 모든 플래그가 비활성화된 경우 `True` 를, 하나라도 활성화된 경우 `False` 를 반환합니다. 그룹과 그 하위 도형은 별도의 잠금 객체를 갖고 있으므로, 그룹에 잠금이 없더라도 하위 도형을 검사해야 합니다.

이 예제는 자동도형, 그림 프레임 및 그룹의 이동을 확인합니다. 또한 사진의 자르기와 그룹의 Ungrouping을 확인합니다. 보고서는 인식된 활성 플래그를 나열하고 검사하지 않은 도형 유형을 표시합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

`Sample.pptx`의 슬라이드 1에 Ungrouping이 잠긴 `Layout`이라는 그룹과, 그 안에 Cropping이 잠긴 `Photo`라는 사진, 잠금이 해제된 `Free`라는 사각형이 포함되어 있다고 가정합니다. 보고서는 `Free`를 건너뛰고 다음 두 줄을 출력합니다:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

보고서는 프리젠테이션을 변경하거나 저장하지 않고 저장된 도형 수준 편집 플래그를 읽습니다. 문서 수준 쓰기 보호는 별도의 설정이며, 각 플래그의 적용 여부는 편집기에 따라 달라집니다.

## **결론**

Aspose.Slides for Python via Java를 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형에서 지원되는 잠금을 선택하고, 제한을 제거해야 할 경우 해당 값을 `False` 로 설정하십시오.

## **자주 묻는 질문**

**같은 프리젠테이션에서 도형 잠금과 암호 보호를 결합할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [암호 보호](/slides/ko/python-java/password-protected-presentation/)는 프리젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 기능을 동일한 파일에서 함께 사용할 수 있습니다.

**특정 슬라이드만 편집을 제한하고 다른 슬라이드에는 영향을 주지 않을 수 있나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하십시오. 이렇게 하면 다른 슬라이드의 잠금 설정은 변경되지 않습니다.

**그룹 내부의 개별 도형에 잠금을 적용하려면 어떻게 해야 하나요?**

그룹의 [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) 메서드가 반환하는 컬렉션을 반복하면서 각 하위 도형에 적절한 잠금을 적용합니다. 중첩된 그룹이 있는 경우에도 보고 예제의 순회를 따라 동일하게 수행합니다.