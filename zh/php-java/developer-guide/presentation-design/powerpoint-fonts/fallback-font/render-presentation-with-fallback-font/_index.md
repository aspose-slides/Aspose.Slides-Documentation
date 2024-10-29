---
title: 使用替代字体渲染演示文稿
type: docs
weight: 30
url: /zh/php-java/render-presentation-with-fallback-font/
---

以下示例包括这些步骤：

1. 我们 [创建替代字体规则集合](/slides/zh/php-java/create-fallback-fonts-collection/)。
1. [移除](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) 一个替代字体规则并 [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 添加到另一个规则中。
1. 将规则集合设置为 [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--)。 [getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
1. 通过 [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法，我们可以以相同的格式保存演示文稿，或以其他格式保存。在替代字体规则集合设置为 [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) 后，这些规则在对演示文稿的任何操作中应用：保存、渲染、转换等。

```php
  # 创建规则集合的新实例
  $rulesList = new FontFallBackRulesCollection();
  # 创建多个规则
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # 尝试从加载的规则中移除替代字体 "Tahoma"
    $fallBackRule->remove("Tahoma");
    # 并更新指定范围的规则
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # 我们还可以从列表中移除任何现有规则
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # 分配准备好的规则列表以供使用
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # 使用初始化的规则集合渲染缩略图并保存为 JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 以 JPEG 格式将图像保存到磁盘
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
阅读更多关于 [演示文稿中的保存和转换](/slides/zh/php-java/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}