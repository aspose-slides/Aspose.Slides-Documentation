---
title: Python에서 도형 잠금으로 프레젠테이션 편집 제한
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
description: "Aspose.Slides for Python via .NET를 사용하여 PPTX 프레젠테이션에서 도형을 잠그고 잠금 해제하는 방법을 배우고, 선택, 이동, 크기 조정 및 그룹화를 제한할 수 있습니다."
---
## **배경**

Aspose.Slides for Python via .NET의 일반적인 사용 사례는 자동화된 워크플로의 일부로 PowerPoint(PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 내용을 보존하는 데 도움이 됩니다.

이 문서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금을 사용하면 개별 도형에 대해 특정 편집 작업을 제한할 수 있습니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for Python via .NET에서 슬라이드의 각 요소는 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 클래스를 상속하는 객체로 표현됩니다.

도형 유형마다 서로 다른 잠금 옵션을 제공합니다. [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) 클래스는 도형 잠금의 기본 클래스이며, Aspose.Slides for Python via .NET은 다음과 같은 잠금 클래스를 제공합니다.

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) 자동 도형을 잠급니다.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 연결선 도형을 잠급니다.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) 그래픽 개체를 잠급니다.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) 그룹 도형을 잠급니다.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 그림 프레임을 잠급니다.  

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 전체에 잠금을 적용하려면 슬라이드를 순회하면서 지원되는 각 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

도형 잠금은 도형 선택, 이동, 크기 조정과 같은 작업을 제한합니다. 전체 프레젠테이션을 편집 불가능하게 만들지는 않습니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for Python via .NET은 슬라이드의 도형을 다루기 위해 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 클래스를 제공합니다.

예제에서는 자동 도형에 대해 [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/)을 `True` 로 설정하고, 그룹 도형, 연결선 및 그림 프레임에도 동일한 잠금을 적용합니다. 연결선은 이동을 위해 [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/)을 사용하고, 그룹은 [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/)을 사용해 그룹화를 제한합니다.

예제는 기존 PPTX 프레젠테이션을 로드하고, 각 슬라이드의 도형 컬렉션을 확인한 뒤, 이러한 제한이 적용된 복사본을 저장합니다. 네 가지 유형 외의 도형은 변경되지 않으며, 루프는 그룹 내부의 자식 도형을 순회하지 않습니다.

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

도형 잠금을 제거하려면 해당 값을 `False` 로 설정하면 됩니다. 다음 예제는 도형 잠금이 적용된 프레젠테이션을 로드하고, [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/)을 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/)을 해제하고 프레젠테이션 복사본을 저장합니다. 다른 잠금 설정은 그대로 유지됩니다.

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

### **결론**

Aspose.Slides for Python via .NET을 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형에서 지원되는 잠금을 선택하고, 제한을 제거해야 할 때는 해당 값을 `False` 로 설정하십시오.

## **FAQ**

**동일한 프레젠테이션에서 도형 잠금과 암호 보호를 결합할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [암호 보호](/slides/ko/python-net/password-protected-presentation/)는 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 가지를 동일 파일에서 함께 사용할 수 있습니다.

**특정 슬라이드만 편집을 제한하고 다른 슬라이드에는 영향을 주지 않을 수 있나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 다른 슬라이드의 잠금 설정은 변경되지 않습니다.

**그룹 내부의 개별 도형에 잠금을 적용할 수 있나요?**

그룹의 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 컬렉션을 순회하면서 각 자식 도형에 적절한 잠금을 적용합니다. 중첩된 그룹도 동일하게 처리합니다. 위 예제는 슬라이드의 도형 컬렉션만 처리하므로 개별 그룹 구성원에 대한 잠금은 설정하지 않습니다.