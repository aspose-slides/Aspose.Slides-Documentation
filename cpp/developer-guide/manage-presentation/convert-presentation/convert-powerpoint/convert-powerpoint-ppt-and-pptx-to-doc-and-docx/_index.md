---
title: Convert PowerPoint to Word
type: docs
weight: 110
url: /cpp/convert-powerpoint-ppt-and-pptx-to-doc-and-docx/
keywords: "Convert PowerPoint, PPT, PPTX, Presentation, Word, DOCX, DOC, PPTX to DOCX, PPT to DOC, PPTX to DOC, PPT to DOCX, C++, Aspose.Slides"
description: "Convert PowerPoint Presentation to Word in C++ "
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
    auto bitmap = slide->GetThumbnail(1.0f, 1.0f);
    builder->InsertImage(bitmap);

    // inserts slide's texts
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::DynamicCast_noexcept<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```
