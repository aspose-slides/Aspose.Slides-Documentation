---
title: 在 Python 中的進階簡報文字擷取
linktitle: 擷取文字
type: docs
weight: 90
url: /zh-hant/python-net/extract-text-from-presentation/
keywords:
- 擷取文字
- 從投影片擷取文字
- 從簡報擷取文字
- 從 PowerPoint 擷取文字
- 從 OpenDocument 擷取文字
- 從 PPT 擷取文字
- 從 PPTX 擷取文字
- 從 ODP 擷取文字
- 取得文字
- 從投影片取得文字
- 從簡報取得文字
- 從 PowerPoint 取得文字
- 從 OpenDocument 取得文字
- 從 PPT 取得文字
- 從 PPTX 取得文字
- 從 ODP 取得文字
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，快速從 PowerPoint 與 OpenDocument 簡報中擷取文字。遵循我們簡單、一步步的指南，節省時間。"
---
## **概述**

從簡報中擷取文字是開發人員處理投影片內容時常見且重要的工作。無論是 Microsoft PowerPoint 的 PPT 或 PPTX 檔案，亦或是 OpenDocument 簡報 (ODP)，取得文字資料都可能對分析、 automatisation、索引或內容遷移等情境關鍵。

本文提供完整指南，說明如何使用 Aspose.Slides for Python via .NET，高效從 PPT、PPTX 與 ODP 等多種簡報格式中擷取文字，並示範如何系統性遍歷簡報元素，以正確取得所需的文字內容。

## **從投影片擷取文字**

Aspose.Slides for Python via .NET 提供了 [aspose.slides.util](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/) 命名空間，其中包含 [SlideUtil](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/) 類別。此類別公開多個重載的靜態方法，可用於擷取整個簡報或單一投影片的所有文字。若要從簡報中的投影片擷取文字，請使用 [get_all_text_boxes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) 方法。此方法接受一個 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/) 物件作為參數。執行時，該方法會掃描整張投影片的文字，並回傳一個包含 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 物件的陣列，保留任何文字格式。

以下程式碼片段會擷取簡報第一張投影片的全部文字：

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **從整份簡報擷取文字**

若要掃描整份簡報的文字，請使用由 [SlideUtil](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/) 類別公開的 [get_all_text_frames](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/get_all_text_frames/) 靜態方法。它接受兩個參數：

1. 第一個參數為 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件，代表要從中擷取文字的 PowerPoint 或 OpenDocument 簡報。
1. 第二個參數為 `Boolean` 值，指示掃描簡報文字時是否包含母版投影片。

該方法會回傳包含 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 物件的陣列，並保留文字的格式資訊。以下程式碼會掃描簡報及其母版投影片的文字與格式細節。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **分類與快速的文字擷取**

[PresentationFactory](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/) 類別同樣提供用於從簡報擷取全部文字的方法：

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

`TextExtractionArrangingMode` 列舉參數指示文字擷取結果的組織方式，可設定為以下值：
- `UNARRANGED` - 原始文字，不考慮其在投影片上的位置。
- `ARRANGED` - 文字依投影片上的順序排列。

當速度至關重要時，可使用 `UNARRANGED` 模式；它比 `ARRANGED` 模式更快。

[PresentationText](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationtext/) 代表從簡報中擷取的原始文字。其 `slides_text` 屬性回傳投影片文字物件的陣列。每個物件代表對應投影片的文字，並具有以下屬性：

- `text` - 投影片形狀內的文字。
- `master_text` - 與此投影片相關的母版投影片形狀內的文字。
- `layout_text` - 與此投影片相關的版面配置投影片形狀內的文字。
- `notes_text` - 投影片備註形狀內的文字。
- `comments_text` - 與此投影片相關的評論文字。

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **常見問題**

**Aspose.Slides 在大量簡報的文字擷取過程中速度如何？**

Aspose.Slides 已為高效能進行最佳化，即使是[大型簡報](/slides/zh-hant/python-net/open-presentation/)，也能快速處理，適用於即時或批次處理情境。

**Aspose.Slides 能否從簡報中的表格與圖表擷取文字？**

可以。Aspose.Slides 能從多種投影片元件擷取文字，包括表格與圖表相關物件，讓您得以存取並分析常見簡報結構中的文字內容。

**擷取簡報文字是否需要特殊的 Aspose.Slides 授權？**

您可使用 Aspose.Slides 的免費試用版進行文字擷取，但會有[某些限制](/slides/zh-hant/python-net/licensing/)，例如只能處理有限張投影片。若需無限制使用且處理更大簡報，建議購買完整授權。