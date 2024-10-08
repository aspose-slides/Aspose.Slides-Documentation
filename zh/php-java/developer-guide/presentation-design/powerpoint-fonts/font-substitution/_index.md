---
title: 字体替换 - PowerPoint Java API
linktitle: 字体替换
type: docs
weight: 70
url: /php-java/font-substitution/
keywords: "字体, 替代字体, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "在 PowerPoint 中替换字体"
---

Aspose.Slides 允许您设置字体规则，以确定在特定情况下（例如，当字体无法访问时）必须执行的操作，如下所示：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 添加替换规则。
5. 将规则添加到演示文稿字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

以下 PHP 代码演示了字体替换过程：

```php
  # 加载演示文稿
  $pres = new Presentation("Fonts.pptx");
  try {
    # 加载将被替换的源字体
    $sourceFont = new FontData("SomeRareFont");
    # 加载新字体
    $destFont = new FontData("Arial");
    # 添加一个字体替换规则
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # 将规则添加到字体替代规则集合中
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # 将字体规则集合添加到规则列表中
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # 当某个字体不可访问时，将使用 Arial 字体代替 SomeRareFont
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 将图像保存到磁盘，格式为 JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
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

{{%  alert title="注意"  color="warning"   %}} 

您可能想查看 [**字体替换**](/slides/php-java/font-replacement/)。

{{% /alert %}}