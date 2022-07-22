---
title: Convert ODP to PPTX
type: docs
weight: 10
url: /cpp/convert-odp-to-pptx/
---

Aspose.Slides for .NET offers Presentation class that represents a presentation file. [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class can now also access ODP through Presentation constructor when the object is instantiated. The following example shows how to convert a ODP Presentation into PPTX Presentation.

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

// Open the ODP file
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Saving the ODP presentation to PPTX format
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```



## **Live Example**
You can visit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) web app, which is built with **Aspose.Slides API.** The app demonstrates how ODP to PPTX conversion can be implemented with Aspose.Slides API.