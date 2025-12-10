---
title: 幻灯片
type: docs
weight: 10
url: /zh/net/examples/elements/slide/
keywords:
- 幻灯片示例
- 添加幻灯片
- 访问幻灯片
- 幻灯片索引
- 克隆幻灯片
- 重新排序幻灯片
- 删除幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中管理幻灯片：创建、克隆、重新排序、隐藏、设置背景和尺寸、应用切换效果，并导出为 PowerPoint 和 OpenDocument。"
---

本文提供了一系列示例，演示如何使用 **Aspose.Slides for .NET** 处理幻灯片。您将学习如何使用 `Presentation` 类添加、访问、克隆、重新排序和删除幻灯片。

下面的每个示例都包括简要说明以及相应的 C# 代码片段。

## **添加幻灯片**

要添加新幻灯片，首先必须选择一个布局。在本例中，我们使用 `Blank` 布局并向演示文稿中添加一个空白幻灯片。
```csharp
static void Add_Slide()
{
    using var pres = new Presentation();

    // 每张幻灯片基于一种版式，而该版式本身基于母版幻灯片。
    // 使用 Blank 版式创建新幻灯片。
    var blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // 使用选定的版式添加一个新的空白幻灯片
    pres.Slides.AddEmptySlide(layout: blankLayout);
}
```

```csharp
static void Access_Slide()
{
    // 默认情况下，创建的演示文稿会包含一个空白幻灯片
    using var pres = new Presentation();

    // 再添加一个空白幻灯片
    pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // 通过索引访问幻灯片
    var firstSlide = pres.Slides[0];
    var secondSlide = pres.Slides[1];

    // 从引用获取幻灯片索引，然后通过索引访问
    var secondSlideIndex = pres.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = pres.Slides[secondSlideIndex];
}
```

```csharp
static void Clone_Slide()
{
    // 默认情况下，演示文稿包含一个空白幻灯片
    using var pres = new Presentation();

    // 克隆第一张幻灯片；它将被添加到演示文稿的末尾
    var clonedSlide = pres.Slides.AddClone(sourceSlide: pres.Slides[0]);

    // 克隆幻灯片的索引是 1（演示文稿中的第二张幻灯片）
    var clonedSlideIndex = pres.Slides.IndexOf(clonedSlide);
}
```

```csharp
static void ReOrder_Slide()
{
    using var pres = new Presentation();

    // 添加第一张幻灯片的克隆（默认创建）
    var clonedSlide = pres.Slides.AddClone(pres.Slides[0]);

    // 将克隆幻灯片移动到首位（其余幻灯片下移）
    pres.Slides.Reorder(index: 0, clonedSlide);
}
```

```csharp
static void Remove_Slide()
{
    using var pres = new Presentation();

    // 在默认的第一张幻灯片之外添加一个新的空白幻灯片
    var secondSlide = pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // 删除第一张幻灯片；仅保留新添加的幻灯片
    var firstSlide = pres.Slides[0];
    pres.Slides.Remove(firstSlide);
}
```
