---
title: 连接器
type: docs
weight: 190
url: /zh/net/examples/elements/connector/
keywords:
- 连接器示例
- 添加连接器
- 访问连接器
- 删除连接器
- 重新连接形状
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中绘制和控制连接器：添加、路由、重新路由、设置连接点、箭头和样式，以在 PPT、PPTX 和 ODP 中链接形状。"
---

展示如何使用 **Aspose.Slides for .NET** 将形状通过连接线连接并更改其目标。

## 添加连接线

在幻灯片的两个点之间插入一个连接线形状。
```csharp
static void Add_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```


## 访问连接线

检索添加到幻灯片的第一个连接线形状。
```csharp
static void Access_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```


## 删除连接线

从幻灯片中删除连接线。
```csharp
static void Remove_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(conn);
}
```


## 重新连接形状

通过分配起始和结束目标，将连接线附加到两个形状上。
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
