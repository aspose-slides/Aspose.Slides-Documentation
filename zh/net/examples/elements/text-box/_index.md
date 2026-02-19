---
title: 文本框
type: docs
weight: 40
url: /zh/net/examples/elements/text-box/
keywords:
- 文本框
- 添加文本框
- 访问文本框
- 删除文本框
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用文本框：使用 C# 为 PPT、PPTX 和 ODP 演示文稿添加、格式化、对齐、换行、自动适应和样式化文本。"
---
在 Aspose.Slides 中，**文本框** 由 `AutoShape` 表示。几乎任何形状都可以包含文本，但典型的文本框没有填充或边框，只显示文本。

本指南说明如何以编程方式添加、访问和删除文本框。

## **添加文本框**

文本框仅仅是一个没有填充或边框且带有一些格式化文本的 `AutoShape`。以下是创建方法：

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 创建一个矩形形状（默认填充并带边框且无文本）。
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // 移除填充和边框，使其看起来像典型的文本框。
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // 设置文本格式。
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // 分配实际的文本内容。
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **注意:** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以充当文本框。

## **按内容访问文本框**

要查找包含特定关键字（例如 “Slide”）的所有文本框，可遍历形状并检查它们的文本：

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // 只有 AutoShape 可以包含可编辑的文本。
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // 对匹配的文本框执行操作。
            }
        }
    }
}
```

## **按内容删除文本框**

此示例查找并删除第一张幻灯片上包含特定关键字的所有文本框：

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **提示:** 在遍历期间修改形状集合前，始终先创建该集合的副本，以避免集合修改错误。