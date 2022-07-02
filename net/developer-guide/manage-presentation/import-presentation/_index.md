---
title: Import PowerPoint from PDF or HTML
linktitle: Import Presentation
type: docs
weight: 60
url: /net/import-presentation/
keywords: "Import PowerPoint, PDF to PowerPoint, HTML to PowerPoint, PDF to PPT, HTML to PPT, C#, Csharp, Aspose.Slides for .NET"
description: "Import PowerPoint from PDF or HTML. Convert PDF to PowerPoint. Convert HTML to PowerPoint"
---

Using [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), you can import presentations from files in other formats.

## **Import PowerPoint from PDF**

Aspose.Slides allows you to import presentations from PDF documents. In this case, you get to convert a PDF to a PowerPoint presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. 
2. Call the [AddFromPdf](https://apireference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) method and pass the PDF file. 
3. Use the [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) method to save the file as a PowerPoint document.

This C# code demonstrates the PDF to PowerPoint operation:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 

You may want to check out **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app because it is a live implementation of the process described here. 

{{% /alert %}} 

## **Import PowerPoint from HTML**

Aspose.Slides allows you to import presentations from HTML files. In this case, you get to convert a HTML document to a PowerPoint presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. 
2. Call the [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) method and pass the HTML file. 
3. Use the [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) method to save the file as a PowerPoint document.

This C# code demonstrates the HTML to PowerPoint operation:

```c#
using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

