---
title: 在 PHP 中使用回退字体渲染演示文稿
linktitle: 渲染演示文稿
type: docs
weight: 30
url: /zh/php-java/render-presentation-with-fallback-font/
keywords:
- 回退字体
- 渲染 PowerPoint
- 渲染演示文稿
- 渲染幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中使用回退字体渲染演示文稿——通过一步步代码示例保持 PPT、PPTX 和 ODP 文本一致。"
---

以下示例包括以下步骤：

1. 我们[创建回退字体规则集合](/slides/zh/php-java/create-fallback-fonts-collection/)。
1. [删除](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) 回退字体规则并将[addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)添加到另一个规则。
1. 将规则集合设置为[getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
1. 使用[Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法我们可以将演示文稿保存为相同的格式，或保存为其他格式。将回退字体规则集合设置到[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) 后，这些规则将在对演示文稿的任何操作中应用：保存、渲染、转换等。
```php
  # 创建规则集合的新实例
  $rulesList = new FontFallBackRulesCollection();
  # 创建若干规则
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # 尝试从已加载的规则中移除回退字体 "Tahoma"
    $fallBackRule->remove("Tahoma");
    # 并为指定范围更新规则
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # 同样可以从列表中移除任何现有规则
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # 分配准备好的规则列表以供使用
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # 使用已初始化的规则集合渲染缩略图并保存为 JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 将图像以 JPEG 格式保存到磁盘
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
了解更多关于如何[将 PPT 和 PPTX 转换为 JPG（PHP）](/slides/zh/php-java/convert-powerpoint-to-jpg/)。
{{% /alert %}}