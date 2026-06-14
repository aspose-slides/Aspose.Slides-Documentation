---
title: 在 PHP 中管理簡報可存取性
linktitle: 簡報可存取性
type: docs
weight: 30
url: /zh-hant/php-java/presentation-accessibility/
keywords:
- 簡報可存取性
- 標記為裝飾性
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides 如何自動化 PPT、PPTX 與 ODP 檔案的簡報可存取性檢查──提升螢幕閱讀器體驗並加強合規性。"
---
## **概述**

簡報的可存取性確保使用輔助技術的使用者──例如螢幕閱讀器、點字顯示器或僅鍵盤操作──能夠與有視力、使用滑鼠的觀眾同樣有效地理解與瀏覽投影片。良好的做法著重於清晰的閱讀順序、對資訊性視覺元素提供有意義的替代文字、足夠的顏色對比度、易讀的排版、具描述性的連結文字，以及避免僅以顏色或位置傳達意義。從一開始就規劃可存取性，可得到更簡潔的結構、更一致的視覺呈現，並使內容能無需變通就觸及每位觀眾。

## **標記為裝飾性**

「標記為裝飾性」用於純粹裝飾性的視覺元素，讓螢幕閱讀器跳過它們，減少噪音並將焦點保持在有意義的內容上。將此標記套用於背景、裝飾圖案和間距元件──絕不可用於傳遞資訊的圖表、圖示或影像。Aspose.Slides 針對此旗標提供偵測與驗證功能，支援自動化的可存取性檢查與清理。

![標記為裝飾性](mark_as_decorative.png)

以下程式碼範例說明如何判斷形狀是否已標記為裝飾性。

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```