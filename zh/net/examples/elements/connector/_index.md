---
title: 连接线
type: docs
weight: 190
url: /zh/net/examples/elements/connector/
keywords:
- 连接线
- 添加连接线
- 访问连接线
- 移除连接线
- 重新连接形状
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在形状之间添加、路由和设置连接线的样式，提供 PPT、PPTX 和 ODP 演示文稿的 C# 示例。"
---
本文演示如何使用 **Aspose.Slides for .NET** 将形状通过连接线连接，并更改其目标。

## **添加连接线**

在幻灯片的两个点之间插入一个连接线形状。

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **访问连接线**

检索添加到幻灯片的第一个连接线形状。

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **移除连接线**

从幻灯片中删除连接线。

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **重新连接形状**

通过分配起始和结束目标，将连接线附加到两个形状。

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