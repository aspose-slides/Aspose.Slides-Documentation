---
title: SmartArt
type: docs
weight: 140
url: /ru/cpp/examples/elements/smart-art/
keywords:
- пример кода
- SmartArt
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Работайте с SmartArt в Aspose.Slides for C++: создавайте, редактируйте, конвертируйте и оформляйте диаграммы с помощью C++ для презентаций PowerPoint и OpenDocument."
---
В этой статье демонстрируется, как добавить графику SmartArt, получить к ней доступ, удалить её и изменить макеты с помощью **Aspose.Slides for C++**.

## **Добавить SmartArt**

Вставьте графику SmartArt, используя один из встроенных макетов.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Доступ к SmartArt**

Получите первый объект SmartArt на слайде.

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

## **Удалить SmartArt**

Удалите форму SmartArt со слайда.

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

## **Изменить макет SmartArt**

Обновите тип макета существующей графики SmartArt.

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