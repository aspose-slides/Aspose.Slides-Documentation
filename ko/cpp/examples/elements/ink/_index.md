---
title: 잉크
type: docs
weight: 180
url: /ko/cpp/examples/elements/ink/
keywords:
- 코드 예제
- 잉크
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 잉크 작업: 스트로크를 그리고, 가져오고, 편집하며, 색상과 굵기를 조정하고, C++ 예제를 사용하여 PPT, PPTX 및 ODP로 내보냅니다."
---
이 문서는 **Aspose.Slides for C++**를 사용하여 기존 잉크 모양에 접근하고 제거하는 예제를 제공합니다.

> ❗ **Note:** 잉크 모양은 특수 장치에서 사용자의 입력을 나타냅니다. Aspose.Slides는 프로그래밍 방식으로 새로운 잉크 스트로크를 만들 수 없지만, 기존 잉크를 읽고 수정할 수 있습니다.

## **Ink 접근**

슬라이드에 있는 첫 번째 잉크 모양의 태그를 읽습니다.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // 필요에 따라 tagName을 사용합니다.
        }
    }

    presentation->Dispose();
}
```

## **Ink 제거**

슬라이드에 잉크 모양이 존재한다면 이를 삭제합니다.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```