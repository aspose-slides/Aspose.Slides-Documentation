---
title: Effortlessly Convert PowerPoint to Word in C# and .NET
linktitle: Convert PowerPoint to Word
type: docs
weight: 110
url: /net/convert-powerpoint-to-word/
keywords:
- Convert PowerPoint
- PPT
- PPTX
- Presentation
- Word
- DOCX
- DOC
- PPTX to DOCX
- PPT to DOC
- PPTX to DOC
- PPT to DOCX
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Convert PowerPoint Presentations to Word Documents using C# and .NET seamlessly."
---

Do you need to repurpose content from your PowerPoint presentations (PPT or PPTX)? Converting them to Word documents (DOC or DOCX) can streamline your workflow and enhance content utilization.

* Microsoft Word offers advanced tools and functionalities for document editing.
* It also provides robust features for collaboration, printing, and sharing.

{{% alert color="primary" %}}

Try our [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) to discover the potential of extracting text from slides effortlessly.

{{% /alert %}}

### **Leverage Aspose.Slides and Aspose.Words**

To successfully convert PowerPoint files (PPTX or PPT) to Word (DOCX or DOC), install [Aspose.Slides for .NET](https://products.aspose.com/slides/net/) and [Aspose.Words for .NET](https://products.aspose.com/words/net/).

[Aspose.Slides](https://products.aspose.app/slides) for .NET extracts text content efficiently from presentations, while [Aspose.Words](https://docs.aspose.com/words/net/) for .NET handles document creation, modification, conversion, rendering, and more, without relying on Microsoft Word.

## **Quick Start: Convert PowerPoint to Word**

1. Import these namespaces in your program.cs file:

```c#
using Aspose.Slides;
using Aspose.Words;
using System.IO;
```

2. Implement this code snippet to perform the conversion:

```c#
using var presentation = new Presentation("sample.pptx");

var doc = new Document();
var builder = new DocumentBuilder(doc);

foreach (var slide in presentation.Slides)
{
    // Generate a slide image and save it to a memory stream
    using var image = slide.GetImage(1, 1);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray());

    // Insert slide text into the document
    foreach (var shape in slide.Shapes)
    {
        if (shape is AutoShape autoShape)
        {
            builder.Writeln(autoShape.TextFrame.Text);
        }
    }

    builder.InsertBreak(BreakType.PageBreak);
}

doc.Save("output.docx");
```