---
title: Коннектор
type: docs
weight: 190
url: /ru/net/examples/elements/connector/
keywords:
- пример коннектора
- добавить коннектор
- доступ к коннектору
- удалить коннектор
- переподключить фигуры
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Рисуйте и управляйте коннекторами в C# с помощью Aspose.Slides: добавляйте, прокладывайте, перенаправляйте, задавайте точки подключения, стрелки и стили для связывания фигур в PPT, PPTX и ODP."
---

Показывает, как соединять фигуры с помощью коннекторов и изменять их цели, используя **Aspose.Slides for .NET**.

## Добавить коннектор

Вставьте форму коннектора между двумя точками на слайде.
```csharp
static void Add_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```


## Доступ к коннектору

Получите первую форму коннектора, добавленную на слайд.
```csharp
static void Access_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```


## Удалить коннектор

Удалите коннектор со слайда.
```csharp
static void Remove_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(conn);
}
```


## Переподключить формы

Присоедините коннектор к двум фигурам, задав начальные и конечные цели.
```csharp
static void Reconnect_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    conn.StartShapeConnectedTo = shape1;
    conn.EndShapeConnectedTo = shape2;
}
```
