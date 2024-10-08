---
title: 段落
type: docs
weight: 60
url: /net/paragraph/
keywords: "段落, 部分, 段落坐标, 部分坐标, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中的 PowerPoint 演示文稿中的段落和部分"
---

## **获取文本框中的段落和部分坐标**
使用 Aspose.Slides for .NET，开发人员现在可以获取文本框中的段落集合中的段落的矩形坐标。它还允许您获取段落的部分集合中的部分坐标。在本主题中，我们将通过示例演示如何获取段落的矩形坐标以及段落中部分的位置。

## **获取段落的矩形坐标**
新增了 **GetRect()** 方法。它允许获取段落边界矩形。

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **获取表格单元格文本框内段落和部分的大小** ##

要获取表格单元格文本框中的 [部分](https://reference.aspose.com/slides/net/aspose.slides/portion) 或 [段落](https://reference.aspose.com/slides/net/aspose.slides/paragraph) 的大小和坐标，可以使用 [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) 和 [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) 方法。

以下示例代码演示了所描述的操作：

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