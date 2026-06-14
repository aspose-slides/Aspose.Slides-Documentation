---
title: 將 PowerPoint 簡報轉換為帶備註的 TIFF（Java）
linktitle: PowerPoint 轉 TIFF 帶備註
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
- PowerPoint 帶備註
- 簡報帶備註
- 投影片帶備註
- PPT 帶備註
- PPTX 帶備註
- TIFF 帶備註
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 將 PowerPoint 簡報轉換為帶備註的 TIFF。了解如何有效地匯出帶有演講者備註的投影片。"
---
## **介紹**

Aspose.Slides for Java 提供了一個簡單的解決方案，將包含備註的 PowerPoint 和 OpenDocument 簡報（PPT、PPTX 和 ODP）轉換為 TIFF 格式。此格式廣泛用於高品質影像儲存、列印和文件歸檔。使用 Aspose.Slides，您不僅可以匯出帶有演講者備註的完整簡報，還可以在「備註投影片」檢視中產生投影片縮圖。轉換過程簡單且高效，利用[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)類別的 `save` 方法，將整個簡報轉換為一系列 TIFF 影像，同時保留備註和版面配置。

## **將簡報轉換為帶備註的 TIFF**

使用 Aspose.Slides for Java 將 PowerPoint 或 OpenDocument 簡報儲存為帶備註的 TIFF 需要以下步驟：

1. 實例化[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)類別：載入 PowerPoint 或 OpenDocument 檔案。
2. 設定輸出版面配置選項：使用[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notescommentslayoutingoptions/)類別指定備註和註解的顯示方式。
3. 將簡報儲存為 TIFF：將設定好的選項傳遞給[save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)方法。

假設我們有一個名為「speaker_notes.pptx」的檔案，其內容如下投影片：

![帶備註的簡報投影片](slide_with_notes.png)

以下程式碼片段示範如何使用[setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)方法，將簡報轉換為「備註投影片」檢視中的 TIFF 影像。

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在投影片下方顯示備註。

    // 使用備註版面配置設定 TIFF 選項。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 將簡報儲存為帶備註的 TIFF。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

結果：

![帶備註的 TIFF 影像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
查看 Aspose 的[免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問與答**

**我可以控制產生的 TIFF 中備註區域的位置嗎？**

可以。使用[備註版面設定](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)來選擇 `None`、`BottomTruncated` 或 `BottomFull` 等選項，分別可隱藏備註、將其壓縮至單一頁面，或允許備註延伸至其他頁面。

**如何在不明顯降低品質的情況下減小帶備註的 TIFF 檔案大小？**

選擇[有效的壓縮方式](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setCompressionType-int-)（例如 `LZW` 或 `RLE`），設定合理的 DPI，若可接受，使用較低的[像素格式](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-)（例如 8 位元或單色的 1 位元）。稍微縮小[影像尺寸](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)也能減少檔案大小，同時不會明顯影響可讀性。

**如果系統缺少原始字型，備註中的字型會影響結果嗎？**

會。缺少的字型會觸發[字型替代](/slides/zh-hant/java/font-selection-sequence/)，可能改變文字的度量和外觀。為避免此情況，請[提供所需字型](/slides/zh-hant/java/custom-font/)或設定預設的[備援字型](/slides/zh-hant/java/fallback-font/)，以確保使用預期的字型。