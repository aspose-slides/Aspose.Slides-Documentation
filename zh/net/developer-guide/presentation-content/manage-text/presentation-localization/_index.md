---
title: 演示文稿本地化
type: docs
weight: 100
url: /zh/net/presentation-localization/
keywords: "更改语言, 拼写检查, 拼写检查, 拼写检查工具, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 PowerPoint 演示文稿中更改或检查语言。 在 C# 或 .NET 中进行拼写检查"
---
## **更改演示文稿和形状文本的语言**
- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 向幻灯片添加一个矩形类型的自动形状。
- 向文本框添加一些文本。
- 将语言 ID 设置为文本。
- 将演示文稿写入 PPTX 文件。

以上步骤的实现如下示例所示。

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("应用拼写检查语言的文本");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```