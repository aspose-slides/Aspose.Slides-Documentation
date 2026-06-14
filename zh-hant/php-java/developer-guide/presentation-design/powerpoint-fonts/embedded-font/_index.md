---
title: 使用 PHP 在簡報中嵌入字型
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/php-java/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得嵌入的字型
- 加入嵌入字型
- 移除嵌入的字型
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 透過 Java 在 PowerPoint 與 OpenDocument 簡報中嵌入 TrueType 字型，確保在所有平台上的渲染精確無誤。"
---
## **簡介**

**PowerPoint 中的嵌入字型** 在您希望簡報於任何系統或裝置上開啟時都能正確顯示時非常有用。若因為在作品中發揮創意而使用了第三方或非標準字型，則更應該將字型嵌入。否則（未嵌入字型），投影片上的文字或數字、版面配置、樣式等可能會變更，甚至變成難以辨識的方塊。

[FontsManager] 類別、[FontData] 類別與 [Compress] 類別包含了處理 PowerPoint 簡報中嵌入字型所需的大部分方法。

## **取得與移除嵌入字型**

Aspose.Slides 提供了由 [FontsManager] 類別所公開的 [getEmbeddedFonts] 方法，讓您取得（或查詢）簡報中嵌入的字型。若要移除字型，則使用同一類別的 [removeEmbeddedFont] 方法。

以下 PHP 程式碼示範如何從簡報中取得與移除嵌入字型：

```php
  # 實例化一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # 轉換包含使用嵌入 \"FunSized\" 字型的文字框的投影片
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 將影像以 JPEG 格式儲存到磁碟
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # 取得所有嵌入的字型
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # 找尋 \"Calibri\" 字型
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # 移除 \"Calibri\" 字型
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # 轉換簡報； \"Calibri\" 字型將被現有字型取代
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 將影像以 JPEG 格式儲存到磁碟
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 將未嵌入 \"Calibri\" 字型的簡報儲存到磁碟
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **加入嵌入字型**

使用 [EmbedFontCharacters] 類別以及 [addEmbeddedFont] 方法的兩個重載，您可以選擇偏好的（嵌入）規則，將字型嵌入簡報中。以下 PHP 程式碼示範如何在簡報中嵌入與加入字型：

```php
  # 載入簡報
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
    # 將簡報儲存至磁碟
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **壓縮嵌入字型**

為了讓您壓縮簡報中嵌入的字型以減少檔案大小，Aspose.Slides 提供了由 [Compress] 類別所公開的 [compressEmbeddedFonts] 方法。

以下 PHP 程式碼示範如何壓縮嵌入的 PowerPoint 字型：

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

## **FAQ**

**如何判斷簡報中即使已嵌入仍會在呈現時被替代的特定字型？**

請檢查字型管理員中的 [替代資訊](/slides/zh-hant/php-java/font-substitution/) 以及 [備援/替代規則](/slides/zh-hant/php-java/fallback-font/)：若字型不可用或受限，系統會使用備援字型。

**將「系統」字型（如 Arial / Calibri）嵌入是否有價值？**

通常不需要——這類字型幾乎隨處可得。但在「精簡」環境（Docker、未預先安裝字型的 Linux 伺服器）中，若要確保完整可移植性，嵌入系統字型可避免意外的替代風險。