---
title: 將 PowerPoint 簡報轉換為帶備註的 TIFF（使用 C++）
linktitle: PowerPoint 轉 TIFF（含備註）
type: docs
weight: 100
url: /zh-hant/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 將 PowerPoint 簡報轉換為帶備註的 TIFF。了解如何高效匯出含講者備註的投影片。"
---
## **簡介**

Aspose.Slides for C++ 提供一個簡易的解決方案，將帶有備註的 PowerPoint 與 OpenDocument 簡報 (PPT、PPTX 與 ODP) 轉換為 TIFF 格式。此格式廣泛用於高品質影像儲存、列印與文件存檔。使用 Aspose.Slides，不僅可以匯出包含講者備註的整個簡報，還能在「備註投影片」檢視模式下產生投影片縮圖。轉換過程簡單且高效，透過 `Save` 方法搭配 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別，將整個簡報轉換為一系列 TIFF 圖片，同時保留備註與版面配置。

## **將簡報轉換為含備註的 TIFF**

使用 Aspose.Slides for C++ 將 PowerPoint 或 OpenDocument 簡報存成帶備註的 TIFF，需遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例：載入 PowerPoint 或 OpenDocument 檔案。  
1. 設定輸出版面選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/) 類別指定備註與評論的顯示方式。  
1. 將簡報儲存為 TIFF：將設定好的選項傳遞給 [Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 方法。

假設我們有一個名為 **speaker_notes.pptx** 的檔案，其內容如下投影片：

![簡報投影片（含講者備註）](slide_with_notes.png)

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 在投影片下方顯示備註。

// 設定備註排版的 TIFF 選項。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// 將簡報儲存為帶講者備註的 TIFF。
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

結果如下：

![帶有講者備註的 TIFF 圖片](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
查看 Aspose [免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

**我可以控制產生的 TIFF 中備註區域的位置嗎？**

是。使用 [notes layout settings](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) 可在 `None`、`BottomTruncated`、`BottomFull` 等選項之間選擇，分別代表隱藏備註、將備註縮減至單頁顯示，或允許備註延伸至多頁。

**如何在不明顯降低品質的前提下減少帶備註的 TIFF 檔案大小？**

選擇一種 [efficient compression](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)（例如 `LZW` 或 `RLE`），設定適當的 DPI，並在可接受的情況下使用較低的 [pixel format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)（如 8 位元或 1 位元單色）。稍微縮小 [image dimensions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_imagesize/) 也能在不顯著影響可讀性的前提下降低檔案大小。

**如果系統中缺少原始字型，備註中的字型會影響結果嗎？**

會。缺少的字型會觸發 [substitution](/slides/zh-hant/cpp/font-selection-sequence/)，可能改變文字度量與外觀。為避免此問題，請 [supply the required fonts](/slides/zh-hant/cpp/custom-font/) 或設定預設的 [fallback font](/slides/zh-hant/cpp/fallback-font/)，以確保使用預期的字型。