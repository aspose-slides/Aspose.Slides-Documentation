---
title: Import Presentation
type: docs
weight: 60
url: /python-net/import-presentation/
keywords: "Import PowerPoint, PDF to Presentation, PDF to PPTX, PDF to PPT, Python, Aspose.Slides for Python via .NET"
description: "Import PowerPoint presentation from PDF. Convert PDF to PowerPoint"
---

Aspose.Slides for Python via .NET allows you to import presentations from PDFs. Essentially, you get to convert a PDF to a PowerPoint presentation.

![pdf-to-powerpoint](pdf-to-powerpoint.png)

Go through these steps:

1. Instantiate an object of the presentation class. 
2. Call the [add_from_pdf](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.slidecollection/addfrompdf/) method and pass the PDF file. 
3. Use the [save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.presentation/) method to save the file in the PowerPoint format.

This Python code demonstrates the PDF to PowerPoint process:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides.remove_at(0)
    pres.slides.add_from_pdf("welcome-to-powerpoint.pdf")
    pres.save("OutputPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}} 

You may want to check out **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app because it is a live implementation of the process described here. 

{{% /alert %}} 
