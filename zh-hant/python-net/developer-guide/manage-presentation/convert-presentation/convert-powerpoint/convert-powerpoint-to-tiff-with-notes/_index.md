---
title: 在 Python 中將 PowerPoint 簡報轉換為含備註的 TIFF
linktitle: PowerPoint 轉 TIFF（含備註）
type: docs
weight: 100
url: /zh-hant/python-net/convert-powerpoint-to-tiff-with-notes/
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
- 含備註的 PowerPoint
- 含備註的簡報
- 含備註的投影片
- 含備註的 PPT
- 含備註的 PPTX
- 含備註的 TIFF
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 將 PowerPoint 簡報轉換為含備註的 TIFF。了解如何有效地匯出帶有講者備註的投影片。"
---
## **Introduction**

Aspose.Slides for Python via .NET 提供了一個簡單的解決方案，可將含備註的 PowerPoint 與 OpenDocument 簡報（PPT、PPTX 以及 ODP）轉換為 TIFF 格式。此格式廣泛用於高品質影像儲存、列印與文件歸檔。使用 Aspose.Slides，您不僅可以匯出包含講者備註的整個簡報，還能在「備註投影片」檢視中產生投影片縮圖。轉換過程簡單且高效，利用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的 `save` 方法，將整個簡報轉換為一系列 TIFF 圖像，同時保留備註與版面配置。

## **將簡報轉換為含備註的 TIFF**

使用 Aspose.Slides for Python via .NET 將 PowerPoint 或 OpenDocument 簡報儲存為含備註的 TIFF 需要以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別：載入 PowerPoint 或 OpenDocument 檔案。  
1. 設定輸出版面配置選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/) 類別指定備註與註解的顯示方式。  
1. 將簡報儲存為 TIFF：將已配置的選項傳遞給 [save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) 方法。

假設我們有一個名為「speaker_notes.pptx」的檔案，內含以下投影片：

![包含講者備註的簡報投影片](slide_with_notes.png)

以下程式碼片段示範如何使用 [slides_layout_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) 屬性，在「備註投影片」檢視中將簡報轉換為 TIFF 影像。

```py
# 實例化表示簡報檔案的 Presentation 類別。
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # 在投影片下方顯示備註。
    
    # 設定帶備註版面的 TIFF 選項。
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # 將簡報與講者備註儲存為 TIFF。
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

結果：

![包含講者備註的 TIFF 影像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
查看 Aspose [免費的 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **FAQ**

**我可以控制產生的 TIFF 中備註區域的位置嗎？**

可以。使用 [notes layout settings](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) 於選項 `NONE`、`BOTTOM_TRUNCATED` 或 `BOTTOM_FULL` 中選擇，分別會隱藏備註、將備註縮減至單頁，或允許備註延伸至更多頁面。

**如何在不明顯降低品質的情況下降低含備註的 TIFF 檔案大小？**

選擇 [efficient compression](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/compression_type/)（例如 `LZW` 或 `RLE`），設定合理的 DPI，若可接受，使用較低的 [pixel format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/pixel_format/)（如 8 bpp 或 1 bpp 的單色），稍微縮小 [image dimensions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/image_size/) 也能減少檔案大小，且不會明顯影響可讀性。

**如果系統缺少原始字型，備註中的字型會影響結果嗎？**

會。缺少的字型會觸發 [substitution](/slides/zh-hant/python-net/font-selection-sequence/)，可能會改變文字度量與外觀。為避免此問題，請 [supply the required fonts](/slides/zh-hant/python-net/custom-font/) 或設定預設的 [fallback font](/slides/zh-hant/python-net/fallback-font/)，以使用預期的字型。