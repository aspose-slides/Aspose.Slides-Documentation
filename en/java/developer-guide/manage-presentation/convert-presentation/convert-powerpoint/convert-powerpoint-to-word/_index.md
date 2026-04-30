---
title: Convert PowerPoint Presentations to Word Documents in Java
linktitle: PowerPoint to Word
type: docs
weight: 110
url: /java/convert-powerpoint-to-word/
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
- Java
- Aspose.Slides
description: "Convert PowerPoint PPT and PPTX slides to editable Word documents in Java using Aspose.Slides with precise layout, images and formatting preserved."
---

## **Overview**

This article provides a solution for developers on converting PowerPoint and OpenDocument presentations to Word documents using Aspose.Slides and Aspose.Words. The step-by-step guide walks you through every stage of the conversion process.

## **Convert PowerPoint to Word**

Follow the instructions below to convert a PowerPoint or OpenDocument presentation to a Word document:

1. Download [Aspose.Slides for Java](https://downloads.aspose.com/slides/java) and [Aspose.Words for Java](https://downloads.aspose.com/words/java) libraries.
2. Add *aspose-slides-x.x-jdk16.jar* and *aspose-words-x.x-jdk16.jar* to your CLASSPATH.
3. Use this code snippet to convert the PowerPoint to Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // generates a slide image as a byte array stream
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // inserts slide's texts
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **FAQ**

**What components need to be installed to convert PowerPoint and OpenDocument presentations to Word documents?**

You only need to add the respective package for [Aspose.Slides for Java](https://releases.aspose.com/slides/java/) and [Aspose.Words for Java](https://releases.aspose.com/words/java/) to your project. Both libraries operate as standalone APIs, and there is no requirement for Microsoft Office to be installed.

**Are all PowerPoint and OpenDocument presentation formats supported?**

Aspose.Slides [supports all presentation formats](/slides/java/supported-file-formats/), including PPT, PPTX, ODP, and other common file types. This ensures that you can work with presentations created in various versions of Microsoft PowerPoint.
