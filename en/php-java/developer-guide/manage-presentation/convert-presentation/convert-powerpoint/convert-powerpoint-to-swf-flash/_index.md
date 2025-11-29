---
title: Convert PowerPoint Presentations to SWF Flash in PHP
linktitle: PowerPoint to SWF
type: docs
weight: 80
url: /php-java/convert-powerpoint-to-swf-flash/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to SWF
- presentation to SWF
- slide to SWF
- PPT to SWF
- PPTX to SWF
- PowerPoint to Flash
- presentation to Flash
- slide to Flash
- PPT to Flash
- PPTX to Flash
- save PPT as SWF
- save PPTX as SWF
- export PPT to SWF
- export PPTX to SWF
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Convert PowerPoint (PPT/PPTX) to SWF Flash in PHP with Aspose.Slides. Step‑by‑step code samples, fast quality output, no PowerPoint automation."
---

## **Convert PPT(X) to SWF**
The [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method exposed by [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class can be used to convert the whole presentation into **SWF** document. The following example shows how to convert a presentation into **SWF** document by using options provided by [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions) class.You can also include comments in generated SWF using [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) class and [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) interface.

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Saving presentation
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
```php

```
