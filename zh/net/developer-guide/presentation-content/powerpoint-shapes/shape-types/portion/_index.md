---
title: 在 .NET 中管理演示文稿的文本片段
linktitle: 文本片段
type: docs
weight: 70
url: /zh/net/portion/
keywords:
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中管理文本片段，从而提升性能和自定义能力。"
---

## **获取文本片段的坐标**
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

**我可以仅对单段落中的部分文字应用超链接吗？**

是的，您可以[分配超链接](/slides/zh/net/manage-hyperlinks/)给单独的片段；只有该片段可点击，而不是整个段落。

**样式继承是如何工作的：Portion 覆盖了哪些属性，哪些属性来自 Paragraph/TextFrame？**

Portion 级别的属性具有最高优先级。如果属性未在[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)上设置，渲染引擎会从[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)获取；如果在那里也未设置，则从[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/)样式获取。

**如果在目标机器/服务器上缺少为 Portion 指定的字体，会发生什么？**

[字体替换规则](/slides/zh/net/font-selection-sequence/)将生效。文本可能会重新换行：度量、连字符和宽度可能会变化，这会影响精确定位。

**我可以为特定 Portion 设置文本填充透明度或渐变，而不影响段落的其他部分吗？**

是的，在[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)级别，文本颜色、填充和透明度可以与相邻片段不同。