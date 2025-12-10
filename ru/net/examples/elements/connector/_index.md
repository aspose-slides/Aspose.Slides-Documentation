---
title: Соединитель
type: docs
weight: 190
url: /ru/net/examples/elements/connector/
keywords:
- пример соединителя
- добавить соединитель
- доступ к соединителю
- удалить соединитель
- переподключить фигуры
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Рисуйте и управляйте соединителями в C# с Aspose.Slides: добавляйте, прокладывайте, перенастраивайте, задавайте точки соединения, стрелки и стили для связывания фигур в PPT, PPTX и ODP."
---

Показывает, как соединять фигуры с помощью соединителей и изменять их цели, используя **Aspose.Slides for .NET**.

## **Добавить соединитель**

Вставьте форму соединителя между двумя точками на слайде.
```csharp
static void Add_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```


## **Получить соединитель**

Получите первую форму соединителя, добавленную на слайд.
```csharp
static void Access_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```


## **Удалить соединитель**

Удалите соединитель со слайда.
```csharp
static void Remove_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(conn);
}
```


## **Переподключить фигуры**

Подключите соединитель к двум фигурам, назначив начальную и конечную цели.
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
