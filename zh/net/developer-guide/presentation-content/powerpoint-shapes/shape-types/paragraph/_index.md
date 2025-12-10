---
title: 从 .NET 演示文稿获取段落边界
linktitle: 段落
type: docs
weight: 60
url: /zh/net/paragraph/
keywords:
- 段落边界
- 文本块边界
- 段落坐标
- 文本块坐标
- 段落大小
- 文本块大小
- 文本框
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中检索段落和文本块边界，以优化 PowerPoint 演示文稿中的文本定位。"
---

## **获取 TextFrame 中段落和文本块的坐标**
使用 Aspose.Slides for .NET，开发者现在可以获取 TextFrame 中段落集合内段落的矩形坐标。它还允许获取段落中文本块集合内文本块的坐标。在本节中，我们将通过示例演示如何获取段落的矩形坐标以及段落内部文本块的位置。

## **获取段落的矩形坐标**
已添加新方法 **GetRect()**。该方法可以获取段落的边界矩形。
```c#
 // 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **获取表格单元格 TextFrame 中段落和文本块的大小**
要获取表格单元格 TextFrame 中 [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) 或 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) 的大小和坐标，可以使用 [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) 和 [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) 方法。

以下示例代码演示了上述操作：
```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```


## **FAQ**

**段落和文本块的坐标以什么单位返回？**  
以点（points）为单位，1 英寸 = 72 点。这适用于幻灯片上的所有坐标和尺寸。

**自动换行会影响段落的边界吗？**  
会。若在 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) 中启用了 [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)，文本会根据区域宽度换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**  
可以。使用公式 pixels = points × (DPI / 72) 将点转换为像素。结果取决于渲染/导出时选择的 DPI。

**如何获取“effective”段落格式参数，以考虑样式继承？**  
使用 [effective paragraph formatting data structure](/slides/zh/net/shape-effective-properties/)，它会返回缩进、间距、换行、RTL 等属性的最终合并值。