---
title: Convert PowerPoint Presentations to Word Documents in PHP
linktitle: PowerPoint to Word
type: docs
weight: 110
url: /php-java/convert-powerpoint-to-word/
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
- PHP
- Aspose.Slides
description: "Convert PowerPoint PPT and PPTX slides to editable Word documents using Aspose.Slides for PHP via Java with precise layout, images and formatting preserved."
---

If you plan to use textual content or information from a presentation (PPT or PPTX) in new ways, you may benefit from converting the presentation to Word (DOC or DOCX). 

* When compared to Microsoft PowerPoint, the Microsoft Word app is more equipped with tools or functionalities for content. 
* Besides the editing functions in Word, you may also benefit from enhanced collaboration, printing, and sharing features. 

{{% alert color="primary" %}} 

You may want to try out our [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) to see what you could gain from working with textual content from slides. 

{{% /alert %}} 

## **Aspose.Slides and Aspose.Words**

To convert a PowerPoint file (PPTX or PPT) to Word (DOCX or DOCX), you need both [Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) and [Aspose.Words for Java](https://products.aspose.com/words/php-java/).

As a standalone API, [Aspose.Slides](https://products.aspose.app/slides) for java provides functions that allow you to extract texts from presentations. 

[Aspose.Words](https://docs.aspose.com/words/php-java/) is an advanced document processing API that allows applications to generate, modify, convert, render, print files, and perform other tasks with documents without utilizing Microsoft Word.

## **Convert PowerPoint to Word**

1. Download [Aspose.Slides for PHP via Java](https://downloads.aspose.com/slides/java) and [Aspose.Words for Java](https://downloads.aspose.com/words/java) libraries.
2. Add *aspose-slides-x.x-jdk16.jar* and *aspose-words-x.x-jdk16.jar* to your CLASSPATH.
3. Use this code snippet to convert the PowerPoint to Word:

```php
  $pres = new Presentation($inputPres);
  try {
    $doc = new Document();
    $builder = new DocumentBuilder($doc);
    foreach($pres->getSlides() as $slide) {
      # generates and inserts slide image
      $bitmap = $slide->getThumbnail(1, 1);
      $builder->insertImage($bitmap);
      # inserts slide's texts
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $builder->writeln($shape->getTextFrame()->getText());
        }
      }
      $builder->insertBreak(BreakType::PAGE_BREAK);
    }
    $doc->save($outputDoc);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
