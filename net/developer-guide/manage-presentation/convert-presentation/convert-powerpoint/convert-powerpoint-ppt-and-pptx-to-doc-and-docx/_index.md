---
title: Convert PowerPoint PPT and PPTX to DOC and DOCX
type: docs
weight: 110
url: /net/convert-powerpoint-ppt-and-pptx-to-doc-and-docx/
keywords: "Convert PowerPoint, PPT, PPTX, Presentation, Word, DOCX, DOC, PPTX to DOCX, PPT to DOC, PPTX to DOC, PPT to DOCX, C#, Csharp, .NET, Aspose.Slides"
description: "Convert PowerPoint Presentation to Word in C# or .NET "
---

If you intend to use textual content or information from a presentation (PPT or PPTX) in new ways, you may benefit from converting the presentation to Word (DOC or DOCX). For example, compared to the Microsoft Presentation app, the Microsoft Word app is more equipped with tools or functionalities that allow you to improve and manipulate content for different purposes. 

{{% alert color="primary" %}} 

You can try out our [**Presentation to Word online converter**](https://products.aspose.app/slides/conversion/ppt-to-word). This way, you get to see what you could gain from working with textual content from slides. 

{{% /alert %}} 

Besides the numerous functions you get to use in a Word editor, you may also benefit from enhanced collaboration, printing, and sharing features. If necessary, you can easily transform your presentation into a poster or brochure (webpage or printed).

As a standalone API, [**Aspose.Slides**](https://products.aspose.app/slides) for .NET provides functions that allow you to extract texts from presentations. To convert PPT to DOC or DOCX, you will have to use Aspose.Slides with another API. 

**Extracting the Text**

You can start by using the [**GetAllTextFrames** ](https://apireference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextframes)method from the [**SlideUtil** ](https://apireference.aspose.com/slides/net/aspose.slides.util/slideutil)class to extract the required text from an entire presentation. After the extraction, you can write the text into a DOC/DOCX document.

{{% alert color="primary" %}} 

See [**Extracting Text from the Presentation**](/slides/net/extracting-text-from-the-presentation/)**.**

{{% /alert %}} 

**Creating the Word Document**

After extracting the text from a presentation, you can use Aspose.Slides together with another API ([Aspose.Words](https://products.aspose.com/words/net), for example) to create the Word (DOC or DOCX) file. This sample code demonstrates the projected operation:

```c#
using(Presentation presentation = new Presentation("pres.pptx"))
using (var stream = new MemoryStream())
{
    presentation.Save(stream, SaveFormat.Html);
    stream.Flush();
    stream.Seek(0, SeekOrigin.Begin);

    var doc = new Aspose.Words.Document(stream);
    doc.Save("pres.docx", Aspose.Words.SaveFormat.Docx);
}
```

