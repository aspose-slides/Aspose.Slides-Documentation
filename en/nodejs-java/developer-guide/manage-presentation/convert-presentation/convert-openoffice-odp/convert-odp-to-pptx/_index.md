---
title: Convert ODP to PPTX
type: docs
weight: 10
url: /nodejs-java/convert-odp-to-pptx/
---

## **Convert ODP to PPTX/PPT Presentation**
Aspose.Slides for Node.js via Java offers [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class that represents a presentation file. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class can now also access ODP through [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) constructor when the object is instantiated. The following example shows how to convert a ODP Presentation into PPTX Presentation.

```javascript
// Open the ODP file
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Saving the ODP presentation to PPTX format
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Live Example**
You can visit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) web app, which is built with **Aspose.Slides API.** The app demonstrates how ODP to PPTX conversion can be implemented with Aspose.Slides API.
