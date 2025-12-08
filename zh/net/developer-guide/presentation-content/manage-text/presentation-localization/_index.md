---
title: 演示文稿本地化
type: docs
weight: 100
url: /zh/net/presentation-localization/
keywords: "更改语言, 拼写检查, 拼写检查, 拼写检查器, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 PowerPoint 演示文稿中更改或检查语言。使用 C# 或 .NET 进行拼写检查文本。"
---

## **更改演示文稿和形状文本的语言**
- 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 向幻灯片添加矩形类型的 AutoShape。
- 向 TextFrame 添加一些文本。
- 设置文本的 Language Id。
- 将演示文稿写入 PPTX 文件。

下面的示例演示了上述步骤的实现。
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

**语言 ID 会触发自动文本翻译吗？**

不会。[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 在 Aspose.Slides 中用于存储用于拼写检查和语法校对的语言，但它不会翻译或更改文本内容。它是 PowerPoint 用于校对的元数据。

**语言 ID 会影响渲染过程中的连字符和换行吗？**

在 Aspose.Slides 中，[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 用于校对。连字符质量和换行主要取决于[合适的字体](/slides/zh/net/powerpoint-fonts/)的可用性以及书写系统的布局/换行设置。为了确保正确渲染，请确保所需字体可用，配置[字体替换规则](/slides/zh/net/font-substitution/)，并/或将[嵌入字体](/slides/zh/net/embedded-font/)嵌入演示文稿。

**我可以在单个段落中设置不同的语言吗？**

可以。[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 在文本片段级别应用，因此单个段落可以混合多种语言并使用不同的校对设置。
