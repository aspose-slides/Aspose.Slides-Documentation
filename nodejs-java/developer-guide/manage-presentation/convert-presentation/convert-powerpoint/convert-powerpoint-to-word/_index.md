---
title: Convert PowerPoint to Word
type: docs
weight: 110
url: /nodejs-java/convert-powerpoint-to-word/
keywords: "Convert PowerPoint, PPT, PPTX, Presentation, Word, DOCX, DOC, PPTX to DOCX, PPT to DOC, PPTX to DOC, PPT to DOCX, Java, java, Aspose.Slides"
description: "Convert PowerPoint Presentation to Word in Javascript"
---

If you plan to use textual content or information from a presentation (PPT or PPTX) in new ways, you may benefit from converting the presentation to Word (DOC or DOCX). 

* When compared to Microsoft PowerPoint, the Microsoft Word app is more equipped with tools or functionalities for content. 
* Besides the editing functions in Word, you may also benefit from enhanced collaboration, printing, and sharing features. 

{{% alert color="primary" %}} 

You may want to try out our [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) to see what you could gain from working with textual content from slides. 

{{% /alert %}} 

## **Aspose.Slides and Aspose.Words**

To convert a PowerPoint file (PPTX or PPT) to Word (DOCX or DOCX), you need both [Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) and [Aspose.Words for Java](https://products.aspose.com/words/java/).

As a standalone API, [Aspose.Slides](https://products.aspose.app/slides) for java provides functions that allow you to extract texts from presentations. 

[Aspose.Words](https://docs.aspose.com/words/java/) is an advanced document processing API that allows applications to generate, modify, convert, render, print files, and perform other tasks with documents without utilizing Microsoft Word.

## **Convert PowerPoint to Word**

1. Download [Aspose.Slides for Node.js via Java](https://downloads.aspose.com/slides/java) and [Aspose.Words for Java](https://downloads.aspose.com/words/java) libraries.
2. Add *aspose-slides-x.x-jdk16.jar* and *aspose-words-x.x-jdk16.jar* to your CLASSPATH.
3. Use this code snippet to convert the PowerPoint to Word:

```javascript
    var pres = new  aspose.slides.Presentation(inputPres);
    try {
        var doc = java.newInstanceSync("Document", );
        var builder = java.newInstanceSync("DocumentBuilder", doc);
        pres.getSlides().forEach(function(slide) {
            // generates and inserts slide image
            var bitmap = slide.getThumbnail(1, 1);
            builder.insertImage(bitmap);
            // inserts slide's texts
            slide.getShapes().forEach(function(shape) {
                if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                    builder.writeln(shape.getTextFrame().getText());
                }
            });
            builder.insertBreak(java.getStaticFieldValue("BreakType", "PAGE_BREAK"));
        });
        doc.save(outputDoc);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
