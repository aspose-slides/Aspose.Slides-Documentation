---
title: Соединитель
type: docs
weight: 190
url: /ru/net/examples/elements/connector/
keywords:
- соединитель
- добавить соединитель
- доступ к соединителю
- удалить соединитель
- переподключить фигуры
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как добавлять, прокладывать и оформлять соединители между фигурами с помощью Aspose.Slides for .NET, с примерами на C# для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как соединять фигуры с помощью соединителей и изменять их цели, используя **Aspose.Slides for .NET**.

## **Добавить соединитель**

Вставьте форму‑соединитель между двумя точками на слайде.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Доступ к соединителю**

Получите первую добавленную к слайду форму‑соединитель.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Удалить соединитель**

Удалите соединитель со слайда.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Переподключить фигуры**

Присоедините соединитель к двум фигурам, задав начальную и конечную цели.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```