---
title: Search and Replace Text in PowerPoint Presentations in Python
linktitle: Search and Replace Text
type: docs
weight: 55
url: /python-net/search-and-replace-text/
keywords:
- search text
- highlight text
- replace text
- regular expression
- text frame
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Search, highlight, and replace text in PowerPoint presentations with Aspose.Slides for Python via .NET."
---

## **Overview**

Aspose.Slides for Python via .NET can search, highlight, and replace text in an individual text frame or across an entire presentation. These capabilities are useful for review, redaction, terminology checks, template cleanup, and other automated document-processing workflows.

In the first examples below, we use a file named "sample.pptx", which contains a single text box on the first slide with the following text:

![Sample text](sample_text.png)

## **Choose the Search Scope**

Use methods on [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) to limit an operation to one text frame. Use methods on [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) to process all applicable text in the presentation.

| Operation | One text frame | Entire presentation |
|---|---|---|
| Highlight literal text | [TextFrame.highlight_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/highlight_text/) |
| Highlight regular-expression matches | [TextFrame.highlight_regex](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/highlight_regex/) |
| Replace literal text | [TextFrame.replace_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/replace_text/) |
| Replace regular-expression matches | [TextFrame.replace_regex](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/replace_regex/) |

## **Configure Text Matching**

For literal-text operations, use [TextSearchOptions](https://reference.aspose.com/slides/python-net/aspose.slides/textsearchoptions/) to control matching:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/python-net/aspose.slides/textsearchoptions/whole_words_only/) limits matches to complete words.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/python-net/aspose.slides/textsearchoptions/case_sensitive/) controls whether character case must match.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/python-net/aspose.slides/textsearchoptions/include_notes/) includes slide notes in presentation-level search, replacement, and highlighting operations.

Regular-expression operations use a pattern string, so matching rules such as case sensitivity and word boundaries are defined by the expression.

## **Identify the Owner of a Text Frame**

Generic text-processing workflows often receive a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) while searching, replacing, validating, or exporting text. Use [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) and [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) to determine which presentation object owns the text frame.

The expected values depend on the owner:

| Text frame owner | `parent_shape` | `parent_cell` |
|---|---|---|
| An AutoShape or another text-containing shape | The owning [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) | `None` |
| A table cell | `None` | The owning [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) |

Both properties are read-only navigation properties. Reading them does not move the text frame or change its owner. Generic code should check both values for `None` and handle the possibility that neither owner is available.

The following example uses [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) to iterate through the text frames in a presentation. For shapes, it reports the shape name, Python runtime type, and containing slide. For table cells, it reports the zero-based column and row coordinates and the containing slide.

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

For SmartArt content, iterate through the shapes in [SmartArtNode.shapes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/shapes/) and access each [ISmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/ismartartshape/text_frame/). The text frame can be traced to its associated shape through [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/), while [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) is `None`. Therefore, the shape branch in the example also handles text from SmartArt nodes.

## **Highlight Text**

Use the [TextFrame.highlight_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/highlight_text/) method to highlight literal-text matches in a text frame. Pass [TextSearchOptions](https://reference.aspose.com/slides/python-net/aspose.slides/textsearchoptions/) to control the search.

The code example below highlights all occurrences of the characters **"try"** and then highlights only the complete word **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Highlight every occurrence of "try" in the text frame.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Highlight only the complete word "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The highlighted text](highlighted_text.png)

## **Highlight Text Using Regular Expressions**

The [TextFrame.highlight_regex](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/highlight_regex/) method highlights text matches found by a regular expression in a text frame.

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

The result:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Highlight Text Across a Presentation**

Use [Presentation.highlight_text](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/highlight_text/) and [Presentation.highlight_regex](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/highlight_regex/) to search all applicable text frames in a presentation. The following example highlights a literal term and all email addresses:

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

## **Replace Text in a Text Frame**

Use [TextFrame.replace_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/replace_text/) for literal text and [TextFrame.replace_regex](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/replace_regex/) for pattern-based replacement. These methods update matched text within the existing text frame, which retains the surrounding portion formatting instead of rebuilding the text frame from a plain string.

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

## **Replace Text Across a Presentation**

Use [Presentation.replace_text](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/replace_text/) and [Presentation.replace_regex](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/replace_regex/) to apply the same operations across the presentation. This is useful for template cleanup, terminology updates, and redaction.

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

## **FAQ**

**How can I search only one text box instead of the entire presentation?**

Get the shape's text frame and call [TextFrame.highlight_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/replace_text/), or [TextFrame.replace_regex](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/replace_regex/) on that text frame. Presentation-level methods process all applicable text frames instead.

**How can I match complete words with the correct capitalization?**

Set [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/python-net/aspose.slides/textsearchoptions/whole_words_only/) and [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/python-net/aspose.slides/textsearchoptions/case_sensitive/) to `True`, and pass the options to a literal-text highlighting or replacement method. For regular expressions, define word boundaries and case sensitivity in the pattern itself.

**Can search and replacement include text in slide notes?**

Yes. Set [TextSearchOptions.include_notes](https://reference.aspose.com/slides/python-net/aspose.slides/textsearchoptions/include_notes/) to `True` when using a presentation-level literal-text operation.

**Does replacing text preserve its formatting?**

[TextFrame.replace_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/replace_text/) and [TextFrame.replace_regex](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/replace_regex/) modify matched text within the existing text frame and retain the surrounding portion formatting. If a match spans portions with different formatting, inspect the result to ensure the replacement uses the desired style.
