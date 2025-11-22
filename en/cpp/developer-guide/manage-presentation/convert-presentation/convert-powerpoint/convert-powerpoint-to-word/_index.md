---
title: Convert PowerPoint Presentations to Word Documents in C++
linktitle: PowerPoint to Word
type: docs
weight: 110
url: /cpp/convert-powerpoint-to-word/
keywords:
- сonvert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to Word
- presentation to Word
- slide to Word
- PPT to Word
- PPTX to Word
- PowerPoint to DOCX
- presentation to DOCX
- slide to DOCX
- PPT to DOCX
- PPTX to DOCX
- PowerPoint to DOC
- presentation to DOC
- slide to DOC
- PPT to DOC
- PPTX to DOC
- save PPT as DOCX
- save PPTX as DOCX
- export PPT to DOCX
- export PPTX to DOCX
- C++
- Aspose.Slides
description: "Convert PowerPoint PPT and PPTX slides to editable Word documents in C++ using Aspose.Slides with precise layout, images and formatting preserved."
---

If you plan to use textual content or information from a presentation (PPT or PPTX) in new ways, you may benefit from converting the presentation to Word (DOC or DOCX). 

* When compared to Microsoft PowerPoint, the Microsoft Word app is more equipped with tools or functionalities for content. 
* Besides the editing functions in Word, you may also benefit from enhanced collaboration, printing, and sharing features. 

{{% alert color="primary" %}} 

You may want to try out our [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) to see what you could gain from working with textual content from slides. 

{{% /alert %}} 

### **Aspose.Slides and Aspose.Words**

To convert a PowerPoint file (PPTX or PPT) to Word (DOCX or DOCX), you need both [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) and [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

As a standalone API, [Aspose.Slides](https://products.aspose.app/slides) for C++ provides functions that allow you to extract texts from presentations. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) is an advanced document processing API that allows applications to generate, modify, convert, render, print files, and perform other tasks with documents without utilizing Microsoft Word.

## **Convert PowerPoint to Word**

Use this code snippet to convert the PowerPoint to Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // generates and inserts slide image
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // inserts slide's texts
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```
