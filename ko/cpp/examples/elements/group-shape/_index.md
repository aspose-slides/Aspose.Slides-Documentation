---
title: 그룹 도형
type: docs
weight: 170
url: /ko/cpp/examples/elements/group-shape/
keywords:
- 코드 예제
- 그룹 도형
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 그룹화된 도형을 관리합니다: C++ 예제를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에서 그룹 도형을 생성, 중첩, 정렬, 재정렬 및 스타일링합니다."
---
다음은 **Aspose.Slides for C++**을 사용하여 도형 그룹을 만들고, 접근하고, 그룹 해제 및 제거하는 예제입니다.

## **그룹 도형 추가**

두 개의 기본 도형을 포함하는 그룹을 생성합니다.

```cpp
static void AddGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    group->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

    presentation->Dispose();
}
```

## **그룹 도형 접근**

슬라이드에서 첫 번째 그룹 도형을 가져옵니다.

```cpp
static void AccessGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    auto firstGroup = SharedPtr<IGroupShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IGroupShape>(shape))
        {
            firstGroup = ExplicitCast<IGroupShape>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **그룹 도형 제거**

슬라이드에서 그룹 도형을 삭제합니다.

```cpp
static void RemoveGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();

    slide->get_Shapes()->Remove(group);

    presentation->Dispose();
}
```

## **그룹 해제**

그룹 컨테이너에서 도형을 꺼냅니다.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // 도형을 그룹 밖으로 이동합니다.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```