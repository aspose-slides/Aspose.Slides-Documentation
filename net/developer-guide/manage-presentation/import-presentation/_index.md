---
title: Import Presentation
type: docs
weight: 60
url: /net/import-presentation/
keywords: "Import PowerPoint, PDF to Presentation, PDF to PPTX, PDF to PPT, C#, Csharp, Aspose.Slides for .NET"
description: "Import PowerPoint presentation from PDF. Convert PDF to PowerPoint"
---

Aspose.Slides for .NET allows you to import presentations from PDFs. Essentially, you get to convert a PDF to a PowerPoint presentation.

![pdf-to-powerpoint](pdf-to-powerpoint.png)

Go through these steps:

1. Instantiate an object of the presentation class. In our example, `pres` is the object. 
2. Call the [AddFromPdf](https://apireference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) method and pass the PDF file. 
3. Use the [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) method to save the file as a presentation.

This C# code demonstrates the PDF to PowerPoint process:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="Tip" color="primary" %}} 

You may want to check out **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app because it is a live implementation of the process described here. 

{{% /alert %}} 

