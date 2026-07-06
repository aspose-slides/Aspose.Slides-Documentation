---
title: 从 .NET 演示文稿中获取文本段边界
linktitle: 段落范围
type: docs
weight: 47
url: /zh/net/portion-bounds/
keywords:
- 文本段边界
- 文本段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中检索文本段边界。"
---
## **概述**

文本段表示段落内的特定文本片段，并允许您独立于周围内容对该片段进行操作。在 Aspose.Slides 中，当您需要获取文本片段的边界、仅对段落的一部分应用格式，或在更细粒度上控制文本行为时，可以使用文本段。

本文展示了如何使用[IPortion.GetRect](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/getrect/)获取文本段的边界矩形。它还展示了如何使用[IPortion.GetCoordinates](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/getcoordinates/)获取文本段起始位置的坐标。此外，还重点介绍了常见的与文本段相关的场景，例如对单个文本片段应用超链接、了解格式如何通过文本段、段落、文本框和主题继承进行解析，以及处理指定字体不可用的情况。

## **获取文本段的边界**

使用[IPortion.GetRect](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/getrect/)检索文本段的边界矩形：

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **获取文本段的坐标**

使用[IPortion.GetCoordinates](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/getcoordinates/)检索文本段起始位置的坐标：

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **常见问题**

**我可以只为单个段落中的部分文本应用超链接吗？**

是的，您可以对单个文本段[分配超链接](/slides/zh/net/manage-hyperlinks/)。只有该片段是可点击的，而不是整段。

**样式继承是如何工作的：文本段会覆盖哪些属性，哪些属性来源于段落或文本框？**

文本段级别的属性具有最高优先级。如果属性未在[IPortion](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/)上设置，Aspose.Slides 将从[IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/)中获取。如果在那里仍未设置，Aspose.Slides 将使用[ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)或[theme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/theme/)的样式。

**如果在目标机器或服务器上缺少文本段指定的字体会怎样？**

[字体替换规则](/slides/zh/net/font-selection-sequence/)将被应用。文本可能会重新换行：度量、连字和宽度可能会变化，这会影响精确定位。

**我可以为文本段单独设置文字填充透明度或渐变，而不影响段落的其他部分吗？**

可以，位于[IPortion](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/)级别的文字颜色、填充和透明度可以与相邻片段不同。