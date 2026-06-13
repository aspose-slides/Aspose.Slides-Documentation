---
title: SmartArt
type: docs
weight: 140
url: /ko/cpp/examples/elements/smart-art/
keywords:
- 코드 예제
- SmartArt
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides에서 SmartArt 작업: PowerPoint 및 OpenDocument 프레젠테이션용 C++로 다이어그램을 만들고, 편집하고, 변환하고, 스타일을 적용합니다."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 SmartArt 그래픽을 추가하고, 액세스하며, 제거하고, 레이아웃을 변경하는 방법을 보여줍니다.

## **SmartArt 추가**

내장된 레이아웃 중 하나를 사용하여 SmartArt 그래픽을 삽입합니다.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **SmartArt 액세스**

슬라이드에서 첫 번째 SmartArt 개체를 검색합니다.

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **SmartArt 제거**

슬라이드에서 SmartArt 도형을 삭제합니다.

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **SmartArt 레이아웃 변경**

기존 SmartArt 그래픽의 레이아웃 유형을 업데이트합니다.

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```