---
title: 在 PHP 中建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/php-java/create-presentation/
keywords:
- 建立簡報
- 新簡報
- 建立 PPT
- 新 PPT
- 建立 PPTX
- 新 PPTX
- 建立 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（透過 Java）建立簡報 — 產生 PPT、PPTX 與 ODP 檔案，並以程式方式儲存以確保可靠的結果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中建立簡報、向投影片加入簡單內容，並將結果儲存為檔案。它還示範如何建立並儲存新簡報、以支援的格式開啟現有簡報，並將其儲存為其他格式。另外，本文還包含一段簡短的常見問題，涵蓋與格式、範本、投影片大小、單位、記憶體使用、執行緒、授權、數位簽章以及 VBA 支援相關的常見問題。

## **建立簡報**

要在簡報的選定投影片上加入一條簡單的直線，請依照以下步驟操作：

1. 建立 Presentation 類別的實例。
1. 使用 Index 取得投影片的參考。
1. 使用 Shapes 物件提供的 addAutoShape 方法，加入類型為 Line 的 AutoShape。
1. 將修改後的簡報寫入為 PPTX 檔案。

在下方的範例中，我們已在簡報的第一張投影片加入了一條線。

```php
  # 實例化一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 加入類型為線條的 AutoShape
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以將新簡報儲存為哪些格式？**

您可以儲存為 [PPTX、PPT 和 ODP](/slides/zh-hant/php-java/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/php-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 以及 [影像](/slides/zh-hant/php-java/convert-powerpoint-to-png/)，等等。

**我能從範本 (POTX/POTM) 開始，並儲存為一般的 PPTX 嗎？**

可以。載入範本後儲存為目標格式；POTX/POTM/PPTM 及其他類似格式 [受到支援](/slides/zh-hant/php-java/supported-file-formats/)。

**建立簡報時，我該如何控制投影片大小/長寬比？**

設定 [投影片大小](/slides/zh-hant/php-java/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

**尺寸與座標使用什麼單位測量？**

以點 (point) 為單位：1 英吋等於 72 單位。

**如何處理包含大量媒體檔案的超大型簡報，以減少記憶體使用？**

使用 [BLOB 管理策略](/slides/zh-hant/php-java/manage-blob/)，藉由暫存檔案限制記憶體內的儲存，並優先使用檔案為基礎的工作流程，而非純粹的記憶體串流。

**我可以平行建立/儲存簡報嗎？**

您無法在 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例上同時由 [多個執行緒](/slides/zh-hant/php-java/multithreading/) 操作。請為每個執行緒或行程執行獨立的實例。

**我該如何移除試用版浮水印與限制？**

[套用授權](/slides/zh-hant/php-java/licensing/) 每個行程一次。授權 XML 必須保持未修改，若有多個執行緒，授權設定亦須同步執行。

**我可以為我建立的 PPTX 加上數位簽章嗎？**

可以。[數位簽章](/slides/zh-hant/php-java/digital-signature-in-powerpoint/)（加入與驗證）在簡報中受到支援。

**在建立的簡報中是否支援巨集 (VBA)？**

可以。您可 [建立/編輯 VBA 專案](/slides/zh-hant/php-java/presentation-via-vba/)，並儲存如 PPTM/PPSM 等支援巨集的檔案。