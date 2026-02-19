---
title: Групповая фигура
type: docs
weight: 170
url: /ru/net/examples/elements/group-shape/
keywords:
- группа
- добавить групповую фигуру
- доступ к групповой фигуре
- удалить групповую фигуру
- разгруппировать фигуры
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте группированными фигурами в Aspose.Slides for .NET: создавайте, вкладывайте, выравнивайте, переупорядочивайте и оформляйте групповые фигуры с примерами на C# в презентациях PPT, PPTX и ODP."
---
Примеры создания групп фигур, доступа к ним, разгруппировки и удаления с использованием **Aspose.Slides for .NET**.

## **Добавить группу фигур**

Создайте группу, содержащую две базовые фигуры.

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **Доступ к группе фигур**

Получите первую группу фигур со слайда.

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **Удалить группу фигур**

Удалите группу фигур со слайда.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Разгруппировать фигуры**

Переместите фигуры из группового контейнера.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Переместить фигуру из группы.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```