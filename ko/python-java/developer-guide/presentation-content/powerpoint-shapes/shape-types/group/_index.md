---
title: Python via Java를 사용한 그룹 프레젠테이션 도형
linktitle: 도형 그룹
type: docs
weight: 40
url: /ko/python-java/group/
keywords:
- 그룹 도형
- 도형 그룹
- 그룹 추가
- 대체 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 파일에서 도형을 그룹화하고 그룹 해제하는 방법을 배우세요—무료 Python 코드와 함께 제공되는 단계별 가이드입니다."
---
## **개요**

이 문서는 Aspose.Slides에서 그룹 모양을 사용하는 방법을 설명합니다. 슬라이드에 그룹 모양을 추가하고, 그 안에 모양을 배치하며, 업데이트된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 그룹에 저장된 모양에 접근하고 [getAlternativeText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getAlternativeText)를 사용하여 대체 텍스트를 읽는 방법을 시연합니다. 추가로 중첩 그룹, Z 순서 및 잠금 옵션과 같은 관련 그룹 모양 기능에 대해 간략히 다룹니다.

## **그룹 모양 추가**

Aspose.Slides는 슬라이드에서 그룹 모양을 사용할 수 있도록 지원합니다. 이 기능은 개발자가 보다 풍부한 프레젠테이션을 만들도록 도와줍니다. Aspose.Slides for Python via Java는 그룹 모양을 추가하고 액세스하는 것을 지원합니다. 그룹 모양을 여러 모양으로 채우거나 해당 속성에 접근할 수 있습니다. Aspose.Slides for Python via Java를 사용하여 슬라이드에 그룹 모양을 추가하려면 다음과 같이 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 그룹 모양을 추가합니다.
1. 그룹 모양에 모양을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 모양을 추가합니다:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Presentation 클래스를 인스턴스화합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 슬라이드의 도형 컬렉션에 접근합니다.
    slide_shapes = slide.getShapes()

    # 슬라이드에 그룹 도형을 추가합니다.
    group_shape = slide_shapes.addGroupShape()

    # 그룹 도형 안에 도형들을 추가합니다.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # 그룹 도형의 프레임을 설정합니다.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **대체 텍스트 접근**

이 섹션에서는 슬라이드의 그룹 안에 있는 모형들의 대체 텍스트에 접근하는 방법을 보여줍니다. Aspose.Slides for Python via Java를 사용하여 이 텍스트에 접근하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화하여 PPTX 파일을 나타냅니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드의 모형 컬렉션에 접근합니다.
1. 그룹 모양에 접근합니다.
1. [getAlternativeText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getAlternativeText)를 사용하여 해당 모형들의 대체 텍스트를 읽습니다.

아래 예제는 그룹 안에 있는 모형들의 대체 텍스트에 접근합니다:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation("AltText.pptx")
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # 슬라이드의 도형 컬렉션에 있는 도형에 접근합니다.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # 그룹 안의 도형에 접근합니다.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # 대체 텍스트를 읽습니다.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**중첩 그룹화(그룹 내부에 그룹)가 지원됩니까?**

예. [GroupShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/groupshape/)에는 계층 구조 지원을 나타내는 [getParentGroup](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getParentGroup) 메서드가 있으며, 그룹은 다른 그룹의 자식이 될 수 있습니다.

**슬라이드의 다른 객체에 대한 그룹의 Z 순서를 어떻게 제어합니까?**

[GroupShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/groupshape/) 객체의 [getZOrderPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getZOrderPosition) 메서드를 사용하여 디스플레이 스택에서의 위치를 확인합니다.

**이동, 편집 또는 그룹 해제를 방지할 수 있습니까?**

예. 그룹의 잠금은 [getGroupShapeLock](https://reference.aspose.com/slides/ko/python-java/aspose.slides/groupshape/#getGroupShapeLock)을 통해 노출되며, 이를 사용해 객체에 대한 작업을 제한할 수 있습니다.