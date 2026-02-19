---
title: "Чернильные"
type: docs
weight: 180
url: /ru/cpp/examples/elements/ink/
keywords:
  - "пример кода"
  - "чернила"
  - "PowerPoint"
  - "OpenDocument"
  - "презентация"
  - "C++"
  - "Aspose.Slides"
description: "Работайте с чернильными объектами в Aspose.Slides for C++: рисуйте, импортируйте и редактируйте штрихи, настраивайте цвет и ширину, а также экспортируйте в PPT, PPTX и ODP с помощью примеров на C++."
---
Эта статья предоставляет примеры доступа к существующим рукописным фигурам и их удаления с использованием **Aspose.Slides for C++**.

> ❗ **Примечание:** Чернильные фигуры представляют ввод пользователя с специализированных устройств. Aspose.Slides не может программно создавать новые чернильные штрихи, но вы можете читать и изменять существующие чернильные данные.

## **Доступ к Ink**

Прочитайте теги первого чернильного объекта на слайде.

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
            // Используйте tagName по необходимости.
        }
    }

    presentation->Dispose();
}
```

## **Удалить Ink**

Удалите чернильный объект со слайда, если он существует.

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