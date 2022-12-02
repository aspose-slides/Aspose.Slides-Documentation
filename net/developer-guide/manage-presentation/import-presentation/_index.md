---
title: Import PowerPoint from PDF or HTML
linktitle: Import Presentation
type: docs
weight: 60
url: /net/import-presentation/
keywords: "Import PowerPoint, PDF to PowerPoint, HTML to PowerPoint, PDF to PPT, HTML to PPT, C#, Csharp, Aspose.Slides for .NET"
description: "Import PowerPoint from PDF or HTML. Convert PDF to PowerPoint. Convert HTML to PowerPoint"
---

Using [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) class to allow you to import presentations from PDF documents.

## **Import PowerPoint from PDF**

In this case, you get to convert a PDF to a PowerPoint presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. 
2. Call the [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) method and pass the PDF file. 
3. Use the [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) method to save the file in the PowerPoint format.

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

In this case, you get to convert a HTML document to a PowerPoint presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. 
2. Call the [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) method and pass the HTML file. 
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

{{% alert title="Note" color="warning" %}} 

You may also use Aspose.Slides to convert HTML to other popular file formats: 

* [HTML to image](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}
