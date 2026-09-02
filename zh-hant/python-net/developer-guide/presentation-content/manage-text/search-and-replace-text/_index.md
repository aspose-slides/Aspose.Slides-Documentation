---
title: 在 Python 中搜尋與取代 PowerPoint 簡報文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/python-net/search-and-replace-text/
keywords:
- 搜尋文字
- 標記文字
- 取代文字
- 正規表示式
- 文字框
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中搜尋、標記與取代文字。"
---
## **概述**

Aspose.Slides for Python via .NET 可以在單一文字框或整個簡報中搜尋、標記與取代文字。這些功能對於審閱、遮蔽、術語檢查、範本清理以及其他自動化文件處理工作流程非常有用。

在以下的第一個範例中，我們使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字方塊，內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 方法將操作限制在單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 方法處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| 標記純文字 | [TextFrame.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/highlight_text/) |
| 標記正規表示式比對 | [TextFrame.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/highlight_regex/) |
| 取代純文字 | [TextFrame.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/replace_text/) |
| 取代正規表示式比對 | [TextFrame.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/replace_regex/) |

## **設定文字匹配**

對於純文字操作，請使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/) 來控制匹配方式：

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/whole_words_only/) 限制匹配僅限於完整的單詞。
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/case_sensitive/) 控制是否必須匹配字符大小寫。
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/include_notes/) 在簡報層級的搜尋、取代和標記操作中包含投影片註解。

正規表示式操作使用模式字串，因此如大小寫敏感性與字界限定等匹配規則由表達式本身定義。

## **標記文字**

使用 [TextFrame.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_text/) 方法在文字框中標記純文字匹配。傳入 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/) 以控制搜尋。

以下程式碼範例會標記所有 **"try"** 字元的出現，然後僅標記完整單詞 **"to"**。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # 將文字框中所有出現的「try」標示為高亮。
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # 僅將完整單詞「to」標示為高亮。
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：

![已標記的文字](highlighted_text.png)

## **使用正規表示式標記文字**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_regex/) 方法在文字框中標記正規表示式找到的文字匹配。

以下程式碼會標記所有包含七個或以上字元的單詞：

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

結果如下：

![使用正規表示式標記的文字](highlighted_text_using_regex.png)

## **跨簡報標記文字**

使用 [Presentation.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/highlight_text/) 和 [Presentation.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/highlight_regex/) 以搜尋簡報中所有適用的文字框。以下範例標記了純文字詞彙與所有電子郵件地址：

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

對於純文字使用 [TextFrame.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_text/)，對於基於模式的取代使用 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_regex/)。這些方法會在現有文字框內更新匹配的文字，保留周圍部分的格式，而不是從純字串重建文字框。

以下範例會標準化拼寫變體，然後取代版本標籤：

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

如果一個匹配跨越不同格式的部分，請檢查輸出以確認應套用於取代文字的格式。

## **跨簡報取代文字**

使用 [Presentation.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/replace_text/) 和 [Presentation.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/replace_regex/) 在整個簡報中套用相同的操作。這對於範本清理、術語更新與遮蔽非常有用。

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

**如何只搜尋單一文字方塊而非整個簡報？**

取得形狀的文字框，然後在該文字框上呼叫 [TextFrame.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_text/)、[TextFrame.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_regex/)、[TextFrame.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_text/) 或 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_regex/)。簡報層級的方法則會處理所有適用的文字框。

**如何以正確的大小寫匹配完整單詞？**

將 [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/whole_words_only/) 和 [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/case_sensitive/) 設為 `True`，並將這些選項傳遞給純文字的標記或取代方法。對於正規表示式，請在模式本身中定義字界限與大小寫敏感性。

**搜尋與取代可以包含投影片註解中的文字嗎？**

可以。使用簡報層級的純文字操作時，將 [TextSearchOptions.include_notes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/include_notes/) 設為 `True`。

**取代文字會保留其格式嗎？**

[TextFrame.replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_text/) 與 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/replace_regex/) 會在現有文字框內修改匹配的文字，且保留周圍部分的格式。如果匹配跨越不同格式的部分，請檢查結果以確保取代文字使用期望的樣式。