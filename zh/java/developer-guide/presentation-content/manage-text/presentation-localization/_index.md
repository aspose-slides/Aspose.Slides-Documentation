---
title: 在 Java 中自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/java/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 语言 ID
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中自动化 PowerPoint 和 OpenDocument 幻灯片本地化，提供实用代码示例和技巧，加速全球发布。"
---

## **更改演示文稿和形状文本的语言**
- 创建 Presentation 类的实例。
- 通过使用索引获取幻灯片的引用。
- 向幻灯片添加一个 Rectangle 类型的 IAutoShape。
- 向 TextFrame 添加一些文本。
- 为文本设置语言 Id。
- 将演示文稿写入为 PPTX 文件。

下面的示例演示了上述步骤的实现。
```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**语言 ID 会触发自动文本翻译吗？**

不会。 [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 在 Aspose.Slides 中用于拼写检查和语法校对，但它不会翻译或更改文本内容。它是 PowerPoint 用于校对的元数据。

**语言 ID 会影响渲染时的连字符和换行吗？**

在 Aspose.Slides 中， [language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 用于校对。连字符质量和换行主要取决于 [proper fonts](/slides/zh/java/powerpoint-fonts/) 的可用性以及书写系统的布局/换行设置。为确保正确渲染，请提供所需字体，配置 [font substitution rules](/slides/zh/java/font-substitution/)，并/或将 [embed fonts](/slides/zh/java/embedded-font/) 嵌入到演示文稿中。

**我可以在同一段落中设置不同的语言吗？**

可以。 [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 在文本片段级别应用，因此单个段落可以混合多种语言，并使用不同的校对设置。