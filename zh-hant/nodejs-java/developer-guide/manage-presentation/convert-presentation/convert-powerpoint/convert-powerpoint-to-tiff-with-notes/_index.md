---
title: 在 JavaScript 中將 PowerPoint 簡報轉換為含備註的 TIFF
linktitle: PowerPoint 轉 TIFF 含備註
type: docs
weight: 100
url: /zh-hant/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 TIFF
- 簡報 轉 TIFF
- 投影片 轉 TIFF
- PPT 轉 TIFF
- PPTX 轉 TIFF
- 將 PPT 儲存為 TIFF
- 將 PPTX 儲存為 TIFF
- 匯出 PPT 為 TIFF
- 匯出 PPTX 為 TIFF
- 含備註的 PowerPoint
- 含備註的簡報
- 含備註的投影片
- 含備註的 PPT
- 含備註的 PPTX
- 含備註的 TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js，在 JavaScript 中將 PowerPoint 簡報轉換為含備註的 TIFF。了解如何有效匯出含講者備註的投影片。"
---
## **簡介**

Aspose.Slides for Node.js via Java 提供了一個簡單的解決方案，可將含備註的 PowerPoint 與 OpenDocument 投影片 (PPT、PPTX 與 ODP) 轉換為 TIFF 格式。此格式廣泛用於高品質圖像儲存、列印與文件封存。使用 Aspose.Slides，您不僅可以匯出含講者備註的完整投影片，還能在「備註投影片」檢視中產生縮圖。轉換過程簡便且高效，利用 `save` 方法的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別將整個投影片轉換為一系列 TIFF 圖片，且保留備註與版面配置。

## **將投影片轉換為含備註的 TIFF**

使用 Aspose.Slides for Node.js via Java 將 PowerPoint 或 OpenDocument 投影片儲存為含備註的 TIFF 需要以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例：載入 PowerPoint 或 OpenDocument 檔案。  
1. 設定輸出版面配置選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 類別指定備註和評論的顯示方式。  
1. 將投影片儲存為 TIFF：將設定好的選項傳遞給 [save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 方法。

假設我們有一個名為 **speaker_notes.pptx** 的檔案，其內容如下：

![含講者備註的投影片](slide_with_notes.png)

下面的程式碼片段示範如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 方法在「備註投影片」檢視中將投影片轉換為 TIFF 圖片。

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // 在投影片下方顯示備註。

    // 配置含備註版面的 TIFF 選項。
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 將簡報儲存為含講者備註的 TIFF。
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

結果：

![含講者備註的 TIFF 圖片](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
查看 Aspose 的 [免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

**我可以控制產生的 TIFF 中備註區域的位置嗎？**

可以。使用 [notes layout settings](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 可在 `None`、`BottomTruncated`、`BottomFull` 等選項中選擇，分別會隱藏備註、將備註縮至單頁，或讓備註延伸至額外頁面。

**如何在不明顯降低品質的情況下減小含備註的 TIFF 檔案大小？**

選擇有效的壓縮方式 (例如 `LZW` 或 `RLE`) 、設定合適的 DPI，且在可接受的情況下使用較低的 [pixel format](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/setpixelformat/)（如 8 bpp 或 1 bpp 單色）。稍微縮小 [image dimensions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/setimagesize/) 也能在不顯著影響可讀性的前提下減少檔案大小。

**如果系統缺少原始字型，備註中的字型會影響結果嗎？**

會。缺少的字型會觸發 [substitution](/slides/zh-hant/nodejs-java/font-selection-sequence/)，可能改變文字度量與外觀。為避免此問題，請 [提供所需字型](/slides/zh-hant/nodejs-java/custom-font/) 或設定預設的 [fallback font](/slides/zh-hant/nodejs-java/fallback-font/) 以使用預期的字型。