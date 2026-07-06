---
title: 在 .NET 中获取演示文稿的段落边界
linktitle: 段落边界
type: docs
weight: 43
url: /zh/net/paragraph-bounds/
keywords:
- 段落边界
- 段落坐标
- 段落大小
- 文本框
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中检索段落边界，以优化 PowerPoint 演示文稿中的文本定位。"
---
## **概述**

本文说明了如何获取 Aspose.Slides 中段落的边界、大小和坐标。它展示了如何通过使用 [IParagraph.GetRect](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/getrect/) 从 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 检索段落矩形，如何获取表格单元格文本框内段落的坐标，并重点说明了测量单位、换行对边界的影响、像素转换以及有效段落格式化值等重要细节。

## **获取段落的矩形坐标**

使用 [IParagraph.GetRect](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/getrect/) 获取段落的边界矩形。

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **获取表格单元格 TextFrame 中段落的大小**

要获取表格单元格文本框中 [IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/) 的大小和坐标，请使用 [IParagraph.GetRect](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/getrect/)。返回的矩形是相对于表格单元格文本框的，因此在需要幻灯片级别坐标时，需要加上表格位置和单元格偏移量。

下面的示例获取表格单元格内段落的边界，并在幻灯片上绘制矩形以可视化这些边界：

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **常见问题**

**段落坐标使用什么单位测量？**

它们使用点（point）作为单位，1 英寸等于 72 点。这适用于幻灯片上的所有坐标和尺寸。

**换行会影响段落的边界吗？**

是的。如果为 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 启用了 [TextFrameFormat.WrapText](https://reference.aspose.com/slides/zh/net/aspose.slides/textframeformat/wraptext/)，则文本会根据区域宽度换行，这会改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用以下公式将点转换为像素：像素 = 点 × (DPI / 72)。结果取决于渲染或导出时选择的 DPI。

**如何获取考虑样式继承的“有效”段落格式化参数？**

使用 [有效段落格式化数据结构](/slides/zh/net/shape-effective-properties/)，它返回缩进、间距、换行、RTL 等的最终合并值。