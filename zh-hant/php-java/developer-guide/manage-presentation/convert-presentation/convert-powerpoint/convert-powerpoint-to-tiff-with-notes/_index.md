---
title: 在 PHP 中將 PowerPoint 簡報轉換為含備註的 TIFF
linktitle: PowerPoint 轉 TIFF（含備註）
type: docs
weight: 100
url: /zh-hant/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 TIFF
- 簡報轉 TIFF
- 投影片轉 TIFF
- PPT 轉 TIFF
- PPTX 轉 TIFF
- 將 PPT 儲存為 TIFF
- 将 PPTX 儲存為 TIFF
- 匯出 PPT 為 TIFF
- 匯出 PPTX 為 TIFF
- 帶備註的 PowerPoint
- 帶備註的簡報
- 帶備註的投影片
- 帶備註的 PPT
- 帶備註的 PPTX
- 帶備註的 TIFF
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 將 PowerPoint 簡報轉換為帶備註的 TIFF。了解如何有效地匯出含講者備註的投影片。"
---
## **介紹**

Aspose.Slides for PHP via Java 提供了一個簡單的解決方案，可將 PowerPoint 與 OpenDocument 簡報（PPT、PPTX 與 ODP）連同備註轉換為 TIFF 格式。此格式廣泛用於高品質影像儲存、列印與文件歸檔。使用 Aspose.Slides，您不僅可以匯出包含講者備註的整個簡報，還能在「備註投影片」視圖中產生投影片縮圖。轉換過程簡單且高效，透過 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的 `save` 方法，將整個簡報轉換為一系列 TIFF 影像，同時保留備註與版面配置。

## **將簡報轉換為包含備註的 TIFF**

使用 Aspose.Slides for PHP via Java 將 PowerPoint 或 OpenDocument 簡報儲存為包含備註的 TIFF，步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 物件：載入 PowerPoint 或 OpenDocument 檔案。  
1. 設定輸出版面選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notescommentslayoutingoptions/) 類別指定備註與評論的顯示方式。  
1. 儲存簡報為 TIFF：將設定好的選項傳遞給 [save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 方法。

假設我們有一個名為 **speaker_notes.pptx** 的檔案，內容如下投影片：

![簡報投影片與講者備註](slide_with_notes.png)

以下程式碼示範如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 方法，將簡報轉換為「備註投影片」視圖下的 TIFF 影像。

```php
// 建立代表簡報檔案的 Presentation 類別實例。
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // 在投影片下方顯示備註。

    // 使用備註版面配置設定 TIFF 選項。
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // 將簡報儲存為含講者備註的 TIFF。
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

結果如下：

![包含講者備註的 TIFF 影像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
了解更多 Aspose [免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問答**

**我可以控制產生的 TIFF 中備註區域的位置嗎？**

可以。使用 [notes layout settings](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 可在 `None`、`BottomTruncated` 或 `BottomFull` 等選項之間選擇，分別代表隱藏備註、將其壓縮至單一頁面，或允許備註延伸至多頁。

**如何在不明顯降低品質的情況下降低帶備註的 TIFF 檔案大小？**

選擇高效的壓縮方式，例如 `LZW` 或 `RLE`，設定適當的 DPI，若可接受，使用較低的 [pixel format](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/setpixelformat/)（如 8 bpp 或 1 bpp 單色）。稍微縮小 [image dimensions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/setimagesize/) 也能在不明顯影響可讀性的前提下降低檔案大小。

**如果系統缺少原始字型，備註中的字型會影響結果嗎？**

會。缺少的字型會觸發 [substitution](/slides/zh-hant/php-java/font-selection-sequence/)，可能改變文字度量與外觀。為避免此情況，請 [supply the required fonts](/slides/zh-hant/php-java/custom-font/) 或設定預設的 [fallback font](/slides/zh-hant/php-java/fallback-font/)，確保使用預期的字型。