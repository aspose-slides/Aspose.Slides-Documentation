---
title: Edit PDF Documents in .NET
linktitle: Edit PDF
type: docs
weight: 65
url: /net/edit-pdf/
keywords:
- edit PDF
- replace PDF text
- PDF to PPTX
- PPTX to PDF
- .NET
- C#
- Aspose.Slides
description: "Edit PDF documents in C# by importing them into Aspose.Slides, replacing text, and saving the modified presentation back to PDF."
---

## **Overview**

Aspose.Slides for .NET lets you edit PDF content by importing its pages as slides, modifying the presentation, and exporting it back to PDF. This article shows a simple text replacement. The presentation stays in memory, so saving an intermediate PPTX file is optional.

## **Replace Text in a PDF**

Use [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) to import the pages, [ReplaceText](https://reference.aspose.com/slides/net/aspose.slides/presentation/replacetext/) to update the text, and [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) to export the result.

The following example expects `input.pdf` to contain the word "Draft" as editable text after import. It replaces that word with "Final" and writes `edited.pdf`. Clearing the initial slide before import prevents an extra blank page in the output. The search matches whole words with the same letter case; `null` means no result callback is needed.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

For more options, see [Search and Replace Text](/slides/net/search-and-replace-text/) and [Convert PowerPoint to PDF](/slides/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

Text replacement works on imported text, not text inside scanned images. The conversion can affect layout and formatting, so review the output, especially when the replacement text is longer than the original.

{{% /alert %}}

## **FAQ**

**Do I need to save a PPTX file before exporting the PDF?**

No. You can edit and export the same presentation in memory. Save a PPTX copy only if you also want to continue editing it in PowerPoint; see [Save Presentations](/slides/net/save-presentation/).

**Why might some text remain unchanged?**

The example matches the whole word "Draft" with exact case. Text imported as an image or split across separate text frames will not necessarily match the search. Check the imported content and adjust the search for your document.
