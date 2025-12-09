---
title: ГрупповаяФигура
type: docs
weight: 170
url: /ru/net/examples/elements/group-shape/
keywords:
- пример группы
- добавить групповую фигуру
- доступ к групповой фигуре
- удалить групповую фигуру
- разгруппировать фигуры
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с групповыми фигурами в C# с помощью Aspose.Slides: создавайте и разгруппируйте, переупорядочивайте дочерние фигуры, задавайте трансформации и границы в PowerPoint и OpenDocument."
---

Примеры создания групп фигур, их доступа, разгруппировки и удаления с использованием **Aspose.Slides for .NET**.

## Добавить групповую фигуру

Создайте группу, содержащую две базовые фигуры.
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


## Доступ к групповой фигуре

Получите первую групповую фигуру со слайда.
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


## Удаление групповой фигуры

Удалите групповую фигуру со слайда.
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## Разгруппировать фигуры

Переместите фигуры из контейнера группы.
```csharp
static void Ungroup_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Переместить фигуру из группы
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
