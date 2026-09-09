---
title: 在 Python via Java 中搜尋與取代 PowerPoint 簡報的文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/python-java/search-and-replace-text/
keywords:
- 搜尋文字
- 突顯文字
- 取代文字
- 正則表達式
- 結果回呼
- 文字框
- 稽核報告
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在使用 Aspose.Slides for Python via Java 時，搜尋、突顯與取代 PowerPoint 簡報中的文字，並收集每個匹配項目。"
---
## **概述**

Aspose.Slides for Python via Java 可以在單一文字框或整份簡報中搜尋、突出顯示與取代文字。每項操作也可以透過結果回呼通知應用程式每一次匹配。這讓您能在更新簡報的同時，建立包含匹配文字、其上下文、位置、文字框與投影片編號的稽核紀錄。

此功能適用於審閱、遮蔽、術語檢查、範本清理與自動化報告工作流程。

在以下第一組範例中，我們使用名為「sample.pptx」的檔案，該檔案在第一張投影片上有一個文字方塊，文字內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 上的方法將操作限制在單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 上的方法則會處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| 突出顯示字面文字 | [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#highlightText) | [Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#highlightText) |
| 突出顯示正則表達式匹配 | [TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#highlightRegex) | [Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#highlightRegex) |
| 取代字面文字 | [TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#replaceText) | [Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#replaceText) |
| 取代正則表達式匹配 | [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#replaceRegex) | [Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#replaceRegex) |

## **設定文字匹配方式**

對於字面文字的操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textsearchoptions/) 來控制匹配方式：

- [setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 只限完整單詞匹配。
- [setCaseSensitive](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) 控制是否必須符合大小寫。
- [setIncludeNotes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) 包含投影片備註於簡報層級的搜尋、取代與突出顯示作業。

正則表達式的操作使用 Java `Pattern`，因此大小寫敏感與單詞邊界等規則由表達式本身及其旗標定義。

## **識別文字框的擁有者**

通用的文字處理工作流程在搜尋、取代、驗證或匯出文字時，往往會取得一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/)。使用 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#getParentShape) 與 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#getParentCell) 可判斷哪個簡報物件擁有此文字框。

預期值取決於擁有者：

| 文字框擁有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| 一個[AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)或其他包含文字的形狀 | 擁有的[Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) | `None` |
| 表格儲存格 | `None` | 擁有的[Cell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/) |

兩個方法皆提供唯讀導覽。呼叫它們不會移動文字框或變更其擁有者。通用程式碼應檢查兩個值是否為 `None`，並處理兩者皆不可用的情況。

以下範例使用 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/#getAllTextFrames) 迭代簡報中的所有文字框。對於形狀，會回報形狀名稱、Java 執行時類型與所在投影片。對於表格儲存格，會回報零基礎的欄與列座標以及所在投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

presentation = Presentation("presentation.pptx")
try:
    text_frames = SlideUtil.getAllTextFrames(presentation, False)
    for text_frame in text_frames:
        owner_shape = text_frame.getParentShape()
        owner_cell = text_frame.getParentCell()
        if owner_shape is not None:
            shape_name = str(owner_shape.getName()) or "(unnamed)"
            shape_type = owner_shape.getClass().getSimpleName()
            base_slide = owner_shape.getSlide()
        elif owner_cell is not None:
            base_slide = owner_cell.getSlide()
        else:
            print("The text frame owner is not available as a shape or table cell.")
            continue

        if isinstance(base_slide, Slide):
            slide_label = f"slide {base_slide.getSlideNumber()}"
        elif isinstance(base_slide, NotesSlide):
            slide_label = f"notes for slide {base_slide.getParentSlide().getSlideNumber()}"
        else:
            slide_label = str(base_slide.getClass().getSimpleName())

        if owner_shape is not None:
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
        else:
            print(f"Table cell: column {owner_cell.getFirstColumnIndex()}, row {owner_cell.getFirstRowIndex()}; {slide_label}")
finally:
    presentation.dispose()
```

對於 SmartArt 內容，請迭代 [SmartArtNode.getShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/#getShapes) 中的形狀，並存取每個 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartshape/#getTextFrame)。文字框可透過 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#getParentShape) 追溯至其關聯的形狀，而 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#getParentCell) 會回傳 `None`。因此，範例中的形狀分支亦會處理來自 SmartArt 節點的文字。

## **使用回呼收集匹配資訊**

透過 `jpype.JProxy` 實作 `IFindResultCallback`，即可在每一次匹配時接收通知。其 `foundResult` 方法會提供相關的文字框、來源文字、匹配文字與匹配位置。

回呼本身不會直接取得投影片編號。下方實作會從父投影片推算編號，並同時處理在投影片備註中找到的文字。可選的投影片編號讓相同的結果模型也能表示與其他投影片類型相關的文字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)
```

對於取代作業，`found_text` 會包含原始匹配文字，回呼因此能精確記錄被取代的詞彙。

## **突出顯示文字**

使用 [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#highlightText) 方法在文字框中突出顯示字面文字匹配。傳入 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textsearchoptions/) 以控制搜尋，並提供回呼以收集匹配細節。

以下程式碼範例先突出顯示所有 **"try"** 字元的出現，然後只突出顯示完整單詞 **"to"**。兩次搜尋皆將匹配結果回報給同一個回呼。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)

    substring_search_options = TextSearchOptions()
    substring_search_options.setCaseSensitive(False)
    substring_highlight_color = Color(173, 216, 230)

    # 在文字框中突出顯示每一次出現的 "try"。
    shape.getTextFrame().highlightText("try", substring_highlight_color, substring_search_options, callback)

    whole_word_search_options = TextSearchOptions()
    whole_word_search_options.setWholeWordsOnly(True)
    whole_word_search_options.setCaseSensitive(False)
    whole_word_highlight_color = Color(238, 130, 238)

    # 僅突出顯示完整單詞 "to"。
    shape.getTextFrame().highlightText("to", whole_word_highlight_color, whole_word_search_options, callback)

    for result in callback_handler.results:
        print(f"Found '{result.found_text}' at position {result.text_position} on slide {result.slide_number}.")

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![已標記的文字](highlighted_text.png)

## **使用正則表達式突出顯示文字**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#highlightRegex) 方法會突出顯示符合正則表達式的文字匹配。

以下程式碼會突出顯示所有包含七個以上字元的單詞，並收集每一次匹配：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    regex = Pattern.compile("\\b[^\\s]{7,}\\b")

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback)

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![使用正則表達式的已標記文字](highlighted_text_using_regex.png)

## **在整份簡報中突出顯示文字**

使用 [Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#highlightText) 與 [Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#highlightRegex) 來搜尋簡報中所有適用的文字框。以下範例同時突出顯示一個字面詞彙與所有電子郵件地址，並為兩個搜尋保留各自的結果集合。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    term_callback_handler = TextSearchCallback()
    term_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=term_callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    presentation.highlightText("confidential", Color.ORANGE, search_options, term_callback)

    email_callback_handler = TextSearchCallback()
    email_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=email_callback_handler)
    email_regex = Pattern.compile("\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", Pattern.CASE_INSENSITIVE)

    presentation.highlightRegex(email_regex, Color.YELLOW, email_callback)
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在文字框中取代文字**

使用 [TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#replaceText) 處理字面文字，使用 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#replaceRegex) 處理基於模式的取代。這些方法會在現有文字框內更新匹配的文字，保留周圍文字的格式，而不是以純文字重新建立文字框。

以下範例先統一拼寫變體，然後取代版本標籤。相同的回呼會記錄兩次作業匹配到的原始詞彙。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    shape.getTextFrame().replaceText("colour", "color", search_options, callback)

    version_regex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE)
    shape.getTextFrame().replaceRegex(version_regex, "current version", callback)

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果一次匹配跨越不同格式的部分，請檢查輸出以確認取代文字應採用哪種格式。

## **在整份簡報中取代文字**

使用 [Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#replaceText) 與 [Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#replaceRegex) 在簡報中套用相同的作業。這對於範本清理、術語更新與遮蔽非常有用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **將匹配結果分組以供報告**

因為每個結果都儲存了投影片編號與文字框，應用程式可以依投影片或文字框分組匹配，以供稽核、報告或審閱工作流程使用。以下範例先依投影片再依文字框分組收集的結果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
    matches_by_slide = {}
    for result in callback_handler.results:
        matches_by_text_frame = matches_by_slide.setdefault(result.slide_number, {})
        text_frame_matches = matches_by_text_frame.setdefault(result.text_frame, [])
        text_frame_matches.append(result)

    for slide_number, matches_by_text_frame in matches_by_slide.items():
        slide_label = "Other" if slide_number is None else str(slide_number)
        print(f"Slide: {slide_label}")
        for text_frame, results in matches_by_text_frame.items():
            print(f"  Text frame: {text_frame.getText()}")
            for result in results:
                print(f"    '{result.found_text}' at position {result.text_position}; context: '{result.source_text}'")
finally:
    presentation.dispose()
```

## **常見問題**

**如何只搜尋單一文字方塊而非整份簡報？**

取得形狀的文字框，然後對該文字框呼叫 [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#highlightText)、[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#highlightRegex)、[TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#replaceText) 或 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#replaceRegex)。簡報層級的方法則會處理所有適用的文字框。

**如何只匹配完整單詞且保持正確的大小寫？**

將 [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 及 [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) 設為 `True`，並將選項傳入字面文字的突出顯示或取代方法。對於正則表達式，請在 Java `Pattern` 本身定義單詞邊界與大小寫敏感性。

**搜尋與取代可以包含投影片備註中的文字嗎？**

可以。於簡報層級的字面文字作業時，將 [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) 設為 `True`。上方示範的回呼實作會將備註投影片中的匹配映射回其父投影片編號。

**如何在不再次掃描簡報的情況下產生報告？**

將 `IFindResultCallback` 實作傳入突出顯示或取代作業。回呼會在作業執行期間收到每一次匹配，讓應用程式可儲存來源文字、匹配文字、位置、文字框與衍生的投影片編號，以供之後分組或匯出。

**取代文字會保留其格式嗎？**

[TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#replaceText) 與 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#replaceRegex) 會在既有文字框內修改匹配的文字，並保留周圍文字的格式。如果一次匹配跨越不同格式的部分，請檢查結果以確保取代文字使用所需的樣式。