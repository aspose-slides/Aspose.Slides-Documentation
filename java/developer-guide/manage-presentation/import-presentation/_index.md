---
title: Import Presentation
type: docs
weight: 60
url: /java/import-presentation/
keywords: "Import PowerPoint, PDF to Presentation, PDF to PPTX, PDF to PPT, Java, Aspose.Slides for Java"
description: "Import PowerPoint presentation from PDF. Convert PDF to PowerPoint"
---

Aspose.Slides for Java allows you to import presentations from PDFs. Essentially, you get to convert a PDF to a PowerPoint presentation.

![pdf-to-powerpoint](pdf-to-powerpoint.png)

Go through these steps:

1. Instantiate an object of the presentation class. 
2. Call the [addFromPdf()](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) method and pass the PDF file. 
3. Use the [save()](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) method to save the file in the PowerPoint format.

This Java code demonstrates the PDF to PowerPoint process:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 

You may want to check out **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app because it is a live implementation of the process described here. 

{{% /alert %}} 

