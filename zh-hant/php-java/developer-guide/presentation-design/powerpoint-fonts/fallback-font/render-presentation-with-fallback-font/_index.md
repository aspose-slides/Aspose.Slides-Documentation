---
title: 在 PHP 中使用備援字型呈現簡報
linktitle: 呈現簡報
type: docs
weight: 30
url: /zh-hant/php-java/render-presentation-with-fallback-font/
keywords:
- 備援字型
- 呈現 PowerPoint
- 呈現簡報
- 呈現投影片
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "透過 Java 在 Aspose.Slides for PHP 中使用備援字型呈現簡報 – 讓文字在 PPT、PPTX 與 ODP 之間保持一致，並提供逐步程式碼範例。"
---
## **概觀**

Aspose.Slides 允許您使用備援字型規則來呈現簡報。本文說明如何建立備援字型規則集合、透過移除或新增備援字型來修改其規則，並將該集合指派給 `FontsManager::setFontFallBackRulesCollection` 方法。

一旦將備援字型規則集合指派給簡報的 `FontsManager`，這些規則會在儲存、呈現與轉換簡報等操作期間套用。範例示範了在呈現投影片縮圖並將其儲存為 PNG 影像時，如何使用已配置的規則。

## **使用備援字型規則呈現投影片**

1. 我們[建立備援字型規則集合](/slides/zh-hant/php-java/create-fallback-fonts-collection/)。
2. [移除](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) 一個備援字型規則，並將[addFallBackFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 新增至另一個規則。
3. 將規則集合設定給[getFontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
4. 使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法，我們可以將簡報儲存為相同格式，或儲存為其他格式。當備援字型規則集合被設定至[FontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontsManager) 後，這些規則會在簡報的任何操作期間套用：儲存、呈現、轉換等。

```php
  # 建立規則集合的新實例
  $rulesList = new FontFallBackRulesCollection();
  # 建立多筆規則
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # 嘗試從已載入的規則中移除備援字型「Tahoma」
    $fallBackRule->remove("Tahoma");
    # 並針對指定範圍更新規則
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # 也可以從清單中移除任何現有規則
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # 指派已準備好的規則清單以供使用
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # 使用已初始化的規則集合渲染縮圖並儲存為 JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 將影像以 JPEG 格式儲存至磁碟
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
了解更多有關如何在 PHP 中[將 PPT 和 PPTX 轉換為 JPG](/slides/zh-hant/php-java/convert-powerpoint-to-jpg/)。
{{% /alert %}}