---
title: 在 Python 中搜尋與取代 PowerPoint 簡報文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/python-net/search-and-replace-text/
keywords:
- 搜尋文字
- 突顯文字
- 取代文字
- 正規表達式
- 文字框
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中搜尋、突顯與取代文字。"
---
## **概述**

Aspose.Slides for Python via .NET 可以在單一文字框或整個簡報中搜尋、突顯與取代文字。這些功能適用於審閱、編輯、術語檢查、範本清理以及其他自動化文件處理工作流程。

在以下第一個範例中，我們使用名為 "sample.pptx" 的檔案，該檔案在第一張投影片上包含一個文字方塊，文字內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 上的方法將操作限制於單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 上的方法則會處理簡報中所有符合條件的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| Highlight literal text | [TextFrame.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/highlight_text/) |
| Highlight regular-expression matches | [TextFrame.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/highlight_regex/) |
| Replace literal text | [TextFrame.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/replace_text/) |
| Replace regular-expression matches | [TextFrame.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/replace_regex/) |

## **設定文字匹配**

對於純文字操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/) 來控制匹配方式：

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/whole_words_only/) 只限完整單字匹配。
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/case_sensitive/) 控制是否必須符合大小寫。
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/include_notes/) 將投影片備註納入簡報層級的搜尋、取代與突顯操作。

正規表達式操作使用模式字串，因此大小寫敏感度與單字邊界等規則需在表達式本身定義。

## **識別文字框的擁有者**

在一般的文字處理工作流程中，常會取得一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 來執行搜尋、取代、驗證或匯出。使用 [TextFrame.parent_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/parent_shape/) 與 [TextFrame.parent_cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/parent_cell/) 可判斷是哪個簡報物件擁有此文字框。

預期的值取決於擁有者：

| 文字框擁有者 | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape 或其他含文字的形狀 | 擁有者 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) | `None` |
| 表格儲存格 | `None` | 擁有者 [Cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/) |

兩個屬性皆為唯讀導覽屬性。讀取它們不會移動文字框或變更其擁有者。通用程式碼應檢查兩個值是否為 `None`，並處理兩者皆不存在的情況。

以下範例使用 [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/get_all_text_frames/) 逐一遍歷簡報中的文字框。對於形狀，會回報形狀名稱、Python 執行時類型與所屬投影片；對於表格儲存格，則回報零基礎的欄列座標與所屬投影片。

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

對於 SmartArt 內容，遍歷 [SmartArtNode.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartartnode/shapes/) 中的形狀，並存取每個 [ISmartArtShape.text_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/ismartartshape/text_frame/)。文字框可透過 [TextFrame.parent_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/parent_shape/) 追溯至其相關形狀，而 [TextFrame.parent_cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/parent_cell/) 為 `None`。因此範例中的形狀分支也會處理來自 SmartArt 節點的文字。

## **突顯文字**

使用 [TextFrame.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_text/) 方法在文字框中突顯純文字匹配項目。傳入 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/) 以控制搜尋條件。

以下程式碼範例先突顯所有出現的字串 **"try"**，再僅突顯完整單字 **"to"**。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # 在文字框中突顯每一次出現的「try」字串。
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # 僅突顯完整單字「to」。
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![已突顯的文字](highlighted_text.png)

## **使用正規表達式突顯文字**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_regex/) 方法會突顯在文字框中由正規表達式找到的文字匹配項目。

以下程式碼突顯所有包含七個或以上字元的單字：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

結果：

![使用正規表達式突顯的文字](highlighted_text_using_regex.png)

## **在簡報中突顯文字**

使用 [Presentation.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/highlight_text/) 與 [Presentation.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/highlight_regex/) 可在簡報中搜尋所有符合條件的文字框。以下範例突顯一個純文字詞彙與所有電子郵件地址：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **在文字框中取代文字**

使用 [TextFrame.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_text/) 處理純文字，使用 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_regex/) 處理基於模式的取代。這些方法會在現有文字框內更新符合的文字，保留其周圍的格式，而不是以純字串重新建構文字框。

以下範例先統一一種拼寫變體，然後取代版本標籤：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

如果單一匹配跨越了不同格式的區段，請檢查輸出以確認取代文字應使用哪種格式。

## **在簡報中取代文字**

使用 [Presentation.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/replace_text/) 與 [Presentation.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/replace_regex/) 可在整個簡報套用相同的取代操作。此功能適用於範本清理、術語更新與編輯。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **常見問題**

**如何只搜尋單一文字方塊而不是整個簡報？**

取得形狀的文字框，並在該文字框上呼叫 [TextFrame.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_text/)、[TextFrame.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_regex/)、[TextFrame.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_text/)、或 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_regex/)。簡報層級的方法則會處理所有符合條件的文字框。

**如何以正確的大小寫匹配完整單字？**

將 [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/whole_words_only/) 與 [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/case_sensitive/) 設為 `True`，並將選項傳遞給純文字的突顯或取代方法。對於正規表達式，請在模式本身定義單字邊界與大小寫敏感度。

**搜尋與取代可以包含投影片備註中的文字嗎？**

可以。使用簡報層級的純文字操作時，將 [TextSearchOptions.include_notes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/include_notes/) 設為 `True`。

**取代文字會保留原有格式嗎？**

[TextFrame.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_text/) 與 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_regex/) 會在現有文字框內修改匹配的文字，並保留周圍區段的格式。如果匹配跨越了不同的格式，請檢查結果以確保取代文字使用所需的樣式。