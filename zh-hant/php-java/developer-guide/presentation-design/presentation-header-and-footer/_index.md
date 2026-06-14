---
title: 在 PHP 中管理簡報的頁首與頁腳
linktitle: 頁首與頁腳
type: docs
weight: 140
url: /zh-hant/php-java/presentation-header-and-footer/
keywords:
- 頁首
- 頁首文字
- 頁腳
- 頁腳文字
- 設定頁首
- 設定頁腳
- 講義
- 註解
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 為 PowerPoint 與 OpenDocument 簡報加入與自訂頁首與頁腳，以獲得專業外觀。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中管理頁首與頁腳設定。頁首與頁腳在簡報母片層級上處理，API 提供設定頁腳文字、變更頁腳可見性，以及在母片註解投影片上更新頁首文字的方法。

您也可以管理講義與註解投影片的頁首與頁腳。這包括變更註解母片、所有子註解投影片或單一註解投影片的頁首、頁腳、投影片編號與日期時間佔位符的可見性與文字。

## **在簡報中管理頁首與頁腳**

如下例所示，某些特定投影片的註解可以被移除：

```php
  # 載入簡報
  $pres = new Presentation("headerTest.pptx");
  try {
    # 設定頁腳
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # 存取與更新頁首
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # 儲存簡報
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **在講義與註解投影片上管理頁首與頁腳**
Aspose.Slides for PHP via Java 支援在講義與註解投影片上的頁首與頁腳。請依照以下步驟操作：

- 載入包含影片的[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)。
- 變更註解母片和所有註解投影片的頁首與頁腳設定。
- 設定母片註解投影片及所有子頁腳佔位符可見。
- 設定母片註解投影片及所有子日期與時間佔位符可見。
- 僅變更第一張註解投影片的頁首與頁腳設定。
- 設定註解投影片的頁首佔位符可見。
- 為註解投影片的頁首佔位符設定文字。
- 為註解投影片的日期時間佔位符設定文字。
- 寫入已修改的簡報檔案。

以下範例提供程式碼片段。

```php

  $pres = new Presentation("presentation.pptx");
  try {
    # 更改註解母片與所有註解投影片的頁首與頁腳設定
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// 使母片註解投影片與所有子頁腳佔位符可見

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// 使母片註解投影片與所有子頁首佔位符可見

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// 使母片註解投影片與所有子投影片編號佔位符可見

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// 使母片註解投影片與所有子日期時間佔位符可見

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// 設定文字至母片註解投影片與所有子頁首佔位符

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// 設定文字至母片註解投影片與所有子頁腳佔位符

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// 設定文字至母片註解投影片與所有子日期時間佔位符

    }
    # 更改僅第一張註解投影片的頁首與頁腳設定
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// 使此註解投影片的頁首佔位符可見

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// 使此註解投影片的頁腳佔位符可見

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// 使此註解投影片的投影片編號佔位符可見

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// 使此註解投影片的日期時間佔位符可見

      $headerFooterManager->setHeaderText("New header text");// 設定文字至註解投影片的頁首佔位符

      $headerFooterManager->setFooterText("New footer text");// 設定文字至註解投影片的頁腳佔位符

      $headerFooterManager->setDateTimeText("New date and time text");// 設定文字至註解投影片的日期時間佔位符

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以在一般投影片上加入「頁首」嗎？**

在 PowerPoint 中，「頁首」僅在註解與講義中存在；在一般投影片上支援的元素只有頁腳、日期/時間與投影片編號。Aspose.Slides 亦遵循相同限制：頁首僅適用於註解/講義，投影片上則為頁腳/日期時間/投影片編號。

**如果版面配置沒有頁腳區域，能「開啟」其可見性嗎？**

可以。透過頁首/頁腳管理器檢查可見性，必要時將其啟用。這些 API 指標與方法設計用於佔位符缺失或被隱藏的情況。

**如何讓投影片編號從非 1 的值開始？**

設定簡報的[first slide number](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/setfirstslidenumber/)；之後所有編號會重新計算。例如，可從 0 或 10 開始，並在標題投影片上隱藏編號。

**匯出為 PDF/圖片/HTML 時，頁首/頁腳會怎樣？**

它們會以簡報的普通文字元素呈現。換句話說，若這些元素在投影片/註解頁面上可見，匯出後的檔案也會一併顯示。