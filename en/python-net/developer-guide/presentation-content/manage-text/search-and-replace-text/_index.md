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
