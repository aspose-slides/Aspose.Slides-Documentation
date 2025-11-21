---
title: 在 .NET 中自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/net/presentation-localization/
keywords:
  - 更改语言
  - 拼写检查
  - 语言 ID
  - PowerPoint
  - 演示文稿
  - .NET
  - C#
  - Aspose.Slides
description: ".NET 中使用 Aspose.Slides 自动化 PowerPoint 和 OpenDocument 幻灯片本地化，提供实用的 C# 示例代码和加速全球发布的技巧。"
---

## **更改演示文稿和形状文本的语言**
- 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 向幻灯片添加矩形类型的 AutoShape。
- 向 TextFrame 添加一些文本。
- 为文本设置 Language Id。
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

不。 [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 在 Aspose.Slides 中用于存储拼写检查和语法校对的语言，但它不会翻译或更改文本内容。它是 PowerPoint 用于校对的元数据。

**语言 ID 会影响渲染时的连字符和换行吗？**

在 Aspose.Slides 中， [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 用于校对。连字符质量和换行主要取决于 [proper fonts](/slides/zh/net/powerpoint-fonts/) 的可用性以及书写系统的布局/换行设置。要确保正确渲染，请提供所需的字体，配置 [font substitution rules](/slides/zh/net/font-substitution/)，和/或将字体 [embed fonts](/slides/zh/net/embedded-font/) 到演示文稿中。

**我可以在同一个段落中设置不同的语言吗？**

可以。 [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 在文本片段级别应用，因此一个段落可以混合多种语言并使用不同的校对设置。