---
title: 從 PHP 提取簡報中的 Flash 物件
linktitle: Flash
type: docs
weight: 10
url: /zh-hant/php-java/flash/
keywords:
- 提取 Flash
- Flash 物件
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 從 PowerPoint 與 OpenDocument 投影片中提取 Flash 物件，並提供完整的程式範例與最佳實踐。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 從簡報中提取 Flash 物件。它展示如何在投影片的控制項集合中根據名稱找到 Flash 控制項，並處理嵌入的 SWF 物件資料。

## **從簡報中提取 Flash 物件**

Aspose.Slides for PHP via Java 提供從簡報中提取 Flash 物件的功能。您可以依名稱存取 Flash 控制項，並將其從簡報中提取，同時保存 SWF 物件資料。

```php
  # 實例化表示 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**在提取 Flash 內容時支援哪些簡報格式？**

[Aspose.Slides supports](/slides/zh-hant/php-java/supported-file-formats/) 主要的 PowerPoint 格式，如 PPT 和 PPTX，因為它可以載入這些容器並存取其控制項，包括與 Flash 相關的 ActiveX 元件。

**我可以將含有 Flash 的簡報轉換為 HTML5 並保留 Flash 互動性嗎？**

不行。Aspose.Slides 不會執行 SWF 內容或轉換其互動性。雖然支援匯出至 [HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/zh-hant/php-java/export-to-html5/)，但由於已停止支援，Flash 無法在現代瀏覽器中播放。建議的做法是在匯出前將 Flash 替換為影片或 HTML5 動畫等替代方案。

**從安全性角度來看，Aspose.Slides 在讀取簡報時會執行 SWF 檔案嗎？**

不會。Aspose.Slides 將 Flash 視為嵌入檔案中的二進位資料，處理過程中不會執行 SWF 內容。

**我應該如何處理同時包含 Flash 以及其他通過 OLE 嵌入的檔案的簡報？**

Aspose.Slides 支援[提取嵌入的 OLE 物件](/slides/zh-hant/php-java/manage-ole/)，因此您可以一次處理所有相關的嵌入內容，同時處理 Flash 控制項與其他 OLE 嵌入的文件。