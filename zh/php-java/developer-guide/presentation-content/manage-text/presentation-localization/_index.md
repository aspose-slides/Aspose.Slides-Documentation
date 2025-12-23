---
title: 在 PHP 中自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/php-java/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 语言 ID
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 使用 Aspose.Slides for PHP，自动化 PowerPoint 和 OpenDocument 幻灯片的本地化，提供实用代码示例和技巧，加快全球部署。"
---

## **更改演示文稿和形状文本的语言**
- 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 通过使用其 Index 获取幻灯片的引用。
- 向幻灯片添加一种 [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) 类型的 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)。
- 向 TextFrame 添加一些文本。
- 为文本[Setting Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-)。
- 将演示文稿写入 PPTX 文件。

下面的示例演示了上述步骤的实现。  
```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**语言 ID 会触发自动文本翻译吗？**

不会。[Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) 在 Aspose.Slides 中存储用于拼写检查和语法校对的语言，但它不会翻译或更改文本内容。它是 PowerPoint 用于校对的元数据。

**语言 ID 在渲染时会影响连字符和换行吗？**

在 Aspose.Slides 中，语言 ID 用于校对。连字符质量和换行主要取决于 [proper fonts](/slides/zh/php-java/powerpoint-fonts/) 和写入系统的布局/换行设置。为了确保正确渲染，请提供所需字体，配置 [font substitution rules](/slides/zh/php-java/font-substitution/)，以及/或 [embed fonts](/slides/zh/php-java/embedded-font/) 到演示文稿。

**我可以在单个段落中设置不同的语言吗？**

可以。[Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) 应用于文本片段级别，因此单个段落可以混合多种语言并拥有不同的校对设置。