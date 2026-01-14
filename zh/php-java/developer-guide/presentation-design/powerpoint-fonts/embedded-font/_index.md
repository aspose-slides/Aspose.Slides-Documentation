---
title: 使用 PHP 在演示文稿中嵌入字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/php-java/embedded-font/
keywords:
- 添加字体
- 嵌入字体
- 字体嵌入
- 获取嵌入的字体
- 添加嵌入的字体
- 删除嵌入的字体
- 压缩嵌入的字体
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 的 Aspose.Slides for PHP 在 PowerPoint 和 OpenDocument 演示文稿中嵌入 TrueType 字体，确保在所有平台上准确渲染。"
---

**嵌入式字体在 PowerPoint 中** 在您希望演示文稿在任何系统或设备上打开时能够正确显示时非常有用。如果您因为创意使用了第三方或非标准字体，那么更应该嵌入该字体。否则（如果没有嵌入字体），幻灯片上的文字或数字、布局、样式等可能会改变或变成令人困惑的矩形。

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) 类、[FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) 类和 [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) 类包含了处理 PowerPoint 演示文稿中嵌入式字体所需的大部分方法。

## **获取和删除嵌入式字体**

Aspose.Slides 提供了 [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 方法（由 [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) 类公开），让您获取（或查询）演示文稿中嵌入的字体。要删除字体，可使用同一类的 [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) 方法。
```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # 渲染包含使用嵌入 “FunSized” 字体的文本框的幻灯片
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 将图像以 JPEG 格式保存到磁盘
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # 获取所有嵌入的字体
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # 查找 “Calibri” 字体
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # 删除 “Calibri” 字体
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # 渲染演示文稿；“Calibri” 字体将被现有字体替代
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 将图像以 JPEG 格式保存到磁盘
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 将演示文稿（已删除嵌入的 “Calibri” 字体）保存到磁盘
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **添加嵌入式字体**

使用 [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) 类和 [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) 方法的两个重载，您可以选择偏好的（嵌入）规则将字体嵌入到演示文稿中。以下 PHP 代码演示了如何嵌入并添加字体到演示文稿：
```php
  # 加载演示文稿
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # 将演示文稿保存到磁盘
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **压缩嵌入式字体**

为了让您压缩演示文稿中嵌入的字体并减小文件大小，Aspose.Slides 提供了由 [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) 类公开的 [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts) 方法。
```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**如何判断演示文稿中即使已嵌入的特定字体仍会在渲染时被替代？**

请在字体管理器中查看 [substitution information](/slides/zh/php-java/font-substitution/) 和 [fallback/substitution rules](/slides/zh/php-java/fallback-font/)：如果字体不可用或受限，将使用回退字体。

**嵌入像 Arial/Calibri 这样的“系统”字体值得吗？**

通常不需要——这些字体几乎总是可用。但在“精简”环境（Docker、未预装字体的 Linux 服务器）中，为了实现完全可移植性，嵌入系统字体可以消除意外替代的风险。