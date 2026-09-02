---
title: 在 Python 中对 PowerPoint 演示文稿进行搜索和替换文本
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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中搜索、突出显示和替换文本。"
---
## **概述**

Aspose.Slides for Python via .NET 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。这些功能对于审阅、编辑、术语检查、模板清理以及其他自动化文档处理工作流非常有用。

在下面的第一个示例中，我们使用名为 “sample.pptx” 的文件，该文件在第一张幻灯片上包含一个单独的文本框，文本内容如下：

![示例文本](sample_text.png)

## **选择搜索范围**

Use methods on [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) to limit an operation to one text frame. Use methods on [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) to process all applicable text in the presentation.

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 突出显示字面文本 | [TextFrame.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/highlight_text/) |
| 突出显示正则表达式匹配 | [TextFrame.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/highlight_regex/) |
| 替换字面文本 | [TextFrame.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/replace_text/) |
| 替换正则表达式匹配 | [TextFrame.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/replace_regex/) |

## **配置文本匹配**

For literal-text operations, use [TextSearchOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/) to control matching:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/whole_words_only/) 将匹配限制为完整的单词。
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/case_sensitive/) 控制字符大小写是否必须匹配。
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/include_notes/) 在演示级别的搜索、替换和突出显示操作中包含幻灯片备注。

正则表达式操作使用模式字符串，因此诸如大小写敏感性和单词边界之类的匹配规则由表达式本身定义。

## **识别文本框的所有者**

Generic text-processing workflows often receive a [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) while searching, replacing, validating, or exporting text. Use [TextFrame.parent_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/parent_shape/) and [TextFrame.parent_cell](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/parent_cell/) to determine which presentation object owns the text frame.

The expected values depend on the owner:

| Text frame owner | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape 或其他包含文本的形状 | The owning [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) | `None` |
| 表格单元格 | `None` | The owning [Cell](https://reference.aspose.com/slides/zh/python-net/aspose.slides/cell/) |

Both properties are read-only navigation properties. Reading them does not move the text frame or change its owner. Generic code should check both values for `None` and handle the possibility that neither owner is available.

The following example uses [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/get_all_text_frames/) to iterate through the text frames in a presentation. For shapes, it reports the shape name, Python runtime type, and containing slide. For table cells, it reports the zero-based column and row coordinates and the containing slide.

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

For SmartArt content, iterate through the shapes in [SmartArtNode.shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartartnode/shapes/) and access each [ISmartArtShape.text_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/ismartartshape/text_frame/). The text frame can be traced to its associated shape through [TextFrame.parent_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/parent_shape/), while [TextFrame.parent_cell](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/parent_cell/) is `None`. Therefore, the shape branch in the example also handles text from SmartArt nodes.

## **突出显示文本**

Use the [TextFrame.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_text/) method to highlight literal-text matches in a text frame. Pass [TextSearchOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/) to control the search.

The code example below highlights all occurrences of the characters **"try"** and then highlights only the complete word **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # 突出显示文本框中每个出现的 "try"。
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

结果如下：

![已突出显示的文本](highlighted_text.png)

## **使用正则表达式突出显示文本**

The [TextFrame.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_regex/) method highlights text matches found by a regular expression in a text frame.

The following code highlights all words containing seven or more characters:

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

结果如下：

![使用正则表达式突出显示的文本](highlighted_text_using_regex.png)

## **跨演示文稿突出显示文本**

Use [Presentation.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/highlight_text/) and [Presentation.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/highlight_regex/) to search all applicable text frames in a presentation. The following example highlights a literal term and all email addresses:

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

Use [TextFrame.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_text/) for literal text and [TextFrame.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_regex/) for pattern-based replacement. These methods update matched text within the existing text frame, which retains the surrounding portion formatting instead of rebuilding the text frame from a plain string.

The following example standardizes a spelling variant and then replaces version labels:

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

If one match spans portions with different formatting, review the output to confirm which formatting should apply to the replacement text.

## **跨演示文稿替换文本**

Use [Presentation.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/replace_text/) and [Presentation.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/replace_regex/) to apply the same operations across the presentation. This is useful for template cleanup, terminology updates, and redaction.

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

**如何仅在一个文本框中搜索，而不是整个演示文稿？**

获取形状的文本框，然后在该文本框上调用 [TextFrame.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_text/)、[TextFrame.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_regex/)、[TextFrame.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_text/) 或 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_regex/)。演示级别的方法则会处理所有适用的文本框。

**如何匹配完整单词且保持正确的大小写？**

将 [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/whole_words_only/) 和 [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/case_sensitive/) 设置为 `True`，并将这些选项传递给字面文本的突出显示或替换方法。对于正则表达式，在模式本身中定义单词边界和大小写敏感性。

**搜索和替换是否可以包括幻灯片备注中的文本？**

可以。使用演示级别的字面文本操作时，将 [TextSearchOptions.include_notes](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/include_notes/) 设置为 `True`。

**替换文本时会保留其格式吗？**

[TextFrame.replace_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_text/) 和 [TextFrame.replace_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/replace_regex/) 在现有文本框中修改匹配的文本并保留周围部分的格式。如果匹配跨越不同格式的部分，请检查结果以确保替换使用所需的样式。