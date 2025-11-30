---
title: Convert ODP to PPTX in PHP
linktitle: ODP to PPTX
type: docs
weight: 10
url: /php-java/convert-odp-to-pptx/
keywords:
- convert OpenDocument
- convert presentation
- convert slide
- convert ODP
- OpenDocument to PPTX
- ODP to PPTX
- save ODP as PPTX
- export ODP to PPTX
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Convert ODP to PPTX with Aspose.Slides for PHP via Java. Clean code examples, batch tips, and high-quality results—no PowerPoint needed."
---

## **Convert ODP to PPTX/PPT Presentation**
Aspose.Slides for PHP via Java offers [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class that represents a presentation file. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class can now also access ODP through [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) constructor when the object is instantiated. The following example shows how to convert a ODP Presentation into PPTX Presentation.

```php
// Open the ODP file
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Saving the ODP presentation to PPTX format
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Live Example**
You can visit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) web app, which is built with **Aspose.Slides API.** The app demonstrates how ODP to PPTX conversion can be implemented with Aspose.Slides API.
