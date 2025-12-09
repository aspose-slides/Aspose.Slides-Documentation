---
title: 在 .NET 中管理演示文稿的文本段落
linktitle: 文本段落
type: docs
weight: 70
url: /zh/net/portion/
keywords:
- 文本段落
- 文本片段
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中管理文本段落，以提升性能和自定义能力。"
---

## **获取 Portion 的位置坐标**
**GetCoordinates()** 方法已添加到 IPortion 和 Portion 类，允许检索 Portion 起始位置的坐标：
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

**我可以仅对单段落中文本的一部分应用超链接吗？**

是的，您可以[分配超链接](/slides/zh/net/manage-hyperlinks/)到单个 Portion；只有该片段是可点击的，而不是整个段落。

**样式继承是如何工作的：Portion 覆盖了什么，什么是从 Paragraph/TextFrame 继承的？**

Portion 级别的属性具有最高优先级。如果属性未在[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)上设置，引擎会从[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)获取；如果在那里也未设置，则从[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/)样式获取。

**如果在目标机器/服务器上缺少为 Portion 指定的字体，会发生什么？**

会应用[字体替换规则](/slides/zh/net/font-selection-sequence/)。文本可能会重新换行：度量、连字符和宽度可能会改变，这对精确定位很重要。

**我能否为单个 Portion 设置独立于段落其余部分的文本填充透明度或渐变？**

可以，[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)级别的文本颜色、填充和透明度可以与相邻片段不同。