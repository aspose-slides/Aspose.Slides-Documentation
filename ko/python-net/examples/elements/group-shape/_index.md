---
title: 그룹 도형
type: docs
weight: 170
url: /ko/python-net/examples/elements/group-shape/
keywords:
- 그룹
- 그룹 도형 추가
- 그룹 도형 액세스
- 그룹 도형 제거
- 그룹 해제 도형
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 그룹 도형을 작업합니다: 생성 및 그룹 해제, 자식 도형 재정렬, 변환 및 경계를 PowerPoint와 OpenDocument 전반에 걸쳐 설정합니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 도형 그룹을 만들고, 액세스하고, 그룹 해제 및 제거하는 예시입니다.

## **그룹 도형 추가**

두 개의 기본 도형을 포함하는 그룹을 만듭니다.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 그룹 도형을 추가합니다.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **그룹 도형 액세스**

슬라이드에서 첫 번째 그룹 도형을 가져옵니다.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 슬라이드에서 첫 번째 그룹 도형에 액세스합니다.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **그룹 도형 제거**

슬라이드에서 그룹 도형을 삭제합니다.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 그룹 도형이라고 가정합니다.
        group = slide.shapes[0]

        # 그룹 도형을 제거합니다.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **그룹 해제 도형**

도형을 그룹 컨테이너 밖으로 이동합니다.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 그룹 도형이라고 가정합니다.
        group = slide.shapes[0]

        # 도형을 그룹 밖으로 이동합니다.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```