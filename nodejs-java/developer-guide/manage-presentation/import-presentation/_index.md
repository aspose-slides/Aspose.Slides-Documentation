---
title: Import Presentation
type: docs
weight: 60
url: /nodejs-java/import-presentation/
keywords: "Import PowerPoint, PDF to Presentation, PDF to PPTX, PDF to PPT, Java, Aspose.Slides for Java"
description: "Import PowerPoint presentation from PDF. Convert PDF to PowerPoint"
---

Using [**Aspose.Slides for Java**](https://products.aspose.com/slides/java/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) class to allow you to import presentations from PDFs, HTML documents, etc.

## **Import PowerPoint from PDF**

In this case, you get to convert a PDF to a PowerPoint presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) class.
2. Call the [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) method and pass the PDF file.
3. Use the [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) method to save the file in the PowerPoint format.

This Java code demonstrates the PDF to PowerPoint operation:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        pres.getSlides().addFromPdf("InputPDF.pdf");
        pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

{{% alert  title="Tip" color="primary" %}} 

You may want to check out **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app because it is a live implementation of the process described here. 

{{% /alert %}} 

## **Import PowerPoint from HTML**

In this case, you get to convert a HTML document to a PowerPoint presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) class.
2. Call the [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) method and pass the PDF file.
3. Use the [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) method to save the file in the PowerPoint format.

This Java code demonstrates the HTML to PowerPoint operation: 

```javascript
    var presentation = new  aspose.slides.Presentation();
    try {
        var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
        try {
            presentation.getSlides().addFromHtml(htmlStream);
        } finally {
            if (htmlStream != null) {
                htmlStream.close();
            }
        }
        presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (e) {
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```

{{% alert title="Note" color="warning" %}} 

You may also use Aspose.Slides to convert HTML to other popular file formats: 

* [HTML to image](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}
