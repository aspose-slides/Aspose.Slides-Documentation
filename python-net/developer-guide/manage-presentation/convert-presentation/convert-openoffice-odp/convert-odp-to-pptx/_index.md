---
title: Convert ODP to PPTX
type: docs
weight: 10
url: /python-net/convert-odp-to-pptx/
keywords: "Convert OpenOffice Presentation, ODP, ODP to PPTX, Python"
description: "Convert OpenOffice ODP to PowerPoint Presentation PPTX  in Python"
---

Aspose.Slides for Python via .NET offers Presentation class that represents a presentation file. [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class can now also access ODP through Presentation constructor when the object is instantiated. The following example shows how to convert a ODP Presentation into PPTX Presentation.

```py
# Import Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Open the ODP file
pres = slides.Presentation("AccessOpenDoc.odp")

# Saving the ODP presentation to PPTX format
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Live Example**
You can visit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) web app, which is built with **Aspose.Slides API.** The app demonstrates how ODP to PPTX conversion can be implemented with Aspose.Slides API.