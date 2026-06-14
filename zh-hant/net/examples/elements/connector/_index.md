---
title: 連接線
type: docs
weight: 190
url: /zh-hant/net/examples/elements/connector/
keywords:
- 連接線
- 新增連接線
- 存取連接線
- 移除連接線
- 重新連接形狀
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在形狀之間新增、路由和設定連接線的樣式，並提供針對 PPT、PPTX 與 ODP 簡報的 C# 範例。"
---
本文示範如何使用 **Aspose.Slides for .NET** 連接形狀與連線，並變更其目標。

## **Add a Connector**
在投影片的兩個點之間插入一個連線形狀。

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Access a Connector**
取得已新增到投影片的第一個連線形狀。

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Remove a Connector**
從投影片中刪除連線。

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Reconnect Shapes**
透過指定起始與結束目標，將連線附加到兩個形狀。

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