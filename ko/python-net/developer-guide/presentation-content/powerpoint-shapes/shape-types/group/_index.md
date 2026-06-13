---
title: Python으로 그룹 프레젠테이션 도형
linktitle: 도형 그룹
type: docs
weight: 40
url: /ko/python-net/group/
keywords:
- 그룹 도형
- 도형 그룹
- 그룹 추가
- 대체 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 PowerPoint 및 OpenDocument 데크에서 도형을 그룹화하고 그룹 해제하는 방법을 배우세요—빠르고 단계별 가이드와 무료 코드 제공."
---
## **개요**

이 문서는 Aspose.Slides에서 그룹 모양을 사용하는 방법을 설명합니다. 슬라이드에 그룹 모양을 추가하고, 그 안에 모양을 배치하며, 업데이트된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 그룹에 저장된 모양에 접근하고 해당 모양의 `alternative_text` 값을 읽는 방법을 시연합니다. 추가로 중첩 그룹, z-order 및 잠금 옵션과 같은 관련 그룹 모양 기능에 대해서도 간략히 다룹니다.

## **그룹 모양 추가**

Aspose.Slides는 슬라이드에서 그룹 모양을 사용하는 것을 지원합니다. 이 기능을 사용하면 여러 모양을 단일 개체로 취급하여 보다 풍부한 프레젠테이션을 만들 수 있습니다. 새 그룹 모양을 추가하고, 기존 그룹을 접근하며, 자식 모양을 채우고, 속성을 읽거나 수정할 수 있습니다. 슬라이드에 그룹 모양을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [GroupShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/) 를 추가합니다.
4. 새로운 그룹 모양에 모양을 추가합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 모양을 추가하는 방법을 보여줍니다.

```py
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 슬라이드에 그룹 도형을 추가합니다.
    group_shape = slide.shapes.add_group_shape()

    # 그룹 도형 안에 도형을 추가합니다.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Alt Text 속성 접근**

이 섹션에서는 Aspose.Slides를 사용하여 슬라이드의 그룹 모양에 포함된 모양들의 Alt Text를 읽는 방법을 설명합니다. Alt Text에 접근하려면:

1. PPTX 파일을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 인덱스로 슬라이드에 대한 참조를 얻습니다.
3. 슬라이드의 shapes 컬렉션에 접근합니다.
4. [GroupShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/) 에 접근합니다.
5. Alt Text 속성을 읽습니다.

아래 예제는 그룹 모양에 포함된 모양들의 Alt Text를 가져옵니다.

```py
import aspose.slides as slides

# PPTX 파일을 열기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("group_shape.pptx") as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # 그룹 도형에 접근합니다.
            for child_shape in shape.shapes:
                # Alt Text 속성에 접근합니다.
                print(child_shape.alternative_text)
```

## **FAQ**

**중첩 그룹화(그룹 안에 그룹)가 지원됩니까?**

예. [GroupShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/) 에는 [parent_group](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/parent_group/) 속성이 있어 계층 구조 지원(그룹이 다른 그룹의 자식이 될 수 있음)을 직접 나타냅니다.

**그룹의 z-order를 슬라이드의 다른 객체와 비교하여 어떻게 제어합니까?**

[GroupShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/) 의 [z_order_position](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/z_order_position/) 속성을 사용하여 디스플레이 스택에서의 위치를 확인할 수 있습니다.

**이동/편집/그룹 해제 방지를 할 수 있습니까?**

예. 그룹의 잠금 섹션은 [group_shape_lock](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/group_shape_lock/) 을 통해 노출되며, 객체에 대한 작업을 제한할 수 있습니다.