---
title: 群組形狀
type: docs
weight: 170
url: /zh-hant/net/examples/elements/group-shape/
keywords:
- 群組
- 新增群組形狀
- 存取群組形狀
- 移除群組形狀
- 解除群組形狀
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理群組形狀：建立、嵌套、對齊、重新排序與設定群組形狀樣式，並提供 PPT、PPTX 與 ODP 簡報的 C# 範例。"
---
使用 **Aspose.Slides for .NET** 建立形狀群組、存取它們、解除群組以及移除的範例。

## **新增群組形狀**

建立一個包含兩個基本形狀的群組。

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

## **存取群組形狀**

從投影片中取得第一個群組形狀。

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

## **移除群組形狀**

從投影片中刪除群組形狀。

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **解除群組形狀**

將形狀從群組容器中移出。

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // 將形狀移出群組。
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```