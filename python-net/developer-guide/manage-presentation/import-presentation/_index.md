---
title: Import Presentation
type: docs
weight: 60
url: /python-net/import-presentation/
keywords: "Import PowerPoint, PDF to Presentation, PDF to PPTX, PDF to PPT, Python, Aspose.Slides for Python via .NET"
description: "Import PowerPoint presentation from PDF. Convert PDF to PowerPoint"
---

Using [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) class to allow you to import presentations from PDFs, HTML documents, etc. 

## **Import PowerPoint from PDF**

In this case, you get to convert a PDF to a PowerPoint presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instantiate an object of the presentation class. 
2. Call the `add_from_pdf` method and pass the PDF file. 
3. Use the `save` method to save the file in the PowerPoint format.

This Python code demonstrates the PDF to PowerPoint operation:

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

## **Import PowerPoint from HTML**

In this case, you get to convert a HTML document to a PowerPoint presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. 
2. Call the `add_from_html` method and pass the HTML file. 
3. Use the `save` method to save the file as a PowerPoint document.

This Python code demonstrates the HTML to PowerPoint operation: 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("page.html", "rb") as htmlStream:
        pres.slides.add_from_html(htmlStream)

    pres.save("MyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

You may also use Aspose.Slides to convert HTML to other popular file formats: 

* [HTML to image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}
