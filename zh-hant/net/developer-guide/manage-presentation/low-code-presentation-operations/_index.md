---
title: 在 .NET 中的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/net/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 遍歷投影片
- 遍歷形狀
- 遍歷文字
- 收集形狀
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面配置投影片
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集形狀，並減少簡報大小。"
---
## **概述**

[Aspose.Slides.LowCode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/) 命名空間提供用於常見簡報操作的靜態輔助類別。這些輔助類別將常用的物件模型工作流程封裝在專注的方法中，讓您可以以更少的程式碼完成檔案轉換或合併、處理簡報元素、收集形狀以及移除未使用的內容。

當操作適用於整個檔案或簡報且預設工作流程符合需求時，低程式碼輔助工具最為實用。若需要對個別投影片、母片、版面配置、形狀、匯出設定或簡報元素之間的關係進行精細控制，請使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/)。

下表彙總了可用的輔助工具：

| 輔助工具 | 使用情境 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/convert/) | 以直接的檔案對檔案呼叫將簡報轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/) | 為每張投影片、形狀、段落或文字部分執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/collect/) | 從整份簡報中取得形狀，以供重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/) | 移除未使用的母片與版面配置，並減少嵌入字型資料。 |

## **轉換簡報**

當輸出檔案副檔名足以決定匯出格式時，使用 [Convert.AutoByExtension](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/convert/autobyextension/)。此方法會開啟來源簡報，從輸出路徑判斷所需格式，並寫入結果。

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/convert/) 類別也提供針對 PDF、SVG、JPEG、PNG 與 TIFF 的專屬輸出方法。若需要在匯出前檢查或修改簡報，或設定未由所選輔助工具公開的匯出選項，請使用完整的物件模型。請參考 [Convert Presentation](/net/convert-presentation/) 了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger.Process](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/merger/process/) 可一次呼叫合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

當所有投影片都應直接附加至最終結果且不需個別選取或重新映射時，這個輔助工具相當合適。若需要合併指定的投影片、套用目標母片或版面配置、明確保留節段，或調整不同投影片尺寸，請使用完整的物件模型。相關情境請參考 [Merge Presentations](/net/merge-presentation/)。

## **遍歷簡報元素**

[ForEach](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/) 類別會為每個請求類型的簡報元素呼叫回呼函式。它可避免巢狀集合迴圈，且適用於全簡報的檢查或格式變更。

以下範例使用 [ForEach.Slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/slide/)、[ForEach.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/shape/)、[ForEach.Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/paragraph/)、[ForEach.Portion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/portion/) 來檢查對應的元素：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

預設情況下，遍歷全簡報的形狀與文字會包含一般投影片、母片與版面配置投影片。帶有 `includeNotes` 參數的重載亦可處理備註投影片。若遍歷順序、提前退出、在回呼前過濾，或需要詳細的父子關係控制很重要，請改用直接的集合迴圈。

## **收集形狀**

當您需要取得簡報中所有形狀的集合，而非對每個形狀立即執行回呼時，使用 [Collect.Shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/collect/shapes/)。此方式適用於同一組形狀將被多次過濾、計數或處理的情況。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

若每個形狀都能立即處理且不需要保留收集結果，請改用 [ForEach.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/shape/)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/) 類別可以移除未使用的結構元素並減少嵌入字型資料：

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 移除所有未被一般投影片參照的版面配置投影片。
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 移除不再使用的母片投影片。
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/compressembeddedfonts/) 移除嵌入字型中未使用的字元。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

先移除未使用的版面配置，然後再移除未使用的母片，因為在版面配置清理後成為未被參照的母片也可以被移除。若日後可能需要原始的母片、版面配置或完整的嵌入字型資料，請將優化後的簡報儲存為新檔案。欲取得更多細節，請參閱 [Slide Master](/net/slide-master/) 與 [Embedded Font](/net/embedded-font/)。

## **常見問題**

**何時該使用低程式碼 API 而非完整物件模型？**

當標準操作適用於整個檔案或簡報且不需要對個別元素進行詳細控制時，使用低程式碼輔助工具。若需要選取特定投影片、控制母片與版面配置的關係、檢查中間狀態，或設定輔助工具未公開的行為，請使用完整的物件模型。

**Merger 能否合併不同檔案格式的簡報？**

不能。[Merger.Process](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/merger/process/) 必須使用相同格式的輸入簡報。請先使用例如 [Convert.AutoByExtension](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/convert/autobyextension/) 將輸入檔案轉換為相同格式，再進行合併。

**ForEach 會處理母片、版面配置與備註投影片嗎？**

[ForEach.Slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/slide/) 只遍歷一般的簡報投影片。全簡報的 [ForEach.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/shape/)、[ForEach.Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/paragraph/)、[ForEach.Portion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/portion/) 操作預設會包含一般、母片與版面配置投影片。使用帶有 `includeNotes` 且設定為 `true` 的重載即可同時包含備註投影片。

**ForEach.Shape 與 Collect.Shapes 有何不同？**

使用 [ForEach.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/shape/) 可在回呼中立即處理每個形狀。使用 [Collect.Shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/collect/shapes/) 時，會取得可保留、過濾、計數或多次遍歷的可列舉結果。

**Compress 總是會讓簡報檔案變小嗎？**

未必。結果取決於簡報是否包含未使用的版面配置、未使用的母片，或嵌入字型中有未使用的字元。若這些項目皆不存在，相應的 [Compress](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/) 操作可能不會減少檔案大小。

**ForEach 或 Compress 的變更會自動保存嗎？**

不會。這些輔助工具在記憶體中的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 物件上運作。於 [ForEach](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/foreach/) 回呼或執行 [Compress](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/) 後，請呼叫 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 以寫入結果。

## **相關文章**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)