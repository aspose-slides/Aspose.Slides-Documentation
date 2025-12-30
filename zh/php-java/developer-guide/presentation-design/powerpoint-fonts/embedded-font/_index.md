---
title: 在演示文稿中使用 PHP 嵌入字体
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
- 移除嵌入的字体
- 压缩嵌入的字体
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 的 Aspose.Slides for PHP 将 TrueType 字体嵌入 PowerPoint 和 OpenDocument 演示文稿，确保在所有平台上准确渲染。"
---

**嵌入的字体在 PowerPoint 中** 在您希望演示文稿在任何系统或设备上打开时都能正确显示时非常有用。如果您使用了第三方或非标准字体来发挥创意，那么就更有理由嵌入字体。否则（未嵌入字体），幻灯片上的文本或数字、布局、样式等可能会变化或变成乱码的方框。

The [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) class, [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) class, and their interfaces contain most of the properties and methods you need to work with embedded fonts in PowerPoint presentations.

## **获取并移除嵌入的字体**

Aspose.Slides 提供了由 [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) 类公开的 [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) 方法，帮助您获取（或查明）演示文稿中嵌入的字体。要移除字体，可使用同一类的 [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) 方法。

以下 PHP 代码演示了如何获取和移除演示文稿中的嵌入字体：
```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # 渲染包含使用嵌入的 "FunSized" 字体的文本框的幻灯片
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 以 JPEG 格式将图像保存到磁盘
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
    # 查找 "Calibri" 字体
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # 移除 "Calibri" 字体
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # 渲染演示文稿；"Calibri" 字体被现有字体替换
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 以 JPEG 格式将图像保存到磁盘
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 将未嵌入 "Calibri" 字体的演示文稿保存到磁盘
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **添加嵌入的字体**

使用 [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) 枚举和 [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) 方法的两个重载，您可以选择首选的（嵌入）规则将字体嵌入演示文稿。以下 PHP 代码演示了如何在演示文稿中嵌入并添加字体：
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


## **压缩嵌入的字体**

为了让您能够压缩演示文稿中嵌入的字体并减小文件大小，Aspose.Slides 提供了由 [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) 类公开的 [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 方法。

以下 PHP 代码演示了如何压缩嵌入的 PowerPoint 字体：
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

**如何判断演示文稿中的特定字体在渲染时仍会被替换，即使已嵌入？**

检查字体管理器中的 [substitution information](/slides/zh/php-java/font-substitution/) 和 [fallback/substitution rules](/slides/zh/php-java/fallback-font/)：如果字体不可用或受限，将使用后备字体。

**嵌入像 Arial/Calibri 这样的“系统”字体是否值得？**

通常不值得——它们几乎总是可用。但在“精简”环境（Docker、未预装字体的 Linux 服务器）中，为了实现完全可移植性，嵌入系统字体可以消除意外替换的风险。