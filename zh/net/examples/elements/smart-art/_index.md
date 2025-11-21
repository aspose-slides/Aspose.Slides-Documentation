---
title: SmartArt
type: docs
weight: 140
url: /zh/net/examples/elements/smartart/
keywords:
- SmartArt 示例
- 添加 SmartArt
- 访问 SmartArt
- 删除 SmartArt
- SmartArt 布局
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中创建和编辑 SmartArt：添加节点、改变布局和样式、精准转换为形状，并导出为 PPT、PPTX 和 ODP。"
---

展示如何使用 **Aspose.Slides for .NET** 添加 SmartArt 图形、访问它们、删除它们以及更改布局。

## 添加 SmartArt

使用内置布局之一插入 SmartArt 图形。
```csharp
static void Add_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```


## 访问 SmartArt

检索幻灯片上的第一个 SmartArt 对象。
```csharp
static void Access_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```


## 删除 SmartArt

从幻灯片中删除 SmartArt 形状。
```csharp
static void Remove_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smart);
}
```


## 更改 SmartArt 布局

更新现有 SmartArt 图形的布局类型。
```csharp
static void Change_SmartArt_Layout()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smart.Layout = SmartArtLayoutType.VerticalPictureList;
}
```
