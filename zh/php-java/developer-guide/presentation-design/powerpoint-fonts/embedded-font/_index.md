---
title: 嵌入式字体 - PowerPoint Java API
linktitle: 嵌入式字体
type: docs
weight: 40
url: /zh/php-java/embedded-font/
keywords: "字体, 嵌入式字体, 添加字体, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "在 PowerPoint 演示文稿中使用嵌入式字体"

---

**PowerPoint中的嵌入式字体**在您希望演示文稿在任何系统或设备上正确显示时非常有用。如果您使用了第三方或非标准字体，因为您在工作中发挥了创造力，那么您有更多的理由嵌入您的字体。否则（没有嵌入式字体），幻灯片上的文本或数字、布局、样式等可能会更改或变成令人困惑的矩形。

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)类, [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/)类, [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)类及其接口包含您在PowerPoint演示文稿中处理嵌入式字体所需的大部分属性和方法。

## **从演示文稿中获取或移除嵌入式字体**

Aspose.Slides提供了[getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--)方法（由[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)类公开），允许您获取（或查找）嵌入到演示文稿中的字体。要移除字体，可以使用[removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)方法（由同一类公开）。

以下PHP代码演示了如何从演示文稿中获取和移除嵌入式字体：

```php
  # 实例化一个表示演示文稿文件的Presentation对象
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # 渲染一个包含使用嵌入式“FunSized”字体的文本框的幻灯片
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 将图像以JPEG格式保存到磁盘
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # 获取所有嵌入式字体
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # 找到“Calibri”字体
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # 移除“Calibri”字体
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # 渲染演示文稿；“Calibri”字体被现有字体替换
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 将图像以JPEG格式保存到磁盘
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 将没有嵌入“Calibri”字体的演示文稿保存到磁盘
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **向演示文稿中添加嵌入式字体**

使用[EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/)枚举和[addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)方法的两个重载，您可以选择您偏好的（嵌入）规则，将字体嵌入到演示文稿中。以下PHP代码演示了如何将字体嵌入并添加到演示文稿中：

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

Aspose.Slides提供了[compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-)方法（由[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)类公开），允许您压缩嵌入到演示文稿中的字体，从而减少其文件大小。

以下PHP代码演示了如何压缩嵌入的PowerPoint字体：

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