---
title: 段落
type: docs
weight: 60
url: /zh/net/paragraph/
keywords: "段落, 片段, 段落坐标, 片段坐标, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中的 PowerPoint 演示文稿中的段落和片段"
---

## **获取 TextFrame 中段落和片段的坐标**
使用 Aspose.Slides for .NET，开发者现在可以获取 TextFrame 中段落集合内 Paragraph 的矩形坐标。它还允许获取段落中片段集合内 Portion 的坐标。在本主题中，我们将通过示例演示如何获取段落的矩形坐标以及段落内片段的位置。

## **获取段落的矩形坐标**
已添加新方法 **GetRect()**，它可以获取段落的边界矩形。
```c#
// 实例化一个表示演示文件的 Presentation 对象
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **获取表格单元格文本框中段落和片段的大小**

要获取表格单元格文本框中 [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) 或 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) 的大小和坐标，可以使用 [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) 和 [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) 方法。

下面的示例代码演示了上述操作：
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

**段落和文本片段的坐标以什么单位返回？**

以点 (point) 为单位，1 英寸 = 72 点。此单位适用于幻灯片上的所有坐标和尺寸。

**自动换行会影响段落的边界吗？**

会。若在 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) 中启用了 [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)，文本会根据区域宽度换行，从而改变段落的实际边界。

**段落坐标可以可靠地映射到导出图像的像素吗？**

可以。使用公式：pixels = points × (DPI / 72) 将点转换为像素。结果取决于渲染/导出时选择的 DPI。

**如何获取考虑样式继承后的“有效”段落格式参数？**

使用 [effective paragraph formatting data structure](/slides/zh/net/shape-effective-properties/)；它返回缩进、间距、换行、RTL 等属性的最终合并值。