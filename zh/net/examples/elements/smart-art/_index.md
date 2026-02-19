---
title: SmartArt
type: docs
weight: 140
url: /zh/net/examples/elements/smart-art/
keywords:
- SmartArt
- 添加 SmartArt
- 访问 SmartArt
- 删除 SmartArt
- SmartArt 布局
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用 SmartArt：使用 C# 为 PowerPoint 和 OpenDocument 演示文稿创建、编辑、转换和设置样式图表。"
---
本文演示了如何使用 **Aspose.Slides for .NET** 添加 SmartArt 图形、访问它们、删除它们以及更改布局。

## **添加 SmartArt**

使用内置布局之一插入 SmartArt 图形。

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **访问 SmartArt**

获取幻灯片上的第一个 SmartArt 对象。

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **删除 SmartArt**

从幻灯片中删除 SmartArt 形状。

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **更改 SmartArt 布局**

更新现有 SmartArt 图形的布局类型。

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```