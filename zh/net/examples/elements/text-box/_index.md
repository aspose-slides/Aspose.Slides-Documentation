---
title: 文本框
type: docs
weight: 40
url: /zh/net/examples/elements/text-box/
keywords:
- 文本框示例
- 添加文本框
- 访问文本框
- 删除文本框
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 C# 和 Aspose.Slides 创建和格式化文本框：设置字体、对齐、换行、自动调整大小以及链接，以优化 PowerPoint 和 OpenDocument 的幻灯片。"
---

在 Aspose.Slides 中，**文本框**由 `AutoShape` 表示。几乎所有形状都可以包含文本，但典型的文本框没有填充或边框，只显示文本。

本指南说明如何以编程方式添加、访问和删除文本框。

## 添加文本框

文本框实际上是一个没有填充和边框且包含一些格式化文本的 `AutoShape`。下面演示如何创建它：

```csharp
public static void Add_TextBox()
{
    using var pres = new Presentation();

    // Create a rectangle shape (defaults to filled with border and no text)
    var textBox = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remove fill and border to make it look like a typical text box
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Set text formatting
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assign the actual text content
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **注意：** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以充当文本框。

## 按内容访问文本框

要查找所有包含特定关键字（例如 “Slide”）的文本框，请遍历形状并检查它们的文本：

```csharp
public static void Access_TextBox()
{
    using var pres = new Presentation();

    foreach (var shape in pres.Slides[0].Shapes)
    {
        // Only AutoShapes can contain editable text
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Do something with the matching text box
            }
        }
    }
}
```

## 按内容删除文本框

此示例查找并删除第一张幻灯片上包含特定关键字的所有文本框：

```csharp
public static void Remove_TextBox()
{
    using var pres = new Presentation();

    var shapesToRemove = pres.Slides[0].Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => pres.Slides[0].Shapes.Remove(shape));
}
```

> 💡 **提示：** 在迭代过程中修改形状集合前，请始终先创建该集合的副本，以避免集合修改错误。