---
title: 演示文稿本地化
type: docs
weight: 100
url: /zh/nodejs-java/presentation-localization/
---

## **更改演示文稿和形状文本的语言**

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 向幻灯片添加一个类型为 [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。
- 向 TextFrame 添加一些文本。
- 对文本设置 [Setting Language Id](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-)。
- 将演示文稿写入为 PPTX 文件。

下面的示例演示了上述步骤的实现。
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**语言 ID 会触发自动文本翻译吗？**

不。Aspose.Slides 中的 [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 用于存储用于拼写检查和语法校对的语言，但它不会翻译或更改文本内容。它是 PowerPoint 能够理解的校对元数据。

**语言 ID 会影响呈现时的连字符和换行吗？**

在 Aspose.Slides 中，[setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 用于校对。连字符质量和换行主要取决于 [proper fonts](/slides/zh/nodejs-java/powerpoint-fonts/) 的可用性以及书写系统的布局/换行设置。为确保正确渲染，请提供所需的字体，配置 [font substitution rules](/slides/zh/nodejs-java/font-substitution/)，并/或将 [embed fonts](/slides/zh/nodejs-java/embedded-font/) 嵌入演示文稿。

**我可以在同一段落中设置不同的语言吗？**

可以。[setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 在文本段落级别应用，因此单个段落可以混合多种语言并拥有不同的校对设置。