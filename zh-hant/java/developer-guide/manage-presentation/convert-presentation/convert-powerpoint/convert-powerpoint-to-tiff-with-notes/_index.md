---
title: 在 Java 中將 PowerPoint 簡報轉換為含備註的 TIFF
linktitle: PowerPoint 轉 TIFF（含備註）
type: docs
weight: 100
url: /zh-hant/java/convert-powerpoint-to-tiff-with-notes/
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
- 將 PPTX 儲存為 TIFF
- 匯出 PPT 為 TIFF
- 匯出 PPTX 為 TIFF
- 帶備註的 PowerPoint
- 帶備註的簡報
- 帶備註的投影片
- 帶備註的 PPT
- 帶備註的 PPTX
- 帶備註的 TIFF
- Java
- Aspose.Slides
description: 使用 Aspose.Slides for Java 將 PowerPoint 簡報轉換為含備註的 TIFF。了解如何高效匯出帶有講者備註的投影片。
---
## **簡介**

Aspose.Slides for Java 提供一個簡單的解決方案，可將含備註的 PowerPoint 與 OpenDocument 簡報 (PPT、PPTX 與 ODP) 轉換為 TIFF 格式。此格式廣泛用於高品質影像儲存、列印與文件歸檔。使用 Aspose.Slides，您不僅可以匯出整個含講者備註的簡報，還可以在「備註投影片」檢視中產生投影片縮圖。轉換過程簡單且高效，利用 `save` 方法的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別，將整個簡報轉換為一系列 TIFF 圖片，同時保留備註與版面配置。

## **將簡報轉換為含備註的 TIFF**

使用 Aspose.Slides for Java 將 PowerPoint 或 OpenDocument 簡報儲存為含備註的 TIFF，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 物件：載入 PowerPoint 或 OpenDocument 檔案。  
2. 設定輸出版面配置選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notescommentslayoutingoptions/) 類別指定備註與評論的顯示方式。  
3. 將簡報儲存為 TIFF：將設定好的選項傳遞給 [save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法。

假設我們有一個名為 **speaker_notes.pptx** 的檔案，其內容如下投影片：

![帶有講者備註的簡報投影片](slide_with_notes.png)

以下程式碼片段示範如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法，將簡報在「備註投影片」檢視中轉換為 TIFF 影像。

```java
import com.aspose.slides.*;

// 建立表示簡報檔案的 Presentation 類別實例。
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在投影片下方顯示備註。

    // 使用備註版面配置設定 TIFF 選項。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 將簡報儲存為含講者備註的 TIFF。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

產生結果：

![帶有講者備註的 TIFF 圖片](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
查看 Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **FAQ**

### 是否能控制產生的 TIFF 中備註區域的位置？

是的。使用 [notes layout settings](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 可在 `None`（不顯示備註）、`BottomTruncated`（將備註壓縮至單頁）或 `BottomFull`（讓備註延伸至多頁）之間選擇。

### 如何在不明顯影響品質的前提下減小含備註的 TIFF 檔案大小？

選擇適當的 [efficient compression](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setCompressionType-int-)（例如 `LZW` 或 `RLE`），設定合理的 DPI，並在可接受的情況下使用較低的 [pixel format](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-)（如 8 bpp 或 1 bpp 單色）。適度縮小 [image dimensions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) 亦可減少檔案大小，且不會明顯影響可讀性。

### 若系統缺少原始字型，備註中的字型會影響最終結果嗎？

會。缺少的字型會觸發 [substitution](/slides/zh-hant/java/font-selection-sequence/)，可能改變文字度量與外觀。為避免此問題，請 [supply the required fonts](/slides/zh-hant/java/custom-font/) 或設定預設的 [fallback font](/slides/zh-hant/java/fallback-font/)，確保使用預期的字體。