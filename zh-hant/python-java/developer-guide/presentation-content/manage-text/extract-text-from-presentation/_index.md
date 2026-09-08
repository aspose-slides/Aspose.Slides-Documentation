---
title: 使用 Python 透過 Java 的進階簡報文字提取
linktitle: 提取文字
type: docs
weight: 90
url: /zh-hant/python-java/extract-text-from-presentation/
keywords:
- 提取文字
- 從投影片提取文字
- 從簡報提取文字
- 從 PowerPoint 提取文字
- 從 OpenDocument 提取文字
- 從 PPT 提取文字
- 從 PPTX 提取文字
- 從 ODP 提取文字
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，快速從 PowerPoint 與 OpenDocument 簡報中提取文字。遵循我們簡單的步驟指南，節省時間。"
---
## **概觀**

從簡報中提取文字是開發人員處理投影片內容時常見且必要的工作。無論您處理的是 Microsoft PowerPoint 的 PPT 或 PPTX 檔案，或是 OpenDocument 簡報 (ODP)，存取與取得文字資料對於分析、自動化、索引或內容遷移等目的都可能是關鍵。

本文提供了一份完整指南，說明如何使用 Aspose.Slides for Python via Java 有效率地從各種簡報格式（包括 PPT、PPTX 和 ODP）提取文字。您將學習如何系統性地遍歷簡報元素，以精確取得所需的文字內容。

## **從投影片提取文字**

Aspose.Slides for Python via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/) 類別。此類別公開了多個重載的 static 方法，用於從簡報或投影片中提取所有文字。若要從簡報中的投影片提取文字，請使用 [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/#getAllTextBoxes) 方法。此方法接受一個類型為 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/) 的物件作為參數。執行時，該方法會掃描整個投影片的文字，並回傳一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 型別的物件陣列，保留所有文字格式。

以下程式碼片段會從簡報的第一張投影片提取所有文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **從簡報提取文字**

要從整份簡報掃描文字，請使用由 [SlideUtil](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/) 類別所提供的 static 方法 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/#getAllTextFrames)。它接受兩個參數：

1. 首先，一個代表將從中提取文字的 PowerPoint 或 OpenDocument 簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件。
1. 其次，一個 `bool` 值，指示在掃描簡報文字時是否應包含母片。

此方法回傳一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 型別的物件陣列，包含文字格式資訊。以下程式碼會從簡報（包括母片）掃描文字與格式細節。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **分類與快速文字提取**

[PresentationFactory](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/) 類別也提供了從簡報中提取所有文字的方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# 從檔案提取文字。
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# 從串流提取文字。
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# 使用載入選項從串流提取文字。
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textextractionarrangingmode/) enum argument indicates the mode for organizing the text extraction result and can be set to the following values:

- [Unarranged](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - 未排序的原始文字，不考慮其在投影片上的位置。
- [Arranged](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - 文字按照投影片上的順序排列。

當速度至關重要時，可使用未排序模式；它比已排序模式更快。

[PresentationText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationtext/) 代表從簡報中提取的原始文字。其 [getSlidesText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationtext/#getSlidesText) 方法回傳一個 `SlideText` 型別的物件陣列。每個物件代表相對應投影片上的文字。`SlideText` 物件具備以下方法：

- `getText` - 投影片形狀內的文字。
- `getMasterText` - 與此投影片相關的母片形狀內的文字。
- `getLayoutText` - 與此投影片相關的版面配置投影片形狀內的文字。
- `getNotesText` - 與此投影片相關的備註投影片形狀內的文字。
- `getCommentsText` - 與此投影片相關的評論內的文字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **常見問題**

**Aspose.Slides 在文字提取過程中處理大型簡報的速度如何？**

Aspose.Slides 已針對高效能進行最佳化，甚至能處理[大型簡報](/slides/zh-hant/python-java/open-presentation/)，因此適用於即時或批次處理情境。

**Aspose.Slides 能從簡報中的表格與圖表提取文字嗎？**

可以。Aspose.Slides 能從許多投影片元素（包括表格與圖表相關物件）提取文字，讓您能存取與分析常見簡報結構中的文字內容。

**提取簡報文字是否需要特殊的 Aspose.Slides 授權？**

您可使用 Aspose.Slides 的免費試用版進行文字提取，然而它會有[某些限制](/slides/zh-hant/python-java/licensing/)，例如只能處理有限張數的投影片。若需無限制使用並處理較大型的簡報，建議購買完整授權。