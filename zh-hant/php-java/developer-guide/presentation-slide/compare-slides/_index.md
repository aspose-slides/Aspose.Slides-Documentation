---
title: 在 PHP 中比較簡報投影片
linktitle: 比較投影片
type: docs
weight: 50
url: /zh-hant/php-java/compare-slides/
keywords:
- 比較投影片
- 投影片比較
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（透過 Java）以程式方式比較 PowerPoint 與 OpenDocument 簡報。快速在程式碼中辨識投影片差異。"
---
## **簡介**

Aspose.Slides 允許您使用 `BaseSlide` 類別提供的 `equals` 方法比較投影片、版面投影片和母片。當比較的投影片在結構與靜態內容上完全相同時，該方法會回傳 `true`。

## **比較兩張投影片**

已在 [BaseSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/BaseSlide) 類別中加入 Equals 方法。它會對結構與靜態內容相同的投影片/版面和投影片/母片回傳 true。

當所有形狀、樣式、文字、動畫及其他設定等皆相同時，兩張投影片被視為相等。比較時不會考慮唯一識別碼值，例如 SlideId，亦不會考慮動態內容，例如日期佔位字元中的目前日期值。

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **常見問題**

**投影片被隱藏會影響投影片本身的比較嗎？**

[Hidden status](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/gethidden/) 是呈現/播放層級的屬性，而非視覺內容。兩張特定投影片的相等性取決於其結構與靜態內容；僅因投影片被隱藏並不會使投影片不同。

**超連結及其參數會被考慮嗎？**

是的。連結屬於投影片的靜態內容。若 URL 或超連結動作不同，通常會被視為靜態內容的差異。

**如果圖表引用外部 Excel 檔案，該檔案的內容會被考慮嗎？**

不會。比較是根據投影片本身執行的。外部資料來源通常不會在比較時讀取；僅考慮投影片結構與靜態狀態中存在的內容。