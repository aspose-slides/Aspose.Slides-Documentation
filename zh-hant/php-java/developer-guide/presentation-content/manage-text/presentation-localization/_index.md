---
title: 在 PHP 中自動化投影片本地化
linktitle: 投影片本地化
type: docs
weight: 100
url: /zh-hant/php-java/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 語言 ID
- PowerPoint
- OpenDocument
- 投影片
- PHP
- Aspose.Slides
description: "透過 Java，使用 Aspose.Slides for PHP，自動化 PowerPoint 與 OpenDocument 投影片的本地化，並提供實用程式碼範例與技巧，加速全球部署。"
---
## **概述**

本文說明如何使用 Aspose.Slides 為投影片中的文字設定 `LanguageId`。它展示了如何開啟投影片、加入帶有文字的形狀、將語言識別碼指派給文字區段，並將結果儲存為 PPTX 檔案。

## **變更投影片與形狀文字的語言**
- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
- 透過 Index 取得投影片的參考。
- 在投影片上加入一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)，其類型為 [Rectangle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ShapeType#Rectangle)。
- 在 TextFrame 中加入一些文字。
- [設定 Language Id](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId) 給文字。
- 將投影片寫入為 PPTX 檔案。

以下範例示範上述步驟的實作。

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**語言 ID 會觸發自動文字翻譯嗎？**

不會。Aspose.Slides 中的 [Language ID](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId) 僅用於儲存拼寫檢查與文法校對的語言資訊，並不會翻譯或變更文字內容。它是 PowerPoint 用於校對的中繼資料。

**語言 ID 會影響渲染時的斷字與換行嗎？**

在 Aspose.Slides 中，[language ID](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId) 只用於校對。斷字品質與換行主要取決於[正確的字型](/slides/zh-hant/php-java/powerpoint-fonts/)是否可用，以及針對該書寫系統的版面配置/換行設定。為確保正確的渲染，請確保所需字型可用、設定[字型替代規則](/slides/zh-hant/php-java/font-substitution/)，以及/或將[字型嵌入](/slides/zh-hant/php-java/embedded-font/)至投影片中。

**我可以在同一段落中設定不同的語言嗎？**

可以。[Language ID](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId) 會套用於文字區段層級，因此單一段落可以混合多種語言，並擁有各自的校對設定。