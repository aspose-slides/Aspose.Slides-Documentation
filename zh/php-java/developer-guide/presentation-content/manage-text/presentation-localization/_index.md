---
title: 演示文稿本地化
type: docs
weight: 100
url: /php-java/presentation-localization/
---

## **更改演示文稿和形状的文本语言**
- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 通过使用幻灯片的索引获取幻灯片的引用。
- 向幻灯片中添加一个类型为 [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) 的 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)。
- 向文本框中添加一些文本。
- [设置语言 ID](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) 到文本。
- 将演示文稿写入 PPTX 文件。

上述步骤的实现如下示例所示。

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("要应用拼写检查语言的文本");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```