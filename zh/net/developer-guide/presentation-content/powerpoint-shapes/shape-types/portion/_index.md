---
title: 片段
type: docs
weight: 70
url: /zh/net/portion/
keywords: "片段, PowerPoint 形状, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中获取 PowerPoint 演示文稿中的片段"
---

## **获取片段的位置坐标**
**GetCoordinates()** 方法已添加到 IPortion 和 Portion 类，允许检索片段起始位置的坐标：
```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```


## **常见问题**

**我能仅对单段落中的部分文字应用超链接吗？**

是的，您可以[分配超链接](/slides/zh/net/manage-hyperlinks/)到单个片段；只有该片段可点击，而不是整段文字。

**样式继承是如何工作的：片段覆盖了哪些属性，哪些属性来自段落/文本框？**

片段级别的属性具有最高优先级。如果属性未在[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)上设置，引擎会从[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)获取；如果在那里也未设置，则从[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/)样式获取。

**如果在目标机器/服务器上缺少片段指定的字体，会怎样？**

[Font substitution rules](/slides/zh/net/font-selection-sequence/) 将被应用。文本可能会重排：度量、连字符和宽度可能会改变，这会影响精确定位。

**我能为片段单独设置文字填充透明度或渐变，而不影响段落的其他部分吗？**

是的，位于[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)级别的文字颜色、填充和透明度可以与相邻片段不同。