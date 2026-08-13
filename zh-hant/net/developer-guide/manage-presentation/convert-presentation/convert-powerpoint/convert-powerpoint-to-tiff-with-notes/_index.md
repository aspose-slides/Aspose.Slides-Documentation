---
title: 在 .NET 中將 PowerPoint 簡報轉換為含註解的 TIFF
linktitle: PowerPoint 轉 TIFF 含註解
type: docs
weight: 100
url: /zh-hant/net/convert-powerpoint-to-tiff-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 PowerPoint 簡報轉換為含註解的 TIFF。了解如何有效地匯出帶有演講者註解的投影片。"
---
## **簡介**

Aspose.Slides for .NET 提供了一個簡單的解決方案，可將包含註解的 PowerPoint 和 OpenDocument 簡報 (PPT、PPTX 和 ODP) 轉換為 TIFF 格式。此格式廣泛用於高品質圖像存儲、列印與文件存檔。使用 Aspose.Slides，您不僅可以匯出整個帶有演講者註解的簡報，還能在「註解投影片」視圖中產生投影片縮圖。轉換過程簡單且高效，利用 `Save` 方法的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別，將整個簡報轉換為一系列 TIFF 圖像，同時保留註解與版面配置。

## **將簡報轉換為包含註解的 TIFF**

使用 Aspose.Slides for .NET 將 PowerPoint 或 OpenDocument 簡報儲存為帶註解的 TIFF 需要以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別：載入 PowerPoint 或 OpenDocument 檔案。  
2. 設定輸出版面配置選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notescommentslayoutingoptions/) 類別來指定註解與評論的顯示方式。  
3. 將簡報儲存為 TIFF：將設定好的選項傳遞給 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/methods/save/index) 方法。

假設我們有一個名為 "speaker_notes.pptx" 的檔案，其內容如下投影片：

![包含演講者註解的簡報投影片](slide_with_notes.png)

以下程式碼片段示範如何使用 [SlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) 屬性，將簡報轉換為「註解投影片」視圖下的 TIFF 影像。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // 設定帶有註解版面的 TIFF 選項。
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // 在投影片下方顯示註解。
        }
    };

    // 將簡報儲存為含演講者註解的 TIFF。
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

結果：

![包含演講者註解的 TIFF 影像](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
了解 Aspose [免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

### 我可以控制產生的 TIFF 中註解區域的位置嗎？

可以。使用 [notes layout settings](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) 來選擇 `None`、`BottomTruncated` 或 `BottomFull` 等選項，分別表示隱藏註解、將註解壓縮至單一頁面，或允許註解延伸至其他頁面。

### 如何在不明顯降低品質的情況下減少含註解的 TIFF 檔案大小？

選擇 [efficient compression](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/compressiontype/)（例如 `LZW` 或 `RLE`），設定合理的 DPI，若可接受，使用較低的 [pixel format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/pixelformat/)（如 8 位元或單色 1 位元）。略微縮小 [image dimensions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/imagesize/) 也能減少檔案大小，而不會明顯影響可讀性。

### 如果系統缺少原始字型，註解中的字型會影響結果嗎？

會。缺少字型會觸發 [substitution](/slides/zh-hant/net/font-selection-sequence/)，可能導致文字度量與外觀變化。為避免此情況，請 [supply the required fonts](/slides/zh-hant/net/custom-font/) 或設定預設的 [fallback font](/slides/zh-hant/net/fallback-font/)，以使用預期的字型。