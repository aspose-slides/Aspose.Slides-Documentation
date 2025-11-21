---
title: 幻灯片
type: docs
weight: 10
url: /zh/net/examples/elements/slide/
keywords:
- 幻灯片 示例
- 添加 幻灯片
- 访问 幻灯片
- 幻灯片 索引
- 克隆 幻灯片
- 重新 排序 幻灯片
- 删除 幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中管理幻灯片：创建、克隆、重新排序、隐藏、设置背景和大小、应用过渡效果，并导出为 PowerPoint 和 OpenDocument。"
---

本文提供了一系列示例，演示如何使用 **Aspose.Slides for .NET** 处理幻灯片。您将学习如何使用 `Presentation` 类添加、访问、克隆、重新排序和删除幻灯片。

下面的每个示例都包括简要说明以及 C# 代码片段。

## 添加幻灯片

要添加新幻灯片，必须先选择一个版式。在本例中，我们使用 `Blank` 版式，并向演示文稿添加一个空幻灯片。
```csharp
static void Add_Slide()
{
    using var pres = new Presentation();

    // 每个幻灯片基于一种版式，而版式本身基于母版幻灯片。
    // 使用 Blank 版式创建新幻灯片。
    var blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // 使用选定的版式添加一个新的空幻灯片
    pres.Slides.AddEmptySlide(layout: blankLayout);
}
````
```csharp
static void Access_Slide()
{
    // 默认情况下，创建的演示文稿包含一个空幻灯片。
    using var pres = new Presentation();

    // 再添加一个空幻灯片。
    pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // 通过索引访问幻灯片。
    var firstSlide = pres.Slides[0];
    var secondSlide = pres.Slides[1];

    // 从引用获取幻灯片索引，然后通过索引访问它。
    var secondSlideIndex = pres.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = pres.Slides[secondSlideIndex];
}
```
```csharp
static void Clone_Slide()
{
    // 默认情况下，演示文稿包含一个空幻灯片。
    using var pres = new Presentation();

    // 克隆第一张幻灯片；它将被添加到演示文稿的末尾。
    var clonedSlide = pres.Slides.AddClone(sourceSlide: pres.Slides[0]);

    // 克隆的幻灯片索引为 1（演示文稿中的第二张幻灯片）。
    var clonedSlideIndex = pres.Slides.IndexOf(clonedSlide);
}
```
```csharp
static void ReOrder_Slide()
{
    using var pres = new Presentation();

    // 添加第一张幻灯片的克隆（默认创建）。
    var clonedSlide = pres.Slides.AddClone(pres.Slides[0]);

    // 将克隆的幻灯片移动到第一位置（其他幻灯片向下移动）。
    pres.Slides.Reorder(index: 0, clonedSlide);
}
```
```csharp
static void Remove_Slide()
{
    using var pres = new Presentation();

    // 在默认的第一张幻灯片之外添加一个新的空幻灯片。
    var secondSlide = pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // 移除第一张幻灯片；仅保留下新添加的幻灯片。
    var firstSlide = pres.Slides[0];
    pres.Slides.Remove(firstSlide);
}
```
