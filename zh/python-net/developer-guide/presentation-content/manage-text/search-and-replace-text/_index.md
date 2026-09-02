---
title: 在 Python 中搜索和替换 PowerPoint 演示文稿的文本
linktitle: 搜索和替换文本
type: docs
weight: 55
url: /zh/python-net/search-and-replace-text/
keywords:
- 搜索文本
- 突出显示文本
- 替换文本
- 正则表达式
- 文本框
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 PowerPoint 演示文稿中使用 Aspose.Slides for Python via .NET 执行搜索、突出显示和替换文本。"
---
## **概述**

Aspose.Slides for Python via .NET 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。这些功能对于审阅、编辑、术语检查、模板清理以及其他自动化文档处理工作流非常有用。

在下面的第一个示例中，我们使用名为 **“sample.pptx”** 的文件，该文件的第一张幻灯片上有一个包含以下文字的文本框：

![Sample text](sample_text.png)

## **选择搜索范围**

使用 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 上的方法将操作限制在单个文本框内。使用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 上的方法可处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 突出显示文字文字 | [TextFrame.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/highlight_text/) |
| 突出显示正则表达式匹配 | [TextFrame.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/highlight_regex/) |
| 替换文字文字 | [TextFrame.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/replace_text/) |
| 替换正则表达式匹配 | [TextFrame.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/replace_regex/) |

## **配置文本匹配**

对于文字文字操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/) 来控制匹配方式：

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/whole_words_only/) 将匹配限制为完整单词。
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/case_sensitive/) 控制是否必须匹配字符大小写。
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/include_notes/) 在演示文稿级别的搜索、替换和突出显示操作中包含幻灯片备注。

正则表达式操作使用模式字符串，大小写敏感性和单词边界等匹配规则由表达式本身定义。

## **突出显示文本**

使用 [TextFrame.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_text/) 方法在文本框中突出显示文字文字匹配。传入 [TextSearchOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/) 以控制搜索。

下面的代码示例先突出显示所有 **“try”** 字符，然后仅突出显示完整单词 **“to”**。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # 突出显示文本框中所有出现的 "try"。
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # 仅突出显示完整单词 "to"。
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The highlighted text](highlighted_text.png)

## **使用正则表达式突出显示文本**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_regex/) 方法在文本框中突出显示正则表达式找到的文本匹配。

下面的代码突出显示所有包含七个或更多字符的单词：

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

结果：

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **在整个演示文稿中突出显示文本**

使用 [Presentation.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/highlight_text/) 和 [Presentation.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/highlight_regex/) 可搜索演示文稿中所有适用的文本框。下面的示例突出显示一个文字术语和所有电子邮件地址：

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

## **在文本框中替换文本**

使用 [TextFrame.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_text/) 进行文字文字替换，使用 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_regex/) 进行基于模式的替换。这些方法在现有文本框中更新匹配的文本，保留周围部分的格式，而不是从纯字符串重新构建文本框。

下面的示例统一拼写变体，然后替换版本标签：

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

如果一次匹配跨越不同格式的部分，请检查输出以确认替换文本应使用哪种格式。

## **在整个演示文稿中替换文本**

使用 [Presentation.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/replace_text/) 和 [Presentation.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/replace_regex/) 可在整个演示文稿中执行相同的操作。这对于模板清理、术语更新和编辑非常有用。

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

## **常见问题**

**如何只在单个文本框中搜索，而不是整个演示文稿？**

获取形状的文本框，并在该文本框上调用 [TextFrame.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_text/)、[TextFrame.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_regex/)、[TextFrame.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_text/) 或 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_regex/)。演示文稿级别的方法会处理所有适用的文本框。

**如何匹配完整单词并保持正确的大小写？**

将 [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/whole_words_only/) 和 [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/case_sensitive/) 设置为 `True`，并将这些选项传递给文字文字的突出显示或替换方法。对于正则表达式，请在模式本身中定义单词边界和大小写敏感性。

**搜索和替换是否可以包括幻灯片备注中的文本？**

可以。在使用演示文稿级别的文字文字操作时，将 [TextSearchOptions.include_notes](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/include_notes/) 设置为 `True`。

**替换文本时会保留其格式吗？**

[TextFrame.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_text/) 和 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_regex/) 会在现有文本框中修改匹配的文本并保留周围部分的格式。如果一次匹配跨越不同格式的部分，请检查结果以确保替换使用所需的样式。