---
title: Групповая форма
type: docs
weight: 170
url: /ru/net/examples/elements/group-shape/
keywords:
- пример группы
- добавить групповую форму
- доступ к групповой форме
- удалить групповую форму
- разгруппировать формы
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работа с групповыми формами в C# с использованием Aspose.Slides: создание и разгруппировка, переупорядочивание дочерних форм, установка преобразований и границ в PowerPoint и OpenDocument."
---

Примеры создания групп фигур, доступа к ним, разгруппировки и удаления с использованием **Aspose.Slides for .NET**.

## **Добавить групповую форму**

Создайте группу, содержащую две базовые формы.
```csharp
static void Add_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```


## **Доступ к групповой форме**

Извлеките первую групповую форму со слайда.
```csharp
static void Access_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```


## **Удалить групповую форму**

Удалите групповую форму со слайда.
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## **Разгруппировать формы**

Переместите формы из группового контейнера.
```csharp
static void Ungroup_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Переместить форму из группы
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
