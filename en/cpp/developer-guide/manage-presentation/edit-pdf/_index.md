---
title: Edit PDF Documents in C++
linktitle: Edit PDF
type: docs
weight: 65
url: /cpp/edit-pdf/
keywords:
- edit PDF
- replace PDF text
- PDF to PPTX
- PPTX to PDF
- C++
- Aspose.Slides
description: "Edit PDF documents in C++ by importing them into Aspose.Slides, replacing text, and saving the modified presentation back to PDF."
---

## **Overview**

Aspose.Slides for C++ lets you edit PDF content by importing its pages as slides, modifying the presentation, and exporting it back to PDF. This article shows a simple text replacement. The presentation stays in memory, so saving an intermediate PPTX file is optional.

## **Replace Text in a PDF**

Use [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/addfrompdf/) to import the pages, [Presentation::ReplaceText](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/replacetext/) to update the text, and [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) to export the result.

The following example expects `input.pdf` to contain the word "Draft" as editable text after import. It replaces that word with "Final" and writes `edited.pdf`. Clearing the initial slide before import prevents an extra blank page in the output. The search matches whole words with the same letter case; `nullptr` means no result callback is needed.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

For more options, see [Search and Replace Text](/slides/cpp/search-and-replace-text/) and [Convert PowerPoint to PDF](/slides/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

Text replacement works on imported text, not text inside scanned images. The conversion can affect layout and formatting, so review the output, especially when the replacement text is longer than the original.

{{% /alert %}}

## **FAQ**

**Do I need to save a PPTX file before exporting the PDF?**

No. You can edit and export the same presentation in memory. Save a PPTX copy only if you also want to continue editing it in PowerPoint; see [Save Presentations](/slides/cpp/save-presentation/).

**Why might some text remain unchanged?**

The example matches the whole word "Draft" with exact case. Text imported as an image or split across separate text frames will not necessarily match the search. Check the imported content and adjust the search for your document.
