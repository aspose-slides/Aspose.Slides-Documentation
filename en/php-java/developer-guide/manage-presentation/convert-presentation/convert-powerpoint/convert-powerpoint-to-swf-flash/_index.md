---
title: Convert PowerPoint to SWF Flash
type: docs
weight: 80
url: /php-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX to SWF"
description: "Convert PowerPoint PPT, PPTX to SWF "
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
