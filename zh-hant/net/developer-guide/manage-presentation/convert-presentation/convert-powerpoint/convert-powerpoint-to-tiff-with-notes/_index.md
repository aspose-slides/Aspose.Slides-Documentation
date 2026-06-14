---
title: 將 PowerPoint 簡報轉換為含備註的 TIFF（.NET）
linktitle: PowerPoint 轉 TIFF 含備註
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
- 含備註的 PowerPoint
- 含備註的簡報
- 含備註的投影片
- 含備註的 PPT
- 含備註的 PPTX
- 含備註的 TIFF
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 PowerPoint 簡報轉換為含備註的 TIFF。了解如何有效地匯出帶有講者備註的投影片。"
---
## **簡介**

Aspose.Slides for .NET 提供一個簡單的解決方案，可將含備註的 PowerPoint 和 OpenDocument 簡報 (PPT、PPTX 與 ODP) 轉換為 TIFF 格式。此格式廣泛用於高品質影像儲存、印刷與文件歸檔。使用 Aspose.Slides，您不僅可以匯出包含講者備註的完整簡報，還能在備註投影片視圖中產生投影片縮圖。轉換過程簡單且高效，利用 `Save` 方法搭配 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別，將整個簡報轉換為一系列 TIFF 圖片，同時保留備註與版面配置。

## **將簡報轉換為含備註的 TIFF**

使用 Aspose.Slides for .NET 將 PowerPoint 或 OpenDocument 簡報儲存為含備註的 TIFF，步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 物件：載入 PowerPoint 或 OpenDocument 檔案。
1. 設定輸出版面配置選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notescommentslayoutingoptions/) 類別指定備註與評論的顯示方式。
1. 將簡報儲存為 TIFF：將已設定的選項傳遞給 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/methods/save/index) 方法。

假設我們有一個名為 "speaker_notes.pptx" 的檔案，內含以下投影片：

![The presentation slide with speaker notes](slide_with_notes.png)

下方程式碼片段示範如何使用 [SlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) 屬性，將簡報在備註投影片視圖下轉換為 TIFF 圖片。

```c#
 // 建立代表簡報檔案的 Presentation 類別實例。
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // 設定帶備註版面的 TIFF 選項。
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // 在投影片下方顯示備註。
        }
    };

    // 將簡報儲存為包含講者備註的 TIFF。
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

結果如下：

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

請參考 Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **常見問題**

**我可以控制產生的 TIFF 中備註區域的位置嗎？**

可以。使用 [notes layout settings](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) 來選擇 `None`、`BottomTruncated` 或 `BottomFull` 等選項，分別會隱藏備註、將備註壓縮至單一頁面，或讓備註延伸至其他頁面。

**如何在不明顯降低品質的情況下縮小含備註的 TIFF 檔案大小？**

選擇有效的壓縮方式，例如 `LZW` 或 `RLE`，設定適當的 DPI，必要時使用較低的 [pixel format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/pixelformat/)（如 8 bpp 或 1 bpp 單色）。適度減少 [image dimensions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/imagesize/) 也可在不明顯影響可讀性的前提下減少檔案大小。

**如果系統缺少原始字型，備註中的字型會影響最終結果嗎？**

會。缺少的字型會觸發 [substitution](/slides/zh-hant/net/font-selection-sequence/)，可能會改變文字度量與外觀。為避免此情況，請 [supply the required fonts](/slides/zh-hant/net/custom-font/) 或設定預設的 [fallback font](/slides/zh-hant/net/fallback-font/)，以使用預期的字體。