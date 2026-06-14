---
title: 在 PHP 中使用 Aspose.Slides 將 PowerPoint（PPT/PPTX）轉換為 SWF Flash
linktitle: PowerPoint 轉換為 SWF
type: docs
weight: 80
url: /zh-hant/php-java/convert-powerpoint-to-swf-flash/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉換為 SWF
- 簡報 轉換為 SWF
- 投影片 轉換為 SWF
- PPT 轉換為 SWF
- PPTX 轉換為 SWF
- PowerPoint 轉換為 Flash
- 簡報 轉換為 Flash
- 投影片 轉換為 Flash
- PPT 轉換為 Flash
- PPTX 轉換為 Flash
- 將 PPT 儲存為 SWF
- 將 PPTX 儲存為 SWF
- 匯出 PPT 為 SWF
- 匯出 PPTX 為 SWF
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 將 PowerPoint（PPT/PPTX）轉換為 SWF Flash。提供逐步程式碼範例，快速高品質輸出，無需 PowerPoint 自動化。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 SWF。它示範如何使用 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/save/) 方法將簡報儲存為 SWF 檔案，並說明如何使用 [SwfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/swfoptions/) 進行匯出設定，包括檢視器設定以及註解或備註的版面配置。

## **將簡報轉換為 Flash**

由 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/save/) 方法可用於將整個簡報轉換為 **SWF** 文件。以下範例示範如何使用 [SWFOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/swfoptions/) 類別提供的選項將簡報轉換為 **SWF** 文件。您也可以使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notescommentslayoutingoptions/) 類別將註解包含在產生的 SWF 中。

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # 儲存簡報
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以在 SWF 中包含隱藏投影片嗎？**

可以。請在 [SwfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/swfoptions/) 中使用 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/swfoptions/setshowhiddenslides/) 方法啟用隱藏投影片。預設情況下，隱藏投影片不會被匯出。

**我該如何控制壓縮與最終的 SWF 檔案大小？**

使用 [setCompressed](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/swfoptions/setcompressed/) 方法，並透過 [adjust JPEG quality](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/swfoptions/setjpegquality/) 調整 JPEG 品質，以在檔案大小與影像品質之間取得平衡。

**'setViewerIncluded' 的作用是什麼？何時應該停用它？**

[setViewerIncluded](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/swfoptions/setviewerincluded/) 會加入內嵌的播放器 UI（導覽控制、面板、搜尋）。如果您打算使用自訂播放器，或需要沒有 UI 的純粹 SWF 框架，請將其停用。

**如果匯出機器上缺少來源字型會發生什麼情況？**

Aspose.Slides 會使用您在 [SwfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/swfoptions/) 中透過 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) 指定的字型進行替代，以避免意外的字型回退。