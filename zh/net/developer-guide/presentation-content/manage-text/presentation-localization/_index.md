---
title: 演示文稿本地化
type: docs
weight: 100
url: /zh/net/presentation-localization/
keywords: "更改语言, 拼写检查, 拼写检查, 拼写检查器, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 PowerPoint 演示文稿中更改或检查语言。使用 C# 或 .NET 进行拼写检查。"
---

## **更改演示文稿和形状文本的语言**
- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 向幻灯片添加一个矩形类型的 AutoShape。
- 向 TextFrame 添加一些文本。
- 为文本设置 Language Id。
- 将演示文稿写入为 PPTX 文件。

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **常见问题**

**language_id 会触发自动文本翻译吗？**

否。Aspose.Slides 中的 [language_id](https://reference.aspose.com/slides/net/aspose.slides/portionformat/languageid/) 用于存储用于拼写检查和语法校对的语言，但它不翻译或更改文本内容。它是 PowerPoint 用于校对的元数据。

**language_id 会影响渲染时的连字符和换行吗？**

在 Aspose.Slides 中，[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 用于校对。连字符质量和换行主要取决于 [proper fonts](/slides/zh/net/powerpoint-fonts/) 的可用性以及针对书写系统的布局/换行设置。为确保正确渲染，需要提供所需字体，配置 [font substitution rules](/slides/zh/net/font-substitution/)，和/或将字体 [embed fonts](/slides/zh/net/embedded-font/) 到演示文稿中。

**我可以在同一段落中设置不同的语言吗？**

是的。[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 在文本段落级别应用，因此单个段落可以混合多种语言并具有不同的校对设置。