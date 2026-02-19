---
title: 幻灯片
type: docs
weight: 10
url: /zh/net/examples/elements/slide/
keywords:
- 幻灯片
- 添加幻灯片
- 访问幻灯片
- 幻灯片索引
- 克隆幻灯片
- 重新排序幻灯片
- 删除幻灯片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中控制幻灯片：使用 C# 为 PPT、PPTX 和 ODP 演示文稿创建、克隆、重新排序、调整大小、设置背景并应用过渡效果。"
---
本文提供了一系列示例，演示如何使用 **Aspose.Slides for .NET** 处理幻灯片。您将学习如何使用 `Presentation` 类添加、访问、克隆、重新排序和删除幻灯片。

以下每个示例都包含简要说明以及对应的 C# 代码片段。

## **添加幻灯片**

要添加新幻灯片，必须先选择布局。在本例中，我们使用 `Blank` 布局并向演示文稿添加一个空白幻灯片。

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // 每个幻灯片基于布局，而布局本身基于母版幻灯片。
    // 使用 Blank 布局创建新幻灯片。
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // 使用选定的布局添加一个新的空白幻灯片。
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **注意：** 每个幻灯片布局都来源于母版幻灯片，母版定义了整体设计和占位符结构。下图展示了母版幻灯片及其关联布局在 PowerPoint 中的组织方式。

![Master and Layout Relationship](master-layout-slide.png)

## **按索引访问幻灯片**

您可以通过索引访问幻灯片，或根据引用查找幻灯片的索引。这对于遍历或修改特定幻灯片非常有用。

```csharp
static void AccessSlide()
{
    // 默认情况下，创建的演示文稿包含一张空白幻灯片。
    using var presentation = new Presentation();

    // 添加另一张空白幻灯片。
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // 按索引访问幻灯片。
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // 从引用获取幻灯片索引，然后按索引访问它。
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **克隆幻灯片**

本示例演示如何克隆现有幻灯片。克隆的幻灯片会自动添加到幻灯片集合的末尾。

```csharp
static void CloneSlide()
{
    // 默认情况下，演示文稿包含一张空白幻灯片。
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // 克隆第一张幻灯片；它将被添加到演示文稿的末尾。
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // 克隆的幻灯片索引为 1（演示文稿中的第二张幻灯片）。
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **重新排序幻灯片**

您可以通过将幻灯片移动到新索引来更改顺序。在本例中，我们将克隆的幻灯片移动到第一位。

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // 添加第一张幻灯片的克隆（默认创建的）。
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // 将克隆的幻灯片移动到第一位置（其他幻灯片向下移动）。
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **删除幻灯片**

要删除幻灯片，只需引用它并调用 `Remove`。本示例先添加第二张幻灯片，然后删除原始幻灯片，仅保留新添加的幻灯片。

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // 在默认的第一张幻灯片之外，添加一个新的空白幻灯片。
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // 删除第一张幻灯片；仅保留下新添加的幻灯片。
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```