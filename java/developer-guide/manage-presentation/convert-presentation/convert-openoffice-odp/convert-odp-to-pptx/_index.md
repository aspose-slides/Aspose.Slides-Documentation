---
title: Convert ODP to PPTX
type: docs
weight: 10
url: /java/convert-odp-to-pptx/
---

## **Convert ODP to PPTX/PPT Presentation**
Aspose.Slides for Java offers [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class that represents a presentation file. [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class can now also access ODP through [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) constructor when the object is instantiated. The following example shows how to convert a ODP Presentation into PPTX Presentation.

```java
// Open the ODP file
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Saving the ODP presentation to PPTX format
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live Example**
You can visit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) web app, which is built with **Aspose.Slides API.** The app demonstrates how ODP to PPTX conversion can be implemented with Aspose.Slides API.
