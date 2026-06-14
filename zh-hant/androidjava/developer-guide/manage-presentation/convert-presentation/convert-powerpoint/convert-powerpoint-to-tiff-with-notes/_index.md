---
title: 將 PowerPoint 簡報轉換為含註解的 TIFF（Android）
linktitle: PowerPoint 轉 TIFF 含註解
type: docs
weight: 100
url: /zh-hant/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- 含註解的 PowerPoint
- 含註解的簡報
- 含註解的投影片
- 含註解的 PPT
- 含註解的 PPTX
- 含註解的 TIFF
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，將 PowerPoint 簡報轉換為含註解的 TIFF。了解如何有效匯出帶有講者註解的投影片。"
---
## **簡介**

Aspose.Slides for Android via Java 提供簡單的解決方案，可將含註解的 PowerPoint 與 OpenDocument 簡報 (PPT、PPTX 與 ODP) 轉換為 TIFF 格式。此格式廣泛用於高品質影像存儲、列印與文件存檔。使用 Aspose.Slides，您不僅能匯出整個包含講者註解的簡報，還能在「註解投影片」視圖中產生投影片縮圖。轉換過程簡單且高效，透過 `save` 方法與 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別，將整個簡報轉換為一系列 TIFF 圖像，同時保留註解與版面配置。

## **將簡報轉換為含註解的 TIFF**

將 PowerPoint 或 OpenDocument 簡報儲存為含註解的 TIFF，使用 Aspose.Slides for Android via Java，需以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例：載入 PowerPoint 或 OpenDocument 檔案。
1. 設定輸出版面配置選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 類別來指定註解與評論的顯示方式。
1. 將簡報儲存為 TIFF：將設定好的選項傳遞給 [save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法。

假設我們有一個 "speaker_notes.pptx" 檔案，其包含以下投影片：

![含講者註解的簡報投影片](slide_with_notes.png)

以下程式碼片段示範如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法，將簡報轉換為「註解投影片」視圖下的 TIFF 圖像。

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在投影片下方顯示註解。

    // 設定具備註解版面配置的 TIFF 選項。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 將簡報儲存為含講者註解的 TIFF。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

結果：

![含講者註解的 TIFF 圖像](TIFF_with_notes.png)

{{% alert title="提示" color="primary" %}}
看看 Aspose 的 [免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

**我可以控制最終 TIFF 中註解區域的位置嗎？**

是的。使用 [註解版面配置設定](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 可在 `None`、`BottomTruncated`、`BottomFull` 等選項之間選擇，分別會隱藏註解、將註解壓縮至單一頁面，或允許註解延伸至其他頁面。

**如何在不明顯降低品質的情況下減少含註解的 TIFF 檔案大小？**

選擇一種[高效壓縮](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-)（例如 `LZW` 或 `RGE`），設定合理的 DPI，並在可接受的情況下使用較低的[像素格式](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-)（如 8 位元或 1 位元單色）。稍微縮小[影像尺寸](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)也能減少檔案大小，同時不會明顯影響可讀性。

**如果系統缺少原始字型，註解中的字型會影響結果嗎？**

是的。缺少字型會觸發[字型替代](/slides/zh-hant/androidjava/font-selection-sequence/)，可能改變文字度量與外觀。為避免此情況，請[提供所需字型](/slides/zh-hant/androidjava/custom-font/)或設定預設的[後備字型](/slides/zh-hant/androidjava/fallback-font/)，以使用預期的字體。