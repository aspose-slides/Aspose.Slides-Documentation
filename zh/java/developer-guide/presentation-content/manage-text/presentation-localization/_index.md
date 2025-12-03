---
title: 用 Java 自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/java/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 语言 id
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中自动化 PowerPoint 和 OpenDocument 幻灯片本地化，提供实用代码示例和加速全球部署的技巧。"
---

## **更改演示文稿和形状文本的语言**
- 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
- 使用其 Index 获取幻灯片的引用。
- 向幻灯片添加类型为[Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle)的[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)。
- 向 TextFrame 添加一些文本。
- 将[Setting Language Id](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-)设置为文本的语言。
- 将演示文稿写入 PPTX 文件。

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


## **常见问题**

**语言 ID 是否会触发自动文本翻译？**

否。[Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)在 Aspose.Slides 中用于拼写检查和语法校对的语言，但它不会翻译或更改文本内容。它是 PowerPoint 用于校对的元数据。

**语言 ID 是否会影响渲染时的连字符和换行？**

在 Aspose.Slides 中，[language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)用于校对。连字符质量和换行主要取决于[proper fonts](/slides/zh/java/powerpoint-fonts/)的可用性以及写入系统的布局/换行设置。为确保正确渲染，请确保所需字体可用，配置[font substitution rules](/slides/zh/java/font-substitution/)，并/或将字体[embed fonts](/slides/zh/java/embedded-font/)嵌入到演示文稿中。

**我可以在同一个段落中设置不同的语言吗？**

可以。[Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)在文本片段级别应用，因此单个段落可以混合多种语言并拥有不同的校对设置。