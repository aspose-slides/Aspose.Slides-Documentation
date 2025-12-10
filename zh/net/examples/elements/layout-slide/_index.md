---
title: 布局幻灯片
type: docs
weight: 20
url: /zh/net/examples/elements/layout-slide/
keywords:
- 布局幻灯片示例
- 添加布局幻灯片
- 访问布局幻灯片
- 移除布局幻灯片
- 未使用的布局幻灯片
- 克隆布局幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 C# 与 Aspose.Slides 管理布局幻灯片：在 PPT、PPTX 和 ODP 演示文稿中创建、应用、克隆、重命名并自定义占位符和主题。"
---

本文演示如何在 Aspose.Slides for .NET 中使用 **Layout Slides**。布局幻灯片定义了普通幻灯片继承的设计和格式。您可以添加、访问、克隆和移除布局幻灯片，还可以清理未使用的布局以减小演示文稿的大小。

## **添加布局幻灯片**

您可以创建自定义布局幻灯片以定义可重用的格式。例如，您可以在使用此布局的所有幻灯片上添加一个文本框。

```csharp
static void Add_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Create a layout slide with a blank layout type and a custom name
    var layoutSlide = pres.LayoutSlides.Add(pres.Masters[0], SlideLayoutType.Blank, "Main layout");

    // Add a text box to the layout slide
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Add two slides using this layout; both will inherit the text from the layout
    pres.Slides.AddEmptySlide(layoutSlide);
    pres.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **提示 1：** 布局幻灯片充当单个幻灯片的模板。您可以一次定义公共元素，然后在多个幻灯片中复用它们。

> 💡 **提示 2：** 当您向布局幻灯片添加形状或文本时，基于该布局的所有幻灯片将自动显示这些共享内容。  
> 以下截图显示了两个幻灯片，它们各自从同一个布局幻灯片继承了文本框。

![继承布局内容的幻灯片](layout-slide-result.png)


## **访问布局幻灯片**

布局幻灯片可以通过索引或布局类型（例如 `Blank`、`Title`、`SectionHeader` 等）访问。

```csharp
static void Access_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Access by index
    var firstLayoutSlide = pres.LayoutSlides[0];
    
    // Access by layout type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **移除布局幻灯片**

如果不再需要特定的布局幻灯片，可以将其移除。

```csharp
static void Remove_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Get a layout slide by type and remove it
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    pres.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **移除未使用的布局幻灯片**

为了减小演示文稿的大小，您可能希望删除未被任何普通幻灯片使用的布局幻灯片。

```csharp
static void RemoveUnused_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Automatically removes all layout slides not referenced by any slide
    pres.LayoutSlides.RemoveUnused();
}
```

## **克隆布局幻灯片**

您可以使用 `AddClone` 方法复制布局幻灯片。

```csharp
static void Clone_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Get an existing layout slide by type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clone the layout slide to the end of the layout slide collection
    var clonedLayoutSlide = pres.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **摘要：** 布局幻灯片是管理幻灯片间一致格式的强大工具。Aspose.Slides 提供了对创建、管理和优化布局幻灯片的完整控制。