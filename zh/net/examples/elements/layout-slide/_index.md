---
title: 布局幻灯片
type: docs
weight: 20
url: /zh/net/examples/elements/layout-slide/
keywords:
- 布局幻灯片
- 添加布局幻灯片
- 访问布局幻灯片
- 删除布局幻灯片
- 未使用的布局幻灯片
- 克隆布局幻灯片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用母版布局幻灯片：选择、应用和自定义幻灯片布局、占位符和母版，提供针对 PPT、PPTX 和 ODP 演示文稿的 C# 示例。"
---
本文演示如何在 Aspose.Slides for .NET 中使用 **Layout Slides**。布局幻灯片定义了普通幻灯片继承的设计和格式。您可以添加、访问、克隆和删除布局幻灯片，并清理未使用的布局幻灯片以减小演示文稿大小。

## **添加布局幻灯片**

您可以创建自定义布局幻灯片以定义可重复使用的格式。例如，您可以添加一个文本框，使所有使用此布局的幻灯片都显示该文本框。

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // 创建一个空白布局类型且具有自定义名称的布局幻灯片。
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // 向布局幻灯片添加文本框。
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // 使用此布局添加两张幻灯片；两者都会继承布局中的文本。
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **注意 1:** 布局幻灯片充当单个幻灯片的模板。您可以一次定义通用元素，然后在多个幻灯片中重复使用它们。

> 💡 **注意 2:** 当您向布局幻灯片添加形状或文本时，基于该布局的所有幻灯片将自动显示这些共享内容。  
> 以下截图显示了两张幻灯片，它们均从同一布局幻灯片继承了文本框。

![Slides Inheriting Layout Content](layout-slide-result.png)

## **访问布局幻灯片**

布局幻灯片可以通过索引或布局类型（例如 `Blank`、`Title`、`SectionHeader` 等）进行访问。

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // 通过索引访问布局幻灯片。
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // 通过类型访问布局幻灯片。
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **删除布局幻灯片**

如果不再需要特定的布局幻灯片，可以将其删除。

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // 通过类型获取布局幻灯片并将其删除。
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **删除未使用的布局幻灯片**

为了减小演示文稿大小，您可能需要删除没有被任何普通幻灯片使用的布局幻灯片。

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // 自动删除所有未被任何幻灯片引用的布局幻灯片。
    presentation.LayoutSlides.RemoveUnused();
}
```

## **克隆布局幻灯片**

您可以使用 `AddClone` 方法复制布局幻灯片。

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // 根据类型获取现有的布局幻灯片。
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // 将布局幻灯片克隆到布局幻灯片集合的末尾。
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **摘要:** 布局幻灯片是管理幻灯片间一致格式的强大工具。Aspose.Slides 提供了对创建、管理和优化布局幻灯片的完整控制。