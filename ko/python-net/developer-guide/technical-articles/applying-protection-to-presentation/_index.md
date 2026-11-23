---
title: Python에서 Shape Locks를 사용하여 프레젠테이션 편집 제한
linktitle: 프레젠테이션 편집 제한
type: docs
weight: 70
url: /ko/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PPTX 프레젠테이션의 도형을 잠그고 해제하는 방법을 배우고, 선택, 이동, 크기 조정 및 그룹화를 제한합니다."
---
## **배경**

Aspose.Slides for Python via .NET의 일반적인 사용 사례는 자동화된 워크플로의 일부로 PowerPoint(PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 내용을 유지하는 데 도움이 됩니다.

이 문서에서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금을 사용하면 개별 도형에 대한 특정 편집 작업을 제한할 수 있습니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹화된 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 구성됩니다. Aspose.Slides for Python via .NET에서는 슬라이드의 각 요소가 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 클래스를 상속하는 객체로 표시됩니다.

다양한 도형 유형은 서로 다른 잠금 옵션을 제공합니다. [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) 클래스는 도형 잠금의 기본 클래스입니다. Aspose.Slides for Python via .NET은 다음 잠금 클래스를 제공합니다:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) 자동 도형을 잠급니다.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 연결선 도형을 잠급니다.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) 그래픽 개체를 잠급니다.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) 그룹 도형을 잠급니다.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 그림 프레임을 잠급니다.  

전체 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)에서 잠금을 적용하려면 슬라이드를 순회하면서 각 지원되는 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

호환되는 프레젠테이션 편집기는 도형 잠금을 사용하여 개별 편집 작업을 제한합니다. 파일 암호화 및 문서 수준 쓰기 보호는 별도의 [프레젠테이션 보호 설정](/slides/ko/python-net/password-protected-presentation/)입니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for Python via .NET는 슬라이드의 도형을 작업하기 위해 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 클래스를 제공합니다.

예제에서는 자동 도형에 대해 [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/)를 `True`로 설정하고, 그룹 도형, 연결선 및 그림 프레임에 대해서도 동일한 잠금을 적용합니다. 연결선은 이동을 위해 [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/)을 사용하고, 그룹은 그룹화를 제한하기 위해 [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/)을 사용합니다.

예제는 기존 PPTX 프레젠테이션을 로드하고, 각 슬라이드의 shape collection에서 도형을 검사한 뒤 이러한 제한이 적용된 사본을 저장합니다. 네 가지 처리 유형에 해당하지 않는 도형은 변경되지 않은 채 남겨집니다. 루프는 그룹 내부의 자식 도형을 순회하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **보호 제거**

도형 잠금을 제거하려면 값을 `False`로 설정합니다. 다음 예제는 도형 잠금이 적용된 프레젠테이션을 로드하고, [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/)을 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/)을 해제하고 프레젠테이션 사본을 저장합니다. 다른 잠금 설정은 변경되지 않은 채 남아 있습니다.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **그림 자르기 유지**

작업 디렉터리에 `photo.jpg`라는 사진을 배치합니다. 예제는 왼쪽에서 12%, 오른쪽에서 8%를 잘라낸 후 그림 프레임에 [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/)을 설정하여 잘라낸 상태를 유지합니다.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx`는 자르기 잠금을 `True`로 저장합니다. PowerPoint에서 사진이 선택된 경우 **Crop** 명령이 비활성화됩니다.

### **다이어그램을 그룹화된 상태로 유지**

예제는 사각형과 화살표를 그룹화한 뒤, 그룹 자체에 [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/)을 설정하여 다이어그램 구성 요소가 함께 유지되도록 합니다. 그룹을 이동하거나 구성 요소의 채우기를 변경하는 등 다른 편집은 여전히 사용할 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx`는 그룹 해제 잠금을 `True`로 저장합니다. PowerPoint에서 전체 다이어그램이 선택된 경우 **Ungroup** 명령이 비활성화됩니다.

### **결론**

Aspose.Slides for Python via .NET를 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형에서 지원하는 잠금을 선택하고, 제한을 제거해야 할 경우 값을 `False`로 설정하십시오.

## **FAQ**

**프레젠테이션에서 도형 잠금과 비밀번호 보호를 동시에 사용할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [비밀번호 보호](/slides/ko/python-net/password-protected-presentation/)는 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 가지를 동일한 파일에서 모두 사용할 수 있습니다.

**특정 슬라이드만 편집 제한을 적용하고 다른 슬라이드에는 영향을 주지 않을 수 있나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 다른 슬라이드의 잠금 설정은 변경되지 않습니다.

**그룹 내부의 개별 도형에 잠금을 적용하려면 어떻게 해야 하나요?**

그룹의 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 컬렉션을 순회하면서 각 자식 도형에 적절한 잠금을 적용합니다. 중첩된 그룹이 있는 경우에도 동일한 방식을 반복합니다. 위 예제는 슬라이드의 shape collection만 처리하므로 개별 그룹 구성원에 대한 잠금을 설정하지 않습니다.