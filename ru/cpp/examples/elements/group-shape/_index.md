---
title: Групповая форма
type: docs
weight: 170
url: /ru/cpp/examples/elements/group-shape/
keywords:
- пример кода
- групповая форма
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте групповыми фигурами в Aspose.Slides for C++: создавайте, вкладывайте, выравнивайте, переупорядочивайте и оформляйте групповые формы с примерами на C++ в презентациях PPT, PPTX и ODP."
---
Примеры создания групп фигур, доступа к ним, разгруппировки и удаления с использованием **Aspose.Slides for C++**.

## **Добавить групповую форму**

Создайте группу, содержащую две базовые фигуры.

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

## **Получить доступ к групповой форме**

Получите первую групповую форму со слайда.

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

## **Удалить групповую форму**

Удалите групповую форму со слайда.

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

## **Разгруппировать фигуры**

Переместите фигуры из группового контейнера.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Переместить фигуру из группы.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```