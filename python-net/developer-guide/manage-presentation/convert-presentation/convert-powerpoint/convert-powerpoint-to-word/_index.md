---
title: Convert PowerPoint to Word
type: docs
weight: 110
url: /python-net/convert-powerpoint-to-word/
keywords: "Convert PowerPoint, PPT, PPTX, Presentation, Word, DOCX, DOC, PPTX to DOCX, PPT to DOC, PPTX to DOC, PPT to DOCX, Python, Aspose.Slides"
description: "Convert PowerPoint Presentation to Word in Python "
---

If you plan to use textual content or information from a presentation (PPT or PPTX) in new ways, you may benefit from converting the presentation to Word (DOC or DOCX). 

* When compared to Microsoft PowerPoint, the Microsoft Word app is more equipped with tools or functionalities for content. 
* Besides the editing functions in Word, you may also benefit from enhanced collaboration, printing, and sharing features. 

{{% alert color="primary" %}} 

You may want to try out our [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) to see what you could gain from working with textual content from slides. 

{{% /alert %}} 

## **Aspose.Slides and Aspose.Words**

To convert a PowerPoint file (PPTX or PPT) to Word (DOCX or DOCX), you need both [Aspose.Slides for Python via .NET](https://products.aspose.com/slides/python-net/) and [Aspose.Words for Python via .NET](https://products.aspose.com/words/python-net/).

As a standalone API, [Aspose.Slides](https://products.aspose.app/slides/python-net/) for Python via .NET provides functions that allow you to extract texts from presentations. 

[Aspose.Words](https://products.aspose.com/words/python-net/) is an advanced document processing API that allows applications to generate, modify, convert, render, print files, and perform other tasks with documents without utilizing Microsoft Word.

## **Convert PowerPoint to Word in Python**

1. Add these namespaces to your program.py file:

```py
import aspose.slides as slides
import aspose.words as words
```

2. Use this code snippet to convert the PowerPoint to Word:

```py
presentation = slides.Presentation("pres.pptx")
doc = words.Document()
builder = words.DocumentBuilder(doc)

for index in range(presentation.slides.length):
    slide = presentation.slides[index]
    # generates and inserts slide image
    slide.get_thumbnail(2,2).save("slide_{i}.png".format(i = index), drawing.imaging.ImageFormat.png)
    builder.insert_image("slide_{i}.png".format(i = index))
    
    for shape in slide.shapes:
        # inserts slide's texts
        if (type(shape) is slides.AutoShape):
            builder.writeln(shape.text_frame.text)
   
    builder.insert_break(words.BreakType.PAGE_BREAK)
doc.save("presentation.docx")
```
