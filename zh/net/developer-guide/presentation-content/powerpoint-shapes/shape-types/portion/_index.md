---
title: 部分
type: docs
weight: 70
url: /zh/net/portion/
keywords: "部分, PowerPoint 形状, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中获取 PowerPoint 演示文稿中的部分"
---

## **获取部分的位置坐标**
**GetCoordinates()** 方法已被添加到 IPortion 和 Portion 类中，允许检索部分的起始坐标：

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
            Console.Write(Environment.NewLine + "坐标 X =" + point.X + " 坐标 Y =" + point.Y);
        }
    }
}
```