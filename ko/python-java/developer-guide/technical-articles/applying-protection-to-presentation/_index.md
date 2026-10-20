---
title: Python에서 도형 잠금으로 프레젠테이션 편집 제한
linktitle: 프레젠테이션 편집 제한
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
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PPTX 프레젠테이션의 도형을 잠그고 해제하는 방법을 배우고, 선택, 이동, 크기 조정 및 그룹화를 제한합니다."
---
## **배경**

Aspose.Slides for Python via Java의 일반적인 활용 사례는 자동화된 워크플로의 일환으로 PowerPoint (PPTX) 프레젠테이션을 만들고, 업데이트하며 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때 도형에 대한 변경을 제한하면 의도된 레이아웃과 내용을 보존하는 데 도움이 됩니다.

이 문서에서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금은 개별 도형에 대한 특정 편집 작업을 제한합니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹 도형, 그림 프레임, 비디오 프레임, 커넥터 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성요소로 이루어집니다. Aspose.Slides for Python via Java에서는 슬라이드의 각 요소가 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 클래스를 상속하는 객체로 표시됩니다.

다양한 도형 유형은 서로 다른 잠금 옵션을 제공합니다. [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) 클래스는 도형 잠금의 기본 클래스입니다. Aspose.Slides for Python via Java는 다음과 같은 잠금 클래스를 제공합니다.

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) 자동 도형을 잠급니다.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) 커넥터 도형을 잠급니다.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) 그래픽 개체를 잠급니다.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) 그룹 도형을 잠급니다.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 그림 프레임을 잠급니다.  

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 전체에 잠금을 적용하려면 슬라이드들을 순회하면서 지원되는 각 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

도형 잠금은 도형 선택, 이동 및 크기 변경과 같은 작업을 제한합니다. 전체 프레젠테이션을 편집 불가능하게 만드는 것은 아닙니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for Python via Java는 슬라이드의 도형을 다루기 위해 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 클래스를 제공합니다.

예제에서는 자동 도형에 대해 `True`와 함께 [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked), [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked)를 호출하고, 그룹 도형, 커넥터 및 그림 프레임에도 동등한 잠금을 적용합니다. 커넥터는 이동을 위해 [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove)를 사용하며, 그룹은 그룹화를 제한하기 위해 [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked)을 사용합니다.

예제는 기존 PPTX 프레젠테이션을 로드하고, 각 슬라이드의 도형 컬렉션을 검사한 뒤 이러한 제한이 적용된 사본을 저장합니다. 네 가지 처리 유형에 해당하지 않는 도형은 변경되지 않은 채로 남습니다. 루프는 그룹 내부의 자식 도형을 순회하지 않습니다.

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

도형 잠금을 제거하려면 값을 `False`로 설정하면 됩니다. 다음 예제는 도형 잠금이 적용된 프레젠테이션을 로드하고, [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/)을 통해 선택, 이동 및 크기 변경 제한을 해제합니다. 또한 [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked)에 `False`를 전달하여 그룹화 제한을 제거하고 프레젠테이션 사본을 저장합니다. 다른 잠금 설정은 그대로 유지됩니다.

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

### **결론**

Aspose.Slides for Python via Java를 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형이 지원하는 잠금을 선택하고, 제한을 제거해야 할 경우 값을 `False`로 설정하십시오.

## **자주 묻는 질문**

**같은 프레젠테이션에서 도형 잠금과 비밀번호 보호를 함께 사용할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [비밀번호 보호](/slides/ko/python-java/password-protected-presentation/)는 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 가지를 동일 파일에서 모두 사용할 수 있습니다.

**특정 슬라이드만 편집을 제한하고 다른 슬라이드에는 영향을 주지 않을 수 있나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 다른 슬라이드의 잠금 설정은 변경되지 않습니다.

**그룹 내 개별 도형에 잠금을 적용하려면 어떻게 해야 하나요?**

그룹의 [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) 메서드가 반환하는 컬렉션을 순회하면서 각 자식 도형에 적절한 잠금을 적용합니다. 중첩된 그룹에 대해서도 동일하게 반복합니다. 위 예제는 슬라이드의 도형 컬렉션만 처리하므로 개별 그룹 구성원에 잠금을 설정하지는 않습니다.