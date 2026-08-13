---
title: 在 Android 上將 PowerPoint 簡報轉換為含備註的 TIFF
linktitle: PowerPoint 轉 TIFF（含備註）
type: docs
weight: 100
url: /zh-hant/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，將 PowerPoint 簡報轉換為含備註的 TIFF。了解如何有效地匯出帶有講者備註的投影片。"
---
## **簡介**

Aspose.Slides for Android via Java 提供了一個簡單的解決方案，用於將含備註的 PowerPoint 和 OpenDocument 簡報 (PPT、PPTX 和 ODP) 轉換為 TIFF 格式。此格式廣泛用於高品質影像儲存、列印和文件存檔。使用 Aspose.Slides，您不僅可以匯出帶有講者備註的完整簡報，還可以在備註投影片檢視中產生投影片縮圖。轉換過程簡單且高效，利用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的 `save` 方法，將整個簡報轉換為一系列 TIFF 影像，同時保留備註和版面配置。

## **將簡報轉換為含備註的 TIFF**

使用 Aspose.Slides for Android via Java 將 PowerPoint 或 OpenDocument 簡報儲存為含備註的 TIFF，需遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別實例：載入 PowerPoint 或 OpenDocument 檔案。
1. 設定輸出版面配置選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 類別指定備註與評論的顯示方式。
1. 將簡報儲存為 TIFF：將已設定的選項傳遞給 [save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法。

假設我們有一個名為「speaker_notes.pptx」的檔案，其包含以下投影片：

![含備註的簡報投影片](slide_with_notes.png)

以下程式碼片段示範如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法，將簡報在備註投影片檢視下轉換為 TIFF 影像。

```java
import com.aspose.slides.*;

// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在投影片下方顯示備註。

    // 設定具有備註佈局的 TIFF 選項。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 將簡報儲存為含備註的 TIFF。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

結果：

![含備註的 TIFF 影像](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
查看 Aspose 免費 PowerPoint 轉海報轉換器[Free PowerPoint to Poster Converter](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

### 我可以控制結果 TIFF 中備註區域的位置嗎？

是的。使用 [notes layout settings](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 可在 `None`、`BottomTruncated` 或 `BottomFull` 等選項之間選擇，分別會隱藏備註、將備註縮減至單頁，或允許備註延伸至其他頁面。

### 如何在不明顯降低品質的情況下降低含備註的 TIFF 檔案大小？

選擇高效的壓縮方式，例如 `LZW` 或 `RLE`，設定適當的 DPI，若可以接受，使用較低的 [pixel format](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-)（如 8 bpp 或 1 bpp 單色）。略微縮小 [image dimensions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) 也能在不明顯影響可讀性的情況下減小檔案大小。

### 若系統缺少原始字體，備註中的字體會影響結果嗎？

是的。缺少字體會觸發 [字體替代](/slides/zh-hant/androidjava/font-selection-sequence/)，可能會改變文字的度量和外觀。為避免此情況，請 [提供所需字體](/slides/zh-hant/androidjava/custom-font/) 或設定預設的 [備援字體](/slides/zh-hant/androidjava/fallback-font/)，以使用預期的字型。