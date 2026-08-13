---
title: 在 C++ 中將 PowerPoint 簡報轉換為含備註的 TIFF
linktitle: PowerPoint 轉 TIFF 含備註
type: docs
weight: 100
url: /zh-hant/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 將 PowerPoint 簡報轉換為含備註的 TIFF。了解如何有效地匯出帶有講者備註的投影片。"
---
## **簡介**

Aspose.Slides for C++ 提供簡單的解決方案，將帶有備註的 PowerPoint 與 OpenDocument 簡報（PPT、PPTX 與 ODP）轉換為 TIFF 格式。此格式廣泛用於高品質影像儲存、列印與文件存檔。使用 Aspose.Slides，不僅可以匯出包含講者備註的整份簡報，還能在「備註投影片」檢視模式下產生投影片縮圖。轉換過程簡潔高效，利用 `Save` 方法搭配 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別，將整個簡報轉換為一系列 TIFF 圖片，同時保留備註與版面配置。

## **將簡報轉換為包含備註的 TIFF**

使用 Aspose.Slides for C++ 將 PowerPoint 或 OpenDocument 簡報儲存為帶備註的 TIFF，需遵循以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別：載入 PowerPoint 或 OpenDocument 檔案。
1. 設定輸出版面配置選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/) 類別指定備註與評論的顯示方式。
1. 將簡報儲存為 TIFF：將已設定的選項傳遞給 [Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 方法。

假設我們有一個名為「speaker_notes.pptx」的檔案，內容如下投影片：

![帶有講者備註的簡報投影片](slide_with_notes.png)

以下程式碼片段示範如何使用 [set_SlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) 方法，將簡報在「備註投影片」檢視模式下轉換為 TIFF 影像。

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 在投影片下方顯示備註。

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

結果：

![帶有講者備註的 TIFF 影像](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
請參閱 Aspose [免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

### 我可以控制產生的 TIFF 中備註區域的位置嗎？

可以。使用 [notes layout settings](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) 來選擇 `None`、`BottomTruncated` 或 `BottomFull` 等選項，分別可隱藏備註、將備註縮至單一頁面，或讓備註延伸至額外頁面。

### 如何在不明顯影響品質的情況下減少帶備註的 TIFF 檔案大小？

選擇 [efficient compression](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)（例如 `LZW` 或 `RLE`），設定合理的 DPI，且若可接受，可使用較低的 [pixel format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)（如 8 bpp 或 1 bpp 的單色）。稍微縮小 [image dimensions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_imagesize/) 也能降低檔案大小，同時不會明顯影響可讀性。

### 若系統缺少原始字型，備註中的字型會影響最終結果嗎？

會。缺少的字型會觸發 [substitution](/slides/zh-hant/cpp/font-selection-sequence/)，可能改變文字度量與外觀。為避免此情況，請 [supply the required fonts](/slides/zh-hant/cpp/custom-font/) 或設定預設的 [fallback font](/slides/zh-hant/cpp/fallback-font/)，以使用預期的字型。