---
title: Edit PDF Documents in Python
linktitle: Edit PDF
type: docs
weight: 65
url: /python-net/edit-pdf/
keywords:
- edit PDF
- replace PDF text
- PDF to PPTX
- PPTX to PDF
- Python
- Aspose.Slides
description: "Edit PDF documents in Python by importing them into Aspose.Slides, replacing text, and saving the modified presentation back to PDF."
---

## **Overview**

Aspose.Slides for Python via .NET lets you edit PDF content by importing its pages as slides, modifying the presentation, and exporting it back to PDF. This article shows a simple text replacement. The presentation stays in memory, so saving an intermediate PPTX file is optional.

## **Replace Text in a PDF**

Use [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) to import the pages, [replace_text](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/replace_text/) to update the text, and [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) to export the result.

The following example expects `input.pdf` to contain the word "Draft" as editable text after import. It replaces that word with "Final" and writes `edited.pdf`. Clearing the initial slide before import prevents an extra blank page in the output. The search matches whole words with the same letter case; `None` means no result callback is needed.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

For more options, see [Search and Replace Text](/slides/python-net/search-and-replace-text/) and [Convert PowerPoint to PDF](/slides/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

Text replacement works on imported text, not text inside scanned images. The conversion can affect layout and formatting, so review the output, especially when the replacement text is longer than the original.

{{% /alert %}}

## **FAQ**

**Do I need to save a PPTX file before exporting the PDF?**

No. You can edit and export the same presentation in memory. Save a PPTX copy only if you also want to continue editing it in PowerPoint; see [Save Presentations](/slides/python-net/save-presentation/).

**Why might some text remain unchanged?**

The example matches the whole word "Draft" with exact case. Text imported as an image or split across separate text frames will not necessarily match the search. Check the imported content and adjust the search for your document.
